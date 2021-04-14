using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace StudentManagement
{
    public partial class FrmManageCourse : Form
    {
        public FrmManageCourse()
        {
            InitializeComponent();
            btnRefresh_Click(new object(), new EventArgs());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataCourse.Rows.Clear();
            List<CourseDTO> courseDtos = loadCourse();
            for (int i = 0; i < courseDtos.Count; i++)
            {
                String courseId = courseDtos[i].CourseId;
                String label = courseDtos[i].Label;
                int period = courseDtos[i].Period;
                String description = courseDtos[i].Description;

                dataCourse.Rows.Add(courseId, label, period, description);
            }
        }

        private List<CourseDTO> loadCourse()
        {
            String url = "http://localhost:8081/api/course";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            CourseDTO courseDto = DTOMapper.GetInstance().Map<CourseDTO>(jObject);

            if (courseDto == null)
            {
                lbStatus.Text = "Something's wrong.";
                return null;
            }

            List<CourseDTO> lRes = new List<CourseDTO>();
            for (int i = 0; i < courseDto.ListResult.Count; i++)
                lRes.Add((CourseDTO)courseDto.ListResult[i]);

            return lRes;
        }

        private void btnToPrinter_Click(object sender, EventArgs e)
        {
            ExportDataToWord();
        }

        private void ExportDataToWord()
        {
            if (dataCourse.Rows.Count != 0)
            {
               
                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                // add title
                var pText = oDoc.Paragraphs.Add();
                pText.Format.SpaceAfter = 10f;
                pText.Range.Text = String.Format("This is line #{0}", 1);
                pText.Range.InsertParagraphAfter();

                //add rows
                int RowCount = dataCourse.Rows.Count;
                int ColumnCount = dataCourse.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = dataCourse.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic pTable = oDoc.Paragraphs.Add();

                dynamic oRangeTable = oDoc.Content.Application.Selection.Range;
                string oContentTable = "";

                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oContentTable = oContentTable + DataArray[r, c] + "\t";

                    }
                }

                // Insert table
                pTable = oDoc.Paragraphs.Add();
                pTable.Format.SpaceAfter = 10f;
                var table = oDoc.Tables.Add(pTable.Range, RowCount, ColumnCount, WdDefaultTableBehavior.wdWord9TableBehavior);
                for (r = 1; r <= table.Rows.Count; r++)
                    for (var c = 1; c <= table.Columns.Count; c++)
                        table.Cell(r, c).Range.Text = (String)DataArray[r-1, c-1];

                ////table format
                ////oRangeTable.Text = oContentTable;
                //pTable.Format.SpaceAfter = 10f;
                //pTable.Range.Text = oContentTable;

                //object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                //object ApplyBorders = true;
                //object AutoFit = true;
                //object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                //pTable.Range.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                //                      Type.Missing, Type.Missing, ref ApplyBorders,
                //                      Type.Missing, Type.Missing, Type.Missing,
                //                      Type.Missing, Type.Missing, Type.Missing,
                //                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                //pTable.Range.Select();

                //pTable.Range.Tables[1].Select();
                //oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                //oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                //oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //oDoc.Application.Selection.InsertRowsAbove(1);
                //oDoc.Application.Selection.Tables[1].Rows[1].Select();

                ////header row style
                //oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                //oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Times New Roman";
                //oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                ////add header row manually
                //for (int c = 0; c <= ColumnCount - 1; c++)
                //{
                //    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dataCourse.Columns[c].HeaderText;
                //}

                ////table style 
                //oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                //oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                //foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                //{
                //    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                //    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                //    headerRange.Text = " ";
                //    headerRange.Font.Size = 16;
                //    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //}

                //save the file
                //oDoc.SaveAs2("course.docx");

                //NASSIM LOUCHANI
            }
        }
    }
}

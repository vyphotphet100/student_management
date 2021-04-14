using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
//using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmStudentList : Form
    {
        public FrmStudentList()
        {
            InitializeComponent();
            btnRefresh_Click(new object(), new EventArgs());
        }

        private void dataStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataStudent.CurrentCell.ColumnIndex.Equals(0))
            {
                if (dataStudent.CurrentCell != null && dataStudent.CurrentCell.Value != null)
                {
                    FrmUpdateDeleteStudent frmUpdateDeleteStudent = new FrmUpdateDeleteStudent(dataStudent.CurrentCell.Value.ToString());
                    DialogResult dr = frmUpdateDeleteStudent.ShowDialog(this);
                }
            }
        }

        private void LoadData(String condition)
        {
            dataStudent.Rows.Clear();

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (responseDto.HttpStatus == "OK")
                for (int i = 0; i < responseDto.ListResult.Count; i++)
                {
                    String studentId = ((StudentDTO)responseDto.ListResult[i]).StudentID;
                    String fName = ((StudentDTO)responseDto.ListResult[i]).FirstName;
                    String lName = ((StudentDTO)responseDto.ListResult[i]).LastName;
                    DateTime birthday = ((StudentDTO)responseDto.ListResult[i]).Birthday;
                    String gender = ((StudentDTO)responseDto.ListResult[i]).Gender;
                    String phone = ((StudentDTO)responseDto.ListResult[i]).Phone;
                    String address = ((StudentDTO)responseDto.ListResult[i]).Address;

                    WebClient client = new WebClient();
                    byte[] picAvtByte = client.DownloadData(@"http://localhost:8081" + ((StudentDTO)responseDto.ListResult[i]).Picture);
                    Image picAvt = Image.FromStream(new MemoryStream(picAvtByte));
                    
                    if ((condition.Contains("filter_male") && gender == "Male") ||
                        (condition.Contains("filter_female") && gender == "Female") ||
                        condition.Contains("filter_all"))
                    {
                        if (condition.Contains("birthday_no") ||
                           (condition.Contains("birthday_yes") && birthday.Ticks - datm1.Value.Ticks > 0 && birthday.Ticks - datm2.Value.Ticks < 0))
                            dataStudent.Rows.Add(studentId, fName, lName, address, birthday.ToString("dd/MM/yyyy"), gender, phone, picAvt);
                    }
                        
                }
            lbStatus.Text = responseDto.Message;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            String condition = "";
            if (rBtnAll.Checked)
                condition += "filter_all;";
            if (rBtnMale.Checked)
                condition += "filter_male;";
            if (rBtnFemale.Checked)
                condition += "filter_female;";
            if (rBtnYes.Checked)
                condition += "birthday_yes;";
            if (rBtnNo.Checked)
                condition += "birthday_no;";

            LoadData(condition);
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataStudent, false);
        }

        private void rBtnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnYes.Checked)
            {
                datm1.Enabled = true;
                datm2.Enabled = true;
            }
            else
            {
                datm1.Enabled = false;
                datm2.Enabled = false;
            }
        }

        private void btnToPrinter_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataStudent, true);
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataStudent.Width, dataStudent.Height);
            dataStudent.DrawToBitmap(bm, new Rectangle(0, 0, dataStudent.Width, dataStudent.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void ExportDataGridViewToExcel(DataGridView dataGridView, bool isPrint)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].GetType() != typeof(DataGridViewImageCell))
                    {
                        if (dataGridView.Columns[j].HeaderText == "Phone")
                            worksheet.Cells[i + 2, j + 1] = "'" + dataGridView.Rows[i].Cells[j].Value.ToString();
                        else
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }

                    else
                    {
                        // Save image from dataGridView to local
                        ((Image)dataGridView.Rows[i].Cells[j].Value).Save(Application.StartupPath + @"\Download\picAvt.png");

                        // You have to get original path here
                        string imagString = Application.StartupPath + @"\Download\picAvt.png";
                        Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
                        float Left = (float)((double)oRange.Left);
                        float Top = (float)((double)oRange.Top);
                        const float ImageSize = 80;

                        worksheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                        oRange.RowHeight = ImageSize + 2;
                    }
                }
            }
            worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
            // save the application  
            //workbook.SaveAs(Application.StartupPath + @"\Backup\data_student.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //app.Quit();

            if (isPrint)
                worksheet.PrintPreview();
        }
    }
}

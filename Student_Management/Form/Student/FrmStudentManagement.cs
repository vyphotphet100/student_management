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
using Microsoft.Office.Interop.Word;

namespace StudentManagement
{
    public partial class FrmStudentManagement : Form
    {
        public FrmStudentManagement()
        {
            InitializeComponent();
            btnRefresh_Click(new object(), new EventArgs());
        }

        private void LoadData(String condition)
        {
            dataStudent.Rows.Clear();

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (responseDto.HttpStatus == "OK")
                for (int i = 0; i < responseDto.ListResult.Count; i++)
                {
                    String studentId = (String)responseDto.ListResult[i]["id"];
                    String fName = (String)responseDto.ListResult[i]["firstName"];
                    String lName = (String)responseDto.ListResult[i]["lastName"];

                    //set birthday
                    long jsonDate = (long)responseDto.ListResult[i]["birthday"];
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                    DateTime birthday = date;

                    String gender = (String)responseDto.ListResult[i]["gender"];
                    String phone = (String)responseDto.ListResult[i]["phoneNumber"];
                    String address = (String)responseDto.ListResult[i]["address"];

                    WebClient client = new WebClient();
                    byte[] picAvtByte = client.DownloadData(@"http://localhost:8081" + (String)responseDto.ListResult[i]["picture"] + "?option=getFile");
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
            downloadListOfStudent();
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\student\list_of_student.docx");
            ap.Visible = true;
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

        public void btnToPrinter_Click(object sender, EventArgs e)
        {
            downloadListOfStudent();
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\student\list_of_student.docx");
            ap.Visible = true;
            document.PrintPreview();
        }

        private void ExportDataGridViewToExcel(DataGridView dataGridView, bool isPrint)
        {
            //// creating Excel Application  
            //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //// creating new WorkBook within Excel application  
            //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //// creating new Excelsheet in workbook  
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //// see the excel sheet behind the program  
            //app.Visible = true;
            //// get the reference of first sheet. By default its name is Sheet1.  
            //// store its reference to worksheet  
            //worksheet = workbook.Sheets["Sheet1"];
            //worksheet = workbook.ActiveSheet;
            //// changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            //// storing header part in Excel  
            //for (int i = 0; i < dataGridView.Columns.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            //}
            //// storing Each row and column value to excel sheet  
            //for (int i = 0; i < dataGridView.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dataGridView.Columns.Count; j++)
            //    {
            //        if (dataGridView.Rows[i].Cells[j].GetType() != typeof(DataGridViewImageCell))
            //        {
            //            if (dataGridView.Columns[j].HeaderText == "Phone")
            //                worksheet.Cells[i + 2, j + 1] = "'" + dataGridView.Rows[i].Cells[j].Value.ToString();
            //            else
            //                worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
            //        }

            //        else
            //        {
            //            // Save image from dataGridView to local
            //            ((Image)dataGridView.Rows[i].Cells[j].Value).Save(Application.StartupPath + @"\Download\picAvt.png");

            //            // You have to get original path here
            //            string imagString = Application.StartupPath + @"\Download\picAvt.png";
            //            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
            //            float Left = (float)((double)oRange.Left);
            //            float Top = (float)((double)oRange.Top);
            //            const float ImageSize = 80;

            //            worksheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
            //            oRange.RowHeight = ImageSize + 2;
            //        }
            //    }
            //}
            //worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
            //// save the application  
            ////workbook.SaveAs(Application.StartupPath + @"\Backup\data_student.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ////app.Quit();

            //if (isPrint)
            //    worksheet.PrintPreview();
        }

        private void downloadListOfStudent()
        {
            String url = "http://localhost:8081/api/file/student?option=print";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (studentDto.HttpStatus == "OK")
            {
                url = "http://localhost:8081" + studentDto.ListResult[0].ToObject<String>() + "?option=getFile";

                var client = new WebClient();
                client.DownloadFile(url, @"sources\student\list_of_student.docx");

            }
        }
    }
}

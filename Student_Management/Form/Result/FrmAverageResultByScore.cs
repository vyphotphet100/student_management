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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmAverageResultByScore : Form
    {
        public FrmAverageResultByScore()
        {
            InitializeComponent();
        }

        private List<SectionClassDTO> loadCourse()
        {
            String url = "http://localhost:8081/api/section_class";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            SectionClassDTO sectionClassDto = DTOMapper.GetInstance().Map<SectionClassDTO>(jObject);

            if (sectionClassDto == null)
            {
                lbStatus.Text = "Something's wrong.";
                return null;
            }

            List<SectionClassDTO> lRes = new List<SectionClassDTO>();
            for (int i = 0; i < sectionClassDto.ListResult.Count; i++)
                lRes.Add((SectionClassDTO)DTOMapper.GetInstance().Map<SectionClassDTO>(sectionClassDto.ListResult[i].ToObject<JObject>()));

            return lRes;
        }

        private List<RegisterDTO> loadRegister()
        {
            JObject jObj = HttpUtils.GetRequest("http://localhost:8081/api/register", Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObj);

            List<RegisterDTO> registerDtos = new List<RegisterDTO>();
            if (registerDto.ListResult != null)
            {
                for (int i = 0; i < registerDto.ListResult.Count; i++)
                    registerDtos.Add(DTOMapper.GetInstance().Map<RegisterDTO>(registerDto.ListResult[i].ToObject<JObject>()));
            }

            return registerDtos;
        }

        private List<StudentDTO> loadStudent()
        {
            List<StudentDTO> studentDtos = new List<StudentDTO>();

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            for (int i=0; i< responseDto.ListResult.Count; i++)
            {
                StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(responseDto.ListResult[i].ToObject<JObject>());
                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataStudentResult.Rows.Clear();
            dataStudentResult.Columns.Clear();
            txbStudentID.Text = "";
            txbFirstName.Text = "";
            txbLastName.Text = "";

            if (rBtnLastName.Checked)
            {
                List<StudentDTO> studentDtos = loadStudent();
                dataStudentResult.Columns.Add("colStudentID", "Student ID");
                dataStudentResult.Columns.Add("colFirstName", "First name");
                dataStudentResult.Columns.Add("colLastName", "Last name");
                dataStudentResult.Columns.Add("colBirthday", "Birthday");

                for (int i = 0; i < dataStudentResult.Columns.Count; i++)
                    dataStudentResult.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i=0; i<studentDtos.Count; i++)
                {
                    if (studentDtos[i].LastName.Trim() == txbSearch.Text.Trim())
                        dataStudentResult.Rows.Add(studentDtos[i].Id, studentDtos[i].FirstName, studentDtos[i].LastName, studentDtos[i].Birthday.ToString("dd/MM/yyyy"));
                }

                if (dataStudentResult.Rows.Count == 0)
                    lbStatus.Text = "There is no student having First name = " + txbSearch.Text;
            }
            else if (rBtnID.Checked)
            {
                // add columns
                List<StudentDTO> studentDtos = loadStudent();
                StudentDTO studentDto = new StudentDTO();
                List<SectionClassDTO> sectionClassDtos = loadCourse();

                for (int i=0; i<studentDtos.Count; i++)
                    if (studentDtos[i].Id == txbSearch.Text)
                    {
                        studentDto = studentDtos[i];
                        break;
                    }

                if (studentDto.Id == null)
                {
                    lbStatus.Text = "There is no student having id = " + txbSearch.Text;
                    return;
                }

                List<RegisterDTO> registerDtos = loadRegister();
                List<RegisterDTO> registeredDtos = new List<RegisterDTO>();
                for (int i = 0; i < registerDtos.Count; i++)
                    if (registerDtos[i].StudentId == studentDto.Id)
                        registeredDtos.Add(registerDtos[i]);

                dataStudentResult.Columns.Add("colStudentID", "Student ID");
                dataStudentResult.Columns.Add("colFirstName", "First name");
                dataStudentResult.Columns.Add("colLastName", "Last name");
                for(int i=0; i<registeredDtos.Count; i++)
                {
                    String sectionClassName = "";
                    for (int k=0; k<sectionClassDtos.Count; k++)
                    {
                        if (registeredDtos[i].SectionClassId == sectionClassDtos[k].Id)
                        {
                            sectionClassName = sectionClassDtos[k].Name;
                            break;
                        }
                    }

                    dataStudentResult.Columns.Add("col" + registeredDtos[i].Id, sectionClassName);
                }
                dataStudentResult.Columns.Add("colAverageScore", "Average score");
                dataStudentResult.Columns.Add("colResult", "Result");

                for (int i = 0; i < dataStudentResult.Columns.Count; i++)
                    dataStudentResult.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // add data
                dataStudentResult.Rows.Add();
                dataStudentResult.Rows[0].Cells[0].Value = studentDto.Id;
                dataStudentResult.Rows[0].Cells[1].Value = studentDto.FirstName;
                dataStudentResult.Rows[0].Cells[2].Value = studentDto.LastName;
                Double totalScore = 0;
                for (int i=0; i<registeredDtos.Count; i++)
                {
                    dataStudentResult.Rows[0].Cells[i + 3].Value = registeredDtos[i].EndTermMark;
                    totalScore += Convert.ToDouble(dataStudentResult.Rows[0].Cells[i + 3].Value);
                }
                Double avgScore = totalScore / registeredDtos.Count;
                dataStudentResult.Rows[0].Cells[registeredDtos.Count + 3].Value = avgScore;
                if (avgScore >= 5)
                    dataStudentResult.Rows[0].Cells[registeredDtos.Count + 4].Value = "Pass";
                else
                    dataStudentResult.Rows[0].Cells[registeredDtos.Count + 4].Value = "Fail";
            }
        }

        private void dataStudentResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Selected = true;
            if (dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[0].Value != null &&
                dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[1].Value != null &&
                dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[2].Value != null)
            {
                txbStudentID.Text = dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txbFirstName.Text = dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txbLastName.Text = dataStudentResult.Rows[dataStudentResult.CurrentCell.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txbStudentID.Text.Trim() == "")
            {
                lbStatus.Text = "You did not choose student.";
                return;
            }

            String url = "http://localhost:8081/api/file/student/"+ txbStudentID.Text +"?option=printResult";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (studentDto.HttpStatus == "OK")
            {
                url = "http://localhost:8081" + studentDto.ListResult[0].ToObject<String>() + "?option=getFile";

                var client = new WebClient();
                string dir = @"sources\student\" + txbStudentID.Text;
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                client.DownloadFile(url, dir + @"\result.docx");

            }

            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\student\"+ txbStudentID.Text + @"\result.docx");
            ap.Visible = true;
            document.PrintPreview();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

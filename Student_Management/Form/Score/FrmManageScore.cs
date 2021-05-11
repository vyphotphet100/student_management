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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmManageScore : Form
    {
        bool checkSetTxbStudentId = false;
        public FrmManageScore()
        {
            InitializeComponent();
            loadCourseToCbx();
            btnShowStudent_Click(new object(), new EventArgs());
        }

        private void loadStudentToDGV()
        {

            dataGRV.Rows.Clear();
            dataGRV.Columns.Clear();

            // add column
            dataGRV.Columns.Add("colStudentID", "Student ID");
            dataGRV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colFName", "First name");
            dataGRV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colLName", "Last name");
            dataGRV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colBirthday", "Birthday");
            dataGRV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (responseDto.HttpStatus == "OK")
                for (int i = 0; i < responseDto.ListResult.Count; i++)
                {
                    StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(responseDto.ListResult[i].ToObject<JObject>());

                    String studentId = studentDto.Id;
                    String fName = studentDto.FirstName;
                    String lName = studentDto.LastName;
                    String birthday = studentDto.Birthday.ToString("dd/MM/yyyy");

                    dataGRV.Rows.Add(studentId, fName, lName, birthday);

                }
        }

        private void loadRegisterToDGV()
        {

            dataGRV.Rows.Clear();
            dataGRV.Columns.Clear();

            // add column
            dataGRV.Columns.Add("colStudentID", "Student ID");
            dataGRV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colCourseID", "Course ID");
            dataGRV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colLabel", "Label");
            dataGRV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colScore", "Score");
            dataGRV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colDescription", "Description");
            dataGRV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colId", "id");
            dataGRV.Columns[5].Visible = false;

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/register/student_id/" + txbStudentID.Text, 
                Globals.TokenCode, null);
            RegisterDTO responseDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObject);
            List<SectionClassDTO> sectionClassDtos = loadCourse();

            if (responseDto.HttpStatus == "OK")
                for (int i = 0; i < responseDto.ListResult.Count; i++)
                {
                    String studentId = (String)responseDto.ListResult[i]["studentId"];
                    String sectionClassId = (String)responseDto.ListResult[i]["sectionClassId"];
                    String label = "";
                    for (int k=0; k< sectionClassDtos.Count; k++)
                        if (sectionClassDtos[k].Id == sectionClassId)
                        {
                            label = sectionClassDtos[k].Name;
                            break;
                        }
                    String endTermMark = (String)responseDto.ListResult[i]["endTermMark"];
                    String description = (String)responseDto.ListResult[i]["description"];
                    String id = (String)responseDto.ListResult[i]["id"];

                    dataGRV.Rows.Add(studentId, sectionClassId, label, endTermMark, description, id);

                }

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

        private void loadCourseToCbx()
        {
            // add section class id to cbxCourse
            List<SectionClassDTO> sectionClassDtos = loadCourse();
            for (int i = 0; i < sectionClassDtos.Count; i++)
                cbxCourse.Items.Add(sectionClassDtos[i].Id);
        }

        private void dataGRV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGRV.Rows[dataGRV.CurrentCell.RowIndex].Selected = true;
            if (checkSetTxbStudentId)
            {
                txbStudentID.Text = dataGRV.Rows[dataGRV.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            

        }

        private void btnShowStudent_Click(object sender, EventArgs e)
        {
            loadStudentToDGV();
            btnRemove.Enabled = false;
            if (dataGRV.RowCount != 0)
                dataGRV.Rows[0].Selected = true;
            txbStudentID.Text = dataGRV.Rows[0].Cells[0].Value.ToString();
            cbxCourse.Enabled = false;
            txbScore.Enabled = false;
            txbDescription.Enabled = false;

            btnAdd.Enabled = false;
            checkSetTxbStudentId = true;
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            loadRegisterToDGV();
            btnRemove.Enabled = true;
            if (dataGRV.RowCount != 0)
                dataGRV.Rows[0].Selected = true;
            txbStudentID.Text = dataGRV.Rows[0].Cells[0].Value.ToString();
            cbxCourse.Enabled = true;
            txbScore.Enabled = true;
            txbDescription.Enabled = true;

            btnAdd.Enabled = true;
            checkSetTxbStudentId = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/register";

            var data = new Dictionary<String, Object>
            {
                { "studentId", txbStudentID.Text },
                { "sectionClassId", cbxCourse.Text },
                { "endTermMark", txbScore.Text },
                { "description", txbDescription.Text }
            };

            JObject jObject = HttpUtils.PostRequest(url, Globals.TokenCode, data);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObject);

            if (registerDto != null)
            {
                lbStatus.Text = registerDto.Message;
            }

            loadRegisterToDGV();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            String id = dataGRV.Rows[dataGRV.CurrentCell.RowIndex].Cells[5].Value.ToString();

            JObject jObj = HttpUtils.DeleteRequest("http://localhost:8081/api/register/" + id, Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObj);

            if (registerDto != null)
                lbStatus.Text = registerDto.Message;

            loadRegisterToDGV();
        }

        public void btnAverage_Click(object sender, EventArgs e)
        {
            List<RegisterDTO> registerDtos = loadRegister();
            List<SectionClassDTO> sectionClassDtos = loadCourse();
            dataGRV.Rows.Clear();
            dataGRV.Columns.Clear();

            // add column
            dataGRV.Columns.Add("colLabel", "Label");
            dataGRV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGRV.Columns.Add("colAverageScore", "Average score");
            dataGRV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // compute average score
            for (int i=0; i<sectionClassDtos.Count; i++)
            {
                String label = sectionClassDtos[i].Name;
                double totalScore = 0;
                int n = 0;
                for (int k=0; k<registerDtos.Count; k++)
                {
                    if (registerDtos[k].SectionClassId == sectionClassDtos[i].Id)
                    {
                        n++;
                        totalScore += registerDtos[k].EndTermMark;
                    }
                }

                double avgScore = totalScore / n;

                dataGRV.Rows.Add(label, avgScore);
            }


            btnRemove.Enabled = false;
            if (dataGRV.RowCount != 0)
                dataGRV.Rows[0].Selected = true;
            cbxCourse.Enabled = false;
            txbScore.Enabled = false;
            txbDescription.Enabled = false;
            txbStudentID.Text = "";

            btnAdd.Enabled = false;
            checkSetTxbStudentId = false;
        }

        public void btnPrint_Click(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/file/register?option=print";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObject);

            if (registerDto.HttpStatus == "OK")
            {
                url = "http://localhost:8081" + (String)registerDto.ListResult[0] + "?option=getFile";

                var client = new WebClient();
                client.DownloadFile(url, @"sources\register\list_of_register.docx");

            }

            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\register\list_of_register.docx");
            ap.Visible = true;
            document.PrintPreview();
        }
    }
}

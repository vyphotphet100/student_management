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

namespace StudentManagement
{
    public partial class FrmAddScore : Form
    {
        public FrmAddScore()
        {
            InitializeComponent();
            loadStudentToDGV();

            // add section class id to cbxCourse
            List<SectionClassDTO> sectionClassDtos = loadCourse();
            for (int i = 0; i < sectionClassDtos.Count; i++)
                cbxCourse.Items.Add(sectionClassDtos[i].Id);
        }

        private void loadStudentToDGV()
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

                    dataStudent.Rows.Add(studentId, fName, lName);

                }
            lbStatus.Text = responseDto.Message;

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

        private void dataStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataStudent.CurrentCell.ColumnIndex == 0)
            {
                txbStudentId.Text = dataStudent.CurrentCell.Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/register";

            var data = new Dictionary<String, Object>
            {
                { "studentId", txbStudentId.Text },
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
        }
    }
}

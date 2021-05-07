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
    public partial class FrmEditCourse : Form
    {
        public FrmEditCourse()
        {
            InitializeComponent();
            List<SectionClassDTO> sectionClassDtos = loadListCourse();
            for (int i = 0; i < sectionClassDtos.Count; i++)
                cbxCourses.Items.Add(sectionClassDtos[i].Id);
        }

        List<SectionClassDTO> loadListCourse()
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
                lRes.Add(DTOMapper.GetInstance().Map<SectionClassDTO>(sectionClassDto.ListResult[i].ToObject<JObject>()));

            return lRes;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // get current section class
            String urlGet = "http://localhost:8081/api/section_class/" + cbxCourses.Text;

            JObject jObjectGet = HttpUtils.GetRequest(urlGet, Globals.TokenCode, null);
            SectionClassDTO sectionClassDtoGet = DTOMapper.GetInstance().Map<SectionClassDTO>(jObjectGet);

            // edit current seciton class
            String urlEdit = "http://localhost:8081/api/section_class";

            // get course id
            String courseId = "";
            for (int i = 0; i < cbxCourses.Text.Length; i++)
                if (cbxCourses.Text[i] != '_')
                    courseId += cbxCourses.Text[i];
                else
                    break;

            var data = new Dictionary<String, Object>
            {
                { "id", cbxCourses.Text },
                { "name", txbLabel.Text },
                { "startTime", sectionClassDtoGet.StartTime },
                { "endTime", sectionClassDtoGet.EndTime },
                { "period", nUDPeriod.Text },
                { "courseId", courseId },
                { "lecturerId", sectionClassDtoGet.LecturerId },
                { "room", sectionClassDtoGet.Room },
                { "description", txbDescription.Text }
            };
            JObject jObjectEdit = HttpUtils.PutRequest(urlEdit, Globals.TokenCode, data);
            SectionClassDTO sectionClassDtoEdit = DTOMapper.GetInstance().Map<SectionClassDTO>(jObjectEdit);

            if (sectionClassDtoEdit != null)
                lbStatus.Text = sectionClassDtoEdit.Message;
            else
                lbStatus.Text = "Something's wrong.";
        }

        private void cbxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/section_class/" + cbxCourses.Text;

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            SectionClassDTO sectionClassDto = DTOMapper.GetInstance().Map<SectionClassDTO>(jObject);

            if (sectionClassDto != null)
            {
                lbStatus.Text = sectionClassDto.Message;
                if (sectionClassDto.HttpStatus == "OK")
                {
                    txbLabel.Text = sectionClassDto.Name;
                    nUDPeriod.Value = sectionClassDto.Period;
                    txbDescription.Text = sectionClassDto.Description;
                }
            }
            else
                lbStatus.Text = "Something's wrong.";
        }
    }
}

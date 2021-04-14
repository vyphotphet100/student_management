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
            List<CourseDTO> courseDtos = loadListCourse();
            for (int i = 0; i < courseDtos.Count; i++)
                cbxCourses.Items.Add(courseDtos[i].CourseId);
        }

        List<CourseDTO> loadListCourse()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/course";

            var data = new Dictionary<String, Object>
            {
                { "courseId", cbxCourses.Text },
                { "label", txbLabel.Text },
                { "period", nUDPeriod.Text },
                { "description", txbDescription.Text }
            };
            JObject jObject = HttpUtils.PutRequest(url, Globals.TokenCode, data);
            CourseDTO courseDto = DTOMapper.GetInstance().Map<CourseDTO>(jObject);

            if (courseDto != null)
                lbStatus.Text = courseDto.Message;
            else
                lbStatus.Text = "Something's wrong.";
        }

        private void cbxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            String url = "http://localhost:8081/api/course/" + cbxCourses.Text;

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            CourseDTO courseDto = DTOMapper.GetInstance().Map<CourseDTO>(jObject);

            if (courseDto != null)
            {
                lbStatus.Text = courseDto.Message;
                if (courseDto.HttpStatus == "OK")
                {
                    txbLabel.Text = courseDto.Label;
                    nUDPeriod.Value = courseDto.Period;
                    txbDescription.Text = courseDto.Description;
                }
            }
            else
                lbStatus.Text = "Something's wrong.";
        }
    }
}

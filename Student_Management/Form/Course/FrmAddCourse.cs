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
    public partial class FrmAddCourse : Form
    {
        public FrmAddCourse()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!verify())
                return;

            String url = "http://localhost:8081/api/section_class";

            // get course id
            String courseId = "";
            for (int i = 0; i < txbCourseID.Text.Length; i++)
                if (txbCourseID.Text[i] != '_')
                    courseId += txbCourseID.Text[i];
                else
                    break;


            var data = new Dictionary<String, Object>
            {
                { "id", txbCourseID.Text },
                { "name", txbLabel.Text },
                { "period", txbPeriod.Text },
                { "courseId", courseId },
                { "room", "A3-305" },
                { "description", txbDescription.Text }
            };
            JObject jObject = HttpUtils.PostRequest(url, Globals.TokenCode, data);
            CourseDTO courseDto = DTOMapper.GetInstance().Map<CourseDTO>(jObject);

            if (courseDto != null)
                lbStatus.Text = courseDto.Message;
            else
                lbStatus.Text = "Something's wrong.";

        }

        private Boolean verify()
        {
            if (txbCourseID.Text.Trim() == "" ||
                txbLabel.Text.Trim() == "" ||
                txbPeriod.Text.Trim() == "" ||
                txbDescription.Text.Trim() == "")
                return false;
            return true;
        }
    }
}

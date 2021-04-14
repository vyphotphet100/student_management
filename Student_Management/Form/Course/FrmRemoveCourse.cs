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
    public partial class FrmRemoveCourse : Form
    {
        public FrmRemoveCourse()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txbCourseId.Text.Trim() == "")
                return;

            String url = "http://localhost:8081/api/course/" + txbCourseId.Text.Trim();

            JObject jObject = HttpUtils.DeleteRequest(url, Globals.TokenCode, null);
            CourseDTO courseDto = DTOMapper.GetInstance().Map<CourseDTO>(jObject);

            if (courseDto != null)
                lbStatus.Text = courseDto.Message;
            else
                lbStatus.Text = "Something's wrong.";
        }
    }
}

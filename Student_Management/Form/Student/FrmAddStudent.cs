using StudentManagement.DTO;
using StudentManagement.MyFile;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FrmAddStudent : Form
    {
        public FrmAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!verify())
                return;

            // up avatar
            var fileDto = new Dictionary<String, Object>
            {
                { "base64String",  PictureUtils.GetInstance().ToBase64String(picAvatar)},
                { "fileName", txbStudentID.Text + "/avatar" },
                { "fileType", "png" }
            };
            JObject jAvatar = HttpUtils.PostRequest("http://localhost:8081/api/file/student", Globals.TokenCode, fileDto);

            if ((String)jAvatar["httpStatus"] != "OK")
            {
                lbStatus.Text = "This student exists already.";
                return;
            }

            // save student
            // process string of gender
            String genderStr = null;
            if (rBtnMale.Checked)
                genderStr = "Male";
            else
                genderStr = "Female";

            var dataAddStudent = new Dictionary<String, Object>
            {
                { "id" , txbStudentID.Text},
                { "username" , txbStudentID.Text },
                { "password" , txbStudentID.Text },
                { "firstName" , txbFirstName.Text },
                { "lastName" , txbLastName.Text },
                { "fullname" , txbFirstName.Text.Trim() + " " +  txbLastName.Text.Trim() },
                { "birthday", datmBirthDay.Value.ToString("yyyy-MM-dd") },
                { "gender" , genderStr },
                { "phoneNumber", txbPhone.Text },
                { "address", txbAddress.Text },
                { "startYear", DateTime.Now.Year },
                { "picture", ((JArray)jAvatar["listResult"])[0].ToObject<String>() }
            };

            JObject jStudent = HttpUtils.PostRequest("http://localhost:8081/api/student", Globals.TokenCode, dataAddStudent);

            lbStatus.Text = (String)jStudent["message"];

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = new Bitmap(open.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool verify()
        {
            if (txbStudentID.Text.Trim() == "" ||
                txbFirstName.Text.Trim() == "" ||
                txbLastName.Text.Trim() == "" ||
                txbAddress.Text.Trim() == "" ||
                txbPhone.Text.Trim() == "" || 
                picAvatar.Image == null)
            {
                lbStatus.Text = "Something is wrong. Please check again.";
                return false;
            }

            return true;
        }
    }
}

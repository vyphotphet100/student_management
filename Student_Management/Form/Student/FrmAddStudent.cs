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

            StudentDTO studentDtoAva = DTOMapper.GetInstance().Map<StudentDTO>(StudentFile.upAvatar("http://localhost:8081", Globals.TokenCode, picAvatar, txbStudentID.Text));

            String url = "http://localhost:8081/api/student";

            // process string of gender
            String genderStr = null;
            if (rBtnMale.Checked)
                genderStr = "Male";
            else
                genderStr = "Female";

            var data = new Dictionary<String, Object>
            {
                { "studentId", txbStudentID.Text },
                { "firstName", txbFirstName.Text },
                { "lastName", txbLastName.Text },
                { "birthday", datmBirthDay.Value.ToString("yyyy-MM-dd") },
                { "gender", genderStr },
                { "phone", txbPhone.Text },
                { "address", txbAddress.Text },
                { "picture", studentDtoAva.Picture }
            };
            JObject jObject = HttpUtils.PostRequest(url, Globals.TokenCode, data);
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);
            lbStatus.Text = studentDto.Message;
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

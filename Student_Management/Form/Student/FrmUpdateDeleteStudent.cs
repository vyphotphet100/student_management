using StudentManagement.DTO;
using StudentManagement.MyFile;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmUpdateDeleteStudent : Form
    {
        public FrmUpdateDeleteStudent(String studentId)
        {
            InitializeComponent();
            if (studentId != "0")
            {
                txbId.Text = studentId;
                btnFind_Click(new object(), new EventArgs());
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txbId.Text.Trim() == "")
                return;

            txbId.ReadOnly = true;
            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student/" + txbId.Text, Globals.TokenCode, null);
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            lbStatus.Text = studentDto.Message;
            if (studentDto.HttpStatus == "OK")
            {
                txbFname.Text = studentDto.FirstName;
                txbLname.Text = studentDto.LastName;
                datmBirthday.Value = studentDto.Birthday;

                if (studentDto.Gender.ToLower() == "male")
                {
                    rBtnMale.Checked = true;
                    rBtnFemale.Checked = false;
                }
                else
                {
                    rBtnMale.Checked = false;
                    rBtnFemale.Checked = true;
                }

                txbPhone.Text = studentDto.Phone;
                txbAddress.Text = studentDto.Address;

                // picture
                WebClient client = new WebClient();
                byte[] bitmap = client.DownloadData(@"http://localhost:8081" + studentDto.Picture);
                Image image = Image.FromStream(new MemoryStream(bitmap));
                picAvatar.Image = image;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = new Bitmap(open.FileName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!verify())
                return;

            StudentDTO studentDtoAva = DTOMapper.GetInstance().Map<StudentDTO>(StudentFile.upAvatar("http://localhost:8081", 
                Globals.TokenCode, picAvatar, txbId.Text));

            String url = "http://localhost:8081/api/student";

            // process string of gender
            String genderStr = null;
            if (rBtnMale.Checked)
                genderStr = "Male";
            else
                genderStr = "Female";

            var data = new Dictionary<String, Object>
            {
                { "studentId", txbId.Text },
                { "firstName", txbFname.Text },
                { "lastName", txbLname.Text },
                { "birthday", datmBirthday.Value.ToString("yyyy-MM-dd") },
                { "gender", genderStr },
                { "phone", txbPhone.Text },
                { "address", txbAddress.Text },
                { "picture", studentDtoAva.Picture }
            };
            JObject jObject = HttpUtils.PutRequest(url, Globals.TokenCode, data);
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (studentDto != null)
            {
                lbStatus.Text = studentDto.Message;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(HttpUtils.DeleteRequest("http://localhost:8081/api/student/" + txbId.Text, Globals.TokenCode, null));
            if (studentDto.HttpStatus == "OK")
            {
                txbFname.Text = "";
                txbLname.Text = "";
                datmBirthday.Value = DateTime.Now;
                rBtnMale.Checked = true;
                rBtnFemale.Checked = false;
                txbPhone.Text = "";
                txbAddress.Text = "";
                picAvatar.Image = null;
            }
           
            lbStatus.Text = studentDto.Message;
            
        }

        private bool verify()
        {
            if (txbId.Text.Trim() == "" ||
                txbFname.Text.Trim() == "" ||
                txbLname.Text.Trim() == "" ||
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

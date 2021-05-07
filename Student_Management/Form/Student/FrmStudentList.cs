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
    public partial class FrmStudentList : Form
    {
        public FrmStudentList()
        {
            InitializeComponent();
            btnRefresh_Click(new object(), new EventArgs());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
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

                    //set birthday
                    long jsonDate = (long)responseDto.ListResult[i]["birthday"];
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                    DateTime birthday = date;

                    String gender = (String)responseDto.ListResult[i]["gender"];
                    String phone = (String)responseDto.ListResult[i]["phoneNumber"];
                    String address = (String)responseDto.ListResult[i]["address"];

                    WebClient client = new WebClient();
                    byte[] picAvtByte = client.DownloadData(@"http://localhost:8081" + (String)responseDto.ListResult[i]["picture"] + "?option=getFile");
                    Image picAvt = Image.FromStream(new MemoryStream(picAvtByte));

                    dataStudent.Rows.Add(studentId, fName, lName, address, birthday.ToString("dd/MM/yyyy"), gender, phone, picAvt);

                }
            lbStatus.Text = responseDto.Message;
        }

        private void dataStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataStudent.CurrentCell.ColumnIndex.Equals(0))
            {
                if (dataStudent.CurrentCell != null && dataStudent.CurrentCell.Value != null)
                {
                    FrmUpdateDeleteStudent frmUpdateDeleteStudent = new FrmUpdateDeleteStudent(dataStudent.CurrentCell.Value.ToString());
                    DialogResult dr = frmUpdateDeleteStudent.ShowDialog(this);
                }
            }
        }
    }
}

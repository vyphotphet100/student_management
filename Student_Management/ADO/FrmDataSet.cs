using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using Newtonsoft.Json.Linq;
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

namespace StudentManagement.ADO
{
    public partial class FrmDataSet : Form
    {
        DataSet dataSet;
        public FrmDataSet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = @"http://localhost:8081/login";
            var data = new Dictionary<String, Object>
                {
                    { "userName", "admin" },
                    { "password", "123456" }
                };
            UserDTO userDto = DTOMapper.GetInstance().Map<UserDTO>(HttpUtils.PostRequest(url, null, data));
            if (userDto.HttpStatus == "OK")
            {
                lbStatus.Text = "Logged by " + userDto.FullName;
                Globals.TokenCode = userDto.TokenCode;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataSet = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("Student ID");
            dt.Columns.Add("First name");
            dt.Columns.Add("Last name");
            dt.Columns.Add("Birthday");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Picture", typeof(byte[]));

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            for (int i = 0; i < responseDto.ListResult.Count; i++)
            {
                DataRow dr = null;
                dr = dt.NewRow();
                dr["Student ID"] = ((StudentDTO)responseDto.ListResult[i]).StudentID;
                dr["First name"] = ((StudentDTO)responseDto.ListResult[i]).FirstName;
                dr["Last name"] = ((StudentDTO)responseDto.ListResult[i]).LastName;
                dr["Birthday"] = ((StudentDTO)responseDto.ListResult[i]).Birthday;
                dr["Gender"] = ((StudentDTO)responseDto.ListResult[i]).Gender;
                dr["Phone"] = ((StudentDTO)responseDto.ListResult[i]).Phone;
                dr["Address"] = ((StudentDTO)responseDto.ListResult[i]).Address;

                WebClient client = new WebClient();
                dr["Picture"] = client.DownloadData(@"http://localhost:8081" + ((StudentDTO)responseDto.ListResult[i]).Picture);

                dt.Rows.Add(dr);
            }
            dataSet.Tables.Add(dt);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btnGetChange_Click(object sender, EventArgs e)
        {
            DataSet dataSetChange = new DataSet("Change");
            
            try
            {
                dataSetChange = dataSet.GetChanges();

                if (dataSetChange != null)
                {
                    dataGridView2.DataSource = dataSetChange.Tables[0];
                }
                else
                    dataGridView2.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            dataSet.AcceptChanges();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            dataSet.RejectChanges();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataSet.Clear();
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet.WriteXml(@"D:\TestXML.xml");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            try
            {
                dataSet.ReadXml(@"D:\TestXML.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            dataGridView2.DataSource = dataSet.Tables[0];
        }
    }
}

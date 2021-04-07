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
    public partial class FrmDataTable : Form
    {
        DataSet dataSet;
        public FrmDataTable()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
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

        private void FrmDataTable_Load(object sender, EventArgs e)
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

        private void btnRows_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0] != null)
            {
                string name = "";
                label3.Text = "Số Rows: " + dataSet.Tables[0].Rows.Count.ToString();
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    name += Convert.ToString(dataRow[2]) + "\n";
                }
                label2.Text = name;
            }
        }

        private void btnColumn_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0] != null)
            {
                string name = "";
                label3.Text = "Số Columns: " + dataSet.Tables[0].Columns.Count.ToString();
                foreach (DataColumn dataColumn in dataSet.Tables[0].Columns)
                {
                    name += Convert.ToString(dataColumn.ToString()) + "\n";
                }
                label2.Text = name;
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet.Tables[0].Columns.Add("New Column", typeof(String));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddRows_Click(object sender, EventArgs e)
        {
            object[] obj = new object[7] { "12345", "New", "Student", "20/4/2001", "Female", "0987654321", "Quang Binh" };
            dataSet.Tables[0].Rows.Add(obj);
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            DataTable dataTableClone = new DataTable();
            try
            {
                dataTableClone = dataSet.Tables[0].Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            this.dataGridView2.DataSource = dataTableClone;
        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
            DataTable dataTableClone = new DataTable();
            try
            {
                dataTableClone = dataSet.Tables[0].Clone();
                for (int i=0; i<dataSet.Tables[0].Rows.Count; i++)
                {
                    dataTableClone.ImportRow(dataSet.Tables[0].Rows[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            this.dataGridView2.DataSource = dataTableClone;
        }
    }
}

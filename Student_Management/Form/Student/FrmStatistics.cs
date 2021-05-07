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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
            DoStatistics();
        }

        private void DoStatistics()
        {
            int nMale = 0;
            int nFemale = 0;

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            if (responseDto.HttpStatus == "OK")
                for (int i = 0; i < responseDto.ListResult.Count; i++)
                {
                    String gender = (String)responseDto.ListResult[i]["gender"];
                    if (gender == "Male")
                        nMale++;
                    else
                        nFemale++;
                }

            chart1.Series["p1"].Points.AddXY("Male", nMale);
            chart1.Series["p1"].Points.AddXY("Female", nFemale);
            lbSumOfStudent.Text += (nMale + nFemale).ToString();
        }
    }
}

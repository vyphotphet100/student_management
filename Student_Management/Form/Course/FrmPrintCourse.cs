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
    public partial class FrmPrintCourse : Form
    {
        public FrmPrintCourse()
        {
            InitializeComponent();
            addCoursesToDataGV();
        }

        private List<CourseDTO> loadCourse()
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

        private void addCoursesToDataGV()
        {
            List<CourseDTO> courseDtos = loadCourse();
            for (int i=0; i<courseDtos.Count; i++)
            {
                dataCourse.Rows.Add(courseDtos[i].CourseId, courseDtos[i].Label, courseDtos[i].Period, courseDtos[i].Description);
            }
            
        }
    }
}

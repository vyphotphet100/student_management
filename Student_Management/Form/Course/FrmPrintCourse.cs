using Microsoft.Office.Interop.Word;
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
    public partial class FrmPrintCourse : Form
    {
        public FrmPrintCourse()
        {
            InitializeComponent();
            addCoursesToDataGV();
        }

        private List<SectionClassDTO> loadCourse()
        {
            String url = "http://localhost:8081/api/section_class";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            SectionClassDTO sectionClassDto = DTOMapper.GetInstance().Map<SectionClassDTO>(jObject);

            if (sectionClassDto == null)
            {
                lbStatus.Text = "Something's wrong.";
                return null;
            }

            List<SectionClassDTO> lRes = new List<SectionClassDTO>();
            for (int i = 0; i < sectionClassDto.ListResult.Count; i++)
                lRes.Add((SectionClassDTO)DTOMapper.GetInstance().Map<SectionClassDTO>(sectionClassDto.ListResult[i].ToObject<JObject>()));

            return lRes;
        }

        private void addCoursesToDataGV()
        {
            List<SectionClassDTO> sectionClassDtos = loadCourse();
            for (int i=0; i< sectionClassDtos.Count; i++)
            {
                dataCourse.Rows.Add(sectionClassDtos[i].Id, sectionClassDtos[i].Name, sectionClassDtos[i].Period, sectionClassDtos[i].Description);
            }
            
        }

        private void btnToFile_Click(object sender, EventArgs e)
        {
            downloadListOfCourse();
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\section_class\list_of_section_class.docx");
            ap.Visible = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            downloadListOfCourse();
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Document document = ap.Documents.Open(System.Windows.Forms.Application.StartupPath + @"\sources\section_class\list_of_section_class.docx");
            ap.Visible = true;
            document.PrintPreview();
        }

        private void downloadListOfCourse()
        {
            String url = "http://localhost:8081/api/file/section_class?option=print";

            JObject jObject = HttpUtils.GetRequest(url, Globals.TokenCode, null);
            SectionClassDTO sectionClassDto = DTOMapper.GetInstance().Map<SectionClassDTO>(jObject);

            if (sectionClassDto.HttpStatus == "OK")
            {
                url = "http://localhost:8081" + (String)sectionClassDto.ListResult[0] + "?option=getFile";

                var client = new WebClient();
                client.DownloadFile(url, @"sources\section_class\list_of_section_class.docx");

            }
        }
    }
}

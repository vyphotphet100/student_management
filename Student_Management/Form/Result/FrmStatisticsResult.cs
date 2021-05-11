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
    public partial class FrmStatisticsResult : Form
    {
        public FrmStatisticsResult()
        {
            InitializeComponent();

            // STATISTICS BY COURSE
            lViewStatisticsByCourse.Items.Clear();
            List<RegisterDTO> registerDtos = loadRegister();
            List<SectionClassDTO> sectionClassDtos = loadCourse();

            // compute average score
            for (int i = 0; i < sectionClassDtos.Count; i++)
            {
                String label = sectionClassDtos[i].Name;
                double totalScore = 0;
                int n = 0;
                for (int k = 0; k < registerDtos.Count; k++)
                {
                    if (registerDtos[k].SectionClassId == sectionClassDtos[i].Id)
                    {
                        n++;
                        totalScore += registerDtos[k].EndTermMark;
                    }
                }

                double avgScore = totalScore / n;
                lViewStatisticsByCourse.Items.Add(label + ": " + avgScore);
            }


            // STATISTICS BY RESULT
            int nPass = 0;
            int nFail = 0;
            lViewStatisticsByResult.Items.Clear();
            List<StudentDTO> studentDtos = loadStudent();

            for (int k = 0; k < studentDtos.Count; k++)
            {
                StudentDTO studentDto = studentDtos[k];
                List<RegisterDTO> registeredDtos = new List<RegisterDTO>();
                for (int i = 0; i < registerDtos.Count; i++)
                    if (registerDtos[i].StudentId == studentDto.Id)
                        registeredDtos.Add(registerDtos[i]);

                Double totalScore = 0;
                for (int i = 0; i < registeredDtos.Count; i++)
                    totalScore += registeredDtos[i].EndTermMark;
                Double avgScore = totalScore / registeredDtos.Count;

                if (avgScore >= 5)
                    nPass++;
                else
                    nFail++;
            }
            int pPass = (int)((double)nPass / studentDtos.Count * 100);
            int pFail = (int)((double)nFail / studentDtos.Count * 100);
            lViewStatisticsByResult.Items.Add("Pass : " + pPass);
            lViewStatisticsByResult.Items.Add("Fail : " + pFail);
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

        private List<RegisterDTO> loadRegister()
        {
            JObject jObj = HttpUtils.GetRequest("http://localhost:8081/api/register", Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObj);

            List<RegisterDTO> registerDtos = new List<RegisterDTO>();
            if (registerDto.ListResult != null)
            {
                for (int i = 0; i < registerDto.ListResult.Count; i++)
                    registerDtos.Add(DTOMapper.GetInstance().Map<RegisterDTO>(registerDto.ListResult[i].ToObject<JObject>()));
            }

            return registerDtos;
        }

        private List<StudentDTO> loadStudent()
        {
            List<StudentDTO> studentDtos = new List<StudentDTO>();

            JObject jObject = HttpUtils.GetRequest("http://localhost:8081/api/student", Globals.TokenCode, null);
            StudentDTO responseDto = DTOMapper.GetInstance().Map<StudentDTO>(jObject);

            for (int i = 0; i < responseDto.ListResult.Count; i++)
            {
                StudentDTO studentDto = DTOMapper.GetInstance().Map<StudentDTO>(responseDto.ListResult[i].ToObject<JObject>());
                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }
    }
}

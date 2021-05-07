using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DTO;

namespace StudentManagement.MapperUtils
{
    public class DTOMapper
    {
        public static DTOMapper GetInstance()
        {
            return new DTOMapper();
        }

        public T Map<T>(JObject json)
        {
            if (typeof(T) == typeof(EducationTrainingDTO))
            {
                EducationTrainingDTO dto = new EducationTrainingDTO();
                dto = (EducationTrainingDTO)SetAbtractDTO(json, dto);
                dto = SetEducationTrainingDTO(json, dto);
                return (T)((Object)dto);
            } 
            else if (typeof(T) == typeof(CourseDTO))
            {
                CourseDTO dto = new CourseDTO();
                dto = (CourseDTO)SetAbtractDTO(json, dto);
                dto = SetCourseDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(LecturerDTO))
            {
                LecturerDTO dto = new LecturerDTO();
                dto = (LecturerDTO)SetAbtractDTO(json, dto);
                dto = SetLecturerDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(MyFileDTO))
            {
                MyFileDTO dto = new MyFileDTO();
                dto = (MyFileDTO)SetAbtractDTO(json, dto);
                dto = SetMyFileDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(NotificationDTO))
            {
                NotificationDTO dto = new NotificationDTO();
                dto = (NotificationDTO)SetAbtractDTO(json, dto);
                dto = SetNotificationDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(RegisterDTO))
            {
                RegisterDTO dto = new RegisterDTO();
                dto = (RegisterDTO)SetAbtractDTO(json, dto);
                dto = SetRegisterDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(RoleDTO))
            {
                RoleDTO dto = new RoleDTO();
                dto = (RoleDTO)SetAbtractDTO(json, dto);
                dto = SetRoleDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(SectionClassDTO))
            {
                SectionClassDTO dto = new SectionClassDTO();
                dto = (SectionClassDTO)SetAbtractDTO(json, dto);
                dto = SetSectionClassDTO(json, dto);
                return (T)((Object)dto);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                StudentDTO dto = new StudentDTO();
                dto = (StudentDTO)SetAbtractDTO(json, dto);
                dto = SetStudentDTO(json, dto);
                return (T)((Object)dto);
            }

            return default(T);
        }
    


        private AbstractDTO SetAbtractDTO(JObject jObj, AbstractDTO dto)
        {
            try
            {
                long jsonDate = (long)jObj["createdDate"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.CreatedDate = date;
            }
            catch { }

            try
            {
                long jsonDate = (long)jObj["modifiedDate"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.CreatedDate = date;
            }
            catch { }

            try { dto.CreatedBy = (String)jObj["createdBy"]; } catch { }

            try { dto.ModifiedBy = (String)jObj["modifiedBy"]; } catch { }

            try { dto.ListResult = (JArray)jObj["listResult"]; } catch { }

            try { dto.ListRequest = (JArray)jObj["listRequest"]; } catch { }

            try { dto.Message = (String)jObj["message"]; } catch { }

            try { dto.HttpStatus = (String)jObj["httpStatus"]; } catch { }
            try {
                if (jObj["status"] != null)
                    dto.HttpStatus = (String)jObj["status"]; 
            } catch { }

            return dto;
        }
        
        private EducationTrainingDTO SetEducationTrainingDTO(JObject jObj, EducationTrainingDTO dto)
        {
            try { dto.Username = (String)jObj["username"]; } catch { }
            try { dto.Password = (String)jObj["password"]; } catch { }
            try { dto.Address = (String)jObj["address"]; } catch { }
            try { dto.RoleCode = (String)jObj["roleCode"]; } catch { }
            try { dto.TokenCode = (String)jObj["tokenCode"]; } catch { }

            return dto;
        } 

        private CourseDTO SetCourseDTO(JObject jObj, CourseDTO dto)
        {
            try { dto.Id = (String)jObj["id"]; } catch { }
            try { dto.Name = (String)jObj["name"]; } catch { }
            try { dto.Period = (int)jObj["period"]; } catch { }
            try { dto.Description = (String)jObj["description"]; } catch { }
            try { dto.NumberOfCredit = (int)jObj["numberOfCredit"]; } catch { }
            try { dto.Fee = (long)jObj["fee"]; } catch { }
            try { dto.SectionClassIds = (JArray)jObj["sectionClassIds"]; } catch { }

            return dto;
        }

        private LecturerDTO SetLecturerDTO(JObject jObj, LecturerDTO dto)
        {
            try { dto.Id = (long)jObj["id"]; } catch { }
            try { dto.Username = (String)jObj["username"]; } catch { }
            try { dto.Password = (String)jObj["password"]; } catch { }
            try { dto.Fullname = (String)jObj["fullname"]; } catch { }
            try
            {
                long jsonDate = (long)jObj["birthday"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.Birthday = date;
            }
            catch { }
            try { dto.PhoneNumber = (String)jObj["phoneNumber"]; } catch { }
            try { dto.Address = (String)jObj["address"]; } catch { }
            try { dto.SectionClassIds = (JArray)jObj["sectionClassIds"]; } catch { }
            try { dto.RoleCode = (String)jObj["roleCode"]; } catch { }
            try { dto.TokenCode = (String)jObj["tokenCode"]; } catch { }

            return dto;
        }

        private MyFileDTO SetMyFileDTO(JObject jObj, MyFileDTO dto)
        {
            try { dto.Base64String = (String)jObj["base64String"]; } catch { }
            try { dto.FileName = (String)jObj["fileName"]; } catch { }
            try { dto.FileType = (String)jObj["fileType"]; } catch { }

            return dto;
        }

        private NotificationDTO SetNotificationDTO(JObject jObj, NotificationDTO dto)
        {
            try { dto.Id = (long)jObj["id"]; } catch { }
            try { dto.Title = (String)jObj["title"]; } catch { }
            try { dto.ShortDescription = (String)jObj["shortDescription"]; } catch { }
            try { dto.Content = (String)jObj["content"]; } catch { }

            return dto;
        }

        private RegisterDTO SetRegisterDTO(JObject jObj, RegisterDTO dto)
        {
            try { dto.Id = (long)jObj["id"]; } catch { }
            try { dto.StudentId = (String)jObj["studentId"]; } catch { }
            try { dto.SectionClassId = (String)jObj["sectionClassId"]; } catch { }
            try { dto.MidTermMark = (double)jObj["midTermMark"]; } catch { }
            try { dto.EndTermMark = (double)jObj["endTermMark"]; } catch { }

            return dto;
        }

        private RoleDTO SetRoleDTO(JObject jObj, RoleDTO dto)
        {
            try { dto.Id = (long)jObj["id"]; } catch { }
            try { dto.Name = (String)jObj["name"]; } catch { }
            try { dto.Code = (String)jObj["code"]; } catch { }
            try { dto.StudentIds = (JArray)jObj["studentIds"]; } catch { }
            try { dto.LecturerIds = (JArray)jObj["lecturerIds"]; } catch { }
            try { dto.EducationTrainingUsernames = (JArray)jObj["educationTrainingUsernames"]; } catch { }

            return dto;
        }

        private SectionClassDTO SetSectionClassDTO(JObject jObj, SectionClassDTO dto)
        {
            try { dto.Id = (String)jObj["id"]; } catch { }
            try { dto.Name = (String)jObj["name"]; } catch { }
            try
            {
                long jsonDate = (long)jObj["startTime"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.StartTime = date;
            }
            catch { }
            try
            {
                long jsonDate = (long)jObj["endTime"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.EndTime = date;
            }
            catch { }
            try { dto.Room = (String)jObj["room"]; } catch { }
            try { dto.Period = (int)jObj["period"]; } catch { }
            try { dto.Description = (String)jObj["description"]; } catch { }
            try { dto.CourseId = (String)jObj["courseId"]; } catch { }
            try { dto.LecturerId = (long)jObj["lecturerId"]; } catch { }
            try { dto.RegisterIds = (JArray)jObj["registerIds"]; } catch { }

            return dto;
        }

        private StudentDTO SetStudentDTO(JObject jObj, StudentDTO dto)
        {
            try { dto.Id = (String)jObj["id"]; } catch { }
            try { dto.FirstName = (String)jObj["firstName"]; } catch { }
            try { dto.LastName = (String)jObj["lastName"]; } catch { }
            try { dto.Fullname = (String)jObj["fullname"]; } catch { }
            try { dto.Username = (String)jObj["username"]; } catch { }
            try { dto.Password = (String)jObj["password"]; } catch { }
            try
            {
                long jsonDate = (long)jObj["birthday"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.Birthday = date;
            }
            catch { }
            try { dto.StartYear = (int)jObj["startYear"]; } catch { }
            try { dto.Gender = (String)jObj["gender"]; } catch { }
            try { dto.PhoneNumber = (String)jObj["phoneNumber"]; } catch { }
            try { dto.Address = (String)jObj["address"]; } catch { }
            try { dto.Picture = (String)jObj["picture"]; } catch { }
            try { dto.RegisterIds = (JArray)jObj["registerIds"]; } catch { }
            try { dto.RoleCode = (String)jObj["roleCode"]; } catch { }
            try { dto.TokenCode = (String)jObj["tokenCode"]; } catch { }

            return dto;
        }

    }
}

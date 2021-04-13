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
            AbstractDTO<T> dto = new AbstractDTO<T>();

            try { dto.Id = (long)json["id"]; } catch { }

            try { 
                long jsonDate = (long)json["createdDate"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.CreatedDate = date;
            } catch { }

            try {
                long jsonDate = (long)json["modifiedDate"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                dto.CreatedDate = date;
            } catch { }

            try { dto.CreatedBy = (String)json["createdBy"]; } catch { }

            try { dto.ModifiedBy = (String)json["modifiedBy"]; } catch { }

            try
            {
                List<Object> lRes = new List<Object>();
                JArray list = (JArray)json["listResult"];
                for (int i = 0; i < list.Count; i++)
                {
                    T dtoTmp = DTOMapper.GetInstance().Map<T>(list[i].ToObject<JObject>());
                    lRes.Add(dtoTmp);
                }

                dto.ListResult = lRes;
            }            
            catch { }

            try { dto.Message = (String)json["message"]; } catch { }
            try { dto.HttpStatus = (String)json["httpStatus"]; } catch { }
            try { 
                if ((String)json["status"] != null)
                    dto.HttpStatus = (String)json["status"]; 
            } catch { }


            if (typeof(T) == typeof(UserDTO))
            {
                UserDTO userDto = dto.ToUserDTO();
                this.SetUserDTO(json, ref userDto);
                dto = (AbstractDTO<T>)((Object)userDto);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                StudentDTO studentDto = dto.ToStudentDTO();
                this.SetStudentDTO(json, ref studentDto);
                dto = (AbstractDTO<T>)((Object)studentDto);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                CourseDTO courseDto = dto.ToCourseDTO();
                this.SetCourseDTO(json, ref courseDto);
                dto = (AbstractDTO<T>)((Object)courseDto);
            }
            return (T)((Object)dto);
        }

        private void SetUserDTO(JObject json, ref UserDTO userDto)
        {
            try { userDto.UserName = (String)json["userName"]; } catch { }
            try { userDto.Password = (String)json["password"]; } catch { }
            try { userDto.FullName = (String)json["fullName"]; } catch { }
            try { userDto.TokenCode = (String)json["tokenCode"]; } catch { }

            try
            {
                List<String> lRes = new List<String>();
                JArray list = (JArray)json["roleCodes"];
                for (int i = 0; i < list.Count; i++)
                {
                    String roleCode = list[i].ToObject<String>();
                    lRes.Add(roleCode);
                }

                userDto.RoleCodes = lRes;
            }
            catch (Exception) { }
        }

        private void SetStudentDTO(JObject json, ref StudentDTO studentDto)
        {
            try { studentDto.StudentID = (String)json["studentId"]; } catch { }
            try { studentDto.FirstName = (String)json["firstName"]; } catch { }
            try { studentDto.LastName = (String)json["lastName"]; } catch { }
            try {
                long jsonDate = (long)json["birthday"];
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(jsonDate).ToLocalTime();
                studentDto.Birthday = date;
            } catch { }
            try { studentDto.Gender = (String)json["gender"]; } catch { }
            try { studentDto.Phone = (String)json["phone"]; } catch { }
            try { studentDto.Address = (String)json["address"]; } catch { }
            try { studentDto.Picture = (String)json["picture"]; } catch { }
        }

        private void SetCourseDTO(JObject json, ref CourseDTO courseDto)
        {
            try { courseDto.Label = (String)json["label"]; } catch { }
            try { courseDto.Period = (int)json["period"]; } catch { }
            try { courseDto.Description = (String)json["description"]; } catch { }

            try
            {
                List<long> lRes = new List<long>();
                JArray list = (JArray)json["scoreIds"];
                for (int i = 0; i < list.Count; i++)
                {
                    long scoreId = list[i].ToObject<long>();
                    lRes.Add(scoreId);
                }

                courseDto.ScoreIds = lRes;
            }
            catch (Exception) { }
        }
    }
}

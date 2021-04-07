using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class AbstractDTO<T>
    {
        private long id;
        private DateTime createdDate;
        private DateTime modifiedDate;
        private String createdBy;
        private String modifiedBy;
        private List<Object> listResult = new List<Object>();
        private String message;
        private String httpStatus;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public DateTime CreatedDate
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }

        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }

        public String CreatedBy
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }

        public String ModifiedBy
        {
            get { return this.modifiedBy; }
            set { this.modifiedBy = value; }
        }

        public List<Object> ListResult
        {
            get { return this.listResult; }
            set { this.listResult = value; }
        }

        public String Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public String HttpStatus {
            get { return this.httpStatus; }
            set { this.httpStatus = value; }
        }


        public UserDTO ToUserDTO()
        {
            UserDTO userDto = new UserDTO();
            userDto.Id = this.id;
            userDto.CreatedDate = this.createdDate;
            userDto.CreatedBy = this.createdBy;
            userDto.ModifiedBy = this.modifiedBy;
            userDto.ModifiedDate = this.modifiedDate;
            userDto.ListResult = this.listResult;
            userDto.Message = this.message;
            userDto.HttpStatus = this.httpStatus;
            return userDto;
        }

        public StudentDTO ToStudentDTO()
        {
            StudentDTO studentDto = new StudentDTO();
            studentDto.Id = this.id;
            studentDto.CreatedDate = this.createdDate;
            studentDto.CreatedBy = this.createdBy;
            studentDto.ModifiedBy = this.modifiedBy;
            studentDto.ModifiedDate = this.modifiedDate;
            studentDto.ListResult = this.listResult;
            studentDto.Message = this.message;
            studentDto.HttpStatus = this.httpStatus;
            return studentDto;
        }
    }
}

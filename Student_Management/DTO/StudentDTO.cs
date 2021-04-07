using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class StudentDTO : AbstractDTO<StudentDTO>
    {
        private String studentId;
        private String firstName;
        private String lastName;
        private DateTime birthday;
        private String gender;
        private String phone;
        private String address;
        private String picture;

        public String StudentID
        {
            get { return this.studentId; }
            set { this.studentId = value; }
        }

        public String FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public String LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }
        public String Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public String Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public String Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }
    }
}

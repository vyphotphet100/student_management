using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class LecturerDTO : AbstractDTO
    {
        private long id;
        private String username;
        private String password;
        private String fullname;
        private DateTime birthday;
        private String phoneNumber;
        private String address;
        private JArray sectionClassIds;
        private String roleCode;
        private String tokenCode;

        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public String RoleCode
        {
            get { return this.roleCode; }
            set { this.roleCode = value; }
        }

        public String TokenCode
        {
            get { return this.tokenCode; }
            set { this.tokenCode = value; }
        }

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Fullname
        {
            get { return this.fullname; }
            set { this.fullname = value; }
        }

        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public String PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public JArray SectionClassIds
        {
            get { return this.sectionClassIds; }
            set { this.sectionClassIds = value; }
        }
    }
}

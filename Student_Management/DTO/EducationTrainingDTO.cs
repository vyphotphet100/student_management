using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class EducationTrainingDTO : AbstractDTO
    {
        private String username;
        private String password;
        private String address;
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
    }
}

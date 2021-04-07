using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class UserDTO : AbstractDTO<UserDTO>
    {
        private String userName;
        private String password;
        private String fullName;
        private String tokenCode;
        private List<String> roleCodes = new List<String>();

        public String UserName {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public String FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public String TokenCode
        {
            get { return this.tokenCode; }
            set { this.tokenCode = value; }
        }

        public List<String> RoleCodes { 
            get { return this.roleCodes; }
            set { this.roleCodes = value;  }
        }

    }
}

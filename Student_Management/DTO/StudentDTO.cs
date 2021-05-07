using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class StudentDTO : AbstractDTO
    {
        private String id;
        private String firstName;
        private String lastName;
        private String fullname;
        private String username;
        private String password;
        private DateTime birthday;
        private int startYear;
        private String gender;
        private String phoneNumber;
        private String address;
        private String picture;
        private JArray registerIds;
        private String roleCode;
        private String tokenCode;

        public String Id
        {
            get { return this.id; }
            set { this.id = value; }
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
        public String Fullname
        {
            get { return this.fullname; }
            set { this.fullname = value; }
        }
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
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }
        public int StartYear
        {
            get { return this.startYear; }
            set { this.startYear = value; }
        }
        public String Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public String PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
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
        public JArray RegisterIds
        {
            get { return this.registerIds; }
            set { this.registerIds = value; }
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

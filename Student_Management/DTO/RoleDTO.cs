using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class RoleDTO : AbstractDTO
    {
        private long id;
        private String name;
        private String code;
        private JArray studentIds;
        private JArray lecturerIds;
        private JArray educationTrainingUsernames;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public JArray StudentIds
        {
            get { return this.studentIds; }
            set { this.studentIds = value; }
        }

        public JArray LecturerIds
        {
            get { return this.lecturerIds; }
            set { this.lecturerIds = value; }
        }

        public JArray EducationTrainingUsernames
        {
            get { return this.educationTrainingUsernames; }
            set { this.educationTrainingUsernames = value; }
        }
    }
}

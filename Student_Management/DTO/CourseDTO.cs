using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class CourseDTO: AbstractDTO
    {
        private String id;
        private String name;
        private int numberOfCredit;
        private long fee;
        private JArray sectionClassIds;

        public String Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int NumberOfCredit
        {
            get { return this.numberOfCredit; }
            set { this.numberOfCredit = value; }
        }

        public long Fee
        {
            get { return this.fee; }
            set { this.fee = value; }
        }

        public JArray SectionClassIds
        {
            get { return this.sectionClassIds; }
            set { this.sectionClassIds = value; }
        }
    }
}

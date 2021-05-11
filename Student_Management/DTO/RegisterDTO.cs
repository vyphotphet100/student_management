using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class RegisterDTO : AbstractDTO
    {
        private long id;
        private String studentId;
        private String sectionClassId;
        private double midTermMark;
        private double endTermMark;
        private String description;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String StudentId
        {
            get { return this.studentId; }
            set { this.studentId = value; }
        }

        public String SectionClassId
        {
            get { return this.sectionClassId; }
            set { this.sectionClassId = value; }
        }

        public double MidTermMark
        {
            get { return this.midTermMark; }
            set { this.midTermMark = value; }
        }

        public double EndTermMark
        {
            get { return this.endTermMark; }
            set { this.endTermMark = value; }
        }

        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}

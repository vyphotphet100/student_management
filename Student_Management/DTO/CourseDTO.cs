using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class CourseDTO: AbstractDTO<CourseDTO>
    {
        private String courseId;
        private String label;
        private int period;
        private String description;
        private List<long> scoreIds = new List<long>();

        public String CourseId
        {
            get { return this.courseId; }
            set { this.courseId = value; }
        }

        public String Label
        {
            get { return this.label; }
            set { this.label = value; }
        }

        public int Period
        {
            get { return this.period; }
            set { this.period = value; }
        }

        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public List<long> ScoreIds
        {
            get { return this.scoreIds; }
            set { this.scoreIds = value; }
        }
    }
}

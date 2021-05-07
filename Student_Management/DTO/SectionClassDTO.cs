using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class SectionClassDTO : AbstractDTO
    {
        private String id;
        private String name;
        private DateTime startTime;
        private DateTime endTime;
        private String room;
        private int period;
        private String description;
        private String courseId;
        private long lecturerId;
        private JArray registerIds;

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

        public DateTime StartTime
        {
            get { return this.startTime; }
            set { this.startTime = value; }
        }

        public DateTime EndTime
        {
            get { return this.endTime; }
            set { this.endTime = value; }
        }

        public String Room
        {
            get { return this.room; }
            set { this.room = value; }
        }

        public String CourseId
        {
            get { return this.courseId; }
            set { this.courseId = value; }
        }

        public long LecturerId
        {
            get { return this.lecturerId; }
            set { this.lecturerId = value; }
        }

        public JArray RegisterIds
        {
            get { return this.registerIds; }
            set { this.registerIds = value; }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class NotificationDTO : AbstractDTO
    {
        private long id;
        private String title;
        private String shortDescription;
        private String content;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public String ShortDescription
        {
            get { return this.shortDescription; }
            set { this.shortDescription = value; }
        }

        public String Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}

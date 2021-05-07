using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class MyFileDTO : AbstractDTO
    {
        private String fileName;
        private String fileType;
        private String base64String;

        public String FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        public String FileType
        {
            get { return this.fileType; }
            set { this.fileType = value; }
        }

        public String Base64String
        {
            get { return this.base64String; }
            set { this.base64String = value; }
        }

    }
}

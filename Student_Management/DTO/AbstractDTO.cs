using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO
{
    public class AbstractDTO
    {
        private DateTime createdDate;
        private DateTime modifiedDate;
        private String createdBy;
        private String modifiedBy;

        private JArray listResult;
        private JArray listRequest;
        private String message;
        private String httpStatus;


        public DateTime CreatedDate
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }

        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }

        public String CreatedBy
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }

        public String ModifiedBy
        {
            get { return this.modifiedBy; }
            set { this.modifiedBy = value; }
        }

        public JArray ListResult
        {
            get { return this.listResult; }
            set { this.listResult = value; }
        }

        public JArray ListRequest
        {
            get { return this.listRequest; }
            set { this.listRequest = value; }
        }

        public String Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public String HttpStatus {
            get { return this.httpStatus; }
            set { this.httpStatus = value; }
        }
        
    }
}

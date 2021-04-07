using StudentManagement.DTO;
using StudentManagement.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.File
{
    public class StudentFile
    {
        public static JObject upAvatar(String serverUrl, String token, PictureBox picAvatar, String studentId)
        {
            var data = new Dictionary<String, Object>
            {
                { "fileName", "/avatar" },
                { "fileType", "png" },
                { "base64String", PictureUtils.GetInstance().ToBase64String(picAvatar) }
            };

            return HttpUtils.PostRequest(serverUrl+"/api/file/student/" + studentId, token, data);
        }
    }
}

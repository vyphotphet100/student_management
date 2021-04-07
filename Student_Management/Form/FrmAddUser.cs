using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!verify())
                return;

            String url = "http://localhost:8081/api/user";

            // List role
            List<String> lRole = new List<String>();
            lRole.Add("ADMIN");
            var data = new Dictionary<String, Object>
            {
                { "userName", txbUsername.Text },
                { "password", txbPassword.Text },
                { "fullName", txbFullname.Text },
                { "roleCodes", lRole }
            };
            JObject jObject = HttpUtils.PostRequest(url, Globals.TokenCode, data);
            UserDTO userDto = DTOMapper.GetInstance().Map<UserDTO>(jObject);

            if (userDto != null)
                lbStatus.Text = userDto.Message;
            else
                lbStatus.Text = "Something wrong.";
        }

        private bool verify()
        {
            if (txbUsername.Text.Trim() == "" ||
                txbPassword.Text.Trim() == "")
            {
                lbStatus.Text = "Something is wrong. Please recheck.";
                return false;
            }

            return true;
        }
    }
}

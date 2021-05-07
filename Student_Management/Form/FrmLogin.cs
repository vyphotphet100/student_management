using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
using System.Diagnostics;
using System.Threading;

namespace StudentManagement
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!verify())
                return;

            tmr.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmAddUser frmAddUser = new FrmAddUser();
            DialogResult dr = frmAddUser.ShowDialog(this);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            pBar.Value++;
            if (pBar.Value == 100) {
                pBar.Value = 0;
                tmr.Stop();

                string url = @"http://localhost:8081/login";
                var data = new Dictionary<String, Object>
                {
                    { "username", txbUsername.Text },
                    { "password", txbPassword.Text }
                };
                EducationTrainingDTO educationTrainingDto = DTOMapper.GetInstance().Map<EducationTrainingDTO>(HttpUtils.PostRequest(url, null, data));
                lbStatus.Text = educationTrainingDto.Message;
                if (educationTrainingDto.HttpStatus == "OK")
                {
                    Globals.TokenCode = educationTrainingDto.TokenCode;
                    this.Hide();
                    FrmMain frmMain = new FrmMain();
                    DialogResult dr = frmMain.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        frmMain.Close();
                        pBar.Value = 0;
                        this.Show();
                    }
                }
            }
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

using Newtonsoft.Json.Linq;
using StudentManagement.DTO;
using StudentManagement.MapperUtils;
using StudentManagement.Utils;
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
    public partial class FrmRemoveScore : Form
    {
        public FrmRemoveScore()
        {
            InitializeComponent();
            loadRegister();
        }

        private void loadRegister()
        {
            dataRegister.Rows.Clear();
            JObject jObj = HttpUtils.GetRequest("http://localhost:8081/api/register", Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObj);

            List<RegisterDTO> registerDtos = new List<RegisterDTO>();
            if (registerDto.ListResult != null)
            {
                for (int i = 0; i < registerDto.ListResult.Count; i++)
                    registerDtos.Add(DTOMapper.GetInstance().Map<RegisterDTO>(registerDto.ListResult[i].ToObject<JObject>()));
            }

            for (int i = 0; i < registerDtos.Count; i++)
            {
                dataRegister.Rows.Add(registerDtos[i].Id, registerDtos[i].StudentId,
                    registerDtos[i].SectionClassId, registerDtos[i].EndTermMark, registerDtos[i].Description);
            }

        }

        private void dataRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataRegister.Rows[dataRegister.CurrentCell.RowIndex].Selected = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            JObject jObj = HttpUtils.DeleteRequest("http://localhost:8081/api/register/" + dataRegister.Rows[dataRegister.CurrentCell.RowIndex].Cells[0].Value, Globals.TokenCode, null);
            RegisterDTO registerDto = DTOMapper.GetInstance().Map<RegisterDTO>(jObj);

            if (registerDto != null)
                lbStatus.Text = registerDto.Message;
            
            loadRegister();
        }
    }
}

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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void stuItemAddNewStudent_Click(object sender, EventArgs e)
        {
            FrmAddStudent frmAddStudent = new FrmAddStudent();
            frmAddStudent.ShowDialog(this);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.TokenCode = null;
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentList frmStudentList = new FrmStudentList();
            frmStudentList.ShowDialog(this);
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStatistics frmStatistics = new FrmStatistics();
            frmStatistics.ShowDialog(this);
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddCourse frmAddCourse = new FrmAddCourse();
            frmAddCourse.ShowDialog(this);
        }
    }
}

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

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRemoveCourse frmRemoveCourse = new FrmRemoveCourse();
            frmRemoveCourse.ShowDialog(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditCourse frmEditCourse = new FrmEditCourse();
            frmEditCourse.ShowDialog(this);
        }

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageCourse frmManageCourse = new FrmManageCourse();
            frmManageCourse.ShowDialog(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateDeleteStudent frmUpdateDeleteStudent = new FrmUpdateDeleteStudent("0");
            frmUpdateDeleteStudent.ShowDialog(this);
        }
    }
}

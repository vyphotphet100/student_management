namespace StudentManagement
{
    partial class FrmManageScore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbStudentID = new System.Windows.Forms.TextBox();
            this.cbxCourse = new System.Windows.Forms.ComboBox();
            this.txbScore = new System.Windows.Forms.TextBox();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.dataGRV = new System.Windows.Forms.DataGridView();
            this.btnShowStudent = new System.Windows.Forms.Button();
            this.btnShowScore = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Score:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description:";
            // 
            // txbStudentID
            // 
            this.txbStudentID.Location = new System.Drawing.Point(111, 19);
            this.txbStudentID.Name = "txbStudentID";
            this.txbStudentID.ReadOnly = true;
            this.txbStudentID.Size = new System.Drawing.Size(112, 20);
            this.txbStudentID.TabIndex = 1;
            // 
            // cbxCourse
            // 
            this.cbxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCourse.FormattingEnabled = true;
            this.cbxCourse.Location = new System.Drawing.Point(111, 50);
            this.cbxCourse.Name = "cbxCourse";
            this.cbxCourse.Size = new System.Drawing.Size(181, 21);
            this.cbxCourse.TabIndex = 2;
            // 
            // txbScore
            // 
            this.txbScore.Location = new System.Drawing.Point(111, 84);
            this.txbScore.Name = "txbScore";
            this.txbScore.Size = new System.Drawing.Size(112, 20);
            this.txbScore.TabIndex = 1;
            // 
            // txbDescription
            // 
            this.txbDescription.Location = new System.Drawing.Point(111, 120);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(181, 78);
            this.txbDescription.TabIndex = 1;
            // 
            // dataGRV
            // 
            this.dataGRV.AllowUserToAddRows = false;
            this.dataGRV.AllowUserToDeleteRows = false;
            this.dataGRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRV.Location = new System.Drawing.Point(308, 43);
            this.dataGRV.Name = "dataGRV";
            this.dataGRV.ReadOnly = true;
            this.dataGRV.Size = new System.Drawing.Size(491, 285);
            this.dataGRV.TabIndex = 3;
            this.dataGRV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGRV_CellClick);
            // 
            // btnShowStudent
            // 
            this.btnShowStudent.Location = new System.Drawing.Point(371, 17);
            this.btnShowStudent.Name = "btnShowStudent";
            this.btnShowStudent.Size = new System.Drawing.Size(171, 23);
            this.btnShowStudent.TabIndex = 4;
            this.btnShowStudent.Text = "Show students";
            this.btnShowStudent.UseVisualStyleBackColor = true;
            this.btnShowStudent.Click += new System.EventHandler(this.btnShowStudent_Click);
            // 
            // btnShowScore
            // 
            this.btnShowScore.Location = new System.Drawing.Point(593, 17);
            this.btnShowScore.Name = "btnShowScore";
            this.btnShowScore.Size = new System.Drawing.Size(171, 23);
            this.btnShowScore.TabIndex = 4;
            this.btnShowScore.Text = "Show scores";
            this.btnShowScore.UseVisualStyleBackColor = true;
            this.btnShowScore.Click += new System.EventHandler(this.btnShowScore_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(111, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 24);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(205, 218);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(87, 24);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Location = new System.Drawing.Point(111, 248);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(181, 24);
            this.btnAverage.TabIndex = 4;
            this.btnAverage.Text = "Average score by course";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(811, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(16, 17);
            this.lbStatus.Text = "...";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(111, 278);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 366);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnShowScore);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShowStudent);
            this.Controls.Add(this.dataGRV);
            this.Controls.Add(this.cbxCourse);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.txbScore);
            this.Controls.Add(this.txbStudentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmManageScore";
            this.Text = "FrmManageScore";
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbStudentID;
        private System.Windows.Forms.ComboBox cbxCourse;
        private System.Windows.Forms.TextBox txbScore;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.DataGridView dataGRV;
        private System.Windows.Forms.Button btnShowStudent;
        private System.Windows.Forms.Button btnShowScore;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.Button btnPrint;
    }
}
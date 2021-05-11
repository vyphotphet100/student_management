namespace StudentManagement
{
    partial class FrmAverageResultByScore
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rBtnLastName = new System.Windows.Forms.RadioButton();
            this.rBtnID = new System.Windows.Forms.RadioButton();
            this.txbStudentID = new System.Windows.Forms.TextBox();
            this.txbFirstName = new System.Windows.Forms.TextBox();
            this.txbLastName = new System.Windows.Forms.TextBox();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.dataStudentResult = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStudentResult)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "First name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(419, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "STUDENT RESULT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Last name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Search by:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 223);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rBtnLastName);
            this.panel1.Controls.Add(this.rBtnID);
            this.panel1.Location = new System.Drawing.Point(96, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 51);
            this.panel1.TabIndex = 2;
            // 
            // rBtnLastName
            // 
            this.rBtnLastName.AutoSize = true;
            this.rBtnLastName.Location = new System.Drawing.Point(14, 26);
            this.rBtnLastName.Name = "rBtnLastName";
            this.rBtnLastName.Size = new System.Drawing.Size(74, 17);
            this.rBtnLastName.TabIndex = 3;
            this.rBtnLastName.Text = "Last name";
            this.rBtnLastName.UseVisualStyleBackColor = true;
            // 
            // rBtnID
            // 
            this.rBtnID.AutoSize = true;
            this.rBtnID.Checked = true;
            this.rBtnID.Location = new System.Drawing.Point(14, 3);
            this.rBtnID.Name = "rBtnID";
            this.rBtnID.Size = new System.Drawing.Size(36, 17);
            this.rBtnID.TabIndex = 3;
            this.rBtnID.TabStop = true;
            this.rBtnID.Text = "ID";
            this.rBtnID.UseVisualStyleBackColor = true;
            // 
            // txbStudentID
            // 
            this.txbStudentID.Location = new System.Drawing.Point(96, 57);
            this.txbStudentID.Name = "txbStudentID";
            this.txbStudentID.ReadOnly = true;
            this.txbStudentID.Size = new System.Drawing.Size(111, 20);
            this.txbStudentID.TabIndex = 3;
            // 
            // txbFirstName
            // 
            this.txbFirstName.Location = new System.Drawing.Point(96, 88);
            this.txbFirstName.Name = "txbFirstName";
            this.txbFirstName.ReadOnly = true;
            this.txbFirstName.Size = new System.Drawing.Size(111, 20);
            this.txbFirstName.TabIndex = 3;
            // 
            // txbLastName
            // 
            this.txbLastName.Location = new System.Drawing.Point(96, 119);
            this.txbLastName.Name = "txbLastName";
            this.txbLastName.ReadOnly = true;
            this.txbLastName.Size = new System.Drawing.Size(111, 20);
            this.txbLastName.TabIndex = 3;
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(96, 225);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(111, 20);
            this.txbSearch.TabIndex = 3;
            // 
            // dataStudentResult
            // 
            this.dataStudentResult.AllowUserToAddRows = false;
            this.dataStudentResult.AllowUserToDeleteRows = false;
            this.dataStudentResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStudentResult.Location = new System.Drawing.Point(224, 57);
            this.dataStudentResult.Name = "dataStudentResult";
            this.dataStudentResult.ReadOnly = true;
            this.dataStudentResult.Size = new System.Drawing.Size(792, 189);
            this.dataStudentResult.TabIndex = 4;
            this.dataStudentResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataStudentResult_CellClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(546, 252);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(649, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 283);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
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
            // FrmAverageResultByScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 305);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataStudentResult);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.txbLastName);
            this.Controls.Add(this.txbFirstName);
            this.Controls.Add(this.txbStudentID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmAverageResultByScore";
            this.Text = "FrmAverageResultByScore";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStudentResult)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rBtnLastName;
        private System.Windows.Forms.RadioButton rBtnID;
        private System.Windows.Forms.TextBox txbStudentID;
        private System.Windows.Forms.TextBox txbFirstName;
        private System.Windows.Forms.TextBox txbLastName;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.DataGridView dataStudentResult;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
    }
}
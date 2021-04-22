namespace StudentManagement
{
    partial class FrmPrintCourse
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
            this.dataCourse = new System.Windows.Forms.DataGridView();
            this.btnToFile = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.colCourseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesciption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataCourse)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataCourse
            // 
            this.dataCourse.AllowUserToAddRows = false;
            this.dataCourse.AllowUserToDeleteRows = false;
            this.dataCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCourseId,
            this.colLabel,
            this.colPeriod,
            this.colDesciption});
            this.dataCourse.Location = new System.Drawing.Point(12, 12);
            this.dataCourse.Name = "dataCourse";
            this.dataCourse.ReadOnly = true;
            this.dataCourse.Size = new System.Drawing.Size(611, 371);
            this.dataCourse.TabIndex = 0;
            // 
            // btnToFile
            // 
            this.btnToFile.Location = new System.Drawing.Point(12, 389);
            this.btnToFile.Name = "btnToFile";
            this.btnToFile.Size = new System.Drawing.Size(75, 23);
            this.btnToFile.TabIndex = 1;
            this.btnToFile.Text = "To file";
            this.btnToFile.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(93, 389);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // colCourseId
            // 
            this.colCourseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCourseId.HeaderText = "Course ID";
            this.colCourseId.Name = "colCourseId";
            this.colCourseId.ReadOnly = true;
            // 
            // colLabel
            // 
            this.colLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLabel.HeaderText = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.ReadOnly = true;
            // 
            // colPeriod
            // 
            this.colPeriod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPeriod.HeaderText = "Period";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.ReadOnly = true;
            // 
            // colDesciption
            // 
            this.colDesciption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesciption.HeaderText = "Desciption";
            this.colDesciption.Name = "colDesciption";
            this.colDesciption.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.TabIndex = 2;
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
            // FrmPrintCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 443);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnToFile);
            this.Controls.Add(this.dataCourse);
            this.Name = "FrmPrintCourse";
            this.Text = "FrmPrintCourse";
            ((System.ComponentModel.ISupportInitialize)(this.dataCourse)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesciption;
        private System.Windows.Forms.Button btnToFile;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
    }
}
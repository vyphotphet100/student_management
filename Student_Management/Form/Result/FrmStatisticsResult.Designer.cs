namespace StudentManagement
{
    partial class FrmStatisticsResult
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("aaa");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("bbb");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("aaa");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("bbb");
            this.label1 = new System.Windows.Forms.Label();
            this.lViewStatisticsByCourse = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lViewStatisticsByResult = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "STATISTICS BY COURSE";
            // 
            // lViewStatisticsByCourse
            // 
            this.lViewStatisticsByCourse.BackColor = System.Drawing.SystemColors.Menu;
            this.lViewStatisticsByCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lViewStatisticsByCourse.Enabled = false;
            this.lViewStatisticsByCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lViewStatisticsByCourse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lViewStatisticsByCourse.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lViewStatisticsByCourse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lViewStatisticsByCourse.Location = new System.Drawing.Point(6, 38);
            this.lViewStatisticsByCourse.MultiSelect = false;
            this.lViewStatisticsByCourse.Name = "lViewStatisticsByCourse";
            this.lViewStatisticsByCourse.Size = new System.Drawing.Size(275, 219);
            this.lViewStatisticsByCourse.TabIndex = 1;
            this.lViewStatisticsByCourse.UseCompatibleStateImageBehavior = false;
            this.lViewStatisticsByCourse.View = System.Windows.Forms.View.Tile;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mistral", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "STATISTICS BY RESULT";
            // 
            // lViewStatisticsByResult
            // 
            this.lViewStatisticsByResult.BackColor = System.Drawing.SystemColors.Menu;
            this.lViewStatisticsByResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lViewStatisticsByResult.Enabled = false;
            this.lViewStatisticsByResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lViewStatisticsByResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lViewStatisticsByResult.HideSelection = false;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.lViewStatisticsByResult.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.lViewStatisticsByResult.Location = new System.Drawing.Point(6, 38);
            this.lViewStatisticsByResult.MultiSelect = false;
            this.lViewStatisticsByResult.Name = "lViewStatisticsByResult";
            this.lViewStatisticsByResult.Size = new System.Drawing.Size(283, 219);
            this.lViewStatisticsByResult.TabIndex = 1;
            this.lViewStatisticsByResult.UseCompatibleStateImageBehavior = false;
            this.lViewStatisticsByResult.View = System.Windows.Forms.View.Tile;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(633, 22);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lViewStatisticsByCourse);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 262);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lViewStatisticsByResult);
            this.panel2.Location = new System.Drawing.Point(304, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 262);
            this.panel2.TabIndex = 4;
            // 
            // FrmStatisticsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 312);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmStatisticsResult";
            this.Text = "FrmStatisticsResult";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lViewStatisticsByCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lViewStatisticsByResult;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
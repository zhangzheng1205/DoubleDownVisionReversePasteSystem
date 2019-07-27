namespace GeneralLabelerStation.UI
{
    partial class fmSelectPasteRegion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bOk = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.cbPasteRegionList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPasteRegionList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "贴附区域";
            // 
            // bOk
            // 
            this.bOk.BackColor = System.Drawing.Color.Red;
            this.bOk.Location = new System.Drawing.Point(213, 8);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(77, 34);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "确定";
            this.bOk.UseVisualStyleBackColor = false;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Yellow;
            this.bClose.Location = new System.Drawing.Point(213, 259);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(77, 34);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "关闭";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // cbPasteRegionList
            // 
            this.cbPasteRegionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPasteRegionList.FormattingEnabled = true;
            this.cbPasteRegionList.Location = new System.Drawing.Point(3, 22);
            this.cbPasteRegionList.Name = "cbPasteRegionList";
            this.cbPasteRegionList.Size = new System.Drawing.Size(201, 269);
            this.cbPasteRegionList.TabIndex = 0;
            // 
            // fmSelectPasteRegion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 294);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmSelectPasteRegion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmSelectPasteRegion";
            this.Load += new System.EventHandler(this.fmSelectPasteRegion_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.CheckedListBox cbPasteRegionList;
    }
}
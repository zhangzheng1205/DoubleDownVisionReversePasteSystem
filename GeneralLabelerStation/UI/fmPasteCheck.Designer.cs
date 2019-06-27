namespace GeneralLabelerStation.UI
{
    partial class fmPasteCheck
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bEnableOffset = new System.Windows.Forms.CheckBox();
            this.lMoveTo = new System.Windows.Forms.Button();
            this.bMoveMark = new System.Windows.Forms.Button();
            this.bRecord = new System.Windows.Forms.Button();
            this.bOffset = new System.Windows.Forms.Button();
            this.gOffset = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lMark2X = new System.Windows.Forms.Label();
            this.lMark2Y = new System.Windows.Forms.Label();
            this.bGoMark2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lMark1X = new System.Windows.Forms.Label();
            this.lMark1Y = new System.Windows.Forms.Label();
            this.bGoMark1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.gOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bEnableOffset);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 91);
            this.panel1.TabIndex = 1;
            // 
            // bEnableOffset
            // 
            this.bEnableOffset.AutoSize = true;
            this.bEnableOffset.Location = new System.Drawing.Point(356, 3);
            this.bEnableOffset.Name = "bEnableOffset";
            this.bEnableOffset.Size = new System.Drawing.Size(96, 16);
            this.bEnableOffset.TabIndex = 4;
            this.bEnableOffset.Text = "启用调试模式";
            this.bEnableOffset.UseVisualStyleBackColor = true;
            this.bEnableOffset.CheckedChanged += new System.EventHandler(this.bEnableOffset_CheckedChanged);
            // 
            // lMoveTo
            // 
            this.lMoveTo.Location = new System.Drawing.Point(498, 91);
            this.lMoveTo.Name = "lMoveTo";
            this.lMoveTo.Size = new System.Drawing.Size(86, 31);
            this.lMoveTo.TabIndex = 3;
            this.lMoveTo.Text = "移动到贴附点";
            this.lMoveTo.UseVisualStyleBackColor = true;
            this.lMoveTo.Click += new System.EventHandler(this.lMoveTo_Click);
            // 
            // bMoveMark
            // 
            this.bMoveMark.Location = new System.Drawing.Point(498, 128);
            this.bMoveMark.Name = "bMoveMark";
            this.bMoveMark.Size = new System.Drawing.Size(86, 31);
            this.bMoveMark.TabIndex = 4;
            this.bMoveMark.Text = "移动到mark点";
            this.bMoveMark.UseVisualStyleBackColor = true;
            this.bMoveMark.Click += new System.EventHandler(this.bMoveMark_Click);
            // 
            // bRecord
            // 
            this.bRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.bRecord.Location = new System.Drawing.Point(3, 17);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(106, 35);
            this.bRecord.TabIndex = 0;
            this.bRecord.Text = "实际位置";
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // bOffset
            // 
            this.bOffset.Dock = System.Windows.Forms.DockStyle.Top;
            this.bOffset.Location = new System.Drawing.Point(3, 52);
            this.bOffset.Name = "bOffset";
            this.bOffset.Size = new System.Drawing.Size(106, 23);
            this.bOffset.TabIndex = 1;
            this.bOffset.Text = "补偿";
            this.bOffset.UseVisualStyleBackColor = true;
            this.bOffset.Click += new System.EventHandler(this.bOffset_Click);
            // 
            // gOffset
            // 
            this.gOffset.Controls.Add(this.bOffset);
            this.gOffset.Controls.Add(this.bRecord);
            this.gOffset.Location = new System.Drawing.Point(498, 183);
            this.gOffset.Name = "gOffset";
            this.gOffset.Size = new System.Drawing.Size(112, 146);
            this.gOffset.TabIndex = 5;
            this.gOffset.TabStop = false;
            this.gOffset.Text = "修改偏移";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(492, 381);
            this.dataGridView1.TabIndex = 2;
            // 
            // lMark2X
            // 
            this.lMark2X.AutoSize = true;
            this.lMark2X.Location = new System.Drawing.Point(17, 23);
            this.lMark2X.Name = "lMark2X";
            this.lMark2X.Size = new System.Drawing.Size(23, 12);
            this.lMark2X.TabIndex = 0;
            this.lMark2X.Text = "X:0";
            // 
            // lMark2Y
            // 
            this.lMark2Y.AutoSize = true;
            this.lMark2Y.Location = new System.Drawing.Point(17, 51);
            this.lMark2Y.Name = "lMark2Y";
            this.lMark2Y.Size = new System.Drawing.Size(23, 12);
            this.lMark2Y.TabIndex = 1;
            this.lMark2Y.Text = "Y:0";
            // 
            // bGoMark2
            // 
            this.bGoMark2.Location = new System.Drawing.Point(83, 23);
            this.bGoMark2.Name = "bGoMark2";
            this.bGoMark2.Size = new System.Drawing.Size(69, 40);
            this.bGoMark2.TabIndex = 2;
            this.bGoMark2.Text = "移动到";
            this.bGoMark2.UseVisualStyleBackColor = true;
            this.bGoMark2.Click += new System.EventHandler(this.bGoMark2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bGoMark2);
            this.groupBox2.Controls.Add(this.lMark2Y);
            this.groupBox2.Controls.Add(this.lMark2X);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(175, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mark2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "贴服点";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 68;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "吸嘴";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 55;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "MarkX";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "MarkY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "X_偏移量";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 78;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Y_偏移量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 78;
            // 
            // lMark1X
            // 
            this.lMark1X.AutoSize = true;
            this.lMark1X.Location = new System.Drawing.Point(17, 23);
            this.lMark1X.Name = "lMark1X";
            this.lMark1X.Size = new System.Drawing.Size(23, 12);
            this.lMark1X.TabIndex = 0;
            this.lMark1X.Text = "X:0";
            // 
            // lMark1Y
            // 
            this.lMark1Y.AutoSize = true;
            this.lMark1Y.Location = new System.Drawing.Point(17, 51);
            this.lMark1Y.Name = "lMark1Y";
            this.lMark1Y.Size = new System.Drawing.Size(23, 12);
            this.lMark1Y.TabIndex = 1;
            this.lMark1Y.Text = "Y:0";
            // 
            // bGoMark1
            // 
            this.bGoMark1.Location = new System.Drawing.Point(83, 23);
            this.bGoMark1.Name = "bGoMark1";
            this.bGoMark1.Size = new System.Drawing.Size(69, 40);
            this.bGoMark1.TabIndex = 2;
            this.bGoMark1.Text = "移动到";
            this.bGoMark1.UseVisualStyleBackColor = true;
            this.bGoMark1.Click += new System.EventHandler(this.bGoMark1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bGoMark1);
            this.groupBox1.Controls.Add(this.lMark1Y);
            this.groupBox1.Controls.Add(this.lMark1X);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mark1";
            // 
            // fmPasteCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 472);
            this.Controls.Add(this.gOffset);
            this.Controls.Add(this.bMoveMark);
            this.Controls.Add(this.lMoveTo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "fmPasteCheck";
            this.Text = "上视觉校验";
            this.Load += new System.EventHandler(this.fmPasteCheck_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gOffset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox bEnableOffset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bGoMark2;
        private System.Windows.Forms.Label lMark2Y;
        private System.Windows.Forms.Label lMark2X;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bGoMark1;
        private System.Windows.Forms.Label lMark1Y;
        private System.Windows.Forms.Label lMark1X;
        private System.Windows.Forms.Button lMoveTo;
        private System.Windows.Forms.Button bMoveMark;
        private System.Windows.Forms.Button bRecord;
        private System.Windows.Forms.Button bOffset;
        private System.Windows.Forms.GroupBox gOffset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}
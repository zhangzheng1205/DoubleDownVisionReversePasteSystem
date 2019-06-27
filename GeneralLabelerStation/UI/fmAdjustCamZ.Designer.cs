namespace GeneralLabelerStation.UI
{
    partial class fmAdjustCamZ
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
            this.bCal = new System.Windows.Forms.Button();
            this.tAppend = new System.Windows.Forms.RichTextBox();
            this.bAutoCal = new System.Windows.Forms.Button();
            this.cb_SelectNz = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bAutoSet = new System.Windows.Forms.Button();
            this.tZ1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tZ2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tZ3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tZ4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bUpdate2Set = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCal
            // 
            this.bCal.BackColor = System.Drawing.Color.Yellow;
            this.bCal.Location = new System.Drawing.Point(11, 20);
            this.bCal.Name = "bCal";
            this.bCal.Size = new System.Drawing.Size(76, 38);
            this.bCal.TabIndex = 0;
            this.bCal.Text = "计算清晰度";
            this.bCal.UseVisualStyleBackColor = false;
            this.bCal.Click += new System.EventHandler(this.bCal_Click);
            // 
            // tAppend
            // 
            this.tAppend.Location = new System.Drawing.Point(138, 20);
            this.tAppend.Name = "tAppend";
            this.tAppend.Size = new System.Drawing.Size(266, 150);
            this.tAppend.TabIndex = 1;
            this.tAppend.Text = "";
            // 
            // bAutoCal
            // 
            this.bAutoCal.BackColor = System.Drawing.Color.Yellow;
            this.bAutoCal.Location = new System.Drawing.Point(11, 132);
            this.bAutoCal.Name = "bAutoCal";
            this.bAutoCal.Size = new System.Drawing.Size(121, 38);
            this.bAutoCal.TabIndex = 2;
            this.bAutoCal.Text = "一键调整";
            this.bAutoCal.UseVisualStyleBackColor = false;
            this.bAutoCal.Click += new System.EventHandler(this.bAutoCal_Click);
            // 
            // cb_SelectNz
            // 
            this.cb_SelectNz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectNz.FormattingEnabled = true;
            this.cb_SelectNz.Items.AddRange(new object[] {
            "Z1",
            "Z2",
            "Z3",
            "Z4"});
            this.cb_SelectNz.Location = new System.Drawing.Point(11, 106);
            this.cb_SelectNz.Name = "cb_SelectNz";
            this.cb_SelectNz.Size = new System.Drawing.Size(121, 25);
            this.cb_SelectNz.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "选择调整Z轴:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tAppend);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bCal);
            this.groupBox1.Controls.Add(this.cb_SelectNz);
            this.groupBox1.Controls.Add(this.bAutoCal);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 196);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拍照高度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bUpdate2Set);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tZ4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tZ3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tZ2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tZ1);
            this.groupBox2.Controls.Add(this.bAutoSet);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(1, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 197);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "贴附高度";
            // 
            // bAutoSet
            // 
            this.bAutoSet.BackColor = System.Drawing.Color.Yellow;
            this.bAutoSet.Location = new System.Drawing.Point(13, 55);
            this.bAutoSet.Name = "bAutoSet";
            this.bAutoSet.Size = new System.Drawing.Size(121, 38);
            this.bAutoSet.TabIndex = 5;
            this.bAutoSet.Text = "一键调整";
            this.bAutoSet.UseVisualStyleBackColor = false;
            this.bAutoSet.Click += new System.EventHandler(this.bAutoSet_Click);
            // 
            // tZ1
            // 
            this.tZ1.Location = new System.Drawing.Point(312, 25);
            this.tZ1.Name = "tZ1";
            this.tZ1.Size = new System.Drawing.Size(100, 27);
            this.tZ1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Z1高度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Z2高度：";
            // 
            // tZ2
            // 
            this.tZ2.Location = new System.Drawing.Point(312, 53);
            this.tZ2.Name = "tZ2";
            this.tZ2.Size = new System.Drawing.Size(100, 27);
            this.tZ2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Z3高度：";
            // 
            // tZ3
            // 
            this.tZ3.Location = new System.Drawing.Point(312, 81);
            this.tZ3.Name = "tZ3";
            this.tZ3.Size = new System.Drawing.Size(100, 27);
            this.tZ3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Z4高度：";
            // 
            // tZ4
            // 
            this.tZ4.Location = new System.Drawing.Point(312, 109);
            this.tZ4.Name = "tZ4";
            this.tZ4.Size = new System.Drawing.Size(100, 27);
            this.tZ4.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "=>";
            // 
            // bUpdate2Set
            // 
            this.bUpdate2Set.BackColor = System.Drawing.Color.GreenYellow;
            this.bUpdate2Set.Location = new System.Drawing.Point(235, 147);
            this.bUpdate2Set.Name = "bUpdate2Set";
            this.bUpdate2Set.Size = new System.Drawing.Size(177, 36);
            this.bUpdate2Set.TabIndex = 17;
            this.bUpdate2Set.Text = "更新到系统参数";
            this.bUpdate2Set.UseVisualStyleBackColor = false;
            this.bUpdate2Set.Click += new System.EventHandler(this.bUpdate2Set_Click);
            // 
            // fmAdjustCamZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fmAdjustCamZ";
            this.Text = "自动调整Z轴拍照高度";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCal;
        private System.Windows.Forms.RichTextBox tAppend;
        private System.Windows.Forms.Button bAutoCal;
        private System.Windows.Forms.ComboBox cb_SelectNz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tZ4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tZ3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tZ2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tZ1;
        private System.Windows.Forms.Button bAutoSet;
        private System.Windows.Forms.Button bUpdate2Set;
    }
}
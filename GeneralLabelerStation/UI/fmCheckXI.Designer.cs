namespace GeneralLabelerStation.UI
{
    partial class fmCheckXI
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bChange = new System.Windows.Forms.Button();
            this.bDetect = new System.Windows.Forms.Button();
            this.nSuckPosY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nSuckPosX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bAutoSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLabelIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nOffsetX = new System.Windows.Forms.NumericUpDown();
            this.nOffsetY = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSuckPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSuckPosX)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.bChange);
            this.groupBox3.Controls.Add(this.bDetect);
            this.groupBox3.Controls.Add(this.nSuckPosY);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.nSuckPosX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(662, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "取料标准位置(料-距离吸嘴旋转中心距离)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(575, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "到拍照位";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bChange
            // 
            this.bChange.BackColor = System.Drawing.Color.Yellow;
            this.bChange.Location = new System.Drawing.Point(373, 28);
            this.bChange.Name = "bChange";
            this.bChange.Size = new System.Drawing.Size(75, 28);
            this.bChange.TabIndex = 5;
            this.bChange.Text = "修改";
            this.bChange.UseVisualStyleBackColor = false;
            this.bChange.Click += new System.EventHandler(this.bChange_Click);
            // 
            // bDetect
            // 
            this.bDetect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bDetect.Location = new System.Drawing.Point(282, 28);
            this.bDetect.Name = "bDetect";
            this.bDetect.Size = new System.Drawing.Size(75, 28);
            this.bDetect.TabIndex = 4;
            this.bDetect.Text = "侦测";
            this.bDetect.UseVisualStyleBackColor = false;
            this.bDetect.Click += new System.EventHandler(this.button1_Click);
            // 
            // nSuckPosY
            // 
            this.nSuckPosY.DecimalPlaces = 1;
            this.nSuckPosY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nSuckPosY.Location = new System.Drawing.Point(185, 29);
            this.nSuckPosY.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nSuckPosY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nSuckPosY.Name = "nSuckPosY";
            this.nSuckPosY.Size = new System.Drawing.Size(78, 26);
            this.nSuckPosY.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y:";
            // 
            // nSuckPosX
            // 
            this.nSuckPosX.DecimalPlaces = 1;
            this.nSuckPosX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nSuckPosX.Location = new System.Drawing.Point(52, 29);
            this.nSuckPosX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nSuckPosX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nSuckPosX.Name = "nSuckPosX";
            this.nSuckPosX.Size = new System.Drawing.Size(78, 26);
            this.nSuckPosX.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "X:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nOffsetY);
            this.groupBox4.Controls.Add(this.nOffsetX);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cbLabelIndex);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.bUpdate);
            this.groupBox4.Controls.Add(this.bAutoSet);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 177);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "吸嘴1-各位置吸取位自动调整";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.Yellow;
            this.bUpdate.Location = new System.Drawing.Point(455, 25);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(195, 91);
            this.bUpdate.TabIndex = 4;
            this.bUpdate.Text = "更新到Feeder取料位";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bAutoSet
            // 
            this.bAutoSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bAutoSet.Location = new System.Drawing.Point(264, 25);
            this.bAutoSet.Name = "bAutoSet";
            this.bAutoSet.Size = new System.Drawing.Size(185, 91);
            this.bAutoSet.TabIndex = 1;
            this.bAutoSet.Text = "吸取选中位-根据标准位置-拍照自动调整";
            this.bAutoSet.UseVisualStyleBackColor = false;
            this.bAutoSet.Click += new System.EventHandler(this.bAutoSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "取第几号料:";
            // 
            // cbLabelIndex
            // 
            this.cbLabelIndex.FormattingEnabled = true;
            this.cbLabelIndex.Items.AddRange(new object[] {
            "1"});
            this.cbLabelIndex.Location = new System.Drawing.Point(117, 44);
            this.cbLabelIndex.Name = "cbLabelIndex";
            this.cbLabelIndex.Size = new System.Drawing.Size(121, 28);
            this.cbLabelIndex.TabIndex = 6;
            this.cbLabelIndex.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "与旋转中心偏差X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "与旋转中心偏差Y:";
            // 
            // nOffsetX
            // 
            this.nOffsetX.DecimalPlaces = 1;
            this.nOffsetX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nOffsetX.Location = new System.Drawing.Point(153, 81);
            this.nOffsetX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nOffsetX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nOffsetX.Name = "nOffsetX";
            this.nOffsetX.Size = new System.Drawing.Size(78, 26);
            this.nOffsetX.TabIndex = 7;
            // 
            // nOffsetY
            // 
            this.nOffsetY.DecimalPlaces = 1;
            this.nOffsetY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nOffsetY.Location = new System.Drawing.Point(153, 117);
            this.nOffsetY.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nOffsetY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nOffsetY.Name = "nOffsetY";
            this.nOffsetY.Size = new System.Drawing.Size(78, 26);
            this.nOffsetY.TabIndex = 7;
            // 
            // fmCheckXI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 253);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmCheckXI";
            this.Text = "吸标管控";
            this.Load += new System.EventHandler(this.fmCheckXI_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSuckPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSuckPosX)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bChange;
        private System.Windows.Forms.Button bDetect;
        private System.Windows.Forms.NumericUpDown nSuckPosY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nSuckPosX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bAutoSet;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbLabelIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nOffsetY;
        private System.Windows.Forms.NumericUpDown nOffsetX;
    }
}
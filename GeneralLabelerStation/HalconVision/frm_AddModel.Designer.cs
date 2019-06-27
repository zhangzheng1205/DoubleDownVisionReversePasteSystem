namespace GeneralLabelerStation
{
    partial class frm_AddModel
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
            this.pictureBox_ShowImage = new System.Windows.Forms.PictureBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.buttonCreateModel = new System.Windows.Forms.Button();
            this.buttonModelPath = new System.Windows.Forms.Button();
            this.buttonFindModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tY = new System.Windows.Forms.TextBox();
            this.tX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nOffsetY = new System.Windows.Forms.NumericUpDown();
            this.nOffsetX = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonModelByHand = new System.Windows.Forms.Button();
            this.buttonModelAdd = new System.Windows.Forms.Button();
            this.bClearModel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tRAngle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tRY = new System.Windows.Forms.TextBox();
            this.tRX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bGetImage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ShowImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetX)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_ShowImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 662);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox_ShowImage
            // 
            this.pictureBox_ShowImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_ShowImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ShowImage.Name = "pictureBox_ShowImage";
            this.pictureBox_ShowImage.Size = new System.Drawing.Size(929, 662);
            this.pictureBox_ShowImage.TabIndex = 0;
            this.pictureBox_ShowImage.TabStop = false;
            // 
            // bOK
            // 
            this.bOK.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.bOK.Font = new System.Drawing.Font("SimSun", 25F);
            this.bOK.Location = new System.Drawing.Point(935, 2);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(132, 51);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "确定";
            this.bOK.UseVisualStyleBackColor = false;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("SimSun", 25F);
            this.bCancel.Location = new System.Drawing.Point(1081, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(132, 51);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "取消";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // buttonCreateModel
            // 
            this.buttonCreateModel.Font = new System.Drawing.Font("SimSun", 15F);
            this.buttonCreateModel.Location = new System.Drawing.Point(936, 245);
            this.buttonCreateModel.Name = "buttonCreateModel";
            this.buttonCreateModel.Size = new System.Drawing.Size(278, 62);
            this.buttonCreateModel.TabIndex = 4;
            this.buttonCreateModel.Text = "5.创建模板轮廓";
            this.buttonCreateModel.UseVisualStyleBackColor = true;
            this.buttonCreateModel.Click += new System.EventHandler(this.buttonCreateModel_Click);
            // 
            // buttonModelPath
            // 
            this.buttonModelPath.Font = new System.Drawing.Font("SimSun", 15F);
            this.buttonModelPath.Location = new System.Drawing.Point(936, 56);
            this.buttonModelPath.Name = "buttonModelPath";
            this.buttonModelPath.Size = new System.Drawing.Size(131, 62);
            this.buttonModelPath.TabIndex = 5;
            this.buttonModelPath.Text = "1.从文件导入图片";
            this.buttonModelPath.UseVisualStyleBackColor = true;
            this.buttonModelPath.Click += new System.EventHandler(this.buttonModelPath_Click);
            // 
            // buttonFindModel
            // 
            this.buttonFindModel.Font = new System.Drawing.Font("SimSun", 15F);
            this.buttonFindModel.Location = new System.Drawing.Point(936, 487);
            this.buttonFindModel.Name = "buttonFindModel";
            this.buttonFindModel.Size = new System.Drawing.Size(278, 41);
            this.buttonFindModel.TabIndex = 6;
            this.buttonFindModel.Text = "测试";
            this.buttonFindModel.UseVisualStyleBackColor = true;
            this.buttonFindModel.Click += new System.EventHandler(this.buttonFindModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tY);
            this.groupBox1.Controls.Add(this.tX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 15F);
            this.groupBox1.Location = new System.Drawing.Point(936, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板点";
            // 
            // tY
            // 
            this.tY.Location = new System.Drawing.Point(135, 51);
            this.tY.Name = "tY";
            this.tY.ReadOnly = true;
            this.tY.Size = new System.Drawing.Size(128, 30);
            this.tY.TabIndex = 12;
            this.tY.Text = "0";
            this.tY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tX
            // 
            this.tX.Location = new System.Drawing.Point(135, 19);
            this.tX.Name = "tX";
            this.tX.ReadOnly = true;
            this.tX.Size = new System.Drawing.Size(128, 30);
            this.tX.TabIndex = 11;
            this.tX.Text = "0";
            this.tX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nOffsetY);
            this.groupBox2.Controls.Add(this.nOffsetX);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 15F);
            this.groupBox2.Location = new System.Drawing.Point(936, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 86);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "调整参考点设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "X:";
            // 
            // nOffsetY
            // 
            this.nOffsetY.Location = new System.Drawing.Point(145, 52);
            this.nOffsetY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nOffsetY.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nOffsetY.Name = "nOffsetY";
            this.nOffsetY.Size = new System.Drawing.Size(118, 30);
            this.nOffsetY.TabIndex = 2;
            // 
            // nOffsetX
            // 
            this.nOffsetX.Location = new System.Drawing.Point(145, 20);
            this.nOffsetX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nOffsetX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nOffsetX.Name = "nOffsetX";
            this.nOffsetX.Size = new System.Drawing.Size(118, 30);
            this.nOffsetX.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonModelByHand
            // 
            this.buttonModelByHand.Font = new System.Drawing.Font("SimSun", 15F);
            this.buttonModelByHand.Location = new System.Drawing.Point(936, 182);
            this.buttonModelByHand.Name = "buttonModelByHand";
            this.buttonModelByHand.Size = new System.Drawing.Size(131, 62);
            this.buttonModelByHand.TabIndex = 12;
            this.buttonModelByHand.Text = "3.开始手绘";
            this.buttonModelByHand.UseVisualStyleBackColor = true;
            this.buttonModelByHand.Click += new System.EventHandler(this.buttonModelByHand_Click);
            // 
            // buttonModelAdd
            // 
            this.buttonModelAdd.Font = new System.Drawing.Font("SimSun", 15F);
            this.buttonModelAdd.Location = new System.Drawing.Point(1073, 182);
            this.buttonModelAdd.Name = "buttonModelAdd";
            this.buttonModelAdd.Size = new System.Drawing.Size(141, 62);
            this.buttonModelAdd.TabIndex = 13;
            this.buttonModelAdd.Text = "4.手绘OK确认增加";
            this.buttonModelAdd.UseVisualStyleBackColor = true;
            this.buttonModelAdd.Click += new System.EventHandler(this.buttonModelAdd_Click);
            // 
            // bClearModel
            // 
            this.bClearModel.Font = new System.Drawing.Font("SimSun", 15F);
            this.bClearModel.Location = new System.Drawing.Point(936, 119);
            this.bClearModel.Name = "bClearModel";
            this.bClearModel.Size = new System.Drawing.Size(278, 62);
            this.bClearModel.TabIndex = 14;
            this.bClearModel.Text = "2.清除模板";
            this.bClearModel.UseVisualStyleBackColor = true;
            this.bClearModel.Click += new System.EventHandler(this.bClearModel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tRAngle);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tRY);
            this.groupBox3.Controls.Add(this.tRX);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("SimSun", 15F);
            this.groupBox3.Location = new System.Drawing.Point(936, 530);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 132);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试结果";
            // 
            // tRAngle
            // 
            this.tRAngle.Location = new System.Drawing.Point(88, 83);
            this.tRAngle.Name = "tRAngle";
            this.tRAngle.ReadOnly = true;
            this.tRAngle.Size = new System.Drawing.Size(175, 30);
            this.tRAngle.TabIndex = 14;
            this.tRAngle.Text = "0";
            this.tRAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "R:";
            // 
            // tRY
            // 
            this.tRY.Location = new System.Drawing.Point(88, 51);
            this.tRY.Name = "tRY";
            this.tRY.ReadOnly = true;
            this.tRY.Size = new System.Drawing.Size(175, 30);
            this.tRY.TabIndex = 12;
            this.tRY.Text = "0";
            this.tRY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tRX
            // 
            this.tRX.Location = new System.Drawing.Point(88, 19);
            this.tRX.Name = "tRX";
            this.tRX.ReadOnly = true;
            this.tRX.Size = new System.Drawing.Size(175, 30);
            this.tRX.TabIndex = 11;
            this.tRX.Text = "0";
            this.tRX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "X:";
            // 
            // bGetImage
            // 
            this.bGetImage.Font = new System.Drawing.Font("SimSun", 15F);
            this.bGetImage.Location = new System.Drawing.Point(1081, 56);
            this.bGetImage.Name = "bGetImage";
            this.bGetImage.Size = new System.Drawing.Size(131, 62);
            this.bGetImage.TabIndex = 16;
            this.bGetImage.Text = "1.从相机导入图片";
            this.bGetImage.UseVisualStyleBackColor = true;
            this.bGetImage.Click += new System.EventHandler(this.bGetImage_Click);
            // 
            // frm_AddModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 662);
            this.Controls.Add(this.bGetImage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bClearModel);
            this.Controls.Add(this.buttonModelAdd);
            this.Controls.Add(this.buttonModelByHand);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonFindModel);
            this.Controls.Add(this.buttonModelPath);
            this.Controls.Add(this.buttonCreateModel);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.panel1);
            this.Name = "frm_AddModel";
            this.Text = "手绘模板";
            this.Load += new System.EventHandler(this.frm_AddModel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ShowImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nOffsetX)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ShowImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button buttonCreateModel;
        private System.Windows.Forms.Button buttonModelPath;
        private System.Windows.Forms.Button buttonFindModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tY;
        private System.Windows.Forms.TextBox tX;
        private System.Windows.Forms.Button buttonModelByHand;
        private System.Windows.Forms.Button buttonModelAdd;
        private System.Windows.Forms.Button bClearModel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tRAngle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tRY;
        private System.Windows.Forms.TextBox tRX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bGetImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nOffsetY;
        private System.Windows.Forms.NumericUpDown nOffsetX;
    }
}
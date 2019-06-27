namespace GeneralLabelerStation
{
    partial class Form_ZDTMES
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
            this.bTestLink = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tLinkCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSide = new System.Windows.Forms.ComboBox();
            this.gridPanel = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bHandle = new System.Windows.Forms.Button();
            this.bReadCode = new System.Windows.Forms.Button();
            this.bShowROI = new System.Windows.Forms.Button();
            this.bRecordROI = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_CodeType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tCycle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tGain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gridCam = new System.Windows.Forms.GroupBox();
            this.bOpenLight = new System.Windows.Forms.Button();
            this.bRecordLight = new System.Windows.Forms.Button();
            this.tExp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bMove = new System.Windows.Forms.Button();
            this.bSet = new System.Windows.Forms.Button();
            this.tYPos = new System.Windows.Forms.TextBox();
            this.tXPos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bUpdate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tBadMarkNO = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gridPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gridCam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bTestLink);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tLinkCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbSide);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(591, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MES-SPI设置";
            // 
            // bTestLink
            // 
            this.bTestLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTestLink.Location = new System.Drawing.Point(470, 45);
            this.bTestLink.Margin = new System.Windows.Forms.Padding(4);
            this.bTestLink.Name = "bTestLink";
            this.bTestLink.Size = new System.Drawing.Size(100, 31);
            this.bTestLink.TabIndex = 4;
            this.bTestLink.Text = "链接测试";
            this.bTestLink.UseVisualStyleBackColor = true;
            this.bTestLink.Click += new System.EventHandler(this.bTestLink_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试条码：";
            // 
            // tLinkCode
            // 
            this.tLinkCode.Location = new System.Drawing.Point(102, 49);
            this.tLinkCode.Margin = new System.Windows.Forms.Padding(4);
            this.tLinkCode.Name = "tLinkCode";
            this.tLinkCode.Size = new System.Drawing.Size(347, 21);
            this.tLinkCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "贴附面：";
            // 
            // cbSide
            // 
            this.cbSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSide.FormattingEnabled = true;
            this.cbSide.Items.AddRange(new object[] {
            "A面",
            "B面"});
            this.cbSide.Location = new System.Drawing.Point(102, 18);
            this.cbSide.Margin = new System.Windows.Forms.Padding(4);
            this.cbSide.Name = "cbSide";
            this.cbSide.Size = new System.Drawing.Size(177, 20);
            this.cbSide.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.groupBox3);
            this.gridPanel.Controls.Add(this.gridCam);
            this.gridPanel.Controls.Add(this.groupBox2);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridPanel.Location = new System.Drawing.Point(0, 84);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(4);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(4);
            this.gridPanel.Size = new System.Drawing.Size(591, 233);
            this.gridPanel.TabIndex = 2;
            this.gridPanel.TabStop = false;
            this.gridPanel.Text = "大板条码读取设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bHandle);
            this.groupBox3.Controls.Add(this.bReadCode);
            this.groupBox3.Controls.Add(this.bShowROI);
            this.groupBox3.Controls.Add(this.bRecordROI);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cb_CodeType);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tCycle);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tOffset);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tGain);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(9, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 128);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读码";
            // 
            // bHandle
            // 
            this.bHandle.Location = new System.Drawing.Point(440, 22);
            this.bHandle.Name = "bHandle";
            this.bHandle.Size = new System.Drawing.Size(75, 23);
            this.bHandle.TabIndex = 12;
            this.bHandle.Text = "处理";
            this.bHandle.UseVisualStyleBackColor = true;
            this.bHandle.Click += new System.EventHandler(this.bHandle_Click);
            // 
            // bReadCode
            // 
            this.bReadCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReadCode.Location = new System.Drawing.Point(293, 79);
            this.bReadCode.Name = "bReadCode";
            this.bReadCode.Size = new System.Drawing.Size(178, 31);
            this.bReadCode.TabIndex = 11;
            this.bReadCode.Text = "读取测试";
            this.bReadCode.UseVisualStyleBackColor = true;
            this.bReadCode.Click += new System.EventHandler(this.bReadCode_Click);
            // 
            // bShowROI
            // 
            this.bShowROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowROI.Location = new System.Drawing.Point(202, 81);
            this.bShowROI.Name = "bShowROI";
            this.bShowROI.Size = new System.Drawing.Size(75, 29);
            this.bShowROI.TabIndex = 10;
            this.bShowROI.Text = "显示";
            this.bShowROI.UseVisualStyleBackColor = true;
            this.bShowROI.Click += new System.EventHandler(this.bShowROI_Click);
            // 
            // bRecordROI
            // 
            this.bRecordROI.BackColor = System.Drawing.Color.Orange;
            this.bRecordROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRecordROI.Location = new System.Drawing.Point(123, 81);
            this.bRecordROI.Name = "bRecordROI";
            this.bRecordROI.Size = new System.Drawing.Size(75, 29);
            this.bRecordROI.TabIndex = 9;
            this.bRecordROI.Text = "记录";
            this.bRecordROI.UseVisualStyleBackColor = false;
            this.bRecordROI.Click += new System.EventHandler(this.bRecordROI_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "记录ROI:";
            // 
            // cb_CodeType
            // 
            this.cb_CodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CodeType.FormattingEnabled = true;
            this.cb_CodeType.Items.AddRange(new object[] {
            "1D39",
            "1D129",
            "1D93",
            "2D_Mat",
            "QR"});
            this.cb_CodeType.Location = new System.Drawing.Point(123, 53);
            this.cb_CodeType.Name = "cb_CodeType";
            this.cb_CodeType.Size = new System.Drawing.Size(302, 20);
            this.cb_CodeType.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "条码类型:";
            // 
            // tCycle
            // 
            this.tCycle.Location = new System.Drawing.Point(373, 22);
            this.tCycle.Name = "tCycle";
            this.tCycle.Size = new System.Drawing.Size(52, 21);
            this.tCycle.TabIndex = 5;
            this.tCycle.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "循环次数:";
            // 
            // tOffset
            // 
            this.tOffset.Location = new System.Drawing.Point(215, 22);
            this.tOffset.Name = "tOffset";
            this.tOffset.Size = new System.Drawing.Size(52, 21);
            this.tOffset.TabIndex = 3;
            this.tOffset.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Offset:";
            // 
            // tGain
            // 
            this.tGain.Location = new System.Drawing.Point(79, 22);
            this.tGain.Name = "tGain";
            this.tGain.Size = new System.Drawing.Size(52, 21);
            this.tGain.TabIndex = 1;
            this.tGain.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gain:";
            // 
            // gridCam
            // 
            this.gridCam.Controls.Add(this.bOpenLight);
            this.gridCam.Controls.Add(this.bRecordLight);
            this.gridCam.Controls.Add(this.tExp);
            this.gridCam.Controls.Add(this.label6);
            this.gridCam.Controls.Add(this.label5);
            this.gridCam.Location = new System.Drawing.Point(215, 21);
            this.gridCam.Name = "gridCam";
            this.gridCam.Size = new System.Drawing.Size(356, 91);
            this.gridCam.TabIndex = 1;
            this.gridCam.TabStop = false;
            this.gridCam.Text = "相机设置";
            // 
            // bOpenLight
            // 
            this.bOpenLight.BackColor = System.Drawing.Color.LightGray;
            this.bOpenLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenLight.Location = new System.Drawing.Point(179, 55);
            this.bOpenLight.Name = "bOpenLight";
            this.bOpenLight.Size = new System.Drawing.Size(86, 30);
            this.bOpenLight.TabIndex = 5;
            this.bOpenLight.Text = "打光";
            this.bOpenLight.UseVisualStyleBackColor = false;
            this.bOpenLight.Click += new System.EventHandler(this.bOpenLight_Click);
            // 
            // bRecordLight
            // 
            this.bRecordLight.BackColor = System.Drawing.Color.LightGray;
            this.bRecordLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRecordLight.Location = new System.Drawing.Point(87, 55);
            this.bRecordLight.Name = "bRecordLight";
            this.bRecordLight.Size = new System.Drawing.Size(86, 30);
            this.bRecordLight.TabIndex = 4;
            this.bRecordLight.Text = "记录";
            this.bRecordLight.UseVisualStyleBackColor = false;
            this.bRecordLight.Click += new System.EventHandler(this.bRecordLight_Click);
            // 
            // tExp
            // 
            this.tExp.Location = new System.Drawing.Point(87, 23);
            this.tExp.Name = "tExp";
            this.tExp.Size = new System.Drawing.Size(87, 21);
            this.tExp.TabIndex = 3;
            this.tExp.Text = "400";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "打光:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "曝光:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bMove);
            this.groupBox2.Controls.Add(this.bSet);
            this.groupBox2.Controls.Add(this.tYPos);
            this.groupBox2.Controls.Add(this.tXPos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 91);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读码位置";
            // 
            // bMove
            // 
            this.bMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMove.Location = new System.Drawing.Point(138, 57);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(45, 27);
            this.bMove.TabIndex = 5;
            this.bMove.Text = "Move";
            this.bMove.UseVisualStyleBackColor = true;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // bSet
            // 
            this.bSet.BackColor = System.Drawing.Color.Orange;
            this.bSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSet.Location = new System.Drawing.Point(138, 25);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(45, 27);
            this.bSet.TabIndex = 4;
            this.bSet.Text = "Set";
            this.bSet.UseVisualStyleBackColor = false;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // tYPos
            // 
            this.tYPos.Location = new System.Drawing.Point(45, 58);
            this.tYPos.Name = "tYPos";
            this.tYPos.Size = new System.Drawing.Size(87, 21);
            this.tYPos.TabIndex = 3;
            this.tYPos.Text = "0";
            // 
            // tXPos
            // 
            this.tXPos.Location = new System.Drawing.Point(45, 26);
            this.tXPos.Name = "tXPos";
            this.tXPos.Size = new System.Drawing.Size(87, 21);
            this.tXPos.TabIndex = 2;
            this.tXPos.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "X:";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.Orange;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Location = new System.Drawing.Point(458, 339);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 31);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "更新";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tBadMarkNO);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(0, 317);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 65);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "产品BadMark数量";
            // 
            // tBadMarkNO
            // 
            this.tBadMarkNO.Location = new System.Drawing.Point(6, 27);
            this.tBadMarkNO.Name = "tBadMarkNO";
            this.tBadMarkNO.Size = new System.Drawing.Size(214, 21);
            this.tBadMarkNO.TabIndex = 0;
            this.tBadMarkNO.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 18F);
            this.checkBox1.Location = new System.Drawing.Point(302, 339);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 28);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "启用MES";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form_ZDTMES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 382);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_ZDTMES";
            this.Text = "脚印系统";
            this.Load += new System.EventHandler(this.Form_ZDTMES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gridCam.ResumeLayout(false);
            this.gridCam.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bTestLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tLinkCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSide;
        private System.Windows.Forms.GroupBox gridPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bHandle;
        private System.Windows.Forms.Button bReadCode;
        private System.Windows.Forms.Button bShowROI;
        private System.Windows.Forms.Button bRecordROI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_CodeType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tCycle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gridCam;
        private System.Windows.Forms.Button bOpenLight;
        private System.Windows.Forms.Button bRecordLight;
        private System.Windows.Forms.TextBox tExp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.TextBox tYPos;
        private System.Windows.Forms.TextBox tXPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tBadMarkNO;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
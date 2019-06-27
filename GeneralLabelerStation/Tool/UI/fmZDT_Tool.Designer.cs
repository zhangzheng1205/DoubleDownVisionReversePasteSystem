namespace GeneralLabelerStation.Tool
{
    partial class fmZDT_Tool
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.bTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ReadCodeName = new System.Windows.Forms.ComboBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rB_SPI = new System.Windows.Forms.RadioButton();
            this.rB_XPanel = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tPort_Local = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tIP_Local = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bTestLink2 = new System.Windows.Forms.Button();
            this.tPort_Remote = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tLinkCode2 = new System.Windows.Forms.TextBox();
            this.tIP_Remote = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tBadMarkNO = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rB_PasteNone = new System.Windows.Forms.RadioButton();
            this.rB_PasteAll = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rB_DisAlarm = new System.Windows.Forms.RadioButton();
            this.rB_Alarm = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bTestLink);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tLinkCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbSide);
            this.groupBox1.Location = new System.Drawing.Point(4, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(758, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MES-脚印设置";
            // 
            // bTestLink
            // 
            this.bTestLink.Location = new System.Drawing.Point(470, 77);
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
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试条码：";
            // 
            // tLinkCode
            // 
            this.tLinkCode.Location = new System.Drawing.Point(102, 79);
            this.tLinkCode.Margin = new System.Windows.Forms.Padding(4);
            this.tLinkCode.Name = "tLinkCode";
            this.tLinkCode.Size = new System.Drawing.Size(347, 26);
            this.tLinkCode.TabIndex = 2;
            this.tLinkCode.Text = "Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
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
            this.cbSide.Location = new System.Drawing.Point(102, 48);
            this.cbSide.Margin = new System.Windows.Forms.Padding(4);
            this.cbSide.Name = "cbSide";
            this.cbSide.Size = new System.Drawing.Size(177, 24);
            this.cbSide.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.bTest);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.cb_ReadCodeName);
            this.groupBox8.Location = new System.Drawing.Point(4, 300);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(758, 84);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "读取条码";
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(349, 41);
            this.bTest.Margin = new System.Windows.Forms.Padding(4);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(100, 31);
            this.bTest.TabIndex = 5;
            this.bTest.Text = "读取测试";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "条码配置:";
            // 
            // cb_ReadCodeName
            // 
            this.cb_ReadCodeName.FormattingEnabled = true;
            this.cb_ReadCodeName.Location = new System.Drawing.Point(141, 44);
            this.cb_ReadCodeName.Name = "cb_ReadCodeName";
            this.cb_ReadCodeName.Size = new System.Drawing.Size(185, 24);
            this.cb_ReadCodeName.TabIndex = 14;
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.LimeGreen;
            this.bUpdate.Location = new System.Drawing.Point(636, 12);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(126, 39);
            this.bUpdate.TabIndex = 2;
            this.bUpdate.Text = "更新";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rB_SPI);
            this.groupBox4.Controls.Add(this.rB_XPanel);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(4, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 49);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mes方式";
            // 
            // rB_SPI
            // 
            this.rB_SPI.AutoSize = true;
            this.rB_SPI.Checked = true;
            this.rB_SPI.Location = new System.Drawing.Point(9, 23);
            this.rB_SPI.Name = "rB_SPI";
            this.rB_SPI.Size = new System.Drawing.Size(58, 20);
            this.rB_SPI.TabIndex = 1;
            this.rB_SPI.TabStop = true;
            this.rB_SPI.Text = "脚印";
            this.rB_SPI.UseVisualStyleBackColor = true;
            // 
            // rB_XPanel
            // 
            this.rB_XPanel.AutoSize = true;
            this.rB_XPanel.Location = new System.Drawing.Point(82, 23);
            this.rB_XPanel.Name = "rB_XPanel";
            this.rB_XPanel.Size = new System.Drawing.Size(66, 20);
            this.rB_XPanel.TabIndex = 0;
            this.rB_XPanel.Text = "X板机";
            this.rB_XPanel.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tPort_Local);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.tIP_Local);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.bTestLink2);
            this.groupBox5.Controls.Add(this.tPort_Remote);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tLinkCode2);
            this.groupBox5.Controls.Add(this.tIP_Remote);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(4, 176);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(758, 117);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MES-X板机设置";
            // 
            // tPort_Local
            // 
            this.tPort_Local.Location = new System.Drawing.Point(320, 20);
            this.tPort_Local.Margin = new System.Windows.Forms.Padding(4);
            this.tPort_Local.Name = "tPort_Local";
            this.tPort_Local.Size = new System.Drawing.Size(129, 26);
            this.tPort_Local.TabIndex = 11;
            this.tPort_Local.Text = "4004";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(270, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 10;
            this.label16.Text = "端口：";
            // 
            // tIP_Local
            // 
            this.tIP_Local.Location = new System.Drawing.Point(103, 20);
            this.tIP_Local.Margin = new System.Windows.Forms.Padding(4);
            this.tIP_Local.Name = "tIP_Local";
            this.tIP_Local.Size = new System.Drawing.Size(160, 26);
            this.tIP_Local.TabIndex = 9;
            this.tIP_Local.Text = "10.182.77.218";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "本地IP：";
            // 
            // bTestLink2
            // 
            this.bTestLink2.Location = new System.Drawing.Point(470, 77);
            this.bTestLink2.Margin = new System.Windows.Forms.Padding(4);
            this.bTestLink2.Name = "bTestLink2";
            this.bTestLink2.Size = new System.Drawing.Size(100, 31);
            this.bTestLink2.TabIndex = 5;
            this.bTestLink2.Text = "链接测试";
            this.bTestLink2.UseVisualStyleBackColor = true;
            this.bTestLink2.Click += new System.EventHandler(this.bTestLink2_Click);
            // 
            // tPort_Remote
            // 
            this.tPort_Remote.Location = new System.Drawing.Point(320, 51);
            this.tPort_Remote.Margin = new System.Windows.Forms.Padding(4);
            this.tPort_Remote.Name = "tPort_Remote";
            this.tPort_Remote.Size = new System.Drawing.Size(129, 26);
            this.tPort_Remote.TabIndex = 7;
            this.tPort_Remote.Text = "4004";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 54);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "端口：";
            // 
            // tLinkCode2
            // 
            this.tLinkCode2.Location = new System.Drawing.Point(102, 82);
            this.tLinkCode2.Margin = new System.Windows.Forms.Padding(4);
            this.tLinkCode2.Name = "tLinkCode2";
            this.tLinkCode2.Size = new System.Drawing.Size(347, 26);
            this.tLinkCode2.TabIndex = 5;
            this.tLinkCode2.Text = "Barcode";
            // 
            // tIP_Remote
            // 
            this.tIP_Remote.Location = new System.Drawing.Point(102, 51);
            this.tIP_Remote.Margin = new System.Windows.Forms.Padding(4);
            this.tIP_Remote.Name = "tIP_Remote";
            this.tIP_Remote.Size = new System.Drawing.Size(160, 26);
            this.tIP_Remote.TabIndex = 5;
            this.tIP_Remote.Text = "10.182.77.218";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "X板机IP：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "测试条码：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tBadMarkNO);
            this.groupBox6.Location = new System.Drawing.Point(476, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(154, 49);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "产品BadMark数量";
            // 
            // tBadMarkNO
            // 
            this.tBadMarkNO.Location = new System.Drawing.Point(6, 18);
            this.tBadMarkNO.Name = "tBadMarkNO";
            this.tBadMarkNO.Size = new System.Drawing.Size(142, 26);
            this.tBadMarkNO.TabIndex = 0;
            this.tBadMarkNO.Text = "0";
            this.tBadMarkNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel2);
            this.groupBox7.Controls.Add(this.panel1);
            this.groupBox7.Location = new System.Drawing.Point(171, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(298, 49);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "数据链接失败后处理方式";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rB_PasteNone);
            this.panel2.Controls.Add(this.rB_PasteAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(167, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 24);
            this.panel2.TabIndex = 1;
            // 
            // rB_PasteNone
            // 
            this.rB_PasteNone.AutoSize = true;
            this.rB_PasteNone.Dock = System.Windows.Forms.DockStyle.Left;
            this.rB_PasteNone.Location = new System.Drawing.Point(58, 0);
            this.rB_PasteNone.Name = "rB_PasteNone";
            this.rB_PasteNone.Size = new System.Drawing.Size(74, 24);
            this.rB_PasteNone.TabIndex = 1;
            this.rB_PasteNone.Text = "不贴附";
            this.rB_PasteNone.UseVisualStyleBackColor = true;
            // 
            // rB_PasteAll
            // 
            this.rB_PasteAll.AutoSize = true;
            this.rB_PasteAll.Checked = true;
            this.rB_PasteAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.rB_PasteAll.Location = new System.Drawing.Point(0, 0);
            this.rB_PasteAll.Name = "rB_PasteAll";
            this.rB_PasteAll.Size = new System.Drawing.Size(58, 24);
            this.rB_PasteAll.TabIndex = 0;
            this.rB_PasteAll.TabStop = true;
            this.rB_PasteAll.Text = "贴附";
            this.rB_PasteAll.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rB_DisAlarm);
            this.panel1.Controls.Add(this.rB_Alarm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 24);
            this.panel1.TabIndex = 0;
            // 
            // rB_DisAlarm
            // 
            this.rB_DisAlarm.AutoSize = true;
            this.rB_DisAlarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.rB_DisAlarm.Location = new System.Drawing.Point(58, 0);
            this.rB_DisAlarm.Name = "rB_DisAlarm";
            this.rB_DisAlarm.Size = new System.Drawing.Size(74, 24);
            this.rB_DisAlarm.TabIndex = 1;
            this.rB_DisAlarm.Text = "不报警";
            this.rB_DisAlarm.UseVisualStyleBackColor = true;
            // 
            // rB_Alarm
            // 
            this.rB_Alarm.AutoSize = true;
            this.rB_Alarm.Checked = true;
            this.rB_Alarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.rB_Alarm.Location = new System.Drawing.Point(0, 0);
            this.rB_Alarm.Name = "rB_Alarm";
            this.rB_Alarm.Size = new System.Drawing.Size(58, 24);
            this.rB_Alarm.TabIndex = 0;
            this.rB_Alarm.TabStop = true;
            this.rB_Alarm.Text = "报警";
            this.rB_Alarm.UseVisualStyleBackColor = true;
            // 
            // fmZDT_Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 396);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmZDT_Tool";
            this.Text = "MES";
            this.Load += new System.EventHandler(this.fmZDT_Tool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSide;
        private System.Windows.Forms.Button bTestLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tLinkCode;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rB_SPI;
        private System.Windows.Forms.RadioButton rB_XPanel;
        private System.Windows.Forms.TextBox tLinkCode2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tIP_Remote;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bTestLink2;
        private System.Windows.Forms.TextBox tPort_Remote;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tPort_Local;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tIP_Local;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tBadMarkNO;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rB_PasteNone;
        private System.Windows.Forms.RadioButton rB_PasteAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rB_DisAlarm;
        private System.Windows.Forms.RadioButton rB_Alarm;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ReadCodeName;
        private System.Windows.Forms.Button bTest;
    }
}
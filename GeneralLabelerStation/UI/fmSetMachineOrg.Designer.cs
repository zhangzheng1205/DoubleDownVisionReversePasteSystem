namespace GeneralLabelerStation.UI
{
    partial class fmSetMachineOrg
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
            this.EnableMachineOrg = new System.Windows.Forms.CheckBox();
            this.圆心坐标 = new System.Windows.Forms.GroupBox();
            this.bMove = new System.Windows.Forms.Button();
            this.bFindCircle = new System.Windows.Forms.Button();
            this.tCircleY = new System.Windows.Forms.TextBox();
            this.tCircleX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tR = new System.Windows.Forms.Label();
            this.tExp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tMaxR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tMinR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bMove_Org2 = new System.Windows.Forms.Button();
            this.bDetectOrg2 = new System.Windows.Forms.Button();
            this.tD_Org2Y = new System.Windows.Forms.TextBox();
            this.tD_Org2X = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bMove_Org1 = new System.Windows.Forms.Button();
            this.bDetectOrg1 = new System.Windows.Forms.Button();
            this.tD_Org1Y = new System.Windows.Forms.TextBox();
            this.tD_Org1X = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tD_Exp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tD_MaxR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tD_MinR = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.nSpace = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nLimit = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.圆心坐标.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // EnableMachineOrg
            // 
            this.EnableMachineOrg.AutoSize = true;
            this.EnableMachineOrg.Location = new System.Drawing.Point(16, 281);
            this.EnableMachineOrg.Margin = new System.Windows.Forms.Padding(4);
            this.EnableMachineOrg.Name = "EnableMachineOrg";
            this.EnableMachineOrg.Size = new System.Drawing.Size(123, 20);
            this.EnableMachineOrg.TabIndex = 0;
            this.EnableMachineOrg.Text = "启用自动校准";
            this.EnableMachineOrg.UseVisualStyleBackColor = true;
            // 
            // 圆心坐标
            // 
            this.圆心坐标.Controls.Add(this.bMove);
            this.圆心坐标.Controls.Add(this.bFindCircle);
            this.圆心坐标.Controls.Add(this.tCircleY);
            this.圆心坐标.Controls.Add(this.tCircleX);
            this.圆心坐标.Controls.Add(this.label2);
            this.圆心坐标.Controls.Add(this.label1);
            this.圆心坐标.Dock = System.Windows.Forms.DockStyle.Left;
            this.圆心坐标.Location = new System.Drawing.Point(371, 22);
            this.圆心坐标.Name = "圆心坐标";
            this.圆心坐标.Size = new System.Drawing.Size(204, 108);
            this.圆心坐标.TabIndex = 1;
            this.圆心坐标.TabStop = false;
            this.圆心坐标.Text = "圆心机台坐标";
            // 
            // bMove
            // 
            this.bMove.BackColor = System.Drawing.Color.White;
            this.bMove.Location = new System.Drawing.Point(130, 59);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(62, 23);
            this.bMove.TabIndex = 5;
            this.bMove.Text = "Move";
            this.bMove.UseVisualStyleBackColor = false;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // bFindCircle
            // 
            this.bFindCircle.BackColor = System.Drawing.Color.Yellow;
            this.bFindCircle.Location = new System.Drawing.Point(131, 29);
            this.bFindCircle.Name = "bFindCircle";
            this.bFindCircle.Size = new System.Drawing.Size(62, 23);
            this.bFindCircle.TabIndex = 4;
            this.bFindCircle.Text = "侦测";
            this.bFindCircle.UseVisualStyleBackColor = false;
            this.bFindCircle.Click += new System.EventHandler(this.bFindCircle_Click);
            // 
            // tCircleY
            // 
            this.tCircleY.Location = new System.Drawing.Point(46, 60);
            this.tCircleY.Name = "tCircleY";
            this.tCircleY.Size = new System.Drawing.Size(75, 26);
            this.tCircleY.TabIndex = 3;
            // 
            // tCircleX
            // 
            this.tCircleX.Location = new System.Drawing.Point(47, 28);
            this.tCircleX.Name = "tCircleX";
            this.tCircleX.Size = new System.Drawing.Size(75, 26);
            this.tCircleX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tR);
            this.groupBox1.Controls.Add(this.tExp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tMaxR);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tMinR);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "侦测设置";
            // 
            // tR
            // 
            this.tR.AutoSize = true;
            this.tR.Location = new System.Drawing.Point(245, 41);
            this.tR.Name = "tR";
            this.tR.Size = new System.Drawing.Size(16, 16);
            this.tR.TabIndex = 6;
            this.tR.Text = "0";
            // 
            // tExp
            // 
            this.tExp.Location = new System.Drawing.Point(99, 76);
            this.tExp.Name = "tExp";
            this.tExp.Size = new System.Drawing.Size(52, 26);
            this.tExp.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "相机曝光：";
            // 
            // tMaxR
            // 
            this.tMaxR.Location = new System.Drawing.Point(185, 37);
            this.tMaxR.Name = "tMaxR";
            this.tMaxR.Size = new System.Drawing.Size(54, 26);
            this.tMaxR.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "-";
            // 
            // tMinR
            // 
            this.tMinR.Location = new System.Drawing.Point(99, 37);
            this.tMinR.Name = "tMinR";
            this.tMinR.Size = new System.Drawing.Size(52, 26);
            this.tMinR.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "半径:";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.Yellow;
            this.bUpdate.Location = new System.Drawing.Point(16, 334);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(139, 35);
            this.bUpdate.TabIndex = 5;
            this.bUpdate.Text = "更新";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.圆心坐标);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 133);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XY机械原点";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 132);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "翻转头原点";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bMove_Org2);
            this.groupBox6.Controls.Add(this.bDetectOrg2);
            this.groupBox6.Controls.Add(this.tD_Org2Y);
            this.groupBox6.Controls.Add(this.tD_Org2X);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(575, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(204, 107);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "圆心2机台坐标";
            // 
            // bMove_Org2
            // 
            this.bMove_Org2.BackColor = System.Drawing.Color.White;
            this.bMove_Org2.Location = new System.Drawing.Point(130, 59);
            this.bMove_Org2.Name = "bMove_Org2";
            this.bMove_Org2.Size = new System.Drawing.Size(62, 23);
            this.bMove_Org2.TabIndex = 5;
            this.bMove_Org2.Text = "Move";
            this.bMove_Org2.UseVisualStyleBackColor = false;
            this.bMove_Org2.Click += new System.EventHandler(this.bMove_Org2_Click);
            // 
            // bDetectOrg2
            // 
            this.bDetectOrg2.BackColor = System.Drawing.Color.Yellow;
            this.bDetectOrg2.Location = new System.Drawing.Point(131, 29);
            this.bDetectOrg2.Name = "bDetectOrg2";
            this.bDetectOrg2.Size = new System.Drawing.Size(62, 23);
            this.bDetectOrg2.TabIndex = 4;
            this.bDetectOrg2.Text = "侦测";
            this.bDetectOrg2.UseVisualStyleBackColor = false;
            this.bDetectOrg2.Click += new System.EventHandler(this.bDetectOrg2_Click);
            // 
            // tD_Org2Y
            // 
            this.tD_Org2Y.Location = new System.Drawing.Point(46, 60);
            this.tD_Org2Y.Name = "tD_Org2Y";
            this.tD_Org2Y.Size = new System.Drawing.Size(75, 26);
            this.tD_Org2Y.TabIndex = 3;
            // 
            // tD_Org2X
            // 
            this.tD_Org2X.Location = new System.Drawing.Point(47, 28);
            this.tD_Org2X.Name = "tD_Org2X";
            this.tD_Org2X.Size = new System.Drawing.Size(75, 26);
            this.tD_Org2X.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Y:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "X:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bMove_Org1);
            this.groupBox5.Controls.Add(this.bDetectOrg1);
            this.groupBox5.Controls.Add(this.tD_Org1Y);
            this.groupBox5.Controls.Add(this.tD_Org1X);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(371, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 107);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "圆心1机台坐标";
            // 
            // bMove_Org1
            // 
            this.bMove_Org1.BackColor = System.Drawing.Color.White;
            this.bMove_Org1.Location = new System.Drawing.Point(130, 59);
            this.bMove_Org1.Name = "bMove_Org1";
            this.bMove_Org1.Size = new System.Drawing.Size(62, 23);
            this.bMove_Org1.TabIndex = 5;
            this.bMove_Org1.Text = "Move";
            this.bMove_Org1.UseVisualStyleBackColor = false;
            this.bMove_Org1.Click += new System.EventHandler(this.bMove_Org1_Click);
            // 
            // bDetectOrg1
            // 
            this.bDetectOrg1.BackColor = System.Drawing.Color.Yellow;
            this.bDetectOrg1.Location = new System.Drawing.Point(131, 29);
            this.bDetectOrg1.Name = "bDetectOrg1";
            this.bDetectOrg1.Size = new System.Drawing.Size(62, 23);
            this.bDetectOrg1.TabIndex = 4;
            this.bDetectOrg1.Text = "侦测";
            this.bDetectOrg1.UseVisualStyleBackColor = false;
            this.bDetectOrg1.Click += new System.EventHandler(this.bDetectOrg1_Click);
            // 
            // tD_Org1Y
            // 
            this.tD_Org1Y.Location = new System.Drawing.Point(46, 60);
            this.tD_Org1Y.Name = "tD_Org1Y";
            this.tD_Org1Y.Size = new System.Drawing.Size(75, 26);
            this.tD_Org1Y.TabIndex = 3;
            // 
            // tD_Org1X
            // 
            this.tD_Org1X.Location = new System.Drawing.Point(47, 28);
            this.tD_Org1X.Name = "tD_Org1X";
            this.tD_Org1X.Size = new System.Drawing.Size(75, 26);
            this.tD_Org1X.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "X:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tD_Exp);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tD_MaxR);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tD_MinR);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 107);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "侦测设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "0";
            // 
            // tD_Exp
            // 
            this.tD_Exp.Location = new System.Drawing.Point(99, 76);
            this.tD_Exp.Name = "tD_Exp";
            this.tD_Exp.Size = new System.Drawing.Size(52, 26);
            this.tD_Exp.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "相机曝光：";
            // 
            // tD_MaxR
            // 
            this.tD_MaxR.Location = new System.Drawing.Point(185, 37);
            this.tD_MaxR.Name = "tD_MaxR";
            this.tD_MaxR.Size = new System.Drawing.Size(54, 26);
            this.tD_MaxR.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "-";
            // 
            // tD_MinR
            // 
            this.tD_MinR.Location = new System.Drawing.Point(99, 37);
            this.tD_MinR.Name = "tD_MinR";
            this.tD_MinR.Size = new System.Drawing.Size(52, 26);
            this.tD_MinR.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "半径:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(640, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(203, 283);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "自动校准时间间隔:";
            // 
            // nSpace
            // 
            this.nSpace.Location = new System.Drawing.Point(353, 278);
            this.nSpace.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nSpace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSpace.Name = "nSpace";
            this.nSpace.Size = new System.Drawing.Size(94, 26);
            this.nSpace.TabIndex = 11;
            this.nSpace.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(235, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 16);
            this.label15.TabIndex = 12;
            this.label15.Text = "检验报警阈值:";
            // 
            // nLimit
            // 
            this.nLimit.DecimalPlaces = 2;
            this.nLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nLimit.Location = new System.Drawing.Point(353, 318);
            this.nLimit.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nLimit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nLimit.Name = "nLimit";
            this.nLimit.Size = new System.Drawing.Size(94, 26);
            this.nLimit.TabIndex = 13;
            this.nLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(453, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 16);
            this.label16.TabIndex = 14;
            this.label16.Text = "mm";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(453, 285);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "小时";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(502, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "手动检验";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmSetMachineOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 381);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nLimit);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nSpace);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.EnableMachineOrg);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmSetMachineOrg";
            this.Text = "机械原点设置";
            this.圆心坐标.ResumeLayout(false);
            this.圆心坐标.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnableMachineOrg;
        private System.Windows.Forms.GroupBox 圆心坐标;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.Button bFindCircle;
        private System.Windows.Forms.TextBox tCircleY;
        private System.Windows.Forms.TextBox tCircleX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tMaxR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tMinR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tExp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label tR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bMove_Org2;
        private System.Windows.Forms.Button bDetectOrg2;
        private System.Windows.Forms.TextBox tD_Org2Y;
        private System.Windows.Forms.TextBox tD_Org2X;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bMove_Org1;
        private System.Windows.Forms.Button bDetectOrg1;
        private System.Windows.Forms.TextBox tD_Org1Y;
        private System.Windows.Forms.TextBox tD_Org1X;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tD_Exp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tD_MaxR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tD_MinR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nSpace;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nLimit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button2;
    }
}
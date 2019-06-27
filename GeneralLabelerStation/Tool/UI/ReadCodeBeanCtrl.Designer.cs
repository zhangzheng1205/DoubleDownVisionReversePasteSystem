namespace GeneralLabelerStation.Tool
{
    partial class ReadCodeBeanCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bZJMove = new System.Windows.Forms.Button();
            this.bZJSet = new System.Windows.Forms.Button();
            this.tYPos = new System.Windows.Forms.TextBox();
            this.tXPos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.gridCam = new System.Windows.Forms.GroupBox();
            this.bZJOpenLight = new System.Windows.Forms.Button();
            this.bZJRecordLight = new System.Windows.Forms.Button();
            this.tZJExp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBarcontent = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_CodeType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tCycle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tGain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bZJHandle = new System.Windows.Forms.Button();
            this.bZJReadCode = new System.Windows.Forms.Button();
            this.bZJShowROI = new System.Windows.Forms.Button();
            this.bZJRecordROI = new System.Windows.Forms.Button();
            this.bSetBarcodeFormat = new System.Windows.Forms.Button();
            this.cB_BarcodeFormateEN = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBarcodeFormate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gridCam.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bZJMove);
            this.groupBox2.Controls.Add(this.bZJSet);
            this.groupBox2.Controls.Add(this.tYPos);
            this.groupBox2.Controls.Add(this.tXPos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(206, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读码位置";
            // 
            // bZJMove
            // 
            this.bZJMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJMove.Location = new System.Drawing.Point(134, 55);
            this.bZJMove.Margin = new System.Windows.Forms.Padding(4);
            this.bZJMove.Name = "bZJMove";
            this.bZJMove.Size = new System.Drawing.Size(64, 26);
            this.bZJMove.TabIndex = 5;
            this.bZJMove.Text = "Move";
            this.bZJMove.UseVisualStyleBackColor = true;
            this.bZJMove.Click += new System.EventHandler(this.bZJMove_Click);
            // 
            // bZJSet
            // 
            this.bZJSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJSet.Location = new System.Drawing.Point(134, 21);
            this.bZJSet.Margin = new System.Windows.Forms.Padding(4);
            this.bZJSet.Name = "bZJSet";
            this.bZJSet.Size = new System.Drawing.Size(64, 26);
            this.bZJSet.TabIndex = 4;
            this.bZJSet.Text = "Set";
            this.bZJSet.UseVisualStyleBackColor = true;
            this.bZJSet.Click += new System.EventHandler(this.bZJSet_Click);
            // 
            // tYPos
            // 
            this.tYPos.Location = new System.Drawing.Point(45, 55);
            this.tYPos.Margin = new System.Windows.Forms.Padding(4);
            this.tYPos.Name = "tYPos";
            this.tYPos.Size = new System.Drawing.Size(81, 26);
            this.tYPos.TabIndex = 3;
            this.tYPos.Text = "0";
            // 
            // tXPos
            // 
            this.tXPos.Location = new System.Drawing.Point(45, 21);
            this.tXPos.Margin = new System.Windows.Forms.Padding(4);
            this.tXPos.Name = "tXPos";
            this.tXPos.Size = new System.Drawing.Size(81, 26);
            this.tXPos.TabIndex = 2;
            this.tXPos.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "X:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gridCam);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 120);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bSave);
            this.panel2.Controls.Add(this.bNew);
            this.panel2.Controls.Add(this.bLoad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(523, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 120);
            this.panel2.TabIndex = 3;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.Yellow;
            this.bSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Location = new System.Drawing.Point(0, 76);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(139, 38);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "保存";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bNew
            // 
            this.bNew.BackColor = System.Drawing.Color.Red;
            this.bNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNew.Location = new System.Drawing.Point(0, 38);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(139, 38);
            this.bNew.TabIndex = 1;
            this.bNew.Text = "新建";
            this.bNew.UseVisualStyleBackColor = false;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bLoad
            // 
            this.bLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.bLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoad.Location = new System.Drawing.Point(0, 0);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(139, 38);
            this.bLoad.TabIndex = 0;
            this.bLoad.Text = "加载";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // gridCam
            // 
            this.gridCam.Controls.Add(this.bZJOpenLight);
            this.gridCam.Controls.Add(this.bZJRecordLight);
            this.gridCam.Controls.Add(this.tZJExp);
            this.gridCam.Controls.Add(this.label6);
            this.gridCam.Controls.Add(this.label5);
            this.gridCam.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridCam.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridCam.Location = new System.Drawing.Point(206, 0);
            this.gridCam.Margin = new System.Windows.Forms.Padding(4);
            this.gridCam.Name = "gridCam";
            this.gridCam.Padding = new System.Windows.Forms.Padding(4);
            this.gridCam.Size = new System.Drawing.Size(317, 120);
            this.gridCam.TabIndex = 2;
            this.gridCam.TabStop = false;
            this.gridCam.Text = "相机设置";
            // 
            // bZJOpenLight
            // 
            this.bZJOpenLight.BackColor = System.Drawing.Color.LightGray;
            this.bZJOpenLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJOpenLight.Location = new System.Drawing.Point(193, 73);
            this.bZJOpenLight.Margin = new System.Windows.Forms.Padding(4);
            this.bZJOpenLight.Name = "bZJOpenLight";
            this.bZJOpenLight.Size = new System.Drawing.Size(95, 29);
            this.bZJOpenLight.TabIndex = 5;
            this.bZJOpenLight.Text = "打光";
            this.bZJOpenLight.UseVisualStyleBackColor = false;
            this.bZJOpenLight.Click += new System.EventHandler(this.bZJOpenLight_Click);
            // 
            // bZJRecordLight
            // 
            this.bZJRecordLight.BackColor = System.Drawing.Color.LightGray;
            this.bZJRecordLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJRecordLight.Location = new System.Drawing.Point(90, 73);
            this.bZJRecordLight.Margin = new System.Windows.Forms.Padding(4);
            this.bZJRecordLight.Name = "bZJRecordLight";
            this.bZJRecordLight.Size = new System.Drawing.Size(95, 29);
            this.bZJRecordLight.TabIndex = 4;
            this.bZJRecordLight.Text = "记录";
            this.bZJRecordLight.UseVisualStyleBackColor = false;
            this.bZJRecordLight.Click += new System.EventHandler(this.bZJRecordLight_Click);
            // 
            // tZJExp
            // 
            this.tZJExp.Location = new System.Drawing.Point(90, 31);
            this.tZJExp.Margin = new System.Windows.Forms.Padding(4);
            this.tZJExp.Name = "tZJExp";
            this.tZJExp.Size = new System.Drawing.Size(96, 26);
            this.tZJExp.TabIndex = 3;
            this.tZJExp.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "打光:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "曝光:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBarcontent);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cb_CodeType);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tCycle);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tOffset);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tGain);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.bZJHandle);
            this.groupBox3.Controls.Add(this.bZJReadCode);
            this.groupBox3.Controls.Add(this.bZJShowROI);
            this.groupBox3.Controls.Add(this.bZJRecordROI);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 120);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(672, 133);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读码";
            // 
            // lblBarcontent
            // 
            this.lblBarcontent.Location = new System.Drawing.Point(428, 60);
            this.lblBarcontent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcontent.Name = "lblBarcontent";
            this.lblBarcontent.Size = new System.Drawing.Size(315, 23);
            this.lblBarcontent.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "记录ROI:";
            // 
            // cb_CodeType
            // 
            this.cb_CodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CodeType.FormattingEnabled = true;
            this.cb_CodeType.Items.AddRange(new object[] {
            "1D-39",
            "1D-129",
            "1D-93",
            "2D-DataMatrix",
            "2D-QR"});
            this.cb_CodeType.Location = new System.Drawing.Point(117, 57);
            this.cb_CodeType.Name = "cb_CodeType";
            this.cb_CodeType.Size = new System.Drawing.Size(303, 20);
            this.cb_CodeType.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "条码类型:";
            // 
            // tCycle
            // 
            this.tCycle.Location = new System.Drawing.Point(368, 27);
            this.tCycle.Name = "tCycle";
            this.tCycle.Size = new System.Drawing.Size(52, 21);
            this.tCycle.TabIndex = 18;
            this.tCycle.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "循环次数:";
            // 
            // tOffset
            // 
            this.tOffset.Location = new System.Drawing.Point(211, 27);
            this.tOffset.Name = "tOffset";
            this.tOffset.Size = new System.Drawing.Size(52, 21);
            this.tOffset.TabIndex = 16;
            this.tOffset.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "Offset:";
            // 
            // tGain
            // 
            this.tGain.Location = new System.Drawing.Point(75, 27);
            this.tGain.Name = "tGain";
            this.tGain.Size = new System.Drawing.Size(52, 21);
            this.tGain.TabIndex = 14;
            this.tGain.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Gain:";
            // 
            // bZJHandle
            // 
            this.bZJHandle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJHandle.Location = new System.Drawing.Point(451, 24);
            this.bZJHandle.Margin = new System.Windows.Forms.Padding(4);
            this.bZJHandle.Name = "bZJHandle";
            this.bZJHandle.Size = new System.Drawing.Size(99, 27);
            this.bZJHandle.TabIndex = 12;
            this.bZJHandle.Text = "处理";
            this.bZJHandle.UseVisualStyleBackColor = true;
            this.bZJHandle.Click += new System.EventHandler(this.bZJHandle_Click);
            // 
            // bZJReadCode
            // 
            this.bZJReadCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJReadCode.Location = new System.Drawing.Point(368, 88);
            this.bZJReadCode.Margin = new System.Windows.Forms.Padding(4);
            this.bZJReadCode.Name = "bZJReadCode";
            this.bZJReadCode.Size = new System.Drawing.Size(100, 39);
            this.bZJReadCode.TabIndex = 11;
            this.bZJReadCode.Text = "读取测试";
            this.bZJReadCode.UseVisualStyleBackColor = true;
            this.bZJReadCode.Click += new System.EventHandler(this.bZJReadCode_Click);
            // 
            // bZJShowROI
            // 
            this.bZJShowROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJShowROI.Location = new System.Drawing.Point(227, 88);
            this.bZJShowROI.Margin = new System.Windows.Forms.Padding(4);
            this.bZJShowROI.Name = "bZJShowROI";
            this.bZJShowROI.Size = new System.Drawing.Size(100, 39);
            this.bZJShowROI.TabIndex = 10;
            this.bZJShowROI.Text = "显示";
            this.bZJShowROI.UseVisualStyleBackColor = true;
            this.bZJShowROI.Click += new System.EventHandler(this.bZJShowROI_Click);
            // 
            // bZJRecordROI
            // 
            this.bZJRecordROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bZJRecordROI.Location = new System.Drawing.Point(117, 88);
            this.bZJRecordROI.Margin = new System.Windows.Forms.Padding(4);
            this.bZJRecordROI.Name = "bZJRecordROI";
            this.bZJRecordROI.Size = new System.Drawing.Size(100, 39);
            this.bZJRecordROI.TabIndex = 9;
            this.bZJRecordROI.Text = "记录";
            this.bZJRecordROI.UseVisualStyleBackColor = true;
            this.bZJRecordROI.Click += new System.EventHandler(this.bZJRecordROI_Click);
            // 
            // bSetBarcodeFormat
            // 
            this.bSetBarcodeFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSetBarcodeFormat.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bSetBarcodeFormat.Location = new System.Drawing.Point(523, 267);
            this.bSetBarcodeFormat.Margin = new System.Windows.Forms.Padding(4);
            this.bSetBarcodeFormat.Name = "bSetBarcodeFormat";
            this.bSetBarcodeFormat.Size = new System.Drawing.Size(85, 28);
            this.bSetBarcodeFormat.TabIndex = 12;
            this.bSetBarcodeFormat.Text = "全设为*";
            this.bSetBarcodeFormat.UseVisualStyleBackColor = true;
            this.bSetBarcodeFormat.Click += new System.EventHandler(this.bSetBarcodeFormat_Click);
            // 
            // cB_BarcodeFormateEN
            // 
            this.cB_BarcodeFormateEN.AutoSize = true;
            this.cB_BarcodeFormateEN.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_BarcodeFormateEN.Location = new System.Drawing.Point(9, 269);
            this.cB_BarcodeFormateEN.Margin = new System.Windows.Forms.Padding(4);
            this.cB_BarcodeFormateEN.Name = "cB_BarcodeFormateEN";
            this.cB_BarcodeFormateEN.Size = new System.Drawing.Size(84, 24);
            this.cB_BarcodeFormateEN.TabIndex = 11;
            this.cB_BarcodeFormateEN.Text = "使用格式";
            this.cB_BarcodeFormateEN.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(5, 315);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(412, 60);
            this.label12.TabIndex = 10;
            this.label12.Text = "说明:\r\n例如 AB***CD***EF**G\r\n必须为15位条码，字母代表必须为相应字符,*号代表字母可以变化";
            // 
            // tBarcodeFormate
            // 
            this.tBarcodeFormate.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBarcodeFormate.Location = new System.Drawing.Point(183, 269);
            this.tBarcodeFormate.Margin = new System.Windows.Forms.Padding(4);
            this.tBarcodeFormate.Name = "tBarcodeFormate";
            this.tBarcodeFormate.Size = new System.Drawing.Size(275, 26);
            this.tBarcodeFormate.TabIndex = 9;
            this.tBarcodeFormate.Text = "***********";
            this.tBarcodeFormate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(101, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "条码格式:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReadCodeBeanCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 394);
            this.Controls.Add(this.bSetBarcodeFormat);
            this.Controls.Add(this.cB_BarcodeFormateEN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tBarcodeFormate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Name = "ReadCodeBeanCtrl";
            this.Text = "读条码方案配置";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gridCam.ResumeLayout(false);
            this.gridCam.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bZJMove;
        private System.Windows.Forms.Button bZJSet;
        private System.Windows.Forms.TextBox tYPos;
        private System.Windows.Forms.TextBox tXPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gridCam;
        private System.Windows.Forms.Button bZJOpenLight;
        private System.Windows.Forms.Button bZJRecordLight;
        private System.Windows.Forms.TextBox tZJExp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBarcontent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_CodeType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tCycle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bZJHandle;
        private System.Windows.Forms.Button bZJReadCode;
        private System.Windows.Forms.Button bZJShowROI;
        private System.Windows.Forms.Button bZJRecordROI;
        private System.Windows.Forms.Button bSetBarcodeFormat;
        private System.Windows.Forms.CheckBox cB_BarcodeFormateEN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBarcodeFormate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

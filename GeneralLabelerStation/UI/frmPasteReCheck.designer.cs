namespace GeneralLabelerStation.UI
{
    partial class frmPasteReCheck
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
            this.dGVMark = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bGoPaste = new System.Windows.Forms.Button();
            this.dGVPaste = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bGoMark2 = new System.Windows.Forms.Button();
            this.bGoMark1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bSet = new System.Windows.Forms.Button();
            this.nShutter = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lCur = new System.Windows.Forms.Label();
            this.cbShowCross = new System.Windows.Forms.CheckBox();
            this.bPrev = new System.Windows.Forms.Button();
            this.bFull = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.bUpGrab = new System.Windows.Forms.Button();
            this.nAngle = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nStandardY = new System.Windows.Forms.NumericUpDown();
            this.nStandardX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bNeedPaste = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.bMultSelect = new System.Windows.Forms.Button();
            this.bSetLike = new System.Windows.Forms.Button();
            this.bUpdateToFlow = new System.Windows.Forms.Button();
            this.bSetToSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tOffsetY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tOffsetX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageSet = new NationalInstruments.Vision.WindowsForms.ImageViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMark)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPaste)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nShutter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAngle)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nStandardY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStandardX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGVMark
            // 
            this.dGVMark.AllowUserToAddRows = false;
            this.dGVMark.AllowUserToDeleteRows = false;
            this.dGVMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dGVMark.Dock = System.Windows.Forms.DockStyle.Left;
            this.dGVMark.Location = new System.Drawing.Point(0, 0);
            this.dGVMark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dGVMark.Name = "dGVMark";
            this.dGVMark.ReadOnly = true;
            this.dGVMark.RowHeadersVisible = false;
            this.dGVMark.RowTemplate.Height = 23;
            this.dGVMark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVMark.Size = new System.Drawing.Size(385, 201);
            this.dGVMark.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "板号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mark1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mark2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(491, 730);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "识别点位";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bGoPaste);
            this.panel2.Controls.Add(this.dGVPaste);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 225);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 500);
            this.panel2.TabIndex = 3;
            // 
            // bGoPaste
            // 
            this.bGoPaste.Dock = System.Windows.Forms.DockStyle.Top;
            this.bGoPaste.Location = new System.Drawing.Point(385, 0);
            this.bGoPaste.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bGoPaste.Name = "bGoPaste";
            this.bGoPaste.Size = new System.Drawing.Size(98, 38);
            this.bGoPaste.TabIndex = 2;
            this.bGoPaste.Text = "到贴附点";
            this.bGoPaste.UseVisualStyleBackColor = true;
            this.bGoPaste.Click += new System.EventHandler(this.bGoPaste_Click);
            // 
            // dGVPaste
            // 
            this.dGVPaste.AllowUserToAddRows = false;
            this.dGVPaste.AllowUserToDeleteRows = false;
            this.dGVPaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPaste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.column10});
            this.dGVPaste.Dock = System.Windows.Forms.DockStyle.Left;
            this.dGVPaste.Location = new System.Drawing.Point(0, 0);
            this.dGVPaste.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dGVPaste.Name = "dGVPaste";
            this.dGVPaste.ReadOnly = true;
            this.dGVPaste.RowHeadersVisible = false;
            this.dGVPaste.RowTemplate.Height = 23;
            this.dGVPaste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVPaste.Size = new System.Drawing.Size(385, 500);
            this.dGVPaste.TabIndex = 1;
            this.dGVPaste.SelectionChanged += new System.EventHandler(this.dGVPaste_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 60F;
            this.dataGridViewTextBoxColumn1.HeaderText = "大板号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 80F;
            this.Column4.HeaderText = "小板号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 35;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 80F;
            this.Column5.HeaderText = "贴附坐标";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 102;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 60F;
            this.Column6.HeaderText = "吸嘴";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 25;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 80F;
            this.Column7.HeaderText = "角度";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 60F;
            this.Column8.HeaderText = "X偏移";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 55;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 60F;
            this.Column9.HeaderText = "Y偏移";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 55;
            // 
            // column10
            // 
            this.column10.HeaderText = "区域";
            this.column10.Name = "column10";
            this.column10.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bGoMark2);
            this.panel1.Controls.Add(this.bGoMark1);
            this.panel1.Controls.Add(this.dGVMark);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 201);
            this.panel1.TabIndex = 2;
            // 
            // bGoMark2
            // 
            this.bGoMark2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bGoMark2.Location = new System.Drawing.Point(385, 38);
            this.bGoMark2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bGoMark2.Name = "bGoMark2";
            this.bGoMark2.Size = new System.Drawing.Size(98, 38);
            this.bGoMark2.TabIndex = 2;
            this.bGoMark2.Text = "到Mark2";
            this.bGoMark2.UseVisualStyleBackColor = true;
            this.bGoMark2.Click += new System.EventHandler(this.bGoMark2_Click);
            // 
            // bGoMark1
            // 
            this.bGoMark1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bGoMark1.Location = new System.Drawing.Point(385, 0);
            this.bGoMark1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bGoMark1.Name = "bGoMark1";
            this.bGoMark1.Size = new System.Drawing.Size(98, 38);
            this.bGoMark1.TabIndex = 1;
            this.bGoMark1.Text = "到Mark1";
            this.bGoMark1.UseVisualStyleBackColor = true;
            this.bGoMark1.Click += new System.EventHandler(this.bGoMark1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bSet);
            this.panel3.Controls.Add(this.nShutter);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lCur);
            this.panel3.Controls.Add(this.cbShowCross);
            this.panel3.Controls.Add(this.bPrev);
            this.panel3.Controls.Add(this.bFull);
            this.panel3.Controls.Add(this.bNext);
            this.panel3.Controls.Add(this.bUpGrab);
            this.panel3.Controls.Add(this.nAngle);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(491, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 87);
            this.panel3.TabIndex = 2;
            // 
            // bSet
            // 
            this.bSet.Location = new System.Drawing.Point(457, 9);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(47, 29);
            this.bSet.TabIndex = 24;
            this.bSet.Text = "设置";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // nShutter
            // 
            this.nShutter.DecimalPlaces = 1;
            this.nShutter.Location = new System.Drawing.Point(378, 10);
            this.nShutter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nShutter.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nShutter.Name = "nShutter";
            this.nShutter.Size = new System.Drawing.Size(73, 26);
            this.nShutter.TabIndex = 23;
            this.nShutter.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(305, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "曝光:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCur
            // 
            this.lCur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lCur.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lCur.Location = new System.Drawing.Point(7, 47);
            this.lCur.Name = "lCur";
            this.lCur.Size = new System.Drawing.Size(265, 25);
            this.lCur.TabIndex = 21;
            this.lCur.Text = "当前第 [1] 板第 [1] 个";
            // 
            // cbShowCross
            // 
            this.cbShowCross.AutoSize = true;
            this.cbShowCross.Location = new System.Drawing.Point(608, 48);
            this.cbShowCross.Name = "cbShowCross";
            this.cbShowCross.Size = new System.Drawing.Size(98, 24);
            this.cbShowCross.TabIndex = 26;
            this.cbShowCross.Text = "显示十字架";
            this.cbShowCross.UseVisualStyleBackColor = true;
            this.cbShowCross.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // bPrev
            // 
            this.bPrev.Location = new System.Drawing.Point(316, 45);
            this.bPrev.Name = "bPrev";
            this.bPrev.Size = new System.Drawing.Size(91, 29);
            this.bPrev.TabIndex = 20;
            this.bPrev.Text = "上一个";
            this.bPrev.UseVisualStyleBackColor = true;
            this.bPrev.Click += new System.EventHandler(this.bPrev_Click);
            // 
            // bFull
            // 
            this.bFull.BackColor = System.Drawing.Color.Yellow;
            this.bFull.Location = new System.Drawing.Point(608, 9);
            this.bFull.Name = "bFull";
            this.bFull.Size = new System.Drawing.Size(95, 29);
            this.bFull.TabIndex = 25;
            this.bFull.Text = "Full";
            this.bFull.UseVisualStyleBackColor = false;
            this.bFull.Click += new System.EventHandler(this.bFull_Click);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(413, 45);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(91, 29);
            this.bNext.TabIndex = 19;
            this.bNext.Text = "下一个";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bUpGrab
            // 
            this.bUpGrab.Location = new System.Drawing.Point(181, 9);
            this.bUpGrab.Name = "bUpGrab";
            this.bUpGrab.Size = new System.Drawing.Size(91, 29);
            this.bUpGrab.TabIndex = 18;
            this.bUpGrab.Text = "上视觉拍照";
            this.bUpGrab.UseVisualStyleBackColor = true;
            this.bUpGrab.Click += new System.EventHandler(this.bUpGrab_Click);
            // 
            // nAngle
            // 
            this.nAngle.DecimalPlaces = 1;
            this.nAngle.Location = new System.Drawing.Point(102, 10);
            this.nAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nAngle.Name = "nAngle";
            this.nAngle.Size = new System.Drawing.Size(73, 26);
            this.nAngle.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "坐标系角度:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.bNeedPaste);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.btnRevoke);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.bMultSelect);
            this.panel4.Controls.Add(this.bSetLike);
            this.panel4.Controls.Add(this.bUpdateToFlow);
            this.panel4.Controls.Add(this.bSetToSelect);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1217, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(133, 643);
            this.panel4.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nStandardY);
            this.groupBox3.Controls.Add(this.nStandardX);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 91);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "标准距离";
            // 
            // nStandardY
            // 
            this.nStandardY.DecimalPlaces = 2;
            this.nStandardY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nStandardY.Location = new System.Drawing.Point(38, 58);
            this.nStandardY.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nStandardY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nStandardY.Name = "nStandardY";
            this.nStandardY.Size = new System.Drawing.Size(70, 26);
            this.nStandardY.TabIndex = 10;
            // 
            // nStandardX
            // 
            this.nStandardX.DecimalPlaces = 2;
            this.nStandardX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nStandardX.Location = new System.Drawing.Point(38, 26);
            this.nStandardX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nStandardX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nStandardX.Name = "nStandardX";
            this.nStandardX.Size = new System.Drawing.Size(70, 26);
            this.nStandardX.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "X:";
            // 
            // bNeedPaste
            // 
            this.bNeedPaste.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bNeedPaste.Location = new System.Drawing.Point(15, 43);
            this.bNeedPaste.Name = "bNeedPaste";
            this.bNeedPaste.Size = new System.Drawing.Size(102, 35);
            this.bNeedPaste.TabIndex = 24;
            this.bNeedPaste.Text = "拾取贴附位置";
            this.bNeedPaste.UseVisualStyleBackColor = false;
            this.bNeedPaste.Click += new System.EventHandler(this.bNeedPaste_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(15, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 32);
            this.button3.TabIndex = 23;
            this.button3.Text = "拾取基准";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.bGetPaste_Click);
            // 
            // btnRevoke
            // 
            this.btnRevoke.Location = new System.Drawing.Point(6, 538);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(87, 30);
            this.btnRevoke.TabIndex = 22;
            this.btnRevoke.Text = "撤销";
            this.btnRevoke.UseVisualStyleBackColor = true;
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 643);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // bMultSelect
            // 
            this.bMultSelect.BackColor = System.Drawing.Color.Red;
            this.bMultSelect.Location = new System.Drawing.Point(4, 371);
            this.bMultSelect.Name = "bMultSelect";
            this.bMultSelect.Size = new System.Drawing.Size(126, 50);
            this.bMultSelect.TabIndex = 20;
            this.bMultSelect.Text = "应用到多选";
            this.bMultSelect.UseVisualStyleBackColor = false;
            this.bMultSelect.Click += new System.EventHandler(this.bSetToMultSelect);
            // 
            // bSetLike
            // 
            this.bSetLike.BackColor = System.Drawing.Color.Red;
            this.bSetLike.Location = new System.Drawing.Point(3, 297);
            this.bSetLike.Name = "bSetLike";
            this.bSetLike.Size = new System.Drawing.Size(127, 73);
            this.bSetLike.TabIndex = 18;
            this.bSetLike.Text = "应用到同一种类(吸嘴和角度相同的)";
            this.bSetLike.UseVisualStyleBackColor = false;
            this.bSetLike.Click += new System.EventHandler(this.bSetLike_Click);
            // 
            // bUpdateToFlow
            // 
            this.bUpdateToFlow.BackColor = System.Drawing.Color.Yellow;
            this.bUpdateToFlow.Location = new System.Drawing.Point(4, 573);
            this.bUpdateToFlow.Name = "bUpdateToFlow";
            this.bUpdateToFlow.Size = new System.Drawing.Size(126, 46);
            this.bUpdateToFlow.TabIndex = 16;
            this.bUpdateToFlow.Text = "更新到程式";
            this.bUpdateToFlow.UseVisualStyleBackColor = false;
            this.bUpdateToFlow.Click += new System.EventHandler(this.bUpdateToFlow_Click);
            // 
            // bSetToSelect
            // 
            this.bSetToSelect.BackColor = System.Drawing.Color.Red;
            this.bSetToSelect.Location = new System.Drawing.Point(4, 425);
            this.bSetToSelect.Name = "bSetToSelect";
            this.bSetToSelect.Size = new System.Drawing.Size(126, 50);
            this.bSetToSelect.TabIndex = 13;
            this.bSetToSelect.Text = "应用到当前贴附位";
            this.bSetToSelect.UseVisualStyleBackColor = false;
            this.bSetToSelect.Click += new System.EventHandler(this.bSetToSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tOffsetY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tOffsetX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(2, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "误差";
            // 
            // tOffsetY
            // 
            this.tOffsetY.Location = new System.Drawing.Point(38, 58);
            this.tOffsetY.Name = "tOffsetY";
            this.tOffsetY.ReadOnly = true;
            this.tOffsetY.Size = new System.Drawing.Size(68, 26);
            this.tOffsetY.TabIndex = 9;
            this.tOffsetY.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y:";
            // 
            // tOffsetX
            // 
            this.tOffsetX.Location = new System.Drawing.Point(38, 25);
            this.tOffsetX.Name = "tOffsetX";
            this.tOffsetX.ReadOnly = true;
            this.tOffsetX.Size = new System.Drawing.Size(68, 26);
            this.tOffsetX.TabIndex = 7;
            this.tOffsetX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "X:";
            // 
            // imageSet
            // 
            this.imageSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSet.Location = new System.Drawing.Point(491, 87);
            this.imageSet.Margin = new System.Windows.Forms.Padding(0);
            this.imageSet.Name = "imageSet";
            this.imageSet.ShowImageInfo = true;
            this.imageSet.ShowToolbar = true;
            this.imageSet.Size = new System.Drawing.Size(726, 643);
            this.imageSet.TabIndex = 295;
            this.imageSet.ZoomToFit = true;
            this.imageSet.ImageMouseDown += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs>(this.imageSet_ImageMouseDown);
            this.imageSet.ImageMouseMove += new System.EventHandler<NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs>(this.imageSet_ImageMouseMove);
            this.imageSet.Resize += new System.EventHandler(this.imageSet_Resize);
            // 
            // frmPasteReCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.imageSet);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPasteReCheck";
            this.Text = "回看";
            this.Load += new System.EventHandler(this.frmPasteReCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVMark)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVPaste)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nShutter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAngle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nStandardY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStandardX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bGoPaste;
        private System.Windows.Forms.DataGridView dGVPaste;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bGoMark2;
        private System.Windows.Forms.Button bGoMark1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tOffsetY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tOffsetX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSetToSelect;
        public NationalInstruments.Vision.WindowsForms.ImageViewer imageSet;
        private System.Windows.Forms.Button bUpdateToFlow;
        private System.Windows.Forms.Button bSetLike;
        private System.Windows.Forms.Button bMultSelect;
        private System.Windows.Forms.Button btnRevoke;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.NumericUpDown nShutter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lCur;
        private System.Windows.Forms.CheckBox cbShowCross;
        private System.Windows.Forms.Button bPrev;
        private System.Windows.Forms.Button bFull;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bUpGrab;
        private System.Windows.Forms.NumericUpDown nAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nStandardY;
        private System.Windows.Forms.NumericUpDown nStandardX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bNeedPaste;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn column10;
    }
}
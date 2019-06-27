namespace GeneralLabelerStation.UI
{
    partial class frmPressEdit
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
            this.bConnect = new System.Windows.Forms.Button();
            this.bReadTest = new System.Windows.Forms.Button();
            this.bClearAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lZ4 = new System.Windows.Forms.Label();
            this.lZ3 = new System.Windows.Forms.Label();
            this.lZ2 = new System.Windows.Forms.Label();
            this.lZ1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.numAlarmCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numAlarmRow = new System.Windows.Forms.NumericUpDown();
            this.tAlarmG = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numZ4Channel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numZ3Channel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numZ2Channel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numZ1Channel = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listPress = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bAutoCalib = new System.Windows.Forms.Button();
            this.tPastePress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSelectNz = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmRow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ4Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ3Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ2Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ1Channel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.bConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConnect.Location = new System.Drawing.Point(0, 94);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(153, 47);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "链接";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bReadTest
            // 
            this.bReadTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.bReadTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReadTest.Location = new System.Drawing.Point(0, 47);
            this.bReadTest.Name = "bReadTest";
            this.bReadTest.Size = new System.Drawing.Size(153, 47);
            this.bReadTest.TabIndex = 1;
            this.bReadTest.Text = "读取测试";
            this.bReadTest.UseVisualStyleBackColor = true;
            this.bReadTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // bClearAll
            // 
            this.bClearAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.bClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClearAll.Location = new System.Drawing.Point(0, 0);
            this.bClearAll.Name = "bClearAll";
            this.bClearAll.Size = new System.Drawing.Size(153, 47);
            this.bClearAll.TabIndex = 2;
            this.bClearAll.Text = "全面请零";
            this.bClearAll.UseVisualStyleBackColor = true;
            this.bClearAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lZ4);
            this.panel1.Controls.Add(this.lZ3);
            this.panel1.Controls.Add(this.lZ2);
            this.panel1.Controls.Add(this.lZ1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 62);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(400, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 62);
            this.label5.TabIndex = 4;
            this.label5.Text = "实时压力值";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lZ4
            // 
            this.lZ4.BackColor = System.Drawing.Color.LightGreen;
            this.lZ4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lZ4.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lZ4.Location = new System.Drawing.Point(300, 0);
            this.lZ4.Name = "lZ4";
            this.lZ4.Size = new System.Drawing.Size(100, 62);
            this.lZ4.TabIndex = 3;
            this.lZ4.Text = "Z4:0";
            this.lZ4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lZ3
            // 
            this.lZ3.BackColor = System.Drawing.Color.LightGreen;
            this.lZ3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lZ3.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lZ3.Location = new System.Drawing.Point(200, 0);
            this.lZ3.Name = "lZ3";
            this.lZ3.Size = new System.Drawing.Size(100, 62);
            this.lZ3.TabIndex = 2;
            this.lZ3.Text = "Z3:0";
            this.lZ3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lZ2
            // 
            this.lZ2.BackColor = System.Drawing.Color.LightGreen;
            this.lZ2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lZ2.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lZ2.Location = new System.Drawing.Point(100, 0);
            this.lZ2.Name = "lZ2";
            this.lZ2.Size = new System.Drawing.Size(100, 62);
            this.lZ2.TabIndex = 1;
            this.lZ2.Text = "Z2:0";
            this.lZ2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lZ1
            // 
            this.lZ1.BackColor = System.Drawing.Color.LightGreen;
            this.lZ1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lZ1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lZ1.Location = new System.Drawing.Point(0, 0);
            this.lZ1.Name = "lZ1";
            this.lZ1.Size = new System.Drawing.Size(100, 62);
            this.lZ1.TabIndex = 0;
            this.lZ1.Text = "Z1:0";
            this.lZ1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.bConnect);
            this.panel2.Controls.Add(this.bReadTest);
            this.panel2.Controls.Add(this.bClearAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 546);
            this.panel2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 47);
            this.button3.TabIndex = 6;
            this.button3.Text = "断开链接";
            this.button3.UseVisualStyleBackColor = true;
            //this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "更新设置";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "最大压力清零";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(159, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报警设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numAlarmCount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numAlarmRow, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tAlarmG, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 42);
            this.label9.TabIndex = 5;
            this.label9.Text = "报警克数";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numAlarmCount
            // 
            this.numAlarmCount.Location = new System.Drawing.Point(120, 50);
            this.numAlarmCount.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numAlarmCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAlarmCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAlarmCount.Name = "numAlarmCount";
            this.numAlarmCount.Size = new System.Drawing.Size(112, 26);
            this.numAlarmCount.TabIndex = 4;
            this.numAlarmCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "累计报警";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "报警显示行数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numAlarmRow
            // 
            this.numAlarmRow.Location = new System.Drawing.Point(120, 10);
            this.numAlarmRow.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numAlarmRow.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAlarmRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAlarmRow.Name = "numAlarmRow";
            this.numAlarmRow.Size = new System.Drawing.Size(112, 26);
            this.numAlarmRow.TabIndex = 3;
            this.numAlarmRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tAlarmG
            // 
            this.tAlarmG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tAlarmG.Location = new System.Drawing.Point(120, 90);
            this.tAlarmG.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tAlarmG.Name = "tAlarmG";
            this.tAlarmG.Size = new System.Drawing.Size(112, 26);
            this.tAlarmG.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(159, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 210);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通道设置设置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.numZ4Channel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.numZ3Channel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.numZ2Channel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numZ1Channel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 185);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numZ4Channel
            // 
            this.numZ4Channel.Location = new System.Drawing.Point(117, 148);
            this.numZ4Channel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numZ4Channel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numZ4Channel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZ4Channel.Name = "numZ4Channel";
            this.numZ4Channel.Size = new System.Drawing.Size(109, 26);
            this.numZ4Channel.TabIndex = 7;
            this.numZ4Channel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 47);
            this.label8.TabIndex = 6;
            this.label8.Text = "Z4通道";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numZ3Channel
            // 
            this.numZ3Channel.Location = new System.Drawing.Point(117, 102);
            this.numZ3Channel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numZ3Channel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numZ3Channel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZ3Channel.Name = "numZ3Channel";
            this.numZ3Channel.Size = new System.Drawing.Size(109, 26);
            this.numZ3Channel.TabIndex = 5;
            this.numZ3Channel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 46);
            this.label7.TabIndex = 4;
            this.label7.Text = "Z3通道";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numZ2Channel
            // 
            this.numZ2Channel.Location = new System.Drawing.Point(117, 56);
            this.numZ2Channel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numZ2Channel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numZ2Channel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZ2Channel.Name = "numZ2Channel";
            this.numZ2Channel.Size = new System.Drawing.Size(109, 26);
            this.numZ2Channel.TabIndex = 3;
            this.numZ2Channel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 46);
            this.label4.TabIndex = 2;
            this.label4.Text = "Z2通道";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Z1通道";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numZ1Channel
            // 
            this.numZ1Channel.Location = new System.Drawing.Point(117, 10);
            this.numZ1Channel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.numZ1Channel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numZ1Channel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZ1Channel.Name = "numZ1Channel";
            this.numZ1Channel.Size = new System.Drawing.Size(109, 26);
            this.numZ1Channel.TabIndex = 1;
            this.numZ1Channel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listPress);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(397, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 493);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "贴附压力矫正";
            // 
            // listPress
            // 
            this.listPress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPress.FormattingEnabled = true;
            this.listPress.ItemHeight = 20;
            this.listPress.Location = new System.Drawing.Point(3, 67);
            this.listPress.Name = "listPress";
            this.listPress.Size = new System.Drawing.Size(336, 423);
            this.listPress.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bAutoCalib);
            this.panel3.Controls.Add(this.tPastePress);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 45);
            this.panel3.TabIndex = 0;
            // 
            // bAutoCalib
            // 
            this.bAutoCalib.Location = new System.Drawing.Point(242, 7);
            this.bAutoCalib.Name = "bAutoCalib";
            this.bAutoCalib.Size = new System.Drawing.Size(79, 32);
            this.bAutoCalib.TabIndex = 2;
            this.bAutoCalib.Text = "自动测量";
            this.bAutoCalib.UseVisualStyleBackColor = true;
            this.bAutoCalib.Click += new System.EventHandler(this.bAutoCalib_Click);
            // 
            // tPastePress
            // 
            this.tPastePress.Location = new System.Drawing.Point(109, 10);
            this.tPastePress.Name = "tPastePress";
            this.tPastePress.ReadOnly = true;
            this.tPastePress.Size = new System.Drawing.Size(119, 26);
            this.tPastePress.TabIndex = 1;
            this.tPastePress.Text = "0";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 45);
            this.label10.TabIndex = 0;
            this.label10.Text = "贴附固有压力:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(429, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "选择吸嘴:";
            // 
            // cbSelectNz
            // 
            this.cbSelectNz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectNz.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSelectNz.FormattingEnabled = true;
            this.cbSelectNz.Items.AddRange(new object[] {
            "Z1",
            "Z2",
            "Z3",
            "Z4"});
            this.cbSelectNz.Location = new System.Drawing.Point(540, 77);
            this.cbSelectNz.Name = "cbSelectNz";
            this.cbSelectNz.Size = new System.Drawing.Size(121, 29);
            this.cbSelectNz.TabIndex = 10;
            this.cbSelectNz.SelectedIndexChanged += new System.EventHandler(this.cbSelectNz_SelectedIndexChanged);
            // 
            // frmPressEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 608);
            this.Controls.Add(this.cbSelectNz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPressEdit";
            this.Text = "压力调整";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPressEdit_FormClosed);
            this.Load += new System.EventHandler(this.frmPressEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmRow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numZ4Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ3Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ2Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ1Channel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bReadTest;
        private System.Windows.Forms.Button bClearAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lZ4;
        private System.Windows.Forms.Label lZ3;
        private System.Windows.Forms.Label lZ2;
        private System.Windows.Forms.Label lZ1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAlarmCount;
        private System.Windows.Forms.NumericUpDown numAlarmRow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numZ1Channel;
        private System.Windows.Forms.NumericUpDown numZ4Channel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numZ3Channel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numZ2Channel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tAlarmG;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSelectNz;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bAutoCalib;
        private System.Windows.Forms.TextBox tPastePress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listPress;
    }
}
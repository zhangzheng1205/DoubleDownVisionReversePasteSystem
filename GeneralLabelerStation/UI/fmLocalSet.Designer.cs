namespace GeneralLabelerStation.UI
{
    partial class fmLocalSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBaseAngle = new System.Windows.Forms.TextBox();
            this.dGV_Global = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bRecrodCamXY = new System.Windows.Forms.Button();
            this.bRecrodLight = new System.Windows.Forms.Button();
            this.bRecrodExp = new System.Windows.Forms.Button();
            this.bMoveCamPos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bFindCircle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tMaxR = new System.Windows.Forms.TextBox();
            this.tMinR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bUpdate = new System.Windows.Forms.Button();
            this.tGain = new System.Windows.Forms.TextBox();
            this.tOffset = new System.Windows.Forms.TextBox();
            this.bHandle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Global)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 236);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "基板角度:";
            // 
            // tBaseAngle
            // 
            this.tBaseAngle.Location = new System.Drawing.Point(468, 233);
            this.tBaseAngle.Name = "tBaseAngle";
            this.tBaseAngle.Size = new System.Drawing.Size(100, 27);
            this.tBaseAngle.TabIndex = 3;
            // 
            // dGV_Global
            // 
            this.dGV_Global.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Global.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dGV_Global.Location = new System.Drawing.Point(4, 8);
            this.dGV_Global.Name = "dGV_Global";
            this.dGV_Global.ReadOnly = true;
            this.dGV_Global.RowTemplate.Height = 23;
            this.dGV_Global.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Global.Size = new System.Drawing.Size(872, 150);
            this.dGV_Global.TabIndex = 4;
            this.dGV_Global.SelectionChanged += new System.EventHandler(this.dGV_Global_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mark";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "MarkX";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "MarkY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Gian";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Offset";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "打光";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "曝光";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Roi";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "最小圆半径";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "最大圆半径";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // bRecrodCamXY
            // 
            this.bRecrodCamXY.BackColor = System.Drawing.Color.Lime;
            this.bRecrodCamXY.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRecrodCamXY.Location = new System.Drawing.Point(4, 164);
            this.bRecrodCamXY.Name = "bRecrodCamXY";
            this.bRecrodCamXY.Size = new System.Drawing.Size(73, 36);
            this.bRecrodCamXY.TabIndex = 5;
            this.bRecrodCamXY.Text = "拍照位";
            this.bRecrodCamXY.UseVisualStyleBackColor = false;
            this.bRecrodCamXY.Click += new System.EventHandler(this.bRecrodCamXY_Click);
            // 
            // bRecrodLight
            // 
            this.bRecrodLight.BackColor = System.Drawing.Color.Lime;
            this.bRecrodLight.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRecrodLight.Location = new System.Drawing.Point(79, 164);
            this.bRecrodLight.Name = "bRecrodLight";
            this.bRecrodLight.Size = new System.Drawing.Size(73, 36);
            this.bRecrodLight.TabIndex = 6;
            this.bRecrodLight.Text = "打光";
            this.bRecrodLight.UseVisualStyleBackColor = false;
            this.bRecrodLight.Click += new System.EventHandler(this.bRecrodLight_Click);
            // 
            // bRecrodExp
            // 
            this.bRecrodExp.BackColor = System.Drawing.Color.Lime;
            this.bRecrodExp.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRecrodExp.Location = new System.Drawing.Point(153, 164);
            this.bRecrodExp.Name = "bRecrodExp";
            this.bRecrodExp.Size = new System.Drawing.Size(73, 36);
            this.bRecrodExp.TabIndex = 7;
            this.bRecrodExp.Text = "曝光";
            this.bRecrodExp.UseVisualStyleBackColor = false;
            this.bRecrodExp.Click += new System.EventHandler(this.bRecrodExp_Click);
            // 
            // bMoveCamPos
            // 
            this.bMoveCamPos.BackColor = System.Drawing.Color.White;
            this.bMoveCamPos.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bMoveCamPos.Location = new System.Drawing.Point(228, 164);
            this.bMoveCamPos.Name = "bMoveCamPos";
            this.bMoveCamPos.Size = new System.Drawing.Size(73, 36);
            this.bMoveCamPos.TabIndex = 8;
            this.bMoveCamPos.Text = "到拍照位";
            this.bMoveCamPos.UseVisualStyleBackColor = false;
            this.bMoveCamPos.Click += new System.EventHandler(this.bMoveCamPos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Offset:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bFindCircle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tMaxR);
            this.groupBox1.Controls.Add(this.tMinR);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(4, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "侦测圆";
            // 
            // bFindCircle
            // 
            this.bFindCircle.BackColor = System.Drawing.Color.Lime;
            this.bFindCircle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bFindCircle.Location = new System.Drawing.Point(240, 22);
            this.bFindCircle.Name = "bFindCircle";
            this.bFindCircle.Size = new System.Drawing.Size(68, 31);
            this.bFindCircle.TabIndex = 6;
            this.bFindCircle.Text = "侦测";
            this.bFindCircle.UseVisualStyleBackColor = false;
            this.bFindCircle.Click += new System.EventHandler(this.bFindCircle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "-";
            // 
            // tMaxR
            // 
            this.tMaxR.Location = new System.Drawing.Point(167, 24);
            this.tMaxR.Name = "tMaxR";
            this.tMaxR.Size = new System.Drawing.Size(57, 27);
            this.tMaxR.TabIndex = 2;
            this.tMaxR.Text = "500";
            // 
            // tMinR
            // 
            this.tMinR.Location = new System.Drawing.Point(75, 24);
            this.tMinR.Name = "tMinR";
            this.tMinR.Size = new System.Drawing.Size(57, 27);
            this.tMinR.TabIndex = 1;
            this.tMinR.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "半径:";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.Yellow;
            this.bUpdate.Location = new System.Drawing.Point(605, 224);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(211, 44);
            this.bUpdate.TabIndex = 12;
            this.bUpdate.Text = "更新Global参数";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // tGain
            // 
            this.tGain.Location = new System.Drawing.Point(406, 173);
            this.tGain.Name = "tGain";
            this.tGain.Size = new System.Drawing.Size(54, 27);
            this.tGain.TabIndex = 13;
            // 
            // tOffset
            // 
            this.tOffset.Location = new System.Drawing.Point(543, 174);
            this.tOffset.Name = "tOffset";
            this.tOffset.Size = new System.Drawing.Size(54, 27);
            this.tOffset.TabIndex = 14;
            // 
            // bHandle
            // 
            this.bHandle.BackColor = System.Drawing.Color.Lime;
            this.bHandle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bHandle.Location = new System.Drawing.Point(605, 171);
            this.bHandle.Name = "bHandle";
            this.bHandle.Size = new System.Drawing.Size(68, 31);
            this.bHandle.TabIndex = 15;
            this.bHandle.Text = "处理";
            this.bHandle.UseVisualStyleBackColor = false;
            this.bHandle.Click += new System.EventHandler(this.bHandle_Click);
            // 
            // fmLocalSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 290);
            this.Controls.Add(this.bHandle);
            this.Controls.Add(this.tOffset);
            this.Controls.Add(this.tGain);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bMoveCamPos);
            this.Controls.Add(this.bRecrodExp);
            this.Controls.Add(this.bRecrodLight);
            this.Controls.Add(this.bRecrodCamXY);
            this.Controls.Add(this.dGV_Global);
            this.Controls.Add(this.tBaseAngle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmLocalSet";
            this.Text = "Global+BadMark定位方式";
            this.Load += new System.EventHandler(this.fmLocalSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Global)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBaseAngle;
        private System.Windows.Forms.DataGridView dGV_Global;
        private System.Windows.Forms.Button bRecrodCamXY;
        private System.Windows.Forms.Button bRecrodLight;
        private System.Windows.Forms.Button bRecrodExp;
        private System.Windows.Forms.Button bMoveCamPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bFindCircle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tMaxR;
        private System.Windows.Forms.TextBox tMinR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox tGain;
        private System.Windows.Forms.TextBox tOffset;
        private System.Windows.Forms.Button bHandle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}
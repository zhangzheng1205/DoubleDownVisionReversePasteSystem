namespace GeneralLabelerStation.Install
{
    partial class Install
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install));
            this.btnSecondMachine = new System.Windows.Forms.Button();
            this.btnThirdMachine = new System.Windows.Forms.Button();
            this.btnLH = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSecondMachine
            // 
            this.btnSecondMachine.Location = new System.Drawing.Point(102, 78);
            this.btnSecondMachine.Name = "btnSecondMachine";
            this.btnSecondMachine.Size = new System.Drawing.Size(75, 23);
            this.btnSecondMachine.TabIndex = 0;
            this.btnSecondMachine.Text = "二代机";
            this.btnSecondMachine.UseVisualStyleBackColor = true;
            this.btnSecondMachine.Click += new System.EventHandler(this.btnSecondMachine_Click);
            // 
            // btnThirdMachine
            // 
            this.btnThirdMachine.Location = new System.Drawing.Point(261, 78);
            this.btnThirdMachine.Name = "btnThirdMachine";
            this.btnThirdMachine.Size = new System.Drawing.Size(75, 23);
            this.btnThirdMachine.TabIndex = 1;
            this.btnThirdMachine.Text = "三代机";
            this.btnThirdMachine.UseVisualStyleBackColor = true;
            this.btnThirdMachine.Click += new System.EventHandler(this.btnThirdMachine_Click);
            // 
            // btnLH
            // 
            this.btnLH.Location = new System.Drawing.Point(261, 129);
            this.btnLH.Name = "btnLH";
            this.btnLH.Size = new System.Drawing.Size(87, 23);
            this.btnLH.TabIndex = 3;
            this.btnLH.Text = "力恒压力传感器";
            this.btnLH.UseVisualStyleBackColor = true;
            this.btnLH.Click += new System.EventHandler(this.btnLH_Click);
            // 
            // btnBD
            // 
            this.btnBD.Location = new System.Drawing.Point(102, 129);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(87, 23);
            this.btnBD.TabIndex = 2;
            this.btnBD.Text = "比淂压力传感器";
            this.btnBD.UseVisualStyleBackColor = true;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 263);
            this.Controls.Add(this.btnLH);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.btnThirdMachine);
            this.Controls.Add(this.btnSecondMachine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Install";
            this.Text = "二代机和三代机配置工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSecondMachine;
        private System.Windows.Forms.Button btnThirdMachine;
        private System.Windows.Forms.Button btnLH;
        private System.Windows.Forms.Button btnBD;
    }
}


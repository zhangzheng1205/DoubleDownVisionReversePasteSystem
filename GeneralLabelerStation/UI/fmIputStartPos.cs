using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmIputStartPos : Form
    {
        public fmIputStartPos()
        {
            InitializeComponent();
        }

        public fmIputStartPos(ref Variable.JOB job)
        {
            InitializeComponent();
            JOB = job;
        }

        public Variable.JOB JOB = new Variable.JOB();
        public int StartPanel = 0;
        public int StartPaste = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.StartPanel = int.Parse(this.textBox1.Text) - 1;
                this.StartPaste = int.Parse(this.textBox2.Text)- 1;
                if (StartPanel >= JOB.PasteCount || this.StartPanel < 0)
                {
                    throw new Exception();
                }

                if (StartPaste >= JOB.PASTEInfo[this.StartPanel].iPasteED.Length || this.StartPaste < 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show("设置 参数 出错 请重新输入!!!");
                return;
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

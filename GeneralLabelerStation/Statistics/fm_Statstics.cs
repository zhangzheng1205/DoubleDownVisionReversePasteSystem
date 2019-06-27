using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.Statistics
{
    public partial class fm_Statstics : Form
    {
        public fm_Statstics()
        {
            InitializeComponent();
            this.dateTimePicker1.MinDate = new DateTime(2018, 10, 1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            report = StatisticsHelper.Instance.GetData(this.dateTimePicker1.Value, (int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value, this.treeView1, this.zedGraphControl1, this.dataGridView1);
        }

        private void fm_Statstics_Load(object sender, EventArgs e)
        {
            report = StatisticsHelper.Instance.GetData(this.dateTimePicker1.Value, (int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value, this.treeView1, this.zedGraphControl1, this.dataGridView1);
        }

        private DayReprot report = null;
        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            report = StatisticsHelper.Instance.GetData(this.dateTimePicker1.Value, (int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value, this.treeView1, this.zedGraphControl1, this.dataGridView1);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (this.numericUpDown2.Value <= this.numericUpDown1.Value)
            {
                this.numericUpDown2.Value = this.numericUpDown2.Minimum = this.numericUpDown1.Value + 1;
            }
        }

        private void bOutput_Click(object sender, EventArgs e)
        {
            if(report != null)
            {
                //this.report.Times[TimeDefine.DTTime].Name
            }
        }
    }
}

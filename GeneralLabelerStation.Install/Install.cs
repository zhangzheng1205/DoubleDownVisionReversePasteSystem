using GeneralLabelerStation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.Install
{
    public partial class Install : Form
    {
        public Install()
        {
            InitializeComponent();
        }
        public static string sPath_Configure = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\";
        IniFile ini = new IniFile(sPath_Configure + "System.ini");
        private void btnSecondMachine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定设备是二代机吗?", "重要提示", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            ini.IniWriteNumber("MachineType", "MachineVersion", 2);
            this.btnSecondMachine.BackColor = Color.YellowGreen;
        }

        private void btnThirdMachine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定设备是三代机吗?", "重要提示", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            ini.IniWriteNumber("MachineType", "MachineVersion", 3);
            this.btnThirdMachine.BackColor = Color.YellowGreen;
        }
    }
}

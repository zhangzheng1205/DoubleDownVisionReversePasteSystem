using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

namespace GeneralLabelerStation.Tool
{
    public partial class ReadCodeBeanCtrl : Form
    {
        public ReadCodeBeanCtrl()
        {
            InitializeComponent();
        }

        public ReadCodeBean Bean = new ReadCodeBean();

        public void ShowBean()
        {
            this.tXPos.Text = Bean.BarcodePos.X.ToString("f3");
            this.tYPos.Text = Bean.BarcodePos.Y.ToString("f3");
            this.tZJExp.Text = Bean.Shutter.ToString();
            this.tGain.Text = Bean.Gain.ToString();
            this.tOffset.Text = Bean.Offset.ToString();
            this.tCycle.Text = Bean.Cycle.ToString();
            this.cb_CodeType.SelectedIndex = (int)Bean.CodeType;
        }
        private void bLoad_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = Variable.sPath_ReadCodeBean;
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var name = this.openFileDialog1.FileName.Replace(".json", "").Replace(Variable.sPath_ReadCodeBean, "");
                this.Bean = ReadCodeBean.Load(name);
                this.ShowBean();
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("请输入 新建程式名称", "提示", "Code", -1, -1);
            if(string.IsNullOrEmpty(s))
            {
                MessageBox.Show("输入错误请正确输入");
                return;
            }

            
            if (File.Exists(Variable.sPath_ReadCodeBean+s+".json"))
            {
                MessageBox.Show("新建的读条码方案已经存在!!");
                return;
            }
            else
            {
                this.Bean = new ReadCodeBean();
                this.Bean.BeanName = s;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            this.Bean.Shutter = int.Parse(this.tZJExp.Text);
            this.Bean.BarcodeFormateEN = this.cB_BarcodeFormateEN.Checked;
            ReadCodeBean.Save(this.Bean);
        }

        private void bZJRecordLight_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.UpdateLightPlan();
            this.Bean.Light = string.Empty;
            this.Bean.Light += Form_Main.VariableSys.bRedU == true ? "1" : "0";
            this.Bean.Light += ",";

            this.Bean.Light += Form_Main.VariableSys.bGreenU == true ? "1" : "0";
            this.Bean.Light += ",";

            this.Bean.Light += Form_Main.VariableSys.bBlueU == true ? "1" : "0";
            this.Bean.Light += ",";

            this.Bean.Light += Form_Main.VariableSys.dRedValue_U.ToString();
            this.Bean.Light += ",";

            this.Bean.Light += Form_Main.VariableSys.dGreenValue_U.ToString();
            this.Bean.Light += ",";

            this.Bean.Light += Form_Main.VariableSys.dBlueValue_U.ToString();
        }

        private void bZJOpenLight_Click(object sender, EventArgs e)
        {
            this.Bean.OpenLight();
        }

        private void bZJSet_Click(object sender, EventArgs e)
        {
            this.Bean.BarcodePos = new PointF((float)Form_Main.Instance.X.Pos,(float)Form_Main.Instance.Y.Pos);

            this.tXPos.Text = Form_Main.Instance.X.Pos.ToString("f3");
            this.tYPos.Text = Form_Main.Instance.Y.Pos.ToString("f3");
        }

        private void bZJMove_Click(object sender, EventArgs e)
        {
            try
            {
                PointF pt = new PointF();
                pt.X = float.Parse(this.tXPos.Text);
                pt.Y = float.Parse(this.tYPos.Text);
                Form_Main.Instance.XYGoPos(pt, Form_Main.VariableSys.VelMode_Debug);
            }
            catch { }
        }

        private void bZJHandle_Click(object sender, EventArgs e)
        {
            try
            {
                this.Bean.Gain = double.Parse(this.tGain.Text);
                this.Bean.Offset = double.Parse(this.tOffset.Text);
                this.Bean.Cycle = int.Parse(this.tCycle.Text);

                VisionImage image = Form_Main.Instance.imageSet.Image;
                for (int i = 0; i < this.Bean.Cycle; ++i)
                {
                    image = Form_Main.Instance.GainOffset(Form_Main.Instance.imageSet.Image, this.Bean.Gain, this.Bean.Offset);
                }

                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bZJRecordROI_Click(object sender, EventArgs e)
        {
            try
            {
                this.Bean.ROI = Form_Main.Instance.imageSet.Roi.GetBoundingRectangle();
            }
            catch { }
        }

        private void bZJShowROI_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.imageSet.Roi.Add(this.Bean.ROI);
        }

        private void bZJReadCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Bean.CodeType = (CodeType)this.cb_CodeType.SelectedIndex;
                //MessageBox.Show(ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, type));
                this.lblBarcontent.Text = ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, this.Bean.CodeType);
            }
            catch {
                MessageBox.Show("读取失败");
            }
        }

        private void bSetBarcodeFormat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lblBarcontent.Text.Length; i++)
            {
                tBarcodeFormate.Text += "*";
            }

            this.Bean.BarcodeFormate = this.tBarcodeFormate.Text;
        }
    }
}

using GeneralLabelerStation.Tools;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralLabelerStation;

namespace GeneralLabelerStation
{
    public partial class Form_ZDTMES : Form
    {
        public Form_ZDTMES()
        {
            InitializeComponent();
        }

        private void bTestLink_Click(object sender, EventArgs e)
        {
            try
            {
                ZDT.Service1SoapClient client = new ZDT.Service1SoapClient();
                string result = client.ReturnSPIBarmark(this.tLinkCode.Text, this.cbSide.SelectedIndex == 0 ? "A" : "B");
                if (result == "NULL")
                {
                    MessageBox.Show("连接失败，请检查网络并确保 板子已过SPI：" + result);
                }
                else
                {
                    MessageBox.Show("连接成功：" + result);
                }
            }
            catch (Exception ex) { MessageBox.Show("连接失败：" + ex.Message); }
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            this.tXPos.Text = Form_Main.Instance.X.Pos.ToString("f3");
            this.tYPos.Text = Form_Main.Instance.Y.Pos.ToString("f3");
        }

        private void bMove_Click(object sender, EventArgs e)
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
        private string Light = string.Empty;
        private void bRecordLight_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.UpdateLightPlan();
            Light = string.Empty;
            Light += Form_Main.VariableSys.bRedU == true ? "1" : "0";
            Light += ",";

            Light += Form_Main.VariableSys.bGreenU == true ? "1" : "0";
            Light += ",";

            Light += Form_Main.VariableSys.bBlueU == true ? "1" : "0";
            Light += ",";

            Light += Form_Main.VariableSys.dRedValue_U.ToString();
            Light += ",";

            Light += Form_Main.VariableSys.dGreenValue_U.ToString();
            Light += ",";

            Light += Form_Main.VariableSys.dBlueValue_U.ToString();
        }

        private void bOpenLight_Click(object sender, EventArgs e)
        {
            try
            {
                var arr = this.Light.Split(',');
                if (arr.Length == 6)
                {
                    bool a1 = arr[0] == "1";
                    bool a2 = arr[1] == "1";
                    bool a3 = arr[2] == "1";
                    double a4 = double.Parse(arr[3]);
                    double a5 = double.Parse(arr[4]);
                    double a6 = double.Parse(arr[5]);
                    Form_Main.Instance.LightON_Up(a1, a2, a3, a4, a5, a6);
                }
            }
            catch { }
        }
        private RectangleContour rect = new RectangleContour(0, 0, 0, 0);
        private void bRecordROI_Click(object sender, EventArgs e)
        {
            try
            {
                rect = Form_Main.Instance.imageSet.Roi.GetBoundingRectangle();
            }
            catch { }
        }

        private void bHandle_Click(object sender, EventArgs e)
        {
            try
            {
                double Gain = double.Parse(this.tGain.Text);
                double Offset = double.Parse(this.tOffset.Text);
                int Cycle = int.Parse(this.tCycle.Text);

                VisionImage image = Form_Main.Instance.imageSet.Image;
                for (int i = 0; i < Cycle; ++i)
                {
                    image = Form_Main.Instance.GainOffset(Form_Main.Instance.imageSet.Image, Gain, Offset);
                }

                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bShowROI_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.imageSet.Roi.Add(rect);
        }

        private void bReadCode_Click(object sender, EventArgs e)
        {
            CodeType type = (CodeType)this.cb_CodeType.SelectedIndex;
            //MessageBox.Show(ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, type));
            tLinkCode.Text = ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, type);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Variable.sPath_SYS_Program + "\\" + Form_Main.VariableSys.sProgramName + "\\" + "JOBFILE\\MES.ini");//Variable.sPath_BaseProgram + "\\Configure\\ZDT.ini");

            try
            {
                ini.IniWriteValue("app", "ReadPosX", this.tXPos.Text);
                ini.IniWriteValue("app", "ReadPosY", this.tYPos.Text);
                ini.IniWriteNumber("app", "Side", this.cbSide.SelectedIndex);
                ini.IniWriteNumber("app", "CodeType", this.cb_CodeType.SelectedIndex);

                string roi = rect.Top.ToString();
                roi += ",";
                roi += rect.Left.ToString();
                roi += ",";
                roi += rect.Width.ToString();
                roi += ",";
                roi += rect.Height.ToString();

                ini.IniWriteValue("app", "ROI", roi);

                ini.IniWriteValue("app", "Light", Light);

                ini.IniWriteValue("app", "Exp", this.tExp.Text);

                ini.IniWriteValue("app","EnableReadCode",this.checkBox1.Checked.ToString());

                ini.IniWriteValue("app", "Gain", this.tGain.Text);
                ini.IniWriteValue("app", "Offset", this.tOffset.Text);
                ini.IniWriteValue("app", "Cycle", this.tCycle.Text);

                Form_Main.Instance.ReadZDTConfig();
            }
            catch { }
        }

        private void Form_ZDTMES_Load(object sender, EventArgs e)
        {
            Form_Main.Instance.ReadZDTConfig();
            this.tXPos.Text = Form_Main.Instance.ReadCodePos.X.ToString("0.000");
            this.tYPos.Text = Form_Main.Instance.ReadCodePos.Y.ToString("0.000");
            this.cbSide.SelectedIndex = (int)Form_Main.Instance.MES_Side;
            this.cb_CodeType.SelectedIndex = (int)Form_Main.Instance.ReadCodeType;
            rect.Top = Form_Main.Instance.ReadCodeROI.Top;
            rect.Left = Form_Main.Instance.ReadCodeROI.Left;
            rect.Width = Form_Main.Instance.ReadCodeROI.Width;
            rect.Height = Form_Main.Instance.ReadCodeROI.Height;
            this.tExp.Text = Form_Main.Instance.ReadCodeExp.ToString();
            this.tGain.Text = Form_Main.Instance.ReadCodeGain.ToString();
            this.tOffset.Text = Form_Main.Instance.ReadCodeOffset.ToString();
            this.tCycle.Text = Form_Main.Instance.ReadCodeCycle.ToString();
            this.Light = Form_Main.Instance.ReadCodeLight.ToString();
            this.tBadMarkNO.Text = Form_Main.Instance.MES_BadMarkNO;
            this.checkBox1.Checked = Form_Main.Instance.EnableReadCode;
        }
    }
}

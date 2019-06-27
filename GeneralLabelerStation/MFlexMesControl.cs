using GeneralLabelerStation.MFlex;
using GeneralLabelerStation.Tool;
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

namespace GeneralLabelerStation
{
    public partial class MFlexMesControl : Form
    {
        public MFlexMesControl()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Dictionary<int, bool> badList = new Dictionary<int, bool>();
            var item = MFlexHelper.Instance.CheckBaseInfo(this.tbBarcode.Text, out badList);

            if (item.Item1)
            {
                this.lblResult.BackColor = Color.Transparent;
                this.lblResult.Text = item.Item2;
            }
            else
            {
                this.lblResult.Text = item.Item2;
                this.lblResult.BackColor = Color.LightCoral;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UIToConfig();
        }

        private void MFlexMesControl_Load(object sender, EventArgs e)
        {
            this.ConfigToUI();
            this.cbCodeList.Items.AddRange(ReadCodeBean.GetList().ToArray());
        }

        private void ConfigToUI()
        {
            MFlexHelper.Load();
            this.tbMachineName.Text = MFlexHelper.Instance.MachineName;
            this.tbMachineLine.Text = MFlexHelper.Instance.LineNo;
            this.tbMachineSite.Text = MFlexHelper.Instance.Site;
            this.tbOperatorName.Text = MFlexHelper.Instance.OperName;
            this.tbMachineSide.Text = MFlexHelper.Instance.WorkArea;
            this.cbEnable.Checked = MFlexHelper.Instance.EnableMES;
            this.cbCodeList.Text = MFlexHelper.Instance.CodeFunc;
            this.tbMac.Text = MFlexHelper.Instance.Mac;
            this.tbProgramName.Text = MFlexHelper.Instance.ProgramName;
        }

        private void UIToConfig()
        {
            MFlexHelper.Instance.MachineName = this.tbMachineName.Text;
            MFlexHelper.Instance.LineNo = this.tbMachineLine.Text;
            MFlexHelper.Instance.Site = this.tbMachineSite.Text;
            MFlexHelper.Instance.OperName = this.tbOperatorName.Text;
            MFlexHelper.Instance.WorkArea = this.tbMachineSide.Text;
            MFlexHelper.Instance.EnableMES = this.cbEnable.Checked;
            MFlexHelper.Instance.Mac = this.tbMac.Text;
            MFlexHelper.Instance.CodeFunc = this.cbCodeList.Text;
            MFlexHelper.Instance.ProgramName = this.tbProgramName.Text;
            MFlexHelper.Save();
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            try
            {
                var bean = ReadCodeBean.Load(this.cbCodeList.Text);
                VisionImage image = Form_Main.Instance.imageSet.Image;
                for (int i = 0; i < bean.Cycle; ++i)
                {
                    image = Form_Main.Instance.GainOffset(Form_Main.Instance.imageSet.Image, bean.Gain, bean.Offset);
                }

                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);

                this.tbBarcode.Text = ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, bean.ROI.ConvertToRoi(), bean.CodeType);
            }
            catch
            {
                MessageBox.Show("读取失败");
            }
        }
    }
}

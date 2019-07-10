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
    public partial class fm_Hardware : Form
    {
        public fm_Hardware()
        {
            InitializeComponent();
            this.wizardControl1.CancelButtonClick += WizardControl1_CancelButtonClick;
        }

        private void WizardControl1_CancelButtonClick(object sender, EventArgs e)
        {
            this.CloseEvent?.Invoke(this, e);
        }

        public event EventHandler CloseEvent;

        private void bAutoCliab1_Click(object sender, EventArgs e)
        {

        }

        private void bLeanTemp_Click(object sender, EventArgs e)
        {

        }

        private void bGoOrg_Click(object sender, EventArgs e)
        {

        }

        private void bSetOrg_Click(object sender, EventArgs e)
        {

        }

        private void bSetNzCenter_Click(object sender, EventArgs e)
        {

        }

        private void bCalRotateCenter_Click(object sender, EventArgs e)
        {

        }

        private void bMoveNzCenter_Click(object sender, EventArgs e)
        {

        }

        private void bMoveRotateCenter_Click(object sender, EventArgs e)
        {

        }

        private void bCheckNz2Cam_Click(object sender, EventArgs e)
        {

        }

        private void bCheckCam2Nz_Click(object sender, EventArgs e)
        {

        }

        private void bCalcDist_Click(object sender, EventArgs e)
        {

        }

        private void bRecrodUp_Click(object sender, EventArgs e)
        {

        }

        private void bRecrodPaste_Click(object sender, EventArgs e)
        {

        }

        private void bRecrodDown_Click(object sender, EventArgs e)
        {

        }

        #region 机械校正
        private PointF Org = new PointF();
        private PointF RightBottom = new PointF();
        private PointF LeftTop = new PointF();
        private PointF RightTop = new PointF();

        private void bFindOrg_Click(object sender, EventArgs e)
        {
            Org = Form_Main.Instance.XYPos;
        }

        private void bLeftTop_Click(object sender, EventArgs e)
        {
            LeftTop = Form_Main.Instance.XYPos;
        }

        private void bRightBottom_Click(object sender, EventArgs e)
        {
            RightBottom = Form_Main.Instance.XYPos;
        }

        private void bRightTop_Click(object sender, EventArgs e)
        {
            RightTop = Form_Main.Instance.XYPos;
        }

        private void bCal_Click(object sender, EventArgs e)
        {
            double angle = Math.Abs(HardwareOrgHelper.GetAngle(Org, RightBottom, Org, LeftTop));
            tXYAngle.Value = (decimal)angle;
            this.bUpdate.Enabled = true;
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            HardwareOrgHelper.Instance.HardWare.LeftBottom = Org;
            HardwareOrgHelper.Instance.HardWare.RightBottom = RightBottom;
            HardwareOrgHelper.Instance.HardWare.LeftTop = LeftTop;
            HardwareOrgHelper.Instance.HardWare.RightTop = RightTop;
            HardwareOrgHelper.Instance.HardWare.XYCroodAngle = (double)this.tXYAngle.Value;
            double deg = (HardwareOrgHelper.Instance.HardWare.XYCroodAngle - 90) / 180.0 * Math.PI;
            HardwareOrgHelper.Instance.HardWare.XRate = Math.Cos(deg);
            HardwareOrgHelper.Instance.HardWare.YRate = Math.Sin(deg);

            HardwareOrgHelper.Save();
        }
        #endregion

        private void bUpdateByCliabed_Click(object sender, EventArgs e)
        {
            var org = Form_Main.Instance.XYPos;
            var leftTop = Form_Main.Instance.XYPos;
            var rightBottom = Form_Main.Instance.XYPos;

            double angle = Math.Abs(HardwareOrgHelper.GetAngle(org, rightBottom, org, leftTop));
            tXYAngle.Text = angle.ToString();
            double distX = HardwareOrgHelper.GetDist(rightBottom, org);
            double distY = HardwareOrgHelper.GetDist(leftTop, org);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"是否初始化机械校验!!! Y/N", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HardwareOrgHelper.Instance.HardWare = new HardwareItem();
                HardwareOrgHelper.Save();
            }
        }
    }
}

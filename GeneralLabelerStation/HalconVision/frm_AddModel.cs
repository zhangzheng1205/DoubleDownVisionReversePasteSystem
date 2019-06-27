using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeneralLabelerStation.HalconVision;
using HalconDotNet;
using NationalInstruments.Vision;

namespace GeneralLabelerStation
{
    public partial class frm_AddModel : Form
    {
        HTuple m_htWindowHandle;
        HTuple m_htModelID;
        HObject m_hoModedImage;
        HObject m_hoModelEdgesTemp;
        HObject m_hoModelEdges;

        public frm_AddModel()
        {
            InitializeComponent();
            HOperatorSet.GenEmptyObj(out m_hoModelEdgesTemp);
            HOperatorSet.GenEmptyObj(out m_hoModelEdges);
            HOperatorSet.GenEmptyObj(out m_hoModedImage);
            //this.pictureBox_ShowImage.MouseWheel += PictureBox_ShowImage_MouseWheel;
        }

        private bool isDraw = false;
        private bool isLoadImage = false;
        private bool isSelect = false;
        // 设定图像的窗口显示部分
        private int zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol;
        private HTuple htWidth, htHeight;

        public short XOffset
        {
            get
            {
                return (short)this.nOffsetX.Value;
            }
            set
            {
                this.nOffsetX.Value = (decimal)value;
            }
        }

        public short YOffset
        {
            get
            {
                return (short)this.nOffsetY.Value;
            }
            set
            {
                this.nOffsetY.Value = (decimal)value;
            }
        }

        public void DispImageFit()
        {
            try
            {
                    HOperatorSet.GetImageSize(m_hoModedImage, out htWidth, out htHeight);
                    HOperatorSet.SetPart(m_htWindowHandle, 0, 0, htHeight, htWidth);
                    HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
            }
            catch
            {
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.PictureBox_ShowImage_MouseWheel(this, e);
            base.OnMouseWheel(e);
        }
        private void PictureBox_ShowImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!isDraw && m_htWindowHandle != null && m_hoModedImage != null&& isLoadImage)
            {
                try
                {
                    HTuple button_state,row, col, beginRow, beginCol, endRow, endCol;
                    HOperatorSet.GetMpositionSubPix(this.m_htWindowHandle, out row, out col, out button_state);
                    HOperatorSet.GetPart(this.m_htWindowHandle, out beginRow, out beginCol, out endRow, out endCol);

                    if (e.Delta > 0)
                    {
                        zoom_beginRow = (int)(beginRow.D + (row.D - beginRow.D) * 0.200d);
                        zoom_beginCol = (int)(beginCol.D + (col.D - beginCol.D) * 0.200d);
                        zoom_endRow = (int)(endRow.D - (endRow.D - row.D) * 0.200d);
                        zoom_endCol = (int)(endCol.D - (endCol.D - col.D) * 0.200d);
                    }
                    else
                    {
                        zoom_beginRow = (int)(row.D - (row.D - beginRow.D) / 0.800d);
                        zoom_beginCol = (int)(col.D - (col.D - beginCol.D) / 0.800d);
                        zoom_endRow = (int)(row.D + (endRow.D - row.D) / 0.800d);
                        zoom_endCol = (int)(col.D + (endCol.D - col.D) / 0.800d);
                    }


                    int hw_width, hw_height;
                    hw_width = this.pictureBox_ShowImage.Width;
                    hw_height = this.pictureBox_ShowImage.Height;

                    bool _isOutOfArea = true;
                    bool _isOutOfSize = true;
                    bool _isOutOfPixel = true; //避免像素过大

                    _isOutOfArea = zoom_beginRow >= htHeight.D || zoom_endRow <= 0 || zoom_beginCol >= htWidth.D || zoom_endCol < 0;
                    _isOutOfSize = (zoom_endRow - zoom_beginRow) > htHeight.D * 20 || (zoom_endCol - zoom_beginCol) > htWidth.D * 20;
                    _isOutOfPixel = hw_height / (zoom_endRow - zoom_beginRow) > 500 || hw_width / (zoom_endCol - zoom_beginCol) > 500;

                    if (_isOutOfArea || _isOutOfSize)
                    {
                        DispImageFit();
                    }
                    else if (!_isOutOfPixel)
                    {

                        HOperatorSet.ClearWindow(this.m_htWindowHandle);
                        zoom_endCol = zoom_beginCol + (zoom_endRow - zoom_beginRow) * hw_width / hw_height;
                        HOperatorSet.SetPart(this.m_htWindowHandle, zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
                        HOperatorSet.DispImage(this.m_hoModedImage, this.m_htWindowHandle);
                    }
                }
                catch(HOperatorException ex)
                {
                }
            }
        }

        private void frm_AddModel_Load(object sender, EventArgs e)
        {
            htWidth = pictureBox_ShowImage.Width;
            htHeight = pictureBox_ShowImage.Height;
            try
            {
                HOperatorSet.OpenWindow(0, 0, htWidth, htHeight, pictureBox_ShowImage.Handle, "visible", "", out m_htWindowHandle);
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.GetErrorMessage());
                return;
            }

            try
            {
                if (0 != m_hoModedImage.CountObj())
                {
                    HOperatorSet.GetImageSize(m_hoModedImage, out htWidth, out htHeight);
                    HOperatorSet.SetPart(m_htWindowHandle, 0, 0, htHeight, htWidth);
                    HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
                    zoom_beginRow = 0;
                    zoom_beginCol = 0;
                    zoom_endCol = htWidth;
                    zoom_endRow = htHeight;
                }
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.GetErrorMessage());
                return;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            try
            {
                HOperatorSet.WriteShapeModel(this.m_htModelID, "D://temp.temp");
                m_hoModedImage?.Dispose();
                DialogResult = DialogResult.Yes;
                this.isLoadImage = false;
            }
            catch { }

            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            HalconHelper.ClearModel(m_htModelID);
            m_hoModedImage?.Dispose();
            DialogResult = DialogResult.No;
            this.isLoadImage = false;
            this.Close();
        }

        //1-导入图片
        private void buttonModelPath_Click(object sender, EventArgs e)
        {
            string strExcetion;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                DialogResult dr = dlg.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    string strPath = dlg.FileName;
                    try
                    {
                        try
                        {
                            m_hoModedImage.Dispose();
                        }
                        catch
                        {
                        }
                        HOperatorSet.GenEmptyObj(out m_hoModedImage);
                        HOperatorSet.ReadImage(out m_hoModedImage, strPath);
                        if (0 != m_hoModedImage.CountObj())
                        {
                            HTuple htWidth = new HTuple();
                            HTuple htHeight = new HTuple();
                            HOperatorSet.GetImageSize(m_hoModedImage, out htWidth, out htHeight);
                            HOperatorSet.SetPart(m_htWindowHandle, 0, 0, htHeight, htWidth);
                            HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
                            zoom_beginRow = 0;
                            zoom_beginCol = 0;
                            zoom_endCol = htWidth;
                            zoom_endRow = htHeight;
                            isLoadImage = true;
                        }

                    }
                    catch (HalconException ex)
                    {
                        strExcetion = ex.GetErrorMessage();
                    }
                }
            }
        }
        //2-清除模板
        private void bClearModel_Click(object sender, EventArgs e)
        {
            HOperatorSet.ClearWindow(m_htWindowHandle);
            HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
            try
            {
                m_hoModelEdgesTemp.Dispose();
            }
            catch (Exception ex)
            {
                m_hoModelEdgesTemp = new HObject();
            }

            try
            {
                m_hoModelEdges.Dispose();
            }
            catch (Exception ex)
            {
                m_hoModelEdges = new HObject();
            }
            HOperatorSet.GenEmptyObj(out m_hoModelEdgesTemp);
            HOperatorSet.GenEmptyObj(out m_hoModelEdges);
        }
        //3-手绘
        private void buttonModelByHand_Click(object sender, EventArgs e)
        {
            try
            {
                HTuple htNumber;
                try
                {
                    m_hoModelEdgesTemp.Dispose();
                }
                catch
                {
                }

                isDraw = true;
                HOperatorSet.GenEmptyObj(out m_hoModelEdgesTemp);
                HOperatorSet.CountObj(m_hoModedImage, out htNumber);
                HSystem.SetSystem("flush_graphic", "false");
                HOperatorSet.ClearWindow(m_htWindowHandle);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
                HOperatorSet.DispObj(m_hoModelEdges, m_htWindowHandle);
                if (0 != htNumber.I)
                {
                    m_hoModelEdgesTemp.Dispose();
                    HOperatorSet.SetColor(m_htWindowHandle, "red");
                    HOperatorSet.SetLineWidth(m_htWindowHandle, 3);
                    HObject region = null;
                    HOperatorSet.DrawRegion(out region, m_htWindowHandle);
                    HObject reduceImage = null;
                    HOperatorSet.ReduceDomain(m_hoModedImage, region, out reduceImage);
                    HOperatorSet.EdgesSubPix(reduceImage, out m_hoModelEdgesTemp, "canny", 1, 20, 70);
                    HOperatorSet.DispObj(m_hoModelEdgesTemp, m_htWindowHandle);
                }
                isDraw = false;
            }
            catch (HalconException ex)
            {
                MessageBox.Show("手绘出现异常，异常信息：" + ex.GetErrorMessage());

            }
        }
        //4-增加轮廓
        private void buttonModelAdd_Click(object sender, EventArgs e)
        {
            try
            {
                HOperatorSet.ConcatObj(m_hoModelEdgesTemp, m_hoModelEdges, out m_hoModelEdges);
            }
            catch (HalconException ex)
            {
                m_hoModelEdges = m_hoModelEdgesTemp;
                MessageBox.Show("添加轮廓异常，异常信息：" + ex.GetErrorMessage());
            }
        }
        //5-创建模板
        private void buttonCreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                HalconHelper.ClearModel(m_htModelID);

                m_htModelID = HalconVision.HalconHelper.LearnShapeModel(m_hoModelEdgesTemp);
                if (m_htModelID != null && m_htModelID.Length > 0)
                {
                    HOperatorSet.SetColor(m_htWindowHandle, "red");
                    HOperatorSet.DispObj(m_hoModelEdges, m_htWindowHandle);
                    MessageBox.Show("学习成功");
                }
                else
                    throw new HalconException("轮廓学习从失败!!!");
            }
            catch (HalconException ex)
            {
                MessageBox.Show("创建模板异常，异常信息：" + ex.GetErrorMessage());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isSelect = true;
        }

        private void buttonFindModel_Click(object sender, EventArgs e)
        {
            HSystem.SetSystem("flush_graphic", "false");
            HOperatorSet.ClearWindow(m_htWindowHandle);
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
            try
            {
                if (m_htModelID == null || m_htModelID.Length == 0) return;
                HObject image = m_hoModedImage.Clone();
                Variable.CamReturn camreturn = new Variable.CamReturn();
                HalconHelper.FindShapeModel(image, null, m_htModelID, ref camreturn, m_htWindowHandle, 0.6, 1);
                tRX.Text = camreturn.X.ToString();
                tRY.Text = camreturn.Y.ToString();
                this.tRAngle.Text = camreturn.Angle.ToString();


                double offsetX = (double)this.nOffsetX.Value * camreturn.XScale;
                double offsetY = (double)this.nOffsetY.Value * camreturn.YScale;

                double deg = -camreturn.Angle / 180.0 * Math.PI;
                PointContour outPt = new PointContour();
                outPt.X = camreturn.X + offsetX;
                outPt.Y = camreturn.Y + offsetY;

                var PTRotated = this.PtRotateDown(outPt, new PointContour(camreturn.X, camreturn.Y), -camreturn.Angle);
                HOperatorSet.SetColor(this.m_htWindowHandle, "green");
                HOperatorSet.DispCross(this.m_htWindowHandle, PTRotated.Y, PTRotated.X, 24, deg);
            }
            catch (HalconException ex)
            {
                MessageBox.Show("查找模板失败，失败信息：" + ex.GetErrorMessage());
            }
        }

        public PointContour PtRotateDown(PointContour PTtoRotate, PointContour RotateCenter, double RotatethetaAngle)//点绕点旋转算法（逆时针为正）
        {
            double deg = RotatethetaAngle / 180.0 * Math.PI;
            var PTRotated = new PointContour();
            PTRotated.X = (PTtoRotate.X - RotateCenter.X) * Math.Cos(deg) + (PTtoRotate.Y - RotateCenter.Y) * Math.Sin(deg) + RotateCenter.X;
            PTRotated.Y = -(PTtoRotate.X - RotateCenter.X) * Math.Sin(deg) + (PTtoRotate.Y - RotateCenter.Y) * Math.Cos(deg) + RotateCenter.Y;
            return PTRotated;
        }

        private void bGetImage_Click(object sender, EventArgs e)
        {
            try
            {
                VisionImage img = GetImage?.Invoke();
                //VisionImage img = new VisionImage();
                //img.ReadFile(@"C:\Users\lichen\Desktop\黑到白\1.bmp");
                if (img != null)
                {
                    m_hoModedImage?.Dispose();
                    m_hoModedImage = HalconHelper.NI2HImage(img);
                    HTuple htWidth = new HTuple();
                    HTuple htHeight = new HTuple();
                    HOperatorSet.GetImageSize(m_hoModedImage, out htWidth, out htHeight);
                    HOperatorSet.SetPart(m_htWindowHandle, 0, 0, htHeight, htWidth);
                    HOperatorSet.DispObj(m_hoModedImage, m_htWindowHandle);
                    zoom_beginRow = 0;
                    zoom_beginCol = 0;
                    zoom_endCol = htWidth;
                    zoom_endRow = htHeight;
                    isLoadImage = true;
                }
            }
            catch { }
        }

        public static event Func<VisionImage> GetImage;
    }
}

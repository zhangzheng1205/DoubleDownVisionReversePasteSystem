using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using HalconDotNet;

namespace GeneralLabelerStation
{
    public enum CodeType
    {
        Code_1D39,
        Code_1D129,
        Code_1D93,
        Code_2D_Mat,
        Code_QR,
    }

    public partial class ReadCodeHelper
    {
        public static string ReadCode1(VisionImage image, Roi roi, CodeType type)
        {
            string code = string.Empty;

            try
            {
                if (type == CodeType.Code_1D39)
                {

                }
                else if (type == CodeType.Code_1D129)
                {

                }
                else if (type == CodeType.Code_1D93)
                {

                }
                else if (type == CodeType.Code_2D_Mat)
                {
                    DataMatrixReport datamatrixreport = Algorithms.ReadDataMatrixBarcode(image, roi);
                    if (datamatrixreport.StringData != null)
                    {
                        code = datamatrixreport.StringData;
                    }
                }
                else if (type == CodeType.Code_QR)
                {
                    QRReport qrreport = new QRReport();
                    qrreport = Algorithms.ReadQRCode(image, roi);
                    System.Text.ASCIIEncoding vaASCIIEncoding = new System.Text.ASCIIEncoding();
                    if (qrreport != null)
                    {
                        code = vaASCIIEncoding.GetString(qrreport.GetData());
                    }
                }
            }
            catch { code = string.Empty; }

            return code;
        }

        /// <summary>
        /// 条码识别
        /// </summary>
        /// <param name="img"></param>
        /// <param name="Roi"></param>
        /// <param name="type"></param>
        /// <param name="Barcode"></param>
        /// <returns></returns>
        public static string ReadCode(VisionImage img, Roi Roi, CodeType type)
        {
            //HObject img,HObject Roi,BarcodeType type,out string Barcode,out HObject Box
            HObject Box, Himage, HRoi, imgreduced;
            string Barcode = "";
            HTuple BarCodeHandle = null, DecodedDataStrings;
            img.Type = ImageType.U8; img.BorderWidth = 0;
            HOperatorSet.GenEmptyObj(out Box);
            HOperatorSet.GenEmptyObj(out Himage);
            HOperatorSet.GenEmptyObj(out HRoi);
            HOperatorSet.GenEmptyObj(out imgreduced);
            try
            {
                HOperatorSet.GenImage1(out Himage, "byte", img.Width, img.Height, img.StartPtr);
                HOperatorSet.GenRectangle1(out HRoi, ((RectangleContour)Roi[0].Shape).Top, ((RectangleContour)Roi[0].Shape).Left, ((RectangleContour)Roi[0].Shape).Top + ((RectangleContour)Roi[0].Shape).Height, ((RectangleContour)Roi[0].Shape).Left + ((RectangleContour)Roi[0].Shape).Width);
                HOperatorSet.ReduceDomain(Himage, HRoi, out imgreduced);//image_rectified
                switch (type)
                {
                    case CodeType.Code_1D129:
                        HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out BarCodeHandle);
                        HOperatorSet.FindBarCode(Himage, out Box, BarCodeHandle,
                                                 "Code 128", out DecodedDataStrings);
                        HOperatorSet.ClearBarCodeModel(BarCodeHandle);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_1D39:
                        HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out BarCodeHandle);
                        HOperatorSet.FindBarCode(Himage, out Box, BarCodeHandle,
                                                 "Code 39", out DecodedDataStrings);
                        HOperatorSet.ClearBarCodeModel(BarCodeHandle);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_2D_Mat:
                        HTuple ResultHandles_DataMatrix = null;
                        HOperatorSet.CreateDataCode2dModel("Data Matrix ECC 200", new HTuple(), new HTuple(), out BarCodeHandle);
                        HOperatorSet.SetDataCode2dParam(BarCodeHandle, "default_parameters", "maximum_recognition");
                        HOperatorSet.FindDataCode2d(Himage, out Box, BarCodeHandle, "stop_after_result_num",
                            1/*找寻1个*/, out ResultHandles_DataMatrix, out DecodedDataStrings);
                        HOperatorSet.ClearDataCode2dModel(BarCodeHandle);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_QR:
                        HTuple ResultHandles_QR = null;
                        HOperatorSet.CreateDataCode2dModel("QR Code", new HTuple(), new HTuple(), out BarCodeHandle);
                        HOperatorSet.FindDataCode2d(Himage, out Box, BarCodeHandle, new HTuple(), new HTuple(), out ResultHandles_QR, out DecodedDataStrings);
                        HOperatorSet.ClearDataCode2dModel(BarCodeHandle);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                }
                if (Box != null)
                    Box.Dispose();
                if (Himage != null)
                    Himage.Dispose();
                if (HRoi != null)
                    HRoi.Dispose();
                if (imgreduced != null)
                    imgreduced.Dispose();
                return Barcode;
            }
            catch
            {
                if (Box != null)
                    Box.Dispose();
                if (Himage != null)
                    Himage.Dispose();
                if (HRoi != null)
                    HRoi.Dispose();
                if (imgreduced != null)
                    imgreduced.Dispose();
                return "";
            }
        }
    }
}

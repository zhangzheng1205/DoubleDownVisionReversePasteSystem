using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using HalconDotNet;

namespace GeneralLabelerStation.Common
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
        public static bool Init()
        {
            BarCodeHandler.Clear();
            try
            {
                foreach(CodeType type in Enum.GetValues(typeof(CodeType)))
                {
                    if(type == CodeType.Code_2D_Mat)
                    {
                        HTuple tuple = new HTuple();
                        HOperatorSet.CreateDataCode2dModel("Data Matrix ECC 200", new HTuple(), new HTuple(), out tuple);
                        HOperatorSet.SetDataCode2dParam(tuple, "default_parameters", "maximum_recognition");
                        BarCodeHandler.Add(type, tuple);
                    }
                    else if(type == CodeType.Code_QR)
                    {
                        HTuple tuple = new HTuple();
                        HOperatorSet.CreateDataCode2dModel("QR Code", new HTuple(), new HTuple(), out tuple);
                        BarCodeHandler.Add(type, tuple);
                    }
                    else
                    {
                        HTuple tuple = new HTuple();
                        HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out tuple);
                        BarCodeHandler.Add(type, tuple);
                    }
                }
            }
            catch { return false; }
            return true;
        }

        public static Dictionary<CodeType, HTuple> BarCodeHandler = new Dictionary<CodeType, HTuple>();

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
            HTuple DecodedDataStrings = null;
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
                        HOperatorSet.FindBarCode(Himage, out Box, BarCodeHandler[CodeType.Code_1D129],"Code 128", out DecodedDataStrings);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_1D39:
                        HOperatorSet.FindBarCode(Himage, out Box, BarCodeHandler[CodeType.Code_1D39],"Code 39", out DecodedDataStrings);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_2D_Mat:
                        HTuple ResultHandles_DataMatrix = null;
                        HOperatorSet.FindDataCode2d(Himage, out Box, BarCodeHandler[CodeType.Code_2D_Mat], "stop_after_result_num",
                            1/*找寻1个*/, out ResultHandles_DataMatrix, out DecodedDataStrings);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                    case CodeType.Code_QR:
                        HTuple ResultHandles_QR = null;
                        HOperatorSet.FindDataCode2d(Himage, out Box, BarCodeHandler[CodeType.Code_QR], new HTuple(), new HTuple(), out ResultHandles_QR, out DecodedDataStrings);
                        if (DecodedDataStrings.Length > 0)
                        {
                            Barcode = DecodedDataStrings.SArr[0];
                        }
                        break;
                }
                Box?.Dispose();
                Himage?.Dispose();
                HRoi?.Dispose();
                imgreduced?.Dispose();
                return Barcode;
            }
            catch
            {
                Box?.Dispose();
                Himage?.Dispose();
                HRoi?.Dispose();
                imgreduced?.Dispose();
                return "";
            }
        }
    }
}

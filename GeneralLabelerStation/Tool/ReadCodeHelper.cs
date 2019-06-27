using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
namespace GeneralLabelerStation.Tools
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
        public static string ReadCode(VisionImage image, Roi roi, CodeType type)
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
    }
}

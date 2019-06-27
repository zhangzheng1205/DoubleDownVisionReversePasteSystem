using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;


namespace GeneralLabelerStation
{
    public class ErrorCode
    {
        #region 单例模式
        private ErrorCode()
        {
            this.ErrorCodeInfo = new List<ErrorCodeBean>();
        }

        private static ErrorCode instance = new ErrorCode();

        public static ErrorCode Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public bool LoadConfig()
        {
            if (File.Exists(Variable.sPath_ErrorCodeInfoConfig))
            {
                Form_Main.InitializeWorkbook(Variable.sPath_ErrorCodeInfoConfig);//XLS
                this.ErrorCodeInfo.Clear();
                ISheet sheet = Form_Main.hssfworkbook.GetSheetAt(0);
                IRow row;
                string errorcode = "",
                    errortype_English = "", errortype_Chinese = "", errortype_ChineseT = "",
                    errorinfo_English = "", errorinfo_Chinese = "", errorinfo_ChineseT = "", 
                    errorsolution_English = "", errorsolution_Chinese = "", errorsolution_ChineseT = "";

                try
                {
                    for (int i = 1; i < 301; i++)//只取300组
                    {
                        row = sheet.GetRow(i);

                        try
                        {
                            errorcode = "";
                            errortype_English = "";
                            errortype_Chinese = "";
                            errortype_ChineseT = "";
                            errorinfo_English = "";
                            errorinfo_Chinese = "";
                            errorinfo_ChineseT = "";
                            errorsolution_English = "";
                            errorsolution_Chinese = "";
                            errorsolution_ChineseT = "";

                            errorcode = row.Cells[0].StringCellValue;
                            errortype_Chinese = row.Cells[1].StringCellValue;
                            errortype_ChineseT = row.Cells[2].StringCellValue;
                            errortype_English = row.Cells[3].StringCellValue;
                            errorinfo_Chinese = row.Cells[4].StringCellValue;
                            errorinfo_ChineseT = row.Cells[5].StringCellValue;
                            errorinfo_English = row.Cells[6].StringCellValue;
                            errorsolution_Chinese = row.Cells[7].StringCellValue;
                            errorsolution_ChineseT = row.Cells[8].StringCellValue;
                            errorsolution_English = row.Cells[9].StringCellValue;
                        }
                        catch
                        {
                        }
                        ErrorCodeBean temp = new ErrorCodeBean();
                        temp.ErrorIndexCode = errorcode;
                        temp.ErrorType_English = errortype_English;
                        temp.ErrorType_Chinese = errortype_Chinese;
                        temp.ErrorType_ChineseT = errortype_ChineseT;
                        temp.ErrorInformation_English = errorinfo_English;
                        temp.ErrorInformation_Chinese = errorinfo_Chinese;
                        temp.ErrorInformation_ChineseT = errorinfo_ChineseT;
                        temp.ErrorSolution_English = errorsolution_English;
                        temp.ErrorSolution_Chinese = errorsolution_Chinese;
                        temp.ErrorSolution_ChineseT = errorsolution_ChineseT;
                        if (errorcode == "")
                        {
                            break;
                        }
                        this.ErrorCodeInfo.Add(temp);
                    }
                }
                catch
                {
                }
            }
            else
            {
                //Form_Main.hssfworkbook.Clear();
                return false;
            }
            Form_Main.hssfworkbook.Clear();
            return true;
        }

        public string GetErrorCode(int ErrorIndex, int Chinese0English1,string AddInfo)
        {
            string Errorcode = "";
            try
            {
                if (Chinese0English1 == 0)
                {
                    Errorcode = "[錯誤代碼:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][類型:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_ChineseT + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_ChineseT + "][" + AddInfo + "]\r\n";
                    Errorcode += "[解決方法:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_ChineseT + "]";
                    Errorcode += "^";
                    Errorcode += "[錯誤代碼:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_ChineseT + "]";
                }
                else if (Chinese0English1 == 1)
                {
                    Errorcode = "[ErrorCode:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][Type:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_English + "]\r\n";
                    Errorcode += "[Information:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_English + "][" + AddInfo + "]\r\n";
                    Errorcode += "[Solution:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_English + "]";
                    Errorcode += "^";
                    Errorcode += "[ErrorCode:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[Information:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_English + "]";
                }
                else if (Chinese0English1 == 2)
                {
                    Errorcode = "[错误代码:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][类型:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_Chinese + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_Chinese + "][" + AddInfo + "]\r\n";
                    Errorcode += "[解决方法:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_Chinese + "]";
                    Errorcode += "^";
                    Errorcode += "[错误代码:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_Chinese + "]";
                }
            }
            catch
            {
            }


            return Errorcode;
        }

        public string GetErrorCode(int ErrorIndex, int Chinese0English1)
        {
            string Errorcode = "";
            try
            {
                if (Chinese0English1 == 0)
                {
                    Errorcode = "[錯誤代碼:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][類型:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_ChineseT + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_ChineseT + "]\r\n";
                    Errorcode += "[解決方法:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_ChineseT + "]";
                    Errorcode += "^";
                    Errorcode += "[錯誤代碼:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_ChineseT + "]";
                }
                else if (Chinese0English1 == 1)
                {
                    Errorcode = "[ErrorCode:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][Type:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_English + "]\r\n";
                    Errorcode += "[Information:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_English + "]\r\n";
                    Errorcode += "[Solution:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_English + "]";
                    Errorcode += "^";
                    Errorcode += "[ErrorCode:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[Information:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_English + "]";
                }
                else if (Chinese0English1 == 2)
                {
                    Errorcode = "[错误代码:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "][类型:" + ErrorCodeInfo[ErrorIndex - 1].ErrorType_Chinese + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_Chinese + "]\r\n";
                    Errorcode += "[解决方法:" + ErrorCodeInfo[ErrorIndex - 1].ErrorSolution_Chinese + "]";
                    Errorcode += "^";
                    Errorcode += "[错误代码:" + ErrorCodeInfo[ErrorIndex - 1].ErrorIndexCode + "]\r\n";
                    Errorcode += "[信息:" + ErrorCodeInfo[ErrorIndex - 1].ErrorInformation_Chinese + "]";
                }
            }
            catch
            {
            }
            return Errorcode;
        }

        public List<ErrorCodeBean> ErrorCodeInfo
        {
            get;
            set;
        }
    }

    public class ErrorCodeBean
    {
        public string ErrorIndexCode
        {
            get;
            set;
        }
        public string ErrorType_English
        {
            get;
            set;
        }
        public string ErrorType_Chinese
        {
            get;
            set;
        }
        public string ErrorType_ChineseT
        {
            get;
            set;
        }
        public string ErrorInformation_English
        {
            get;
            set;
        }
        public string ErrorInformation_Chinese
        {
            get;
            set;
        }
        public string ErrorInformation_ChineseT
        {
            get;
            set;
        }
        public string ErrorSolution_English
        {
            get;
            set;
        }
        public string ErrorSolution_Chinese
        {
            get;
            set;
        }
        public string ErrorSolution_ChineseT
        {
            get;
            set;
        }
    }
}

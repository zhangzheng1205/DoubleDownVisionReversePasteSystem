using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.HPSF.Wellknown;

using System.IO;
using System.Data;
using System.Drawing;
namespace GeneralLabelerStation.Tools
{
    public class ExcelHelper
    {
        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string fileName, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            FileStream fs = null;
            IWorkbook workbook = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }

                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }


        /// <summary>
        /// 从贴附信息导入
        /// </summary>
        /// <param name="excelPath">excel 路径</param>
        /// <param name="posList">PosList 拍照点</param>
        /// <returns>true/false</returns>
        public bool ExcelReadToCpkItem(string excelPath, ref List<CPK_ResultItem> posList)
        {
            if (posList != null)
            {
                posList.Clear();

                ISheet sheet = null;
                FileStream fs = null;
                IWorkbook workbook = null;

                fs = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (excelPath.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (excelPath.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheet("PASTE");
                }
                else
                {
                    return false;
                }

                if (sheet == null)
                {
                    return false;
                }

                IRow row;

                //计算贴附点个数
                int rowIndex = 0;
                short PastePointCount = 0;
                while (rowIndex < 1000000000)//默认小于1000000000
                {
                    row = sheet.GetRow(rowIndex + 152);//76
                    try
                    {
                        if (row.Cells[4].StringCellValue == "")
                        {
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                    rowIndex++;
                    PastePointCount++;
                }

                for (int i = 0; i < PastePointCount; i++)
                {
                    row = sheet.GetRow(i + 152);
                    CPK_ResultItem item = new CPK_ResultItem();
                    item.Pos = new PointF(float.Parse(row.Cells[1].StringCellValue), float.Parse(row.Cells[2].StringCellValue));
                    item.UsedNozzle = short.Parse(row.Cells[9].StringCellValue);
                    posList.Add(item);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 优化路径
        /// </summary>
        /// <param name="cpkValue">cpk X  标准值</param>
        /// <param name="cpkValue">cpk Y  标准值</param>
        /// <param name="excelPath">excel 路径</param>
        /// <param name="items">cpk 结果</param>
        /// <returns>true/false</returns>
        public bool OptimizePasteByCPK(double cpkXValue, double cpkYValue, string excelPath, List<CPK_ResultItem> items)
        {
            if (items != null)
            {
                ISheet sheet = null;
                FileStream fs = null;
                IWorkbook workbook = null;

                fs = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (excelPath.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (excelPath.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheet("PASTE");
                }
                else
                {
                    return false;
                }

                if (sheet == null)
                {
                    return false;
                }

                IRow row = null;

                try
                {
                    for (int i = 0; i < items.Count; ++i)
                    {
                        if (items[i].X1 == 0) continue;
                        row = sheet.GetRow(i + 152);
                        if (row == null) continue;

                        PointF orgPoint = new PointF(float.Parse(row.Cells[1].StringCellValue), float.Parse(row.Cells[2].StringCellValue));
                        double dX = items[i].X1;//(items[i].X1 + items[i].X2) / 2.0;
                        double dY = items[i].Y1;//(items[i].Y1 + items[i].Y2) / 2.0;


                        if (Math.Abs(dX - cpkXValue) > 0.04 && Math.Abs(dX - cpkXValue) < 1.0)
                        {
                            orgPoint.X = orgPoint.X - (float)(dX - cpkXValue);
                        }

                        if (Math.Abs(dY - cpkYValue) > 0.04 && Math.Abs(dY - cpkYValue) < 1.0)
                        {
                            orgPoint.Y = orgPoint.Y - (float)(dY - cpkYValue);
                        }

                        row.Cells[1].SetCellValue(orgPoint.X.ToString());
                        row.Cells[2].SetCellValue(orgPoint.Y.ToString());
                    }

                    fs.Close();

                    FileStream file = new FileStream(excelPath, FileMode.Create);

                    workbook.Write(file);
                    file.Flush();
                    file.Close();
                }
                catch(Exception ex)
                {
                    return false;    
                }

                return true;
            }

            return false;
        }


        /// <summary>
        /// 将excel导入到datatable
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <returns>返回datatable</returns>
        public bool ExcelToDataTable(string filePath, string descPath, List<CPK_ResultItem> items)
        {
            FileStream fs = null;

            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;

            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                // 2007版本
                if (filePath.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                // 2003版本
                else if (filePath.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheet("CPK Data");//读取第一个sheet，当然也可以循环读取每个sheet

                    if (sheet != null)
                    {
                        int rowCount = sheet.LastRowNum;//总行数
                        if (rowCount > 0)
                        {
                            rowCount = 55;
                            short Head1Row = 23;
                            short Head2Row = 23;

                            for (int i = 0; i < items.Count; ++i)
                            {
                                CPK_ResultItem item = items[i];
                                if (item.UsedNozzle == 1)
                                {
                                    if (Head1Row > 55) continue;
                                    row = sheet.GetRow(Head1Row);
                                    if (row == null) continue;
                                    cell = row.GetCell(2);
                                    cell.SetCellValue(item.X1);
                                    cell = row.GetCell(3);
                                    cell.SetCellValue(item.X2);
                                    cell = row.GetCell(4);
                                    cell.SetCellValue(item.Y1);
                                    cell = row.GetCell(5);
                                    cell.SetCellValue(item.Y2);
                                    Head1Row++;
                                }
                                else
                                {
                                    if (Head2Row > 55) continue;
                                    row = sheet.GetRow(Head2Row);
                                    if (row == null) continue;
                                    cell = row.GetCell(6);
                                    cell.SetCellValue(item.X1);
                                    cell = row.GetCell(7);
                                    cell.SetCellValue(item.X2);
                                    cell = row.GetCell(8);
                                    cell.SetCellValue(item.Y1);
                                    cell = row.GetCell(9);
                                    cell.SetCellValue(item.Y2);
                                    Head2Row++;
                                }
                            }
                        }
                    }
                }

                fs.Close();

                FileStream file = new FileStream(descPath, FileMode.Create);

                workbook.Write(file);
                file.Flush();
                file.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return false;
            }
        }

        public bool CailbResultToExcel(string filePath, string descPath, ref Jig_ResultItem[,] items, int jig_row, int jig_col)
        {
            FileStream fs = null;

            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;

            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                // 2007版本
                if (filePath.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                // 2003版本
                else if (filePath.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheet("sheet1");//读取第一个sheet，当然也可以循环读取每个sheet

                    if (sheet != null)
                    {
                        //int rowCount = sheet.LastRowNum;//总行数
                        //if (rowCount > 0)
                        {
                            int startRow = 1;

                            for (int i = 0; i < jig_row; ++i)
                            {
                                for (int j = 0; j < jig_col; ++j)
                                {
                                    row = sheet.CreateRow(i*jig_col+j+startRow);
                                    if (row == null) continue;
                                    row.CreateCell(0).SetCellValue(i * jig_col + j);
                                    row.CreateCell(1).SetCellValue(i);
                                    row.CreateCell(2).SetCellValue(j);
                                    row.CreateCell(3).SetCellValue(items[i, j].Image_CircleCenter.X);
                                    row.CreateCell(4).SetCellValue(items[i, j].Image_CircleCenter.Y);
                                    row.CreateCell(5).SetCellValue(items[i, j].MachinePos.X);
                                    row.CreateCell(6).SetCellValue(items[i, j].MachinePos.Y);
                                    row.CreateCell(7).SetCellValue(items[i, j].Real_CircleCenter.X);
                                    row.CreateCell(8).SetCellValue(items[i, j].Real_CircleCenter.Y);
                                    row.CreateCell(9).SetCellValue(items[i, j].RightDist);
                                    row.CreateCell(10).SetCellValue(items[i, j].DownDist);
                                }
                            }
                        }
                    }
                }

                fs.Close();

                FileStream file = new FileStream(descPath, FileMode.Create);

                workbook.Write(file);
                file.Flush();
                file.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return false;
            }
        }

        /// <summary>
        /// 获得 机台校验文件 数据
        /// </summary>
        /// <param name="filePath">机台校验路径</param>
        /// <param name="items">数据项</param>
        /// <param name="jig_row">数据行</param>
        /// <param name="jig_col">数据列</param>
        /// <returns>false</returns>
        public bool GetCailbResult(string filePath, ref Jig_ResultItem[,] items, int jig_row, int jig_col)
        {
            items = new Jig_ResultItem[jig_row, jig_col];
            FileStream fs = null;

            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;

            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                // 2007版本
                if (filePath.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                // 2003版本
                else if (filePath.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheet("sheet1");//读取第一个sheet，当然也可以循环读取每个sheet

                    if (sheet != null)
                    {
                        {
                            int startRow = 1;

                            for (int i = 0; i < jig_row; ++i)
                            {
                                for (int j = 0; j < jig_col; ++j)
                                {
                                    row = sheet.GetRow(i * jig_col + j + startRow);
                                    if (row == null) continue;
                                    items[i, j] = new Jig_ResultItem();
                                    items[i, j].Image_CircleCenter.X = (float)row.GetCell(3).NumericCellValue;
                                    items[i, j].Image_CircleCenter.Y = (float)row.GetCell(4).NumericCellValue;
                                    items[i, j].MachinePos.X = (float)row.GetCell(5).NumericCellValue;
                                    items[i, j].MachinePos.Y = (float)row.GetCell(6).NumericCellValue;
                                    items[i, j].Real_CircleCenter.X = (float)row.GetCell(7).NumericCellValue;
                                    items[i, j].Real_CircleCenter.Y = (float)row.GetCell(8).NumericCellValue;
                                    items[i, j].RightDist = row.GetCell(9).NumericCellValue;
                                    items[i, j].DownDist  = row.GetCell(10).NumericCellValue;
                                }
                            }
                        }
                    }
                }

                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }

                items = null;
                return false;
            }
        }
    }
}

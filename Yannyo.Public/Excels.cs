using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

using NPOI;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using System.IO;

namespace Yannyo.Public
{
    public class Excels
    {
        
        public static DataSet ExcelToDataTable(string strExcelFileName)
        {
            //源的定义
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";

            //Sql语句
            //string strExcel = string.Format("select * from [{0}$]", strSheetName); 这是一种方法
            

            //定义存放的数据表
            DataSet ds = new DataSet();

            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                conn.Open();
                //适配到数据源
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string strExcel = "select * from [" + dt.Rows[0][2].ToString().Trim() + "]";

                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                try
                {
                    adapter.Fill(ds);
                }
                finally
                {
                    adapter.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        
        /// <summary> 
        /// 将Excel文件中的数据读出到DataTable中(xlsx) 
        /// </summary> 
        /// <param name="file">文件路径</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ExcelToTableForXLSX(string file)
        {
            DataTable dt = new DataTable();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {

                XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                ISheet sheet = xssfworkbook.GetSheetAt(0);

                // 表头 
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {

                    object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);

                    if (obj == null || obj.ToString() == string.Empty)
                    {

                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));

                        // continue; 

                    }
                    else{
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }

                    columns.Add(i);

                }

                // 数据 
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {

                    DataRow dr = dt.NewRow();

                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {

                            hasValue = true;

                        }

                    }

                    if (hasValue)
                    {

                        dt.Rows.Add(dr);

                    }

                }

            }

            return dt;

        }

        /// <summary> 
        /// 将DataTable数据导出到Excel文件中(xlsx) 
        /// </summary> 
        /// <param name="dt">数据源</param> 
        /// <param name="excelName">文件名称</param> 
        public static void TableToExcelForXLSX(DataTable dt, string excelName)
        {
            XSSFWorkbook xssfworkbook = new XSSFWorkbook();
            ISheet sheet = xssfworkbook.CreateSheet((dt.TableName.Trim()!=""?dt.TableName.Trim():"Data"));


            //表头 
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);

                cell.SetCellValue(dt.Columns[i].ColumnName);

            }

            //数据 

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                IRow row1 = sheet.CreateRow(i + 1);

                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());

                }
            }

            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            curContext.Response.Clear();
            curContext.Response.ContentType = "application/x-excel";
            string filename = HttpUtility.UrlEncode(excelName + DateTime.Now.ToString("yyyyMMddHHmm") + ".xlsx");
            curContext.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            xssfworkbook.Write(curContext.Response.OutputStream);
            curContext.Response.End();
        }

        /// <summary> 
        /// 获取单元格类型(xlsx) 
        /// </summary> 
        /// <param name="cell">单元格</param> 
        /// <returns>单元格类型</returns> 
        private static object GetValueTypeForXLSX(XSSFCell cell)
        {

            if (cell == null)
            return null;

            switch (cell.CellType)
            {

            case CellType.Blank: //BLANK: 

            return null;

            case CellType.Boolean: //BOOLEAN: 

            return cell.BooleanCellValue;

            case CellType.Numeric: //NUMERIC: 

            return cell.NumericCellValue;

            case CellType.String: //STRING: 

            return cell.StringCellValue;

            case CellType.Error: //ERROR: 

            return cell.ErrorCellValue;

            case CellType.Formula: //FORMULA: 

            default:

            return "=" + cell.CellFormula;

            }

        }
    }
}

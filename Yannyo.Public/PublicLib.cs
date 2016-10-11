using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Yannyo.Public
{
    public class PublicLib
    {
        /// <summary>
        /// 判断身份证是否合法
        /// </summary>
        /// <param name="str">身份证号码</param>
        /// <returns>bool</returns>
        public static bool cardID(string str)
        {
            bool error = true;
            string zzbds = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$"; //设置正则表达式 
            Match m = Regex.Match(str, zzbds);//判断并得到结果
            if (!m.Success)//判断如果不符合正则表达式规则设置error为false;
            {
                error = false; ;
            }
            return error;
        }

        public static IdentityCardInfo CheckIdCard(string IdCardStr)
        {
            IdentityCardInfo ic = new IdentityCardInfo();
            if(IdCardStr.Trim()!="")
            {
                if (IdCardStr.Length != 15 && IdCardStr.Length != 18)
                {
                    ic = null;
                }
                else
                {
                    string birthday = "";
                    string thisyearbirthday = DateTime.Now.Year.ToString();
                    string sex = "";

                    ic.CardIDStr = IdCardStr;

                    if (IdCardStr.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
                    {
                        birthday = IdCardStr.Substring(6, 4) + "-" + IdCardStr.Substring(10, 2) + "-" + IdCardStr.Substring(12, 2);
                        thisyearbirthday = thisyearbirthday + "-" + IdCardStr.Substring(10, 2) + "-" + IdCardStr.Substring(12, 2);
                        sex = IdCardStr.Substring(14, 3);
                    }
                    if (IdCardStr.Length == 15)
                    {
                        birthday = "19" + IdCardStr.Substring(6, 2) + "-" + IdCardStr.Substring(8, 2) + "-" + IdCardStr.Substring(10, 2);
                        thisyearbirthday = thisyearbirthday + "-" + IdCardStr.Substring(8, 2) + "-" + IdCardStr.Substring(10, 2);
                        sex = IdCardStr.Substring(12, 3);
                    }
                    ic.Birthday = DateTime.Parse(birthday);
                    ic.ThisYearBirthDay = DateTime.Parse(thisyearbirthday);

                    if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性奇数为男性
                    {
                        ic.Sex = "女";
                    }
                    else
                    {
                        ic.Sex = "男";
                    }
                }
            }
            return ic;
        }

        /// <summary>     
        /// Datatable转换为Json     
        /// </summary>    
        /// <param name="table">Datatable对象</param>     
        /// <returns>Json字符串</returns>     
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>json字符串</returns>
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        #region GetPagedTable DataTable分页
        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="PageIndex">页索引,注意：从1开始</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns></returns>
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Copy();
            newdt.Clear();

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }
        #endregion
    }

    public class IdentityCardInfo
    {
        private string _CardIDStr;
        private string _Sex;
        private DateTime _Birthday;
        private DateTime _ThisYearBirthDay;

        /// <summary>
        /// 身份证号码,15或18位
        /// </summary>
        public string CardIDStr
        {
            set { _CardIDStr = value; }
            get { return _CardIDStr; }
        }
        /// <summary>
        /// 性别,男,女
        /// </summary>
        public string Sex
        {
            set { _Sex = value; }
            get { return _Sex; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday
        {
            set { _Birthday = value; }
            get { return _Birthday; }
        }
        /// <summary>
        /// 今年的生日日期
        /// </summary>
        public DateTime ThisYearBirthDay
        {
            set { _ThisYearBirthDay = value; }
            get { return _ThisYearBirthDay; }
        }
    }
}

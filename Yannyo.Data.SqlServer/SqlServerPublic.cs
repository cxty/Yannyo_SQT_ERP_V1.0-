using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// SQL SERVER SQL语句转义
        /// </summary>
        /// <param name="str">需要转义的关键字符串</param>
        /// <returns>转义后的字符串</returns>
        private static string RegEsc(string str)
        {
            string[] pattern = { @"%", @"_", @"'" };
            foreach (string s in pattern)
            {
                //Regex rgx = new Regex(s);
                //keyword = rgx.Replace(keyword, "\\" + s);
                switch (s)
                {
                    case "%":
                        str = str.Replace(s, "[%]");
                        break;
                    case "_":
                        str = str.Replace(s, "[_]");
                        break;
                    case "'":
                        str = str.Replace(s, "['']");
                        break;

                }

            }
            return str;
        }
    }
}

using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

using Yannyo.Common;
using Yannyo.Data;

namespace Yannyo.Public
{
    /// <summary>
    /// 模板生成类
    /// </summary>
    public class SysPageTemplate : PageTemplate
    {
        /// <summary>
        /// 解析特殊变量
        /// </summary>
        /// <param name="skinName">皮肤名</param>
        /// <param name="strTemplate">模板内容</param>
        /// <returns></returns>
        public override string ReplaceSpecialTemplate(string syspath, string skinName, string strTemplate)
        {
            Regex r;
            Match m;

            StringBuilder sb = new StringBuilder();
            sb.Append(strTemplate);
            r = new Regex(@"({([^\[\]/\{\}='\s]+)})", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
            for (m = r.Match(strTemplate); m.Success; m = m.NextMatch())
            {
                if (m.Groups[0].ToString() == "{forumversion}")
                {
                    sb = sb.Replace(m.Groups[0].ToString(), Utils.GetAssemblyVersion());
                }
                else if (m.Groups[0].ToString() == "{forumproductname}")
                {
                    sb = sb.Replace(m.Groups[0].ToString(), Utils.GetAssemblyProductName());
                }
            }

            foreach (DataRow dr in GetTemplateVarList(syspath, skinName).Rows)
            {
                sb = sb.Replace(dr["variablename"].ToString().Trim(), dr["variablevalue"].ToString().Trim());
            }
            return sb.ToString();
        }


        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="skinName">皮肤名</param>
        /// <param name="templateName">模板名</param>
        /// <param name="nest">嵌套次数</param>
        /// <param name="templateid">皮肤id</param>
        /// <returns></returns>
        public override string GetTemplate(string syspath, string skinName, string templateName, int nest, int templateid, string Inherits)
        {
            return base.GetTemplate(syspath, skinName, templateName, nest, templateid, Inherits);
        }

        /// <summary>
        /// 获得模板变量列表
        /// </summary>
        /// <param name="skinName">皮肤名</param>
        /// <returns></returns>
        public static DataTable GetTemplateVarList(string syspath, string skinName)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable dt = cache.RetrieveSingleObject("/Sys/" + skinName + "/TemplateVariable") as DataTable;

            if (dt != null)
            {
                return dt;
            }
            else
            {
                DataSet dsSrc = new DataSet("template");
                string[] filename = new string[1] { Utils.GetMapPath(syspath + "templates/" + skinName + "/templatevariable.xml") };

                if (Utils.FileExists(filename[0]))
                {
                    dsSrc.ReadXml(filename[0]);

                    if (dsSrc.Tables.Count == 0)
                    {
                        DataTable templatevariable = new DataTable("TemplateVariable");
                        templatevariable.Columns.Add("id", System.Type.GetType("System.Int32"));
                        templatevariable.Columns.Add("variablename", System.Type.GetType("System.String"));
                        templatevariable.Columns.Add("variablevalue", System.Type.GetType("System.String"));
                        dsSrc.Tables.Add(templatevariable);
                    }
                }
                else
                {
                    DataTable templatevariable = new DataTable("TemplateVariable");
                    templatevariable.Columns.Add("id", System.Type.GetType("System.Int32"));
                    templatevariable.Columns.Add("variablename", System.Type.GetType("System.String"));
                    templatevariable.Columns.Add("variablevalue", System.Type.GetType("System.String"));
                    dsSrc.Tables.Add(templatevariable);
                }

                cache.AddSingleObject("/Forum/" + skinName + "/TemplateVariable", dsSrc.Tables[0], filename);
                return dsSrc.Tables[0];
            }
        }
    }
}

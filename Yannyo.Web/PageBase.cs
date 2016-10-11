using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Data;
using Yannyo.Public;
using Yannyo.BLL;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Yannyo.Web
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 系统配置信息
        /// </summary>
        protected internal GeneralConfigInfo config;

        /// <summary>
        /// 当前用户实例
        /// </summary>
        protected internal UserInfo userinfo;
        /// <summary>
        /// 当前用户的用户名
        /// </summary>
        protected internal string username = "";
        /// <summary>
        /// 当前用户的密码
        /// </summary>
        protected internal string password = "";
        /// <summary>
        /// 当前用户的特征串
        /// </summary>
        protected internal string userkey = "";
        /// <summary>
        /// 当前用户的用户ID
        /// </summary>
        protected internal int userid = -1;
        /// <summary>
        /// 用户识别码
        /// </summary>
        protected internal string UserCode = "";
        /// <summary>
        /// 在线用户信息
        /// </summary>
        protected internal OnlineUserInfo oluserinfo;

        /// <summary>
        /// 当前用户的权限代码
        /// </summary>
        protected internal string userpopedom;

        /// <summary>
        /// 当前用户的在线表ID
        /// </summary>
        protected internal int olid;

        /// <summary>
        /// 当前页面是否被POST请求
        /// </summary>
        protected internal bool ispost;
        /// <summary>
        /// 当前页面是否被GET请求
        /// </summary>
        protected internal bool isget;
        /// <summary>
        /// 当前页面是否被GET请求
        /// </summary>
        protected internal bool showmsgboxlink = true;

        /// <summary>
        /// 当前页面标题
        /// </summary>
        protected internal string pagetitle = "页面";

        /// <summary>
        /// 模板id
        /// </summary>
        protected internal int templateid;

        /// 当前模板路径
        /// </summary>
        protected internal string templatepath;

        /// <summary>
        /// 当前日期
        /// </summary>
        protected internal string nowdate;
        /// <summary>
        /// 当前时间
        /// </summary>
        protected internal string nowtime;
        /// <summary>
        /// 当前日期时间
        /// </summary>
        protected internal string nowdatetime;
        /// <summary>
        /// 当前页面Meta字段内容
        /// </summary>
        protected internal string meta = "";
        /// <summary>
        /// 当前页面Link字段内容
        /// </summary>
        protected internal string link;
        /// <summary>
        /// 当前页面中增加script
        /// </summary>
        protected internal string script;
        /// <summary>
        /// 当前页面检查到的错误数
        /// </summary>
        protected internal int page_err = 0;
        /// <summary>
        /// 当前页面检查到的消息数
        /// </summary>
        protected internal int page_msg = 0;
        /// <summary>
        /// 提示文字
        /// </summary>
        protected internal string msgbox_text = "";
        /// <summary>
        /// 是否显示回退的链接
        /// </summary>
        protected internal string msgbox_showbacklink = "true";
        /// <summary>
        /// 回退链接的内容
        /// </summary>
        protected internal string msgbox_backlink = "javascript:history.back();";
        /// <summary>
        /// 返回到的页面url地址
        /// </summary>
        protected internal string msgbox_url = "";

        /// <summary>
        /// 当前在线人数
        /// </summary>
        protected internal int onlineusercount = 1;
        /// <summary>
        /// 页面内容
        /// </summary>
        protected internal System.Text.StringBuilder templateBuilder = new System.Text.StringBuilder();
        /// <summary>
        /// 是否为需检测校验码页面
        /// </summary>
        protected bool isseccode = true;
        /// <summary>
        /// 是否为游客缓存页
        /// </summary>
        protected int isguestcachepage = 0;


        public int Issmileyinsert = 0;

        /// <summary>
        /// 当前页面名称
        /// </summary>
        public string pagename = HTTPRequest.GetPageName();

        /// <summary>
        /// 查询次数统计
        /// </summary>
        public int querycount = 0;

        /// <summary>
        /// 当前页面开始载入时间(毫秒)
        /// </summary>
        private DateTime m_starttick;

        /// <summary>
        /// 当前页面执行时间(毫秒)
        /// </summary>
        private double m_processtime;

#if DEBUG
        public string querydetail = "";
#endif
        public string PageBarHTML = "";

        protected internal string DepartmentsClassToolBarHTML = Caches.GetDepartmentsClassHTML();

        //网店列表
        protected internal DataTable MConfigList;

        //当前网店配置信息
        protected internal M_ConfigInfo M_Config;

        //是否弹出鉴权界面
        protected internal bool ShowMSign = false;

        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        public void SetMetaRefresh()
        {
            SetMetaRefresh(2, msgbox_url);
        }

        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        /// <param name="sec">时间(秒)</param>
        public void SetMetaRefresh(int sec)
        {
            SetMetaRefresh(sec, msgbox_url);
        }
        /// <summary>
        /// 设置对话框是否显示跳转连接
        /// </summary>
        /// <param name="IsShow"></param>
        public void SetShowMsgLink(bool IsShow)
        {
            showmsgboxlink = IsShow;
        }
        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        /// <param name="sec">时间(秒)</param>
        /// <param name="url">转向地址</param>
        public void SetMetaRefresh(int sec, string url)
        {

            meta = meta + "\r\n<meta http-equiv=\"refresh\" content=\"" + sec.ToString() + "; url=" + url + "\" />";
            //AddScript("window.setInterval('location.replace(\"" + url + "\");'," + (sec*1000).ToString() + ");");

        }

        /// <summary>
        /// 插入指定路径的CSS
        /// </summary>
        /// <param name="url">CSS路径</param>
        public void AddLinkCss(string url)
        {
            link = link + "\r\n<link href=\"" + url + "\" rel=\"stylesheet\" type=\"text/css\" />";
        }

        public void AddLinkRss(string url, string title)
        {
            link = link + "\r\n<link rel=\"alternate\" type=\"application/rss+xml\" title=\"" + title + "\" href=\"" + url + "\" />";

        }
        

        /// <summary>
        /// 插入指定路径的CSS
        /// </summary>
        /// <param name="url">CSS路径</param>
        public void AddLinkCss(string url, string linkid)
        {
            link = link + "\r\n<link href=\"" + url + "\" rel=\"stylesheet\" type=\"text/css\" id=\"" + linkid + "\" />";
        }


        /// <summary>
        /// 插入脚本内容到页面head中
        /// </summary>
        /// <param name="scriptstr">不包括<script></script>的脚本主体字符串</param>
        public void AddScript(string scriptstr)
        {
            AddScript(scriptstr, "javascript");
        }

        /// <summary>
        /// 插入脚本内容到页面head中
        /// </summary>
        /// <param name="scriptstr">不包括<script>
        /// <param name="scripttype">脚本类型(值为：vbscript或javascript,默认为javascript)</param>
        public void AddScript(string scriptstr, string scripttype)
        {
            if (!scripttype.ToLower().Equals("vbscript") && !scripttype.ToLower().Equals("vbscript"))
            {
                scripttype = "javascript";
            }
            script = script + "\r\n<script type=\"text/" + scripttype + "\">" + scriptstr + "</script>";
        }

        /// <summary>
        /// 插入指定Meta
        /// </summary>
        /// <param name="metastr">Meta项</param>
        public void AddMeta(string metastr)
        {
            meta = meta + "\r\n<meta " + metastr + " />";
        }

        /// <summary>
        /// 更新页面Meta
        /// </summary>
        /// <param name="Seokeywords">关键词</param>
        /// <param name="Seodescription">说明</param>
        /// <param name="Seohead">其它增加项</param>
        public void UpdateMetaInfo(string Seokeywords, string Seodescription, string Seohead)
        {
            string[] metaArray = Utils.SplitString(meta, "\r\n");
            //设置为空,并在下面代码中进行重新赋值
            meta = "";
            foreach (string metaoption in metaArray)
            {
                //找出keywords关键字
                if (metaoption.ToLower().IndexOf("name=\"keywords\"") > 0)
                {
                    if (Seokeywords != null && Seokeywords.Trim() != "")
                    {
                        meta += "<meta name=\"keywords\" content=\"" + Utils.RemoveHtml(Seokeywords).Replace("\"", " ") + "\" />\r\n";
                        continue;
                    }
                }

                //找出description关键字
                if (metaoption.ToLower().IndexOf("name=\"description\"") > 0)
                {
                    if (Seodescription != null && Seodescription.Trim() != "")
                    {
                        meta += "<meta name=\"description\" content=\"" + Utils.RemoveHtml(Seodescription).Replace("\"", " ") + "\" />\r\n";
                        continue;
                    }
                }

                meta = meta + metaoption + "\r\n";
            }

            // meta = meta + Seohead;
        }

        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        public void CreateExcel(DataTable dt, string fileName)
        {
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
			Response.ContentType = "application/vnd.ms-excel";
            string colHeaders = "", ls_item = "";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化 
            //DataTable dt = ds.Tables[0]; 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的 
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (dt.Columns[i].Caption.GetType() == System.Type.GetType("System.DateTime"))
                {
                    colHeaders += Convert.ToDateTime(dt.Columns[i].Caption.ToString()).ToShortDateString();
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() ;
                }
                if (i == (cl - 1))//最后一列，加n 
                {

                    colHeaders +=  " \n ";
                    
                }
                else
                {
                    colHeaders += " \t ";
                }

            }
            Response.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息 

            //逐行处理数据 
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                for (i = 0; i < cl; i++)
                {
                    if (row[i].GetType() == System.Type.GetType("System.DateTime"))
                    {
                        ls_item += Convert.ToDateTime(row[i].ToString()).ToShortDateString();
                    }
                    else
                    {
                        ls_item += row[i].ToString();
                    }
                    if (i == (cl - 1))//最后一列，加n 
                    {
                        ls_item +=  " \n ";
                    }
                    else
                    {
                        ls_item +=  " \t ";
                    }

                }
                Response.Write(ls_item);
                ls_item = "";
            }
            Response.End();
        }
        /// <summary>
        /// 服务端生成Excel
        /// </summary>
        /// <returns></returns>
        public static string GreateExcelToFile(DataTable dt, string fileName)
        {
            fileName = fileName.Replace("/", "-");
            string FilePath = "/data/ExportData/" + DateTime.Now.Year + "-" + DateTime.Now.Month+"/";
            string colHeaders = "", ls_item = "";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化 
            //DataTable dt = ds.Tables[0]; 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的 
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (dt.Columns[i].Caption.GetType() == System.Type.GetType("System.DateTime"))
                {
                    colHeaders += Convert.ToDateTime(dt.Columns[i].Caption.ToString()).ToShortDateString();
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString();
                }
                if (i == (cl - 1))//最后一列，加n 
                {
                    colHeaders +=  " \n ";
                }
                else
                {
                    colHeaders +=  " \t ";
                }

            }

            //逐行处理数据 
            foreach (DataRow row in myRow)
            {
                for (i = 0; i < cl; i++)
                {
                    if (row[i].GetType() == System.Type.GetType("System.DateTime"))
                    {
                        ls_item += Convert.ToDateTime(row[i].ToString()).ToShortDateString();
                    }
                    else
                    {
                        ls_item += row[i].ToString();
                    }
                    if (i == (cl - 1))//最后一列，加n 
                    {
                        ls_item +=  " \n ";
                    }
                    else
                    {
                        ls_item +=  " \t ";
                    }

                }
            }
            if (StrToFile(colHeaders + ls_item, FilePath, fileName))
            {
                return FilePath + fileName;
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 字符串保存成文件
        /// </summary>
        /// <returns></returns>
        public static bool StrToFile(string Str,string FilePath,string FileName)
        {
            try
            {
                FilePath = Utils.GetMapPath(FilePath);
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                StreamWriter sw = new StreamWriter(File.Create(FilePath + "/" + FileName.Replace("/", "-")), Encoding.Default); 
                //StreamWriter sw = File.CreateText(FilePath + "/" + FileName.Replace("/","-"));
                try
                {
                    sw.Write(Str);
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            }
            catch {
                return false;
            }
        }
        /// <summary>
        /// 添加页面Meta信息
        /// </summary>
        /// <param name="Seokeywords">关键词</param>
        /// <param name="Seodescription">说明</param>
        /// <param name="Seohead">其它增加项</param>
        public void AddMetaInfo(string Seokeywords, string Seodescription, string Seohead)
        {
            if (Seokeywords != "")
            {
                meta = meta + "<meta name=\"keywords\" content=\"" + Utils.RemoveHtml(Seokeywords).Replace("\"", " ") + "\" />\r\n";
            }
            if (Seodescription != "")
            {
                meta = meta + "<meta name=\"description\" content=\"" + Utils.RemoveHtml(Seodescription).Replace("\"", " ") + "\" />\r\n";
            }
            meta = meta + Seohead;
        }

        /// <summary>
        /// 增加错误提示
        /// </summary>
        /// <param name="errinfo">错误提示信息</param>
        public void AddErrLine(string errinfo)
        {
            if (msgbox_text.Length == 0)
            {
                msgbox_text = msgbox_text + errinfo;
            }
            else
            {
                msgbox_text = msgbox_text + "<br />" + errinfo;
            }
            page_err++;
        }

		/// <summary>
		/// 显示授权码输入框
		/// </summary>
		public void ShowRCodeInput(string s_r_Code){


			if (config.ProductCostPriceCodeMail.Trim () != "") {

				msgbox_text = msgbox_text + "<br>校验码：<form action=\"\" name=\"rCodeForm\" id=\"rCodeForm\">\n<input name=\"rCode\" type=\"text\" id=\"rCode\" value=\"\" size=\"6\" maxlength=\"6\"/>\n <button type=\"button\" name=\"sCodeButton\" id=\"sCodeButton\"  >发送校验码</button> <button type=\"submit\" name=\"rCodeButton\" id=\"rCodeButton\"  >提交</button>\n</form>";
			} else {
				msgbox_text = msgbox_text + "<b>请配置校验码收取邮箱！</b>";
			}


			page_err++;
		}

		/// <summary>
		/// 生成验证码字符串
		/// </summary>
		/// <param name="codeLen">验证码字符长度</param>
		/// <returns>返回验证码字符串</returns>
		public string MakeCode(int codeLen)
		{
			if (codeLen < 1)
			{
				return string.Empty;
			}

			int number;
			string checkCode = string.Empty;
			Random random = new Random();

			for (int index = 0; index < codeLen; index++)
			{
				number = random.Next();

				if (number % 2 == 0)     
				{
					checkCode += (char)('0' + (char)(number % 10));     //生成数字
				}
				else
				{
					checkCode += (char)('A' + (char)(number % 26));     //生成字母
				}
			}

			return checkCode;
		}

        /// <summary>
        /// 增加提示信息
        /// </summary>
        /// <param name="strinfo">提示信息</param>
        public void AddMsgLine(string strinfo)
        {
            if (msgbox_text.Length == 0)
            {
                msgbox_text = msgbox_text + strinfo;
            }
            else
            {
                msgbox_text = msgbox_text + "<br />" + strinfo;
            }
            page_msg++;
        }


        /// <summary>
        /// 是否已经发生错误
        /// </summary>
        /// <returns>有错误则返回true, 无错误则返回false</returns>
        public bool IsErr()
        {
            return page_err > 0;
        }

        /// <summary>
        /// 设置要转向的url
        /// </summary>
        /// <param name="strurl">要转向的url</param>
        public void SetUrl(string strurl)
        {
            msgbox_url = strurl;
        }
        /// <summary>
        /// 设置回退链接的内容
        /// </summary>
        /// <param name="strback">回退链接的内容</param>
        public void SetBackLink(string strback)
        {
            msgbox_backlink = strback;
        }

        /// <summary>
        /// 设置是否显示回退链接
        /// </summary>
        /// <param name="link">要显示则为true, 否则为false</param>
        public void SetShowBackLink(bool link)
        {
            if (link)
            {
                msgbox_showbacklink = "true";
            }
            else
            {
                msgbox_showbacklink = "false";
            }
        }

        public void ShowMessage(byte mode)
        {
            ShowMessage("", mode);
        }

        public void ShowMessage(string hint, byte mode)
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head><title>");
            string title;
            string body;
            switch (mode)
            {
                case 1:
                    title = "系统维护暂时关闭";
                    body = config.Closedreason;
                    break;
                case 2:
                    title = "禁止访问";
                    body = hint;
                    break;
                default:
                    title = "提示";
                    body = hint;
                    break;
            }
            System.Web.HttpContext.Current.Response.Write(title);
            System.Web.HttpContext.Current.Response.Write("</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            System.Web.HttpContext.Current.Response.Write(meta);
            System.Web.HttpContext.Current.Response.Write("<style type=\"text/css\"><!-- body { margin: 20px; font-family: Tahoma, Verdana; font-size: 14px; color: #333333; background-color: #FFFFFF; }a {color: #1F4881;text-decoration: none;}--></style></head><body><div style=\"border: #cccccc solid 1px; padding: 20px; width: 500px; margin:auto\" align=\"center\">");
            System.Web.HttpContext.Current.Response.Write(body);
            System.Web.HttpContext.Current.Response.Write("</div><br /><br /><br /><div style=\"border: 0px; padding: 0px; width: 500px; margin:auto\"><strong>当前服务器时间:</strong> ");
            System.Web.HttpContext.Current.Response.Write(Utils.GetDateTime());
            System.Web.HttpContext.Current.Response.Write("<br /><strong>当前页面</strong> ");
            System.Web.HttpContext.Current.Response.Write(pagename);
            System.Web.HttpContext.Current.Response.Write("<br /><strong>可选择操作:</strong> ");
            if (userkey == "")
            {
                System.Web.HttpContext.Current.Response.Write("<a href=\"Login.aspx\">登录</a> | <a href=\"Register.aspx\">注册</a>");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<a href=\"Logout.aspx?userkey=" + userkey + "\">退出</a>");
            }
            System.Web.HttpContext.Current.Response.Write("</div></body></html>");
            System.Web.HttpContext.Current.Response.End();
        }

        public void ShowMSGBox()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head><title>");
            string title;
            string body;

            title = "提示";
            body = msgbox_text;

            System.Web.HttpContext.Current.Response.Write(title);
            System.Web.HttpContext.Current.Response.Write("</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            System.Web.HttpContext.Current.Response.Write(meta);
            System.Web.HttpContext.Current.Response.Write("<style type=\"text/css\"><!-- body { margin: 20px; font-family: Tahoma, Verdana; font-size: 14px; color: #333333; background-color: #FFFFFF; }a {color: #1F4881;text-decoration: none;}--></style></head><body><div style=\"border: #cccccc solid 1px; padding: 20px; width: 80%; margin:auto\" align=\"center\">");
            System.Web.HttpContext.Current.Response.Write(body);
            System.Web.HttpContext.Current.Response.Write(script);
            System.Web.HttpContext.Current.Response.Write("</div><br /><br /><br /><div style=\"border: 0px; padding: 0px; width: 500px; margin:auto\"><strong>当前服务器时间:</strong> ");
            System.Web.HttpContext.Current.Response.Write(Utils.GetDateTime());
            System.Web.HttpContext.Current.Response.Write("<br /><strong>当前页面</strong> ");
            System.Web.HttpContext.Current.Response.Write(pagename);
            if (showmsgboxlink)
            {
                System.Web.HttpContext.Current.Response.Write("<br /><strong>可选择操作:</strong> ");

                System.Web.HttpContext.Current.Response.Write("<a href=\"Login.aspx\">登录</a> | <a href=\"Register.aspx\">注册</a>");
            }
            System.Web.HttpContext.Current.Response.Write("</div></body></html>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 直接跳转到设定页面
        /// </summary>
        public void GoRefresh()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head><title>");
            string title;
            string body;

            title = "页面转接中...";
            body = msgbox_text+"<br>页面转接中,请稍后...";
            System.Web.HttpContext.Current.Response.Write(title);
            System.Web.HttpContext.Current.Response.Write("</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            System.Web.HttpContext.Current.Response.Write("<style type=\"text/css\"><!-- body { margin: 20px; font-family: Tahoma, Verdana; font-size: 14px; color: #333333; background-color: #FFFFFF; }a {color: #1F4881;text-decoration: none;}--></style></head><body><div style=\"border: #cccccc solid 1px; padding: 20px; width: 500px; margin:auto\" align=\"center\">");
            System.Web.HttpContext.Current.Response.Write(body);
            System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\" language=\"javascript\">location='" + msgbox_url + "';</script>");
            System.Web.HttpContext.Current.Response.Write("</div><br /><br /><br /><div style=\"border: 0px; padding: 0px; width: 500px; margin:auto\"><strong>当前服务器时间:</strong> ");
            System.Web.HttpContext.Current.Response.Write(Utils.GetDateTime());
            System.Web.HttpContext.Current.Response.Write("</div></body></html>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        public bool CheckUser()
        {
            userid = Utils.StrToInt(Utils.GetCookie(config.CookieTag, "userid"), -1);
            password = UsersUtils.GetCookiePassword(config.Passwordkey);
            if (userid > 0)
            {
                userid = tbUserInfo.CheckPassword(userid, password, false);
                UserCode = Utils.UrlEncode(DES.Encode(this.userid + "$|$" + password, config.Passwordkey));
            }
            else {
                if (HTTPRequest.GetString("UserCode").Trim() != "")
                {
                    string UserCode = DES.Decode(HTTPRequest.GetString("UserCode").Trim(), config.Passwordkey);
                  if (UserCode.Trim() != "")
                  {
                      string[] UserCodeArr = Utils.SplitString(UserCode.Trim(), "$|$");
                      if (UserCodeArr.Length == 2)
                      {
                          userid =Convert.ToInt32(UserCodeArr[0]);
                          password = UserCodeArr[1].Trim();
                          if (userid > 0)
                          {
                              userid = tbUserInfo.CheckPassword(userid, password, false);
                          }
                      }
                  }
                }
            }
            return userid > 0;
        }

        /// <summary>
        /// 得到当前页面的载入时间供模板中调用(单位:毫秒)
        /// </summary>
        /// <returns>当前页面的载入时间</returns>
        public double Processtime
        {
            get { return m_processtime; }
        }

        /// <summary>
        /// 当前页面URL是否包含指定字符串
        /// </summary>
        public bool CheckPageUrl(string cStr)
        {
            return HTTPRequest.GetRawUrl().IndexOf(cStr) == 1;
        }

        public string FormatBr(string tStr)
        {
            return tStr.Replace("\r\n", "<br>").Replace("\n", "<br />");
        }

        /// <summary>
        /// 验证用户指定权限
        /// </summary>
        public bool CheckUserPopedoms(string PopedomsID)
        {
            bool re = false;
            if (this.userpopedom != "")
            {
                string tp = ","+this.userpopedom+",";
                if (tp.IndexOf("," + PopedomsID + ",") > -1)
                {
                    re = true;
                }
                else
                {
                    //是否上级权限
                    string[] uparray = Utils.SplitString(tp, ",");
                    string _p = UsersUtils.GetUserPopedomByPopedomIDUp(PopedomsID);
                    if (_p.Trim() != "")
                    {
                        _p = ','+_p.Trim();
                    }
                    foreach (string up in uparray)
                    {
                        if (_p.IndexOf("," + up + ",") > -1)
                        {
                            re = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                re = false;
            }
            return re;
        }
        /// <summary>
        /// 验证用户指定权限
        /// </summary>
        public bool CheckUserPopedoms(string PopedomsID,string pStr)
        {
            if (this.userpopedom != "")
            {
                string tp = "," + pStr + ",";
                if (tp.IndexOf("," + PopedomsID + ",") > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 返回人员数组
        /// </summary>
        public DataTable StaffTypeList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeID", typeof(int));
            dt.Columns.Add("TypeName", typeof(string));

            DataRow dr = dt.NewRow();
            dr["TypeID"] = 0;
            dr["TypeName"] = "公司";
            dt.Rows.Add(dr);

            DataRow dr2 = dt.NewRow();
            dr2["TypeID"] = 1;
            dr2["TypeName"] = "业务员";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["TypeID"] = 2;
            dr3["TypeName"] = "促销员";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["TypeID"] = 3;
            dr4["TypeName"] = "其他";
            dt.Rows.Add(dr4);

            dt.AcceptChanges();

            return dt;
        }
        /// <summary>
        /// 返回人员类型
        /// </summary>
        public string GetStaffTypeStr(string sType)
        {
            string reStr = "";
            DataTable dt = StaffTypeList();
            try 
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["TypeID"].ToString() == sType)
                    {
                        reStr = dr["TypeName"].ToString();
                    }
                }            
            }
            finally
            {
                dt.Clear();
            }
            return reStr;
        }

        /// <summary>
        /// 返回单据类型
        /// </summary>
        /// <param name="oType"></param>
        /// <returns></returns>
        public string GetOrderType(string oType)
        {
            string reStr = "";
            try
            {
                foreach (Orders.Order_Type.Rewrite _Type in Orders.Order_Type.GetOrderType().OrderType)
                {
                    if (_Type.ID.ToString() == oType.Trim())
                    {
                        reStr = _Type.Name;
                    }
                }
                return reStr;
            }
            catch {
                return reStr;
            }
        }
        /// <summary>
        /// 凭证类型
        /// </summary>
        /// <param name="cType"></param>
        /// <returns></returns>
        public string GetCertificateType(string cType)
        {
            
            return (((cType == "0" )? "收款" : (cType == "1") ? "付款" : cType) == "2" )? "其他" : "";
        }
        
        /// <summary>
        /// 返回字段类型
        /// </summary>
        /// <param name="fType"></param>
        /// <returns></returns>
        public string GetFieldType(string fType)
        {
            string reStr = "";
            try
            {
                foreach (Orders.OrderFieldTypes.Rewrite _Type in Caches.GetOrderFieldType().FieldTypes)
                {
                    if (_Type.ID.ToString() == fType.Trim())
                    {
                        reStr = _Type.Name;
                    }
                }
                return reStr;
            }
            catch
            {
                return reStr;
            }
        }
        /// <summary>
        /// 返回单据步骤
        /// </summary>
        /// <param name="fType"></param>
        /// <returns></returns>
        public string GetOrderStpes(string Stpes)
        {
            string reStr = "";
            try
            {
                foreach (Orders.OrderSteps.Rewrite _Steps in Caches.GetOrderSteps().OrderStep)
                {
                    if (_Steps.ID.ToString() == Stpes.Trim())
                    {
                        reStr = _Steps.Name;
                    }
                }
                return reStr;
            }
            catch
            {
                return reStr;
            }
        }


     /// <summary>金额转大写    
     ///     
     /// </summary>    
     /// <param name="LowerMoney"></param>    
     /// <returns></returns>    
        public string MoneyToChinese(string LowerMoney)
        {
            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数    
            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数    
                LowerMoney = LowerMoney.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4    
            LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();
            if (LowerMoney.IndexOf(".") > 0)
            {
                if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
                {
                    LowerMoney = LowerMoney + "0";
                }
            }
            else
            {
                LowerMoney = LowerMoney + ".00";
            }
            strLower = LowerMoney;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "圆";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理    
            if (strUpper.Substring(0, 1) == "圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }

        /// <summary>
        /// 科目所有父路径
        /// </summary>
        /// <param name="FeesSubjectClassID"></param>
        /// <param name="sStr"></param>
        /// <returns></returns>
        public string GetFeesSubjectClassParentStr(int FeesSubjectClassID, string sStr)
        {
            return DataClass.GetFeesSubjectClassParentStr(FeesSubjectClassID, sStr);
        }

        public string chang(string money)
        {

            return MoneyToChinese(money);
            /*
            decimal MyNumber = Convert.ToDecimal(money);
            int aa = (int)(MyNumber * 100);
            MyNumber = Convert.ToDecimal(aa / 100.0);
            money = MyNumber.ToString();
            String[] MyScale = { "分", "角", "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "兆", "拾", "佰", "仟" };
            String[] MyBase = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            String M = "";
            bool isPoint = false;
            if (money.IndexOf(".") != -1)
            {
                money = money.Remove(money.IndexOf("."), 1);
                isPoint = true;
            }
            for (int i = money.Length; i > 0; i--)
            {
                int MyData = Convert.ToInt16(money[money.Length - i].ToString());
                M += MyBase[MyData];
                if (isPoint == true)
                {
                    M += MyScale[i - 1];
                }
                else
                {
                    M += MyScale[i + 1];
                }
            }
            return M;*/
        }
        /// <summary>
        /// 文件类型验证
        /// </summary>
        public enum FileExtension
        {
            JPG = 255216,
            GIF = 7173,
            PNG = 13780,
            SWF = 6787,
            RAR = 8297,
            _7Z = 55122,
            BMP = 6677,
            XLSX = 208207,
            XLS = 8075

            // 6787 swf

            // 7790 exe dll,

            // 8297 rar

            // 8075 zip

            // 55122 7z

            // 6063 xml

            // 6033 html

            // 239187 aspx

            // 117115 cs

            // 119105 js

            // 102100 txt

            // 255254 sql 

        }

        public class FileValidation
        {
            public static bool IsAllowedExtension(MemoryStream ms, FileExtension[] fileEx)
            {
                System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
                string fileclass = "";
                byte buffer;
                try
                {
                    buffer = br.ReadByte();
                    fileclass = buffer.ToString();
                    buffer = br.ReadByte();
                    fileclass += buffer.ToString();
                }
                catch
                {
                }
                br.Close();
                ms.Close();
                foreach (FileExtension fe in fileEx)
                {
                    if (Int32.Parse(fileclass) == (int)fe)
                        return true;
                }
                return false;
            }
            public static bool IsAllowedExtension(FileUpload fu, FileExtension[] fileEx)
            {
                int fileLen = fu.PostedFile.ContentLength;
                byte[] imgArray = new byte[fileLen];
                fu.PostedFile.InputStream.Read(imgArray, 0, fileLen);
                MemoryStream ms = new MemoryStream(imgArray);
                System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
                string fileclass = "";
                byte buffer;
                try
                {
                    buffer = br.ReadByte();
                    fileclass = buffer.ToString();
                    buffer = br.ReadByte();
                    fileclass += buffer.ToString();
                }
                catch
                {
                }
                br.Close();
                ms.Close();
                foreach (FileExtension fe in fileEx)
                {
                    if (Int32.Parse(fileclass) == (int)fe)
                        return true;
                }
                return false;
            }
            public static bool IsAllowedExtension(HttpPostedFile pu, FileExtension[] fileEx)
            {
                int fileLen = pu.ContentLength;
                byte[] imgArray = new byte[fileLen];
                pu.InputStream.Read(imgArray, 0, fileLen);
                MemoryStream ms = new MemoryStream(imgArray);
                System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
                string fileclass = "";
                byte buffer;
                try
                {
                    buffer = br.ReadByte();
                    fileclass = buffer.ToString();
                    buffer = br.ReadByte();
                    fileclass += buffer.ToString();
                }
                catch
                {
                }
                br.Close();
                ms.Close();
                foreach (FileExtension fe in fileEx)
                {
                    if (Int32.Parse(fileclass) == (int)fe)
                        return true;
                }
                return false;
            }


        }

		public string GetIP(){
			string text = string.Empty;
			text = HttpContext.Current.Request.ServerVariables ["HTTP_X_FORWARDED_FOR"];
			if (string.IsNullOrEmpty (text))
			{
				text = HttpContext.Current.Request.ServerVariables ["HTTP_CLIENT_IP"];
			}
			if (string.IsNullOrEmpty (text))
			{
				text = HttpContext.Current.Request.ServerVariables ["REMOTE_ADDR"];
			}
			if (string.IsNullOrEmpty (text))
			{
				text = HttpContext.Current.Request.UserHostAddress;
			}
			string result;
			if (string.IsNullOrEmpty (text) || !Utils.IsIP (text))
			{
				result = "127.0.0.1";
			}
			else
			{
				result = text;
			}
			return result;
		}


        /// <summary>
        /// BasePage类构造函数
        /// </summary>
        public PageBase()
        {
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);

            System.Web.HttpContext.Current.Response.Expires = 0;

            //清理缓存
            if(HTTPRequest.GetInt("CachesClear",0)==1)
            {
                Caches.ReSet();
                System.Web.HttpContext.Current.Response.End();
            }




            string cookietag = GeneralConfigs.GetConfig().CookieTag.Trim();
            config = GeneralConfigs.GetConfig();
            MConfigList = Caches.GetMConfigList();//网店列表

            //取当前网店信息
            int mconfigid = HTTPRequest.GetInt("mconfigid",0);
            if(mconfigid>0)
            {
                M_Config = Caches.GetMConfig(mconfigid);

                //是否沙箱模式
                if (config.Taobao_SandBox == 1)
                {
                    //SessioKey是否超过30分钟
                    if (DateTime.Now.Subtract(M_Config.m_UpdateTime).TotalMinutes >= 30)
                    {
                        ShowMSign = true;//弹出授权框
                    }
                }
            }
            
            if (CheckUser())
            {
                userinfo = Yannyo.BLL.tbUserInfo.GetUserInfoModel(userid);
                userpopedom = userinfo.uPermissions;
                username = userinfo.uName;
            }

            //清空当前页面查询统计
            Yannyo.Data.DbHelper.QueryCount = 0;
#if NET1
#else
#if DEBUG
            Yannyo.Data.DbHelper.QueryDetail = "";
#endif
#endif

            AddMetaInfo(config.Seokeywords, config.Seodescription, config.Seohead);


            System.Web.HttpContext.Current.Response.BufferOutput = false;
            System.Web.HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            System.Web.HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            System.Web.HttpContext.Current.Response.Expires = 0;
            System.Web.HttpContext.Current.Response.CacheControl = "no-cache";
            System.Web.HttpContext.Current.Response.Cache.SetNoStore();

            try
            {
                oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
            }
            catch
            {
                System.Threading.Thread.Sleep(2000);
                oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
            }

            olid = oluserinfo.olID;

            if (config.Onlinetimeout > 0 && userid != -1)
            {
                onlineusercount = OnlineUsers.GetOnlineAllUserCount();
            }
            else
            {
                onlineusercount = OnlineUsers.GetCacheOnlineAllUserCount();
            }

            if (userid != -1)
            {
                //更新用户在线时长
                OnlineUsers.UpdateOnlineTime(config.Oltimespan, userid);

                string ignore = HTTPRequest.GetString("ignore");
            }

            templateid = 1;
            templatepath = Templates.GetTemplateItem(templateid).Directory;

            nowdate = Utils.GetDate();
            nowtime = Utils.GetTime();
            nowdatetime = Utils.GetDateTime();


            ispost = HTTPRequest.IsPost();
            isget = HTTPRequest.IsGet();

            link = "";

            script = "";

            m_starttick = DateTime.Now;

            ShowPage();

            //m_processtime = //(System.Environment.TickCount - m_starttick) / 1000;
            m_processtime = DateTime.Now.Subtract(m_starttick).TotalMilliseconds / 1000;

            querycount = Yannyo.Data.DbHelper.QueryCount;
            Yannyo.Data.DbHelper.QueryCount = 0;
#if NET1
#else
#if DEBUG

            querydetail = Yannyo.Data.DbHelper.QueryDetail;
            Yannyo.Data.DbHelper.QueryDetail = "";
#endif
#endif

        }
        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            return;
        }

        /// <summary>
        /// 调用Page_Load事件
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }


        /// <summary>
        /// OnUnload事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        /// <summary>
        /// 控件初始化时计算执行时间
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (isguestcachepage == 1)
            {
                m_processtime = 0;
            }
            base.OnInit(e);
        }

        protected string aspxrewriteurl = "";
    }
}

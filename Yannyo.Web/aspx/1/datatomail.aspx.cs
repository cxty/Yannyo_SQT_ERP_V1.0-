using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class datatomail : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") )
                {
                    pagesize = 20;
                    PageBarHTML = "";
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }

                    dList = tbDataToMailInfo.GetDataToMailInfoList(pagesize, pageindex, "", out pagetotal, 1, "*");
                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "");
                }
                else
                {
                    AddErrLine("权限不足!");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 导出数据转发邮件 计划任务";
            this.Load += new EventHandler(this.Page_Load);
        }
        public string GetDataTypeName(int dDataType)
        {
           
            string tname = "";
            DataTable DataTypes = new DataTable();
            DataTypes = tbDataToMailInfo.GetDataToMailDataTypes();
            foreach (DataRow dr in DataTypes.Rows)
            {
                if (Convert.ToInt32(dr["id"].ToString()) == dDataType)
                {
                    tname = dr["name"].ToString();
                    break;
                }
            }
            return tname;
        }
    }
}
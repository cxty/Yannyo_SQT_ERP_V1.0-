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
using System.IO;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class storehousestorageselected : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable pList = new DataTable();
        public DateTime sDate = DateTime.Now;
        public string sName = "";
        public int sId;
        public DateTime bDate=DateTime.Now.AddDays(-(DateTime.Now.Day)+1);
        public DateTime eDate=DateTime.Now;

        public string Act;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-6-2"))
                {
                    dList = storehouseStorage.SnameBindDropdownlist();
                    Act = HTTPRequest.GetString("Act");
                    if (ispost)
                    {
                        sName = HTTPRequest.GetString("sName");
                        bDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
                        eDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
                        sId = Convert.ToInt32(HTTPRequest.GetString("StoresID"));
                        pList = storehouseStorage.SelectStorageData(sId, bDate, eDate);
                    }
                    else
                    {
                        if (Act.IndexOf("act") > -1)
                        {
                            bDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
                            eDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
                            sId = HTTPRequest.GetInt("StoresID", 0);
                            if (sId > 0)
                            {
                                pList = storehouseStorage.SelectStorageData(sId, bDate, eDate);
                                DataTable dt = pList.Copy();
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);
                                ds.Tables[0].Columns[0].ColumnName = "商品条码";
                                ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                ds.Tables[0].Columns[2].ColumnName = "数量";
                                ds.Tables[0].Columns[3].ColumnName = "金额";
                                ds.Tables[0].Columns[4].ColumnName = "导入时间";
                                ds.Tables[0].Columns[5].ColumnName = "系统时间";
                                CreateExcel(ds.Tables[0], "联营库存导入详情_" + DateTime.Now.ToString("yyy-MM-dd") + ".xls");
                            }
                            else
                            {
                                AddErrLine("请正确选择门店编号!");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
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
            pagetitle = "查询客户库存导入数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
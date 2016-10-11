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
    public partial class diqu_edit : PageBase
    {
        public RegionInfo pi = new RegionInfo();
        public int regionClassID;
        public string rClassName = "";
        public DateTime dAppendTime = DateTime.Now;
        public string Act = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-5"))
                {
                    Act = HTTPRequest.GetString("Act");
                    rClassName = HTTPRequest.GetString("tName").Trim();
                    regionClassID = HTTPRequest.GetInt("classID", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();
                    if (regionClassID > 0)
                    {
                        pi = tbRegionInfo.GetRegionInfoModel(regionClassID);
                    }

                    if (ispost)
                    {
                        //添加
                        if (Act.IndexOf("add") > -1)
                        {
                            RegionInfo li = new RegionInfo();
                            if (rClassName != "")
                            {
                                li.rUpID = regionClassID;
                                li.rName = rClassName;
                                li.rOrder = HTTPRequest.GetInt("tOrder", 0);
                                li.rAppendTime = DateTime.Now;

                                bool hValue = tbRegionInfo.ExistsRegionInfo(HTTPRequest.GetString("tName"), regionClassID);
                                if (hValue)
                                {
                                    AddErrLine("操作失败，该条分类已经存在，请核对后重新添加！");
                                }
                                else
                                {
                                    int addCount = tbRegionInfo.AddRegionInfo(li);
                                    if (addCount > 0)
                                    {
                                        //记录成功操作
                                        Logs.AddEventLog(this.userid, "添加" + rClassName + "地区分类");
                                        AddMsgLine("操作成功！");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("操作失败，请重新添加！");
                                    }
                                }
                            }
                            else
                            {
                                AddErrLine("操作失败，请重新添加！");
                            }
                        }
                        //修改
                        if (Act.IndexOf("update") > -1)
                        {
                            if (rClassName != "")
                            {
                                pi.RegionID = regionClassID;
                                pi.rName = rClassName;
                                pi.rAppendTime = DateTime.Now;

                                int count = tbRegionInfo.UpdateRegionInfo(pi);
                                if (count > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "地区修改为" + rClassName);
                                    AddMsgLine("修改成功！");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("修改失败！");
                                }
                            }
                            else
                            {
                                AddErrLine("修改失败！");
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
            pagetitle = "地区分类信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
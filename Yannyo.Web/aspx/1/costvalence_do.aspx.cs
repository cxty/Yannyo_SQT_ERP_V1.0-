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
    public partial class costvalence_do : PageBase
    {
        public CostValenceInfo ci = new CostValenceInfo();
        public string Act = "";
        public int CostValenceID = 0;
        public int ProductsID = 0;
        public float cPrice = 0;
        public DateTime cDateTime = DateTime.Now;
        public DateTime cAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("5-2"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        CostValenceID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);

                        ci = tbCostValenceInfo.GetCostValenceInfoModel(CostValenceID);
                    }
                    if (ispost)
                    {
                        ProductsID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductsID")), 0);
                        cPrice = Utils.StrToFloat(Utils.ChkSQL(HTTPRequest.GetString("cPrice")), 0);
                        cDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("cDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("cDateTime"))) : DateTime.Now;
                        

                        ci.ProductsID = ProductsID;
                        ci.cPrice = decimal.Parse(cPrice.ToString());
                        ci.cDateTime = cDateTime;

                        if (ProductsID > 0)
                        {
                            if (Act == "Add")
                            {
                                if (!tbCostValenceInfo.ExistsCostValenceInfo(ProductsID, cDateTime))
                                {
                                    ci.cAppendTime = cAppendTime;
                                    if (tbCostValenceInfo.AddCostValenceInfo(ci) > 0)
                                    {
                                        AddMsgLine("创建成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("创建失败!");
                                        AddScript("history.back(1);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("该产品" + cAppendTime.ToString() + ",已经有新成本变动数据了!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            if (Act == "Edit")
                            {

                                bool IsOK = false;

                                if (ci.cDateTime != cDateTime)
                                {
                                    if (!tbCostValenceInfo.ExistsCostValenceInfo(ProductsID, cDateTime))
                                    {
                                        IsOK = true;
                                    }
                                    else
                                    {
                                        IsOK = false;
                                    }
                                }
                                else
                                {
                                    IsOK = true;
                                }
                                if (IsOK)
                                {
                                    try
                                    {
                                        tbCostValenceInfo.UpdateCostValenceInfo(ci);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("该产品" + cAppendTime.ToString() + ",已经有新成本变动数据了!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }

                            }
                        }
                        else
                        {
                            AddErrLine("产品不能为空!");
                            AddScript("window.setTimeout('history.back(1);',1000);");
                        }

                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbCostValenceInfo.DeleteCostValenceInfo(HTTPRequest.GetString("cid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("创建失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 添加修改成本变动数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

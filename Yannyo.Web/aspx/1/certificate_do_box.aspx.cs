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
    public partial class certificate_do_box : PageBase
    {
        public int OrderID = 0;
        public int ordertype = 0;
        public int CertificateID = 0;
        public DataTable dList = new DataTable();
        public decimal SumMoney = 0;//合计金额
        public string Act = "";
        public string cNumber = "";
        public int cType = -1;
        public string cDateTimeB = "";
        public string cDateTimeE = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-2"))
                {
                    string tSQL = "";
                    OrderID = HTTPRequest.GetInt("orderid", 0);
                    ordertype = HTTPRequest.GetInt("ordertype", 0);
                    Act = HTTPRequest.GetString("Act");

                    if (!ispost)
                    {
                        //对账时使用
                        if (Act == "s")
                        {
                            //int sObjectType = HTTPRequest.GetInt("sObjectType", -1);
                            //int sObjectID = HTTPRequest.GetInt("sObjectID", -1);
                            //if (sObjectType > -1 && sObjectID > -1)
                            //{

                            //    tSQL = "cObject=0 and toObject=" + sObjectType + " and toObjectID=" + sObjectID + " and cState=0";

                            //    cCode = Utils.ChkSQL(HTTPRequest.GetServerString("cCode"));
                            //    if (cCode.Trim() != "")
                            //    {
                            //        tSQL += " and cCode like '%" + cCode + "%'";
                            //    }
                            //    cType = HTTPRequest.GetInt("cType", -1);
                            //    if (cType > -1)
                            //    {
                            //        tSQL += " and cType=" + cType;
                            //    }

                            //    dList = Certificates.GetCertificateInfoList(tSQL+"  order by cDateTime desc").Tables[0];
                            //}
                            //else {
                            //    dList = Certificates.GetCertificateInfoList(" cObject=0 and cState=0 order by cDateTime desc").Tables[0];
                            //}
                            tSQL = " cObject=0 and cState=0  ";
                            cNumber = HTTPRequest.GetString("cNumber");
                            if (Utils.StrToInt(cNumber, 0) > 0)
                            {
                                tSQL += " and cNumber = " + cNumber + "";
                            }
                            cType = HTTPRequest.GetInt("cType", -1);
                            if (cType > -1)
                            {
                                tSQL += " and cType=" + cType;
                            }
                            cDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("cDateTimeB"));
                            if (cDateTimeB.Trim() != "" && Utils.IsDateString(cDateTimeB.Trim()))
                            {
                                tSQL += " and cDateTime>='" + cDateTimeB.Trim() + "  00:00:00 '";
                            }
                            cDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("cDateTimeE"));
                            if (cDateTimeE.Trim() != "" && Utils.IsDateString(cDateTimeE.Trim()))
                            {
                                tSQL += " and cDateTime<='" + cDateTimeE.Trim() + "  23:59:59 '";
                            }
                            dList = Certificates.GetCertificateInfoList(tSQL+" order by cDateTime desc").Tables[0];

                        }
                        else
                        {
                            dList = Certificates.GetCertificateInfoList(" cObject=1 and cObjectID=" + OrderID + " and cState=0 order by cDateTime desc").Tables[0];
                        }
                    }
                    else
                    {
                        
                        string CertificateIDStr = HTTPRequest.GetString("CertificateIDStr");//凭证系统编号集合,逗号分割
                        string tMsg = "";
                        string format = "";
                        //json操作部分,返回json
                        if (Act == "Finish")//凭证随附操作完成
                        {
                            format = "json";
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-10"))
                            {
                                try
                                {
                                    OrderInfo oi = Orders.GetOrderInfoModel(OrderID);
                                    if (oi != null)
                                    {
                                        if (oi.oState != 1)
                                        {
                                            if (oi.oSteps == 2)
                                            {
                                                oi.oSteps = 3;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                                decimal _sumMoney = 0;

                                                if (CertificateIDStr.Trim() != "")
                                                {
                                                    string[] CertificateIDStrArray = Utils.SplitString(CertificateIDStr, ",");
                                                    if (CertificateIDStrArray.Length > 0)
                                                    {

                                                        CertificateInfo _ci = new CertificateInfo();
                                                        try
                                                        {
                                                            foreach (string _tStr in CertificateIDStrArray)
                                                            {
                                                                if (_tStr.Trim() != "")
                                                                {
                                                                    _ci = Certificates.GetCertificateInfoModel(Convert.ToInt32(_tStr));
                                                                    if (_ci != null)
                                                                    {
                                                                        _sumMoney += _ci.cMoney;
                                                                        tMsg += "凭证号:" + _ci.cCode + ",单位:" + _ci.toObjectName + ",金额:" + _ci.cMoney + ";";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            _ci = null;
                                                        }
                                                    }
                                                }

                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 9;
                                                owl.oMsg = (tMsg.Trim() != "") ? "随附凭证,合计金额:" + _sumMoney.ToString() + ",凭证摘要:" + tMsg + " ,完成财务操作." : "没有任何凭证随附.";
                                                owl.pAppendTime = DateTime.Now;

                                                Orders.AddOrderWorkingLogInfo(owl);

                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 3;
                                                owl.oMsg = "系统自动发货处理,等待收货.";
                                                owl.pAppendTime = DateTime.Now;

                                                Orders.AddOrderWorkingLogInfo(owl);

                                                AddMsgLine("发货 操作成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("单据非 已审核 待 发货 状态,无法进行 发货 操作!请重试!");
                                            }
                                        }
                                        else
                                        {
                                            AddErrLine("此单已作废!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误,该单据不存在!请重试!");
                                    }
                                }
                                catch
                                {
                                    AddErrLine("发货 操作失败!请重试!");
                                }
                            }
                            else {
                                AddErrLine("权限不足!");
                            }
                        }
                        

                        if (format == "json")
                        {
                            Response.ClearContent();
                            Response.Buffer = true;
                            Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                            Response.Expires = 0;

                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            Response.ContentType = "application/json";
                            string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"}}";
                            Response.Write(Json_Str);
                            Response.End();
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
            pagetitle = " 凭证录入";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
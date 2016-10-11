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
    public partial class mexpress_print : MPageBase
    {
        public string OrderID = "";//发货单编号
        public string MTradeInfoID = "";//交易单编号

        public string Receiver_name = "";//收货人姓名
        public string Receiver_state	= "";//收货人的所在省份
        public string Receiver_city	= "";//收货人的所在城市
        public string Receiver_district	= "";//收货人的所在地区
        public string Receiver_address	= "";//收货人的详细地址
        public string Receiver_zip	= "";//收货人的邮编
        public string Receiver_mobile	= "";//收货人的手机号码
        public string Receiver_phone = "";//收货人的电话号码
        public string BuyerName = "";//网购用户昵称

        public string From_name = "";//发件人姓名
        public string From_company = "";//发件公司名称
        public string From_state = "";//发件人的所在省份
        public string From_city = "";//发件人的所在城市
        public string From_district = "";//发件人的所在地区
        public string From_address = "";//发件地址
        public string From_zip = "";//发件邮编
        public string From_mobile = "";//发件手机
        public string From_phone = "";//发件电话

        public string MMemo = "";//备注

        public OrderInfo oi = new OrderInfo();//发货单
        public M_SendGoodsInfo m_sg = new M_SendGoodsInfo();//网购订单
        public M_ExpressTemplatesInfo m_exp = new M_ExpressTemplatesInfo();//网购运单

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-3-2-3"))
                {
                    int oid = HTTPRequest.GetInt("oid", 0);//发货单系统编号
                    if (oid > 0)
                    {
                        oi = Orders.GetOrderInfoModel(oid);
                        if (oi != null)
                        {
                            m_sg = M_Utils.GetM_SendGoodsInfoModelByOrderID(oid);
                            if (m_sg != null)
                            {
                                m_exp = M_Utils.GetM_ExpressTemplatesInfoModel(m_sg.mExpName);
                                if (m_exp != null)
                                {
                                    OrderID = oi.oOrderNum;
                                    string MTradeInfoID = m_sg.m_TradeInfoID;
                                    string[] _m_TradeInfoIDArr = Utils.SplitString(MTradeInfoID, ",");
                                    MTradeInfoID = "";
                                    foreach (string _m_TradeInfoID_Str in _m_TradeInfoIDArr)
                                    {
                                        if (_m_TradeInfoID_Str.Trim() != "")
                                        {
                                            M_TradeInfo _mt = new M_TradeInfo();
                                            try
                                            {
                                                try
                                                {
                                                    _mt = M_Utils.GetM_TradeInfoModel(Convert.ToInt32(_m_TradeInfoID_Str.Trim()));
                                                    if (_mt != null)
                                                    {
                                                        BuyerName = _mt.buyer_nick;
                                                        MTradeInfoID += _mt.tid.ToString() + " ";
                                                    }
                                                }
                                                catch
                                                {

                                                }
                                            }
                                            finally
                                            {
                                                _mt = null;
                                            }
                                        }
                                    }
                                    Receiver_name = m_sg.receiver_name;
                                    Receiver_state = m_sg.receiver_state;
                                    Receiver_city = m_sg.receiver_city;
                                    Receiver_district = m_sg.receiver_district;
                                    Receiver_address = m_sg.receiver_address;
                                    Receiver_zip = m_sg.receiver_zip;
                                    Receiver_mobile = m_sg.receiver_mobile;
                                    Receiver_phone = m_sg.receiver_phone;

                                    From_name = m_sg.from_name;
                                    From_company = M_Config.StoresName;
                                    From_state = m_sg.from_state;
                                    From_city = m_sg.from_city;
                                    From_district = m_sg.from_district;
                                    From_address = m_sg.from_address;
                                    From_zip = m_sg.from_zip;
                                    From_mobile = m_sg.from_mobile;
                                    From_phone = m_sg.from_phone;
                                    MMemo = m_sg.mMemo;
                                    
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{OrderID}", OrderID, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{MTradeInfoID}", MTradeInfoID, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{BuyerName}", BuyerName, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_name}", Receiver_name, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_state}", Receiver_state, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_city}", Receiver_city, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_district}", Receiver_district, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_address}", Receiver_address, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_zip}", Receiver_zip, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_mobile}", Receiver_mobile, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{Receiver_phone}", Receiver_phone, false);

                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_name}", From_name, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_company}", From_company, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_state}", From_state, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_city}", From_city, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_district}", From_district, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_address}", From_address, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_zip}", From_zip, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_mobile}", From_mobile, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{From_phone}", From_phone, false);
                                    m_exp.mData = Utils.ReplaceString(m_exp.mData, "{MMemo}", MMemo, false);
                                    
                                }
                                else
                                {
                                    AddErrLine("网购单不存在!");
                                }
                            }
                            else {
                                AddErrLine("网购运单模板不存在!");
                            }
                        }
                        else
                        {
                            AddErrLine("该发货单不存在!");
                        }
                    }
                    else 
                    {
                        AddErrLine("参数错误!");
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
            pagetitle = config.CompanyName + " 销售报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
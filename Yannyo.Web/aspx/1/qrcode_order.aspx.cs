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
    public partial class qrcode_order : PageBase
    {
        public OrderInfo oi = new OrderInfo();
        public DataTable dList = new DataTable();//操作记录
        //public DataTable OrderFieldList = new DataTable();//自定义字段
        //public DataTable OrderFieldValueList = new DataTable();//自定义字段值
        public DataTable OrderList = new DataTable();//单据体列表
        public decimal summoney = 0;//合计
        public string summoney_str = "";//大写
        public decimal sumQuantityM = 0;//合计数量,小单位
        public decimal sumQuantityB = 0;//合计数量,大单位
        public int OrderFieldCount = 0;//自定义字段数
        public UserInfo print_ui = new UserInfo();//开单人员
        public UserInfo print_v_ui = new UserInfo();//审核人员
        public bool ShowMoney = false;//是否显示金额

        public string printdatetime = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            int orderid = HTTPRequest.GetInt("orderid",0);
            string rc = HTTPRequest.GetString("rc");
            if (orderid > 0)
            {
                //rc = Utils.UrlDecode(DES.Decode(rc, config.Passwordkey));
				rc = DES.Decode(Utils.UrlDecode(rc), config.Passwordkey);
                if (rc.Trim() != "")
                {
                   string[] rearray = Utils.SplitString(rc, "|");
                   if(rearray.Length>0){
                    oi = Orders.GetOrderInfoModel(orderid);
                    if (oi != null)
                    {
                        if (rearray[1].Trim() == oi.oOrderNum.Trim())
                        {
                            printdatetime = rearray[0].Trim();
                            string tSteps = ((oi.oSteps == 1) ? "  tbOrderListInfo.oWorkType=0 " : "  tbOrderListInfo.oWorkType<>0 ").ToString();
                            string tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0 " : " IsVerify<>0 ").ToString();
                            //销售出货跟销售退货显示金额
                            if(oi.oType==3 || oi.oType==4){
                                ShowMoney = true;
                            }
                            
                            OrderList = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];

                            foreach (DataRow dr in OrderList.Rows)
                            {
                                summoney += Convert.ToDecimal(dr["oQuantity"]) * Convert.ToDecimal(dr["oPrice"]);
                            }
                            summoney_str = chang(summoney.ToString());

                            summoney = Math.Round(summoney,config.MoneyDecimal);

                            //库存调拨单,整理数据
                            if (oi.oType == 9)
                            {
                                DataTable nOrderList = new DataTable();
                                nOrderList = OrderList.Clone();

                                foreach (DataRow dr in OrderList.Rows)
                                {
                                    if (Convert.ToDecimal(dr["oQuantity"].ToString()) < 0)
                                    {
                                        dr["StorageName"] = "来源:" + dr["StorageName"].ToString();
                                        nOrderList.Rows.Add(dr.ItemArray);
                                    }
                                }
                                nOrderList.AcceptChanges();

                                foreach (DataRow dr in OrderList.Rows)
                                {
                                    foreach (DataRow ddr in nOrderList.Rows)
                                    {
                                        if (Convert.ToInt32(ddr["ProductsID"].ToString()) == Convert.ToInt32(dr["ProductsID"].ToString()))
                                        {
                                            if (Convert.ToDecimal(dr["oQuantity"].ToString()) > 0)
                                            {
                                                ddr["oQuantity"] = Convert.ToDecimal(dr["oQuantity"].ToString());
                                                ddr["StorageName"] = ddr["StorageName"].ToString() + "<br>去向:" + dr["StorageName"].ToString() + "";
                                            }
                                        }
                                        
                                    }
                                    nOrderList.AcceptChanges();
                                }

                                OrderList.Clear();
                                OrderList = nOrderList.Copy();
                            }
                            //制单人
                            print_ui = tbUserInfo.GetUserInfoModel(oi.UserID);
                            //审核人
                            OrderWorkingLogInfo owil = Orders.GetOrderWorkingUserID(oi.OrderID, 2);
                            if (owil != null)
                            {
                                print_v_ui = tbUserInfo.GetUserInfoModel(owil.UserID);
                            }
                            else {
                                print_v_ui = null;
                            }

                            dList = Orders.GetOrderWorkingLogInfoList(" OrderID=" + orderid + " order by pAppendTime desc").Tables[0];
                        }
                        else {
                            AddErrLine("掩码被修改!");
                        }
                    }
                    else
                    {
                        AddErrLine("参数错误,单据不存在!");
                    }
                   }else{
                        AddErrLine("掩码被修改!");
                   }
                }
                else {
                    AddErrLine("秘钥参数错误!");
                }
            }
            else {
                AddErrLine("单据编号参数错误!");
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 单据信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
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

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{
    public partial class datapost : PageBase
    {
        public DataTable ProductList = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            string Act = HTTPRequest.GetString("Act");
            int pagesize = HTTPRequest.GetInt("pagesize", 0);
            int page = HTTPRequest.GetInt("page", 0);

            ProductList = tbProductsInfo.GetProductsInfoList("").Tables[0];

            if (Act != "")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);

                Response.Expires = 0;
                string Json_Str = "";

                if (ispost)
                {
                    if (Act == "Add")
                    {
                        try
                        {
                            string JsonStr = HTTPRequest.GetString("json");
                            Order oo = (Order)JavaScriptConvert.DeserializeObject(JsonStr, typeof(Order));
                            if (oo != null)
                            {
                                if (oo.O_ORDERNUM.Trim() != "")
                                {
                                    if (!Orders.ExistsOrderInfo(oo.O_ORDERNUM))
                                    {
                                        bool isneworder = false;
                                        OrderInfo oi = new OrderInfo();
                                        oi.oOrderNum = oo.O_ORDERNUM;
                                        oi.oType = (oo.O_REMARK == "4") ? 1 : (oo.O_REMARK == "8") ? 2 : (oo.O_REMARK == "1") ? 3 : (oo.O_REMARK == "5") ? 4 : (oo.O_REMARK == "2") ? 5 : (oo.O_REMARK == "3") ? 6 : (oo.O_REMARK == "7") ? 7 : (oo.O_REMARK == "6") ? 10 : 0;
                                        switch (oi.oType)
                                        {
                                            case 1:
                                            case 2://供货商
                                                SupplierInfo si = new SupplierInfo();
                                                try
                                                {
                                                    si = tbSupplierInfo.GetSupplierInfoModelByName(oo.c_name);
                                                    if (si != null)
                                                    {
                                                        oi.StoresID = si.SupplierID;
                                                        oi.oCustomersName = si.sName;
                                                        oi.oCustomersContact = si.sLinkMan;
                                                        oi.oCustomersTel = si.sTel;
                                                        oi.oCustomersAddress = si.sAddress;
                                                    }
                                                }
                                                finally
                                                {
                                                    si = null;
                                                }
                                                break;
                                            case 3:
                                            case 4:
                                            case 5:
                                            case 6:
                                            case 7:
                                                StoresInfo sti = new StoresInfo();
                                                try
                                                {
                                                    sti = tbStoresInfo.GetStoresInfoModelByName(oo.c_name);
                                                    if (sti != null)
                                                    {
                                                        oi.StoresID = sti.StoresID;
                                                        oi.oCustomersName = sti.sName;
                                                        oi.oCustomersContact = sti.sContact;
                                                        oi.oCustomersTel = sti.sTel;
                                                        oi.oCustomersAddress = sti.sAddress;
                                                    }
                                                }
                                                finally
                                                {
                                                    sti = null;
                                                }
                                                break;
                                            case 10:
                                                oi.StoresID = 0;
                                                oi.oCustomersName = "";
                                                oi.oCustomersContact = "";
                                                oi.oCustomersTel = "";
                                                oi.oCustomersAddress = "";
                                                break;
                                        }

                                        oi.oCustomersOrderID = oo.C_ORDERID;
                                        oi.oCustomersNameB = oo.C_MD;
                                        StaffInfo sai = new StaffInfo();
                                        sai = tbStaffInfo.GetStaffInfoModelByName(oo.sa_name);
                                        if (sai != null)
                                        {
                                            oi.StaffID = sai.StaffID;
                                        }
                                        oi.UserID = this.userid;
                                        oi.oAppendTime = Convert.ToDateTime(oo.O_TIME);
                                        oi.oOrderDateTime = Convert.ToDateTime(oo.O_CREATETIME);
                                        oi.oState = 0;
                                        oi.oSteps = 1;

                                        isneworder = (oo.O_ISCHECK == "1") ? true : false;

                                        string tListStr = "";

                                        if (oo.OrderData != null)
                                        {
                                            foreach (OrderData od in oo.OrderData)
                                            {

                                                ProductsInfo pi = new ProductsInfo();
                                                try
                                                {
                                                    pi = tbProductsInfo.GetProductsInfoModelByName(od.p_name);
                                                    if (pi == null)
                                                    {
                                                        pi = tbProductsInfo.GetProductsInfoModelByBarcode(od.p_code);
                                                    }

                                                    tListStr += "{\"OrderListID\":0,\"OrderID\":0,\"StorageID\":1,\"ProductsID\":" + pi.ProductsID + ",\"oQuantity\":" + Convert.ToDecimal(od.s_quantity) + ",\"oPrice\":" + Convert.ToDecimal(od.s_price) + ",\"oMoney\":" + Convert.ToDecimal(od.s_total) + ",\"StoresSupplierID\":" + oi.StoresSupplierID + ",\"IsPromotions\":0,\"oWorkType\":0,\"oAppendTime\":\"" + oi.oAppendTime + "\"," +
                                                        "\"OrderFieldValueInfo\":[{\"OrderFieldValueID\":0,\"OrderFieldID\":1,\"OrderListID\":0,\"oFieldValue\":\"" + od.makedate + "\",\"IsVerify\":0,\"oAppendTime\":\"" + oi.oAppendTime + "\"}," +
                                                        "{\"OrderFieldValueID\":0,\"OrderFieldID\":2,\"OrderListID\":0,\"oFieldValue\":\"" + od.Manufacturers + "\",\"IsVerify\":0,\"oAppendTime\":\"" + oi.oAppendTime + "\"}," +
                                                        "{\"OrderFieldValueID\":0,\"OrderFieldID\":3,\"OrderListID\":0,\"oFieldValue\":\"" + od.Durability + "\",\"IsVerify\":0,\"oAppendTime\":\"" + oi.oAppendTime + "\"}]},";

                                                }
                                                finally
                                                {
                                                    pi = null;
                                                }
                                            }
                                        }
                                        if (tListStr.Trim() != "")
                                        {
                                            tListStr = tListStr.Substring(0, tListStr.Length - 1);
                                        }
                                        tListStr = "{\"OrderListJson\":[" + tListStr + "]}";

                                        oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(tListStr, typeof(OrderListDataJson)); ;
                                        int OrderID = Orders.AddOrderInfoAndList(oi);
                                        {
                                            oi = Orders.GetOrderInfoModel(OrderID);

                                            //完成审核操作
                                            Orders.VerifyOrder(oi.OrderID);

                                            tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                            owl.OrderID = oi.OrderID;
                                            owl.UserID = this.userid;
                                            owl.oType = 2;
                                            owl.oMsg = "数据迁移,系统自动处理";
                                            owl.pAppendTime = oi.oAppendTime;

                                            Orders.AddOrderWorkingLogInfo(owl);

                                            if (!isneworder)
                                            {
                                                //完成发货操作
                                                oi.oSteps = 3;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 3;
                                                owl.oMsg = "数据迁移,系统自动处理";
                                                owl.pAppendTime = oi.oAppendTime;

                                                Orders.AddOrderWorkingLogInfo(owl);
                                                //完成收货操作
                                                oi.oSteps = 4;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 4;
                                                owl.oMsg = "数据迁移,系统自动处理";
                                                owl.pAppendTime = oi.oAppendTime;

                                                Orders.AddOrderWorkingLogInfo(owl);

                                                //完成核销操作
                                                oi.oSteps = 5;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 5;
                                                owl.oMsg = "数据迁移,系统自动处理";
                                                owl.pAppendTime = oi.oAppendTime;

                                                Orders.AddOrderWorkingLogInfo(owl);
                                            }
                                            else
                                            {
                                                //完成发货操作
                                                oi.oSteps = 3;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 3;
                                                owl.oMsg = "数据迁移,系统自动处理";
                                                owl.pAppendTime = oi.oAppendTime;
                                            }
                                        }
                                        Json_Str = "{\"results\": true,\"msg\":\"" + oi.OrderID + "\",\"orderid\":\"" + oo.O_ORDERNUM + "\"}";
                                    }
                                    else
                                    {
                                        Json_Str = "{\"results\": false,\"msg\":\"单据已存在.\",\"orderid\":\"" + oo.O_ORDERNUM + "\"}";
                                    }
                                }
                                else
                                {
                                    Json_Str = "{\"results\": false,\"msg\":\"对象为空.\"}";
                                }

                            }
                            else
                            {
                                Json_Str = "{\"results\": false,\"msg\":\"单号为空.\"}";
                            }
                        }
                        catch (Exception ex)
                        {
                            Json_Str = "{\"results\": false,\"msg\":\"" + ex.Message + "," + ex.Data + "\"}";
                        }
                        Response.Charset = "utf-8";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                        Response.ContentType = "application/json";

                        Response.Write(Json_Str);
                    }
                    if (Act == "PAttribute")
                    {
                        int ProductID = HTTPRequest.GetInt("pid", 0);
                        string JsonStr = HTTPRequest.GetString("JsonStr");
                        int PriceClassID = 0;
                        decimal Price = 0;
                        if (ProductID > 0 && JsonStr.Trim() != "")
                        {
                            PAttribute oo = (PAttribute)JavaScriptConvert.DeserializeObject(JsonStr, typeof(PAttribute));
                            if (oo != null)
                            {
                                foreach (PAttributePrice pa in oo.PAttributePrice)
                                {
                                    if (pa != null)
                                    {
                                        if (pa.pr_Name.Trim() != "")
                                        {
                                            try
                                            {
                                                Price = Convert.ToDecimal(pa.a_Price);
                                                PriceClassID = DataClass.GetPriceClassInfoModel(pa.pr_Name).PriceClassID;
                                                tbPriceClassDefaultPriceInfo.SavePriceClassDefaultPrice(PriceClassID, ProductID, Price,0);
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            Response.ContentType = "application/json";

                            Response.Write("{\"results\": true,\"msg\":\"OK.\",\"PID\":" + ProductID + "}");
                        }
                    }
                }
                else
                {
                    if (Act == "GetOrderList" || Act == "GetPAttribute")
                    {
                        WebClient client = new WebClient();
                        byte[] bytes = null;
                        if (Act == "GetOrderList")
                        {
                            bytes = client.DownloadData(new Uri("http://erp.bdu9.com/datapost.aspx?Act=" + Act + "&pagesize=" + pagesize + "&page=" + page + ""));
                        }
                        if (Act == "GetPAttribute")
                        {
                            bytes = client.DownloadData(new Uri("http://erp.bdu9.com/datapost.aspx?Act=" + Act + "&pid=" + HTTPRequest.GetInt("pid", 0) + "&pname=" + tbProductsInfo.GetProductsInfoModel(HTTPRequest.GetInt("pid", 0)).pName));
                        }
                        if (bytes.Length == 0)
                        {
                            Response.ContentType = "text/plain";
                            Response.Write("(not loaded)");
                        }
                        else
                        {
                            Response.BinaryWrite(bytes);
                        }
                    }
                }

                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 数据迁移";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
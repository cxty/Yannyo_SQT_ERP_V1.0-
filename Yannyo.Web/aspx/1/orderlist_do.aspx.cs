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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{
    public partial class orderlist_do : PageBase
    {
        public int ordertype = 0;//单据类型
        public string Act = "";
        public string OrderListDataJsonStr = "";
        public DateTime oOrderDateTime = DateTime.Now;
        public DataTable OrderFieldList = new DataTable();
        public DataTable CertificateList = new DataTable();
        public string OrderFieldListJson = "";
        public int orderid = 0;//单据编号
        public OrderInfo oi = new OrderInfo();
        public bool ShowTree = false;
        public bool IsVerify = false;
        public string OrderWorkingLogMsg = "";
        public int OrderWorkingType = 0;//当前单据操作标识
        public string format = "";//返回值格式,默认html
        public bool IsFirst = false;//当前是否为原始单据
        public bool ShowEdit = false;//是否可编辑
        public bool IsNOFull = false;//是否为非全额单据
        public bool IsNOFullAndNOToDo = false;//非全额单据且差额未转单

        public bool IsPrepayOK = false;//需预付的是否预付成功
        public decimal PrepayMoney = 0;//已预付金额
        public decimal cSumMoney = 0;//预付合计

        public string pagecode = "";//防止操作员提交后刷新,导致重新提交.
        public bool IsMOrder = false;//是否为网购订单
        public M_SendGoodsInfo _ms = new M_SendGoodsInfo();//网购订单
        public string MS_Json = "";//网购单操作时返回信息
		
		public string Order_QRCode_URL = "";//外部查看连接

        public bool EditDefaultPrice = false;//是否可修改默认价格
		
        protected virtual void Page_Load(object sender, EventArgs e)
        {

            if (this.userid > 0)
            {
                ordertype = HTTPRequest.GetInt("ordertype", 0);
                orderid = HTTPRequest.GetInt("orderid", 0);
                Act = Utils.ChkSQL(HTTPRequest.GetString("Act")).Trim();
                format = HTTPRequest.GetString("format");
                IsFirst = (HTTPRequest.GetString("IsFirst").Trim() != "") ? Convert.ToBoolean(HTTPRequest.GetString("IsFirst").Trim()) : false; ;

                this.EditDefaultPrice = (CheckUserPopedoms("3-2-1-10") || CheckUserPopedoms("X"));//是否有修改价格的权限

                if (ordertype > 0 && Act != "")
                {
                    #region 权限判断
                    switch (ordertype)
                    {
                        case 1://采购入库=1
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-1") || CheckUserPopedoms("3-1-1-2") || CheckUserPopedoms("3-1-1-3") || CheckUserPopedoms("3-1-1-4") || CheckUserPopedoms("3-1-1-5") || CheckUserPopedoms("3-1-1-6") || CheckUserPopedoms("3-1-1-7") || CheckUserPopedoms("3-1-1-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-1"))
                                        {
                                            OrderWorkingType = 1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 采购入库单 列表!");
                                        }
                                        break;
                                    case "2":
									case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-2"))
                                        {
                                            OrderWorkingType = 2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 采购入库单 列表!");
                                        }
                                        break;
                                    case "3":
									case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-3"))
                                        {
                                            OrderWorkingType = 3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-4"))
                                        {
                                            OrderWorkingType = 4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-5"))
                                        {
                                            OrderWorkingType = 5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        //审核后的修改操作
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-6"))
                                        {
                                            OrderWorkingType = 6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-7"))
                                        {
                                            OrderWorkingType = 7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost) {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps==7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8"))
                                        {
                                           OrderWorkingType = 8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 采购入库单 列表!");
                            }
                            break;
                        case 2://采购退货=2
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-1") || CheckUserPopedoms("3-1-2-2") || CheckUserPopedoms("3-1-2-3") || CheckUserPopedoms("3-1-2-4") || CheckUserPopedoms("3-1-2-5") || CheckUserPopedoms("3-1-2-6") || CheckUserPopedoms("3-1-2-7") || CheckUserPopedoms("3-1-2-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-1"))
                                        {
                                            OrderWorkingType = 1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 采购退货单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 采购退货单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-4"))
                                        {
                                            OrderWorkingType = 4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 采购退货单 列表!");
                            }
                            break;
                        case 3://销售发货=3
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-1") || CheckUserPopedoms("3-2-1-2") || CheckUserPopedoms("3-2-1-3") || CheckUserPopedoms("3-2-1-4") || CheckUserPopedoms("3-2-1-5") || CheckUserPopedoms("3-2-1-6") || CheckUserPopedoms("3-2-1-7") || CheckUserPopedoms("3-2-1-8"))
                            {
                                
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 销售发货单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 销售发货单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 销售发货单 列表!");
                            }
                            break;
                        case 4://销售退货=4
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-1") || CheckUserPopedoms("3-2-2-2") || CheckUserPopedoms("3-2-2-3") || CheckUserPopedoms("3-2-2-4") || CheckUserPopedoms("3-2-2-5") || CheckUserPopedoms("3-2-2-6") || CheckUserPopedoms("3-2-2-7") || CheckUserPopedoms("3-2-2-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 销售退货单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 销售退货单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 销售退货单 列表!");
                            }
                            break;
                        case 5://赠品=5
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-1") || CheckUserPopedoms("3-2-3-2") || CheckUserPopedoms("3-2-3-3") || CheckUserPopedoms("3-2-3-4") || CheckUserPopedoms("3-2-3-5") || CheckUserPopedoms("3-2-3-6") || CheckUserPopedoms("3-2-3-7") || CheckUserPopedoms("3-2-3-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 赠品单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 赠品单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 赠品单 列表!");
                            }
                            break;
                        case 6://样品=6
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-1") || CheckUserPopedoms("3-2-4-2") || CheckUserPopedoms("3-2-4-3") || CheckUserPopedoms("3-2-4-4") || CheckUserPopedoms("3-2-4-5") || CheckUserPopedoms("3-2-4-6") || CheckUserPopedoms("3-2-4-7") || CheckUserPopedoms("3-2-4-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 样品单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 样品单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 样品单 列表!");
                            }
                            break;
                        case 7://代购=7
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-1") || CheckUserPopedoms("3-2-5-2") || CheckUserPopedoms("3-2-5-3") || CheckUserPopedoms("3-2-5-4") || CheckUserPopedoms("3-2-5-5") || CheckUserPopedoms("3-2-5-6") || CheckUserPopedoms("3-2-5-7") || CheckUserPopedoms("3-2-5-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 代购单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 代购单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 代购单 列表!");
                            }
                            break;
                        case 8://库存调整=8
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-1") || CheckUserPopedoms("3-3-2-2") || CheckUserPopedoms("3-3-2-3") || CheckUserPopedoms("3-3-2-4") || CheckUserPopedoms("3-3-2-5") || CheckUserPopedoms("3-3-2-6") || CheckUserPopedoms("3-3-2-7") || CheckUserPopedoms("3-3-2-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 库存调整单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 库存调整单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 库存调整单 列表!");
                            }
                            break;
                        case 9://库存调拨=9
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-1") || CheckUserPopedoms("3-3-1-2") || CheckUserPopedoms("3-3-1-3") || CheckUserPopedoms("3-3-1-4") || CheckUserPopedoms("3-3-1-5") || CheckUserPopedoms("3-3-1-6") || CheckUserPopedoms("3-3-1-7") || CheckUserPopedoms("3-3-1-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 库存调拨单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 库存调拨单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 库存调拨单 列表!");
                            }
                            break;
                        case 10://坏货=10
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-1") || CheckUserPopedoms("3-3-3-2") || CheckUserPopedoms("3-3-3-3") || CheckUserPopedoms("3-3-3-4") || CheckUserPopedoms("3-3-3-5") || CheckUserPopedoms("3-3-3-6") || CheckUserPopedoms("3-3-3-7") || CheckUserPopedoms("3-3-3-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-1"))
                                        {
                                            OrderWorkingType =1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 坏货单 列表!");
                                        }
                                        break;
                                    case "2":case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-2"))
                                        {
                                            OrderWorkingType =2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 坏货单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-3"))
                                        {
                                            OrderWorkingType =3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-4"))
                                        {
                                            OrderWorkingType =4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-5"))
                                        {
                                            OrderWorkingType =5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-6"))
                                        {
                                            OrderWorkingType =6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-7"))
                                        {
                                            OrderWorkingType =7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-8"))
                                        {
                                            OrderWorkingType =8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 坏货单 列表!");
                            }
                            break;
                        case 11://换货=11
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-1") || CheckUserPopedoms("3-2-6-2") || CheckUserPopedoms("3-2-6-3") || CheckUserPopedoms("3-2-6-4") || CheckUserPopedoms("3-2-6-5") || CheckUserPopedoms("3-2-6-6") || CheckUserPopedoms("3-2-6-7") || CheckUserPopedoms("3-2-6-8"))
                            {
                                switch (Act)
                                {
                                    case "1":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-1"))
                                        {
                                            OrderWorkingType = 1;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法新建 换货单 列表!");
                                        }
                                        break;
                                    case "2":
                                    case "s":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-2"))
                                        {
                                            OrderWorkingType = 2;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法审核 换货单 列表!");
                                        }
                                        break;
                                    case "3":
                                    case "d":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-3"))
                                        {
                                            OrderWorkingType = 3;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 发货 列表!");
                                        }
                                        break;
                                    case "4":
                                    case "r":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-4"))
                                        {
                                            OrderWorkingType = 4;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 收货 列表!");
                                        }
                                        break;
                                    case "5":
                                    case "vv":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-5"))
                                        {
                                            OrderWorkingType = 5;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 核销 列表!");
                                        }
                                        break;
                                    case "6":
                                    case "e":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-6"))
                                        {
                                            OrderWorkingType = 6;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 修改 列表!");
                                        }
                                        break;
                                    case "7":
                                    case "i":
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-7"))
                                        {
                                            OrderWorkingType = 7;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 作废 列表!");
                                        }
                                        break;
                                    case "8":
                                    case "v":
                                        if (ispost)
                                        {
                                            oi = Orders.GetOrderInfoModel(this.orderid);
                                            if (oi != null)
                                            {
                                                if (oi.oSteps == 3)
                                                {
                                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-6"))
                                                    {
                                                        OrderWorkingType = 6;
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("权限不足,无法 修改 列表!");
                                                    }
                                                }
                                                else if (oi.oSteps == 2 || oi.oSteps == 4 || oi.oSteps == 5 || oi.oSteps == 6 || oi.oSteps == 7)
                                                {
                                                    AddErrLine("无法 修改 列表!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误!");
                                            }
                                        }
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-8"))
                                        {
                                            OrderWorkingType = 8;
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,无法 查看 列表!");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddErrLine("权限不足,无法浏览 换货单 列表!");
                            }
                            break;
                    }
                    #endregion
                }
                else
                {
                    AddErrLine("参数错误,请返回!");
                }

				int OrderID = HTTPRequest.GetInt("OrderID", 0);
				string oOrderNum = Utils.ChkSQL(HTTPRequest.GetString("oOrderNum"));
				int oType = ordertype;
				int StoresSupplierID = HTTPRequest.GetInt("StoresSupplierID", 0);
				string oCustomersName = Utils.ChkSQL(HTTPRequest.GetString("oCustomersName"));
				string oCustomersContact = Utils.ChkSQL(HTTPRequest.GetString("oCustomersContact"));
				string oCustomersTel = Utils.ChkSQL(HTTPRequest.GetString("oCustomersTel"));
				string oCustomersAddress = Utils.ChkSQL(HTTPRequest.GetString("oCustomersAddress"));
				string oCustomersOrderID = Utils.ChkSQL(HTTPRequest.GetString("oCustomersOrderID"));
				string oCustomersNameB = Utils.ChkSQL(HTTPRequest.GetString("oCustomersNameB"));
				int StaffID = HTTPRequest.GetInt("StaffID", 0);
				int oPrepay = HTTPRequest.GetInt("oPrepay", 0);
				string oReMake = Utils.ChkSQL(HTTPRequest.GetString("oReMake"));
				oOrderDateTime = (HTTPRequest.GetString("oOrderDateTime").Trim() != "") ? Convert.ToDateTime(Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTime"))) : DateTime.Now;
				string _OrderListDataJson = HTTPRequest.GetString("OrderListDataJson");
				OrderWorkingLogMsg = Utils.ChkSQL(HTTPRequest.GetString("OrderWorkingLogMsg"));

				if (ispost) {
					if (Act == "1" || Act == "e") {

						//验证数据
						switch (oType) {
						case 1:
						case 2://采购入库，采购退货
							if (StoresSupplierID > 0) {

							} else {
								AddErrLine ("请重新填写供应商信息,请返回!");
							}
							break;
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 11://销售出货，销售退货
							if (StoresSupplierID > 0) {
								if (StaffID > 0) {

								} else {
									AddErrLine ("请重新填写业务员信息,请返回!");
								}
							} else {
								AddErrLine ("请重新填写客户信息,请返回!");
							}
							break;
						case 8:
						case 9:
						case 10://调整，调拨，坏损
							break;
						}

					}
				}

                if (!IsErr())
                {
                    if (!ispost) 
                    {
                        OrderFieldList = Orders.GetOrderFieldInfoList(" OrderType=" + ordertype + " and fState=0").Tables[0];
                        if (OrderFieldList != null)
                        {
                            foreach (DataRow dr in OrderFieldList.Rows)
                            {
                                OrderFieldListJson += "{\"OrderField\":{\"OrderFieldID\":\"" + dr["OrderFieldID"].ToString() + "\",\"OrderType\":\"" + dr["OrderType"].ToString() + "\",\"fName\":\"" + dr["fName"].ToString() + "\",\"fType\":\"" + dr["fType"].ToString() + "\",\"fProductField\":\"" + dr["fProductField"].ToString() + "\"}},";
                            }
                            if (OrderFieldListJson.Trim() != "")
                            {
                                OrderFieldListJson = OrderFieldListJson.Substring(0, OrderFieldListJson.Length - 1);
                            }
                            OrderFieldListJson = "{\"OrderFieldList\":[" + OrderFieldListJson + "]}";
                        }
                    }

                    
                    // oi = new OrderInfo();


                    switch (Act)
                    {
                        #region 新建
                        case "1":
                            this.ShowEdit = true;
                            if (ispost)
                            {
                                pagecode = HTTPRequest.GetString("pagecode").Trim();
                                string old_pagecode = UsersUtils.GetCookie("OrderPageCode");
                                bool isRePost = false;
                                if (pagecode.Trim() != "")
                                {
                                    if (pagecode == old_pagecode)
                                    {
                                        isRePost = false;
                                    }
                                    else
                                    {
                                        isRePost = true;
                                    }
                                }
                                else {
                                    isRePost = true;
                                }

                                if (!isRePost)
                                {
                                    //重置页面随机码
                                    pagecode = Utils.GetRanDomCode().Trim();
                                    UsersUtils.WriteCookie("OrderPageCode", pagecode);

                                    //新单不产生单号
                                    oi.oOrderNum = "----------";// Orders.GetNewOrderNum();
                                    //if (!Orders.ExistsOrderInfo(oi.oOrderNum))
                                    {
										

                                        oi.oType = oType;
                                        oi.StoresID = StoresSupplierID;
                                        oi.oCustomersName = oCustomersName;
                                        oi.oCustomersContact = oCustomersContact;
                                        oi.oCustomersTel = oCustomersTel;
                                        oi.oCustomersAddress = oCustomersAddress;
                                        oi.oCustomersOrderID = oCustomersOrderID;
                                        oi.oCustomersNameB = oCustomersNameB;
                                        oi.StaffID = StaffID;
                                        oi.UserID = this.userid;
                                        oi.oAppendTime = DateTime.Now;
                                        oi.oOrderDateTime = oOrderDateTime;
                                        oi.oState = 0;
                                        oi.oSteps = 1;
                                        oi.oPrepay = oPrepay;
                                        oi.oReMake = oReMake;
                                        oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson, typeof(OrderListDataJson));
                                        OrderID = Orders.AddOrderInfoAndList(oi);
                                        if (OrderID > 0)
                                        {
                                            AddMsgLine("单据创建成功!<p class=\"SendGood\"><!--<br>是否打印?-><a href=\"javascript:void(0);\" onclick=\"javascript:OrderDO.Print(" + OrderID + ");\">打印</a>--><br>继续开单?-><a href=\"javascript:void(0);\" onclick=\"javascript:OrderDO.Re(" + OrderID + ");\">开单</a><br>查看单据?-><a href=\"javascript:void(0);\" onclick=\"javascript:OrderDO.Show(" + OrderID + ");\">查看</a></p>");

                                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                            owl.OrderID = OrderID;
                                            owl.UserID = this.userid;
                                            owl.oType = 0;
                                            owl.oMsg = OrderWorkingLogMsg;
                                            owl.pAppendTime = DateTime.Now;

                                            Orders.AddOrderWorkingLogInfo(owl);

                                            #region 发送邮件给审核人员
                                            try
                                            {
                                                oi = Orders.GetOrderInfoModel(OrderID);
                                                switch (ordertype)
                                                {
                                                    case 1://采购入库
                                                        UsersUtils.SendUserMailByPopedom("3-1-1-2", "采购入库单 需审核,单号:" + oi.oOrderNum, "采购入库单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 2://采购退货
                                                        UsersUtils.SendUserMailByPopedom("3-1-2-2", "采购退货单 需审核,单号:" + oi.oOrderNum, "采购退货单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 3://销售发货
                                                        UsersUtils.SendUserMailByPopedom("3-2-1-2", "销售发货单 需审核,单号:" + oi.oOrderNum, "销售发货单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 4://销售退货
                                                        UsersUtils.SendUserMailByPopedom("3-2-2-2", "销售退货单 需审核,单号:" + oi.oOrderNum, "销售退货单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 5://赠品
                                                        UsersUtils.SendUserMailByPopedom("3-2-3-2", "赠品单 需审核,单号:" + oi.oOrderNum, "赠品单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 6://样品
                                                        UsersUtils.SendUserMailByPopedom("3-2-4-2", "样品单 需审核,单号:" + oi.oOrderNum, "样品单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 7://代购
                                                        UsersUtils.SendUserMailByPopedom("3-2-5-2", "代购单 需审核,单号:" + oi.oOrderNum, "代购单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 11://换货
                                                        UsersUtils.SendUserMailByPopedom("3-2-6-2", "换货单 需审核,单号:" + oi.oOrderNum, "换货单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 10://坏货
                                                        UsersUtils.SendUserMailByPopedom("3-3-3-2", "坏货单 需审核,单号:" + oi.oOrderNum, "坏货单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 8://库存调整
                                                        UsersUtils.SendUserMailByPopedom("3-3-1-2", "库存调整单 需审核,单号:" + oi.oOrderNum, "库存调整单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                    case 9://库存调拨
                                                        UsersUtils.SendUserMailByPopedom("3-3-2-2", "库存调拨单 需审核,单号:" + oi.oOrderNum, "库存调拨单 需审核,单号:" + oi.oOrderNum);
                                                        break;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            AddErrLine("新建单据失败,请重试!");
                                        }
                                    }
                                    //else
                                    {
                                   //     AddErrLine("单据号重复,单据添加失败,请重试!");
                                    }
                                }
                                else {
                                    AddErrLine("数据已提交,请不要按F5或刷新页面!");
                                }
                            }
                            else 
                            {
                                pagecode = Utils.GetRanDomCode().Trim();
                                UsersUtils.WriteCookie("OrderPageCode", pagecode);
                            }
                            break;
                        #endregion
                        #region 查看,修改
                        case "v":case "e":
                            oi = Orders.GetOrderInfoModel(orderid);
                            if (!ispost)
                            {
                                if (oi != null)
                                {
                                    CertificateList = Certificates.GetCertificateInfoList(" cObject=1 and cObjectID=" + oi.OrderID + " and cState=0 order by cDateTime desc").Tables[0];
                                    PrepayMoney = Certificates.GetPrepayMoneyByOrderID(oi.OrderID);
                                    oOrderDateTime = oi.oOrderDateTime;

                                    //是否为网购订单
                                    _ms = M_Utils.GetM_SendGoodsInfoModelByOrderID(oi.OrderID);
                                    if (_ms != null)
                                    {
                                        IsMOrder = true;
                                    }

                                    //未审核,可修改
                                    if (oi.oSteps == 1)
                                    {
                                        this.ShowEdit = true;
                                        ShowTree = true;
                                        IsVerify = true;
                                    }
                                    else {
                                        if (oi.oType != 11)//非换货单可修改
                                        {
                                            if (oi.oPrepay == 1)
                                            {
                                                //是否已完成预付操作
                                                IsPrepayOK = Certificates.CheckCertificateByOrderID(oi.OrderID);
                                            }
                                            else 
                                            {
                                                IsPrepayOK = true;
                                            }

                                            //已审核已发货
                                            if (oi.oSteps == 3)
                                            {
                                                this.ShowEdit = true;
                                            }
                                            else if (oi.oSteps >= 4)
                                            {
                                                //已经收货,已验收,已对账
                                                IsNOFull = Orders.CheckOrderIsFull(oi.OrderID);
                                            }
                                        }
                                        else {
                                            IsPrepayOK = true;
                                            this.ShowEdit = false;
                                        }
                                    }
                                    OrderListDataJsonStr = "";//{"OrderListJson":[{"OrderListID":0,"OrderID":0,"StorageID":0,"ProductsID":0,"oQuantity":0,"oPrice":0,"oMoney":0,"StoresSupplierID":0,"IsPromotions":0,"oWorkType":0,"oAppendTime":"\/Date(1289206775426+0800)\/","OrderFieldValueInfo":[{"OrderFieldValueID":0,"OrderFieldID":0,"OrderListID":0,"oFieldValue":null,"IsVerify":0,"oAppendTime":"\/Date(1289206775426+0800)\/"}]}]} 
                                    string OrderFieldValueStr = "";
                                    string tSteps = "";
                                    string tSteps_b = "";
									
									Order_QRCode_URL = "" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim();
									
									
                                    if (IsFirst)//输出原始单据
                                    {
                                        tSteps = " oWorkType=0";
                                        tSteps_b = " IsVerify=0";
                                    }
                                    else
                                    {
                                        tSteps = ((oi.oSteps == 1) ? " oWorkType=0" : " oWorkType<>0").ToString();
                                        tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0" : " IsVerify<>0").ToString();
                                    }
                                    DataTable OrderListData = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];
                                    if (OrderListData != null)
                                    {
                                        foreach (DataRow dr_OrderListData in OrderListData.Rows)
                                        {
                                            OrderFieldValueStr = "";
                                            DataTable OrderFieldValueData = Orders.GetOrderFieldValueInfoList(" OrderListID=" + dr_OrderListData["OrderListID"].ToString() + "and " + tSteps_b).Tables[0];
                                            foreach (DataRow dr_OrderFieldValueData in OrderFieldValueData.Rows)
                                            {
                                                OrderFieldValueStr += "{\"OrderFieldValueID\":" + dr_OrderFieldValueData["OrderFieldValueID"].ToString() + ",\"OrderFieldID\":" + dr_OrderFieldValueData["OrderFieldID"].ToString() + ",\"OrderListID\":" + dr_OrderFieldValueData["OrderListID"].ToString() + ",\"oFieldValue\":\"" + dr_OrderFieldValueData["oFieldValue"].ToString() + "\",\"IsVerify\":" + dr_OrderFieldValueData["IsVerify"].ToString() + ",\"oAppendTime\":\"" + dr_OrderFieldValueData["oAppendTime"].ToString() + "\"},";
                                            }
                                            if (OrderFieldValueStr != "")
                                            {
                                                OrderFieldValueStr =",\"OrderFieldValueInfo\":["+ Utils.ReSQLSetTxt(OrderFieldValueStr)+"]";
                                            }
                                            OrderListDataJsonStr += "{\"OrderListID\":" + dr_OrderListData["OrderListID"].ToString() + ","+
                                                                                    "\"OrderID\":" + dr_OrderListData["OrderID"].ToString() + "," +
                                                                                    "\"StorageID\":" + dr_OrderListData["StorageID"].ToString() + "," +
                                                                                    "\"StorageName\":\"" + dr_OrderListData["StorageName"].ToString() + "\"," +
                                                                                    "\"ProductsID\":" + dr_OrderListData["ProductsID"].ToString() + "," +
												"\"ProductsName\":\"" +Utils.ReplaceString( Utils.ReplaceString( dr_OrderListData["ProductsName"].ToString(),"'","\\'",false),"\"","\\\"",false) + "\"," +
                                                                                    "\"oQuantity\":" + dr_OrderListData["oQuantity"].ToString() + "," +
                                                                                    "\"oPrice\":" + dr_OrderListData["oPrice"].ToString() + "," +
                                                                                    "\"oMoney\":" + dr_OrderListData["oMoney"].ToString() + "," +
                                                                                    "\"StoresSupplierID\":" + dr_OrderListData["StoresSupplierID"].ToString() + "," +
                                                                                    "\"IsPromotions\":" + dr_OrderListData["IsPromotions"].ToString() + "," +
                                                                                    "\"oWorkType\":" + dr_OrderListData["oWorkType"].ToString() + "," +
                                                                                    "\"IsGifts\":" + dr_OrderListData["IsGifts"].ToString() + "," +
                                                                                    "\"oAppendTime\":\"" + dr_OrderListData["oAppendTime"].ToString() + "\"," +
                                                                                    "\"PriceClassID\":\"" + dr_OrderListData["PriceClassID"].ToString() + "\" "+OrderFieldValueStr+"},";
                                            
                                        }
                                        if (OrderListDataJsonStr.Trim() != "")
                                        {
                                            OrderListDataJsonStr = "{\"OrderListJson\":["+Utils.ReSQLSetTxt(OrderListDataJsonStr)+"]}";
                                        }
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误,单据列表不存在!");
                                }
                            }
                            else //提交,修改更新操作
                            {
                                //非作废单据
                                if (oi.oState != 1)
                                {
                                    if (oi.oSteps == 1 || oi.oSteps == 3)//未审核,已发货,可修改操作
                                    {
                                        oi.StoresID = StoresSupplierID;
                                        oi.oCustomersName = oCustomersName;
                                        oi.oCustomersContact = oCustomersContact;
                                        oi.oCustomersTel = oCustomersTel;
                                        oi.oCustomersAddress = oCustomersAddress;
                                        oi.oCustomersOrderID = oCustomersOrderID;
                                        oi.oCustomersNameB = oCustomersNameB;
                                        oi.StaffID = StaffID;
                                        oi.oReMake = oReMake;
                                        //oi.UserID = this.userid;
                                        //oi.oAppendTime = DateTime.Now;
                                        //oi.oState = 0;
                                        //oi.oSteps = 1;
                                        //未审核前可以修改,是否需预付,单据时间.
                                        if (oi.oSteps == 1)
                                        {
                                            oi.oOrderDateTime = oOrderDateTime;
                                            oi.oPrepay = oPrepay;
                                        }
                                        oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson, typeof(OrderListDataJson));
                                        if (Orders.UpdateOrderInfoAndList(oi))
                                        {
                                            if (oi.oSteps == 3)
                                            {
                                                tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况
                                            }

                                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                            owl.OrderID = oi.OrderID;
                                            owl.UserID = this.userid;
                                            owl.oType = 1;
                                            owl.oMsg = OrderWorkingLogMsg;
                                            owl.pAppendTime = DateTime.Now;

                                            Orders.AddOrderWorkingLogInfo(owl);

                                            AddMsgLine("单据更新成功!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                        else
                                        {
                                            AddErrLine("更新单据失败!请重试!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                    }
                                }
                                else {
                                    AddErrLine("此单已作废,无法修改!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
                                }
                            }
                            break;
                        #endregion
                        #region 审核
                        case "s"://审核
                            if(!ispost)
                            {
                                try
                                {
                                    oi = Orders.GetOrderInfoModel(orderid);
                                    if (oi.oState != 1)
                                    {
                                        if (oi.oSteps == 1)
                                        {

											//验证库存数
										bool _isCheckProductsStock = false;

										if(oi.oType == 8){//调整单不进行验证
											_isCheckProductsStock = true;
										}else{
											_isCheckProductsStock = Orders.CheckOrderProductsStock(orderid);
										}
										if(_isCheckProductsStock){

	                                            //分配单号
	                                            if (oi.oOrderNum == "----------")
	                                            {
	                                                oi.oOrderNum = Orders.GetNewOrderNum();
	                                                if (!Orders.ExistsOrderInfo(oi.oOrderNum))
	                                                {
	                                                    Orders.UpdateOrderInfo(oi);
	                                                }
	                                                else
	                                                {
	                                                    AddErrLine("单号重复!请重新提交!");
	                                                }
	                                            }
	                                            if (page_err<=0)
	                                            {
	                                                
	                                                Orders.VerifyOrder(oi.OrderID);

	                                                tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

	                                                OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
	                                                owl.OrderID = oi.OrderID;
	                                                owl.UserID = this.userid;
	                                                owl.oType = 2;
	                                                owl.oMsg = OrderWorkingLogMsg;
	                                                owl.pAppendTime = DateTime.Now;

	                                                Orders.AddOrderWorkingLogInfo(owl);

													OrderInfo _nextOrder = new OrderInfo();
													_nextOrder =  Orders.GetNextOrder(oi.oType,
														0,//正常的单据
														1);//新建的单据
													if(_nextOrder!=null){
														MS_Json = ",\"NextOrderID\":"+_nextOrder.OrderID;
													}
													_nextOrder = null;
	                                                AddMsgLine("审核 操作成功!");


													//数据同步至SCM系统
													Orders.UpdateSCMProductsStockByOrderID(orderid);


	                                                #region 发送邮件给发货人员
	                                                try
	                                                {
	                                                    //oi = Orders.GetOrderInfoModel(OrderID);
	                                                    switch (oi.oType)
	                                                    {
	                                                        case 1://采购入库
	                                                            UsersUtils.SendUserMailByPopedom("3-1-1-3", "采购入库单 等待发货处理,单号:" + oi.oOrderNum, "采购入库单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 2://采购退货
	                                                            UsersUtils.SendUserMailByPopedom("3-1-2-3", "采购退货单 等待发货处理,单号:" + oi.oOrderNum, "采购退货单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 3://销售发货
	                                                            UsersUtils.SendUserMailByPopedom("3-2-1-3", "销售发货单 等待发货处理,单号:" + oi.oOrderNum, "销售发货单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 4://销售退货
	                                                            UsersUtils.SendUserMailByPopedom("3-2-2-3", "销售退货单 等待发货处理,单号:" + oi.oOrderNum, "销售退货单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 5://赠品
	                                                            UsersUtils.SendUserMailByPopedom("3-2-3-3", "赠品单 等待发货处理,单号:" + oi.oOrderNum, "赠品单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 6://样品
	                                                            UsersUtils.SendUserMailByPopedom("3-2-4-3", "样品单 等待发货处理,单号:" + oi.oOrderNum, "样品单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 7://代购
	                                                            UsersUtils.SendUserMailByPopedom("3-2-5-3", "代购单 等待发货处理,单号:" + oi.oOrderNum, "代购单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 11://换货
	                                                            UsersUtils.SendUserMailByPopedom("3-2-6-3", "换货单 等待发货处理,单号:" + oi.oOrderNum, "换货单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 10://坏货
	                                                            UsersUtils.SendUserMailByPopedom("3-3-3-3", "坏货单 等待发货处理,单号:" + oi.oOrderNum, "坏货单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 8://库存调整
	                                                            UsersUtils.SendUserMailByPopedom("3-3-1-3", "库存调整单 等待发货处理,单号:" + oi.oOrderNum, "库存调整单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                        case 9://库存调拨
	                                                            UsersUtils.SendUserMailByPopedom("3-3-2-3", "库存调拨单 等待发货处理,单号:" + oi.oOrderNum, "库存调拨单 等待发货处理,单号:" + oi.oOrderNum);
	                                                            break;
	                                                    }

	                                                }
	                                                catch
	                                                {
	                                                }

	                                                #endregion

	                                                #region 发邮件给业务员
	                                                // if (oi.StaffID != 0)
	                                                // {
	                                                //     tbStaffInfo.SendMailToStaff(oi.StaffID, "单号:" + oi.oOrderNum + "已审核等待发货,请注意跟踪.", "单号:" + oi.oOrderNum + "已审核等待发货,请注意跟踪.<br>单据处理情况:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim());
	                                                // }
	                                                #endregion
	                                            }
											}else{
												AddErrLine("库存数已更新，请重新审核,操作失败!");
											}
                                        }
                                        else
                                        {
                                            AddErrLine("该单据非新开单据,无法审核,操作失败!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("此单已作废!");
                                    }
                                }
								catch(Exception ex) {
									AddErrLine("审核 操作失败!请重试!"+ex.Message.ToString());
                                }

                            }
                            break;
                        #endregion
                        #region 发货
                        case "d":
                            if (!ispost)
                            {
                                try
                                {
                                    oi = Orders.GetOrderInfoModel(orderid);
                                    if (oi != null)
                                    {
                                        if (oi.oState != 1)
                                        {
                                            if (oi.oSteps == 2)
                                            {
                                               
                                                //网店订单自动发货处理
                                                try
                                                {
                                                    try
                                                    {
                                                        _ms = M_Utils.GetM_SendGoodsInfoModelByOrderID(oi.OrderID);
                                                        if (_ms != null)
                                                        {
                                                            IsMOrder = true;
                                                            _ms.mExpName = HTTPRequest.GetInt("ExpID", 0);
                                                            _ms.mExpNO = HTTPRequest.GetString("ExpNO").Trim();
                                                            if (_ms.mExpName <= 0)
                                                            {
                                                                AddErrLine("请填写物流公司信息.");
                                                            }
                                                            else {
                                                                if (_ms.mExpNO.Trim() == "")
                                                                {
                                                                    AddErrLine("请填写物流运单号.");
                                                                }
                                                            }
                                                            M_Utils.UpdateM_SendGoodsInfo(_ms);
                                                        }

                                                        if (page_err == 0)
                                                        {
                                                            oi.oSteps = 3;
                                                            Orders.UpdateOrderInfo(oi);

                                                            tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

                                                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                                            owl.OrderID = oi.OrderID;
                                                            owl.UserID = this.userid;
                                                            owl.oType = 3;
                                                            owl.oMsg = OrderWorkingLogMsg;
                                                            owl.pAppendTime = DateTime.Now;

                                                            Orders.AddOrderWorkingLogInfo(owl);
                                                            AddMsgLine("发货 操作成功!");

                                                            if (IsMOrder)
                                                            {
                                                                //同步网购发货
                                                                M_ConfigInfo _mc = new M_ConfigInfo();
                                                                _mc = Caches.GetMConfig(_ms.m_ConfigInfoID);
                                                                
                                                                if (_mc != null)
                                                                {
                                                                    //物流公司信息
                                                                    M_ExpressTemplatesInfo _mxp = new M_ExpressTemplatesInfo();
                                                                    _mxp = M_Utils.GetM_ExpressTemplatesInfoModel(_ms.mExpName);
                                                                    if (_mxp != null)
                                                                    {
                                                                        PublicReMSG _msReMSG = new PublicReMSG();
                                                                        string _m_TradeInfoID = _ms.m_TradeInfoID;
                                                                        string[] _m_TradeInfoIDArr = Utils.SplitString(_m_TradeInfoID, ",");
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
                                                                                            _msReMSG = TopApiUtils.DeliverySend(_mc, _mt.tid, _ms.mExpNO, _mxp.mName, 0, 0);
                                                                                            if (_msReMSG != null)
                                                                                            {
                                                                                                if (_msReMSG.reCode == 0)
                                                                                                {
                                                                                                    AddMsgLine(_msReMSG.reMSG);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    AddErrLine(_msReMSG.reMSG);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    catch (Exception _mex)
                                                                                    {
                                                                                        AddErrLine("网购订单同步发货时出现错误,请手动发货处理!" + _mex.Message.ToString());
                                                                                    }
                                                                                }
                                                                                finally
                                                                                {
                                                                                    _mt = null;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else {
                                                                        AddErrLine("网购订单中的物流信息有错!请手动发货!");
                                                                    }
                                                                }
                                                                else {
                                                                    AddErrLine("网购订单所属网店不存在!无法同步网购订单!");
                                                                }
                                                            }
                                                            
                                                        }
                                                        else {
                                                            MS_Json = ",\"MS_Order\":{\"Exp\":false}";
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        _ms = null;
                                                    }
                                                }
                                                catch (Exception mex)
                                                {
                                                    AddErrLine("网店订单发货同步处理时出现错误!" + mex.Message.ToString());
                                                }


                                                try
                                                {
                                                    #region 发送邮件给收货人员
                                                    //oi = Orders.GetOrderInfoModel(OrderID);
                                                    switch (oi.oType)
                                                    {
                                                        case 1://采购入库
                                                            UsersUtils.SendUserMailByPopedom("3-1-1-4", "采购入库单 等待收货处理,单号:" + oi.oOrderNum, "采购入库单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 2://采购退货
                                                            UsersUtils.SendUserMailByPopedom("3-1-2-4", "采购退货单 等待收货处理,单号:" + oi.oOrderNum, "采购退货单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 3://销售发货
                                                            UsersUtils.SendUserMailByPopedom("3-2-1-4", "销售发货单 等待收货处理,单号:" + oi.oOrderNum, "销售发货单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 4://销售退货
                                                            UsersUtils.SendUserMailByPopedom("3-2-2-4", "销售退货单 等待收货处理,单号:" + oi.oOrderNum, "销售退货单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 5://赠品
                                                            UsersUtils.SendUserMailByPopedom("3-2-3-4", "赠品单 等待收货处理,单号:" + oi.oOrderNum, "赠品单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 6://样品
                                                            UsersUtils.SendUserMailByPopedom("3-2-4-4", "样品单 等待收货处理,单号:" + oi.oOrderNum, "样品单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 7://代购
                                                            UsersUtils.SendUserMailByPopedom("3-2-5-4", "代购单 等待收货处理,单号:" + oi.oOrderNum, "代购单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 11://换货
                                                            UsersUtils.SendUserMailByPopedom("3-2-6-4", "换货单 等待收货处理,单号:" + oi.oOrderNum, "换货单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 10://坏货
                                                            UsersUtils.SendUserMailByPopedom("3-3-3-4", "坏货单 等待收货处理,单号:" + oi.oOrderNum, "坏货单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 8://库存调整
                                                            UsersUtils.SendUserMailByPopedom("3-3-1-4", "库存调整单 等待收货处理,单号:" + oi.oOrderNum, "库存调整单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 9://库存调拨
                                                            UsersUtils.SendUserMailByPopedom("3-3-2-4", "库存调拨单 等待收货处理,单号:" + oi.oOrderNum, "库存调拨单 等待收货处理,单号:" + oi.oOrderNum);
                                                            break;
                                                    }
                                                    #endregion

                                                    

                                                   
                                                    switch (oi.oType)
                                                    {

                                                        case 3:
                                                        case 4:
                                                        case 5:
                                                        case 6:
                                                            #region 发邮件给业务员
                                                            if (oi.StaffID != 0)
                                                            {
                                                                tbStaffInfo.SendMailToStaff(oi.StaffID, tbStoresInfo.GetStoresInfoModel(oi.StoresSupplierID).sName + "," + GetOrderType(oi.oType.ToString()) + "单:" + oi.oOrderNum + "已发货.", "客户:" + tbStoresInfo.GetStoresInfoModel(oi.StoresSupplierID).sName + ",的" + GetOrderType(oi.oType.ToString()) + "单,单号:" + oi.oOrderNum + "已发货等待收货,请注意跟踪.<br>单据处理情况:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim());
                                                            }
                                                            #endregion

                                                            #region 给客户发邮件
                                                            tbStoresInfo.SendMailToStores(oi.StoresSupplierID, GetOrderType(oi.oType.ToString()) + "单 已发货,单号:" + oi.oOrderNum, GetOrderType(oi.oType.ToString()) + "单 已发货,单号:" + oi.oOrderNum);
                                                            #endregion
                                                            break;
                                                    }
                                                   
                                                }
                                                catch
                                                {
                                                }
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
                                    else {
                                        AddErrLine("参数错误,该单据不存在!请重试!");
                                    }
                                }
                                catch
                                {
                                    AddErrLine("发货 操作失败!请重试!");
                                }
                            }
                            break;
                        #endregion
                        #region 收货
                        case "r":
                            if (!ispost)
                            {
                                try
                                {
                                    oi = Orders.GetOrderInfoModel(orderid);
                                    if (oi != null)
                                    {
                                        if (oi.oState != 1)
                                        {
                                            if (oi.oSteps == 3)
                                            {
                                                oi.oSteps = 4;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

                                                OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 4;
                                                owl.oMsg = OrderWorkingLogMsg;
                                                owl.pAppendTime = DateTime.Now;

                                                Orders.AddOrderWorkingLogInfo(owl);

                                                Orders.UpdateSCMProductsStockByOrderID(orderid);

                                                AddMsgLine("收货 操作成功!");

                                                #region 发送邮件给核销人员
                                                try
                                                {
                                                    //oi = Orders.GetOrderInfoModel(OrderID);
                                                    switch (oi.oType)
                                                    {
                                                        case 1://采购入库
                                                            UsersUtils.SendUserMailByPopedom("3-1-1-5", "采购入库单 等待核销处理,单号:" + oi.oOrderNum, "采购入库单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 2://采购退货
                                                            UsersUtils.SendUserMailByPopedom("3-1-2-5", "采购退货单 等待核销处理,单号:" + oi.oOrderNum, "采购退货单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 3://销售发货
                                                            UsersUtils.SendUserMailByPopedom("3-2-1-5", "销售发货单 等待核销处理,单号:" + oi.oOrderNum, "销售发货单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 4://销售退货
                                                            UsersUtils.SendUserMailByPopedom("3-2-2-5", "销售退货单 等待核销处理,单号:" + oi.oOrderNum, "销售退货单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 5://赠品
                                                            UsersUtils.SendUserMailByPopedom("3-2-3-5", "赠品单 等待核销处理,单号:" + oi.oOrderNum, "赠品单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 6://样品
                                                            UsersUtils.SendUserMailByPopedom("3-2-4-5", "样品单 等待核销处理,单号:" + oi.oOrderNum, "样品单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 7://代购
                                                            UsersUtils.SendUserMailByPopedom("3-2-5-5", "代购单 等待核销处理,单号:" + oi.oOrderNum, "代购单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 11://换货
                                                            UsersUtils.SendUserMailByPopedom("3-2-6-5", "换货单 等待核销处理,单号:" + oi.oOrderNum, "换货单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 10://坏货
                                                            UsersUtils.SendUserMailByPopedom("3-3-3-5", "坏货单 等待核销处理,单号:" + oi.oOrderNum, "坏货单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 8://库存调整
                                                            UsersUtils.SendUserMailByPopedom("3-3-1-5", "库存调整单 等待核销处理,单号:" + oi.oOrderNum, "库存调整单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 9://库存调拨
                                                            UsersUtils.SendUserMailByPopedom("3-3-2-5", "库存调拨单 等待核销处理,单号:" + oi.oOrderNum, "库存调拨单 等待核销处理,单号:" + oi.oOrderNum);
                                                            break;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                                #endregion
                                                #region 发邮件给业务员
                                                //if (oi.StaffID != 0)
                                                //{
                                                //    tbStaffInfo.SendMailToStaff(oi.StaffID, "单号:" + oi.oOrderNum + "已收货等待核销,请注意跟踪.", "单号:" + oi.oOrderNum + "已收货等待核销,请注意跟踪.<br>单据处理情况:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim());
                                                //}
                                                #endregion
                                            }
                                            else
                                            {
                                                AddErrLine("单据非 已发货 待 收货 状态,无法进行 收货 操作!请重试!");
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
                                    AddErrLine("收货 操作失败!请重试!");
                                }
                            }
                            break;
                        #endregion
                        #region 核销
                        case "vv":
                            if (!ispost)
                            {
                                try
                                {
                                    oi = Orders.GetOrderInfoModel(orderid);
                                    if (oi != null)
                                    {
                                        if (oi.oState != 1)
                                        {
                                            if (oi.oSteps == 4)
                                            {
                                                //oWorkType=1 时更新一次库存
                                                tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

                                                oi.oSteps = 5;
                                                Orders.UpdateOrderInfo(oi);

                                                //oWorkType=2 时再更新一次库存
                                                tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

                                                OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = 5;
                                                owl.oMsg = OrderWorkingLogMsg;
                                                owl.pAppendTime = DateTime.Now;

                                                Orders.AddOrderWorkingLogInfo(owl);

												OrderInfo _nextOrder = new OrderInfo();
												_nextOrder =  Orders.GetNextOrder(oi.oType,
													0,//正常的单据
													4);//新建的单据
												if(_nextOrder!=null){
													MS_Json = ",\"NextOrderID\":"+_nextOrder.OrderID;
												}
												_nextOrder = null;

                                                AddMsgLine("核销 操作成功!");

                                                #region 发送邮件给对账人员
                                                try
                                                {
                                                    //oi = Orders.GetOrderInfoModel(OrderID);
                                                    switch (oi.oType)
                                                    {
                                                        case 1://采购入库
                                                            UsersUtils.SendUserMailByPopedom("6-6-2-2", "采购入库单 等待对账处理,单号:" + oi.oOrderNum, "采购入库单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 2://采购退货
                                                            UsersUtils.SendUserMailByPopedom("6-6-2-2", "采购退货单 等待对账处理,单号:" + oi.oOrderNum, "采购退货单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 3://销售发货
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "销售发货单 等待对账处理,单号:" + oi.oOrderNum, "销售发货单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 4://销售退货
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "销售退货单 等待对账处理,单号:" + oi.oOrderNum, "销售退货单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 5://赠品
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "赠品单 等待对账处理,单号:" + oi.oOrderNum, "赠品单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 6://样品
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "样品单 等待对账处理,单号:" + oi.oOrderNum, "样品单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 7://代购
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "代购单 等待对账处理,单号:" + oi.oOrderNum, "代购单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 11://换货
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "换货单 等待对账处理,单号:" + oi.oOrderNum, "换货单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                        case 10://坏货
                                                            UsersUtils.SendUserMailByPopedom("6-6-1-2", "坏货单 等待对账处理,单号:" + oi.oOrderNum, "坏货单 等待对账处理,单号:" + oi.oOrderNum);
                                                            break;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                                #endregion
                                                #region 发邮件给业务员
                                                //if (oi.StaffID != 0)
                                                //{
                                                //    tbStaffInfo.SendMailToStaff(oi.StaffID, "单号:" + oi.oOrderNum + "已核销等待对账,请注意跟踪.", "单号:" + oi.oOrderNum + "已核销等待对账,请注意跟踪.<br>单据处理情况:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim());
                                                //}
                                                #endregion
                                            }
                                            else
                                            {
                                                AddErrLine("单据非 已收货 待 核销 状态,无法进行 核销 操作!请重试!");
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
                                    AddErrLine("核销 操作失败!请重试!");
                                }
                            }
                            break;
                        #endregion
                        #region 作废
                        case "i":
                            if (!ispost)
                            {
                                try
                                {
                                    oi = Orders.GetOrderInfoModel(orderid);
                                    if (oi != null)
                                    {
                                        if (oi.oSteps == 2)
                                        {
                                            oi.oState = 1;
                                            Orders.UpdateOrderInfo(oi);

                                            tbProductsInfo.UpdateProductsStorageByOrderID(orderid);//更新当前在途库存情况

                                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                            owl.OrderID = oi.OrderID;
                                            owl.UserID = this.userid;
                                            owl.oType = -1;
                                            owl.oMsg = OrderWorkingLogMsg;
                                            owl.pAppendTime = DateTime.Now;

                                            Orders.AddOrderWorkingLogInfo(owl);

                                            AddMsgLine("作废 操作成功!");

                                            //数据同步至SCM系统
                                            Orders.UpdateSCMProductsStockByOrderID(orderid);
                                        }
                                        else
                                        {
                                            AddErrLine("单据非 已审核 待 发货 状态,无法进行 作废 操作!请重试!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误,该单据不存在!请重试!");
                                    }
                                }
                                catch
                                {
                                    AddErrLine("作废 操作失败!请重试!");
                                }
                            }
                            break;
                        #endregion
                    }
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
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
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"}" + MS_Json + "}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 单据信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
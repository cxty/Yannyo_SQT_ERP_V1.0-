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

namespace Yannyo.Web
{
    public partial class monthlystatementlist_do : PageBase
    {
        public MonthlyStatementInfo ms = new MonthlyStatementInfo();
        public string Act = "";
        public int MonthlyStatementID = 0;
        public int sType = -1;
        public string MonthlyStatementDataJsonStr = "";

        public string DepartmentsJson = "";
        public string SupplierJson = "";
        public string CustomersJson = "";
        public string PaymentSystemJson = "";
        public int NextMonthlyStatementID = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            /*
            MonthlyStatementDataJson msd = new MonthlyStatementDataJson();
            MonthlyStatementDataInfo[] msdi = new MonthlyStatementDataInfo[1];
            msdi[0] = new MonthlyStatementDataInfo();
            msdi[0].sAppendTime = DateTime.Now;

            MonthlyStatementAppendDataInfo[] msad = new MonthlyStatementAppendDataInfo[1];
            msad[0] = new MonthlyStatementAppendDataInfo();
            msad[0].aAppendTime = DateTime.Now;

            msd.MonthlyStatementAppendData = msad;
            msd.MonthlyStatementData = msdi;

            MonthlyStatementDataJsonStr = JavaScriptConvert.SerializeObject(msd);
            */
            if (this.userid > 0)
            {
                string format = "";
                format = HTTPRequest.GetString("format");
                sType = HTTPRequest.GetInt("sType", -1);
                if (sType > -1 || format=="json")
                {
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-1") || CheckUserPopedoms("6-6-1-2") || CheckUserPopedoms("6-6-1-3") || CheckUserPopedoms("6-6-1-4") || CheckUserPopedoms("6-6-1-5") || CheckUserPopedoms("6-6-1-6") || CheckUserPopedoms("6-6-2-1") || CheckUserPopedoms("6-6-2-2") || CheckUserPopedoms("6-6-2-3") || CheckUserPopedoms("6-6-2-4") || CheckUserPopedoms("6-6-2-5") || CheckUserPopedoms("6-6-2-6") || CheckUserPopedoms("6-6-3-1") || CheckUserPopedoms("6-6-3-2") || CheckUserPopedoms("6-6-3-3") || CheckUserPopedoms("6-6-3-4") || CheckUserPopedoms("6-6-3-5") || CheckUserPopedoms("6-6-3-6"))
                    {
                        
                        Act = Utils.ChkSQL(HTTPRequest.GetString("Act")).Trim();
                        #region 权限判断
                        switch (Act)
                        {
                            case "Add":
                            case "0":
                                switch (sType)
                                {
                                    case 2://应收
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-2"))
                                        {
                                        }
                                        else {
                                            AddErrLine("权限不足,需 创建应收对账单权限!");
                                        }
                                        break;
                                    case 1://应付
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-2"))
                                        {
                                        }
                                        else {
                                            AddErrLine("权限不足,需 创建应付对账单权限!");
                                        }
                                        break;
                                    case 3://其他
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-2"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 创建其他类型对账单权限!");
                                        }
                                        break;
                                }
                                break;
                            case "Edit":
                            case "v":
                                if (ispost)
                                {
                                    switch (sType)
                                    {
                                        case 2://应收
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-4"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 修改应收对账单权限!");
                                            }
                                            break;
                                        case 1://应付
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-4"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 修改应付对账单权限!");
                                            }
                                            break;
                                        case 3://其他 
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-4"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 修改其他类型对账单权限!");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (sType)
                                    {
                                        case 2://应收
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-1"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 查看应收对账单权限!");
                                            }
                                            break;
                                        case 1://应付
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-1"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 查看应付对账单权限!");
                                            }
                                            break;
                                        case 3://其他
                                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-1"))
                                            {
                                            }
                                            else
                                            {
                                                AddErrLine("权限不足,需 查看其他类型对账单权限!");
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "1"://完成对账
                            case "d":
                                switch (sType)
                                {
                                    case 2://应收
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-3"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成对账 权限!");
                                        }
                                        break;
                                    case 1://应付
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-3"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成对账 权限!");
                                        }
                                        break;
                                    case 3://其他
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-3"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成对账 权限!");
                                        }
                                        break;
                                }
                                break;
                            case "2"://到款
                            case "m":
                                switch (sType)
                                {
                                    case 2://应收
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-5"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成到款 权限!");
                                        }
                                        break;
                                    case 1://应付
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-5"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成到款 权限!");
                                        }
                                        break;
                                    case 3://其他
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-5"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 完成到款 权限!");
                                        }
                                        break;
                                }
                                break;
                            case "3"://结账
                            case "e":
                                switch (sType)
                                {
                                    case 2://应收
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-6"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 结账 权限!");
                                        }
                                        break;
                                    case 1://应付
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-6"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 结账 权限!");
                                        }
                                        break;
                                    case 3://其他
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-6"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 结账 权限!");
                                        }
                                        break;
                                }
                                break;
                            case "i"://作废
                                switch (sType)
                                {
                                    case 2://应收
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-7"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 作废 权限!");
                                        }
                                        break;
                                    case 1://应付
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-7"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 作废 权限!");
                                        }
                                        break;
                                    case 3://其他
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-7"))
                                        {
                                        }
                                        else
                                        {
                                            AddErrLine("权限不足,需 作废 权限!");
                                        }
                                        break;
                                }
                                break;
                        }
                        #endregion;

                        if (!IsErr())
                        {
                            MonthlyStatementID = HTTPRequest.GetInt("MonthlyStatementID", 0);
                            string MonthlyStatementWorkingLogMsg = HTTPRequest.GetString("MonthlyStatementWorkingLogMsg");
                            int sObjectID = HTTPRequest.GetInt("sObjectID", 0);
                            int sObjectType = HTTPRequest.GetInt("sObjectType", 0);
                            decimal sUpMoney = 0;// (HTTPRequest.GetString("sUpMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("sUpMoney").Trim()) : 0;
                            decimal sThisMoney = (HTTPRequest.GetString("sThisMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("sThisMoney").Trim()) : 0;
                            decimal sMoney = 0;// (HTTPRequest.GetString("sMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("sMoney").Trim()) : 0;
                            decimal sToMoney = (HTTPRequest.GetString("sToMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("sToMoney").Trim()) : 0;
                            decimal sBalanceMoney = 0;// (HTTPRequest.GetString("sBalanceMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("sBalanceMoney").Trim()) : 0;

                            int sBalanceType = HTTPRequest.GetInt("sBalanceType", 0);
                            int sReceiptState = HTTPRequest.GetInt("sReceiptState", 0);
                            DateTime sDateTime = (HTTPRequest.GetString("sDateTime").Trim() != "") ? Convert.ToDateTime(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) : DateTime.Now;

                            string _MonthlyStatementDataJson = HTTPRequest.GetString("MonthlyStatementDataJson");

                           

                            DepartmentsJson = Caches.GetDepartmentsClassInfoToJson(-1, true, true);
                            SupplierJson = Caches.GetSupplierClassInfoToJson(-1, true, true);
                            CustomersJson = Caches.GetCustomersClassInfoToJson(-1, true, true);
                            PaymentSystemJson = Caches.GetPaymentSystemJson();

                            #region 获取同步骤的下一对账单信息,对账确认,到款,结账
                            if ((",1,d,2,m,3,e,").IndexOf(Act) > -1)
                            {
                                int sSteps = 0;
                                switch (Act)
                                {
                                    case "1": case "d":
                                        sSteps = 0;
                                        break;
                                    case "2": case "m":
                                        sSteps = 1;
                                        break;
                                    case "3": case "e":
                                        sSteps = 2;
                                        break;
                                }
                                DataSet NextDS = MonthlyStatements.GetMonthlyStatementInfoList(1, " MonthlyStatementID>" + MonthlyStatementID + " and sSteps=" + sSteps + "", " MonthlyStatementID asc");
                                if (NextDS != null)
                                {
                                    if (NextDS.Tables[0].Rows.Count > 0)
                                    {
                                        NextMonthlyStatementID = Convert.ToInt32(NextDS.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                                    }
                                }
                            }
                            #endregion

                            switch (Act)
                            {
                                #region 新建
                                case "Add":
                                case "0":
                                    if (ispost)
                                    {
                                        ms.sCode = MonthlyStatements.GetNewNum();
                                        if (!MonthlyStatements.ExistsMonthlyStatementInfo(ms.sCode))
                                        {
                                            ms.sObjectID = sObjectID;
                                            ms.sObjectType = sObjectType;
                                            ms.sType = sType;
                                            ms.sUpMoney = sUpMoney;
                                            ms.sThisMoney = sThisMoney;
                                            ms.sMoney = sMoney;
                                            ms.sToMoney = sToMoney;
                                            ms.sBalanceMoney = sBalanceMoney;
                                            ms.sSteps = 0;
                                            ms.sBalanceType = sBalanceType;
                                            ms.sReceiptState = sReceiptState;
                                            ms.sDateTime = sDateTime;
                                            ms.sState = 0;
                                            ms.UserID = this.userid;
                                            ms.sAppendTime = DateTime.Now;

                                            ms.MonthlyStatementDataJson = (MonthlyStatementDataJson)JavaScriptConvert.DeserializeObject(_MonthlyStatementDataJson, typeof(MonthlyStatementDataJson));

                                            MonthlyStatementID = MonthlyStatements.AddMonthlyStatementInfo(ms);
                                            if (MonthlyStatementID > 0)
                                            {
                                                AddMsgLine("对账单创建成功!<p class=\"SendGood\"><br>继续开单?-><a href=\"javascript:void(0);\" onclick=\"javascript:MonthlyStatementList_do.Re(" + MonthlyStatementID + ");\">开单</a><br>查看单据?-><a href=\"javascript:void(0);\" onclick=\"javascript:MonthlyStatementList_do.Show(" + MonthlyStatementID + "," + sType + ");\">查看</a></p>");

                                                MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                mwl.MonthlyStatementID = MonthlyStatementID;
                                                mwl.UserID = this.userid;
                                                mwl.mType = 0;
                                                mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                mwl.mAppendTime = DateTime.Now;

                                                MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                                                MonthlyStatements.UpdateMonthlyStatementSteps(MonthlyStatementID, 0);
                                            }
                                            else {
                                                AddErrLine("对账单创建失败,请重试!");
                                            }
                                        }
                                        else
                                        {
                                            AddErrLine("对账单号重复,请重试!");
                                        }
                                    }
                                    break;
                                #endregion
                                #region 修改
                                case "Edit":
                                case "v":
                                    ms = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                                    if (ms != null)
                                    {
                                        if (!ispost)
                                        {
                                            DataTable tmsd = new DataTable();
                                            DataTable tmsad = new DataTable();

                                            #region 单据列表
                                            tmsd = MonthlyStatements.GetMonthlyStatementDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " order by sAppendTime desc").Tables[0];
                                            string MonthlyStatementDataStr = "";
                                            if (tmsd != null)
                                            {
                                                if (tmsd.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in tmsd.Rows)
                                                    {
                                                        MonthlyStatementDataStr += " {\"MonthlyStatementDataID\":\"" + dr["MonthlyStatementDataID"].ToString() + "\",\"MonthlyStatementID\":\"" + dr["MonthlyStatementID"].ToString() + "\",\"OrderID\":\"" + dr["OrderID"].ToString() + "\"," +
                                                           "\"oMoney\":\"" + dr["oMoney"].ToString() + "\",\"sRemake\":\"" + dr["sRemake"].ToString() + "\",\"sAppendTime\":\"" + dr["sAppendTime"].ToString() + "\"," + "\"StoresSupplierName\":\"" + dr["StoresSupplierName"].ToString() + "\"," +
                                                           "\"oOrderNum\":\"" + dr["oOrderNum"].ToString() + "\",\"oOrderDateTime\":\"" + Convert.ToDateTime(dr["oOrderDateTime"].ToString()).ToString("yyyy-MM-dd") + "\",\"StaffName\":\"" + dr["StaffName"].ToString() + "\",\"oTypeStr\":\"" + GetOrderType(dr["oType"].ToString()) + "\",\"oType\":\"" + dr["oType"].ToString() + "\"},";
                                                    }
                                                }

                                            }
                                            if (MonthlyStatementDataStr.Trim() != "")
                                            {
                                                MonthlyStatementDataStr = MonthlyStatementDataStr.Substring(0, MonthlyStatementDataStr.Length - 1);
                                            }
                                            MonthlyStatementDataStr = "\"MonthlyStatementData\":[" + MonthlyStatementDataStr + "]";
                                            #endregion

                                            #region 凭证列表
                                            string MonthlyStatementAppendDataStr = "";
                                            tmsad = MonthlyStatements.GetMonthlyStatementAppendDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " and aState=0 order by aAppendTime desc").Tables[0];
                                            if (tmsad != null)
                                            {
                                                if (tmsad.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in tmsad.Rows)
                                                    {
                                                        MonthlyStatementAppendDataStr += "{\"MonthlyStatementAppendDataID\":\"" + dr["MonthlyStatementAppendDataID"].ToString() + "\",\"MonthlyStatementID\":\"" + dr["MonthlyStatementID"].ToString() + "\",\"CertificateID\":\"" + dr["CertificateID"].ToString() + "\"," +
                                                                                                                    "\"aState\":\"" + dr["aState"].ToString() + "\",\"aRemake\":\"" + dr["aRemake"].ToString() + "\"," +
                                                                                                                    "\"cCode\":\"" + Convert.ToDateTime(dr["cDateTime"]).ToString("yyyyMMdd") + "-" + (dr["cNumber"].ToString()).PadLeft(config.CertificateCodeLen, '0') + "\"," +
                                                                                                                    "\"toObjectName\":\"" + dr["toObjectName"].ToString() + "\"," +
                                                                                                                    "\"aAppendTime\":\"" + dr["aAppendTime"].ToString() + "\",\"cMoney\":\"" + dr["cMoney"].ToString() + "\"," +
                                                                                                                    "\"cType\":\"" + dr["cType"].ToString() + "\",\"cTypeStr\":\"" + GetCertificateType(dr["cType"].ToString()) + "\"," +
                                                                                                                    "\"UserID\":\"" + dr["UserID"].ToString() + "\",\"UserName\":\"" + dr["UserName"].ToString() + "\"," +
                                                                                                                    "\"UserStaffName\":\"" + dr["UserStaffName"].ToString() + "\",\"StaffName\":\"" + dr["StaffName"].ToString() + "\"," +
                                                                                                                    "\"StaffID\":\"" + dr["StaffID"].ToString() + "\",\"cDateTime\":\"" + Convert.ToDateTime(dr["cDateTime"].ToString()).ToString("yyyy-MM-dd") + "\"," +
                                                                                                                    "\"cObject\":\"" + dr["cObject"].ToString() + "\",\"cObjectID\":\"" + dr["cObjectID"].ToString() + "\"},";
                                                    }
                                                }
                                            }
                                            if (MonthlyStatementAppendDataStr.Trim() != "")
                                            {
                                                MonthlyStatementAppendDataStr = MonthlyStatementAppendDataStr.Substring(0, MonthlyStatementAppendDataStr.Length - 1);
                                            }
                                            MonthlyStatementAppendDataStr = "\"MonthlyStatementAppendData\":[" + MonthlyStatementAppendDataStr + "]";
                                            #endregion

                                            #region 发生金额列表
                                            string MonthlyStatementAppendMoneyDataStr = "";
                                            tmsad = MonthlyStatements.GetMonthlyStatementAppendMoneyDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " and mState=0 order by mAppendTime desc").Tables[0];
                                            if (tmsad != null)
                                            {
                                                if (tmsad.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in tmsad.Rows)
                                                    {
                                                        MonthlyStatementAppendMoneyDataStr += "{\"MonthlyStatementAppendMoneyDataID\":\"" + dr["MonthlyStatementAppendMoneyDataID"].ToString() + "\",\"MonthlyStatementID\":\"" + dr["MonthlyStatementID"].ToString() + "\",\"mMoney\":\"" + dr["mMoney"].ToString() + "\",\"mDateTime\":\"" +Convert.ToDateTime(dr["mDateTime"]).ToString("yyyy-MM-dd") + "\",\"mState\":\"" + dr["mState"].ToString() + "\",\"mRemake\":\"" + dr["mRemake"].ToString() + "\",\"mAppendTime\":\"" + dr["mAppendTime"].ToString() + "\"},";
                                                    }
                                                }
                                            }
                                            if (MonthlyStatementAppendMoneyDataStr.Trim() != "")
                                            {
                                                MonthlyStatementAppendMoneyDataStr = MonthlyStatementAppendMoneyDataStr.Substring(0, MonthlyStatementAppendMoneyDataStr.Length - 1);
                                            }
                                            MonthlyStatementAppendMoneyDataStr = "\"MonthlyStatementAppendMoneyData\":[" + MonthlyStatementAppendMoneyDataStr + "]";
                                            #endregion

                                            MonthlyStatementDataJsonStr = "{\"MonthlyStatementDataJson\":{" + MonthlyStatementDataStr + "," + MonthlyStatementAppendDataStr + "," + MonthlyStatementAppendMoneyDataStr + "}}";
                                        }
                                        else
                                        {
                                            ms.sObjectID = sObjectID;
                                            ms.sObjectType = sObjectType;
                                            ms.sType = sType;
                                            ms.sUpMoney = sUpMoney;
                                            ms.sThisMoney = sThisMoney;
                                            ms.sMoney = sMoney;
                                            ms.sToMoney = sToMoney;
                                            ms.sBalanceMoney = sBalanceMoney;
                                            //ms.sSteps = 0;
                                            ms.sBalanceType = sBalanceType;
                                            ms.sReceiptState = sReceiptState;
                                            ms.sDateTime = sDateTime;
                                            //ms.sState = 0;
                                            //ms.UserID = this.userid;
                                            //ms.sAppendTime = DateTime.Now;

                                            ms.MonthlyStatementDataJson = (MonthlyStatementDataJson)JavaScriptConvert.DeserializeObject(_MonthlyStatementDataJson, typeof(MonthlyStatementDataJson));

                                            try
                                            {
                                                MonthlyStatements.UpdateMonthlyStatementInfo(ms);

                                                MonthlyStatements.UpdateMonthlyStatementSteps(MonthlyStatementID, ms.sSteps);//更新新单据步骤

                                                MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                mwl.MonthlyStatementID = MonthlyStatementID;
                                                mwl.UserID = this.userid;
                                                mwl.mType = 1;
                                                mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                mwl.mAppendTime = DateTime.Now;

                                                MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                                                AddMsgLine("对账单更新成功!");
                                                AddScript("window.setTimeout('location=location;',2000);");
                                            }catch(Exception ex)
                                            {
                                                AddErrLine("内部错误,请重试!"+ex.Message);
                                            }
                                        }
                                    }
                                    else {
                                        AddErrLine("参数错误,请重试!");
                                    }
                                    break;
                                #endregion
                                #region 对账确认
                                case "1":
                                case "d"://完成对账,对账确认
                                    if (!ispost)
                                    {
                                        try
                                        {
                                            ms = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                                            if (ms != null)
                                            {
                                                if (ms.sSteps == 0)
                                                {
                                                    MonthlyStatements.UpdateMonthlyStatementSteps(MonthlyStatementID,1);

                                                    MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                    mwl.MonthlyStatementID = MonthlyStatementID;
                                                    mwl.UserID = this.userid;
                                                    mwl.mType = 2;
                                                    mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                    mwl.mAppendTime = DateTime.Now;

                                                    MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                                                    //获取下一张未对账确认对账单


                                                    AddMsgLine("对账确认成功!");

                                                }
                                                else 
                                                {
                                                    AddErrLine("非新开对账单,无法进行对账确认操作,请重试!");
                                                }
                                            }
                                            else 
                                            {
                                                AddErrLine("参数错误,请重试!");
                                            }
                                        }
                                        catch
                                        {
                                            AddErrLine("对账确认 操作失败!请重试!");
                                        }

                                    }
                                    break;
                                #endregion
                                #region 到款
                                case "2":
                                case "m"://到款
                                    if (!ispost)
                                    {
                                        try
                                        {
                                            ms = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                                            if (ms != null)
                                            {
                                                if (ms.sSteps == 1)
                                                {
                                                    MonthlyStatements.UpdateMonthlyStatementSteps(MonthlyStatementID, 2);

                                                    MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                    mwl.MonthlyStatementID = MonthlyStatementID;
                                                    mwl.UserID = this.userid;
                                                    mwl.mType = 3;
                                                    mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                    mwl.mAppendTime = DateTime.Now;

                                                    MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                                                    AddMsgLine("到款 操作成功!");

                                                }
                                                else
                                                {
                                                    AddErrLine("非已对账确认的对账单,无法进行到款操作,请重试!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误,请重试!");
                                            }
                                        }
                                        catch
                                        {
                                            AddErrLine("到款 操作失败!请重试!");
                                        }
                                    }
                                    break;
                                #endregion
                                #region 结账
                                case "3":
                                case "e"://结账
                                    if (!ispost)
                                    {
                                        try
                                        {
                                            ms = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                                            if (ms != null)
                                            {
                                                if (ms.sSteps == 2)
                                                {
                                                    MonthlyStatements.UpdateMonthlyStatementSteps(MonthlyStatementID, 3);

                                                    MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                    mwl.MonthlyStatementID = MonthlyStatementID;
                                                    mwl.UserID = this.userid;
                                                    mwl.mType = 4;
                                                    mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                    mwl.mAppendTime = DateTime.Now;

                                                    MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                                                    AddMsgLine("结账 操作成功!");

                                                }
                                                else
                                                {
                                                    AddErrLine("非已到款的对账单,无法进行结账操作,请重试!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误,请重试!");
                                            }
                                        }
                                        catch
                                        {
                                            AddErrLine("结账 操作失败!请重试!");
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
                                            ms = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                                            if (ms != null)
                                            {
                                                if (ms.sSteps <= 1)
                                                {
                                                    //更新对账单状态
                                                    MonthlyStatements.UpdateMonthlyStatementState(MonthlyStatementID);
                                                    MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                                                    mwl.MonthlyStatementID = MonthlyStatementID;
                                                    mwl.UserID = this.userid;
                                                    mwl.mType = -1;
                                                    mwl.mMsg = MonthlyStatementWorkingLogMsg;
                                                    mwl.mAppendTime = DateTime.Now;

                                                    MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);
                                                    AddMsgLine("作废 操作成功!");
                                                }
                                                else
                                                {
                                                    AddErrLine("到款后的对账单无法作废!");
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("参数错误,请重试!");
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

                        if (format == "json")
                        {
                            Response.ClearContent();
                            Response.Buffer = true;
                            Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                            Response.Expires = 0;

                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            Response.ContentType = "application/json";
                            string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\",\"NextMonthlyStatementID\":\"" + NextMonthlyStatementID + "\"}}";
                            Response.Write(Json_Str);
                            Response.End();
                        }
                    }
                    else
                    {
                        AddErrLine("权限不足!");
                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                    }
                }
                else {
                    AddErrLine("参数错误!");
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
            pagetitle = " 对账单信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
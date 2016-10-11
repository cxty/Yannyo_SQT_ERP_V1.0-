using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web.Services
{
    public partial class CAjax : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string doAction;
            string doValue;
            string Rss_XML = "";
            string FullRss_XML = "";
            bool XML_IsNull = false;
            bool ReJson = false;
			bool ReTxt = false;
            string Json_Str = "";
            bool ReChartsXML = false;
            string User_Name = "";
            string User_PWD = "";
            DateTime bDate = DateTime.Now;
            DateTime eDate = DateTime.Now;
            int tAction = 0;

            if (!IsPostBack)
            {
                System.IO.StreamReader PostdoValue = new System.IO.StreamReader(HttpContext.Current.Request.InputStream);
                ArrayList list = new ArrayList();
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    doAction = HTTPRequest.GetQueryString("do").ToString();
                    doValue = (HTTPRequest.GetQueryString("doValue") != null) ? HTTPRequest.GetQueryString("doValue").ToString() : "";

                    if (HTTPRequest.IsPost())
                    {
                        if (PostdoValue.ToString().Trim() == "")
                        {
                            XML_IsNull = false;
                            Rss_XML = "<Error>0</Error><MSG><![CDATA[Post数据无效,请重新发送.]]></MSG>";
                        }
                        else
                        {
                            XML_IsNull = true;
                        }
                    }
                    else
                    {
                        if (doAction.Trim() == "")
                        {
                            XML_IsNull = false;
                            Rss_XML = "<Error>0</Error><MSG><![CDATA[Get数据无效,请重新发送.]]></MSG>";
                        }
                        else
                        {
                            XML_IsNull = true;
                        }
                    }

                    if (XML_IsNull)
                    {
                        try
                        {
                            int re_id = 0;
                            string tProductsName = "";
                            int ProductID = 0;
                            string tBarcode = "";//条码
                            int StorageID = 0;//仓库
                            int StoresID = 0;//门店
                            int SupplierID = 0;//供应商
                            int tindex = 0;//回调使用
                            int PriceClassID = 0;//价格分类
                            string tStoresName = "";//客户名称
                            int CertificateID = 0;//凭证编号
                            int NOCaches = 0;//是否缓存
							int orderType = 0;//单据类型
							switch (doAction)
                            {
                                #region 系统字典
                                #region 地区
                                #region 新建
                                case "AddRegion":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = AddRegion(xmlDoc);
                                    break;
                                #endregion
                                #region 修改
                                case "EditRegion":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = EditRegion(xmlDoc);
                                    break;
                                #endregion
                                #region 删除
                                case "DelRegion":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = DelRegion(xmlDoc);
                                    break;
                                #endregion
                                #region 获取
                                case "GetRegionTreeList":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetRegionTreeList(xmlDoc);
                                    break;
                                case "GetRegionTreeList_noCaches":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetRegionTreeList_noCaches(xmlDoc);
                                    break;
                                #endregion
                                #region 获取子类
                                case "GetRegionTreeChildList":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetRegionTreeChildList(xmlDoc);
                                    break;
                                case "GetRegionTreeChildList_noCaches":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetRegionTreeChildList_noCaches(xmlDoc);
                                    break;
                                #endregion
                                #region 移动
                                case "EditRegionPaterID":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = EditRegionPaterID(xmlDoc);
                                    break;
                                #endregion
                                #region 移动并排序
                                case "EditRegionOrder":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = EditRegionOrder(xmlDoc);
                                    break;
                                #endregion
                                #endregion
                                #region 分类
                                case "DataClass":
                                    ReJson = true;
                                    bool _NOCaches = HTTPRequest.GetInt("NOCaches", 1) == 1 ? true : false;
									orderType = HTTPRequest.GetInt("orderType", 0);

                                    switch (doValue)
                                    {
                                        case "SelectTreeAndData":
											Json_Str = "[" + DataClass.GetDataClassToJson(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1), true,orderType) + "]";
                                            break;
                                        case "select":
                                            if (_NOCaches)
                                            {
                                                Json_Str = "[" + DataClass.GetDataClassToJson(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1)) + "]";
                                            }
                                            else {
                                                Json_Str = "[" + DataClass.GetDataClassToJsonNOCaches(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1)) + "]";
                                            }
                                            break;
                                        case "create":
                                            if (this.userid > 0)
                                            {
                                                if (HTTPRequest.GetInt("pid", -1) > -1)
                                                {
                                                    re_id = DataClass.CreateDataClass(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1), Utils.ChkSQL(HTTPRequest.GetString("ClassName")));
                                                    Json_Str = "{ \"status\" : 1, \"id\" : " + re_id + " }";
                                                    Caches.ReSet();
                                                }
                                                else {
                                                    Json_Str = "{ \"status\" : 0, \"id\" : 0 }";
                                                }
                                            }
                                            else {
                                                Json_Str = "{ \"status\" : 0, \"id\" : 0 }";
                                            }
                                            break;
                                        case "rename":
                                            if (this.userid > 0)
                                            {
                                                if (DataClass.UpdateDataClass(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1), HTTPRequest.GetInt("cid", -1), Utils.ChkSQL(HTTPRequest.GetString("ClassName"))))
                                                {
                                                    Json_Str = "{ \"status\" : 1 }";
                                                    Caches.ReSet();
                                                }
                                                else
                                                {
                                                    Json_Str = "{ \"status\" : 0 }";
                                                }
                                            }
                                            else
                                            {
                                                Json_Str = "{ \"status\" : 0, \"id\" : 0 }";
                                            }
                                            break;
                                        case "remove":
                                            if (this.userid > 0)
                                            {
                                                if (DataClass.DelDataClass(HTTPRequest.GetString("DataType"), HTTPRequest.GetInt("pid", -1), HTTPRequest.GetInt("cid", -1)))
                                                {
                                                    Json_Str = "{ \"status\" : 1 }";
                                                    Caches.ReSet();
                                                }
                                                else
                                                {
                                                    Json_Str = "{ \"status\" : 0 }";
                                                }
                                            }
                                            else
                                            {
                                                Json_Str = "{ \"status\" : 0, \"id\" : 0 }";
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #endregion

                                #region 人员
                                case "GetStaffList":
                                    ReJson = true;
                                    string tStaffName = Utils.ChkSQL(HTTPRequest.GetString("StaffName"));

                                    int tsType = HTTPRequest.GetString("sType").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("sType"), 0) : -1;

                                    string tsTypeSQL = "";

                                    if (tStaffName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable StaffList = new DataTable();
                                        try
                                        {
                                            if (tsType != -1) {
                                                tsTypeSQL = " and sType=" + tsType;
                                            }
                                            if (tStaffName.Trim() == "*")
                                            {
                                                StaffList = Caches.GetStaffInfoList(" 1=1 " + tsTypeSQL + " ");
                                                //StaffList = Caches.GetStaffInfoList(" sState<>1 " + tsTypeSQL + " ");// tbStaffInfo.GetStaffInfoList(" 1=1 " + tsTypeSQL + " ").Tables[0];
                                            }
                                            else
                                            {
                                                StaffList = Caches.GetStaffInfoList("  1=1 and sName like '%" + tStaffName.Trim() + "%' or sTel like '%" + tStaffName.Trim() + "%' " + tsTypeSQL + " ");
                                                //StaffList = Caches.GetStaffInfoList("  sState<>1 and sName like '%" + tStaffName.Trim() + "%' or sTel like '%" + tStaffName.Trim() + "%' " + tsTypeSQL + " ");// tbStaffInfo.GetStaffInfoList(" sName like '%" + tStaffName.Trim() + "%' or sTel like '%" + tStaffName.Trim() + "%' " + tsTypeSQL + " ").Tables[0];
                                            }
                                            if (StaffList != null)
                                            {
                                                foreach (DataRow dr in StaffList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["StaffID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sTel"].ToString() + "\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            StaffList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                case "GetStaffList_XML":
                                    
                                    string _tStaffName = Utils.ChkSQL(HTTPRequest.GetString("StaffName"));

                                    int _tsType = HTTPRequest.GetString("sType").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("sType"), 0) : -1;

                                    string _tsTypeSQL = "";

                                    if (_tStaffName.Trim() != "")
                                    {
                                        string _jTem = "";

                                        DataTable _StaffList = new DataTable();
                                        try
                                        {
                                            if (_tsType != -1)
                                            {
                                                _tsTypeSQL = " and sType=" + _tsType;
                                            }
                                            if (_tStaffName.Trim() == "*")
                                            {
                                                _StaffList = tbStaffInfo.GetStaffInfoList(" " + _tsTypeSQL + " ").Tables[0];
                                            }
                                            else
                                            {
                                                _StaffList = tbStaffInfo.GetStaffInfoList(" sName like '%" + _tStaffName.Trim() + "%' " + _tsTypeSQL + " ").Tables[0];
                                            }
                                            if (_StaffList != null)
                                            {
                                                foreach (DataRow dr in _StaffList.Rows)
                                                {
                                                    _jTem += "" + dr["sName"].ToString() + "," + dr["StaffID"].ToString() + "|";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            _StaffList.Clear();
                                        }
                                        if (_jTem.Trim() != "")
                                        {
                                            _jTem = _jTem.Substring(0, _jTem.Length - 1);
                                        }
                                        Rss_XML = "<listdata>" + _jTem + "</listdata>";
                                    }
                                    break;
                                #endregion

                                #region 操作员
                                case "GetUserList":
                                    ReJson = true;
                                    string tUserName = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                    if (tUserName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";
                                        DataTable UserList = new DataTable();
                                        try
                                        {
                                            if (tUserName.Trim() == "*")
                                            {
                                                UserList = Caches.GetUserInfoList(" uEstate <> 1");// tbUserInfo.GetUserInfoList("").Tables[0];
                                            }
                                            else
                                            {
                                                UserList = Caches.GetUserInfoList(" uEstate <> 1 and uName like '%" + tUserName.Trim() + "%' ");// tbUserInfo.GetUserInfoList(" uName like '%" + tUserName.Trim() + "%' ").Tables[0];
                                            }
                                            if (UserList != null)
                                            {
                                                foreach (DataRow dr in UserList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["UserID"].ToString() + "\", \"value\": \"" + dr["uName"].ToString() + "\", \"info\": \"\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            UserList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 门店
                                case "GetStoresInfoList":
                                    ReJson = true;
                                    tStoresName = Utils.ChkSQL(HTTPRequest.GetString("StoresName"));
                                    if (tStoresName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";
                                        DataTable StoresList = new DataTable();
                                        if (tStoresName.Trim() == "*")
                                        {
                                            StoresList = Caches.GetStoresInfoList(" sState<>1 ");// tbStoresInfo.GetStoresInfoList("").Tables[0];
                                        }
                                        else
                                        {
                                            StoresList = Caches.GetStoresInfoList(" sState<>1 and sName like '%" + tStoresName.Trim() + "%' or sCode like '%" + tStoresName.Trim() + "%'");// tbStoresInfo.GetStoresInfoList(" sName like '%" + tStoresName.Trim() + "%' or sCode like '%" + tStoresName.Trim() + "%'").Tables[0];
                                        }
                                        if (StoresList != null)
                                        {
                                            StaffInfo si = new StaffInfo();
                                            int _staffid=0;
                                            string _staffname = "";
                                            foreach (DataRow dr in StoresList.Rows)
                                            {
                                                _staffid = 0;
                                                _staffname = "";
                                                //取门店上岗中的业务员
                                                si = tbStaffStoresInfo.GetStaffByStores(Convert.ToInt32(dr["StoresID"].ToString()),1);
                                                if (si != null)
                                                {
                                                    _staffid = si.StaffID;
                                                    _staffname = si.sName;
                                                }
                                                jTem += "{\"id\": \"" + dr["StoresID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sCode"].ToString() + "\","+
                                                    "\"CustomersClassID\":\"" + dr["CustomersClassID"].ToString() + "\","+
                                                    "\"CustomersClassName\":\"" + dr["CustomersClassName"].ToString() + "\"," +
                                                    "\"PriceClassID\":\"" + dr["PriceClassID"].ToString() + "\","+
                                                    "\"PriceClassName\":\"" + dr["PriceClassName"].ToString() + "\"," +
                                                    "\"sType\":\"" + dr["sType"].ToString() + "\",\"YHsysID\":\"" + dr["YHsysID"].ToString() + "\","+
                                                    "\"sIsFZYH\":\"" + dr["sIsFZYH"].ToString() + "\","+
                                                    "\"YHsysName\":\"" + dr["YHsysName"].ToString() + "\","+
                                                    "\"sContact\":\"" + dr["sContact"].ToString() + "\","+
                                                    "\"sTel\":\"" + dr["sTel"].ToString() + "\","+
                                                    "\"sAddress\":\"" + dr["sAddress"].ToString() + "\","+
                                                    "\"StaffID\":\"" + _staffid + "\",\"StaffName\":\"" + _staffname + "\"},";
                                            }
                                            if (jTem.Trim() != "")
                                            {
                                                jTem = jTem.Substring(0, jTem.Length - 1);
                                            }
                                            Json_Str = Json_Str + jTem + "]}";
                                        }
                                    }
                                    break;
                                case "GetStoresList":
                                    ReJson = true;
                                     tStoresName = Utils.ChkSQL(HTTPRequest.GetString("StoresName"));
                                    string tStores_eDate = Utils.ChkSQL(HTTPRequest.GetString("eDate"));
                                    if (tStoresName.Trim() != "")
                                    {
                                        string jTem = "";
                                        decimal tStores_ArMoney = 0;//实际
                                        decimal tStores_nMoney = 0;//新增
                                        Json_Str = "{\"results\": [";

                                        try
                                        {
                                            DataTable StoresList = new DataTable();
                                            try
                                            {
                                                if (tStoresName.Trim() == "*")
                                                {
                                                    StoresList = tbStoresInfo.GetStoresInfoList("").Tables[0];
                                                }
                                                else
                                                {
                                                    StoresList = tbStoresInfo.GetStoresInfoList(" sName like '%" + tStoresName.Trim() + "%' or sCode like '%" + tStoresName.Trim() + "%'").Tables[0];
                                                }
                                                if (StoresList != null)
                                                {
                                                    if (StoresList.Rows.Count > 1)
                                                    {
                                                        foreach (DataRow dr in StoresList.Rows)
                                                        {
                                                            jTem += "{\"id\": \"" + dr["StoresID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sCode"].ToString() + "\",\"ArMoney\":\"" + tStores_ArMoney.ToString() + "\",\"NrMoney\":\"" + tStores_nMoney.ToString() + "\",\"IsPaymentSystem\":\"0\"},";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        foreach (DataRow dr in StoresList.Rows)
                                                        {
                                                            tStores_ArMoney = 0;
                                                            tStores_nMoney = 0;
                                                            //取客户应收信息
                                                            if (tStores_eDate.Trim() != "")
                                                            {
                                                                DataTable _tDataList = tbARMoneyInfo.GetErpCustomerPay("", dr["sName"].ToString(), DateTime.Parse("1984-09-24"), DateTime.Parse(tStores_eDate));
                                                                try
                                                                {
                                                                    if (_tDataList != null)
                                                                    {
                                                                        foreach (DataRow _dr in _tDataList.Rows)
                                                                        {
                                                                            //实际应收
                                                                            tStores_ArMoney += (decimal.Parse(_dr["DeliveryMoney"].ToString()) - decimal.Parse(_dr["ReturnMoney"].ToString())) + (decimal.Parse(_dr["AMoney"].ToString()) - decimal.Parse(_dr["ActualMoney"].ToString()));
                                                                            //新增应收
                                                                            tStores_nMoney += decimal.Parse(_dr["DeliveryMoney"].ToString()) - decimal.Parse(_dr["ReturnMoney"].ToString());
                                                                        }
                                                                    }
                                                                }
                                                                finally
                                                                {
                                                                    _tDataList.Clear();
                                                                }

                                                            }

                                                            jTem += "{\"id\": \"" + dr["StoresID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sCode"].ToString() + "\",\"ArMoney\":\"" + tStores_ArMoney.ToString() + "\",\"NrMoney\":\"" + tStores_nMoney.ToString() + "\",\"IsPaymentSystem\":\"0\"},";
                                                        }
                                                    }
                                                }
                                                
                                            }
                                            finally
                                            {
                                                StoresList.Clear();
                                            }
                                        }
                                        catch(Exception ex)
                                        {
                                            jTem = ex.ToString();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 结算系统
                                case "GetPaymentSystemList":
                                    ReJson = true;
                                    string tPaymentSystemName = Utils.ChkSQL(HTTPRequest.GetString("PaymentSystemName"));
                                    //string tPaymentSystem_eDate = Utils.ChkSQL(HTTPRequest.GetString("eDate"));
                                    if (tPaymentSystemName.Trim() != "")
                                    {
                                        string jTem = "";
                                        //decimal tPaymentSystem_ArMoney = 0;//实际
                                        //decimal tPaymentSystem_nMoney = 0;//新增
                                        Json_Str = "{\"results\": [";
                                        try
                                        {
                                            DataTable PaymentSystemList = new DataTable();
                                            try
                                            {
                                                if (tPaymentSystemName.Trim() != "*")
                                                {
                                                    PaymentSystemList = tbPaymentSystemInfo.GetPaymentSystemList(" pName like '%" + tPaymentSystemName + "%'").Tables[0];
                                                }
                                                else {
                                                    PaymentSystemList = tbPaymentSystemInfo.GetPaymentSystemList("").Tables[0];
                                                }
                                                if (PaymentSystemList != null)
                                                {
                                                    foreach (DataRow dr in PaymentSystemList.Rows)
                                                    {
                                                        jTem += "{\"id\": \"" + dr["PaymentSystemID"].ToString() + "\", \"value\": \"" + dr["pName"].ToString() + "\", \"info\": \"\",\"IsPaymentSystem\":\"1\"},";
                                                    }
                                                }
                                                /*
                                                PaymentSystemList = tbARMoneyInfo.GetErpCustomerPay("", "", DateTime.Parse("1984-09-24"), DateTime.Parse(tPaymentSystem_eDate), tPaymentSystemName.Trim());
                                                if (PaymentSystemList != null)
                                                {
                                                    foreach (DataRow dr in PaymentSystemList.Rows)
                                                    {
                                                        //实际应收
                                                        tPaymentSystem_ArMoney = (decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString())) + (decimal.Parse(dr["AMoney"].ToString()) - decimal.Parse(dr["ActualMoney"].ToString()));
                                                        //新增应收
                                                        tPaymentSystem_nMoney = decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString());
                                                        jTem += "{\"id\": \"" + dr["PaymentSystemID"].ToString() + "\", \"value\": \"" + dr["pName"].ToString() + "\", \"info\": \"\",\"ArMoney\":\"" + tPaymentSystem_ArMoney.ToString() + "\",\"NrMoney\":\"" + tPaymentSystem_nMoney.ToString() + "\",\"IsPaymentSystem\":\"1\"},";
                                                    }
                                                }
                                                 */
                                            }
                                            finally
                                            {
                                                PaymentSystemList.Clear();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            jTem = ex.ToString();
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 供货商
                                case "GetSupplierList":
                                    ReJson = true;
                                    string tSupplierName = Utils.ChkSQL(HTTPRequest.GetString("SupplierName"));
                                    string tSupplier_eDate = Utils.ChkSQL(HTTPRequest.GetString("eDate"));
                                    if (tSupplierName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";
                                        decimal tSupplier_ApMoney = 0;
                                        decimal tSupplier_nMoney = 0;

                                        DataTable SupplierList = new DataTable();
                                        try
                                        {
                                            if (tSupplierName.Trim() == "*")
                                            {
                                                SupplierList = Caches.GetSupplierInfoList("");// tbSupplierInfo.GetSupplierInfoList("").Tables[0];
                                            }
                                            else
                                            {
                                                SupplierList = Caches.GetSupplierInfoList(" sName like '%" + tSupplierName.Trim() + "%' or sCode like '%" + tSupplierName.Trim() + "%'"); //tbSupplierInfo.GetSupplierInfoList(" sName like '%" + tSupplierName.Trim() + "%' or sCode like '%" + tSupplierName.Trim() + "%'").Tables[0];
                                            }
                                            if (SupplierList != null)
                                            {
                                                foreach (DataRow dr in SupplierList.Rows)
                                                {
                                                    tSupplier_ApMoney = 0;
                                                    tSupplier_nMoney = 0;
                                                    //取供货商应付信息
                                                    if (tSupplier_eDate.Trim() != "")
                                                    {
                                                        DataTable _tDataList = tbAPMoneyInfo.GetErpWillPay(DateTime.Parse("1984-09-24"), DateTime.Parse(tSupplier_eDate));
                                                        try
                                                        {
                                                            if (_tDataList != null)
                                                            {
                                                                foreach (DataRow _dr in _tDataList.Rows)
                                                                {
                                                                    //实际应付
                                                                    tSupplier_ApMoney += (decimal.Parse(_dr["DeliveryMoney"].ToString()) - decimal.Parse(_dr["ReturnMoney"].ToString())) + (decimal.Parse(_dr["NPMoney"].ToString()) - decimal.Parse(_dr["ActualMoney"].ToString()));
                                                                    //新增应付
                                                                    tSupplier_nMoney += decimal.Parse(_dr["DeliveryMoney"].ToString()) - decimal.Parse(_dr["ReturnMoney"].ToString());
                                                                }
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            _tDataList.Clear();
                                                        }
                                                    }
                                                    jTem += "{\"id\": \"" + dr["SupplierID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sCode"].ToString() + "\",\"ApMoney\":\"" + tSupplier_ApMoney.ToString() + "\",\"NpMoney\":\"" + tSupplier_nMoney.ToString() + "\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            SupplierList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 仓库
                                case "GetStorageList":
                                    ReJson = true;
                                    string tStorageName = Utils.ChkSQL(HTTPRequest.GetString("StorageName"));
                                    if (tStorageName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable StorageList = new DataTable();
                                        try
                                        {
                                            if (tStorageName.Trim() == "*")
                                            {
                                                StorageList = Caches.GetStorageInfoList("");
                                            }
                                            else
                                            {
                                                StorageList = Caches.GetStorageInfoList(" sName like '%" + tStorageName.Trim() + "%' or sCode like '%" + tStorageName.Trim() + "%'"); //tbSupplierInfo.GetSupplierInfoList(" sName like '%" + tSupplierName.Trim() + "%' or sCode like '%" + tSupplierName.Trim() + "%'").Tables[0];
                                            }
                                            if (StorageList != null)
                                            {
                                                foreach (DataRow dr in StorageList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["StorageID"].ToString() + "\", \"value\": \"" + dr["sName"].ToString() + "\", \"info\": \"" + dr["sCode"].ToString() + "\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            StorageList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 产品
                                case "SetProductsState"://修改商品系统状态
                                    ReJson = true;
                                    ProductID = HTTPRequest.GetInt("ProductID", 0);
                                    if (ProductID > 0)
                                    {
                                        ProductsInfo _pi = tbProductsInfo.GetProductsInfoModel(ProductID);
                                        if (_pi != null)
                                        {
                                            try
                                            {
                                                _pi.pState = (_pi.pState == 0) ? 1 : 0;
                                                tbProductsInfo.UpdateProductsInfo(_pi);
                                                Json_Str = "{\"results\": true,\"msg\":\"成功.\",\"pid\":\"" + ProductID + "\",\"state\":" + _pi.pState + "}";
                                            }catch
                                            {
                                                Json_Str = "{\"results\": false,\"msg\":\"错误.\"}";
                                            }
                                        }
                                        else {
                                            Json_Str = "{\"results\": false,\"msg\":\"参数错误.\"}";
                                        }
                                    }
                                    break;
                                case "GetProductsList":
                                    ReJson = true;
                                     tProductsName = Utils.ChkSQL(HTTPRequest.GetString("ProductsName"));
                                    if (tProductsName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable ProductsList = new DataTable();
                                        try
                                        {
                                            if (tProductsName.Trim() == "*")
                                            {
                                                ProductsList = Caches.GetProductsInfoList(" pState<>1 ");// tbProductsInfo.GetProductsInfoList("").Tables[0];
                                            }
                                            else
                                            {
                                                ProductsList = Caches.GetProductsInfoList(" pState<>1 and pName like '%" + tProductsName.Trim() + "%' or pBarcode like '%" + tProductsName.Trim() + "%'"); //tbProductsInfo.GetProductsInfoList(" pName like '%" + tProductsName.Trim() + "%' or pBarcode like '%" + tProductsName.Trim() + "%'").Tables[0];
                                            }
                                            if (ProductsList != null)
                                            {
                                                foreach (DataRow dr in ProductsList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["ProductsID"].ToString() + "\", \"value\": \"" + dr["pName"].ToString() + "\", \"info\":\"" + dr["pBarcode"].ToString() + "\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            ProductsList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length-1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                case "GetProducts":
                                    ReJson = true;

                                    ProductID = HTTPRequest.GetInt("ProductID",0);
                                    StorageID = HTTPRequest.GetInt("StorageID",0);//仓库
                                    StoresID = HTTPRequest.GetInt("StoresID",0);//门店
                                    SupplierID = HTTPRequest.GetInt("SupplierID",0);//供应商
                                    PriceClassID = HTTPRequest.GetInt("PriceClassID", 0);//价格分类
                                    tindex = HTTPRequest.GetInt("ind",0);//
                                    Json_Str = "{\"results\": {";

                                    ProductsInfo pi = new ProductsInfo();
                                    if (ProductID > 0)
                                    {
                                        pi = tbProductsInfo.GetProductsInfoModel(ProductID);

                                        if (pi != null)
                                        {
                                            Json_Str += "\"ind\":\"" + tindex + "\",\"ProductsID\":\"" + pi.ProductsID + "\",\"pCode\":\"" + pi.pCode + "\"," +
                                                                "\"pBarcode\":\"" + pi.pBarcode + "\",\"pName\":\"" + pi.pName + "\",\"ProductClassID\":\"" + pi.ProductClassID + "\"," +
                                                                "\"pBrand\":\"" + pi.pBrand + "\",\"pStandard\":\"" + pi.pStandard + "\",\"pUnits\":\"" + pi.pUnits + "\",\"pMaxUnits\":\"" + pi.pMaxUnits + "\",\"pToBoxNo\":\"" + pi.pToBoxNo + "\"," +
                                                                "\"pPrice\":\"" + pi.pPrice + "\",\"NowPrice\":\"" + pi.NowPrice + "\",\"pState\":\"" + pi.pState + "\",\"pDoDayQuantity\":\"" + pi.pDoDayQuantity + "\",\"pAppendTime\":\"" + pi.pAppendTime + "\",\"pProducer\":\"" + pi.pProducer + "\",\"pExpireDay\":\"" + pi.pExpireDay + "\"";

                                            if (StorageID > 0)
                                            {
                                                try
                                                {
                                                    tbProductsInfo.AddProductsStorage(StorageID, ProductID);
                                                    ProductsStorageInfo psi = new ProductsStorageInfo();
                                                    psi = tbProductsInfo.GetProductsStorageModel(StorageID, ProductID);
                                                    Json_Str += ",\"StorageInfo\":{\"StorageID\":\"" + StorageID + "\",";
                                                    Json_Str += "\"BeginningStorage\":\"" + tbProductsInfo.GetProductsBeginningStorage(StorageID, ProductID) + "\"";
                                                    if (psi != null)
                                                    {
                                                        Json_Str += ",\"NowStorage\":\"" + psi.pStorage + "\",\"StorageIn\":\"" + psi.pStorageIn + "\",\"StorageOut\":\"" + psi.pStorageOut + "\",\"StorageBad\":\"" + psi.pStorageBad + "\",\"UpdateTime\":\"" + psi.pUpdateTime + "\"";
                                                    }
                                                    else
                                                    {
                                                        Json_Str += ",\"NowStorage\":\"0\",\"StorageIn\":\"0\",\"StorageOut\":\"0\",\"StorageBad\":\"0\",\"UpdateTime\":\"" + DateTime.Now + "\"";
                                                    }
                                                    Json_Str += "}";
                                                }
                                                catch (Exception _e)
                                                {
                                                    Response.Write(_e.Message.ToString());
                                                    Response.End();
                                                }
                                            }
                                            //客户
                                            if (StoresID > 0)
                                            {
                                                int _p_PriceClassID = 0;
                                                StoresInfo _p_si = new StoresInfo();
                                                _p_si = tbStoresInfo.GetStoresInfoModel(StoresID);
                                                if(_p_si!=null)
                                                {
                                                    _p_PriceClassID = _p_si.PriceClassID;
                                                }
                                                Json_Str += ",\"DefaultPrice\":\"" + tbPriceClassDefaultPriceInfo.GetProductsPiceByStoresID(ProductID, StoresID) + "\",\"PriceClassID\":\"" + _p_PriceClassID + "\"";

                                                try
                                                {
                                                    string _MS_List = "";
                                                    //当前客户可用数量
                                                    DataTable M_S_List = new DataTable();
                                                    M_S_List = M_Utils.GetM_StockInfoList(" ProductsID=" + ProductID + " and m_ConfigInfoID = (select m_ConfigInfoID from tb_M_ConfigInfo where StoresID=" + StoresID + ")").Tables[0];
                                                    if (M_S_List != null)
                                                    {
                                                        foreach (DataRow _mdr in M_S_List.Rows)
                                                        {
                                                            _MS_List += "{\"StorageID\":\"" + _mdr["StorageID"].ToString() + "\",\"StorageName\":\"" + _mdr["StorageName"].ToString() + "\",\"ProductsID\":\"" + _mdr["ProductsID"].ToString() + "\",\"m_Num\":\"" + _mdr["m_Num"].ToString() + "\"},";
                                                        }
                                                        if (_MS_List.Trim() != "")
                                                        {
                                                            _MS_List = _MS_List.Substring(0, _MS_List.Length - 1);

                                                            Json_Str = Json_Str + ",\"MS_Nums\":[" + _MS_List + "]";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Json_Str = Json_Str + ",\"MS_Nums\":[]";
                                                    }
                                                }
                                                catch (Exception _e)
                                                {
                                                    Response.Write(_e.Message.ToString());
                                                    Response.End();
                                                }
                                            }
                                            //供应商
                                            if (SupplierID > 0)
                                            {
                                                if (pi.NowPrice != 0)
                                                {
                                                    Json_Str += ",\"DefaultPrice\":\"" + pi.NowPrice + "\"";
                                                }
                                                else {
                                                    Json_Str += ",\"DefaultPrice\":\"" + pi.pPrice + "\"";
                                                }
                                            }
                                        }
                                    }

                                    Json_Str = Json_Str + "}}";

                                    break;
                                case "GetProductsPrice"://指定客户价格类型,获取产品价格
                                    ReJson = true;

                                    ProductID = HTTPRequest.GetInt("ProductID",0);
                                    PriceClassID = HTTPRequest.GetInt("PriceClassID", 0);//价格分类
                                    if (ProductID > 0)
                                    {
                                        if (PriceClassID > 0)
                                        {
                                            PriceClassDefaultPriceInfo _pcp = new PriceClassDefaultPriceInfo();
                                            _pcp = tbPriceClassDefaultPriceInfo.GetPriceClassDefaultPriceInfoModel(PriceClassID, ProductID);
                                            if (_pcp != null)
                                            {
                                                Json_Str = "\"DefaultPrice\":\"" + _pcp.pPrice + "\",\"IsEdit\":" + (_pcp.pIsEdit == 0 ? "true" : "false") + "";
                                            }
                                            else {
                                                Json_Str = "\"DefaultPrice\":false,\"IsEdit\":true";
                                            }
                                        }
                                    }
                                    Json_Str = "{\"results\": {" + Json_Str+"}}";
                                    break;
                                #endregion

                                #region 费用科目
                                case "GetFeesSubjectList":
                                    ReJson = true;
                                    string tFeesSubjectName = Utils.ChkSQL(HTTPRequest.GetString("FeesSubjectName"));
                                    if (tFeesSubjectName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable FeesSubjectList = new DataTable();
                                        try
                                        {
                                            if (tFeesSubjectName.Trim() == "*")
                                            {
                                                FeesSubjectList = tbFeesSubjectInfo.GetFeesSubjectInfoList("").Tables[0];
                                            }
                                            else
                                            {
                                                FeesSubjectList = tbFeesSubjectInfo.GetFeesSubjectInfoList(" fName like '%" + tFeesSubjectName.Trim() + "%'").Tables[0];
                                            }
                                            if (FeesSubjectList != null)
                                            {
                                                foreach (DataRow dr in FeesSubjectList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["FeesSubjectID"].ToString() + "\", \"value\": \"" + dr["fName"].ToString() + "\", \"info\": \"\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            FeesSubjectList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 银行
                                case "GetBankList":
                                    ReJson = true;
                                    string tBankName = Utils.ChkSQL(HTTPRequest.GetString("BankName"));
                                    if (tBankName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable BankList = new DataTable();
                                        try
                                        {
                                            if (tBankName.Trim() == "*")
                                            {
                                                BankList = tbBankInfo.GetBankList("").Tables[0];
                                            }
                                            else
                                            {
                                                BankList = tbBankInfo.GetBankList(" bName like '%" + tBankName.Trim() + "%'").Tables[0];
                                            }
                                            if (BankList != null)
                                            {
                                                foreach (DataRow dr in BankList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["BankID"].ToString() + "\", \"value\": \"" + dr["bName"].ToString() + "\", \"info\": \"\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            BankList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 超市系统
                                case "GetYHsysList":
                                    ReJson = true;
                                    string tYHsysName = Utils.ChkSQL(HTTPRequest.GetString("YHsysName"));
                                    if (tYHsysName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable YHsysList = new DataTable();
                                        try
                                        {
                                            if (tYHsysName.Trim() == "*")
                                            {
                                                YHsysList = tbYHsysInfo.GetYHsysInfoList("").Tables[0];
                                            }
                                            else
                                            {
                                                YHsysList = tbYHsysInfo.GetYHsysInfoList(" yName like '%" + tYHsysName.Trim() + "%'").Tables[0];
                                            }
                                            if (YHsysList != null)
                                            {
                                                foreach (DataRow dr in YHsysList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["YHsysID"].ToString() + "\", \"value\": \"" + dr["yName"].ToString() + "\", \"info\": \"\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            YHsysList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion

                                #region 对账单
                                #region 取指定对象上期余额
                                case "GetSObjectUpMoney":
                                    int sObjectID = HTTPRequest.GetInt("sObjectID", -1);//对象编号
                                    int sObjectType = HTTPRequest.GetInt("sObjectType", -1);//对象类型,客户=0,供应商=1,人员=2,超市系统=3
                                    int sType = HTTPRequest.GetInt("sType", -1);//账单类型,应收=2,应付=1
                                    ReJson = true;
                                    if (sObjectID>-1 && sObjectType > -1 && sType > -1)
                                    {
                                        Json_Str = "{\"results\": {\"UpMoney\":\"" + MonthlyStatements.GetSObjectUpMoney(sObjectID,sObjectType,sType)+ "\"}}";
                                    }
                                    break;
                                #endregion
                                #region 取单据随附凭证
                                case "GetOrderCertificateList":
                                    ReJson = true;
                                    int OrderID = HTTPRequest.GetInt("OrderID", 0);
                                    if (OrderID > 0)
                                    {
                                        string jTem = "";
                                        DataTable dList = Certificates.GetCertificateInfoListByObject(1, OrderID).Tables[0];
                                        if (dList != null)
                                        {
                                            if (dList.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in dList.Rows)
                                                {
                                                    jTem += "{\"MonthlyStatementAppendDataID\":\"0\",\"MonthlyStatementID\":\"0\","+
                                                        "\"CertificateID\":\"" + dr["CertificateID"].ToString() + "\","+
                                                        "\"aState\":\"0\",\"aRemake\":\"\","+
                                                        "\"cAppendTime\":\"" + dr["cAppendTime"].ToString() + "\"," +
                                                        "\"cMoney\":\"" + dr["cMoney"].ToString() + "\","+
                                                        "\"cCode\":\"" + dr["cCode"].ToString() + "\","+
                                                        "\"cType\":\""+dr["cType"].ToString()+"\","+
                                                        "\"cTypeStr\":\"" + (dr["cType"].ToString() == "0" ? "收款" : (dr["cType"].ToString() == "1") ? "付款" : dr["cType"].ToString() == "2"?"其他":"") + "\"," +
                                                        "\"UserID\":\"" + dr["UserID"].ToString() + "\","+
                                                        "\"UserName\":\"" + dr["UserName"].ToString() + "\","+
                                                        "\"UserStaffName\":\"" + dr["UserStaffName"].ToString() + "\"," +
                                                        "\"StaffName\":\"" + dr["StaffName"].ToString() + "\"," +
                                                        "\"StaffID\":\"" + dr["StaffID"].ToString() + "\","+
                                                        "\"cDateTime\":\"" + Convert.ToDateTime(dr["cDateTime"].ToString()).ToString("yyyy-MM-dd") + "\"," +
                                                        "\"cObject\":\"" + dr["cObject"].ToString() + "\","+
                                                        "\"cObjectID\":\"" + dr["cObjectID"].ToString() + "\"},";
                                                }
                                                if (jTem.Trim() != "")
                                                {
                                                    jTem = jTem.Substring(0, jTem.Length - 1);
                                                }
                                            }
                                        }
                                        Json_Str = "{\"results\":{\"MonthlyStatementAppendData\":[" + jTem + "]}}";
                                    }
                                    break;
                                #endregion
                                #endregion

                                #region 凭证
                                #region 列表
                                case "GetCertificateList":
                                    ReJson = true;
                                    string CertificateCode = Utils.ChkSQL(HTTPRequest.GetString("CertificateCode"));

                                    if (CertificateCode.Trim() != "")
                                    {
                                        int IsToObject = HTTPRequest.GetInt("IsToObject", -1);//随附对象,已随附单据=1,未随附=0
                                        int cType = HTTPRequest.GetInt("cType", -1);//凭证类型,收款=0,付款=1,其他=2
                                        string jTem = "";
                                        string tSQL = " 1=1 ";
                                        if (CertificateCode.Trim() != "*")
                                        {
                                            tSQL += " and cCode like '%" + CertificateCode .Trim()+ "%'";
                                        }
                                        if (cType > -1)
                                        {
                                            tSQL += " and cType=" + cType;
                                        }
                                        if (IsToObject > -1)
                                        {
                                            tSQL += " and cObject=" + IsToObject;
                                        }
                                        DataTable tdl = Certificates.GetCertificateInfoList(tSQL + "  order by cDateTime desc").Tables[0];

                                        Json_Str = "{\"results\": [";

                                        if (tdl != null)
                                        {
                                            if (tdl.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in tdl.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["CertificateID"].ToString() + "\", \"value\": \"" + dr["cCode"].ToString() + "\", \"info\": \"" + dr["toObjectName"].ToString() + "\"},";
                                                }
                                            }
                                            if (jTem.Trim() != "")
                                            {
                                                jTem = jTem.Substring(0, jTem.Length - 1);
                                            }
                                        }

                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion
                                #region 内容
                                case "GetCertificate":
                                    ReJson = true;
                                     CertificateID = HTTPRequest.GetInt("cid", 0);
                                    if (CertificateID > 0)
                                    {
                                        CertificateInfo ci = Certificates.GetCertificateInfoModel(CertificateID);
                                        if (ci != null)
                                        {
                                            string jTem = "";

                                            DataTable cdList = Certificates.GetCertificateDataInfoList(" CertificateID = " + CertificateID + " order by CertificateDataID asc").Tables[0];
                                            if (cdList != null)
                                            {
                                                foreach (DataRow dr in cdList.Rows)
                                                {
                                                    jTem += "{\"CertificateDataID\":\"" + dr["CertificateDataID"].ToString() + "\",\"CertificateID\":\"" + dr["CertificateID"].ToString() + "\",\"FeesSubjectName\":\"" + dr["FeesSubjectName"].ToString() + "\",\"FeesSubjectID\":\"" + dr["FeesSubjectID"].ToString() + "\",\"cdName\":\"" + dr["cdName"].ToString() + "\",\"cdMoney\":\"" + dr["cdMoney"].ToString() + "\",\"cdRemake\":\"" + dr["cdRemake"].ToString() + "\",\"cdAppendTime\":\"" + dr["cdAppendTime"].ToString() + "\"},";
                                                }
                                            }

                                            if (jTem.Trim() != "")
                                            {
                                                jTem = jTem.Substring(0, jTem.Length - 1);
                                            }
                                            Json_Str = "{\"results\": {\"Certificates\":{"+
                                                                "\"CertificateID\":\""+ci.CertificateID+"\","+
                                                                "\"cCode\":\"" + ci.cCode + "\"," +
                                                                "\"cMoney\":\"" + ci.cMoney + "\"," +
                                                                "\"cType\":\"" + ci.cType + "\"," +
                                                                "\"UserID\":\"" + ci.UserID + "\"," +
                                                                "\"UserStaffName\":\"" + ci.UserStaffName + "\"," +
                                                                "\"StaffID\":\"" + ci.StaffID + "\"," +
                                                                "\"StaffName\":\"" + ci.StaffName + "\"," +
                                                                "\"cRemake\":\"" + ci.cRemake + "\"," +
                                                                "\"toObject\":\"" + ci.toObject + "\"," +
                                                                "\"toObjectID\":\"" + ci.toObjectID + "\"," +
                                                                "\"toObjectName\":\"" + ci.toObjectName + "\"," +
                                                                "\"cObject\":\"" + ci.cObject + "\"," +
                                                                "\"cObjectID\":\"" + ci.cObjectID + "\"," +
                                                                "\"cState\":\"" + ci.cState + "\"," +
                                                                "\"BankID\":\"" + ci.BankID + "\"," +
                                                                "\"BankName\":\"" + ci.BankName + "\"," +
                                                                "\"cDateTime\":\"" + ci.cDateTime + "\"" +
                                                               " },\"DataList\":{\"CertificateDataInfoJson\":[" + jTem + "]}";

                                            Json_Str = Json_Str +"}}";
                                        }
                                    }
                                    break;
                                #endregion
                                #region 取消随附
                                case "RemoveCertificateToObject":
                                    ReJson = true;
                                    CertificateID = HTTPRequest.GetInt("cid", 0);
                                    if (CertificateID > 0)
                                    {
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-3"))
                                        {
                                            Certificates.RemoveCertificateToObject(CertificateID);
                                            Json_Str = "{\"results\":true,\"msg\":\"成功!\"}";
                                        }
                                        else { 
                                            Json_Str = "{\"results\":false,\"msg\":\"权限不足!\"}";
                                        }
                                    }
                                    break;
                                #endregion
                                #region 设置随附信息
                                case "SetCertificateToObject":
                                    ReJson = true;
                                    CertificateID = HTTPRequest.GetInt("cid", 0);
                                    if (CertificateID > 0)
                                    {
                                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-3"))
                                        {
                                            int cObject = HTTPRequest.GetInt("cObject",0);
                                            int cObjectID = HTTPRequest.GetInt("cObjectID", 0);
                                            Certificates.SetCertificateToObject(CertificateID, cObject, cObjectID);
                                            Json_Str = "{\"results\":true,\"msg\":\"成功!\"}";
                                        }
                                        else
                                        {
                                            Json_Str = "{\"results\":false,\"msg\":\"权限不足!\"}";
                                        }
                                    }
                                    break;
                                #endregion
                                #endregion
                                /*
                                #region 客户结算系统
                                case "GetPaymentSystemList":
                                    ReJson = true;
                                    string tPaymentSystemName = Utils.ChkSQL(HTTPRequest.GetString("PaymentSystemName"));
                                    if (tPaymentSystemName.Trim() != "")
                                    {
                                        string jTem = "";
                                        Json_Str = "{\"results\": [";

                                        DataTable PaymentSystemList = new DataTable();
                                        try
                                        {
                                            if (tPaymentSystemName.Trim() == "*")
                                            {
                                                PaymentSystemList = tbPaymentSystemInfo.GetPaymentSystemList("").Tables[0];
                                            }
                                            else
                                            {
                                                PaymentSystemList = tbPaymentSystemInfo.GetPaymentSystemList(" pName like '%" + tPaymentSystemName.Trim() + "%' ").Tables[0];
                                            }
                                            if (PaymentSystemList != null)
                                            {
                                                foreach (DataRow dr in PaymentSystemList.Rows)
                                                {
                                                    jTem += "{\"id\": \"" + dr["PaymentSystemID"].ToString() + "\", \"value\": \"" + dr["pName"].ToString() + "\", \"info\":\"\"},";
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            PaymentSystemList.Clear();
                                        }
                                        if (jTem.Trim() != "")
                                        {
                                            jTem = jTem.Substring(0, jTem.Length - 1);
                                        }
                                        Json_Str = Json_Str + jTem + "]}";
                                    }
                                    break;
                                #endregion
*/
                                #region 获取Erp系统产品列表
                                case "GetErpProductList":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetErpProductList(xmlDoc);
                                    break;
                                #endregion

                                #region 获取Erp系统产品单据列表
                                case "GetErpProductOrderList":
                                    xmlDoc.Load(PostdoValue);
                                    Rss_XML = GetErpProductOrderList(xmlDoc);
                                    break;
                                #endregion

                                #region 图表
                                #region 永辉销售数据
                                case "GetSalesChartsXML":
                                    ReChartsXML = true;

                                    Rss_XML = GetSalesChartsXML();
                                    break;
                                #endregion
                                #endregion

                                #region 鉴权
                                case "UserLogin":
                                    ReJson = true;
                                    User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                    User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));

                                    if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                    {
                                        Json_Str = "{\"code\":0,\"msg\":\"用户名密码正确!\"}";
                                    }
                                    else
                                    {
                                        Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                    }

                                    break;
                                #endregion
                                #region 利润
                                case "Data_Profit":
                                    ReJson = true;
                                    try
                                    {
                                        User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                        User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));
                                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate"));
                                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate") + " 23:59:59");

                                        if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                        {
                                            DataTable dList = DataUtils.GetErpData_analysis(bDate, eDate, 7);
                                            try
                                            {
                                                if (dList != null)
                                                {
                                                    Json_Str = "{\"code\":0,\"msg\":\"" + bDate.ToShortDateString().ToString() + " <-> " + eDate.ToShortDateString().ToString() + " 利润\",\"datalist\":[{\"Sales\":" + dList.Rows[0][0].ToString() + ",\"Cost\":" + dList.Rows[0][1].ToString() + ",\"Returns\":" + dList.Rows[0][2].ToString() + ",\"Bad\":" + dList.Rows[0][3].ToString() + ",\"Gifts\":" + dList.Rows[0][4].ToString() + ",\"Selling\":" + dList.Rows[0][5].ToString() + ",\"Corporate\":" + dList.Rows[0][6].ToString() + ",Profit:" + (Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5]) - Convert.ToDecimal(dList.Rows[0][6])).ToString() + "}]}";
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":3,\"msg\":\"没有数据\"}";
                                                }
                                            }
                                            finally
                                            {
                                                dList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                        }
                                    }catch(Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\""+ex.Message+"\"}";
                                    }
                                    break;
                                #endregion
                                #region 毛利
                                case "Data_Maori":
                                    ReJson = true;
                                    try
                                    {
                                        User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                        User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));
                                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate"));
                                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate") + " 23:59:59");

                                        if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                        {
                                            DataTable dList = DataUtils.GetErpData_analysis(bDate, eDate, 7);
                                            try
                                            {
                                                if (dList != null)
                                                {
                                                    Json_Str = "{\"code\":0,\"msg\":\"" + bDate.ToShortDateString().ToString() + " <-> " + eDate.ToShortDateString().ToString() + " 利润\",\"datalist\":[{\"Sales\":" + dList.Rows[0][0].ToString() + ",\"Cost\":" + dList.Rows[0][1].ToString() + ",\"Returns\":" + dList.Rows[0][2].ToString() + ",\"Bad\":" + dList.Rows[0][3].ToString() + ",\"Gifts\":" + dList.Rows[0][4].ToString() + ",\"Selling\":" + dList.Rows[0][5].ToString() + ",Profit:" + (Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5])).ToString() + "}]}";
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":3,\"msg\":\"没有数据\"}";
                                                }
                                            }
                                            finally
                                            {
                                                dList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion
                                #region 费用
                                case "Data_Fees":
                                    ReJson = true;
                                    try
                                    {
                                        User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                        User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));
                                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate"));
                                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate") + " 23:59:59");
                                        tAction = Utils.StrToInt(HTTPRequest.GetString("tType"),8);//公司费用=8,营销费用=9
                                        string tTitleStr = (tAction == 8) ? "公司" : "营销";
                                        int mType = (tAction == 8) ? 1 : 0;
                                        if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                        {
                                            DataTable dList = DataUtils.Get_Fees_analysis(bDate, eDate, mType);
                                            try
                                            {
                                                if (dList != null)
                                                {
                                                    string tLoopstr = "";
                                                    decimal tAllValue = 0;
                                                    foreach (DataRow dr in dList.Rows)
                                                    {
                                                        tLoopstr += "{Data:[\""+dr[0]+"\",\""+dr[1]+"\"]},";
                                                        tAllValue += Convert.ToDecimal(dr[1]);
                                                    }
                                                    if (tLoopstr.Substring(tLoopstr.Length-1, 1) == ",")
                                                    {
                                                        tLoopstr = tLoopstr.Substring(0, tLoopstr.Length - 1);
                                                    }
                                                    Json_Str = "{\"code\":0,\"msg\":\"" + bDate.ToShortDateString().ToString() + " <-> " + eDate.ToShortDateString().ToString() + " " + tTitleStr + "费用\",\"AllFees\":" + tAllValue + ",\"datalist\":[" + tLoopstr + "]}";
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":3,\"msg\":\"无数据!\"}";
                                                }
                                            }
                                            finally
                                            {
                                                dList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion
                                #region 利润排行
                                case "Data_Toplist":
                                    ReJson = true;
                                    try
                                    {
                                        User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                        User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));
                                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate"));
                                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate") + " 23:59:59");
                                        tAction = Utils.StrToInt(HTTPRequest.GetString("mType"), 1);//1:门店/客户, 2:业务员, 3:促销员, 4:产品
                                        string tTitleStr = (tAction == 1) ? "门店" : (tAction == 2) ? "业务员" : (tAction == 3) ? "促销员" : (tAction == 4) ? "产品" : "";
                                        if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                        {
                                            DataTable dList = DataUtils.GetErpData_analysis(bDate, eDate, tAction);
                                            try
                                            {
                                                if (dList != null)
                                                {
                                                    string tLoopstr = "";
                                                    decimal tAllValue = 0;
                                                    if (tAction == 4)
                                                    {
                                                        foreach (DataRow dr in dList.Rows)
                                                        {
                                                            tLoopstr += "{Data:[\"" + dr[1] + "\",\"" + dr["S_TOTAL"] + "\",\"" + dr["S_QUANTITY"] + "\",\"" + dr["BadgoodsFees"] + "\",\"" + dr["ReturnsFees"] + "\",\"" + dr["CostFees"] + "\",\"" + dr["Profit"] + "\"]},";
                                                            tAllValue += Convert.ToDecimal(dr["Profit"]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        foreach (DataRow dr in dList.Rows)
                                                        {
                                                            tLoopstr += "{Data:[\"" + dr["sName"] + "\",\"" + dr["Sales"] + "\",\"" + dr["SalesFees"] + "\",\"" + dr["GiftsFees"] + "\",\"" + dr["BadgoodsFees"] + "\",\"" + dr["ReturnsFees"] + "\",\"" + dr["CostFees"] + "\",\"" + dr["Profit"] + "\"]},";
                                                            tAllValue += Convert.ToDecimal(dr["Profit"]);
                                                        }
                                                    }
                                                    if (tLoopstr.Substring(tLoopstr.Length - 1, 1) == ",")
                                                    {
                                                        tLoopstr = tLoopstr.Substring(0, tLoopstr.Length - 1);
                                                    }

                                                    Json_Str = "{\"code\":0,\"msg\":\"" + bDate.ToShortDateString().ToString() + " <-> " + eDate.ToShortDateString().ToString() + " " + tTitleStr + "利润 排行\",\"AllProfit\":" + tAllValue + ",\"datalist\":[" + tLoopstr + "]}";
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":3,\"msg\":\"无数据!\"}";
                                                }
                                            }
                                            finally
                                            {
                                                dList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion

                                #region 综合统计
                                case "GetBasisData":
                                    ReJson = true;
                                    try
                                    {
                                        User_Name = Utils.ChkSQL(HTTPRequest.GetString("UserName"));
                                        User_PWD = Utils.ChkSQL(HTTPRequest.GetString("UserPWD"));
                                        if (BLL.tbUserInfo.CheckPassword(User_Name, User_PWD, true) > 0)
                                        {
                                            //净资产
                                            string NetAssetsStr = "";
                                            string NetAssetsLoopStr = "";
                                            DataTable NetAssetsDataList = DataUtils.GetNetAssets(DateTime.Now);
                                            if (NetAssetsDataList != null)
                                            {
                                                foreach (DataRow dr in NetAssetsDataList.Rows)
                                                {
                                                    NetAssetsLoopStr += "{BankMoney:" + dr["BankMoney"].ToString() + "," +
                                                                          "StockMoney:" + dr["StockMoney"].ToString() + "," +
                                                                          "ARMoney_A:" + dr["ARMoney_A"].ToString() + "," +
                                                                          "ARMoney_B:" + dr["ARMoney_B"].ToString() + "," +
                                                                          "APMoney_A:" + dr["APMoney_A"].ToString() + "," +
                                                                          "APMoney_B:" + dr["APMoney_B"].ToString() + "," +
                                                                          "FixedMoney:" + dr["FixedMoney"].ToString() + "," +
                                                                          "NetAssetsMoney:" + dr["NetAssetsMoney"].ToString() +
                                                                          "},";
                                                }
                                                if (NetAssetsLoopStr.Substring(NetAssetsLoopStr.Length - 1, 1) == ",")
                                                {
                                                    NetAssetsLoopStr = NetAssetsLoopStr.Substring(0, NetAssetsLoopStr.Length - 1);
                                                }
                                                NetAssetsStr = "{NetAssets:[" + NetAssetsLoopStr + "]}";
                                            }
                                            //近一周生日人员列表
                                            string BirthdayStr = "";
                                            string BirthdayLoopStr = "";
                                            DataTable BirthdayDataList = GetStaffBirthdayList();
                                            if (BirthdayDataList != null)
                                            {
                                                DataView dv = new DataView();
                                                dv.Table = BirthdayDataList;

                                                dv.RowFilter = " ThisYearBirthday >='" + System.DateTime.Now.ToShortDateString() + "' and  ThisYearBirthday<='" + System.DateTime.Now.AddDays(7).ToShortDateString() + "'";

                                                BirthdayDataList = dv.Table;

                                                foreach (DataRow dr in BirthdayDataList.Rows)
                                                {
                                                    BirthdayLoopStr += "{StaffID:" + dr["StaffID"].ToString() + "," +
                                                        "sName:" + dr["sName"].ToString() + "," +
                                                        "sSex:" + dr["sSex"].ToString() + "," +
                                                        "Birthday:" + DateTime.Parse(dr["ThisYearBirthday"].ToString()).Month.ToString() + "月" + DateTime.Parse(dr["ThisYearBirthday"].ToString()).Day.ToString() + "" +
                                                        "},";
                                                }
                                                if (BirthdayLoopStr.Substring(BirthdayLoopStr.Length - 1, 1) == ",")
                                                {
                                                    BirthdayLoopStr = BirthdayLoopStr.Substring(0, BirthdayLoopStr.Length - 1);
                                                }
                                                BirthdayStr = "{Birthday:[" + BirthdayLoopStr + "]}";
                                            }
                                            //本月

                                            Json_Str = "{\"code\":0,\"msg\":\"获取成功\",datalist:[" + NetAssetsStr + "," + BirthdayStr + "]}";
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":1,\"msg\":\"用户名密码错误!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion

                                #region 提交新完成单据
                                case "ImportNewOrder":
                                    ReJson = true;
                                    try {
                                        int SuccessCount = 0;
                                        int FailureCount = 0;
                                        string passportkey = Utils.ChkSQL(HTTPRequest.GetString("passportkey"));
                                        string OrderIDStr = Utils.ChkSQL(HTTPRequest.GetString("OrderID"));

                                        if (passportkey == GeneralConfigs.GetConfig().ErpWebServicePWD.Trim())
                                        {
                                            if (OrderIDStr.Trim() != "")
                                            {
                                                DataTable OrderTb = new DataTable();
                                                OrderTb = tbProductsInfo.GetOrderList(OrderIDStr.Trim());
                                                if (OrderTb != null)
                                                {
                                                    Json_Str = GetErpOrderList(OrderTb, true, out SuccessCount, out FailureCount);
                                                    if (Json_Str.Substring(Json_Str.Length - 1, 1) == ",")
                                                    {
                                                        Json_Str = Json_Str.Substring(0, Json_Str.Length - 1);
                                                    }
                                                    Json_Str = "{\"code\":0,\"msg\":\"完成!\",{ReData:[" + Json_Str + "]}}";
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":0,\"msg\":\"数据为空!\"}";
                                                }
                                            }
                                            else
                                            {
                                                Json_Str = "{\"code\":0,\"msg\":\"单据编号错误!\"}";
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":0,\"msg\":\"鉴权失败!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion

                                #region 删除指定单据
                                case "DeleteOrder":
                                    ReJson = true;
                                    try
                                    {

                                        string passportkey = Utils.ChkSQL(HTTPRequest.GetString("passportkey"));
                                        string OrderIDStr = Utils.ChkSQL(HTTPRequest.GetString("OrderID"));

                                        if (passportkey == GeneralConfigs.GetConfig().ErpWebServicePWD.Trim())
                                        {
                                            if (OrderIDStr.Trim() != "")
                                            {
                                                try
                                                {
                                                    tbErpOrderInfo.DeleteErpOrderInfoByOID(Convert.ToInt32(OrderIDStr.Trim()));
                                                    Json_Str = "{\"code\":0,\"msg\":\"完成!\"}";
                                                }
                                                catch {
                                                    Json_Str = "{\"code\":0,\"msg\":\"系统错误!\"}";
                                                }
                                                
                                            }
                                            else
                                            {
                                                Json_Str = "{\"code\":0,\"msg\":\"单据编号错误!\"}";
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":0,\"msg\":\"鉴权失败!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion

                                #region 查询产品实时库存
                                case "GetProductStock":
                                    ReJson = true;
                                    try {
                                        string passportkey = Utils.ChkSQL(HTTPRequest.GetString("passportkey"));
                                        if (passportkey == GeneralConfigs.GetConfig().ErpWebServicePWD.Trim())
                                        {
                                            string ProductName = Utils.ChkSQL(HTTPRequest.GetString("ProductName"));
                                            if (ProductName.Trim() != "")
                                            {
                                                ProductsInfo _pi = tbProductsInfo.GetProductsInfoModelByName(ProductName.Trim());
                                                if (_pi != null)
                                                {
                                                    DataTable _dt = DataUtils.GetStock_analysis(0, DateTime.Now, _pi.ProductsID);
                                                    if (_dt != null)
                                                    {
                                                        foreach (DataRow dr in _dt.Rows)
                                                        {
                                                            Json_Str += "{\"ProductsID\":" + dr["ProductsID"].ToString() + ",\"QUANTITY\":" + dr["S_QUANTITY"].ToString() + ",\"isOK\":" + dr["isOK"].ToString() + ",isBad:" + dr["isBad"].ToString() + ",\"sAppendTime\":\"" + dr["sAppendTime"].ToString() + "\"},";
                                                        }
                                                        if (Json_Str.Substring(Json_Str.Length - 1, 1) == ",")
                                                        {
                                                            Json_Str = Json_Str.Substring(0, Json_Str.Length - 1);
                                                        }
                                                        Json_Str = "{\"code\":-1,\"msg\":\"OK!\",\"ReData\":[" + Json_Str + "]}";
                                                    }
                                                    else
                                                    {
                                                        Json_Str = "{\"code\":0,\"msg\":\"产品未找到,无具体数据,请同步数据!\"}";
                                                    }
                                                }
                                                else
                                                {
                                                    Json_Str = "{\"code\":0,\"msg\":\"产品未找到,请同步数据!\"}";
                                                }
                                            }
                                            else
                                            {
                                                Json_Str = "{\"code\":0,\"msg\":\"产品名称不能为空!\"}";
                                            }
                                        }
                                        else
                                        {
                                            Json_Str = "{\"code\":0,\"msg\":\"鉴权失败!\"}";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Json_Str = "{\"code\":2,\"msg\":\"" + ex.Message + "\"}";
                                    }
                                    break;
                                #endregion

								#region UpFile
								case "UpFile":
								ReJson = true;
									string FileType = HTTPRequest.GetString("FileType");
									string fObj = HTTPRequest.GetString("fObj");
									HttpFileCollection files = HttpContext.Current.Request.Files;
									try{
										if (files.Count > 0)
										{
											HttpPostedFile postedFile = files[0];
											string Path = @"/ufile/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + @"/";
											string modifyFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
											string uploadFilePath = System.Web.HttpContext.Current.Server.MapPath("/") +Path;

											string tFileType = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(".")+1);
											System.IO.DirectoryInfo dir=new System.IO.DirectoryInfo(uploadFilePath);
											//判断文件夹否存在,不存在则创建
											if(!dir.Exists)
											{
												dir.Create();
											}

											if(FileType.ToLower().IndexOf(tFileType.ToLower())>-1){

												string filePath = uploadFilePath + modifyFileName + "." + tFileType;
												postedFile.SaveAs(filePath);
												filePath = Path + modifyFileName + "." + tFileType;
												Json_Str = "{\"code\":0,\"msg\":\"OK\",\"fObj\":\""+fObj+"\",\"file\":\""+filePath+"\"}";
											}else{
												Json_Str = "{\"code\":-2,\"msg\":\"文件类型必须是 "+FileType+"!\"}";
											}
										}
									}catch{
										Json_Str = "{\"code\":-1,\"msg\":\"失败!\"}";
									}
									finally
									{
										files = null;
									}
									break;
								#endregion

								#region 查看是否完成收发货
							case "CheckStorageProductLogCutLen":
								ReJson = true;
								int _OrderID = HTTPRequest.GetInt("OrderID", 0);
								int _StorageProductLogCutLen = tbStorageProductLogInfo.GetStorageProductLogCutLenFromOrderID (_OrderID);
								Json_Str = "{\"code\":0,\"msg\":\"OK\",\"CutLen\":"+_StorageProductLogCutLen+"}";
								break;
								#endregion

                                default:
                                    Rss_XML = "<Error>2</Error><MSG><![CDATA[参数错误.]]></MSG>";
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Rss_XML = "<Error>0</Error><MSG><![CDATA[系统错误,请联系管理员,错误代码:" + ex + "]]></MSG>";
                        }
                    }

                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                    
                    Response.Expires = 0;
                    Response.AddHeader("pragma", "no-cache");
                    Response.AddHeader("cache-control", "");
                    Response.CacheControl = "no-cache";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;

                    if (ReJson) {
                        Response.Charset = "utf-8";
                        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                        Response.ContentType = "application/json";
                        if (Json_Str.Trim() == "")
                        {
                            Json_Str = "{\"results\": []}";
                        }
                        Response.Write(Json_Str);
                    }
                    else if (ReChartsXML)
                    {
                        Response.Charset = "utf-8";
                        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                        Response.ContentType = "text/xml";
                        Response.Write(Rss_XML);
                        Response.End();
					}else if(ReTxt){
						Response.Charset = "utf-8";
						//Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");

						Response.Write(Rss_XML);
						Response.End();
					}
                    else
                    {
                        Response.Charset = "utf-8";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                        Response.ContentType = "text/xml";

                        if (FullRss_XML.Equals(""))
                        {
                            Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?><root>" + Rss_XML + "</root>");
                        }
                        else
                        {
                            Response.Write(FullRss_XML);
                        }
                    }
                    Response.End();
                }
                finally
                {
                    list = null;
                    xmlDoc = null;
                    PostdoValue = null;
                }
            }
        }
        public string AddRegion(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int add_Region_PaterID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "PaterID")).Trim(), 0);
            string add_Region_Value = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "vValue")).Trim();
            RegionInfo ri = new RegionInfo();
            try
            {
                ri.rName = add_Region_Value;
                ri.rUpID = add_Region_PaterID;
                ri.rOrder = 0;
                ri.rState = 0;
                ri.rAppendTime = DateTime.Now;

                int RegionID = tbRegionInfo.AddRegionInfo(ri);
                if (RegionID > 0)
                {
                    Rss_XML = "<Error>-1</Error><MSG><![CDATA[创建成功.]]></MSG><RegionID>" + RegionID + "</RegionID>";
                }
                else
                {
                    Rss_XML = "<Error>10</Error><MSG><![CDATA[系统忙,请稍后.]]></MSG>";
                }
            }
            finally
            {
                ri = null;
            }
            return Rss_XML;
        }
        public string EditRegion(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int edit_RegionID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "RegionID")).Trim(), 0);
            int edit_Region_PaterID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "PaterID")).Trim(), 0);
            string edit_Region_Value = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "vValue")).Trim();
            RegionInfo ri = new RegionInfo();
            try
            {
                ri = tbRegionInfo.GetRegionInfoModel(edit_RegionID);
                ri.rName = edit_Region_Value;

                tbRegionInfo.UpdateRegionInfo(ri);

                Rss_XML = "<Error>-1</Error><MSG><![CDATA[修改成功.]]></MSG><RegionID>" + edit_RegionID + "</RegionID>";
            }
            finally
            {
                ri = null;
            }
            return Rss_XML;
        }
        public string DelRegion(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int del_RegionID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "RegionID")).Trim(), 0);
            tbRegionInfo.DeleteRegionInfo(del_RegionID);
            Rss_XML = "<Error>-1</Error><MSG><![CDATA[删除成功.]]></MSG><RegionID>" + del_RegionID + "</RegionID>";
            return Rss_XML;
        }
        public string GetRegionTreeList(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            Rss_XML = "<Error>-1</Error><MSG><![CDATA[获取成功.]]></MSG><RegionValues>" + Caches.GetRegionListToXML() + "</RegionValues>";
            return Rss_XML;
        }
        public string GetRegionTreeList_noCaches(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            Rss_XML = "<Error>-1</Error><MSG><![CDATA[获取成功.]]></MSG><RegionValues>" + tbRegionInfo.GetRegionListToXML() + "</RegionValues>";
            return Rss_XML;
        }
        
        public string GetRegionTreeChildList(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int PRegionID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "PaterID")).Trim(), 0);
            Rss_XML = "<Error>-1</Error><MSG><![CDATA[获取成功.]]></MSG><RegionValues>" + Caches.GetRegionListToXML(PRegionID) + "</RegionValues>";
            return Rss_XML;
        }
        public string GetRegionTreeChildList_noCaches(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int PRegionID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "PaterID")).Trim(), 0);
            Rss_XML = "<Error>-1</Error><MSG><![CDATA[获取成功.]]></MSG><RegionValues>" + tbRegionInfo.GetRegionListToXML(PRegionID) + "</RegionValues>";
            return Rss_XML;
        }
        public string EditRegionPaterID(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            int edit_RegionID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "RegionID")).Trim(), 0);
            int edit_RegionPaterID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "PaterID")).Trim(), 0);

            string cidstr = "," + tbRegionInfo.GetRegionChildrenStr(edit_RegionID) + ",";
            if (cidstr.IndexOf("," + edit_RegionPaterID + ",") > -1)
            {
                Rss_XML = "<Error>10</Error><MSG><![CDATA[不能移动到子对象.]]></MSG>";
            }
            else
            {
                RegionInfo ri = new RegionInfo();
                try
                {
                    ri = tbRegionInfo.GetRegionInfoModel(edit_RegionID);
                    ri.rUpID = edit_RegionPaterID;

                    tbRegionInfo.UpdateRegionInfo(ri);

                    Rss_XML = "<Error>-1</Error><MSG><![CDATA[修改成功.]]></MSG><RegionID>" + edit_RegionID + "</RegionID>";
                }
                finally
                {
                    ri = null;
                }
            }
            return Rss_XML;
        }
        public string EditRegionOrder(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            string sCID = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "sCID")).Trim();
            string tCID = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "tCID")).Trim();
            string nCIDstr = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "nCIDstr")).Trim();
            string pCID = Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "pCID")).Trim();
            if (sCID != "" && tCID != "" && nCIDstr != "" && pCID != "")
            {
                tbRegionInfo.UpdateRegionOrder(sCID, tCID, nCIDstr, pCID);
                Rss_XML = "<Error>-1</Error><MSG><![CDATA[操作成功.]]></MSG>";
            }
            return Rss_XML;
        }
        public string GetErpProductList(XmlDocument xmlDoc)
        {
            string Rss_XML = "";
            DataTable dt = tbProductsInfo.getERPProductList("");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["P_NAME"].ToString().Trim() != "" )
                    {
                        Rss_XML += "<Product><P_NAME><![CDATA[" + dr["P_NAME"].ToString().Trim() + "]]></P_NAME>" +
                                    "<P_CODE><![CDATA[" + dr["P_CODE"].ToString().Trim() + "]]></P_CODE>"+
                                    "<TYPENAME><![CDATA[" + dr["TYPENAME"].ToString().Trim() + "]]></TYPENAME>"+
                                    "<P_ID><![CDATA[" + dr["P_ID"].ToString().Trim() + "]]></P_ID></Product>";
                    }
                }
            }
            else
            {
                Rss_XML = "<Error>0</Error><MSG><![CDATA[获取远程数据失败!]]></MSG>";
            }

            return "<Error>-1</Error><MSG><![CDATA[获取成功.]]></MSG><ProductList>" + Rss_XML + "</ProductList>";
        }
        public string GetErpProductOrderList(XmlDocument xmlDoc)
        {
            int SuccessCount = 0;
            int FailureCount = 0;
            string Rss_XML = "";
            int pID = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "pID")).Trim(),0);
            int oType = Utils.StrToInt(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "oType")).Trim(),0);
            DateTime bDate = Utils.IsDateString(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "bDate")).Trim()) ? DateTime.Parse(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "bDate")).Trim()) : DateTime.Now;
            DateTime eDate = Utils.IsDateString(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "eDate")).Trim()) ? DateTime.Parse(Utils.ChkSQL(Utils.GetXMLData(xmlDoc, "eDate")).Trim()) : DateTime.Now;

            DataTable dt = tbProductsInfo.getERPProductOrderList(pID, oType, bDate, eDate);
            if (dt != null)
            {
                Rss_XML = GetErpOrderList(dt, false, out SuccessCount, out FailureCount);
            }
            else
            {
                Rss_XML = "<Error>0</Error><MSG><![CDATA[Get Data Error!]]></MSG>";
            }

            return "<Error>-1</Error><MSG><![CDATA[Get Data Success.]]></MSG><pID>" + pID + "</pID><oType>" + oType + "</oType>" +
            "<bDate><![CDATA[" + bDate + "]]></bDate><eDate><![CDATA[" + eDate + "]]></eDate><SuccessCount>" + SuccessCount + "</SuccessCount><FailureCount>" + FailureCount + "</FailureCount><ProductOrderMsgList>" + Rss_XML + "</ProductOrderMsgList>";
        }
        public string GetErpOrderList(DataTable OrderTb, bool IsJson, out int SuccessCount, out int FailureCount)
        {
            string ReStr = "";
            SuccessCount = 0;
            FailureCount = 0;
            if (OrderTb != null)
            {
                foreach (DataRow dr in OrderTb.Rows)
                {
                    if (dr["P_NAME"].ToString().Trim() != "")
                    {
                        if (!tbErpOrderInfo.ExistsErpOrderInfo(Utils.StrToInt(dr["O_ID"].ToString().Trim(), 0),
                            dr["O_ORDERNUM"].ToString().Trim(),
                            Utils.StrToInt(dr["P_ID"].ToString().Trim(), 0),
                            Utils.StrToInt(dr["S_ID"].ToString().Trim(), 0),
                            Utils.StrToInt(dr["R_ID"].ToString().Trim(), 0),
                            DateTime.Parse(dr["O_CREATETIME"].ToString().Trim())))
                        {
                            ErpOrderInfo eo = new ErpOrderInfo();
                            ProductsInfo pi = new ProductsInfo();
                            StoresInfo si = new StoresInfo();
                            StaffInfo ssi = new StaffInfo();
                            SupplierInfo spi = new SupplierInfo();

                            pi = tbProductsInfo.GetProductsInfoModelByName(dr["P_NAME"].ToString().Trim());
                            if (pi == null)
                            {
                                pi = tbProductsInfo.GetProductsInfoModelByBarcode(dr["P_CODE"].ToString().Trim());
                            }
                            if (pi != null)
                            {
                                eo.ProductsID = pi.ProductsID;
                            }
                            else
                            {
                                eo.ProductsID = 0;
                            }

                            //供货商
                            if (Utils.StrToInt(dr["R_ID"].ToString().Trim(), 0) == 4 || Utils.StrToInt(dr["R_ID"].ToString().Trim(), 0) == 8)
                            {
                                spi = tbSupplierInfo.GetSupplierInfoModelByName(dr["C_NAME"].ToString().Trim());
                                if (spi == null)
                                {
                                    spi = tbSupplierInfo.GetSupplierInfoModelByCode(dr["C_CODE"].ToString().Trim());
                                }
                                if (spi != null)
                                {
                                    eo.StoresID = spi.SupplierID;
                                }
                            }
                            else
                            {

                                si = tbStoresInfo.GetStoresInfoModelByName(dr["C_NAME"].ToString().Trim());
                                if (si == null)
                                {
                                    si = tbStoresInfo.GetStoresInfoModelByCode(dr["C_CODE"].ToString().Trim());
                                }
                                if (si != null)
                                {
                                    eo.StoresID = si.StoresID;
                                }
                            }
                            ssi = tbStaffInfo.GetStaffInfoModelByName(dr["SA_NAME"].ToString().Trim());
                            if (ssi != null)
                            {
                                eo.StaffID = ssi.StaffID;
                            }

                            eo.O_ID = Utils.StrToInt(dr["O_ID"].ToString().Trim(), 0);
                            eo.O_ORDERNUM = dr["O_ORDERNUM"].ToString().Trim();
                            eo.O_CREATETIME = DateTime.Parse(dr["O_CREATETIME"].ToString().Trim());
                            eo.P_ID = Utils.StrToInt(dr["P_ID"].ToString().Trim(), 0);
                            eo.P_CODE = dr["P_CODE"].ToString().Trim();
                            eo.P_NAME = dr["P_NAME"].ToString().Trim();
                            eo.P_RULES = dr["P_RULES"].ToString().Trim();
                            eo.S_ID = Utils.StrToInt(dr["S_ID"].ToString().Trim(), 0);
                            eo.S_PRICE = decimal.Parse(Utils.StrToFloat(dr["S_PRICE"].ToString().Trim(), 0).ToString());
                            eo.S_QUANTITY = Utils.StrToInt(dr["S_QUANTITY"].ToString().Trim(), 0);
                            eo.S_TOTAL = decimal.Parse(dr["S_TOTAL"].ToString().Trim());
                            eo.C_CODE = dr["C_CODE"].ToString().Trim();
                            eo.C_NAME = dr["C_NAME"].ToString().Trim();
                            eo.R_NAME = dr["R_NAME"].ToString().Trim();
                            eo.R_ID = Utils.StrToInt(dr["R_ID"].ToString().Trim(), 0);
                            eo.SA_NAME = dr["SA_NAME"].ToString().Trim();
                            eo.eAppendTime = DateTime.Now;
                            eo.PROMOTIONS = Utils.StrToInt(dr["PROMOTIONS"].ToString().Trim(), 0);
                            eo.storageid = Utils.StrToInt(dr["storageid"].ToString().Trim(), 0);

                            if (tbErpOrderInfo.AddErpOrderInfo(eo) > 0)
                            {
                                if (!IsJson)
                                {
                                    ReStr += "<ProductOrderMsg><O_ORDERNUM><![CDATA[" + dr["O_ORDERNUM"].ToString().Trim() + "]]></O_ORDERNUM>" +
                                        "<State>-1</State>" +
                                    "<Msg><![CDATA[Success]]></Msg></ProductOrderMsg>";
                                }
                                else
                                {
                                    ReStr += "{\"code\":-1,\"msg\":\"Success\",\"O_ORDERNUM\":\"" + dr["O_ORDERNUM"].ToString().Trim() + "\"},";
                                }
                                SuccessCount++;
                            }
                            else
                            {
                                if (!IsJson)
                                {
                                    ReStr += "<ProductOrderMsg><O_ORDERNUM><![CDATA[" + dr["O_ORDERNUM"].ToString().Trim() + "]]></O_ORDERNUM>" +
                                        "<State>0</State>" +
                                    "<Msg><![CDATA[Insert Data Error]]></Msg></ProductOrderMsg>";
                                }
                                else
                                {
                                    ReStr += "{\"code\":0,\"msg\":\"Insert Data Error\",\"O_ORDERNUM\":\"" + dr["O_ORDERNUM"].ToString().Trim() + "\"},";
                                }
                                FailureCount++;
                            }
                        }
                        else
                        {
                            if (!IsJson)
                            {
                                ReStr += "<ProductOrderMsg><O_ORDERNUM><![CDATA[" + dr["O_ORDERNUM"].ToString().Trim() + "]]></O_ORDERNUM>" +
                                    "<State>0</State>" +
                                "<Msg><![CDATA[Data Repeat]]></Msg></ProductOrderMsg>";
                            }
                            else
                            {
                                ReStr += "{\"code\":0,\"msg\":\"Data Repeat\",\"O_ORDERNUM\":\"" + dr["O_ORDERNUM"].ToString().Trim() + "\"},";
                            }
                            FailureCount++;
                        }
                    }
                    else
                    {
                        if (!IsJson)
                        {
                            ReStr += "<ProductOrderMsg><O_ORDERNUM><![CDATA[" + dr["O_ORDERNUM"].ToString().Trim() + "]]></O_ORDERNUM>" +
                                        "<State>0</State>" +
                                    "<Msg><![CDATA[Data Error NO Name]]></Msg></ProductOrderMsg>";
                        }
                        else
                        {
                            ReStr += "{\"code\":0,\"msg\":\"Data Error NO Name\",\"O_ORDERNUM\":\"" + dr["O_ORDERNUM"].ToString().Trim() + "\"},";
                        }
                        FailureCount++;
                    }
                }
            }
            return ReStr;
        }
        public string GetSalesChartsXML()
        {
            string Rss_XML = "";
            string Rss_XML_B = "";
            string Rss_XML_C = "";
            string tableName = "";
            int tStoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID"), 0);
            int tStaffID = Utils.StrToInt(HTTPRequest.GetString("StaffID"), 0);
            int tStaffIDB = Utils.StrToInt(HTTPRequest.GetString("StaffIDB"), 0);
            string tBrand = Utils.ChkSQL(HTTPRequest.GetString("tBrand").Trim());
            int tRegionID = Utils.StrToInt(HTTPRequest.GetString("RegionID"), 0);
            DateTime tbDate = DateTime.Parse(HTTPRequest.GetString("bDate").Trim());
            DateTime teDate = DateTime.Parse(HTTPRequest.GetString("eDate").Trim());
            int tShowType = Utils.StrToInt(HTTPRequest.GetString("ShowType"), 1);
            int tProductID = Utils.StrToInt(HTTPRequest.GetString("ProductID"), 1);
            int tYHsysID = Utils.StrToInt(HTTPRequest.GetString("YHsysID"), 1);
            decimal AllSumValue = 0;
            switch (tShowType)
            { 
                case 1:
                    tableName = "门店";
                    break;
                case 2:
                    tableName = "业务员";
                    break;
                case 3:
                    tableName = "促销员";
                    break;
                case 4:
                    tableName = "产品";
                    break;
                case 5:
                    tableName = "品牌";
                    break;
            }

            DataTable A_Data = new DataTable();
            A_Data = DataUtils.GetSales_analysis(tStoresID, tStaffID, tStaffIDB, tBrand, tRegionID, tProductID, tYHsysID, tbDate, teDate, tShowType, 1, out AllSumValue);
            if (A_Data != null)
            {
                foreach (DataRow dr in A_Data.Rows)
                {
                    Rss_XML_B += "<category label=\"" + dr[0].ToString() + "\" /> ";
                    Rss_XML_C += "<dataset seriesName=\"" + dr[0].ToString() + "\"  showValues=\"0\" ><set value=\"" + dr[1].ToString() + "\"/></dataset>";
                }
                Rss_XML = "<chart palette=\"2\" showBorder=\"1\" caption=\"" + tableName + " 销售数据分析\" xAxisName=\"" + tableName + "\" yAxisName=\"销售额\" shownames=\"1\" showvalues=\"0\" useRoundEdges=\"1\" legendBorderAlpha=\"0\">"+
                    "<categories>" + Rss_XML_B + "</categories>" + Rss_XML_C + "</chart>";
            }
            return Rss_XML;
        }

        //返回格式化后的人员列表,含出生年月日
        public DataTable GetStaffBirthdayList()
        {
            DataTable dt = DataUtils.GetStaffBirthdayList();
            if (dt != null)
            {
                IdentityCardInfo ic = new IdentityCardInfo();
                try
                {
                    DataColumn column = new DataColumn();
                    column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "Birthday";
                    dt.Columns.Add(column);

                    column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "ThisYearBirthday";
                    dt.Columns.Add(column);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["sCarID"].ToString().Trim() != "")
                        {
                            ic = PublicLib.CheckIdCard(dr["sCarID"].ToString().Trim());
                            if (ic != null)
                            {
                                dr["Birthday"] = ic.Birthday;
                                dr["ThisYearBirthday"] = ic.ThisYearBirthDay;
                            }
                        }
                    }
                    dt.AcceptChanges();
                }
                finally {
                    ic = null;
                }
            }
            return dt;
        }
    }
}

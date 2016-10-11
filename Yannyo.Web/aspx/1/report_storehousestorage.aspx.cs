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
    public partial class report_storehousestorage : PageBase
    {
        //实现绑定数据到前台
        public DataTable dList = new DataTable();
        public DataTable List = new DataTable();
        public DataTable list = new DataTable();
        public StoresInfo si = new StoresInfo();
        public DataTable sList = new DataTable();
        public DataTable hList = new DataTable();
        public DataTable yList = new DataTable();//销售年份
        public DataTable pList = new DataTable();
        public DataTable fList = new DataTable();//营业员门店每月数量
        public int rList;
        public string sName;//门店名称
        public string sCode;//门店编号
        public int ReType;//0=周；1=月；2=年
        public DateTime sDate=DateTime.Now.AddDays(-(DateTime.Now.Day)+1) ;//定义时间
        public DateTime stDate = DateTime.Now;//定义时间
        public string ProductsID;//产品编号
        public int pType;//出入库标志 期初=-1;入库=0;出库=1;损耗=2
        public int StoresID = -1;//客户系统编号
        public int rID = -1;//区域ID
        public int staffID = -1;//营业员ID
        public string name = "";
        public string sfName = "";
        public string rName = "";
        public string Act = "";
        public string Region = "";
        public int reType = -1;
        public string get_rName = "";
        public string get_storageName = "";
        public string get_staffName = "";
        public string get_reTypeValue = "";
        public decimal SumA, SumAA, SumAAA,SumC, SumCC, SumCCC, SumD, SumDD;
        public decimal SumB, SumBA, SumBB, SumBC, SumBD, SumBE, SumBF, SumBG, SumBH, SumBI;
        public decimal SumE, SumEA, SumEB, SumEC, SumED, SumEE, SumEF, SumEG, SumEH, SumEI, SumEJ, SumEK;
        public decimal SumF, SumFA, SumFB, SumFC, SumFD, SumFE, SumFF, SumFG, SumFH, SumFI, SumFJ, SumFK;
        public int bType = 0;//报表类型
        public int value = 0;
        public string sfname;
        public DataTable count;
        public int tLoopid;
        public DataTable productsDetails;
        public string s_year;
        public int _associated;//联营
        public string associated;

        public string Export_Act;//导出
        public int d_count=0;
        public DataSet dset = new DataSet();

        public DataTable getStorage_Num(string datetime, string sname)
        {
            int sid = storehouseStorage.getStaffIDByName(sname);
            fList = storehouseStorage.getStorageNum(datetime, sid);
            if (fList.Rows.Count > 0)
            {
                return fList;
            }
            else
            {
                return null;
            }
        }

        public DataTable getProductsDetails(string datetime, string sname)
        {
            int sid = storehouseStorage.getStorageIDBystorageName(sname);
            pList = storehouseStorage.getProductsDetaisMonth(datetime, sid);
            if (pList.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = dList.Copy();
                dt.TableName = "d_" + d_count;
                dset.Tables.Add(dt);
                d_count++;
                return pList;
            }
            else
            {
                return null;
            }
        }
        public DataTable stName(string sfname)
        {
            hList = storehouseStorage.getStorehouseNameByStaffName(sfname);
            if (hList.Rows.Count > 0)
            {
                return hList;
            }
            else
            {
                return null;
            }
        }
        public int rowList(string sname)
        {
           count = storehouseStorage.getStorehouseNameByNameList(sname);
           if (count.Rows.Count > 0)
           {
               return count.Rows.Count;
           }
           else
           {
               return -1;
           }
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-2"))
                {
                    si = tbStoresInfo.GetStoresInfoModel(StoresID);
                    sName = HTTPRequest.GetString("SName");
                    List = storehouseStorage.RegionName();
                    Act = HTTPRequest.GetString("act");//获取客户端post过来Act的值
                    bType = HTTPRequest.GetInt("id",-1);
                    sList = storehouseStorage.getStaffName();
                    sfname = HTTPRequest.GetString("");
                    yList = storehouseStorage.getSalesYear();
                    Export_Act = HTTPRequest.GetString("Act");

                    //获取前台传过来的区域得到区域ID
                    get_rName = HTTPRequest.GetString("rName");
                    rID = storehouseStorage.GetRegionIDByName(get_rName);
                    //根据传过来的门店名称找到该门店的编号:表tbStoresInfo
                    get_storageName = HTTPRequest.GetString("storageName");
                    StoresID = storehouseStorage.getStorageIDByName(get_storageName);
                    //根据营业员名称得到营业员id
                    get_staffName = HTTPRequest.GetString("staffName");
                    staffID = storehouseStorage.getStaffIDByName(get_staffName);
                    //获取客户端过来的选择类型
                    get_reTypeValue = HTTPRequest.GetString("reTypeValue");
                    reType = HTTPRequest.GetInt("reTypeValue", -1);
                    //获取客户端过来的联营类型
                    associated = HTTPRequest.GetString("associated");
                    _associated = HTTPRequest.GetInt("_associated", -1);

                    //获取选择的日期
                    sDate = (HTTPRequest.GetString("sDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim() + " 00:00:00") : DateTime.Now.AddDays(-(DateTime.Now.Day)+1);
                    stDate = (HTTPRequest.GetString("stDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("stDate").Trim() + " 23:59:59") : DateTime.Now;

                    if (ispost)
                    {
                        if (bType == 0)
                        {
                            if (Act == "act")
                            {
                                name = HTTPRequest.GetString("path");//获取客户端post过来的区域值
                                sfName = HTTPRequest.GetString("pathend");//获取客户端post过来的门店值
                                rName = HTTPRequest.GetString("pathRname");

                                if (name.Trim() != "")
                                {
                                    list = storehouseStorage.StaffNameByRegionName(name);

                                    for (int i = 0; i < list.Rows.Count; i++)
                                    {
                                        Response.Write(list.Rows[i][0].ToString() + ",");
                                    }
                                    Response.End();
                                }
                                if (sfName.Trim() != "")
                                {
                                    List = storehouseStorage.GetStorageName(rName, sfName);
                                    for (int i = 0; i < List.Rows.Count; i++)
                                    {
                                        Response.Write(List.Rows[i][0].ToString() + ",");
                                    }
                                    Response.End();
                                }
                            }
                            else
                            {

                                if (sDate > stDate)
                                {
                                    AddErrLine("日期区间选择错误，请重新选择！");
                                }
                                else
                                {
                                    dList = storehouseStorage.GetStorehouseStorageReport(rID, StoresID, staffID, sDate, stDate, reType, _associated);
                                }
                            }
                        }
                        if (bType == 1)
                        {
                            s_year = HTTPRequest.GetString("s_year");
                        }
                    }
                    else
                    {
                        
                        if (Export_Act.IndexOf("act") > -1)
                        {
                            if (bType == 0)
                            {
                                DataTable dt = new DataTable();
                                DataSet ds = new DataSet();
                                dList = storehouseStorage.GetStorehouseStorageReport(rID, StoresID, staffID, sDate, stDate, reType, _associated);
                                dt = dList.Copy();
                                dt.Columns.RemoveAt(0);
                                ds.Tables.Add(dt);
                                ds.Tables[0].Columns[0].ColumnName = "商品条码";
                                ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                ds.Tables[0].Columns[2].ColumnName = "装件数";
                                ds.Tables[0].Columns[3].ColumnName = "期初数";
                                ds.Tables[0].Columns[4].ColumnName = "进货数量";
                                ds.Tables[0].Columns[5].ColumnName = "销售数量";
                                ds.Tables[0].Columns[6].ColumnName = "进货金额";
                                ds.Tables[0].Columns[7].ColumnName = "销售金额";
                                ds.Tables[0].Columns[8].ColumnName = "期初金额";
                                ds.Tables[0].Columns[9].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[10].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[11].ColumnName = "样品数量";
                                ds.Tables[0].Columns[12].ColumnName = "样品金额";
                                ds.Tables[0].Columns[13].ColumnName = "退货数量";
                                ds.Tables[0].Columns[14].ColumnName = "退货金额";

                                CreateExcel(ds.Tables[0], "客户进销存报表_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
                            }
                        }
                    }


                }
                else
                {
                    AddErrLine("权限不足!");
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
            pagetitle = config.CompanyName + " 进销存报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
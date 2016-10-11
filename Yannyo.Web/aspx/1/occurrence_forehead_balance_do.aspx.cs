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

namespace Yannyo.Web
{
    public partial class occurrence_forehead_balance_do : PageBase
    {
        public DataTable dList = new DataTable();           //上年结转
        public DataTable cList = new DataTable();           //待摊费用明细
        public DataTable mList = new DataTable();           //获得月份
        public DataTable nTable = new DataTable();          //去掉重复的月份
        public string maxList;                              //获得最大月
        public string FeesSubjectJson="" ;                  //科目选择
        public string fsubject;                             //科目编号
        public DataTable fsubjectName=new DataTable();
        public DataTable objectName=new DataTable();        //科目名称
        public string getYear;                              //截取年份
        public DateTime bDate=DateTime.Now;
        public DateTime eDate=DateTime.Now;
        public int tLoopid;
        public int tCount=0;
        public decimal sumA, sumAA, sumB, sumBB, sumC,sumCC,sumJ;
        public decimal cAccountMoney, JAccountMoney;
        public decimal JDirection, DDirection;
        public decimal moneyA, moneyB, sumD, sumDD, sumE, sumEE;//总账统计
        public int sType;
        public int cMonth;

        public decimal oMoney;
        public int c_count = 0;
        public DataSet classDataSet = new DataSet();
        public string dataclass;
        public string[] result;
        public bool tl=false;
        //--===========数据合并===========
        public DataTable ydt = new DataTable();          //上年结存
        public DataSet yds = new DataSet();              //上年结存
        public DataTable ysCost = new DataTable();       //上年结存合成表
        public decimal ycAccountMoney;                   //上年结存余额

     

        public DataTable mdt = new DataTable();         //月份
        public DataSet mds = new DataSet();             //月份
        public DataTable msCost = new DataTable();          //月份合成表

        public object obj = new object();
        public decimal cdMoney, cdMoneyA, cdMoneyB, cdMoneyBB;
        public decimal pMonth;//月份计较
        public int maxValue = 0;
        public int oneMonth = 0;//第一个月
        public int status = 0;

        //明细账
        public DataTable getMonthCostDetails(string subjects,DateTime bDate,DateTime eDate,string oMonth,int sType,int status)
        {
            DataTable cdt = new DataTable();         //明细
            DataSet cds = new DataSet();             //明细
            DataTable csCost = new DataTable();      //明细合成表
            DataTable dtCost=new DataTable();
            result = subjects.Split(',');
            for (int i = 0; i < result.Length - 1; i++)
            {
                  bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                  if (tl)
                  {
                        dataclass = CostDetails.getTreeChildrenCount(result[i]);//找到子节点
                        string[] dclass = dataclass.Split(',');
                        for (int j = 0; j < dclass.Length - 1; j++)
                        {
                            dtCost = CostDetails.getMonthCost(Convert.ToInt32(dclass[j]), bDate, eDate, Convert.ToInt32(oMonth), sType, status);
                            cdt = dtCost.Copy();
                            cdt.TableName = "c_" + j + tCount;
                            cds.Tables.Add(cdt);
                            tCount++;
                        }
                        csCost = cds.Tables[0].Clone();//创建新表 克隆以有表的架构
                        object[] objArray = new object[csCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                        for (int m = 0; m < cds.Tables.Count; m++)
                        {
                            if (cds.Tables[m].Rows.Count > 0)
                            {
                                for (int n = 0; n < cds.Tables[m].Rows.Count; n++)
                                {
                                    cds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                    csCost.Rows.Add(objArray); //将数组的值添加到新表中
                                }
                            }
                        }

                       

                      }
                      else
                      {
                          csCost = CostDetails.getMonthCost(Convert.ToInt32(result[i]), bDate, eDate, Convert.ToInt32(oMonth), sType, status);
                      
                      }
            }

            if (csCost.Rows.Count > 0)
            {
                DataView dv = new DataView(csCost);
                dv.Sort = "Cmonth";
                csCost = dv.ToTable(true, "Cmonth", "Cday", "CertificateID", "pzCode", "cdName", "cdMoney", "cdMoneyA", "cdMoneyB", "cdMoneyBB", "cDirection", "FeesSubjectID", "cClassName", "cCode", "unit");
            }
                return csCost;
      
        }
        //总账
        public object getMonthCostTotalDetails(string subjects, DateTime bDate, DateTime eDate, string oMonth, int sType,int status)
        {
            DataTable cdt = new DataTable();         //明细
            DataSet cds = new DataSet();             //明细
            DataTable csCost = new DataTable();      //明细合成表
            DataTable dtCost = new DataTable();
            result = subjects.Split(',');
            for (int i = 0; i < result.Length - 1; i++)
            {
                bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                if (tl)
                {
                    dataclass = CostDetails.getTreeChildrenCount(result[i]);//找到子节点
                    string[] dclass = dataclass.Split(',');
                    for (int j = 0; j < dclass.Length - 1; j++)
                    {
                        dtCost = CostDetails.getMonthCost(Convert.ToInt32(dclass[j]), bDate, eDate, Convert.ToInt32(oMonth), sType, status);
                        cdt = dtCost.Copy();
                        cdt.TableName = "c_" + j + tCount;
                        cds.Tables.Add(cdt);
                        tCount++;
                    }
                    csCost = cds.Tables[0].Clone();//创建新表 克隆以有表的架构
                    object[] objArray = new object[csCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                    for (int m = 0; m < cds.Tables.Count; m++)
                    {
                        if (cds.Tables[m].Rows.Count > 0)
                        {
                            for (int n = 0; n < cds.Tables[m].Rows.Count; n++)
                            {
                                cds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                csCost.Rows.Add(objArray); //将数组的值添加到新表中
                            }
                        }
                    }

                }
                else
                {
                    csCost = CostDetails.getMonthCost(Convert.ToInt32(result[i]), bDate, eDate, Convert.ToInt32(oMonth), sType, status);
                }
            }
            if (csCost.Rows.Count > 0)
            {
                cdMoney = 0;
                cdMoneyA = 0;
                cdMoneyB = 0;
                cdMoneyBB = 0;

                cdMoney = Convert.ToDecimal(csCost.Compute("sum(cdMoney)", "").ToString()) ;
                cdMoneyA = Convert.ToDecimal(csCost.Compute("sum(cdMoneyA)", "").ToString());
                cdMoneyB = Convert.ToDecimal(csCost.Compute("sum(cdMoneyB)", "").ToString()) ;
                cdMoneyBB = Convert.ToDecimal(csCost.Compute("sum(cdMoneyBB)", "").ToString()) ;
            }
            else
            {
                cdMoney = 0;
                cdMoneyA = 0;
                cdMoneyB = 0;
                cdMoneyBB = 0;
            }
            return obj;
        }
     
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-7-9"))
                {
                    //科目树
                    FeesSubjectJson = Caches.GetFeesSubjectClassInfoToJson(-1, false, true);
                    
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now.AddDays(-(DateTime.Now.Day)+1); //获得日期
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now; //获得日期
                    sType = HTTPRequest.GetInt("seType", -1);          //统计类型：0=明细统计，1=总账统计
                    getYear = bDate.ToString("yyyy");
                    oneMonth =Convert.ToInt32(bDate.ToString("MM"));
                    status = HTTPRequest.GetInt("get_status",0);


                    //获得科目选择，遍历科目
                    fsubject = HTTPRequest.GetString("subject_hd"); 
                    result = fsubject.Split(',');
                 
                   
                   
                    if (ispost)
                    {
                        for (int i = 0; i < result.Length - 1; i++)
                        {
                            //获得科目所选节点科目名称
                            fsubjectName = CostDetails.getObjectsListName(Convert.ToInt32(result[i]));
                            
                            //判断是否有子节点
                            tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                            if (tl)
                            {
                                 
                                 dataclass = CostDetails.getTreeChildrenCount(result[i]);//找到子节点
                                 string[] dclass = dataclass.Split(',');
                                 for (int j = 0; j < dclass.Length - 1; j++)
                                 {
                                     //获得月份
                                     mList = CostDetails.getMonthBySubjectAndDateTime(Convert.ToInt32(dclass[j]), bDate, eDate);
                                     mdt = mList.Copy();
                                     mdt.TableName = "m_" + j + c_count;
                                     mds.Tables.Add(mdt);
                                    
                                     
                                     //获得最大月
                                     maxList += CostDetails.getMonthBySubjectAndDateTime_Max(Convert.ToInt32(dclass[j]), bDate, eDate) + ",";
                                     //获得科目名称及编码
                                     objectName = CostDetails.getSubjectNameAndID(Convert.ToInt32(dclass[j]));
                                     
                                     //上年结转余额
                                     dList = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(dclass[j]), status);
                                     ydt = dList.Copy();
                                     ydt.TableName = "y_" + j + c_count;
                                     yds.Tables.Add(ydt);

                                     c_count++;
                                 }
                                 //--====================================月份合成表=============================================
                                 msCost = mds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                 object[] objmArray = new object[msCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                 for (int m = 0; m < mds.Tables.Count; m++)
                                 {
                                     if (mds.Tables[m].Rows.Count > 0)
                                     {
                                         for (int n = 0; n < mds.Tables[m].Rows.Count; n++)
                                         {
                                             mds.Tables[m].Rows[n].ItemArray.CopyTo(objmArray, 0); //将表的一行的值存放数组中
                                             msCost.Rows.Add(objmArray); //将数组的值添加到新表中
                                         }
                                     }
                                 }
                                 DataView dv = new DataView(msCost);
                                 dv.Sort = "oMonth";
                                 nTable = dv.ToTable(true, "oMonth");
                                 //=====================上年结存余额合成一张表==============================
                                 ysCost = yds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                 object[] objArray = new object[ysCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                 for (int m = 0; m < yds.Tables.Count; m++)
                                 {
                                     if (yds.Tables[m].Rows.Count > 0)
                                     {
                                         for (int n = 0; n < yds.Tables[m].Rows.Count; n++)
                                         {
                                             yds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                             ysCost.Rows.Add(objArray); //将数组的值添加到新表中
                                         }
                                     }
                                 }
                                 if (ysCost.Rows.Count > 0)
                                 {
                                     ycAccountMoney = Convert.ToDecimal(ysCost.Compute("sum(cAccountMoney)", "").ToString());
                                 }
                                 
                                //====================找到科目中最大月========================================
                                 string[] maxListArrary = maxList.Split(',');
                                
                                 for (int q = 0; q < maxListArrary.Length - 1; q++)
                                 {
                                     if (maxListArrary[q].ToString() != "")
                                     {
                                         int mValue = Convert.ToInt32(maxListArrary[q].ToString());
                                         if (mValue > maxValue)
                                         {
                                             maxValue = mValue;
                                         }
                                     }
                                 }
                                 maxList = maxValue.ToString();
                                 
                            }
                            else
                            {
                                //上年结转余额
                                ysCost = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(result[i]), status);
                                //获得月份
                                nTable = CostDetails.getMonthBySubjectAndDateTime(Convert.ToInt32(result[i]), bDate, eDate);
                                //获得最大月
                                maxList = CostDetails.getMonthBySubjectAndDateTime_Max(Convert.ToInt32(result[i]), bDate, eDate);
                                //获得科目名称及编码
                                objectName = CostDetails.getSubjectNameAndID(Convert.ToInt32(result[i]));
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
            pagetitle = "发生额及余额明细";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
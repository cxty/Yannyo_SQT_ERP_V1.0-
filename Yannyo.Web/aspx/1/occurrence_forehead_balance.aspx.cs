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
    public partial class occurrence_forehead_balance : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable kList = new DataTable();   //科目编号
        public DataTable sCost = new DataTable();
        public DataTable newTable = new DataTable();
        public DateTime bDate;
        public DateTime eDate;
        public decimal jAcount;     //期末余额借
        public decimal DAcount;     //期末余额贷
        public decimal oMoney;      //期初余额借
        public decimal qMoney;      //期初余额贷
        public decimal bMoney;      //本期发生借
        public decimal bMoneyd;     //本期发生贷
        public decimal sumA, sumAA, sumB, sumBB, sumC, sumCC;
        public int sType=0;           //统计类型
        public string getTreeNode="";
        public string TreeName;
        public string[] result;
        public int c_count = 0;
        public object obj = new object();
        public int status = 0;//审核状态

        public decimal cAccountMoney, JcdMoney, DcdMoney, OMoney, iMoney;
      
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-7-10"))
                {
                    bDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) : DateTime.Now.AddDays(-(DateTime.Now.Day)+1);
                    eDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("eDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("eDate"))) : DateTime.Now;
                    sType = HTTPRequest.GetInt("sType",0);
                    status = HTTPRequest.GetInt("get_status", 0);//0=全部；1=已审核

                    if (ispost)
                    {
                        //按时间统计
                        if (sType == 0)
                        {
                            kList = CostDetails.getFeeSubjectID(bDate, eDate);
                            DataSet ds = new DataSet();
                            for (int i = 0; i < kList.Rows.Count; i++)
                            {
                                DataTable dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(kList.Rows[i][0]),status);
                                dList = dt.Copy();
                                dList.TableName = "t_" + i;
                                ds.Tables.Add(dList);
                            }
                            if (ds.Tables.Count > 0)
                            {
                                sCost = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                object[] objArray = new object[sCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                for (int m = 0; m < ds.Tables.Count; m++)
                                {
                                    if (ds.Tables[m].Rows.Count > 0)
                                    {
                                        for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                        {
                                            ds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                            sCost.Rows.Add(objArray); //将数组的值添加到新表中
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //按科目统计
                    if (sType == 1)
                    {

                        DataSet classDataSet = new DataSet();
                        getTreeNode = HTTPRequest.GetString("get_treeNode");
                        result = getTreeNode.Split(',');


                        //把选择的科目整理到dataset中
                        for (int i = 0; i < result.Length - 1; i++)
                        {
                            DataTable tr = CostDetails.getObjectsListName(Convert.ToInt32(result[i]));

                            if (tr != null)
                            {
                                for (int p = 0; p < tr.Rows.Count; p++)
                                {
                                    TreeName += tr.Rows[p][0].ToString() + ",";
                                }
                            }
                            else
                            {
                                TreeName = "";
                            }

                            //获得科目名称
                            DataTable className = CostDetails.getClassName(result[i]);

                            DataTable ddt = className.Copy();
                            ddt.TableName = "k" + i + c_count;
                            classDataSet.Tables.Add(ddt);
                            c_count++;
                        }
                        if (classDataSet.Tables.Count > 0)
                        {
                            //把dataset中的datatable合并到一张表中
                            newTable = classDataSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                            object[] objArray = new object[newTable.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                            for (int m = 0; m < classDataSet.Tables.Count; m++)
                            {
                                if (classDataSet.Tables[m].Rows.Count > 0)
                                {
                                    for (int n = 0; n < classDataSet.Tables[m].Rows.Count; n++)
                                    {
                                        classDataSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                        newTable.Rows.Add(objArray); //将数组的值添加到新表中
                                    }
                                }
                            }
                            if (TreeName.Length > 2)
                            {
                                TreeName = TreeName.Substring(0, TreeName.Length - 1);
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
            pagetitle = "发生额及余额查询";
            this.Load += new EventHandler(this.Page_Load);
        }
        public object getClassDetails(string feeID)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
           

            //判断是否有子节点
            bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(feeID));
            if (tl)
            {
                string dataclass = CostDetails.getTreeChildrenCount(feeID);
                string[] dclass = dataclass.Split(',');
                for (int j = 0; j < dclass.Length - 1; j++)
                {
                    dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(dclass[j]),status);
                    dList = dt.Copy();
                    dList.TableName = "t_" + j + c_count;
                    ds.Tables.Add(dList);
                    c_count++;
                }
            }
            else
            {
                dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(feeID),status);
                dList = dt.Copy();
                dList.TableName = "d_" + c_count;
                ds.Tables.Add(dList);
                c_count++;
            }

            if (ds.Tables.Count > 0)
            {
                //合成一张表
                sCost = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                object[] objArray = new object[sCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                for (int m = 0; m < ds.Tables.Count; m++)
                {
                    if (ds.Tables[m].Rows.Count > 0)
                    {
                        for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                        {
                            ds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                            sCost.Rows.Add(objArray); //将数组的值添加到新表中
                        }
                    }
                }
            }
            if (sCost.Rows.Count > 0)
            {
                cAccountMoney = Convert.ToDecimal(sCost.Compute("sum(cAccountMoney)", "").ToString());
                JcdMoney = Convert.ToDecimal(sCost.Compute("sum(JcdMoney)", "").ToString());
                DcdMoney = Convert.ToDecimal(sCost.Compute("sum(DcdMoney)", "").ToString());
                OMoney = Convert.ToDecimal(sCost.Compute("sum(oMoney)", "").ToString());
                iMoney = Convert.ToDecimal(sCost.Compute("sum(iMoney)", "").ToString());
            }
            else
            {
                cAccountMoney = 0;
                JcdMoney = 0;
                DcdMoney = 0;
                OMoney = 0;
                iMoney = 0;
            }

            return obj;
        }
    }
}
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
    public partial class occurrence_forehead_balance_print : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable ddt = new DataTable();
        public DataTable newTable = new DataTable();
        public DataTable sCost = new DataTable();
        public DataTable kList = new DataTable();   //科目编号
        public DateTime bDate = DateTime.Now;    //开始日期
        public DateTime eDate = DateTime.Now;    //结束日期
        public DateTime pDate = DateTime.Now;    //打印日期
        public UserInfo uiName = new UserInfo(); //制单人员
        
        public string bTime;
        public string eTime;
        public string pTime;
        public decimal jAcount;     //期末余额借
        public decimal DAcount;     //期末余额贷
        public decimal oMoney;      //期初余额借
        public decimal qMoney;      //期初余额贷
        public decimal bMoney;      //本期发生借
        public decimal bMoneyd;     //本期发生贷
        public int sType;           //查询类型：0=时间；1=科目
        public string getFeeID;     //获得科目编号

        public string getTreeNode = "";
        public string TreeName;
        public string[] result;
        public int c_count = 0;
        public object obj = new object();

        public decimal cAccountMoney, JcdMoney, DcdMoney, OMoney, iMoney;

        public int detailsCount;//统计行数
        public int MaxDetailsCount = 23;//最大行数
        public DataSet dsDetails = new DataSet(); //分页存储多个表
        public DataTable dt = new DataTable();
        public int rCount = 0;//判断是否为下一页
        public int status = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-7-10"))
                {
                    //接收打印类型
                    sType = HTTPRequest.GetInt("dType",0);

                    //接收日期参数
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now; //获得日期
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now; //获得日期
                    //页面日期格式转换
                    bTime = bDate.ToString("yyyy.MM");
                    eTime = eDate.ToString("yyyy.MM");
                    pTime = pDate.ToString("yyyy.MM.dd");
                    uiName = tbUserInfo.GetUserInfoModel(this.userid);
                    status = HTTPRequest.GetInt("status", 0);

                    //1、时间打印
                    if (sType == 0)
                    {
                        //读出数据
                        kList = CostDetails.getFeeSubjectID(bDate, eDate);
                        if (kList.Rows.Count > 0)
                        {
                            DataSet ds = new DataSet();
                            for (int i = 0; i < kList.Rows.Count; i++)
                            {
                                DataTable dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(kList.Rows[i][0]), status);
                                dList = dt.Copy();
                                dList.TableName = "t_" + i;
                                ds.Tables.Add(dList);
                            }

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
                            if (sCost.Rows.Count > 0)
                            {
                                detailsCount = sCost.Rows.Count;
                                int p = 0;
                                dt = sCost.Clone();
                                foreach (DataRow dr in sCost.Rows)
                                {
                                    dt.ImportRow(dr);
                                    p++;
                                    if (p % MaxDetailsCount == 0)
                                    {
                                        dsDetails.Tables.Add(dt);
                                        dt.TableName = "t_" + p;
                                        dt = sCost.Clone();
                                    }
                                }
                                if (dt.Rows.Count > 0)
                                {
                                    //剩下的行数
                                    dsDetails.Tables.Add(dt);
                                    dt = sCost.Clone();
                                    dt.TableName = "t_" + (p + 1);
                                }
                            }
                            else
                            {
                                AddErrLine("无数据打印，请查询后再次打印数据！");
                            }
                        }
                        else
                        {
                            AddErrLine("未能获得科目编号！");
                        }
                    }

                    //2、科目打印
                    if (sType == 1)
                    { 
                        //1.找到科目名称;
                        DataSet classDataSet = new DataSet();
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        getTreeNode = HTTPRequest.GetString("feeID");
                        result = getTreeNode.Split(',');

                        //把选择的科目整理到dataset中
                        for (int i = 0; i < result.Length - 1; i++)
                        {
                            //--==================获得科目名称================
                            DataTable className = CostDetails.getClassName(result[i]);
                            DataTable ddt = className.Copy();
                            ddt.TableName = "k" + i + c_count;
                            classDataSet.Tables.Add(ddt);
                            c_count++;

                        }

                        //-==========================合成科目名称表=============================
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
                        dsDetails.Tables.Add(newTable);

             
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
            pagetitle = "  发生额及余额打印";
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
                    dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(dclass[j]), status);
                    dList = dt.Copy();
                    dList.TableName = "t_" + j + c_count;
                    ds.Tables.Add(dList);
                    c_count++;
                }
            }
            else
            {
                dt = CostDetails.getOccurrenceAndBalanceDetails(bDate, eDate, Convert.ToInt32(feeID), status);
                dList = dt.Copy();
                dList.TableName = "d_" + c_count;
                ds.Tables.Add(dList);
                c_count++;
            }

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
            if (sCost.Rows.Count > 0)
            {
                cAccountMoney = Convert.ToDecimal(sCost.Compute("sum(cAccountMoney)", "").ToString());
                JcdMoney = Convert.ToDecimal(sCost.Compute("sum(JcdMoney)", "").ToString());
                DcdMoney = Convert.ToDecimal(sCost.Compute("sum(DcdMoney)", "").ToString());
                OMoney = Convert.ToDecimal(sCost.Compute("sum(oMoney)", "").ToString());
                iMoney = Convert.ToDecimal(sCost.Compute("sum(iMoney)", "").ToString());
                uiName = tbUserInfo.GetUserInfoModel(this.userid);
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
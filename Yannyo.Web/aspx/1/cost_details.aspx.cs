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
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
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
    public partial class cost_details : PageBase
    {
        /// <summary>
        /// 门店费用统计
        /// </summary>
        public DataTable oList = new DataTable();         //科目明细
        public DataTable sList = new DataTable();         //门店名称
        public DataTable rList = new DataTable();         //区域名称
        public DataTable kList = new DataTable();         //科目名称
        public DataTable nTable = new DataTable();        //将重复区域删除后存放
        public DataTable newData = new DataTable();       //将门店数据组合到一起，将同一门店相加
        public DataSet kDateSetName = new DataSet();      //数据暂存 
        public DataSet rDateSet = new DataSet();
        public DataSet SdateSetCost = new DataSet();      //费用统计：客户
        public DataTable cost_storehouse_list = new DataTable();//费用统计：客户

        public DateTime sDate = DateTime.Now.AddDays(-(DateTime.Now.Day)+1);             //开始日期
        public DateTime stDate = DateTime.Now;            //结束日期
        public int tType;                                 //下拉选择
        public int feeType;                               //费用选择
        public int moriType;                              //毛利选择
        public string getTreeNode="";                     //科目树
        public string TreeName="";                        //科目名称
        public int sID;                                   //门店编号

        public int tLoopid;
        public int s_count;
        public int get_direction;                         //借贷方向  0=借；1=贷
        public int c_count=0;
        public int count = 1;
        public decimal sumA;
        public string dataclass;
        public decimal test=0;

        public string Act;                              //导出标志
        /// <summary>
        /// 科目费用统计
        /// </summary>
        public DataTable className = new DataTable();    //科目名称获得
        public DataSet classDataSet = new DataSet();     //科目名称存储
        public DataTable newTable = new DataTable();     //合并科目名称
        public DataTable classList = new DataTable();    //科目费用列表
        public DataTable clist = new DataTable();

        /// <summary>
        /// 业务员费用统计
        /// </summary>
        public DataTable staffList = new DataTable();        //业务员名称
        public DataTable sCostList = new DataTable();        //业务员费用
        public DataSet sDataSet = new DataSet();             
        public DataTable sCostTable = new DataTable();
        public DataTable tnTable=new DataTable();
        public decimal sTest;

        /// <summary>
        /// 赠品费用统计
        /// </summary>
        public DataTable gList = new DataTable();          //赠品列表
        public DataTable gList_stor=new DataTable();       //返回赠品受影响行数
        public decimal sumC, sumB,sumCC,sumBB;

        /// <summary>
        /// 毛利统计
        /// </summary>
        public DataTable mList = new DataTable();         //区域毛利
        public int maori_ID;
        public decimal sumD, sumE, sumF;
        //1.费用统计——客户

        //获得门店的名称
        public DataTable getStoresName(string rid)
        {
            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
            get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向
            sList = CostDetails.getStorsList(get_direction, rid, sDate, stDate);
            if (sList.Rows.Count > 0)
            {
                return sList;
            }
            else
            {
                return null;
            }
        }
        //返回门店受影响的行集
        public int getStoresCount(string rid)
        {
            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
            get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向
            sList = CostDetails.getStorsList(get_direction, rid, sDate, stDate);
            return sList.Rows.Count;
        }
        //获得门店的费用
        public DataSet getCostOfStorehouse(string sid)
        {
            get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向

            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
           

            getTreeNode = HTTPRequest.GetString("get_treeNode");
            string[] result = getTreeNode.Split(',');
            for (int i = 0; i < result.Length - 1; i++)
            {
                //判断是否有子节点
                bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                if (tl)
                {
                    dataclass = CostDetails.getTreeChildrenCount(result[i]);

                    string[] dclass = dataclass.Split(',');
                    for (int j = 0; j < dclass.Length - 1; j++)
                    {
                        cost_storehouse_list = CostDetails.getCostOfStorehouse(Convert.ToInt32(sid), dclass[j].ToString(), get_direction, sDate, stDate);
                        DataTable ct = cost_storehouse_list.Copy();

                        ct.TableName = "p_" + j + "_" + c_count + count;
                        SdateSetCost.Tables.Add(ct);
                        c_count = c_count + 1;
                        count = count + 1;
                    }
                    newData = SdateSetCost.Tables[0].Clone();//创建新表 克隆以有表的架构
                    object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                    for (int m = 0; m < SdateSetCost.Tables.Count; m++)
                    {
                        if (SdateSetCost.Tables[m].Rows.Count > 0)
                        {
                            for (int n = 0; n < SdateSetCost.Tables[m].Rows.Count; n++)
                            {
                                SdateSetCost.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                newData.Rows.Add(obj); //将数组的值添加到新表中
                            }
                        }
                    }

                    try
                    {
                        test =Convert.ToDecimal(newData.Compute("sum(appendCost)", "").ToString());
                    }
                    catch(Exception e)
                    {
                        e.Message.ToString();
                    }
  
                }
                else
                {
                    cost_storehouse_list = CostDetails.getCostOfStorehouse(Convert.ToInt32(sid), result[i], get_direction, sDate, stDate);
                    DataTable ct = cost_storehouse_list.Copy();

                    ct.TableName = "j_" + i + c_count;
                    SdateSetCost.Tables.Add(ct);
                    c_count = c_count + 1;

                    newData = SdateSetCost.Tables[0].Clone();//创建新表 克隆以有表的架构
                    object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                    for (int m = 0; m < SdateSetCost.Tables.Count; m++)
                    {
                        if (SdateSetCost.Tables[m].Rows.Count > 0)
                        {
                            for (int n = 0; n < SdateSetCost.Tables[m].Rows.Count; n++)
                            {
                                SdateSetCost.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                newData.Rows.Add(obj); //将数组的值添加到新表中
                            }
                        }
                    }

                    try
                    {
                        test = Convert.ToDecimal(newData.Compute("sum(appendCost)", "").ToString());
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
            }
            return SdateSetCost;
        }
        
        //2.费用统计——科目
        
        //获得科目费用统计
        public Decimal getCostOfClass(string kid)
        {
            get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向

            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;

            //判断是否有子节点
            bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(kid));
            if (tl)
            {
                dataclass = CostDetails.getTreeChildrenCount(kid);
                 string[] dclass = dataclass.Split(',');
                 for (int j = 0; j < dclass.Length - 1; j++)
                 {
                     classList = CostDetails.getClassCost(get_direction, dclass[j].ToString(), sDate, stDate);
                     
                     DataTable ct = classList.Copy();
                     ct.TableName = "c_" + j + c_count;
                     rDateSet.Tables.Add(ct);
                     c_count = c_count + 1;
                 }

                 clist = rDateSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                 object[] objArray = new object[clist.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                 for (int m = 0; m < rDateSet.Tables.Count; m++)
                 {
                     if (rDateSet.Tables[m].Rows.Count > 0)
                     {
                         for (int n = 0; n < rDateSet.Tables[m].Rows.Count; n++)
                         {
                             rDateSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                             clist.Rows.Add(objArray); //将数组的值添加到新表中
                         }
                     }
                     else
                     {
                         test = 0;
                     }
                 }
                 try
                 {
                     if (get_direction == 0)
                     {
                         test = Convert.ToDecimal(clist.Compute("sum(cdMoney)", "").ToString());
                     }
                     if (get_direction == 1)
                     {
                         test = Convert.ToDecimal(clist.Compute("sum(cdMoneyB)", "").ToString());
                     }
                 }
                 catch(Exception e)
                 {
                     e.Message.ToString();
                 }

            }
            else
            {
                classList = CostDetails.getClassCost(get_direction, kid, sDate, stDate);
                if (classList.Rows.Count > 0)
                {
                    if (get_direction == 0)
                    {
                        test = Convert.ToDecimal(classList.Compute("sum(cdMoney)", "").ToString());
                    }
                    if (get_direction == 1)
                    {
                        test = Convert.ToDecimal(classList.Compute("sum(cdMoneyB)", "").ToString());
                    }
                }
                else
                {
                    test = 0;
                }
            }
            return test;
        }

        //费用统计——业务员
        public Decimal getCostOFStaff(string staffID)
        {
            get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向
            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
            getTreeNode = HTTPRequest.GetString("get_treeNode");
            string[] result = getTreeNode.Split(',');
            sTest = 0;
            for (int i = 0; i < result.Length - 1; i++)
            {
                 //判断是否有子节点
                bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                DataSet sCostDataSet = new DataSet();
                if (tl)
                {
                    dataclass = CostDetails.getTreeChildrenCount(result[i]);

                    string[] dclass = dataclass.Split(',');
                    for (int j = 0; j < dclass.Length - 1; j++)
                    {
                        sCostList = CostDetails.getCostOfStaffID(get_direction, sDate, stDate, Convert.ToInt32(dclass[j].ToString()), Convert.ToInt32(staffID));

                        DataTable ct = sCostList.Copy();

                        ct.TableName = "s_" + j + c_count;
                        sCostDataSet.Tables.Add(ct);
                        c_count = c_count + 1;
                    }
                    DataTable sCost = new DataTable();
                    sCost = sCostDataSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                    object[] objArray = new object[sCost.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                    for (int m = 0; m < sCostDataSet.Tables.Count; m++)
                    {
                        if (sCostDataSet.Tables[m].Rows.Count > 0)
                        {
                            for (int n = 0; n < sCostDataSet.Tables[m].Rows.Count; n++)
                            {
                                sCostDataSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                sCost.Rows.Add(objArray); //将数组的值添加到新表中
                            }
                        }
                    }
                    try
                    {
                        if (get_direction == 0)
                        {
                            sTest += Convert.ToDecimal(sCost.Compute("sum(cdMoney)", "").ToString());
                        }
                        if (get_direction == 1)
                        {
                            sTest += Convert.ToDecimal(sCost.Compute("sum(cdMoneyB)", "").ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
                else
                {
                  sCostList = CostDetails.getCostOfStaffID(get_direction, sDate, stDate,Convert.ToInt32(result[i].ToString()),Convert.ToInt32(staffID));

                  if (sCostList.Rows.Count > 0)
                  {
                     
                      if (get_direction == 0)
                      {
                          sTest += Convert.ToDecimal(sCostList.Compute("sum(cdMoney)", "").ToString());
                      }
                      if (get_direction == 1)
                      {
                          sTest += Convert.ToDecimal(sCostList.Compute("sum(cdMoneyB)", "").ToString());
                      }
                  }
                }
            }
            return sTest;
        }

        //费用统计——赠品
        public int getCost_Gifts_count(string sid)
        {
            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
            gList = CostDetails.getGiftCost(Convert.ToInt32(sid), sDate, stDate);
            if (gList.Rows.Count > 0)
            {
                return gList.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-7-8"))
                {
                    Act = HTTPRequest.GetString("Act").Trim();
                    tType = HTTPRequest.GetInt("tType", 0);
                    feeType = HTTPRequest.GetInt("feeType", 0);
                    get_direction = HTTPRequest.GetInt("get_direction", 0);//借贷方向
                    //获得科目节点选择
                    getTreeNode = HTTPRequest.GetString("get_treeNode").Trim();
                    string[] result = getTreeNode.Split(',');
                    if (ispost)
                    {
                        
                        maori_ID = HTTPRequest.GetInt("maori_ID",0);  //销售类型：0=购销；1=联营：2=直销
                        moriType = HTTPRequest.GetInt("moriType", 0);  //毛利统计类别
                        sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
                        stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
                        
                        
                       
                            //1.费用统计_门店
                            if (tType == 1 && feeType == 0)
                            {
                                //获得科目名称
                                for (int i = 0; i < result.Length - 1; i++)
                                {
                                    DataTable dttp = CostDetails.getObjectsListName(Convert.ToInt32(result[i]));

                                    if (dttp !=null)
                                    {
                                        for (int pp = 0; pp < dttp.Rows.Count; pp++)
                                        {
                                            TreeName += dttp.Rows[0][0] + ",";
                                        }
                                    }
                                    else
                                    {
                                        TreeName = "";
                                    }
                                       
                                }
                                if (TreeName.Length > 2)
                                {
                                    TreeName = TreeName.Substring(0, TreeName.Length - 1);
                                }
                                for (int i = 0; i < result.Length - 1; i++)
                                {
                                    //判断是否有子节点
                                    bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                                    if (tl)
                                    {
                                        dataclass = CostDetails.getTreeChildrenCount(result[i]);

                                        string[] dclass = dataclass.Split(',');
                                        for (int j = 0; j < dclass.Length - 1; j++)
                                        {
                                            //获得科目信息
                                            kList = CostDetails.getTreeName(dclass[j].ToString());
                                            DataTable dt = kList.Copy();
                                            dt.TableName = "p_" + j + c_count;
                                            kDateSetName.Tables.Add(dt);

                                            //获得区域信息
                                            rList = CostDetails.getRegionList(get_direction, dclass[j].ToString(), sDate, stDate);

                                            DataTable rt = rList.Copy();
                                            rt.TableName = "o_" + j + c_count;
                                            rDateSet.Tables.Add(rt);
                                            c_count = c_count + 1;
                                        }

                                        DataTable newDataTable = rDateSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                                        object[] objArray = new object[newDataTable.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                        for (int m = 0; m < rDateSet.Tables.Count; m++)
                                        {
                                            if (rDateSet.Tables[m].Rows.Count > 0)
                                            {
                                                for (int n = 0; n < rDateSet.Tables[m].Rows.Count; n++)
                                                {
                                                    rDateSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                                    newDataTable.Rows.Add(objArray); //将数组的值添加到新表中
                                                }
                                            }
                                        }
                                        DataView dv = new DataView(newDataTable);
                                        dv.Sort = "RegionID";
                                        nTable = dv.ToTable(true, "RegionID", "rName");

                                    }
                                    else
                                    {
                                        //获得科目信息
                                        kList = CostDetails.getTreeName(result[i]);
                                        DataTable dt = kList.Copy();
                                        dt.TableName = "m_" + i;
                                        kDateSetName.Tables.Add(dt);

                                        //获得区域信息
                                        rList = CostDetails.getRegionList(get_direction, result[i], sDate, stDate);

                                        DataTable rt = rList.Copy();
                                        rt.TableName = "f_" + i;
                                        rDateSet.Tables.Add(rt);

                                        DataTable newDataTable = rDateSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                                        object[] objArray = new object[newDataTable.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                        for (int m = 0; m < rDateSet.Tables.Count; m++)
                                        {
                                            if (rDateSet.Tables[m].Rows.Count > 0)
                                            {
                                                for (int n = 0; n < rDateSet.Tables[m].Rows.Count; n++)
                                                {
                                                    rDateSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                                    newDataTable.Rows.Add(objArray); //将数组的值添加到新表中
                                                }
                                            }
                                        }
                                        DataView dv = new DataView(newDataTable);
                                        dv.Sort = "RegionID";
                                        nTable = dv.ToTable(true, "RegionID", "rName");
                                    }
                                }

                            }
                        //2.费用统计_科目
                        if (tType == 1 && feeType == 1)
                        {
                            //获得科目名称
                            for (int i = 0; i < result.Length - 1; i++)
                            {
                                DataTable dttp = CostDetails.getObjectsListName(Convert.ToInt32(result[i]));

                                if (dttp != null)
                                {
                                    for (int pp = 0; pp < dttp.Rows.Count; pp++)
                                    {
                                        TreeName += dttp.Rows[0][0] + ",";
                                    }
                                }
                                else
                                {
                                    TreeName = "";
                                }
                            }
                            if (TreeName.Length > 2)
                            {
                                TreeName = TreeName.Substring(0, TreeName.Length - 1);
                            }
                            
                                //把选择的科目整理到dataset中
                            for (int i = 0; i < result.Length - 1; i++)
                            {
                                className = CostDetails.getClassName(result[i]);

                                DataTable ddt = className.Copy();
                                ddt.TableName = "k" + i + c_count;
                                classDataSet.Tables.Add(ddt);
                                c_count++;
                            }
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

                        }
                        //3.费用统计_业务员
                        if (tType == 1 && feeType == 2)
                        {
                            //获得科目名称
                            for (int i = 0; i < result.Length - 1; i++)
                            {
                                DataTable dttp = CostDetails.getObjectsListName(Convert.ToInt32(result[i]));

                                if (dttp != null)
                                {
                                    for (int pp = 0; pp < dttp.Rows.Count; pp++)
                                    {
                                        TreeName += dttp.Rows[0][0] + ",";
                                    }
                                }
                                else
                                {
                                    TreeName = "";
                                }
                            }
                            if (TreeName.Length > 2)
                            {
                                TreeName = TreeName.Substring(0, TreeName.Length - 1);
                            }
                            
                            for (int i = 0; i < result.Length - 1; i++)
                            {
                                //判断是否有子节点
                                bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                                if (tl)
                                {
                                    dataclass = CostDetails.getTreeChildrenCount(result[i]);

                                    string[] dclass = dataclass.Split(',');
                                    for (int j = 0; j < dclass.Length - 1; j++)
                                    {
                                        //获得科目信息
                                        kList = CostDetails.getTreeName(dclass[j].ToString());
                                        DataTable dt = kList.Copy();
                                        dt.TableName = "p_" + j + c_count;
                                        kDateSetName.Tables.Add(dt);

                                        staffList = CostDetails.getStaffName(get_direction, sDate, stDate, Convert.ToInt32(dclass[j]));
                                        DataTable stl = staffList.Copy();
                                        stl.TableName = "qp_" + j + c_count;
                                        sDataSet.Tables.Add(stl);
                                        c_count++;
                                    }
                                }
                                else
                                {
                                    //获得科目信息
                                    kList = CostDetails.getTreeName(result[i]);
                                    DataTable dt = kList.Copy();
                                    dt.TableName = "m_" + i;
                                    kDateSetName.Tables.Add(dt);
                                    //获取业务员名称
                                    staffList = CostDetails.getStaffName(get_direction, sDate, stDate, Convert.ToInt32(result[i]));
                                    DataTable stl = staffList.Copy();
                                    stl.TableName = "we_" + i + c_count;
                                    sDataSet.Tables.Add(stl);
                                }
                            }
                              sCostTable = sDataSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                                    object[] objArray = new object[sCostTable.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                    for (int m = 0; m < sDataSet.Tables.Count; m++)
                                    {
                                        if (sDataSet.Tables[m].Rows.Count > 0)
                                        {
                                            for (int n = 0; n < sDataSet.Tables[m].Rows.Count; n++)
                                            {
                                                sDataSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                                sCostTable.Rows.Add(objArray); //将数组的值添加到新表中
                                            }
                                        }
                                    }
                                    DataView dv = new DataView(sCostTable);
                                    dv.Sort = "StaffID";
                                    tnTable = dv.ToTable(true, "StaffID", "sName");
                        }
                        //4.费用统计_赠品
                        if (tType == 1 && feeType == 3)
                        {
                            DataTable dt = CostDetails.getGiftCost(0, sDate, stDate);
                            if (dt.Rows.Count > 0)
                            {
                                gList_stor = dt.Copy();
                            }
                           
                            gList = CostDetails.getGiftCost(0, sDate, stDate);
                            
                        }

                        //1.毛利统计
                        if (tType == 0)
                        {
                            mList = CostDetails.getMoriOfRegion(moriType, 0,sDate,stDate);
                        }
                    }
                    else
                    {
                        if (Act.IndexOf("act") > -1)
                        {
                            sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) : DateTime.Now;
                            stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("eDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("eDate"))) : DateTime.Now;
                            DataTable dt = new DataTable();
                            DataSet ds = new DataSet();
                            if (tType == 0)
                            {
                                moriType = HTTPRequest.GetInt("mType",0);
                                mList = CostDetails.getMoriOfRegion(moriType, 0, sDate, stDate);

                                dt = mList.Copy();
                                ds.Tables.Add(dt);
                                if (moriType == 0)
                                {
                                    ds.Tables[0].Columns[0].ColumnName = "区域名称";
                                }
                                if (moriType == 1)
                                {
                                    ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                }
                                if (moriType == 2)
                                {
                                    ds.Tables[0].Columns[0].ColumnName = "业务员名称";
                                }
                                if (moriType == 3)
                                {
                                    ds.Tables[0].Columns[0].ColumnName = "品牌名称";
                                }
                                if (moriType == 4)
                                {
                                    ds.Tables[0].Columns[0].ColumnName = "单品名称";

                                }
                                ds.Tables[0].Columns[1].ColumnName = "销售金额";
                                ds.Tables[0].Columns[2].ColumnName = "成本金额";
                                ds.Tables[0].Columns[3].ColumnName = "利润金额";

                                CreateExcel(ds.Tables[0], "毛利统计_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
                            }
                            if (tType == 1)
                            {
                                DataSet dss = new DataSet();
                                if (feeType == 3)
                                {
                                    gList = CostDetails.getGiftCost(0, sDate, stDate);
                                    dt = gList.Copy();
                                    dt.Columns.RemoveAt(0);
                                    dt.Columns.RemoveAt(0);
                                    dt.Columns.RemoveAt(1);
                                    ds.Tables.Add(dt);
                                    ds.Tables[0].Columns[0].ColumnName = "门店名称";
                                    ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                    ds.Tables[0].Columns[2].ColumnName = "商品条码";
                                    ds.Tables[0].Columns[3].ColumnName = "赠品单数量";
                                    ds.Tables[0].Columns[4].ColumnName = "销售单数量";
                                    ds.Tables[0].Columns[5].ColumnName = "赠品金额";

                                    CreateExcel(ds.Tables[0],"赠品数据_"+DateTime.Now.ToString("yyyy-MM-dd")+".xls");
                                }
                                else
                                {
                                    for (int i = 0; i < result.Length - 1; i++)
                                    {
                                        //判断是否有子节点
                                        bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(result[i]));
                                        if (tl)
                                        {
                                            dataclass = CostDetails.getTreeChildrenCount(result[i]);

                                            string[] dclass = dataclass.Split(',');
                                            for (int j = 0; j < dclass.Length - 1; j++)
                                            {
                                                //客户
                                                if (feeType == 0)
                                                {
                                                    rList = CostDetails.getCostOfStorehouse(-1, dclass[j].ToString(), get_direction, sDate, stDate);
                                                    dt = rList.Copy();
                                                    dt.TableName = "k_" + j;
                                                    ds.Tables.Add(dt);

                                                    newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                    object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                    for (int m = 0; m < ds.Tables.Count; m++)
                                                    {
                                                        if (ds.Tables[m].Rows.Count > 0)
                                                        {
                                                            for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                            {
                                                                ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                                newData.Rows.Add(obj); //将数组的值添加到新表中
                                                            }
                                                        }
                                                    }
                                                }
                                                //科目
                                                if (feeType == 1)
                                                {
                                                    rList = CostDetails.getClassCost(get_direction, dclass[j].ToString(), sDate, stDate);
                                                    dt = rList.Copy();
                                                    dt.TableName = "c_" + j;
                                                    ds.Tables.Add(dt);

                                                    newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                    object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                    for (int m = 0; m < ds.Tables.Count; m++)
                                                    {
                                                        if (ds.Tables[m].Rows.Count > 0)
                                                        {
                                                            for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                            {
                                                                ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                                newData.Rows.Add(obj); //将数组的值添加到新表中
                                                            }
                                                        }
                                                    }
                                                }
                                                //业务员
                                                if (feeType == 2)
                                                {
                                                    rList = CostDetails.getCostOfStaffID(get_direction, sDate, stDate, Convert.ToInt32(dclass[j].ToString()), -1);
                                                    dt = rList.Copy();
                                                    dt.TableName = "y_" + j;
                                                    ds.Tables.Add(dt);

                                                    newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                    object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                    for (int m = 0; m < ds.Tables.Count; m++)
                                                    {
                                                        if (ds.Tables[m].Rows.Count > 0)
                                                        {
                                                            for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                            {
                                                                ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                                newData.Rows.Add(obj); //将数组的值添加到新表中
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //客户
                                            if (feeType == 0)
                                            {
                                                rList = CostDetails.getCostOfStorehouse(-1, result[i], get_direction, sDate, stDate);
                                                dt = rList.Copy();
                                                dt.TableName = "k_" + i;
                                                ds.Tables.Add(dt);

                                                newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                for (int m = 0; m < ds.Tables.Count; m++)
                                                {
                                                    if (ds.Tables[m].Rows.Count > 0)
                                                    {
                                                        for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                        {
                                                            ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                            newData.Rows.Add(obj); //将数组的值添加到新表中
                                                        }
                                                    }
                                                }
                                            }
                                            //科目
                                            if (feeType == 1)
                                            {
                                                rList = CostDetails.getClassCost(get_direction, result[i], sDate, stDate);
                                                dt = rList.Copy();
                                                dt.TableName = "c_" + i;
                                                ds.Tables.Add(dt);

                                                newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                for (int m = 0; m < ds.Tables.Count; m++)
                                                {
                                                    if (ds.Tables[m].Rows.Count > 0)
                                                    {
                                                        for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                        {
                                                            ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                            newData.Rows.Add(obj); //将数组的值添加到新表中
                                                        }
                                                    }
                                                }
                                            }
                                            //业务员
                                            if (feeType == 2)
                                            {
                                                rList = CostDetails.getCostOfStaffID(get_direction, sDate, stDate, Convert.ToInt32(result[i]), -1);
                                                dt = rList.Copy();
                                                dt.TableName = "y_" + i;
                                                ds.Tables.Add(dt);

                                                newData = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                                object[] obj = new object[newData.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                                for (int m = 0; m < ds.Tables.Count; m++)
                                                {
                                                    if (ds.Tables[m].Rows.Count > 0)
                                                    {
                                                        for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                                        {
                                                            ds.Tables[m].Rows[n].ItemArray.CopyTo(obj, 0); //将表的一行的值存放数组中
                                                            newData.Rows.Add(obj); //将数组的值添加到新表中
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        dt = newData.Copy();
                                        //客户
                                        if (feeType == 0)
                                        {
                                            dt.Columns.RemoveAt(0);
                                            dss.Tables.Add(dt);
                                            dss.Tables[0].Columns[0].ColumnName = "客户名称";
                                            dss.Tables[0].Columns[1].ColumnName = "发生金额";
                                        }
                                        //科目
                                        if (feeType == 1)
                                        {
                                            dt.Columns.RemoveAt(0);
                                            dss.Tables.Add(dt);
                                            dss.Tables[0].Columns[0].ColumnName = "科目名称";
                                            dss.Tables[0].Columns[1].ColumnName = "发生金额";
                                        }
                                        //业务员
                                        if (feeType == 2)
                                        {
                                            dss.Tables.Add(dt);
                                            dss.Tables[0].Columns[0].ColumnName = "业务名称";
                                            dss.Tables[0].Columns[1].ColumnName = "发生金额";
                                        }
                                        CreateExcel(dss.Tables[0], "费用统计_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
                                    }
                                }
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
            pagetitle = " 费用详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
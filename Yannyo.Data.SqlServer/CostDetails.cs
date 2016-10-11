using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.Common.Generic;
using System.Collections;

namespace Yannyo.Data.SqlServer
{
    
    public partial class DataProvider : IDataProvider
    {
        #region 费用统计_门店
        /// <summary>
        /// 获得科目详细
        /// </summary>
        /// <returns></returns>
        public DataTable getObjectsList()
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select FeesSubjectClassID,cParentID,cClassName from tbFeesSubjectClassInfo");
            return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得科目名称
        /// </summary>
        /// <returns></returns>
        public DataTable getObjectsListName(int sid)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select cClassName,cCode,cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID='" + sid + "'");
            DataTable dt= DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得区域详情
        /// </summary>
        /// <returns></returns>
        public DataTable getRegionList(int sid,string kid,DateTime bDate,DateTime eDate)
        {
            if (sid == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("select RegionID,rName from tbRegionInfo where RegionID in(select RegionID from tbStoresInfo where StoresID in");
                btr.Append("  (select cfi.toObjectID from tbCertificateDataInfo as cfi left join tbCertificateInfo as ci");
                btr.Append("  on cfi.CertificateID=ci.CertificateID where cdMoney !=0 and FeesSubjectID='" + kid + "' and ci.cState=0 and ci.cDateTime between '" + bDate + "' and '" + eDate + "')) ");

                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("select RegionID,rName from tbRegionInfo where RegionID in(select RegionID from tbStoresInfo where StoresID in");
                btr.Append("  (select cfi.toObjectID from tbCertificateDataInfo as cfi left join tbCertificateInfo as ci");
                btr.Append("  on cfi.CertificateID=ci.CertificateID where cdMoneyB !=0 and FeesSubjectID='" + kid + "' and ci.cState=0 and ci.cDateTime between '" + bDate + "' and '" + eDate + "')) ");

              
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得客户名称
        /// </summary>
        /// <param name="rID"></param>
        /// <returns></returns>
        public DataTable getStorsList(int sid,string rID,DateTime bDate,DateTime eDate)
        {
            if (sid == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select StoresID,sName,sType from tbStoresInfo where RegionID='" + rID + "' and ");
                btr.Append(" StoresID in (select ci.toObjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
                btr.Append("  on ci.CertificateID=cfi.CertificateID where cfi.cState=0 and ci.cdMoney!=0 and cfi.cDateTime ");
                btr.Append("  between '" + bDate + "' and '" + eDate + "')");

                //btr.Append(" select StoresID,sName,sType from tbStoresInfo where RegionID='" + rID + "' and StoresID in (select toObjectID from tbCertificateDataInfo where cdMoney !=0)");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select StoresID,sName,sType from tbStoresInfo where RegionID='" + rID + "' and ");
                btr.Append(" StoresID in (select ci.toObjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
                btr.Append("  on ci.CertificateID=cfi.CertificateID where cfi.cState=0 and ci.cdMoneyB!=0 and cfi.cDateTime ");
                btr.Append("  between '" + bDate + "' and '" + eDate + "')");

                //btr.Append(" select StoresID,sName,sType from tbStoresInfo where RegionID='" + rID + "' and StoresID in (select toObjectID from tbCertificateDataInfo where cdMoney !=0)");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得科目选择名称
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public DataTable getTreeName(string treeNode)
        { 
            StringBuilder btr = new StringBuilder();
            btr.Append(" select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID='"+treeNode+"'");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 费用统计：客户—科目
        /// </summary>
        /// <param name="storesId"></param>
        /// <param name="kType"></param>
        /// <param name="type"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getCostOfStorehouse(int storesId, string kType,int type, DateTime bDate, DateTime eDate)
        {
             SqlParameter[] parameter = { 
                          new SqlParameter("@inyStoresID",SqlDbType.Int), 
                          new SqlParameter("@chvKtype",SqlDbType.VarChar),
                          new SqlParameter("@inyType",SqlDbType.Int),
                          new SqlParameter("@dtmBdate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmEdate",SqlDbType.DateTime), 
                                       };
             parameter[0].Value = storesId;
             parameter[1].Value = kType;
             parameter[2].Value = type;
             parameter[3].Value = bDate;
             parameter[4].Value = eDate;

             return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "CostDetails", parameter).Tables[0];
        
        }
        /// <summary>
        /// 门店费用详细
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="kid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getCostOfStorehouseDetails(int selectID,int sid, string kid, DateTime bDate, DateTime eDate)
        {
            if (selectID == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select fi.cClassName,pp.cdName,pp.cdMoney,pp.cDateTime from (");
		        btr.Append("   select ci.cdName,ci.cdMoney,cfi.cDateTime,ci.FeesSubjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
                btr.Append(" on ci.CertificateID=cfi.CertificateID where cDateTime between '" + bDate + "' and '" + eDate + "' and");
                btr.Append(" ci.toObject=0 and ci.toObjectID='" + sid + "' and FeesSubjectID='" + kid + "' and cfi.cState=0 and ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)) as pp left join ");
                btr.Append(" tbFeesSubjectClassInfo as fi on pp.FeesSubjectID=fi.FeesSubjectClassID");

                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (selectID == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select fi.cClassName,pp.cdName,pp.cdMoneyB,pp.cDateTime from (");
                btr.Append("   select ci.cdName,ci.cdMoneyB,cfi.cDateTime,ci.FeesSubjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
                btr.Append(" on ci.CertificateID=cfi.CertificateID where cDateTime between '" + bDate + "' and '" + eDate + "' and");
                btr.Append(" ci.toObject=0 and ci.toObjectID='" + sid + "' and FeesSubjectID='" + kid + "' and cfi.cState=0 and ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)) as pp left join ");
                btr.Append(" tbFeesSubjectClassInfo as fi on pp.FeesSubjectID=fi.FeesSubjectClassID");

                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 循环找到科目子节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        public string getTreeChildrenCount(string kid)
        {
            string cid = kid;
            string chID = "";
            string ID = "";
            ArrayList al = new ArrayList();
            while (true)
            {
                //1. 调用方法，继续寻找子节点
                string dt = getFeesSubjectClassID(kid);
                chID += dt;
                if (dt == kid)
                {
                    ID = chID + cid + ",";
                    string[] dID = ID.Split(',');
                    for (int i = 0; i < dID.Length - 1; i++)
                    {
                        if (al.Contains(dID[i]) == false)
                        {
                            al.Add(dID[i]);
                        } 
                    }
                    return String.Join(",", (string[])al.ToArray(typeof(string))) + ",";

                }
                else
                {
                    kid = "";
                    kid = dt;
                }
            }
        }
        /// <summary>
        /// 返回科目集
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string getFeesSubjectClassID(string fid)
        {
            int m = fid.IndexOf(",");
            string dtm = "";
            if (m > 0)
            {
                string[] spid = fid.Split(',');
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
               
                for (int i = 0; i < spid.Length-1; i++)
                {
                    StringBuilder btr = new StringBuilder();
                    btr.Append("select FeesSubjectClassID from tbFeesSubjectClassInfo where cParentID='" + spid[i] + "'");
                    
                    dt = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        DataTable tt = dt.Copy();
                        tt.TableName = "f" + i;
                        ds.Tables.Add(tt);
                        
                    }
                    else
                    {
                        dtm += spid[i].ToString() + ",";
                    }
                }

                foreach (DataTable dtb in ds.Tables)
                {
                    if (dtb != null)
                    {
                        for (int j = 0; j < dtb.Rows.Count; j++)
                        {
                            dtm += dtb.Rows[j][0].ToString() + ",";
                        }
                    }

                }
                return dtm;
            }
            else
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("select FeesSubjectClassID from tbFeesSubjectClassInfo where cParentID='" + fid + "'");
                DataTable mm= DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
                for (int i = 0; i < mm.Rows.Count; i++)
                {
                    dtm += mm.Rows[i][0].ToString() + ",";
                }
                return dtm;
            }
        }
        #endregion
        #region  费用统计_科目
        /// <summary>
        /// 获得科目选择级得名称
        /// </summary>
        /// <param name="kid">科目ID</param>
        /// <returns></returns>
        public DataTable getClassName(string kid)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select FeesSubjectClassID,cClassName,cCode,cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID='" + kid + "'");

            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得科目的统计费用
        /// </summary>
        /// <param name="type">借方或贷方</param>
        /// <param name="kid">科目</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <returns></returns>
        public DataTable getClassCost(int type, string kid, DateTime bDate, DateTime eDate)
        {
            if (type == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select pp.FeesSubjectID,fi.cClassName,pp.cdMoney from (");
                btr.Append("  select ci.FeesSubjectID,isnull(sum(ci.cdMoney),0) as cdMoney from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
                btr.Append(" where ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)");
                btr.Append("  and ci.FeesSubjectID='" + kid + "' and cfi.cState=0 and cfi.cDateTime between '"+bDate+"' and '"+eDate+"'  group by ci.FeesSubjectID");
                btr.Append(" ) as pp left join tbFeesSubjectClassInfo as fi on pp.FeesSubjectID=fi.FeesSubjectClassID");
                return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];
            }
            if (type == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select pp.FeesSubjectID,fi.cClassName,pp.cdMoney from (");
                btr.Append("  select ci.FeesSubjectID,isnull(sum(ci.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
                btr.Append(" where ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)");
                btr.Append("  and ci.FeesSubjectID='" + kid + "' and cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "'  group by ci.FeesSubjectID");
                btr.Append(" ) as pp left join tbFeesSubjectClassInfo as fi on pp.FeesSubjectID=fi.FeesSubjectClassID");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 科目费用统计详细
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="kID"></param>
        /// <returns></returns>
        public DataTable getCostOfClassDetails(int sID, DateTime bDate, DateTime eDate, int kID)
        {
            if (sID == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select fi.cClassName,qq.cdName,qq.cdMoney,qq.sName,qq.cDateTime from (");
                btr.Append(" select pp.cdName,pp.FeesSubjectID,si.sName,pp.cdMoney,pp.cDateTime from (");
	            btr.Append("	select ci.FeesSubjectID,ci.cdMoney,ci.cdName,cfi.StaffID,cfi.cDateTime from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
	            btr.Append("	 where ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)");
                btr.Append("    and ci.FeesSubjectID='" + kID + "' and cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "') pp");
                btr.Append("    left join tbStaffInfo as si on pp.StaffID=si.StaffID) as qq left join tbFeesSubjectClassInfo as fi on qq.FeesSubjectID=fi.FeesSubjectClassID");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sID == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select fi.cClassName,qq.cdName,qq.cdMoneyB,qq.sName,qq.cDateTime from (");
                btr.Append(" select pp.cdName,pp.FeesSubjectID,si.sName,pp.cdMoneyB,pp.cDateTime from (");
                btr.Append("	select ci.FeesSubjectID,ci.cdMoneyB,ci.cdName,cfi.StaffID,cfi.cDateTime from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
                btr.Append("	 where ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2)");
                btr.Append("   and ci.FeesSubjectID='" + kID + "' and cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "') pp");
                btr.Append("    left join tbStaffInfo as si on pp.StaffID=si.StaffID) as qq left join tbFeesSubjectClassInfo as fi on qq.FeesSubjectID=fi.FeesSubjectClassID");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 费用统计_业务员
        /// <summary>
        /// 获得业务员名称
        /// </summary>
        /// <param name="sid">借方或者贷方</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <returns></returns>
        public DataTable getStaffName(int sid, DateTime bDate, DateTime eDate,int kID)
        {
            if (sid == 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select distinct(si.sName),si.StaffID from tbStaffInfo  as  si left join tbStaffStoresInfo as ssi on si.StaffID=ssi.StaffID");
                btr.Append(" where si.sType=1 and si.sState=0 and ssi.sType=0 and");
                btr.Append(" ssi.StoresID in (select ci.toObjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on");
                btr.Append(" ci.CertificateID=cfi.CertificateID where ci.cdMoney !=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and ci.FeesSubjectID='"+kID+"')");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select distinct(si.sName),si.StaffID from tbStaffInfo  as  si left join tbStaffStoresInfo as ssi on si.StaffID=ssi.StaffID");
                btr.Append(" where si.sType=1 and si.sState=0 and ssi.sType=0 and");
                btr.Append(" ssi.StoresID in (select ci.toObjectID from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on");
                btr.Append(" ci.CertificateID=cfi.CertificateID where ci.cdMoneyB !=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and ci.FeesSubjectID='" + kID + "')");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;    
            }
        }
        /// <summary>
        /// 获得业务员费用
        /// </summary>
        /// <param name="sid">借方或贷方</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <param name="kID">科目编号</param>
        /// <param name="staffID">业务员编号</param>
        /// <returns></returns>
        public DataTable getCostOfStaffID(int sid, DateTime bDate, DateTime eDate, int kID,int staffID)
        {
            if (sid == 0 && staffID>0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("select ci.toObject,isnull(sum(ci.cdMoney),0) as cdMoney from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
                btr.Append("  where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='" + kID + "'  and ci.toObjectID ");
                btr.Append("  in(select StoresID from tbStaffStoresInfo where StaffID='" + staffID + "' and sType=0) and ci.CertificateID ");
                btr.Append("  in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) group by ci.toObject");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1 && staffID > 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("select ci.toObject,isnull(sum(ci.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
                btr.Append("  where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='" + kID + "'  and ci.toObjectID ");
                btr.Append("  in(select StoresID from tbStaffStoresInfo where StaffID='" + staffID + "' and sType=0) and ci.CertificateID ");
                btr.Append("  in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) group by ci.toObject");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 0 && staffID < 0)
            {
               StringBuilder btr = new StringBuilder();
               btr.Append(" select sp.sName,isnull(qq.cdMoney,0) as cdMoney from (");
               btr.Append("  select si.StaffID,isnull(sum(pp.cdMoney),0) as cdMoney from(");
               btr.Append("  select ci.toObjectID,isnull(sum(ci.cdMoney),0) as cdMoney from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
               btr.Append(" where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='" + kID + "'  and ci.CertificateID ");
               btr.Append(" in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) group by ci.toObjectID) as pp");
               btr.Append(" left join tbStaffStoresInfo as si on pp.toObjectID=si.StoresID where si.sType=0 ");
               btr.Append(" and si.StaffID in(select StaffID from tbStaffInfo where sState=0 and sType=1) group by si.StaffID");
               btr.Append("  ) as qq left join tbStaffInfo as sp on qq.StaffID=sp.StaffID where sState=0 and sType=1");
               return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1 && staffID < 0)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append(" select sp.sName,isnull(qq.cdMoneyB,0) as cdMoneyB from (");
                btr.Append("  select si.StaffID,isnull(sum(pp.cdMoneyB),0) as cdMoneyB from(");
                btr.Append("  select ci.toObjectID,isnull(sum(ci.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID");
                btr.Append(" where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='" + kID + "'  and ci.CertificateID ");
                btr.Append(" in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) group by ci.toObjectID) as pp");
                btr.Append(" left join tbStaffStoresInfo as si on pp.toObjectID=si.StoresID where si.sType=0 ");
                btr.Append(" and si.StaffID in(select StaffID from tbStaffInfo where sState=0 and sType=1) group by si.StaffID");
                btr.Append("  ) as qq left join tbStaffInfo as sp on qq.StaffID=sp.StaffID where sState=0 and sType=1");
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得业务费用详细
        /// </summary>
        /// <param name="sid">借方或贷方</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <param name="staffID">业务编号</param>
        /// <param name="kID">科目选择</param>
        /// <returns></returns>
        public DataTable getCostOfStaffDetails(int sid, DateTime bDate, DateTime eDate, int staffID, string kID)
        {
            if (sid == 0)
            { 
                StringBuilder btr=new StringBuilder();
                btr.Append("  select isnull(pp.cdMoney,0) as cdMoney,pp.sName,fi.cClassName,pp.cdName,pp.cDateTime from (");
                btr.Append("  select si.sName,isnull(qq.cdMoney,0) as cdMoney,qq.cdName,qq.cDateTime,qq.FeesSubjectID from (");
                btr.Append("  select ci.FeesSubjectID,isnull(ci.cdMoney,0) as cdMoney,cfi.StaffID,cfi.cDateTime,ci.cdName from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
                btr.Append("  where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='"+kID+"' and ci.toObjectID ");
                btr.Append("  in(select StoresID from tbStaffStoresInfo where StaffID='"+staffID+"' and sType=0) and ci.CertificateID ");
                btr.Append("  in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) ) as qq");
                btr.Append("  left join tbStaffInfo as si on qq.StaffID=si.StaffID) as pp left join tbFeesSubjectClassInfo as fi");
                btr.Append("  on fi.FeesSubjectClassID=pp.FeesSubjectID");

                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            if (sid == 1)
            {
                StringBuilder btr = new StringBuilder();
                btr.Append("  select isnull(pp.cdMoneyB,0) as cdMoneyB,pp.sName,fi.cClassName,pp.cdName,pp.cDateTime from (");
                btr.Append("  select si.sName,isnull(qq.cdMoneyB,0) as cdMoneyB,qq.cdName,qq.cDateTime,qq.FeesSubjectID from (");
                btr.Append("  select ci.FeesSubjectID,isnull(ci.cdMoneyB,0) as cdMoneyB,cfi.StaffID,cfi.cDateTime,ci.cdName from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
                btr.Append("  where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and  ci.FeesSubjectID='" + kID + "' and ci.toObjectID ");
                btr.Append("  in(select StoresID from tbStaffStoresInfo where StaffID='" + staffID + "' and sType=0) and ci.CertificateID ");
                btr.Append("  in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) ) as qq");
                btr.Append("  left join tbStaffInfo as si on qq.StaffID=si.StaffID) as pp left join tbFeesSubjectClassInfo as fi");
                btr.Append("  on fi.FeesSubjectClassID=pp.FeesSubjectID");

                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 费用统计_赠品
        /// <summary>
        /// 获得门店赠品费用
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getGiftCost(int sID,DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@dtmBdate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmEdate",SqlDbType.DateTime), 
                                       };
            parameter[0].Value = bDate;
            parameter[1].Value = eDate;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "CostDetailsOfGifts", parameter).Tables[0];
        }
        /// <summary>
        /// 获得门店
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getGiftCost_storehouse(DateTime bDate, DateTime eDate)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("  select si.sName,qq.StoresID from (");
            btr.Append("  select distinct(oi.StoresID) from tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID");
            btr.Append("  where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oi.OrderID");
            btr.Append("  in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between '" + bDate + "' and '" + eDate + "')) as qq");
            btr.Append("  left join tbStoresInfo as si on qq.StoresID=si.StoresID");

            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得赠品费用明细
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="pid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getGiftCost_details(int sid, int pid, DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@inysID",SqlDbType.Int),
                          new SqlParameter("@inypID",SqlDbType.Int),
                          new SqlParameter("@dtmBdate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmEdate",SqlDbType.DateTime), 
                                       };
            parameter[0].Value = sid;
            parameter[1].Value = pid;
            parameter[2].Value = bDate;
            parameter[3].Value = eDate;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "CostOfGifts_Details", parameter).Tables[0];
        }
        #endregion
        #region  毛利统计
        /// <summary>
        /// 获得区域毛利
        /// </summary>
        /// <param name="moriType"></param>
        /// <param name="saleType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getMoriOfRegion(int moriType, int saleType, DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@inyMoriType",SqlDbType.Int),
                          new SqlParameter("@dtmbDate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmeDate",SqlDbType.DateTime), 
                          
                                       };
            parameter[0].Value = moriType;
            parameter[1].Value = bDate;
            parameter[2].Value = eDate;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "MoriCostDetails", parameter).Tables[0];
        }
        #endregion
        #region 发生额及余额统计
        /// <summary>
        /// 获取科目
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getFeeSubjectID(DateTime bDate,DateTime eDate)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select FeesSubjectClassID,cCode from tbFeesSubjectClassInfo where FeesSubjectClassID");
            btr.Append("  in( select cfi.FeesSubjectID from tbCertificateInfo as ci");  
            btr.Append("     right join tbCertificateDataInfo as cfi on ci.CertificateID=cfi.CertificateID ");
            btr.Append("       where ci.cState=0 ");
            btr.Append("         and cfi.CertificateID in(select CertificateID  from tbCertificateWorkingLogInfo ))");
            btr.Append("  or FeesSubjectClassID in(select FeesSubjectClassID from tbBankCapitalAccountInfo)   order by cCode asc");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }

        public DataTable getOccurrenceAndBalanceDetails(DateTime bDate, DateTime eDate,int feeID,int status)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@dtmbDate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmeDate",SqlDbType.DateTime), 
                          new SqlParameter("@FeesSubjectClassID",SqlDbType.Int),
                          new SqlParameter("@inyStatus",SqlDbType.Int),
                                       };
            parameter[0].Value = bDate;
            parameter[1].Value = eDate;
            parameter[2].Value = feeID;
            parameter[3].Value = status;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "OpeningBalance", parameter).Tables[0];
 
        }
        /// <summary>
        /// 获得发生额明细
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable get_Occurrence_Balance_Details(int objectID, DateTime bDate, DateTime eDate)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select convert(varchar,datepart(month,cfi.cDateTime))+'月'+convert(varchar,datepart(DAY,cfi.cDateTime))+'日' as cDateTime,cfi.cCode,ci.cdName,isnull(ci.cdMoney,0) as cdMoney,isnull(ci.cdMoneyB,0) as cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
            btr.Append("   on ci.CertificateID=cfi.CertificateID where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and ci.CertificateID ");
            btr.Append("   in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) and ci.FeesSubjectID='" + objectID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public int get_Occurrence_Balance_Details_Count(int objectID, DateTime bDate, DateTime eDate)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("  select cfi.cDateTime,cfi.cCode,ci.cdName,ci.cdMoney,ci.cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
            btr.Append("   on ci.CertificateID=cfi.CertificateID where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' and ci.CertificateID ");
            btr.Append("   in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) and ci.FeesSubjectID='" + objectID + "'");
            DataTable dt= DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 本月累计
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable get_Occurrence_Balance_addMonth(int objectID, DateTime bDate, DateTime eDate)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("   select ci.FeesSubjectID,isnull(sum(ci.cdMoney),0) as cdMoney,isnull(sum(ci.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi");
            btr.Append("    on ci.CertificateID=cfi.CertificateID where cfi.cState=0 and cfi.cDateTime between CONVERT(varchar,DATEPART(YEAR,'" + eDate + "'))+'-01'+'-01' and '" + eDate + "' and ci.CertificateID ");
            btr.Append("    in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) and ci.FeesSubjectID='"+objectID+"' group by ci.FeesSubjectID");
            return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];

        }
        /// <summary>
        /// 获得上年结转
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public DataTable getLastYearMoney(int objectID)
        { 
            StringBuilder btr = new StringBuilder();
            btr.Append("  select cAccountName,cAccountMoney,fi.cDirection from tbBankCapitalAccountInfo  as bi left join tbFeesSubjectClassInfo as fi");
		    btr.Append(" on bi.FeesSubjectClassID=fi.FeesSubjectClassID");
            btr.Append(" where bi.FeesSubjectClassID='" + objectID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 待摊费用明细账
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getMonthCost(int objectID, DateTime bDate, DateTime eDate,int oMonth,int sType,int status)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@inySubject",SqlDbType.Int), 
                          new SqlParameter("@btmBdate",SqlDbType.DateTime), 
                          new SqlParameter("@btmEdate",SqlDbType.DateTime), 
                          new SqlParameter("@inyMonth",SqlDbType.Int),
                          new SqlParameter("@inyStype",SqlDbType.Int),
                          new SqlParameter("@inyStatus",SqlDbType.Int),
                                       };
            parameter[0].Value = objectID;
            parameter[1].Value = bDate;
            parameter[2].Value = eDate;
            parameter[3].Value = oMonth;
            parameter[4].Value = sType;
            parameter[5].Value = status;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Occurrence_forehead_and_balance_do", parameter).Tables[0];
        }
        /// <summary>
        /// 获得科目名称及编码
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public DataTable getSubjectNameAndID(int objectID)
        { 
            StringBuilder btr = new StringBuilder();
            btr.Append("select cClassName,cCode from tbFeesSubjectClassInfo where FeesSubjectClassID='" + objectID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得月份
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable getMonthBySubjectAndDateTime(int objectID, DateTime bDate, DateTime eDate) 
        {
            //开始日期的第一天
            bDate = bDate.AddDays(-(bDate.Day) + 1);
            //结束日期最后一天
            DateTime ed = eDate.AddMonths(1);
            eDate = ed.AddDays(-(ed.Day) + 1);
            eDate = eDate.AddDays(-1);
            StringBuilder btr = new StringBuilder();
            btr.Append(" select distinct(convert(int,datepart(month,cfi.cDateTime)))  as oMonth");
            btr.Append(" from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
            btr.Append(" where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' ");
            btr.Append(" and ci.FeesSubjectID='" + objectID + "'");
		    btr.Append("  order by oMonth asc");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得最大月
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public string getMonthBySubjectAndDateTime_Max(int objectID, DateTime bDate, DateTime eDate)
        {
            //开始日期的第一天
            bDate = bDate.AddDays(-(bDate.Day) + 1);
            //结束日期最后一天
            DateTime ed = eDate.AddMonths(1);
            eDate = ed.AddDays(-(ed.Day) + 1);
            eDate = eDate.AddDays(-1);
            StringBuilder btr = new StringBuilder();
            btr.Append(" select max(distinct(convert(int,datepart(month,cfi.cDateTime))))  as oMonth");
            btr.Append(" from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID ");
            btr.Append(" where cfi.cState=0 and cfi.cDateTime between '" + bDate + "' and '" + eDate + "' ");
            btr.Append("  and ci.FeesSubjectID='" + objectID + "'");
            btr.Append("  order by oMonth asc");
            return DbHelper.ExecuteScalarToStr(CommandType.Text, btr.ToString());
        }
        #endregion
    }
}

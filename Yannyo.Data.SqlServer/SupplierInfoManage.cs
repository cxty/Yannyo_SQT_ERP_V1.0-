using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSupplierInfo(string sName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbSupplierInfo");
            strSql.Append(" where sName=@sName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,128)};
            parameters[0].Value = sName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSupplierInfoCode(string sCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbSupplierInfo");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50)};
            parameters[0].Value = sCode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSupplierInfo(SupplierInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbSupplierInfo(");
            strSql.Append("sName,sCode,sAddress,sTel,sLinkMan,sDoDay,sDoDayMoney,sAppendTime,SupplierClassID,sLicense)");
            strSql.Append(" values (");
            strSql.Append("@sName,@sCode,@sAddress,@sTel,@sLinkMan,@sDoDay,@sDoDayMoney,@sAppendTime,@SupplierClassID,@sLicense)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,128),
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
					new SqlParameter("@sAddress", SqlDbType.VarChar,256),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sLinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@sDoDay", SqlDbType.Int,4),
					new SqlParameter("@sDoDayMoney", SqlDbType.Money,8),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@SupplierClassID", SqlDbType.Int,4),
                                        new SqlParameter("@sLicense", SqlDbType.VarChar,50),};
            parameters[0].Value = model.sName;
            parameters[1].Value = model.sCode;
            parameters[2].Value = model.sAddress;
            parameters[3].Value = model.sTel;
            parameters[4].Value = model.sLinkMan;
            parameters[5].Value = model.sDoDay;
            parameters[6].Value = model.sDoDayMoney;
            parameters[7].Value = model.sAppendTime;
            parameters[8].Value = model.SupplierClassID;
            parameters[9].Value = model.sLicense;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSupplierInfo(SupplierInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbSupplierInfo set ");
            strSql.Append("sName=@sName,");
            strSql.Append("sCode=@sCode,");
            strSql.Append("sAddress=@sAddress,");
            strSql.Append("sTel=@sTel,");
            strSql.Append("sLinkMan=@sLinkMan,");
            strSql.Append("sDoDay=@sDoDay,");
            strSql.Append("sDoDayMoney=@sDoDayMoney,");
            strSql.Append("sAppendTime=@sAppendTime,");
            strSql.Append("SupplierClassID=@SupplierClassID,");
            strSql.Append("sLicense=@sLicense");
            strSql.Append(" where SupplierID=@SupplierID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.VarChar,128),
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
					new SqlParameter("@sAddress", SqlDbType.VarChar,256),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sLinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@sDoDay", SqlDbType.Int,4),
					new SqlParameter("@sDoDayMoney", SqlDbType.Money,8),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@SupplierClassID", SqlDbType.Int,4),
                                        new SqlParameter("@sLicense", SqlDbType.VarChar,50),};
            parameters[0].Value = model.SupplierID;
            parameters[1].Value = model.sName;
            parameters[2].Value = model.sCode;
            parameters[3].Value = model.sAddress;
            parameters[4].Value = model.sTel;
            parameters[5].Value = model.sLinkMan;
            parameters[6].Value = model.sDoDay;
            parameters[7].Value = model.sDoDayMoney;
            parameters[8].Value = model.sAppendTime;
            parameters[9].Value = model.SupplierClassID;
            parameters[10].Value = model.sLicense;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSupplierInfo(int SupplierID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSupplierInfo ");
            strSql.Append(" where SupplierID=@SupplierID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4)};
            parameters[0].Value = SupplierID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSupplierInfo(string SupplierID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSupplierInfo ");
            strSql.Append(" where SupplierID in(" + SupplierID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierInfo GetSupplierInfoModel(int SupplierID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SupplierID,sName,sCode,sAddress,sTel,sLinkMan,sDoDay,sDoDayMoney,sAppendTime,SupplierClassID,sLicense,(select tbSupplierClassInfo.sClassName from tbSupplierClassInfo where tbSupplierClassInfo.SupplierClassID=tbSupplierInfo.SupplierClassID) as SupplierClassName from tbSupplierInfo ");
            strSql.Append(" where SupplierID=@SupplierID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4)};
            parameters[0].Value = SupplierID;

            SupplierInfo model = new SupplierInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierClassID"].ToString() != "")
                {
                    model.SupplierClassID = int.Parse(ds.Tables[0].Rows[0]["SupplierClassID"].ToString());
                }
                model.SupplierClassName = ds.Tables[0].Rows[0]["SupplierClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sLinkMan = ds.Tables[0].Rows[0]["sLinkMan"].ToString();
                model.sLicense = ds.Tables[0].Rows[0]["sLicense"].ToString();
                if (ds.Tables[0].Rows[0]["sDoDay"].ToString() != "")
                {
                    model.sDoDay = int.Parse(ds.Tables[0].Rows[0]["sDoDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDoDayMoney"].ToString() != "")
                {
                    model.sDoDayMoney = decimal.Parse(ds.Tables[0].Rows[0]["sDoDayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierInfo GetSupplierInfoModelByName(string sName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SupplierID,sName,sCode,sAddress,sTel,sLinkMan,sDoDay,sDoDayMoney,sAppendTime,SupplierClassID,sLicense,(select tbSupplierClassInfo.sClassName from tbSupplierClassInfo where tbSupplierClassInfo.SupplierClassID=tbSupplierInfo.SupplierClassID) as SupplierClassName from tbSupplierInfo ");
            strSql.Append(" where sName=@sName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,128)};
            parameters[0].Value = sName;

            SupplierInfo model = new SupplierInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierClassID"].ToString() != "")
                {
                    model.SupplierClassID = int.Parse(ds.Tables[0].Rows[0]["SupplierClassID"].ToString());
                }
                model.SupplierClassName = ds.Tables[0].Rows[0]["SupplierClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sLinkMan = ds.Tables[0].Rows[0]["sLinkMan"].ToString();
                model.sLicense = ds.Tables[0].Rows[0]["sLicense"].ToString();
                if (ds.Tables[0].Rows[0]["sDoDay"].ToString() != "")
                {
                    model.sDoDay = int.Parse(ds.Tables[0].Rows[0]["sDoDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDoDayMoney"].ToString() != "")
                {
                    model.sDoDayMoney = decimal.Parse(ds.Tables[0].Rows[0]["sDoDayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierInfo GetSupplierInfoModelByCode(string sCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SupplierID,sName,sCode,sAddress,sTel,sLinkMan,sDoDay,sDoDayMoney,sAppendTime,SupplierClassID,sLicense,(select tbSupplierClassInfo.sClassName from tbSupplierClassInfo where tbSupplierClassInfo.SupplierClassID=tbSupplierInfo.SupplierClassID) as SupplierClassName from tbSupplierInfo ");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50)};
            parameters[0].Value = sCode;

            SupplierInfo model = new SupplierInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierClassID"].ToString() != "")
                {
                    model.SupplierClassID = int.Parse(ds.Tables[0].Rows[0]["SupplierClassID"].ToString());
                }
                model.SupplierClassName = ds.Tables[0].Rows[0]["SupplierClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sLinkMan = ds.Tables[0].Rows[0]["sLinkMan"].ToString();
                model.sLicense = ds.Tables[0].Rows[0]["sLicense"].ToString();
                if (ds.Tables[0].Rows[0]["sDoDay"].ToString() != "")
                {
                    model.sDoDay = int.Parse(ds.Tables[0].Rows[0]["sDoDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDoDayMoney"].ToString() != "")
                {
                    model.sDoDayMoney = decimal.Parse(ds.Tables[0].Rows[0]["sDoDayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetSupplierInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierID,sName,sCode,sAddress,sTel,sLinkMan,sDoDay,sDoDayMoney,sAppendTime,SupplierClassID,sLicense,(select tbSupplierClassInfo.sClassName from tbSupplierClassInfo where tbSupplierClassInfo.SupplierClassID=tbSupplierInfo.SupplierClassID) as SupplierClassName ");
            strSql.Append(" FROM tbSupplierInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetSupplierInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbSupplierInfo";
            parameters[1].Value = "SupplierID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select tbSupplierClassInfo.sClassName from tbSupplierClassInfo where tbSupplierClassInfo.SupplierClassID=tbSupplierInfo.SupplierClassID) as SupplierClassName ";
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
    }
}

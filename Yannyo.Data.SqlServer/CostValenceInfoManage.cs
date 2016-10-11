﻿using System;
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
        public bool ExistsCostValenceInfo(int ProductsID, DateTime cDateTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCostValenceInfo");
            strSql.Append(" where ProductsID=@ProductsID and cDateTime=@cDateTime");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
                    new SqlParameter("@cDateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = ProductsID;
            parameters[1].Value = cDateTime;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCostValenceInfo(CostValenceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbCostValenceInfo(");
            strSql.Append("ProductsID,cPrice,cDateTime,cAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@ProductsID,@cPrice,@cDateTime,@cAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@cPrice", SqlDbType.Money,8),
					new SqlParameter("@cDateTime", SqlDbType.DateTime),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.cPrice;
            parameters[2].Value = model.cDateTime;
            parameters[3].Value = model.cAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateCostValenceInfo(CostValenceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCostValenceInfo set ");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("cPrice=@cPrice,");
            strSql.Append("cDateTime=@cDateTime,");
            strSql.Append("cAppendTime=@cAppendTime");
            strSql.Append(" where CostVelenceID=@CostVelenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CostVelenceID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@cPrice", SqlDbType.Money,8),
					new SqlParameter("@cDateTime", SqlDbType.DateTime),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CostVelenceID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.cPrice;
            parameters[3].Value = model.cDateTime;
            parameters[4].Value = model.cAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteCostValenceInfo(int CostVelenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCostValenceInfo ");
            strSql.Append(" where CostVelenceID=@CostVelenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CostVelenceID", SqlDbType.Int,4)};
            parameters[0].Value = CostVelenceID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteCostValenceInfo(string CostVelenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCostValenceInfo ");
            strSql.Append(" where CostVelenceID in(" + CostVelenceID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CostValenceInfo GetCostValenceInfoModel(int CostVelenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CostVelenceID,ProductsID,cPrice,cDateTime,cAppendTime,(select pName from tbProductsInfo where ProductsID=tbCostValenceInfo.ProductsID) as ProductsName from tbCostValenceInfo ");
            strSql.Append(" where CostVelenceID=@CostVelenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CostVelenceID", SqlDbType.Int,4)};
            parameters[0].Value = CostVelenceID;

            CostValenceInfo model = new CostValenceInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CostVelenceID"].ToString() != "")
                {
                    model.CostVelenceID = int.Parse(ds.Tables[0].Rows[0]["CostVelenceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cPrice"].ToString() != "")
                {
                    model.cPrice = decimal.Parse(ds.Tables[0].Rows[0]["cPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cDateTime"].ToString() != "")
                {
                    model.cDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["cDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
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
        public DataSet GetCostValenceInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CostVelenceID,ProductsID,cPrice,cDateTime,cAppendTime,(select pName from tbProductsInfo where ProductsID=tbCostValenceInfo.ProductsID) as ProductsName ");
            strSql.Append(" FROM tbCostValenceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetCostValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbCostValenceInfo";
            parameters[1].Value = "CostVelenceID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
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

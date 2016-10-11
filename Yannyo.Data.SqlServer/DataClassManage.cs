using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using System.Collections;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  CustomersClass
        /// <summary>
        /// 获得客户上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getCustomersClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select CustomersClassID,cParentID,cClassName,cOrder,cAppendTime,");
            strSql.Append(" case when cParentID='" + ParentID + "' then ");
            strSql.Append(" (select cClassName from tbCustomersClassInfo where CustomersClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbCustomersClassInfo where cParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得客户分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetCustomersDetails(int CustomersClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CustomersClassID,cParentID,cClassName,cOrder,cAppendTime from tbCustomersClassInfo ");
            if (CustomersClassID > -1)
            {
                strSql.Append(" where  cParentID= '" + CustomersClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsCustomersClassInfo(string cClassName, int cParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCustomersClassInfo");
            strSql.Append(" where cClassName=@cClassName and cParentID=@cParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@cParentID", SqlDbType.Int,4)};
            parameters[0].Value = cClassName;
            parameters[1].Value = cParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsCustomersClassChild(int CustomersClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCustomersClassInfo");
            strSql.Append(" where cParentID=@CustomersClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CustomersClassID", SqlDbType.Int,4)};
            parameters[0].Value = CustomersClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCustomersClassInfo(CustomersClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbCustomersClassInfo(");
            strSql.Append("cParentID,cClassName,cOrder,cAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@cParentID,@cClassName,@cOrder,@cAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cParentID", SqlDbType.Int,4),
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
					new SqlParameter("@cOrder", SqlDbType.Int,4),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.cParentID;
            parameters[1].Value = model.cClassName;
            parameters[2].Value = model.cOrder;
            parameters[3].Value = model.cAppendTime;

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
        public int UpdateCustomersClassInfo(CustomersClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCustomersClassInfo set ");
            strSql.Append("cParentID=@cParentID,");
            strSql.Append("cClassName=@cClassName,");
            strSql.Append("cOrder=@cOrder,");
            strSql.Append("cAppendTime=@cAppendTime");
            strSql.Append(" where CustomersClassID=@CustomersClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomersClassID", SqlDbType.Int,4),
					new SqlParameter("@cParentID", SqlDbType.Int,4),
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
					new SqlParameter("@cOrder", SqlDbType.Int,4),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CustomersClassID;
            parameters[1].Value = model.cParentID;
            parameters[2].Value = model.cClassName;
            parameters[3].Value = model.cOrder;
            parameters[4].Value = model.cAppendTime;

           return  DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteCustomersClassInfo(int CustomersClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCustomersClassInfo ");
            strSql.Append(" where CustomersClassID=@CustomersClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomersClassID", SqlDbType.Int,4)};
            parameters[0].Value = CustomersClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CustomersClassInfo GetCustomersClassInfoModel(int CustomersClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CustomersClassID,cParentID,cClassName,cOrder,cAppendTime from tbCustomersClassInfo ");
            strSql.Append(" where CustomersClassID=@CustomersClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomersClassID", SqlDbType.Int,4)};
            parameters[0].Value = CustomersClassID;

            CustomersClassInfo model = new CustomersClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CustomersClassID"].ToString() != "")
                {
                    model.CustomersClassID = int.Parse(ds.Tables[0].Rows[0]["CustomersClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cParentID"].ToString() != "")
                {
                    model.cParentID = int.Parse(ds.Tables[0].Rows[0]["cParentID"].ToString());
                }
                model.cClassName = ds.Tables[0].Rows[0]["cClassName"].ToString();
                if (ds.Tables[0].Rows[0]["cOrder"].ToString() != "")
                {
                    model.cOrder = int.Parse(ds.Tables[0].Rows[0]["cOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
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
        public DataSet GetCustomersClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CustomersClassID,cParentID,cClassName,cOrder,cAppendTime ");
            strSql.Append(" FROM tbCustomersClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCustomersClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CustomersClassID,cParentID,cClassName,cOrder,cAppendTime ");
            strSql.Append(" FROM tbCustomersClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        #endregion
        #region DepartmentsClass
        /// <summary>
        /// 获得部门上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getDepartmentClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select DepartmentsClassID,dParentID,dClassName,dOrder,dAppendTime,");
            strSql.Append(" case when dParentID='" + ParentID + "' then ");
            strSql.Append(" (select dClassName from tbDepartmentsClassInfo where DepartmentsClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbDepartmentsClassInfo where dParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsDepartmentsClassInfo(string dClassName, int dParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbDepartmentsClassInfo");
            strSql.Append(" where dClassName=@dClassName and dParentID=@dParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@dClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@dParentID", SqlDbType.Int,4)};
            parameters[0].Value = dClassName;
            parameters[1].Value = dParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsDepartmentsClassChild(int DepartmentsClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbDepartmentsClassInfo");
            strSql.Append(" where dParentID=@DepartmentsClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4)};
            parameters[0].Value = DepartmentsClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddDepartmentsClassInfo(DepartmentsClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbDepartmentsClassInfo(");
            strSql.Append("dParentID,dClassName,dOrder,dAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@dParentID,@dClassName,@dOrder,@dAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@dParentID", SqlDbType.Int,4),
					new SqlParameter("@dClassName", SqlDbType.VarChar,50),
					new SqlParameter("@dOrder", SqlDbType.Int,4),
					new SqlParameter("@dAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.dParentID;
            parameters[1].Value = model.dClassName;
            parameters[2].Value = model.dOrder;
            parameters[3].Value = model.dAppendTime;

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
        public int UpdateDepartmentsClassInfo(DepartmentsClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbDepartmentsClassInfo set ");
            strSql.Append("dParentID=@dParentID,");
            strSql.Append("dClassName=@dClassName,");
            strSql.Append("dOrder=@dOrder,");
            strSql.Append("dAppendTime=@dAppendTime");
            strSql.Append(" where DepartmentsClassID=@DepartmentsClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4),
					new SqlParameter("@dParentID", SqlDbType.Int,4),
					new SqlParameter("@dClassName", SqlDbType.VarChar,50),
					new SqlParameter("@dOrder", SqlDbType.Int,4),
					new SqlParameter("@dAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.DepartmentsClassID;
            parameters[1].Value = model.dParentID;
            parameters[2].Value = model.dClassName;
            parameters[3].Value = model.dOrder;
            parameters[4].Value = model.dAppendTime;

           return  DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteDepartmentsClassInfo(int DepartmentsClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbDepartmentsClassInfo ");
            strSql.Append(" where DepartmentsClassID=@DepartmentsClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4)};
            parameters[0].Value = DepartmentsClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DepartmentsClassInfo GetDepartmentsClassInfoModel(int DepartmentsClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DepartmentsClassID,dParentID,dClassName,dOrder,dAppendTime from tbDepartmentsClassInfo ");
            strSql.Append(" where DepartmentsClassID=@DepartmentsClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4)};
            parameters[0].Value = DepartmentsClassID;

            DepartmentsClassInfo model = new DepartmentsClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString() != "")
                {
                    model.DepartmentsClassID = int.Parse(ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dParentID"].ToString() != "")
                {
                    model.dParentID = int.Parse(ds.Tables[0].Rows[0]["dParentID"].ToString());
                }
                model.dClassName = ds.Tables[0].Rows[0]["dClassName"].ToString();
                if (ds.Tables[0].Rows[0]["dOrder"].ToString() != "")
                {
                    model.dOrder = int.Parse(ds.Tables[0].Rows[0]["dOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dAppendTime"].ToString() != "")
                {
                    model.dAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAppendTime"].ToString());
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
        public DataSet GetDepartmentsClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DepartmentsClassID,dParentID,dClassName,dOrder,dAppendTime ");
            strSql.Append(" FROM tbDepartmentsClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得部门分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetDepartmentClassDetails(int DepartClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DepartmentsClassID,dParentID,dClassName,dOrder,dAppendTime from tbDepartmentsClassInfo ");
            if (DepartClassID > -1)
            {
                strSql.Append(" where dParentID= '" + DepartClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetDepartmentsClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" DepartmentsClassID,dParentID,dClassName,dOrder,dAppendTime ");
            strSql.Append(" FROM tbDepartmentsClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        #endregion
        #region PriceClass
        /// <summary>
        /// 获得价格上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getPriceClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select PriceClassID,pParentID,pClassName,pOrder,pAppendTime,");
            strSql.Append(" case when pParentID='" + ParentID + "' then ");
            strSql.Append(" (select pClassName from tbPriceClassInfo where PriceClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbPriceClassInfo where pParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得价格分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetPriceDetails(int PriceClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PriceClassID,pParentID,pClassName,pOrder,pAppendTime from tbPriceClassInfo ");
            if (PriceClassID > -1)
            {
                strSql.Append(" where  pParentID= '" + PriceClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsPriceClassInfo(string pClassName, int pParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPriceClassInfo");
            strSql.Append(" where pClassName=@pClassName and pParentID=@pParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@pParentID", SqlDbType.Int,4)};
            parameters[0].Value = pClassName;
            parameters[1].Value = pParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsPriceClassChild(int PriceClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPriceClassInfo");
            strSql.Append(" where pParentID=@PriceClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@PriceClassID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddPriceClassInfo(PriceClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPriceClassInfo(");
            strSql.Append("pParentID,pClassName,pOrder,pAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@pParentID,@pClassName,@pOrder,@pAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pParentID", SqlDbType.Int,4),
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
					new SqlParameter("@pOrder", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.pParentID;
            parameters[1].Value = model.pClassName;
            parameters[2].Value = model.pOrder;
            parameters[3].Value = model.pAppendTime;

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
        public int UpdatePriceClassInfo(PriceClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPriceClassInfo set ");
            strSql.Append("pParentID=@pParentID,");
            strSql.Append("pClassName=@pClassName,");
            strSql.Append("pOrder=@pOrder,");
            strSql.Append("pAppendTime=@pAppendTime");
            strSql.Append(" where PriceClassID=@PriceClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4),
					new SqlParameter("@pParentID", SqlDbType.Int,4),
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
					new SqlParameter("@pOrder", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PriceClassID;
            parameters[1].Value = model.pParentID;
            parameters[2].Value = model.pClassName;
            parameters[3].Value = model.pOrder;
            parameters[4].Value = model.pAppendTime;

            return  DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeletePriceClassInfo(int PriceClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPriceClassInfo ");
            strSql.Append(" where PriceClassID=@PriceClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PriceClassInfo GetPriceClassInfoModel(int PriceClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PriceClassID,pParentID,pClassName,pOrder,pAppendTime from tbPriceClassInfo ");
            strSql.Append(" where PriceClassID=@PriceClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassID;

            PriceClassInfo model = new PriceClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pParentID"].ToString() != "")
                {
                    model.pParentID = int.Parse(ds.Tables[0].Rows[0]["pParentID"].ToString());
                }
                model.pClassName = ds.Tables[0].Rows[0]["pClassName"].ToString();
                if (ds.Tables[0].Rows[0]["pOrder"].ToString() != "")
                {
                    model.pOrder = int.Parse(ds.Tables[0].Rows[0]["pOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public PriceClassInfo GetPriceClassInfoModel(string pClassName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PriceClassID,pParentID,pClassName,pOrder,pAppendTime from tbPriceClassInfo ");
            strSql.Append(" where pClassName=@pClassName ");
            SqlParameter[] parameters = {
					new SqlParameter("@pClassName", SqlDbType.VarChar,50)};
            parameters[0].Value = pClassName;

            PriceClassInfo model = new PriceClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pParentID"].ToString() != "")
                {
                    model.pParentID = int.Parse(ds.Tables[0].Rows[0]["pParentID"].ToString());
                }
                model.pClassName = ds.Tables[0].Rows[0]["pClassName"].ToString();
                if (ds.Tables[0].Rows[0]["pOrder"].ToString() != "")
                {
                    model.pOrder = int.Parse(ds.Tables[0].Rows[0]["pOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetPriceClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PriceClassID,pParentID,pClassName,pOrder,pAppendTime ");
            strSql.Append(" FROM tbPriceClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetPriceClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PriceClassID,pParentID,pClassName,pOrder,pAppendTime ");
            strSql.Append(" FROM tbPriceClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        #endregion
        #region ProductClass
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsProductClassInfo(string pClassName, int pParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbProductClassInfo");
            strSql.Append(" where pClassName=@pClassName and pParentID=@pParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@pParentID", SqlDbType.Int,4)};
            parameters[0].Value = pClassName;
            parameters[1].Value = pParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsProductClassChild(int ProductClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from tbProductClassInfo  as p join tbProductsInfo  as pf ");
            strSql.Append(" on p.ProductClassID=pf.ProductClassID where p.pParentID=@ProductClassID or pf.ProductClassID=@ProductClassID");
            //strSql.Append("select count(1) from tbProductClassInfo");
            //strSql.Append(" where pParentID=@ProductClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@ProductClassID", SqlDbType.Int,4)};
            parameters[0].Value = ProductClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductClassInfo(ProductClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbProductClassInfo(");
            strSql.Append("pParentID,pClassName,pOrder,pAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@pParentID,@pClassName,@pOrder,@pAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pParentID", SqlDbType.Int,4),
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
					new SqlParameter("@pOrder", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.pParentID;
            parameters[1].Value = model.pClassName;
            parameters[2].Value = model.pOrder;
            parameters[3].Value = model.pAppendTime;

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
        public int UpdateProductClassInfo(ProductClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbProductClassInfo set ");
            strSql.Append("pParentID=@pParentID,");
            strSql.Append("pClassName=@pClassName,");
            strSql.Append("pOrder=@pOrder,");
            strSql.Append("pAppendTime=@pAppendTime");
            strSql.Append(" where ProductClassID=@ProductClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductClassID", SqlDbType.Int,4),
					new SqlParameter("@pParentID", SqlDbType.Int,4),
					new SqlParameter("@pClassName", SqlDbType.VarChar,50),
					new SqlParameter("@pOrder", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductClassID;
            parameters[1].Value = model.pParentID;
            parameters[2].Value = model.pClassName;
            parameters[3].Value = model.pOrder;
            parameters[4].Value = model.pAppendTime;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteProductClassInfo(int ProductClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductClassInfo ");
            strSql.Append(" where ProductClassID=@ProductClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductClassID", SqlDbType.Int,4)};
            parameters[0].Value = ProductClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得产品分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetProductClassDetails(int ProductClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductClassID,pParentID,pClassName,pOrder,pAppendTime from tbProductClassInfo ");
            if (ProductClassID > -1)
            {
                strSql.Append(" where  pParentID= '" + ProductClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得产品上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getProductsClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select ProductClassID,pParentID,pClassName,pOrder,pAppendTime,");
            strSql.Append(" case when pParentID='" + ParentID + "' then ");
            strSql.Append(" (select pClassName from tbProductClassInfo where ProductClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbProductClassInfo where pParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetProductClassInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbProductClassInfo";
            parameters[1].Value = "ProductClassID";
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductClassInfo GetProductClassInfoModel(int ProductClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductClassID,pParentID,pClassName,pOrder,pAppendTime from tbProductClassInfo ");
            strSql.Append(" where ProductClassID=@ProductClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductClassID", SqlDbType.Int,4)};
            parameters[0].Value = ProductClassID;

            ProductClassInfo model = new ProductClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pParentID"].ToString() != "")
                {
                    model.pParentID = int.Parse(ds.Tables[0].Rows[0]["pParentID"].ToString());
                }
                model.pClassName = ds.Tables[0].Rows[0]["pClassName"].ToString();
                if (ds.Tables[0].Rows[0]["pOrder"].ToString() != "")
                {
                    model.pOrder = int.Parse(ds.Tables[0].Rows[0]["pOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public ProductClassInfo GetProductClassInfoModel(string pClassName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductClassID,pParentID,pClassName,pOrder,pAppendTime from tbProductClassInfo ");
            strSql.Append(" where pClassName=@pClassName ");
            SqlParameter[] parameters = {
					new SqlParameter("@pClassName", SqlDbType.VarChar,50)};
            parameters[0].Value = pClassName.Trim();

            ProductClassInfo model = new ProductClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pParentID"].ToString() != "")
                {
                    model.pParentID = int.Parse(ds.Tables[0].Rows[0]["pParentID"].ToString());
                }
                model.pClassName = ds.Tables[0].Rows[0]["pClassName"].ToString();
                if (ds.Tables[0].Rows[0]["pOrder"].ToString() != "")
                {
                    model.pOrder = int.Parse(ds.Tables[0].Rows[0]["pOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetProductClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductClassID,pParentID,pClassName,pOrder,pAppendTime ");
            strSql.Append(" FROM tbProductClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetProductClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProductClassID,pParentID,pClassName,pOrder,pAppendTime ");
            strSql.Append(" FROM tbProductClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        #endregion
        #region SupplierClass
        /// <summary>
        /// 获得供应商上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getSupplierClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select SupplierClassID,sParentID,sClassName,sOrder,sAppendTime,");
            strSql.Append(" case when sParentID='" + ParentID + "' then ");
            strSql.Append(" (select sClassName from tbSupplierClassInfo where SupplierClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbSupplierClassInfo where sParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得供应商分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetSupplierClassDetails(int SupplierClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierClassID,sParentID,sClassName,sOrder,sAppendTime from tbSupplierClassInfo ");
            if (SupplierClassID > -1)
            {
                strSql.Append(" where sParentID= '" + SupplierClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSupplierClassInfo(string sClassName, int sParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbSupplierClassInfo");
            strSql.Append(" where sClassName=@sClassName and sParentID=@sParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@sClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@sParentID", SqlDbType.Int,50)};
            parameters[0].Value = sClassName;
            parameters[1].Value = sParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsSupplierClassChild(int SupplierClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbSupplierClassInfo");
            strSql.Append(" where sParentID=@SupplierClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@SupplierClassID", SqlDbType.Int,4)};
            parameters[0].Value = SupplierClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSupplierClassInfo(SupplierClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbSupplierClassInfo(");
            strSql.Append("sParentID,sClassName,sOrder,sAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@sParentID,@sClassName,@sOrder,@sAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sParentID", SqlDbType.Int,4),
					new SqlParameter("@sClassName", SqlDbType.VarChar,50),
					new SqlParameter("@sOrder", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.sParentID;
            parameters[1].Value = model.sClassName;
            parameters[2].Value = model.sOrder;
            parameters[3].Value = model.sAppendTime;

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
        public int UpdateSupplierClassInfo(SupplierClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbSupplierClassInfo set ");
            strSql.Append("sParentID=@sParentID,");
            strSql.Append("sClassName=@sClassName,");
            strSql.Append("sOrder=@sOrder,");
            strSql.Append("sAppendTime=@sAppendTime");
            strSql.Append(" where SupplierClassID=@SupplierClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierClassID", SqlDbType.Int,4),
					new SqlParameter("@sParentID", SqlDbType.Int,4),
					new SqlParameter("@sClassName", SqlDbType.VarChar,50),
					new SqlParameter("@sOrder", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.SupplierClassID;
            parameters[1].Value = model.sParentID;
            parameters[2].Value = model.sClassName;
            parameters[3].Value = model.sOrder;
            parameters[4].Value = model.sAppendTime;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteSupplierClassInfo(int SupplierClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSupplierClassInfo ");
            strSql.Append(" where SupplierClassID=@SupplierClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierClassID", SqlDbType.Int,4)};
            parameters[0].Value = SupplierClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierClassInfo GetSupplierClassInfoModel(int SupplierClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SupplierClassID,sParentID,sClassName,sOrder,sAppendTime from tbSupplierClassInfo ");
            strSql.Append(" where SupplierClassID=@SupplierClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierClassID", SqlDbType.Int,4)};
            parameters[0].Value = SupplierClassID;

            SupplierClassInfo model = new SupplierClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SupplierClassID"].ToString() != "")
                {
                    model.SupplierClassID = int.Parse(ds.Tables[0].Rows[0]["SupplierClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sParentID"].ToString() != "")
                {
                    model.sParentID = int.Parse(ds.Tables[0].Rows[0]["sParentID"].ToString());
                }
                model.sClassName = ds.Tables[0].Rows[0]["sClassName"].ToString();
                if (ds.Tables[0].Rows[0]["sOrder"].ToString() != "")
                {
                    model.sOrder = int.Parse(ds.Tables[0].Rows[0]["sOrder"].ToString());
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
        public DataSet GetSupplierClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierClassID,sParentID,sClassName,sOrder,sAppendTime ");
            strSql.Append(" FROM tbSupplierClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetSupplierClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SupplierClassID,sParentID,sClassName,sOrder,sAppendTime ");
            strSql.Append(" FROM tbSupplierClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        #endregion
        #region  FeesSubjectClass
        /// <summary>
        /// 更新凭证信息到某个科目下
        /// </summary>
        /// <param name="certificateID">凭证系统编号</param>
        /// <param name="feesubjectID">科目编号</param>
        /// <returns></returns>
        public int updateCertificateToFeessubjects(string certificateID, int feesubjectID, int lastFeeID)
        {
            StringBuilder strSql = new StringBuilder();

            certificateID = certificateID.Substring(0, certificateID.Length - 1);
            strSql.Append("update tbCertificateDataInfo set FeesSubjectID='" + feesubjectID + "' where CertificateDataID in(" + certificateID + ") and FeesSubjectID='" + lastFeeID + "'");
            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 返回科目下凭证信息
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public DataTable getCertificateDate(int fid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select *,(select sName from tbStaffInfo where StaffID=cfi.StaffID) as sName ");
            strSql.Append(" from tbCertificateDataInfo as ci  left join tbCertificateInfo as cfi");
            strSql.Append(" on ci.CertificateID=cfi.CertificateID where FeesSubjectID='" + fid + "' order by cfi.cDateTime desc,cfi.cNumber asc");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 返回科目是否启用状态（只要有凭证用到该科目即为启用）
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public int getFeeState(int fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbCertificateDataInfo where FeesSubjectID='" + fid + "'");
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获得科目上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getFeesSubjectClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType,");
            strSql.Append(" case when cParentID='" + ParentID + "' then ");
            strSql.Append(" (select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbFeesSubjectClassInfo where cParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得科目分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetFeesSubjectDetails(int CustomersClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType from tbFeesSubjectClassInfo ");
            if (CustomersClassID > -1)
            {
                strSql.Append(" where  cParentID= '" + CustomersClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsFeesSubjectClassInfo(string cClassName, int cParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFeesSubjectClassInfo");
            strSql.Append(" where cClassName=@cClassName and cParentID=@cParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
                                        new SqlParameter("@cParentID", SqlDbType.Int,4)};
            parameters[0].Value = cClassName;
            parameters[1].Value = cParentID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsFeesSubjectClassChild(int FeesSubjectClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFeesSubjectClassInfo");
            strSql.Append(" where cParentID=@FeesSubjectClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        public bool ExistsFeesSubjectClassInfoByCode(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFeesSubjectClassInfo");
            strSql.Append(" where cCode=@cCode");
            SqlParameter[] parameters = {
					new SqlParameter("@cCode", SqlDbType.VarChar,50),};
            parameters[0].Value = cCode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddFeesSubjectClassInfo(FeesSubjectClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbFeesSubjectClassInfo(");
            strSql.Append("cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType)");
            strSql.Append(" values (");
            strSql.Append("@cParentID,@cClassName,@cOrder,@cAppendTime,@cDirection,@cCode,@cType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cParentID", SqlDbType.Int,4),
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
					new SqlParameter("@cOrder", SqlDbType.Int,4),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@cDirection", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,50),
					new SqlParameter("@cType", SqlDbType.Int,4),};
            parameters[0].Value = model.cParentID;
            parameters[1].Value = model.cClassName;
            parameters[2].Value = model.cOrder;
            parameters[3].Value = model.cAppendTime;
            parameters[4].Value = model.cDirection;
            parameters[5].Value = model.cCode;
            parameters[6].Value = model.cType;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public int UpdateFeesSubjectClassInfo(FeesSubjectClassInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbFeesSubjectClassInfo set ");
            strSql.Append("cParentID=@cParentID,");
            strSql.Append("cClassName=@cClassName,");
            strSql.Append("cOrder=@cOrder,");
            strSql.Append("cAppendTime=@cAppendTime,");
            strSql.Append("cDirection=@cDirection,");
            strSql.Append("cCode=@cCode,");
            strSql.Append("cType=@cType ");
            strSql.Append(" where FeesSubjectClassID=@FeesSubjectClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4),
					new SqlParameter("@cParentID", SqlDbType.Int,4),
					new SqlParameter("@cClassName", SqlDbType.VarChar,50),
					new SqlParameter("@cOrder", SqlDbType.Int,4),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@cDirection", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,50),
					new SqlParameter("@cType", SqlDbType.Int,4),};
            parameters[0].Value = model.FeesSubjectClassID;
            parameters[1].Value = model.cParentID;
            parameters[2].Value = model.cClassName;
            parameters[3].Value = model.cOrder;
            parameters[4].Value = model.cAppendTime;
            parameters[5].Value = model.cDirection;
            parameters[6].Value = model.cCode;
            parameters[7].Value = model.cType;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteFeesSubjectClassInfo(int FeesSubjectClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFeesSubjectClassInfo ");
            strSql.Append(" where FeesSubjectClassID=@FeesSubjectClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectClassID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FeesSubjectClassInfo GetFeesSubjectClassInfoModel(int FeesSubjectClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType from tbFeesSubjectClassInfo ");
            strSql.Append(" where FeesSubjectClassID=@FeesSubjectClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectClassID;

            FeesSubjectClassInfo model = new FeesSubjectClassInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString() != "")
                {
                    model.FeesSubjectClassID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cParentID"].ToString() != "")
                {
                    model.cParentID = int.Parse(ds.Tables[0].Rows[0]["cParentID"].ToString());
                }
                model.cClassName = ds.Tables[0].Rows[0]["cClassName"].ToString();
                if (ds.Tables[0].Rows[0]["cOrder"].ToString() != "")
                {
                    model.cOrder = int.Parse(ds.Tables[0].Rows[0]["cOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["cDirection"].ToString() != "")
                {
                    model.cDirection = int.Parse(ds.Tables[0].Rows[0]["cDirection"].ToString());
                }
                model.cCode = ds.Tables[0].Rows[0]["cCode"].ToString();
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {
                    model.cType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
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
        public DataSet GetFeesSubjectClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            //strSql.Append("select FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cType,cSubjectNum,cBalanceDirection ");

            strSql.Append("select FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType ");

            strSql.Append(" FROM tbFeesSubjectClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetFeesSubjectClassInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            //strSql.Append(" FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cType,cSubjectNum,cBalanceDirection  ");

            strSql.Append(" FeesSubjectClassID,cParentID,cClassName,cOrder,cAppendTime,cDirection,cCode,cType ");

            strSql.Append(" FROM tbFeesSubjectClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }


        #endregion
        #region StorageClass
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetStorageClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StorageClassID,sParentID,sClassName,sOrder,sAppendTime ");
            strSql.Append(" FROM tbStorageClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsStorageClassChild(int StorageClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStorageClassInfo");
            strSql.Append(" where sParentID=@StorageClassID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@StorageClassID", SqlDbType.Int,4)};
            parameters[0].Value = StorageClassID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        #endregion
        #region region
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetRegionClassInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbRegionInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsRegionClassChild(int RegionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbRegionInfo");
            strSql.Append(" where rUpID=@RegionID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@RegionID", SqlDbType.Int,4)};
            parameters[0].Value = RegionID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 循环找到区域子节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        public string getRegionChildrenCount(string kid)
        {
            string cid = kid;
            string chID = "";
            string ID = "";
            ArrayList al = new ArrayList();
            while (true)
            {
                //1. 调用方法，继续寻找子节点
                string dt = getRegionClassID(kid);
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
        public string getRegionClassID(string fid)
        {
            int m = fid.IndexOf(",");
            string dtm = "";
            if (m > 0)
            {
                string[] spid = fid.Split(',');
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                for (int i = 0; i < spid.Length - 1; i++)
                {
                    StringBuilder btr = new StringBuilder();
                    btr.Append("select RegionID from tbRegionInfo where rUpID='" + spid[i] + "'");

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
                btr.Append("select RegionID from tbRegionInfo where rUpID='" + fid + "'");
                DataTable mm = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
                for (int i = 0; i < mm.Rows.Count; i++)
                {
                    dtm += mm.Rows[i][0].ToString() + ",";
                }
                return dtm;
            }
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public bool ExistsCustormClassChild(int Custorm)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StoresID,sName,sCode,sType,RegionID,sState,sAppendTime,YHsysID,sIsFZYH,sContact,sTel,sAddress,sEmail,sLicense,");
            strSql.Append(" (select yName from tbYHsysInfo where YHsysID=tbStoresInfo.[YHsysID]) as YHsysName,sDoDay,sDoDayMoney,PaymentSystemID,");
            strSql.Append(" (select pName from tbPaymentSystemInfo where tbPaymentSystemInfo.PaymentSystemID=tbStoresInfo.PaymentSystemID) as PaymentSystemName,CustomersClassID,");
            strSql.Append(" (select cClassName from tbCustomersClassInfo where CustomersClassID=tbStoresInfo.CustomersClassID) as CustomersClassName,PriceClassID,");
            strSql.Append(" (select tbPriceClassInfo.pClassName from tbPriceClassInfo where tbPriceClassInfo.PriceClassID=tbStoresInfo.PriceClassID) as PriceClassName ");
            strSql.Append(" FROM tbStoresInfo  where CustomersClassID=@Custorm");
            SqlParameter[] parameters = {
                                        new SqlParameter("@Custorm", SqlDbType.Int,4)};
            parameters[0].Value = Custorm;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 循环找到客户子节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        public string getCustormChildrenCount(string kid)
        {
            string cid = kid;
            string chID = "";
            string ID = "";
            ArrayList al = new ArrayList();
            while (true)
            {
                //1. 调用方法，继续寻找子节点
                string dt = getCustormClassID(kid);
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
        public string getCustormClassID(string fid)
        {
            int m = fid.IndexOf(",");
            string dtm = "";
            if (m > 0)
            {
                string[] spid = fid.Split(',');
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                for (int i = 0; i < spid.Length - 1; i++)
                {
                    StringBuilder btr = new StringBuilder();
                    btr.Append("select StoresID,sName,sCode,sType,RegionID,sState,sAppendTime,YHsysID,sIsFZYH,sContact,sTel,sAddress,sEmail,sLicense,");
                    btr.Append(" (select yName from tbYHsysInfo where YHsysID=tbStoresInfo.[YHsysID]) as YHsysName,sDoDay,sDoDayMoney,PaymentSystemID,");
                    btr.Append(" (select pName from tbPaymentSystemInfo where tbPaymentSystemInfo.PaymentSystemID=tbStoresInfo.PaymentSystemID) as PaymentSystemName,CustomersClassID,");
                    btr.Append(" (select cClassName from tbCustomersClassInfo where CustomersClassID=tbStoresInfo.CustomersClassID) as CustomersClassName,PriceClassID,");
                    btr.Append(" (select tbPriceClassInfo.pClassName from tbPriceClassInfo where tbPriceClassInfo.PriceClassID=tbStoresInfo.PriceClassID) as PriceClassName ");
                    btr.Append(" FROM tbStoresInfo  where CustomersClassID='" + spid[i] + "'");

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
                btr.Append("select StoresID,sName,sCode,sType,RegionID,sState,sAppendTime,YHsysID,sIsFZYH,sContact,sTel,sAddress,sEmail,sLicense,");
                btr.Append(" (select yName from tbYHsysInfo where YHsysID=tbStoresInfo.[YHsysID]) as YHsysName,sDoDay,sDoDayMoney,PaymentSystemID,");
                btr.Append(" (select pName from tbPaymentSystemInfo where tbPaymentSystemInfo.PaymentSystemID=tbStoresInfo.PaymentSystemID) as PaymentSystemName,CustomersClassID,");
                btr.Append(" (select cClassName from tbCustomersClassInfo where CustomersClassID=tbStoresInfo.CustomersClassID) as CustomersClassName,PriceClassID,");
                btr.Append(" (select tbPriceClassInfo.pClassName from tbPriceClassInfo where tbPriceClassInfo.PriceClassID=tbStoresInfo.PriceClassID) as PriceClassName ");
                btr.Append(" FROM tbStoresInfo  where CustomersClassID='" + fid + "'");
                DataTable mm = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
                for (int i = 0; i < mm.Rows.Count; i++)
                {
                    dtm += mm.Rows[i][0].ToString() + ",";
                }
                return dtm;
            }
        }
        /// <summary>
        /// 循环找到客户子节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        public string getProductsChildrenCount(string kid)
        {
            string cid = kid;
            string chID = "";
            string ID = "";
            ArrayList al = new ArrayList();
            while (true)
            {
                //1. 调用方法，继续寻找子节点
                string dt = getProductsClassID(kid);
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
        public string getProductsClassID(string fid)
        {
            int m = fid.IndexOf(",");
            string dtm = "";
            if (m > 0)
            {
                string[] spid = fid.Split(',');
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                for (int i = 0; i < spid.Length - 1; i++)
                {
                    StringBuilder btr = new StringBuilder();
                    btr.Append("select *,(select pClassName from tbProductClassInfo where ProductClassID=tbProductsInfo.ProductClassID) as pClassName from tbProductsInfo where ProductClassID='" + spid[i] + "'");
             
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
                btr.Append("select *,(select pClassName from tbProductClassInfo where ProductClassID=tbProductsInfo.ProductClassID) as pClassName from tbProductsInfo where ProductClassID='" + fid + "'");
                DataTable mm = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
                for (int i = 0; i < mm.Rows.Count; i++)
                {
                    dtm += mm.Rows[i][0].ToString() + ",";
                }
                return dtm;
            }
        }
        #endregion
    }
}

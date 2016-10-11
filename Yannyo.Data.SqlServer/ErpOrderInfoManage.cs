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
        public bool ExistsErpOrderInfo(int O_ID, string O_ORDERNUM, int P_ID, int S_ID, int R_ID, DateTime O_CREATETIME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbErpOrderInfo");
            strSql.Append(" where O_ID=@O_ID and  O_ORDERNUM=@O_ORDERNUM and P_ID=@P_ID and S_ID=@S_ID and R_ID=@R_ID and O_CREATETIME=@O_CREATETIME");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.Int,4),
                                        new SqlParameter("@O_ORDERNUM", SqlDbType.VarChar,50),
                                        new SqlParameter("@P_ID", SqlDbType.Int,4),
                                        new SqlParameter("@S_ID", SqlDbType.Int,4),
                                        new SqlParameter("@R_ID", SqlDbType.Int,4),
                                        new SqlParameter("@O_CREATETIME", SqlDbType.DateTime,8)};
            parameters[0].Value = O_ID;
            parameters[1].Value = O_ORDERNUM;
            parameters[2].Value = P_ID;
            parameters[3].Value = S_ID;
            parameters[4].Value = R_ID;
            parameters[5].Value = O_CREATETIME;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddErpOrderInfo(ErpOrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbErpOrderInfo(");
            strSql.Append("O_ID,O_ORDERNUM,O_CREATETIME,ProductsID,P_ID,P_CODE,P_NAME,P_RULES,S_ID,S_PRICE,S_QUANTITY,S_TOTAL,C_NAME,R_NAME,R_ID,SA_NAME,eAppendTime,StoresID,StaffID,C_CODE,PROMOTIONS,storageid)");
            strSql.Append(" values (");
            strSql.Append("@O_ID,@O_ORDERNUM,@O_CREATETIME,@ProductsID,@P_ID,@P_CODE,@P_NAME,@P_RULES,@S_ID,@S_PRICE,@S_QUANTITY,@S_TOTAL,@C_NAME,@R_NAME,@R_ID,@SA_NAME,@eAppendTime,@StoresID,@StaffID,@C_CODE,@PROMOTIONS,@storageid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.Int,4),
					new SqlParameter("@O_ORDERNUM", SqlDbType.VarChar,50),
					new SqlParameter("@O_CREATETIME", SqlDbType.DateTime),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@P_ID", SqlDbType.Int,4),
					new SqlParameter("@P_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@P_NAME", SqlDbType.VarChar,128),
					new SqlParameter("@P_RULES", SqlDbType.VarChar,50),
					new SqlParameter("@S_ID", SqlDbType.Int,4),
					new SqlParameter("@S_PRICE", SqlDbType.Money,8),
					new SqlParameter("@S_QUANTITY", SqlDbType.Int,4),
					new SqlParameter("@S_TOTAL", SqlDbType.Money,8),
					new SqlParameter("@C_NAME", SqlDbType.VarChar,128),
					new SqlParameter("@R_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@R_ID", SqlDbType.Int,4),
					new SqlParameter("@SA_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@eAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@StoresID", SqlDbType.Int,4),
                    new SqlParameter("@StaffID", SqlDbType.Int,4),
                    new SqlParameter("@C_CODE", SqlDbType.VarChar,50),
                    new SqlParameter("@PROMOTIONS", SqlDbType.Int,4),
                    new SqlParameter("@storageid", SqlDbType.Int,4)};
            parameters[0].Value = model.O_ID;
            parameters[1].Value = model.O_ORDERNUM;
            parameters[2].Value = model.O_CREATETIME;
            parameters[3].Value = model.ProductsID;
            parameters[4].Value = model.P_ID;
            parameters[5].Value = model.P_CODE;
            parameters[6].Value = model.P_NAME;
            parameters[7].Value = model.P_RULES;
            parameters[8].Value = model.S_ID;
            parameters[9].Value = model.S_PRICE;
            parameters[10].Value = model.S_QUANTITY;
            parameters[11].Value = model.S_TOTAL;
            parameters[12].Value = model.C_NAME;
            parameters[13].Value = model.R_NAME;
            parameters[14].Value = model.R_ID;
            parameters[15].Value = model.SA_NAME;
            parameters[16].Value = model.eAppendTime;
            parameters[17].Value = model.StoresID;
            parameters[18].Value = model.StaffID;
            parameters[19].Value = model.C_CODE;
            parameters[20].Value = model.PROMOTIONS;
            parameters[21].Value = model.storageid;

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
        public void UpdateErpOrderInfo(ErpOrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbErpOrderInfo set ");
            strSql.Append("O_ID=@O_ID,");
            strSql.Append("O_ORDERNUM=@O_ORDERNUM,");
            strSql.Append("O_CREATETIME=@O_CREATETIME,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("P_ID=@P_ID,");
            strSql.Append("P_CODE=@P_CODE,");
            strSql.Append("P_NAME=@P_NAME,");
            strSql.Append("P_RULES=@P_RULES,");
            strSql.Append("S_ID=@S_ID,");
            strSql.Append("S_PRICE=@S_PRICE,");
            strSql.Append("S_QUANTITY=@S_QUANTITY,");
            strSql.Append("S_TOTAL=@S_TOTAL,");
            strSql.Append("C_NAME=@C_NAME,");
            strSql.Append("R_NAME=@R_NAME,");
            strSql.Append("R_ID=@R_ID,");
            strSql.Append("SA_NAME=@SA_NAME,");
            strSql.Append("eAppendTime=@eAppendTime,");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("C_CODE=@C_CODE,");
            strSql.Append("PROMOTIONS=@PROMOTIONS,");
            strSql.Append("storageid=@storageid");
            strSql.Append(" where ErpOrderID=@ErpOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ErpOrderID", SqlDbType.Int,4),
					new SqlParameter("@O_ID", SqlDbType.Int,4),
					new SqlParameter("@O_ORDERNUM", SqlDbType.VarChar,50),
					new SqlParameter("@O_CREATETIME", SqlDbType.DateTime),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@P_ID", SqlDbType.Int,4),
					new SqlParameter("@P_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@P_NAME", SqlDbType.VarChar,128),
					new SqlParameter("@P_RULES", SqlDbType.VarChar,50),
					new SqlParameter("@S_ID", SqlDbType.Int,4),
					new SqlParameter("@S_PRICE", SqlDbType.Money,8),
					new SqlParameter("@S_QUANTITY", SqlDbType.Int,4),
					new SqlParameter("@S_TOTAL", SqlDbType.Money,8),
					new SqlParameter("@C_NAME", SqlDbType.VarChar,128),
					new SqlParameter("@R_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@R_ID", SqlDbType.Int,4),
					new SqlParameter("@SA_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@eAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@StoresID", SqlDbType.Int,4),
                    new SqlParameter("@StaffID", SqlDbType.Int,4),
                    new SqlParameter("@C_CODE", SqlDbType.VarChar,50),
                    new SqlParameter("@PROMOTIONS", SqlDbType.Int,4),
                    new SqlParameter("@storageid", SqlDbType.Int,4)};
            parameters[0].Value = model.ErpOrderID;
            parameters[1].Value = model.O_ID;
            parameters[2].Value = model.O_ORDERNUM;
            parameters[3].Value = model.O_CREATETIME;
            parameters[4].Value = model.ProductsID;
            parameters[5].Value = model.P_ID;
            parameters[6].Value = model.P_CODE;
            parameters[7].Value = model.P_NAME;
            parameters[8].Value = model.P_RULES;
            parameters[9].Value = model.S_ID;
            parameters[10].Value = model.S_PRICE;
            parameters[11].Value = model.S_QUANTITY;
            parameters[12].Value = model.S_TOTAL;
            parameters[13].Value = model.C_NAME;
            parameters[14].Value = model.R_NAME;
            parameters[15].Value = model.R_ID;
            parameters[16].Value = model.SA_NAME;
            parameters[17].Value = model.eAppendTime;
            parameters[18].Value = model.StoresID;
            parameters[19].Value = model.StaffID;
            parameters[20].Value = model.C_CODE;
            parameters[21].Value = model.PROMOTIONS;
            parameters[22].Value = model.storageid;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新对账状态
        /// </summary>
        public void UpdateErpOrderIsCheck(string ErpOrderID, int t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbErpOrderInfo set IsCheck=" + t + " where ErpOrderID in(" + ErpOrderID + ")");
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        public int[] SyncErpOrderInfo()
        {
            int[] ReCount = {0,0};
            //ProductsInfo pi = new ProductsInfo();
            //StoresInfo si = new StoresInfo();
            //StaffInfo ssi = new StaffInfo();
            /*
            StringBuilder strSqlt = new StringBuilder();

            string strSql = "select * from tbErpOrderInfo";// where ProductsID=0 or StoresID=0 or StaffID=0";
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                strSqlt.Append("update tbErpOrderInfo set tbErpOrderInfo.ProductsID=p.ProductsID from tbProductsInfo as p where p.pBarcode='" + dr["P_CODE"].ToString().Trim() + "' and tbErpOrderInfo.ErpOrderID=" + dr["ErpOrderID"].ToString() + ";\n ");
                ReCount[0] ++;


                strSqlt.Append("update tbErpOrderInfo set tbErpOrderInfo.StoresID=s.StoresID from tbStoresInfo as s where s.sName='" + dr["C_NAME"].ToString().Trim() + "' and tbErpOrderInfo.ErpOrderID=" + dr["ErpOrderID"].ToString() + ";\n ");
                ReCount[2] ++;


                strSqlt.Append("update tbErpOrderInfo set tbErpOrderInfo.StaffID=s.StaffID from tbStaffInfo as s where s.sName='" + dr["SA_NAME"].ToString().Trim() + "' and tbErpOrderInfo.ErpOrderID=" + dr["ErpOrderID"].ToString() + ";\n ");
                ReCount[3]++;

                if (strSqlt.Length > 100)
                {
                    ReCount[1] += DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    strSqlt.Remove(0, 99);
                }

            }
            if (strSqlt.ToString().Trim() != "")
            {
                ReCount[1] += DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString());
            }
             */
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "SyncErpOrderInfo");
            if (ds.Tables.Count > 1)
            {
                ReCount[0] = (int)ds.Tables[0].Rows[0][0];
                ReCount[1] = (int)ds.Tables[0].Rows[0][1];
            }
            ds.Clear();
            ds.Dispose();
            return ReCount;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteErpOrderInfo(int ErpOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbErpOrderInfo ");
            strSql.Append(" where ErpOrderID=@ErpOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ErpOrderID", SqlDbType.Int,4)};
            parameters[0].Value = ErpOrderID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }
        public void DeleteErpOrderInfoByOID(int O_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbErpOrderInfo ");
            strSql.Append(" where O_ID=@O_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.Int,4)};
            parameters[0].Value = O_ID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteErpOrderInfo(string ErpOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbErpOrderInfo ");
            strSql.Append(" where ErpOrderID in(" + ErpOrderID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ErpOrderInfo GetErpOrderInfoModel(int ErpOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ErpOrderID,O_ID,O_ORDERNUM,O_CREATETIME,ProductsID,P_ID,P_CODE,P_NAME,P_RULES,S_ID,S_PRICE,S_QUANTITY,S_TOTAL,C_NAME,R_NAME,R_ID,SA_NAME,eAppendTime,StoresID,C_CODE,PROMOTIONS,IsCheck,storageid,(select pName from tbProductsInfo where ProductsID=tbErpOrderInfo.ProductsID) as ProductsName,(select sName from tbStoresInfo where StoresID=tbErpOrderInfo.StoresID) as StoresName from tbErpOrderInfo ");
            strSql.Append(" where ErpOrderID=@ErpOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ErpOrderID", SqlDbType.Int,4)};
            parameters[0].Value = ErpOrderID;

            ErpOrderInfo model = new ErpOrderInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ErpOrderID"].ToString() != "")
                {
                    model.ErpOrderID = int.Parse(ds.Tables[0].Rows[0]["ErpOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["O_ID"].ToString() != "")
                {
                    model.O_ID = int.Parse(ds.Tables[0].Rows[0]["O_ID"].ToString());
                }
                model.O_ORDERNUM = ds.Tables[0].Rows[0]["O_ORDERNUM"].ToString();
                if (ds.Tables[0].Rows[0]["O_CREATETIME"].ToString() != "")
                {
                    model.O_CREATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["O_CREATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["P_ID"].ToString() != "")
                {
                    model.P_ID = int.Parse(ds.Tables[0].Rows[0]["P_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                model.P_CODE = ds.Tables[0].Rows[0]["P_CODE"].ToString();
                model.P_NAME = ds.Tables[0].Rows[0]["P_NAME"].ToString();
                model.P_RULES = ds.Tables[0].Rows[0]["P_RULES"].ToString();
                model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();
                if (ds.Tables[0].Rows[0]["S_ID"].ToString() != "")
                {
                    model.S_ID = int.Parse(ds.Tables[0].Rows[0]["S_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["storageid"].ToString() != "")
                {
                    model.storageid = int.Parse(ds.Tables[0].Rows[0]["storageid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["S_PRICE"].ToString() != "")
                {
                    model.S_PRICE = decimal.Parse(ds.Tables[0].Rows[0]["S_PRICE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["S_QUANTITY"].ToString() != "")
                {
                    model.S_QUANTITY = int.Parse(ds.Tables[0].Rows[0]["S_QUANTITY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["S_TOTAL"].ToString() != "")
                {
                    model.S_TOTAL = decimal.Parse(ds.Tables[0].Rows[0]["S_TOTAL"].ToString());
                }
                model.C_CODE = ds.Tables[0].Rows[0]["C_CODE"].ToString();
                model.C_NAME = ds.Tables[0].Rows[0]["C_NAME"].ToString();
                model.R_NAME = ds.Tables[0].Rows[0]["R_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["R_ID"].ToString() != "")
                {
                    model.R_ID = int.Parse(ds.Tables[0].Rows[0]["R_ID"].ToString());
                }
                model.SA_NAME = ds.Tables[0].Rows[0]["SA_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["eAppendTime"].ToString() != "")
                {
                    model.eAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["eAppendTime"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                if (ds.Tables[0].Rows[0]["PROMOTIONS"].ToString() != "")
                {
                    model.PROMOTIONS = int.Parse(ds.Tables[0].Rows[0]["PROMOTIONS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsCheck"].ToString() != "")
                {
                    model.IsCheck = int.Parse(ds.Tables[0].Rows[0]["IsCheck"].ToString());
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
        public DataSet GetErpOrderInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ErpOrderID,O_ID,O_ORDERNUM,O_CREATETIME,ProductsID,P_ID,P_CODE,P_NAME,P_RULES,S_ID,S_PRICE,S_QUANTITY,S_TOTAL,C_NAME,R_NAME,R_ID,SA_NAME,eAppendTime,StoresID,C_CODE,PROMOTIONS,IsCheck,storageid,(select pName from tbProductsInfo where ProductsID=tbErpOrderInfo.ProductsID) as ProductsName,(select sName from tbStoresInfo where StoresID=tbErpOrderInfo.StoresID) as StoresName ");
            strSql.Append(" FROM tbErpOrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetErpOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbErpOrderInfo";
            parameters[1].Value = "ErpOrderID";
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
        /// 获取指定条件下的订单编号集合
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        public string GetErpOrderIDStr(int StoresID, int R_ID,DateTime eDate)
        {
            string reStr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ErpOrderID ");
            strSql.Append(" FROM tbErpOrderInfo where StoresID=@StoresID and R_ID=@R_ID and O_CREATETIME<=@eDate");
            SqlParameter[] parameters = {
                    new SqlParameter("@StoresID", SqlDbType.Int),
                    new SqlParameter("@R_ID", SqlDbType.Int),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    };
            parameters[0].Value = StoresID;
            parameters[1].Value = R_ID;
            parameters[2].Value = eDate;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds != null)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    reStr += dr["ErpOrderID"].ToString()+",";
                }
            }
            if (reStr.Trim() != "")
            {
                reStr = "," + reStr + ",";
                reStr = Utils.ReSQLSetTxt(reStr);
            }
            return reStr;
        }

        /// <summary>
        /// 修改订单标记
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="IsCheck">修改后标记,未对账=0,已对账=1</param>
        public bool UpdateErpOrderCheck(int StoresID, int R_ID, DateTime eDate, int IsCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbErpOrderInfo set IsCheck=@IsCheck ");
            strSql.Append(" where StoresID=@StoresID and R_ID=@R_ID and O_CREATETIME<=@eDate");
            SqlParameter[] parameters = {
                    new SqlParameter("@StoresID", SqlDbType.Int),
                    new SqlParameter("@R_ID", SqlDbType.Int),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@IsCheck", SqlDbType.Int),
                    };
            parameters[0].Value = StoresID;
            parameters[1].Value = R_ID;
            parameters[2].Value = eDate;
            parameters[3].Value = IsCheck;

            try
            {
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                return true;
            }catch
            {
                return false;
            }
        }
    }
}

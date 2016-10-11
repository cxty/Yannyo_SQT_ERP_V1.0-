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
        public bool ExistsM_SendGoodsInfo(int OrderID, string m_TradeInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_SendGoodsInfo");
            strSql.Append(" where OrderID=@OrderID and m_TradeInfoID=@m_TradeInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
            };

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_SendGoodsInfo(M_SendGoodsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_SendGoodsInfo(");
            strSql.Append("m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@m_ConfigInfoID,@OrderID,@m_TradeInfoID,@receiver_name,@receiver_state,@receiver_city,@receiver_district,@receiver_address,@receiver_zip,@receiver_mobile,@receiver_phone,@from_name,@from_state,@from_city,@from_district,@from_address,@from_zip,@from_mobile,@from_phone,@mExpName,@mExpNO,@mMemo,@mState,@mAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.VarChar,256),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_state", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_city", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_district", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_address", SqlDbType.VarChar,256),
					new SqlParameter("@receiver_zip", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@from_name", SqlDbType.VarChar,50),
					new SqlParameter("@from_state", SqlDbType.VarChar,50),
					new SqlParameter("@from_city", SqlDbType.VarChar,50),
					new SqlParameter("@from_district", SqlDbType.VarChar,50),
					new SqlParameter("@from_address", SqlDbType.VarChar,256),
					new SqlParameter("@from_zip", SqlDbType.VarChar,50),
					new SqlParameter("@from_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@from_phone", SqlDbType.VarChar,50),
					new SqlParameter("@mExpName", SqlDbType.Int,4),
					new SqlParameter("@mExpNO", SqlDbType.VarChar,50),
					new SqlParameter("@mMemo", SqlDbType.VarChar,256),
					new SqlParameter("@mState", SqlDbType.Int,4),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_ConfigInfoID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.m_TradeInfoID;
            parameters[3].Value = model.receiver_name;
            parameters[4].Value = model.receiver_state;
            parameters[5].Value = model.receiver_city;
            parameters[6].Value = model.receiver_district;
            parameters[7].Value = model.receiver_address;
            parameters[8].Value = model.receiver_zip;
            parameters[9].Value = model.receiver_mobile;
            parameters[10].Value = model.receiver_phone;
            parameters[11].Value = model.from_name;
            parameters[12].Value = model.from_state;
            parameters[13].Value = model.from_city;
            parameters[14].Value = model.from_district;
            parameters[15].Value = model.from_address;
            parameters[16].Value = model.from_zip;
            parameters[17].Value = model.from_mobile;
            parameters[18].Value = model.from_phone;
            parameters[19].Value = model.mExpName;
            parameters[20].Value = model.mExpNO;
            parameters[21].Value = model.mMemo;
            parameters[22].Value = model.mState;
            parameters[23].Value = model.mAppendTime;

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
        public bool UpdateM_SendGoodsInfo(M_SendGoodsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_SendGoodsInfo set ");
            strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("m_TradeInfoID=@m_TradeInfoID,");
            strSql.Append("receiver_name=@receiver_name,");
            strSql.Append("receiver_state=@receiver_state,");
            strSql.Append("receiver_city=@receiver_city,");
            strSql.Append("receiver_district=@receiver_district,");
            strSql.Append("receiver_address=@receiver_address,");
            strSql.Append("receiver_zip=@receiver_zip,");
            strSql.Append("receiver_mobile=@receiver_mobile,");
            strSql.Append("receiver_phone=@receiver_phone,");
            strSql.Append("from_name=@from_name,");
            strSql.Append("from_state=@from_state,");
            strSql.Append("from_city=@from_city,");
            strSql.Append("from_district=@from_district,");
            strSql.Append("from_address=@from_address,");
            strSql.Append("from_zip=@from_zip,");
            strSql.Append("from_mobile=@from_mobile,");
            strSql.Append("from_phone=@from_phone,");
            strSql.Append("mExpName=@mExpName,");
            strSql.Append("mExpNO=@mExpNO,");
            strSql.Append("mMemo=@mMemo,");
            strSql.Append("mState=@mState,");
            strSql.Append("mAppendTime=@mAppendTime");
            strSql.Append(" where m_SendGoodsID=@m_SendGoodsID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_SendGoodsID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.VarChar,256),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_state", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_city", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_district", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_address", SqlDbType.VarChar,256),
					new SqlParameter("@receiver_zip", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@from_name", SqlDbType.VarChar,50),
					new SqlParameter("@from_state", SqlDbType.VarChar,50),
					new SqlParameter("@from_city", SqlDbType.VarChar,50),
					new SqlParameter("@from_district", SqlDbType.VarChar,50),
					new SqlParameter("@from_address", SqlDbType.VarChar,256),
					new SqlParameter("@from_zip", SqlDbType.VarChar,50),
					new SqlParameter("@from_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@from_phone", SqlDbType.VarChar,50),
					new SqlParameter("@mExpName", SqlDbType.Int,4),
					new SqlParameter("@mExpNO", SqlDbType.VarChar,50),
					new SqlParameter("@mMemo", SqlDbType.VarChar,256),
					new SqlParameter("@mState", SqlDbType.Int,4),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_SendGoodsID;
            parameters[1].Value = model.m_ConfigInfoID;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.m_TradeInfoID;
            parameters[4].Value = model.receiver_name;
            parameters[5].Value = model.receiver_state;
            parameters[6].Value = model.receiver_city;
            parameters[7].Value = model.receiver_district;
            parameters[8].Value = model.receiver_address;
            parameters[9].Value = model.receiver_zip;
            parameters[10].Value = model.receiver_mobile;
            parameters[11].Value = model.receiver_phone;
            parameters[12].Value = model.from_name;
            parameters[13].Value = model.from_state;
            parameters[14].Value = model.from_city;
            parameters[15].Value = model.from_district;
            parameters[16].Value = model.from_address;
            parameters[17].Value = model.from_zip;
            parameters[18].Value = model.from_mobile;
            parameters[19].Value = model.from_phone;
            parameters[20].Value = model.mExpName;
            parameters[21].Value = model.mExpNO;
            parameters[22].Value = model.mMemo;
            parameters[23].Value = model.mState;
            parameters[24].Value = model.mAppendTime;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_SendGoodsInfo(int m_SendGoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_SendGoodsInfo ");
            strSql.Append(" where m_SendGoodsID=@m_SendGoodsID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_SendGoodsID", SqlDbType.Int,4)
};
            parameters[0].Value = m_SendGoodsID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_SendGoodsInfoList(string m_SendGoodsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_SendGoodsInfo ");
            strSql.Append(" where m_SendGoodsID in (" + m_SendGoodsIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_SendGoodsInfo GetM_SendGoodsInfoModel(int m_SendGoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_SendGoodsID,m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime from tb_M_SendGoodsInfo ");
            strSql.Append(" where m_SendGoodsID=@m_SendGoodsID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_SendGoodsID", SqlDbType.Int,4)
};
            parameters[0].Value = m_SendGoodsID;

            M_SendGoodsInfo model = new M_SendGoodsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString() != "")
                {
                    model.m_SendGoodsID = int.Parse(ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.m_TradeInfoID = ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString();
                model.receiver_name = ds.Tables[0].Rows[0]["receiver_name"].ToString();
                model.receiver_state = ds.Tables[0].Rows[0]["receiver_state"].ToString();
                model.receiver_city = ds.Tables[0].Rows[0]["receiver_city"].ToString();
                model.receiver_district = ds.Tables[0].Rows[0]["receiver_district"].ToString();
                model.receiver_address = ds.Tables[0].Rows[0]["receiver_address"].ToString();
                model.receiver_zip = ds.Tables[0].Rows[0]["receiver_zip"].ToString();
                model.receiver_mobile = ds.Tables[0].Rows[0]["receiver_mobile"].ToString();
                model.receiver_phone = ds.Tables[0].Rows[0]["receiver_phone"].ToString();
                model.from_name = ds.Tables[0].Rows[0]["from_name"].ToString();
                model.from_state = ds.Tables[0].Rows[0]["from_state"].ToString();
                model.from_city = ds.Tables[0].Rows[0]["from_city"].ToString();
                model.from_district = ds.Tables[0].Rows[0]["from_district"].ToString();
                model.from_address = ds.Tables[0].Rows[0]["from_address"].ToString();
                model.from_zip = ds.Tables[0].Rows[0]["from_zip"].ToString();
                model.from_mobile = ds.Tables[0].Rows[0]["from_mobile"].ToString();
                model.from_phone = ds.Tables[0].Rows[0]["from_phone"].ToString();
                if (ds.Tables[0].Rows[0]["mExpName"].ToString() != "")
                {
                    model.mExpName = int.Parse(ds.Tables[0].Rows[0]["mExpName"].ToString());
                }
                model.mExpNO = ds.Tables[0].Rows[0]["mExpNO"].ToString();
                model.mMemo = ds.Tables[0].Rows[0]["mMemo"].ToString();
                if (ds.Tables[0].Rows[0]["mState"].ToString() != "")
                {
                    model.mState = int.Parse(ds.Tables[0].Rows[0]["mState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 指定发货单返回网购发货单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public M_SendGoodsInfo GetM_SendGoodsInfoModelByOrderID(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_SendGoodsID,m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime from tb_M_SendGoodsInfo ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
};
            parameters[0].Value = OrderID;

            M_SendGoodsInfo model = new M_SendGoodsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString() != "")
                {
                    model.m_SendGoodsID = int.Parse(ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.m_TradeInfoID = ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString();
                model.receiver_name = ds.Tables[0].Rows[0]["receiver_name"].ToString();
                model.receiver_state = ds.Tables[0].Rows[0]["receiver_state"].ToString();
                model.receiver_city = ds.Tables[0].Rows[0]["receiver_city"].ToString();
                model.receiver_district = ds.Tables[0].Rows[0]["receiver_district"].ToString();
                model.receiver_address = ds.Tables[0].Rows[0]["receiver_address"].ToString();
                model.receiver_zip = ds.Tables[0].Rows[0]["receiver_zip"].ToString();
                model.receiver_mobile = ds.Tables[0].Rows[0]["receiver_mobile"].ToString();
                model.receiver_phone = ds.Tables[0].Rows[0]["receiver_phone"].ToString();
                model.from_name = ds.Tables[0].Rows[0]["from_name"].ToString();
                model.from_state = ds.Tables[0].Rows[0]["from_state"].ToString();
                model.from_city = ds.Tables[0].Rows[0]["from_city"].ToString();
                model.from_district = ds.Tables[0].Rows[0]["from_district"].ToString();
                model.from_address = ds.Tables[0].Rows[0]["from_address"].ToString();
                model.from_zip = ds.Tables[0].Rows[0]["from_zip"].ToString();
                model.from_mobile = ds.Tables[0].Rows[0]["from_mobile"].ToString();
                model.from_phone = ds.Tables[0].Rows[0]["from_phone"].ToString();
                if (ds.Tables[0].Rows[0]["mExpName"].ToString() != "")
                {
                    model.mExpName = int.Parse(ds.Tables[0].Rows[0]["mExpName"].ToString());
                }
                model.mExpNO = ds.Tables[0].Rows[0]["mExpNO"].ToString();
                model.mMemo = ds.Tables[0].Rows[0]["mMemo"].ToString();
                if (ds.Tables[0].Rows[0]["mState"].ToString() != "")
                {
                    model.mState = int.Parse(ds.Tables[0].Rows[0]["mState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 网购交易系统编号返回网购发货单
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <returns></returns>
        public M_SendGoodsInfo GetM_SendGoodsInfoModelBym_TradeInfoID(int m_TradeInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_SendGoodsID,m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime from tb_M_SendGoodsInfo ");
            strSql.Append(" where  charindex('," + m_TradeInfoID + ",',','+m_TradeInfoID+',')>0 ");
            
           
            M_SendGoodsInfo model = new M_SendGoodsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString() != "")
                {
                    model.m_SendGoodsID = int.Parse(ds.Tables[0].Rows[0]["m_SendGoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.m_TradeInfoID = ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString();
                model.receiver_name = ds.Tables[0].Rows[0]["receiver_name"].ToString();
                model.receiver_state = ds.Tables[0].Rows[0]["receiver_state"].ToString();
                model.receiver_city = ds.Tables[0].Rows[0]["receiver_city"].ToString();
                model.receiver_district = ds.Tables[0].Rows[0]["receiver_district"].ToString();
                model.receiver_address = ds.Tables[0].Rows[0]["receiver_address"].ToString();
                model.receiver_zip = ds.Tables[0].Rows[0]["receiver_zip"].ToString();
                model.receiver_mobile = ds.Tables[0].Rows[0]["receiver_mobile"].ToString();
                model.receiver_phone = ds.Tables[0].Rows[0]["receiver_phone"].ToString();
                model.from_name = ds.Tables[0].Rows[0]["from_name"].ToString();
                model.from_state = ds.Tables[0].Rows[0]["from_state"].ToString();
                model.from_city = ds.Tables[0].Rows[0]["from_city"].ToString();
                model.from_district = ds.Tables[0].Rows[0]["from_district"].ToString();
                model.from_address = ds.Tables[0].Rows[0]["from_address"].ToString();
                model.from_zip = ds.Tables[0].Rows[0]["from_zip"].ToString();
                model.from_mobile = ds.Tables[0].Rows[0]["from_mobile"].ToString();
                model.from_phone = ds.Tables[0].Rows[0]["from_phone"].ToString();
                if (ds.Tables[0].Rows[0]["mExpName"].ToString() != "")
                {
                    model.mExpName = int.Parse(ds.Tables[0].Rows[0]["mExpName"].ToString());
                }
                model.mExpNO = ds.Tables[0].Rows[0]["mExpNO"].ToString();
                model.mMemo = ds.Tables[0].Rows[0]["mMemo"].ToString();
                if (ds.Tables[0].Rows[0]["mState"].ToString() != "")
                {
                    model.mState = int.Parse(ds.Tables[0].Rows[0]["mState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
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
        public DataSet GetM_SendGoodsInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_SendGoodsID,m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime ");
            strSql.Append(" FROM tb_M_SendGoodsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_SendGoodsInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_SendGoodsID,m_ConfigInfoID,OrderID,m_TradeInfoID,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,from_name,from_state,from_city,from_district,from_address,from_zip,from_mobile,from_phone,mExpName,mExpNO,mMemo,mState,mAppendTime ");
            strSql.Append(" FROM tb_M_SendGoodsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetM_SendGoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_SendGoodsInfo";
            parameters[1].Value = "m_SendGoodsID";
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

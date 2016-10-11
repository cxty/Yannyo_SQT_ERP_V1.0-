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
        public bool ExistsM_ShippingInfo(int m_TradeInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_ShippingInfo");
            strSql.Append(" where m_TradeInfoID=@m_TradeInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_TradeInfoID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_ShippingInfo(M_ShippingInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_ShippingInfo(");
            strSql.Append("m_TradeInfoID,tid,seller_nick,buyer_nick,delivery_start,delivery_end,out_sid,item_title,receiver_name,receiver_phone,receiver_mobile,status,type,freight_payer,seller_confirm,company_name,is_success,created,modified)");
            strSql.Append(" values (");
            strSql.Append("@m_TradeInfoID,@tid,@seller_nick,@buyer_nick,@delivery_start,@delivery_end,@out_sid,@item_title,@receiver_name,@receiver_phone,@receiver_mobile,@status,@type,@freight_payer,@seller_confirm,@company_name,@is_success,@created,@modified)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.BigInt,8),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_start", SqlDbType.DateTime),
					new SqlParameter("@delivery_end", SqlDbType.DateTime),
					new SqlParameter("@out_sid", SqlDbType.VarChar,50),
					new SqlParameter("@item_title", SqlDbType.VarChar,128),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@freight_payer", SqlDbType.VarChar,50),
					new SqlParameter("@seller_confirm", SqlDbType.VarChar,10),
					new SqlParameter("@company_name", SqlDbType.VarChar,128),
					new SqlParameter("@is_success", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
            parameters[0].Value = model.m_TradeInfoID;
            parameters[1].Value = model.tid;
            parameters[2].Value = model.seller_nick;
            parameters[3].Value = model.buyer_nick;
            parameters[4].Value = model.delivery_start;
            parameters[5].Value = model.delivery_end;
            parameters[6].Value = model.out_sid;
            parameters[7].Value = model.item_title;
            parameters[8].Value = model.receiver_name;
            parameters[9].Value = model.receiver_phone;
            parameters[10].Value = model.receiver_mobile;
            parameters[11].Value = model.status;
            parameters[12].Value = model.type;
            parameters[13].Value = model.freight_payer;
            parameters[14].Value = model.seller_confirm;
            parameters[15].Value = model.company_name;
            parameters[16].Value = model.is_success;
            parameters[17].Value = model.created;
            parameters[18].Value = model.modified;

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
        public void UpdateM_ShippingInfo(M_ShippingInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_ShippingInfo set ");
            strSql.Append("m_TradeInfoID=@m_TradeInfoID,");
            strSql.Append("tid=@tid,");
            strSql.Append("seller_nick=@seller_nick,");
            strSql.Append("buyer_nick=@buyer_nick,");
            strSql.Append("delivery_start=@delivery_start,");
            strSql.Append("delivery_end=@delivery_end,");
            strSql.Append("out_sid=@out_sid,");
            strSql.Append("item_title=@item_title,");
            strSql.Append("receiver_name=@receiver_name,");
            strSql.Append("receiver_phone=@receiver_phone,");
            strSql.Append("receiver_mobile=@receiver_mobile,");
            strSql.Append("status=@status,");
            strSql.Append("type=@type,");
            strSql.Append("freight_payer=@freight_payer,");
            strSql.Append("seller_confirm=@seller_confirm,");
            strSql.Append("company_name=@company_name,");
            strSql.Append("is_success=@is_success,");
            strSql.Append("created=@created,");
            strSql.Append("modified=@modified");
            strSql.Append(" where m_ShippingInfoID=@m_ShippingInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ShippingInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.BigInt,8),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_start", SqlDbType.DateTime),
					new SqlParameter("@delivery_end", SqlDbType.DateTime),
					new SqlParameter("@out_sid", SqlDbType.VarChar,50),
					new SqlParameter("@item_title", SqlDbType.VarChar,128),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@freight_payer", SqlDbType.VarChar,50),
					new SqlParameter("@seller_confirm", SqlDbType.VarChar,10),
					new SqlParameter("@company_name", SqlDbType.VarChar,128),
					new SqlParameter("@is_success", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
            parameters[0].Value = model.m_ShippingInfoID;
            parameters[1].Value = model.m_TradeInfoID;
            parameters[2].Value = model.tid;
            parameters[3].Value = model.seller_nick;
            parameters[4].Value = model.buyer_nick;
            parameters[5].Value = model.delivery_start;
            parameters[6].Value = model.delivery_end;
            parameters[7].Value = model.out_sid;
            parameters[8].Value = model.item_title;
            parameters[9].Value = model.receiver_name;
            parameters[10].Value = model.receiver_phone;
            parameters[11].Value = model.receiver_mobile;
            parameters[12].Value = model.status;
            parameters[13].Value = model.type;
            parameters[14].Value = model.freight_payer;
            parameters[15].Value = model.seller_confirm;
            parameters[16].Value = model.company_name;
            parameters[17].Value = model.is_success;
            parameters[18].Value = model.created;
            parameters[19].Value = model.modified;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteM_ShippingInfo(int m_ShippingInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_ShippingInfo ");
            strSql.Append(" where m_ShippingInfoID=@m_ShippingInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ShippingInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ShippingInfoID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_ShippingInfo GetM_ShippingInfoModel(int m_ShippingInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_ShippingInfoID,m_TradeInfoID,tid,seller_nick,buyer_nick,delivery_start,delivery_end,out_sid,item_title,receiver_name,receiver_phone,receiver_mobile,status,type,freight_payer,seller_confirm,company_name,is_success,created,modified from tb_M_ShippingInfo ");
            strSql.Append(" where m_ShippingInfoID=@m_ShippingInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ShippingInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ShippingInfoID;

            M_ShippingInfo model = new M_ShippingInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_ShippingInfoID"].ToString() != "")
                {
                    model.m_ShippingInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ShippingInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString() != "")
                {
                    model.m_TradeInfoID = int.Parse(ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tid"].ToString() != "")
                {
                    model.tid = long.Parse(ds.Tables[0].Rows[0]["tid"].ToString());
                }
                model.seller_nick = ds.Tables[0].Rows[0]["seller_nick"].ToString();
                model.buyer_nick = ds.Tables[0].Rows[0]["buyer_nick"].ToString();
                if (ds.Tables[0].Rows[0]["delivery_start"].ToString() != "")
                {
                    model.delivery_start = DateTime.Parse(ds.Tables[0].Rows[0]["delivery_start"].ToString());
                }
                if (ds.Tables[0].Rows[0]["delivery_end"].ToString() != "")
                {
                    model.delivery_end = DateTime.Parse(ds.Tables[0].Rows[0]["delivery_end"].ToString());
                }
                model.out_sid = ds.Tables[0].Rows[0]["out_sid"].ToString();
                model.item_title = ds.Tables[0].Rows[0]["item_title"].ToString();
                model.receiver_name = ds.Tables[0].Rows[0]["receiver_name"].ToString();
                model.receiver_phone = ds.Tables[0].Rows[0]["receiver_phone"].ToString();
                model.receiver_mobile = ds.Tables[0].Rows[0]["receiver_mobile"].ToString();
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                model.freight_payer = ds.Tables[0].Rows[0]["freight_payer"].ToString();
                model.seller_confirm = ds.Tables[0].Rows[0]["seller_confirm"].ToString();
                model.company_name = ds.Tables[0].Rows[0]["company_name"].ToString();
                if (ds.Tables[0].Rows[0]["is_success"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_success"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_success"].ToString().ToLower() == "true"))
                    {
                        model.is_success = true;
                    }
                    else
                    {
                        model.is_success = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["created"].ToString() != "")
                {
                    model.created = DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["modified"].ToString() != "")
                {
                    model.modified = DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
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
        public DataSet GetM_ShippingInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_ShippingInfoID,m_TradeInfoID,tid,seller_nick,buyer_nick,delivery_start,delivery_end,out_sid,item_title,receiver_name,receiver_phone,receiver_mobile,status,type,freight_payer,seller_confirm,company_name,is_success,created,modified ");
            strSql.Append(" FROM tb_M_ShippingInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_ShippingInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_ShippingInfoID,m_TradeInfoID,tid,seller_nick,buyer_nick,delivery_start,delivery_end,out_sid,item_title,receiver_name,receiver_phone,receiver_mobile,status,type,freight_payer,seller_confirm,company_name,is_success,created,modified ");
            strSql.Append(" FROM tb_M_ShippingInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetM_ShippingInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_ShippingInfo";
            parameters[1].Value = "M_ShippingInfoID";
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

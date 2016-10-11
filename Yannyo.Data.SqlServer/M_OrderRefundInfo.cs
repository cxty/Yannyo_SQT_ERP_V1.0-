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
	/// <summary>
	/// 数据访问类M_OrderRefundInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  退款信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_OrderRefundInfo(int m_ConfigInfoID, int num_iid, int refund_id, int tid, int oid, string alipay_no)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_OrderRefundInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and num_iid=@num_iid and refund_id=@refund_id and tid=@tid and oid=@oid and alipay_no=@alipay_no");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt),
                                        new SqlParameter("@refund_id", SqlDbType.BigInt),
                                        new SqlParameter("@tid", SqlDbType.BigInt),
                                        new SqlParameter("@oid", SqlDbType.BigInt),
                                        new SqlParameter("@alipay_no", SqlDbType.VarChar,50)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = num_iid;
            parameters[2].Value = refund_id;
            parameters[3].Value = tid;
            parameters[4].Value = oid;
            parameters[5].Value = alipay_no;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_OrderRefundInfo(M_OrderRefundInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_OrderRefundInfo(");
			strSql.Append("m_ConfigInfoID,num_iid,refund_id,tid,oid,alipay_no,total_fee,buyer_nick,seller_nick,created,modified,order_status,status,good_status,has_good_return,refund_fee,payment,reason,m_desc,title,price,num,good_return_time,company_name,sid,address,shipping_type)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@num_iid,@refund_id,@tid,@oid,@alipay_no,@total_fee,@buyer_nick,@seller_nick,@created,@modified,@order_status,@status,@good_status,@has_good_return,@refund_fee,@payment,@reason,@m_desc,@title,@price,@num,@good_return_time,@company_name,@sid,@address,@shipping_type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@refund_id", SqlDbType.BigInt),
					new SqlParameter("@tid", SqlDbType.BigInt),
					new SqlParameter("@oid", SqlDbType.BigInt),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@order_status", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@good_status", SqlDbType.VarChar,50),
					new SqlParameter("@has_good_return", SqlDbType.Bit,1),
					new SqlParameter("@refund_fee", SqlDbType.Money,8),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@reason", SqlDbType.VarChar,50),
					new SqlParameter("@m_desc", SqlDbType.VarChar,512),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@good_return_time", SqlDbType.DateTime),
					new SqlParameter("@company_name", SqlDbType.VarChar,50),
					new SqlParameter("@sid", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,512),
					new SqlParameter("@shipping_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.num_iid;
			parameters[2].Value = model.refund_id;
			parameters[3].Value = model.tid;
			parameters[4].Value = model.oid;
			parameters[5].Value = model.alipay_no;
			parameters[6].Value = model.total_fee;
			parameters[7].Value = model.buyer_nick;
			parameters[8].Value = model.seller_nick;
			parameters[9].Value = model.created;
			parameters[10].Value = model.modified;
			parameters[11].Value = model.order_status;
			parameters[12].Value = model.status;
			parameters[13].Value = model.good_status;
			parameters[14].Value = model.has_good_return;
			parameters[15].Value = model.refund_fee;
			parameters[16].Value = model.payment;
			parameters[17].Value = model.reason;
			parameters[18].Value = model.m_desc;
			parameters[19].Value = model.title;
			parameters[20].Value = model.price;
			parameters[21].Value = model.num;
			parameters[22].Value = model.good_return_time;
			parameters[23].Value = model.company_name;
			parameters[24].Value = model.sid;
			parameters[25].Value = model.address;
			parameters[26].Value = model.shipping_type;

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
		public void UpdateM_OrderRefundInfo(M_OrderRefundInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_OrderRefundInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("refund_id=@refund_id,");
			strSql.Append("tid=@tid,");
			strSql.Append("oid=@oid,");
			strSql.Append("alipay_no=@alipay_no,");
			strSql.Append("total_fee=@total_fee,");
			strSql.Append("buyer_nick=@buyer_nick,");
			strSql.Append("seller_nick=@seller_nick,");
			strSql.Append("created=@created,");
			strSql.Append("modified=@modified,");
			strSql.Append("order_status=@order_status,");
			strSql.Append("status=@status,");
			strSql.Append("good_status=@good_status,");
			strSql.Append("has_good_return=@has_good_return,");
			strSql.Append("refund_fee=@refund_fee,");
			strSql.Append("payment=@payment,");
			strSql.Append("reason=@reason,");
			strSql.Append("m_desc=@m_desc,");
			strSql.Append("title=@title,");
			strSql.Append("price=@price,");
			strSql.Append("num=@num,");
			strSql.Append("good_return_time=@good_return_time,");
			strSql.Append("company_name=@company_name,");
			strSql.Append("sid=@sid,");
			strSql.Append("address=@address,");
			strSql.Append("shipping_type=@shipping_type");
			strSql.Append(" where m_OrderRefundInfoID=@m_OrderRefundInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderRefundInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@refund_id", SqlDbType.BigInt),
					new SqlParameter("@tid", SqlDbType.BigInt),
					new SqlParameter("@oid", SqlDbType.BigInt),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@order_status", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@good_status", SqlDbType.VarChar,50),
					new SqlParameter("@has_good_return", SqlDbType.Bit,1),
					new SqlParameter("@refund_fee", SqlDbType.Money,8),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@reason", SqlDbType.VarChar,50),
					new SqlParameter("@m_desc", SqlDbType.VarChar,512),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@good_return_time", SqlDbType.DateTime),
					new SqlParameter("@company_name", SqlDbType.VarChar,50),
					new SqlParameter("@sid", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,512),
					new SqlParameter("@shipping_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_OrderRefundInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.num_iid;
			parameters[3].Value = model.refund_id;
			parameters[4].Value = model.tid;
			parameters[5].Value = model.oid;
			parameters[6].Value = model.alipay_no;
			parameters[7].Value = model.total_fee;
			parameters[8].Value = model.buyer_nick;
			parameters[9].Value = model.seller_nick;
			parameters[10].Value = model.created;
			parameters[11].Value = model.modified;
			parameters[12].Value = model.order_status;
			parameters[13].Value = model.status;
			parameters[14].Value = model.good_status;
			parameters[15].Value = model.has_good_return;
			parameters[16].Value = model.refund_fee;
			parameters[17].Value = model.payment;
			parameters[18].Value = model.reason;
			parameters[19].Value = model.m_desc;
			parameters[20].Value = model.title;
			parameters[21].Value = model.price;
			parameters[22].Value = model.num;
			parameters[23].Value = model.good_return_time;
			parameters[24].Value = model.company_name;
			parameters[25].Value = model.sid;
			parameters[26].Value = model.address;
			parameters[27].Value = model.shipping_type;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_OrderRefundInfo(int m_OrderRefundInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_OrderRefundInfo ");
			strSql.Append(" where m_OrderRefundInfoID=@m_OrderRefundInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderRefundInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_OrderRefundInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_OrderRefundInfo GetM_OrderRefundInfoModel(int m_OrderRefundInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_OrderRefundInfoID,m_ConfigInfoID,num_iid,refund_id,tid,oid,alipay_no,total_fee,buyer_nick,seller_nick,created,modified,order_status,status,good_status,has_good_return,refund_fee,payment,reason,m_desc,title,price,num,good_return_time,company_name,sid,address,shipping_type from tb_M_OrderRefundInfo ");
			strSql.Append(" where m_OrderRefundInfoID=@m_OrderRefundInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderRefundInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_OrderRefundInfoID;

			M_OrderRefundInfo model=new M_OrderRefundInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_OrderRefundInfoID"].ToString()!="")
				{
					model.m_OrderRefundInfoID=int.Parse(ds.Tables[0].Rows[0]["m_OrderRefundInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=int.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["refund_id"].ToString()!="")
				{
					model.refund_id=int.Parse(ds.Tables[0].Rows[0]["refund_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tid"].ToString()!="")
				{
					model.tid=int.Parse(ds.Tables[0].Rows[0]["tid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["oid"].ToString()!="")
				{
					model.oid=int.Parse(ds.Tables[0].Rows[0]["oid"].ToString());
				}
				model.alipay_no=ds.Tables[0].Rows[0]["alipay_no"].ToString();
				if(ds.Tables[0].Rows[0]["total_fee"].ToString()!="")
				{
					model.total_fee=decimal.Parse(ds.Tables[0].Rows[0]["total_fee"].ToString());
				}
				model.buyer_nick=ds.Tables[0].Rows[0]["buyer_nick"].ToString();
				model.seller_nick=ds.Tables[0].Rows[0]["seller_nick"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				model.order_status=ds.Tables[0].Rows[0]["order_status"].ToString();
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
				model.good_status=ds.Tables[0].Rows[0]["good_status"].ToString();
				if(ds.Tables[0].Rows[0]["has_good_return"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_good_return"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_good_return"].ToString().ToLower()=="true"))
					{
						model.has_good_return=true;
					}
					else
					{
						model.has_good_return=false;
					}
				}
				if(ds.Tables[0].Rows[0]["refund_fee"].ToString()!="")
				{
					model.refund_fee=decimal.Parse(ds.Tables[0].Rows[0]["refund_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["payment"].ToString()!="")
				{
					model.payment=decimal.Parse(ds.Tables[0].Rows[0]["payment"].ToString());
				}
				model.reason=ds.Tables[0].Rows[0]["reason"].ToString();
				model.m_desc=ds.Tables[0].Rows[0]["m_desc"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["good_return_time"].ToString()!="")
				{
					model.good_return_time=DateTime.Parse(ds.Tables[0].Rows[0]["good_return_time"].ToString());
				}
				model.company_name=ds.Tables[0].Rows[0]["company_name"].ToString();
				model.sid=ds.Tables[0].Rows[0]["sid"].ToString();
				model.address=ds.Tables[0].Rows[0]["address"].ToString();
				model.shipping_type=ds.Tables[0].Rows[0]["shipping_type"].ToString();
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
		public DataSet GetM_OrderRefundInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_OrderRefundInfoID,m_ConfigInfoID,num_iid,refund_id,tid,oid,alipay_no,total_fee,buyer_nick,seller_nick,created,modified,order_status,status,good_status,has_good_return,refund_fee,payment,reason,m_desc,title,price,num,good_return_time,company_name,sid,address,shipping_type ");
			strSql.Append(" FROM tb_M_OrderRefundInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_OrderRefundInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_OrderRefundInfoID,m_ConfigInfoID,num_iid,refund_id,tid,oid,alipay_no,total_fee,buyer_nick,seller_nick,created,modified,order_status,status,good_status,has_good_return,refund_fee,payment,reason,m_desc,title,price,num,good_return_time,company_name,sid,address,shipping_type ");
			strSql.Append(" FROM tb_M_OrderRefundInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetM_OrderRefundInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_OrderRefundInfo";
			parameters[1].Value = "M_OrderRefundInfoID";
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
		#endregion
	}
}


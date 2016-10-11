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
	/// 数据访问类M_OrderInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  订单信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_OrderInfo(int m_ConfigInfoID, int m_TradeInfoID, int num_iid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_OrderInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_TradeInfoID=@m_TradeInfoID and num_iid=@num_iid ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_TradeInfoID;
            parameters[2].Value = num_iid;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_OrderInfo(M_OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_OrderInfo(");
			strSql.Append("m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_TradeInfoID,@num_iid,@total_fee,@discount_fee,@adjust_fee,@sku_id,@sku_properties_name,@item_meal_name,@num,@title,@price,@pic_path,@seller_nick,@buyer_nick,@created,@refund_status,@oid,@outer_iid,@outer_sku_id,@payment,@status,@snapshot_url,@snapshot,@timeout_action_time,@buyer_rate,@seller_rate,@refund_id,@seller_type,@modified,@cid,@is_oversold)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@adjust_fee", SqlDbType.Money,8),
					new SqlParameter("@sku_id", SqlDbType.VarChar,50),
					new SqlParameter("@sku_properties_name", SqlDbType.VarChar,512),
					new SqlParameter("@item_meal_name", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,512),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@refund_status", SqlDbType.VarChar,50),
					new SqlParameter("@oid", SqlDbType.BigInt),
					new SqlParameter("@outer_iid", SqlDbType.VarChar,50),
					new SqlParameter("@outer_sku_id", SqlDbType.VarChar,50),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@snapshot_url", SqlDbType.VarChar,512),
					new SqlParameter("@snapshot", SqlDbType.VarChar,1024),
					new SqlParameter("@timeout_action_time", SqlDbType.DateTime),
					new SqlParameter("@buyer_rate", SqlDbType.Bit,1),
					new SqlParameter("@seller_rate", SqlDbType.Bit,1),
					new SqlParameter("@refund_id", SqlDbType.BigInt),
					new SqlParameter("@seller_type", SqlDbType.VarChar,50),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@cid", SqlDbType.BigInt),
					new SqlParameter("@is_oversold", SqlDbType.Bit,1)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_TradeInfoID;
			parameters[2].Value = model.num_iid;
			parameters[3].Value = model.total_fee;
			parameters[4].Value = model.discount_fee;
			parameters[5].Value = model.adjust_fee;
			parameters[6].Value = model.sku_id;
			parameters[7].Value = model.sku_properties_name;
			parameters[8].Value = model.item_meal_name;
			parameters[9].Value = model.num;
			parameters[10].Value = model.title;
			parameters[11].Value = model.price;
			parameters[12].Value = model.pic_path;
			parameters[13].Value = model.seller_nick;
			parameters[14].Value = model.buyer_nick;
			parameters[15].Value = model.created;
			parameters[16].Value = model.refund_status;
			parameters[17].Value = model.oid;
			parameters[18].Value = model.outer_iid;
			parameters[19].Value = model.outer_sku_id;
			parameters[20].Value = model.payment;
			parameters[21].Value = model.status;
			parameters[22].Value = model.snapshot_url;
			parameters[23].Value = model.snapshot;
			parameters[24].Value = model.timeout_action_time;
			parameters[25].Value = model.buyer_rate;
			parameters[26].Value = model.seller_rate;
			parameters[27].Value = model.refund_id;
			parameters[28].Value = model.seller_type;
			parameters[29].Value = model.modified;
			parameters[30].Value = model.cid;
			parameters[31].Value = model.is_oversold;

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
		public void UpdateM_OrderInfo(M_OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_OrderInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_TradeInfoID=@m_TradeInfoID,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("total_fee=@total_fee,");
			strSql.Append("discount_fee=@discount_fee,");
			strSql.Append("adjust_fee=@adjust_fee,");
			strSql.Append("sku_id=@sku_id,");
			strSql.Append("sku_properties_name=@sku_properties_name,");
			strSql.Append("item_meal_name=@item_meal_name,");
			strSql.Append("num=@num,");
			strSql.Append("title=@title,");
			strSql.Append("price=@price,");
			strSql.Append("pic_path=@pic_path,");
			strSql.Append("seller_nick=@seller_nick,");
			strSql.Append("buyer_nick=@buyer_nick,");
			strSql.Append("created=@created,");
			strSql.Append("refund_status=@refund_status,");
			strSql.Append("oid=@oid,");
			strSql.Append("outer_iid=@outer_iid,");
			strSql.Append("outer_sku_id=@outer_sku_id,");
			strSql.Append("payment=@payment,");
			strSql.Append("status=@status,");
			strSql.Append("snapshot_url=@snapshot_url,");
			strSql.Append("snapshot=@snapshot,");
			strSql.Append("timeout_action_time=@timeout_action_time,");
			strSql.Append("buyer_rate=@buyer_rate,");
			strSql.Append("seller_rate=@seller_rate,");
			strSql.Append("refund_id=@refund_id,");
			strSql.Append("seller_type=@seller_type,");
			strSql.Append("modified=@modified,");
			strSql.Append("cid=@cid,");
			strSql.Append("is_oversold=@is_oversold");
			strSql.Append(" where m_OrderInfoID=@m_OrderInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@adjust_fee", SqlDbType.Money,8),
					new SqlParameter("@sku_id", SqlDbType.VarChar,50),
					new SqlParameter("@sku_properties_name", SqlDbType.VarChar,512),
					new SqlParameter("@item_meal_name", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,512),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@refund_status", SqlDbType.VarChar,50),
					new SqlParameter("@oid", SqlDbType.BigInt),
					new SqlParameter("@outer_iid", SqlDbType.VarChar,50),
					new SqlParameter("@outer_sku_id", SqlDbType.VarChar,50),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@snapshot_url", SqlDbType.VarChar,512),
					new SqlParameter("@snapshot", SqlDbType.VarChar,1024),
					new SqlParameter("@timeout_action_time", SqlDbType.DateTime),
					new SqlParameter("@buyer_rate", SqlDbType.Bit,1),
					new SqlParameter("@seller_rate", SqlDbType.Bit,1),
					new SqlParameter("@refund_id", SqlDbType.BigInt),
					new SqlParameter("@seller_type", SqlDbType.VarChar,50),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@cid", SqlDbType.BigInt),
					new SqlParameter("@is_oversold", SqlDbType.Bit,1)};
			parameters[0].Value = model.m_OrderInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_TradeInfoID;
			parameters[3].Value = model.num_iid;
			parameters[4].Value = model.total_fee;
			parameters[5].Value = model.discount_fee;
			parameters[6].Value = model.adjust_fee;
			parameters[7].Value = model.sku_id;
			parameters[8].Value = model.sku_properties_name;
			parameters[9].Value = model.item_meal_name;
			parameters[10].Value = model.num;
			parameters[11].Value = model.title;
			parameters[12].Value = model.price;
			parameters[13].Value = model.pic_path;
			parameters[14].Value = model.seller_nick;
			parameters[15].Value = model.buyer_nick;
			parameters[16].Value = model.created;
			parameters[17].Value = model.refund_status;
			parameters[18].Value = model.oid;
			parameters[19].Value = model.outer_iid;
			parameters[20].Value = model.outer_sku_id;
			parameters[21].Value = model.payment;
			parameters[22].Value = model.status;
			parameters[23].Value = model.snapshot_url;
			parameters[24].Value = model.snapshot;
			parameters[25].Value = model.timeout_action_time;
			parameters[26].Value = model.buyer_rate;
			parameters[27].Value = model.seller_rate;
			parameters[28].Value = model.refund_id;
			parameters[29].Value = model.seller_type;
			parameters[30].Value = model.modified;
			parameters[31].Value = model.cid;
			parameters[32].Value = model.is_oversold;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_OrderInfo(int m_OrderInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_OrderInfo ");
			strSql.Append(" where m_OrderInfoID=@m_OrderInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_OrderInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_OrderInfo GetM_OrderInfoModel(int m_OrderInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_OrderInfoID,m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold from tb_M_OrderInfo ");
			strSql.Append(" where m_OrderInfoID=@m_OrderInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_OrderInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_OrderInfoID;

			M_OrderInfo model=new M_OrderInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_OrderInfoID"].ToString()!="")
				{
					model.m_OrderInfoID=int.Parse(ds.Tables[0].Rows[0]["m_OrderInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString()!="")
				{
					model.m_TradeInfoID=int.Parse(ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=int.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["total_fee"].ToString()!="")
				{
					model.total_fee=decimal.Parse(ds.Tables[0].Rows[0]["total_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["discount_fee"].ToString()!="")
				{
					model.discount_fee=decimal.Parse(ds.Tables[0].Rows[0]["discount_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["adjust_fee"].ToString()!="")
				{
					model.adjust_fee=decimal.Parse(ds.Tables[0].Rows[0]["adjust_fee"].ToString());
				}
				model.sku_id=ds.Tables[0].Rows[0]["sku_id"].ToString();
				model.sku_properties_name=ds.Tables[0].Rows[0]["sku_properties_name"].ToString();
				model.item_meal_name=ds.Tables[0].Rows[0]["item_meal_name"].ToString();
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				model.pic_path=ds.Tables[0].Rows[0]["pic_path"].ToString();
				model.seller_nick=ds.Tables[0].Rows[0]["seller_nick"].ToString();
				model.buyer_nick=ds.Tables[0].Rows[0]["buyer_nick"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				model.refund_status=ds.Tables[0].Rows[0]["refund_status"].ToString();
                if (ds.Tables[0].Rows[0]["oid"].ToString() != "")
                {
                    model.oid = Convert.ToInt64(ds.Tables[0].Rows[0]["oid"].ToString());
                }
				model.outer_iid=ds.Tables[0].Rows[0]["outer_iid"].ToString();
				model.outer_sku_id=ds.Tables[0].Rows[0]["outer_sku_id"].ToString();
				if(ds.Tables[0].Rows[0]["payment"].ToString()!="")
				{
					model.payment=decimal.Parse(ds.Tables[0].Rows[0]["payment"].ToString());
				}
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
				model.snapshot_url=ds.Tables[0].Rows[0]["snapshot_url"].ToString();
				model.snapshot=ds.Tables[0].Rows[0]["snapshot"].ToString();
				if(ds.Tables[0].Rows[0]["timeout_action_time"].ToString()!="")
				{
					model.timeout_action_time=DateTime.Parse(ds.Tables[0].Rows[0]["timeout_action_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["buyer_rate"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["buyer_rate"].ToString()=="1")||(ds.Tables[0].Rows[0]["buyer_rate"].ToString().ToLower()=="true"))
					{
						model.buyer_rate=true;
					}
					else
					{
						model.buyer_rate=false;
					}
				}
				if(ds.Tables[0].Rows[0]["seller_rate"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["seller_rate"].ToString()=="1")||(ds.Tables[0].Rows[0]["seller_rate"].ToString().ToLower()=="true"))
					{
						model.seller_rate=true;
					}
					else
					{
						model.seller_rate=false;
					}
				}
                if (ds.Tables[0].Rows[0]["refund_id"].ToString() != "")
                {
                    model.refund_id =long.Parse( ds.Tables[0].Rows[0]["refund_id"].ToString());
                }
				model.seller_type=ds.Tables[0].Rows[0]["seller_type"].ToString();
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cid"].ToString()!="")
				{
					model.cid=int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["is_oversold"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_oversold"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_oversold"].ToString().ToLower()=="true"))
					{
						model.is_oversold=true;
					}
					else
					{
						model.is_oversold=false;
					}
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
		public DataSet GetM_OrderInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select m_OrderInfoID,m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold,(select pName from tbProductsInfo where ProductsID=outer_iid) as ProductsName,(select pBarcode from tbProductsInfo where ProductsID=outer_iid) as ProductsBarcode ");
			strSql.Append(" FROM tb_M_OrderInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_OrderInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" m_OrderInfoID,m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold,(select pName from tbProductsInfo where ProductsID=outer_iid) as ProductsName,(select pBarcode from tbProductsInfo where ProductsID=outer_iid) as ProductsBarcode ");
			strSql.Append(" FROM tb_M_OrderInfo ");
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
		public DataTable GetM_OrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_OrderInfo";
			parameters[1].Value = "M_OrderInfoID";
			parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select pName from tbProductsInfo where ProductsID=outer_iid) as ProductsName,(select pBarcode from tbProductsInfo where ProductsID=outer_iid) as ProductsBarcode";
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


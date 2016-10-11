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
	/// 数据访问类M_GoodsExtraInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  商品扩展信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_GoodsExtraInfo(int m_GoodsID, int eid, int num_iid, string title)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_GoodsExtraInfo");
            strSql.Append(" where m_GoodsID=@m_GoodsID and eid=@eid and num_iid=@num_iid and title=@title");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
                                        new SqlParameter("@eid", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.Int,4),
                                        new SqlParameter("@title", SqlDbType.VarChar,100)};
            parameters[0].Value = m_GoodsID;
            parameters[1].Value = eid;
            parameters[2].Value = num_iid;
            parameters[3].Value = title;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_GoodsExtraInfo(M_GoodsExtraInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_GoodsExtraInfo(");
			strSql.Append("m_GoodsID,eid,num_iid,title,m_desc,feature,memo,type,reserve_price,created,modified,list_time,delist_time,approve_status,pic_url,options,item_pic_url,item_options,item_num)");
			strSql.Append(" values (");
			strSql.Append("@m_GoodsID,@eid,@num_iid,@title,@m_desc,@feature,@memo,@type,@reserve_price,@created,@modified,@list_time,@delist_time,@approve_status,@pic_url,@options,@item_pic_url,@item_options,@item_num)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
					new SqlParameter("@eid", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@m_desc", SqlDbType.VarChar,1024),
					new SqlParameter("@feature", SqlDbType.VarChar,512),
					new SqlParameter("@memo", SqlDbType.VarChar,512),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@reserve_price", SqlDbType.Money,8),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@list_time", SqlDbType.DateTime),
					new SqlParameter("@delist_time", SqlDbType.DateTime),
					new SqlParameter("@approve_status", SqlDbType.VarChar,50),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@options", SqlDbType.Int,4),
					new SqlParameter("@item_pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@item_options", SqlDbType.Int,4),
					new SqlParameter("@item_num", SqlDbType.Int,4)};
			parameters[0].Value = model.m_GoodsID;
			parameters[1].Value = model.eid;
			parameters[2].Value = model.num_iid;
			parameters[3].Value = model.title;
			parameters[4].Value = model.m_desc;
			parameters[5].Value = model.feature;
			parameters[6].Value = model.memo;
			parameters[7].Value = model.type;
			parameters[8].Value = model.reserve_price;
			parameters[9].Value = model.created;
			parameters[10].Value = model.modified;
			parameters[11].Value = model.list_time;
			parameters[12].Value = model.delist_time;
			parameters[13].Value = model.approve_status;
			parameters[14].Value = model.pic_url;
			parameters[15].Value = model.options;
			parameters[16].Value = model.item_pic_url;
			parameters[17].Value = model.item_options;
			parameters[18].Value = model.item_num;

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
		public void UpdateM_GoodsExtraInfo(M_GoodsExtraInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_GoodsExtraInfo set ");
			strSql.Append("m_GoodsID=@m_GoodsID,");
			strSql.Append("eid=@eid,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("title=@title,");
			strSql.Append("m_desc=@m_desc,");
			strSql.Append("feature=@feature,");
			strSql.Append("memo=@memo,");
			strSql.Append("type=@type,");
			strSql.Append("reserve_price=@reserve_price,");
			strSql.Append("created=@created,");
			strSql.Append("modified=@modified,");
			strSql.Append("list_time=@list_time,");
			strSql.Append("delist_time=@delist_time,");
			strSql.Append("approve_status=@approve_status,");
			strSql.Append("pic_url=@pic_url,");
			strSql.Append("options=@options,");
			strSql.Append("item_pic_url=@item_pic_url,");
			strSql.Append("item_options=@item_options,");
			strSql.Append("item_num=@item_num");
			strSql.Append(" where m_GoodsExtraInfoID=@m_GoodsExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsExtraInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
					new SqlParameter("@eid", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@m_desc", SqlDbType.VarChar,1024),
					new SqlParameter("@feature", SqlDbType.VarChar,512),
					new SqlParameter("@memo", SqlDbType.VarChar,512),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@reserve_price", SqlDbType.Money,8),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@list_time", SqlDbType.DateTime),
					new SqlParameter("@delist_time", SqlDbType.DateTime),
					new SqlParameter("@approve_status", SqlDbType.VarChar,50),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@options", SqlDbType.Int,4),
					new SqlParameter("@item_pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@item_options", SqlDbType.Int,4),
					new SqlParameter("@item_num", SqlDbType.Int,4)};
			parameters[0].Value = model.m_GoodsExtraInfoID;
			parameters[1].Value = model.m_GoodsID;
			parameters[2].Value = model.eid;
			parameters[3].Value = model.num_iid;
			parameters[4].Value = model.title;
			parameters[5].Value = model.m_desc;
			parameters[6].Value = model.feature;
			parameters[7].Value = model.memo;
			parameters[8].Value = model.type;
			parameters[9].Value = model.reserve_price;
			parameters[10].Value = model.created;
			parameters[11].Value = model.modified;
			parameters[12].Value = model.list_time;
			parameters[13].Value = model.delist_time;
			parameters[14].Value = model.approve_status;
			parameters[15].Value = model.pic_url;
			parameters[16].Value = model.options;
			parameters[17].Value = model.item_pic_url;
			parameters[18].Value = model.item_options;
			parameters[19].Value = model.item_num;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_GoodsExtraInfo(int m_GoodsExtraInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_GoodsExtraInfo ");
			strSql.Append(" where m_GoodsExtraInfoID=@m_GoodsExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsExtraInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsExtraInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_GoodsExtraInfo GetM_GoodsExtraInfoModel(int m_GoodsExtraInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_GoodsExtraInfoID,m_GoodsID,eid,num_iid,title,m_desc,feature,memo,type,reserve_price,created,modified,list_time,delist_time,approve_status,pic_url,options,item_pic_url,item_options,item_num from tb_M_GoodsExtraInfo ");
			strSql.Append(" where m_GoodsExtraInfoID=@m_GoodsExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsExtraInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsExtraInfoID;

			M_GoodsExtraInfo model=new M_GoodsExtraInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_GoodsExtraInfoID"].ToString()!="")
				{
					model.m_GoodsExtraInfoID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsExtraInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_GoodsID"].ToString()!="")
				{
					model.m_GoodsID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["eid"].ToString()!="")
				{
					model.eid=int.Parse(ds.Tables[0].Rows[0]["eid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=int.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.m_desc=ds.Tables[0].Rows[0]["m_desc"].ToString();
				model.feature=ds.Tables[0].Rows[0]["feature"].ToString();
				model.memo=ds.Tables[0].Rows[0]["memo"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["reserve_price"].ToString()!="")
				{
					model.reserve_price=decimal.Parse(ds.Tables[0].Rows[0]["reserve_price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["list_time"].ToString()!="")
				{
					model.list_time=DateTime.Parse(ds.Tables[0].Rows[0]["list_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["delist_time"].ToString()!="")
				{
					model.delist_time=DateTime.Parse(ds.Tables[0].Rows[0]["delist_time"].ToString());
				}
				model.approve_status=ds.Tables[0].Rows[0]["approve_status"].ToString();
				model.pic_url=ds.Tables[0].Rows[0]["pic_url"].ToString();
				if(ds.Tables[0].Rows[0]["options"].ToString()!="")
				{
					model.options=int.Parse(ds.Tables[0].Rows[0]["options"].ToString());
				}
				model.item_pic_url=ds.Tables[0].Rows[0]["item_pic_url"].ToString();
				if(ds.Tables[0].Rows[0]["item_options"].ToString()!="")
				{
					model.item_options=int.Parse(ds.Tables[0].Rows[0]["item_options"].ToString());
				}
				if(ds.Tables[0].Rows[0]["item_num"].ToString()!="")
				{
					model.item_num=int.Parse(ds.Tables[0].Rows[0]["item_num"].ToString());
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
		public DataSet GetM_GoodsExtraInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_GoodsExtraInfoID,m_GoodsID,eid,num_iid,title,m_desc,feature,memo,type,reserve_price,created,modified,list_time,delist_time,approve_status,pic_url,options,item_pic_url,item_options,item_num ");
			strSql.Append(" FROM tb_M_GoodsExtraInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_GoodsExtraInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_GoodsExtraInfoID,m_GoodsID,eid,num_iid,title,m_desc,feature,memo,type,reserve_price,created,modified,list_time,delist_time,approve_status,pic_url,options,item_pic_url,item_options,item_num ");
			strSql.Append(" FROM tb_M_GoodsExtraInfo ");
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
		public DataTable GetM_GoodsExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_GoodsExtraInfo";
			parameters[1].Value = "M_GoodsExtraInfoID";
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


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
	/// 数据访问类M_ProductInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  产品结构信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_ProductInfo(int m_ConfigInfoID, int ProductsID, long product_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_ProductInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID and product_id=@product_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@product_id", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = product_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_ProductInfo(M_ProductInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_ProductInfo(");
			strSql.Append("m_ConfigInfoID,ProductsID,product_id,outer_id,created,tsc,cid,cat_name,props,props_str,binds_str,sale_props_str,name,binds,sale_props,price,m_desc,pic_url,modified,status,collect_num,m_level,pic_path,vertical_market,customer_props,property_alias)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@ProductsID,@product_id,@outer_id,@created,@tsc,@cid,@cat_name,@props,@props_str,@binds_str,@sale_props_str,@name,@binds,@sale_props,@price,@m_desc,@pic_url,@modified,@status,@collect_num,@m_level,@pic_path,@vertical_market,@customer_props,@property_alias)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@tsc", SqlDbType.VarChar,50),
					new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@cat_name", SqlDbType.VarChar,128),
					new SqlParameter("@props", SqlDbType.VarChar,512),
					new SqlParameter("@props_str", SqlDbType.VarChar,512),
					new SqlParameter("@binds_str", SqlDbType.VarChar,512),
					new SqlParameter("@sale_props_str", SqlDbType.VarChar,512),
					new SqlParameter("@name", SqlDbType.VarChar,128),
					new SqlParameter("@binds", SqlDbType.VarChar,512),
					new SqlParameter("@sale_props", SqlDbType.VarChar,512),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@m_desc", SqlDbType.NText),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@collect_num", SqlDbType.Int,4),
					new SqlParameter("@m_level", SqlDbType.Int,4),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@vertical_market", SqlDbType.Int,4),
					new SqlParameter("@customer_props", SqlDbType.VarChar,512),
					new SqlParameter("@property_alias", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.ProductsID;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.outer_id;
			parameters[4].Value = model.created;
			parameters[5].Value = model.tsc;
			parameters[6].Value = model.cid;
			parameters[7].Value = model.cat_name;
			parameters[8].Value = model.props;
			parameters[9].Value = model.props_str;
			parameters[10].Value = model.binds_str;
			parameters[11].Value = model.sale_props_str;
			parameters[12].Value = model.name;
			parameters[13].Value = model.binds;
			parameters[14].Value = model.sale_props;
			parameters[15].Value = model.price;
			parameters[16].Value = model.m_desc;
			parameters[17].Value = model.pic_url;
			parameters[18].Value = model.modified;
			parameters[19].Value = model.status;
			parameters[20].Value = model.collect_num;
			parameters[21].Value = model.m_level;
			parameters[22].Value = model.pic_path;
			parameters[23].Value = model.vertical_market;
			parameters[24].Value = model.customer_props;
			parameters[25].Value = model.property_alias;

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
		public void UpdateM_ProductInfo(M_ProductInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_ProductInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("outer_id=@outer_id,");
			strSql.Append("created=@created,");
			strSql.Append("tsc=@tsc,");
			strSql.Append("cid=@cid,");
			strSql.Append("cat_name=@cat_name,");
			strSql.Append("props=@props,");
			strSql.Append("props_str=@props_str,");
			strSql.Append("binds_str=@binds_str,");
			strSql.Append("sale_props_str=@sale_props_str,");
			strSql.Append("name=@name,");
			strSql.Append("binds=@binds,");
			strSql.Append("sale_props=@sale_props,");
			strSql.Append("price=@price,");
			strSql.Append("m_desc=@m_desc,");
			strSql.Append("pic_url=@pic_url,");
			strSql.Append("modified=@modified,");
			strSql.Append("status=@status,");
			strSql.Append("collect_num=@collect_num,");
			strSql.Append("m_level=@m_level,");
			strSql.Append("pic_path=@pic_path,");
			strSql.Append("vertical_market=@vertical_market,");
			strSql.Append("customer_props=@customer_props,");
			strSql.Append("property_alias=@property_alias");
			strSql.Append(" where m_ProductInfoID=@m_ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@tsc", SqlDbType.VarChar,50),
					new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@cat_name", SqlDbType.VarChar,128),
					new SqlParameter("@props", SqlDbType.VarChar,512),
					new SqlParameter("@props_str", SqlDbType.VarChar,512),
					new SqlParameter("@binds_str", SqlDbType.VarChar,512),
					new SqlParameter("@sale_props_str", SqlDbType.VarChar,512),
					new SqlParameter("@name", SqlDbType.VarChar,128),
					new SqlParameter("@binds", SqlDbType.VarChar,512),
					new SqlParameter("@sale_props", SqlDbType.VarChar,512),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@m_desc", SqlDbType.NText),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@collect_num", SqlDbType.Int,4),
					new SqlParameter("@m_level", SqlDbType.Int,4),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@vertical_market", SqlDbType.Int,4),
					new SqlParameter("@customer_props", SqlDbType.VarChar,512),
					new SqlParameter("@property_alias", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_ProductInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.ProductsID;
			parameters[3].Value = model.product_id;
			parameters[4].Value = model.outer_id;
			parameters[5].Value = model.created;
			parameters[6].Value = model.tsc;
			parameters[7].Value = model.cid;
			parameters[8].Value = model.cat_name;
			parameters[9].Value = model.props;
			parameters[10].Value = model.props_str;
			parameters[11].Value = model.binds_str;
			parameters[12].Value = model.sale_props_str;
			parameters[13].Value = model.name;
			parameters[14].Value = model.binds;
			parameters[15].Value = model.sale_props;
			parameters[16].Value = model.price;
			parameters[17].Value = model.m_desc;
			parameters[18].Value = model.pic_url;
			parameters[19].Value = model.modified;
			parameters[20].Value = model.status;
			parameters[21].Value = model.collect_num;
			parameters[22].Value = model.m_level;
			parameters[23].Value = model.pic_path;
			parameters[24].Value = model.vertical_market;
			parameters[25].Value = model.customer_props;
			parameters[26].Value = model.property_alias;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_ProductInfo(int m_ProductInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_ProductInfo ");
			strSql.Append(" where m_ProductInfoID=@m_ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ProductInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_ProductInfo GetM_ProductInfoModel(int m_ProductInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_ProductInfoID,m_ConfigInfoID,ProductsID,product_id,outer_id,created,tsc,cid,cat_name,props,props_str,binds_str,sale_props_str,name,binds,sale_props,price,m_desc,pic_url,modified,status,collect_num,m_level,pic_path,vertical_market,customer_props,property_alias from tb_M_ProductInfo ");
			strSql.Append(" where m_ProductInfoID=@m_ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ProductInfoID;

			M_ProductInfo model=new M_ProductInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString()!="")
				{
					model.m_ProductInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductsID"].ToString()!="")
				{
					model.ProductsID=int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=long.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				model.outer_id=ds.Tables[0].Rows[0]["outer_id"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				model.tsc=ds.Tables[0].Rows[0]["tsc"].ToString();
				model.cid=ds.Tables[0].Rows[0]["cid"].ToString();
				model.cat_name=ds.Tables[0].Rows[0]["cat_name"].ToString();
				model.props=ds.Tables[0].Rows[0]["props"].ToString();
				model.props_str=ds.Tables[0].Rows[0]["props_str"].ToString();
				model.binds_str=ds.Tables[0].Rows[0]["binds_str"].ToString();
				model.sale_props_str=ds.Tables[0].Rows[0]["sale_props_str"].ToString();
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.binds=ds.Tables[0].Rows[0]["binds"].ToString();
				model.sale_props=ds.Tables[0].Rows[0]["sale_props"].ToString();
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				model.m_desc=ds.Tables[0].Rows[0]["m_desc"].ToString();
				model.pic_url=ds.Tables[0].Rows[0]["pic_url"].ToString();
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["collect_num"].ToString()!="")
				{
					model.collect_num=int.Parse(ds.Tables[0].Rows[0]["collect_num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_level"].ToString()!="")
				{
					model.m_level=int.Parse(ds.Tables[0].Rows[0]["m_level"].ToString());
				}
				model.pic_path=ds.Tables[0].Rows[0]["pic_path"].ToString();
				if(ds.Tables[0].Rows[0]["vertical_market"].ToString()!="")
				{
					model.vertical_market=int.Parse(ds.Tables[0].Rows[0]["vertical_market"].ToString());
				}
				model.customer_props=ds.Tables[0].Rows[0]["customer_props"].ToString();
				model.property_alias=ds.Tables[0].Rows[0]["property_alias"].ToString();
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
		public DataSet GetM_ProductInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_ProductInfoID,m_ConfigInfoID,ProductsID,product_id,outer_id,created,tsc,cid,cat_name,props,props_str,binds_str,sale_props_str,name,binds,sale_props,price,m_desc,pic_url,modified,status,collect_num,m_level,pic_path,vertical_market,customer_props,property_alias ");
			strSql.Append(" FROM tb_M_ProductInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_ProductInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_ProductInfoID,m_ConfigInfoID,ProductsID,product_id,outer_id,created,tsc,cid,cat_name,props,props_str,binds_str,sale_props_str,name,binds,sale_props,price,m_desc,pic_url,modified,status,collect_num,m_level,pic_path,vertical_market,customer_props,property_alias ");
			strSql.Append(" FROM tb_M_ProductInfo ");
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
		public DataTable GetM_ProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_ProductInfo";
			parameters[1].Value = "M_ProductInfoID";
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


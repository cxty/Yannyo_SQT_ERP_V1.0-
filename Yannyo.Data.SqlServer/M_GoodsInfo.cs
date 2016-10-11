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
	/// 数据访问类M_GoodsInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  商品信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_GoodsInfo(int m_ConfigInfoID, int ProductsID, int m_ProductInfoID, long product_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_GoodsInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID and m_ProductInfoID=@m_ProductInfoID and product_id=@product_id");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@product_id", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = m_ProductInfoID;
            parameters[3].Value = product_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}
        public bool ExistsM_GoodsInfo(int m_ConfigInfoID,  long num_iid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_GoodsInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and num_iid=@num_iid");
            SqlParameter[] parameters = {
                                            new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = num_iid;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        public int ExistsM_GoodsInfoAndGetID(int m_ConfigInfoID, long num_iid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 m_GoodsID from tb_M_GoodsInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and num_iid=@num_iid");
            SqlParameter[] parameters = {
                                            new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = num_iid;
            object o = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (o != null)
            {
                return (int)o;
            }
            else
            {
                return -1;
            }
        }
		
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_GoodsInfo(M_GoodsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("declare @m_GoodsID int;");
			strSql.Append("insert into tb_M_GoodsInfo(");
            strSql.Append("m_ConfigInfoID,ProductsID,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime)");
			strSql.Append(" values (");
            strSql.Append("@m_ConfigInfoID,@ProductsID,@m_ProductInfoID,@product_id,@outer_id,@num_iid,@detail_url,@title,@nick,@type,@props_name,@promoted_service,@cid,@seller_cids,@props,@input_pids,@input_str,@m_desc,@pic_url,@num,@valid_thru,@list_time,@delist_time,@stuff_status,@price,@post_fee,@express_fee,@ems_fee,@has_discount,@freight_payer,@has_invoice,@has_warranty,@has_showcase,@modified,@increment,@approve_status,@postage_id,@auction_point,@property_alias,@is_virtual,@is_taobao,@is_ex,@is_timing,@is_3D,@one_station,@second_kill,@auto_fill,@violation,@created,@cod_postage_id,@sell_promise,@m_IsDeltet,@m_UpdateTime)");
            strSql.Append(";SET @m_GoodsID = SCOPE_IDENTITY();select @m_GoodsID;");

            if (model.skus != null)
            { 
                foreach(M_GoodsSkuInfo sku in model.skus)
                {
                    strSql.Append(" insert into tb_M_GoodsSkuInfo(m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status])");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + sku.sku_id + "," + model.num_iid + ",'" + sku.properties + "'," + sku.quantity + "," + sku.price + "," + model.ProductsID + ",'" + sku.created + "','" + sku.modified + "','" + sku.status + "');");
                }
            }

            if (model.location != null)
            {
                strSql.Append(" insert into tb_M_LocationInfo(m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime)");
                strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID,'" + model.location.zip + "','" + model.location.address + "','" + model.location.city + "','" + model.location.state + "','" + model.location.country + "','" + model.location.district + "',getdate());");
            }

            if (model.item_imgs != null)
            {
                foreach (M_ImgInfo img in model.item_imgs)
                {
                    strSql.Append(" insert into tb_M_ImgInfo(m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,url,position,created,modified)");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID,"+img.m_id+","+img.product_id+",'"+img.url+"',"+img.position+",'"+img.created+"','"+img.modified+"');");
                }
            }

            if (model.prop_imgs != null)
            {
                foreach (M_PropImgInfo propimg in model.prop_imgs)
                {
                    strSql.Append(" insert into tb_M_PropImgInfo(m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified)");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + propimg.m_id + "," + propimg.product_id + ",'"+propimg.position+"','" + propimg.url + "'," + propimg.position + ",'" + propimg.created + "','" + propimg.modified + "');");
                }
            }

            if (model.videos != null)
            {
                foreach (M_VideoInfo video in model.videos)
                {
                     strSql.Append(" insert into tb_M_VideoInfo(m_ConfigInfoID,m_Type,m_ObjID,video_id,url,created,modified,num_iid)");
                     strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + video.video_id + ",'" + video.url + "','" + video.created + "','" + video.modified + "'," + model.num_iid + ");");
                }
            }

			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@detail_url", SqlDbType.VarChar,512),
					new SqlParameter("@title", SqlDbType.VarChar,60),
					new SqlParameter("@nick", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@props_name", SqlDbType.VarChar,1024),
					new SqlParameter("@promoted_service", SqlDbType.VarChar,512),
					new SqlParameter("@cid", SqlDbType.BigInt),
					new SqlParameter("@seller_cids", SqlDbType.VarChar,512),
					new SqlParameter("@props", SqlDbType.VarChar,1024),
					new SqlParameter("@input_pids", SqlDbType.VarChar,1024),
					new SqlParameter("@input_str", SqlDbType.VarChar,1024),
					new SqlParameter("@m_desc", SqlDbType.NText),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@valid_thru", SqlDbType.Int,4),
					new SqlParameter("@list_time", SqlDbType.DateTime),
					new SqlParameter("@delist_time", SqlDbType.DateTime),
					new SqlParameter("@stuff_status", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@post_fee", SqlDbType.Money,8),
					new SqlParameter("@express_fee", SqlDbType.Money,8),
					new SqlParameter("@ems_fee", SqlDbType.Money,8),
					new SqlParameter("@has_discount", SqlDbType.Bit,1),
					new SqlParameter("@freight_payer", SqlDbType.VarChar,50),
					new SqlParameter("@has_invoice", SqlDbType.Bit,1),
					new SqlParameter("@has_warranty", SqlDbType.Bit,1),
					new SqlParameter("@has_showcase", SqlDbType.Bit,1),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@increment", SqlDbType.VarChar,50),
					new SqlParameter("@approve_status", SqlDbType.VarChar,50),
					new SqlParameter("@postage_id", SqlDbType.BigInt),
					new SqlParameter("@auction_point", SqlDbType.Int,4),
					new SqlParameter("@property_alias", SqlDbType.VarChar,50),
					new SqlParameter("@is_virtual", SqlDbType.Bit,1),
					new SqlParameter("@is_taobao", SqlDbType.Bit,1),
					new SqlParameter("@is_ex", SqlDbType.Bit,1),
					new SqlParameter("@is_timing", SqlDbType.Bit,1),
					new SqlParameter("@is_3D", SqlDbType.Bit,1),
					new SqlParameter("@one_station", SqlDbType.Bit,1),
					new SqlParameter("@second_kill", SqlDbType.VarChar,50),
					new SqlParameter("@auto_fill", SqlDbType.VarChar,50),
					new SqlParameter("@violation", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@cod_postage_id", SqlDbType.BigInt),
					new SqlParameter("@sell_promise", SqlDbType.Bit,1),
                                        new SqlParameter("@m_IsDeltet", SqlDbType.Bit,1),
                                        new SqlParameter("@m_UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.ProductsID;
			parameters[2].Value = model.m_ProductInfoID;
			parameters[3].Value = model.product_id;
            parameters[4].Value = model.outer_id == null ? "" : model.outer_id;
			parameters[5].Value = model.num_iid;
            parameters[6].Value = model.detail_url == null ? "" : model.detail_url;
            parameters[7].Value = model.title == null ? "" : model.title;
            parameters[8].Value = model.nick == null ? "" : model.nick;
            parameters[9].Value = model.type == null ? "" : model.type;
            parameters[10].Value = model.props_name == null ? "" : model.props_name;
            parameters[11].Value = model.promoted_service == null ? "" : model.promoted_service;
			parameters[12].Value = model.cid;
            parameters[13].Value = model.seller_cids == null ? "" : model.seller_cids;
            parameters[14].Value = model.props == null ? "" : model.props;
            parameters[15].Value = model.input_pids == null ? "" : model.input_pids;
            parameters[16].Value = model.input_str == null ? "" : model.input_str;
            parameters[17].Value = model.m_desc == null ? "" : model.m_desc;
            parameters[18].Value = model.pic_url == null ? "" : model.pic_url;
			parameters[19].Value = model.num;
			parameters[20].Value = model.valid_thru;
			parameters[21].Value = model.list_time;
			parameters[22].Value = model.delist_time;
            parameters[23].Value = model.stuff_status == null ? "" : model.stuff_status;
			parameters[24].Value = model.price;
			parameters[25].Value = model.post_fee;
			parameters[26].Value = model.express_fee;
			parameters[27].Value = model.ems_fee;
			parameters[28].Value = model.has_discount;
            parameters[29].Value = model.freight_payer == null ? "" : model.freight_payer;
			parameters[30].Value = model.has_invoice;
			parameters[31].Value = model.has_warranty;
			parameters[32].Value = model.has_showcase;
			parameters[33].Value = model.modified;
            parameters[34].Value = model.increment == null ? "" : model.increment;
            parameters[35].Value = model.approve_status == null ? "" : model.approve_status;
			parameters[36].Value = model.postage_id;
			parameters[37].Value = model.auction_point;
            parameters[38].Value = model.property_alias == null ? "" : model.property_alias;
			parameters[39].Value = model.is_virtual;
			parameters[40].Value = model.is_taobao;
			parameters[41].Value = model.is_ex;
			parameters[42].Value = model.is_timing;
			parameters[43].Value = model.is_3D;
			parameters[44].Value = model.one_station;
            parameters[45].Value = model.second_kill == null ? "" : model.second_kill;
            parameters[46].Value = model.auto_fill == null ? "" : model.auto_fill;
			parameters[47].Value = model.violation;
			parameters[48].Value = model.created;
			parameters[49].Value = model.cod_postage_id;
			parameters[50].Value = model.sell_promise;
            parameters[51].Value = model.m_IsDeltet;
            parameters[52].Value = model.m_UpdateTime;

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
		public void UpdateM_GoodsInfo(M_GoodsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_GoodsInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("m_ProductInfoID=@m_ProductInfoID,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("outer_id=@outer_id,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("detail_url=@detail_url,");
			strSql.Append("title=@title,");
			strSql.Append("nick=@nick,");
			strSql.Append("type=@type,");
			strSql.Append("props_name=@props_name,");
			strSql.Append("promoted_service=@promoted_service,");
			strSql.Append("cid=@cid,");
			strSql.Append("seller_cids=@seller_cids,");
			strSql.Append("props=@props,");
			strSql.Append("input_pids=@input_pids,");
			strSql.Append("input_str=@input_str,");
			strSql.Append("m_desc=@m_desc,");
			strSql.Append("pic_url=@pic_url,");
			strSql.Append("num=@num,");
			strSql.Append("valid_thru=@valid_thru,");
			strSql.Append("list_time=@list_time,");
			strSql.Append("delist_time=@delist_time,");
			strSql.Append("stuff_status=@stuff_status,");
			strSql.Append("price=@price,");
			strSql.Append("post_fee=@post_fee,");
			strSql.Append("express_fee=@express_fee,");
			strSql.Append("ems_fee=@ems_fee,");
			strSql.Append("has_discount=@has_discount,");
			strSql.Append("freight_payer=@freight_payer,");
			strSql.Append("has_invoice=@has_invoice,");
			strSql.Append("has_warranty=@has_warranty,");
			strSql.Append("has_showcase=@has_showcase,");
			strSql.Append("modified=@modified,");
			strSql.Append("increment=@increment,");
			strSql.Append("approve_status=@approve_status,");
			strSql.Append("postage_id=@postage_id,");
			strSql.Append("auction_point=@auction_point,");
			strSql.Append("property_alias=@property_alias,");
			strSql.Append("is_virtual=@is_virtual,");
			strSql.Append("is_taobao=@is_taobao,");
			strSql.Append("is_ex=@is_ex,");
			strSql.Append("is_timing=@is_timing,");
			strSql.Append("is_3D=@is_3D,");
			strSql.Append("one_station=@one_station,");
			strSql.Append("second_kill=@second_kill,");
			strSql.Append("auto_fill=@auto_fill,");
			strSql.Append("violation=@violation,");
			strSql.Append("created=@created,");
			strSql.Append("cod_postage_id=@cod_postage_id,");
			strSql.Append("sell_promise=@sell_promise,");
            strSql.Append("m_IsDeltet=@m_IsDeltet,");
            strSql.Append("m_UpdateTime=@m_UpdateTime");
			strSql.Append(" where m_GoodsID=@m_GoodsID ;");

            strSql.Append(" delete tb_M_GoodsSkuInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID;");
            if (model.skus != null)
            {
                
                foreach (M_GoodsSkuInfo sku in model.skus)
                {
                    /*
                    strSql.Append(" if exists(select 0 from tb_M_GoodsSkuInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID and sku_id=" + sku.sku_id + " and num_iid=" + sku.num_iid + ") \r\n");
                    strSql.Append(" begin \r\n");

                    strSql.Append(" update tb_M_GoodsSkuInfo set properties='" + sku.properties + "',quantity=" + sku.quantity + ",price=" + sku.price + ",outer_id=@ProductsID,created='" + sku.created + "',modified'" + sku.modified + "',[status]='" + sku.status + "' ");
                    strSql.Append(" where where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID and sku_id=" + sku.sku_id + " and num_iid=" + sku.num_iid + " ;");

                    strSql.Append(" end \r\n");
                    strSql.Append(" else \r\n");
                    strSql.Append(" begin \r\n");
                    */
                    strSql.Append(" insert into tb_M_GoodsSkuInfo(m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status])");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + sku.sku_id + "," + model.num_iid + ",'" + sku.properties + "'," + sku.quantity + "," + sku.price + "," + model.ProductsID + ",'" + sku.created + "','" + sku.modified + "','" + sku.status + "');");

                    //strSql.Append(" end \r\n");
                    
                }
            }

            strSql.Append(" delete tb_M_LocationInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID;");
            if (model.location != null)
            {
                
                strSql.Append(" insert into tb_M_LocationInfo(m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime)");
                strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID,'" + model.location.zip + "','" + model.location.address + "','" + model.location.city + "','" + model.location.state + "','" + model.location.country + "','" + model.location.district + "',getdate());");
            }

            strSql.Append(" delete tb_M_ImgInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID;");
            if (model.item_imgs != null)
            {
                foreach (M_ImgInfo img in model.item_imgs)
                {
                    strSql.Append(" insert into tb_M_ImgInfo(m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,url,position,created,modified)");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + img.m_id + "," + img.product_id + ",'" + img.url + "'," + img.position + ",'" + img.created + "','" + img.modified + "');");
                }
            }

            strSql.Append(" delete tb_M_PropImgInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID;");
            if (model.prop_imgs != null)
            {
                foreach (M_PropImgInfo propimg in model.prop_imgs)
                {
                    strSql.Append(" insert into tb_M_PropImgInfo(m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified)");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + propimg.m_id + "," + propimg.product_id + ",'" + propimg.position + "','" + propimg.url + "'," + propimg.position + ",'" + propimg.created + "','" + propimg.modified + "');");
                }
            }

            strSql.Append(" delete tb_M_VideoInfo where m_ConfigInfoID=@m_ConfigInfoID and m_Type=2 and m_ObjID=@m_GoodsID;");
            if (model.videos != null)
            {
                foreach (M_VideoInfo video in model.videos)
                {
                    strSql.Append(" insert into tb_M_VideoInfo(m_ConfigInfoID,m_Type,m_ObjID,video_id,url,created,modified,num_iid)");
                    strSql.Append(" values(@m_ConfigInfoID,2,@m_GoodsID," + video.video_id + ",'" + video.url + "','" + video.created + "','" + video.modified + "'," + model.num_iid + ");");
                }
            }



			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@m_ProductInfoID", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@detail_url", SqlDbType.VarChar,512),
					new SqlParameter("@title", SqlDbType.VarChar,60),
					new SqlParameter("@nick", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@props_name", SqlDbType.VarChar,1024),
					new SqlParameter("@promoted_service", SqlDbType.VarChar,512),
					new SqlParameter("@cid", SqlDbType.BigInt),
					new SqlParameter("@seller_cids", SqlDbType.VarChar,512),
					new SqlParameter("@props", SqlDbType.VarChar,1024),
					new SqlParameter("@input_pids", SqlDbType.VarChar,1024),
					new SqlParameter("@input_str", SqlDbType.VarChar,1024),
					new SqlParameter("@m_desc", SqlDbType.NText),
					new SqlParameter("@pic_url", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@valid_thru", SqlDbType.Int,4),
					new SqlParameter("@list_time", SqlDbType.DateTime),
					new SqlParameter("@delist_time", SqlDbType.DateTime),
					new SqlParameter("@stuff_status", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@post_fee", SqlDbType.Money,8),
					new SqlParameter("@express_fee", SqlDbType.Money,8),
					new SqlParameter("@ems_fee", SqlDbType.Money,8),
					new SqlParameter("@has_discount", SqlDbType.Bit,1),
					new SqlParameter("@freight_payer", SqlDbType.VarChar,50),
					new SqlParameter("@has_invoice", SqlDbType.Bit,1),
					new SqlParameter("@has_warranty", SqlDbType.Bit,1),
					new SqlParameter("@has_showcase", SqlDbType.Bit,1),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@increment", SqlDbType.VarChar,50),
					new SqlParameter("@approve_status", SqlDbType.VarChar,50),
					new SqlParameter("@postage_id", SqlDbType.BigInt),
					new SqlParameter("@auction_point", SqlDbType.Int,4),
					new SqlParameter("@property_alias", SqlDbType.VarChar,50),
					new SqlParameter("@is_virtual", SqlDbType.Bit,1),
					new SqlParameter("@is_taobao", SqlDbType.Bit,1),
					new SqlParameter("@is_ex", SqlDbType.Bit,1),
					new SqlParameter("@is_timing", SqlDbType.Bit,1),
					new SqlParameter("@is_3D", SqlDbType.Bit,1),
					new SqlParameter("@one_station", SqlDbType.Bit,1),
					new SqlParameter("@second_kill", SqlDbType.VarChar,50),
					new SqlParameter("@auto_fill", SqlDbType.VarChar,50),
					new SqlParameter("@violation", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@cod_postage_id", SqlDbType.BigInt),
					new SqlParameter("@sell_promise", SqlDbType.Bit,1),
                                        new SqlParameter("@m_IsDeltet", SqlDbType.Bit,1),
                                        new SqlParameter("@m_UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_GoodsID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.ProductsID;
			parameters[3].Value = model.m_ProductInfoID;
			parameters[4].Value = model.product_id;
            parameters[5].Value = model.outer_id == null ? "" : model.outer_id;
			parameters[6].Value = model.num_iid;
            parameters[7].Value = model.detail_url == null ? "" : model.detail_url;
            parameters[8].Value = model.title == null ? "" : model.title;
            parameters[9].Value = model.nick == null ? "" : model.nick;
            parameters[10].Value = model.type == null ? "" : model.type;
            parameters[11].Value = model.props_name == null ? "" : model.props_name;
            parameters[12].Value = model.promoted_service == null ? "" : model.promoted_service;
			parameters[13].Value = model.cid;
            parameters[14].Value = model.seller_cids == null ? "" : model.seller_cids;
            parameters[15].Value = model.props == null ? "" : model.props;
            parameters[16].Value = model.input_pids == null ? "" : model.input_pids;
            parameters[17].Value = model.input_str == null ? "" : model.input_str;
            parameters[18].Value = model.m_desc == null ? "" : model.m_desc;
            parameters[19].Value = model.pic_url == null ? "" : model.pic_url;
			parameters[20].Value = model.num;
			parameters[21].Value = model.valid_thru;
			parameters[22].Value = model.list_time;
			parameters[23].Value = model.delist_time;
            parameters[24].Value = model.stuff_status == null ? "" : model.stuff_status;
			parameters[25].Value = model.price;
			parameters[26].Value = model.post_fee;
			parameters[27].Value = model.express_fee;
			parameters[28].Value = model.ems_fee;
			parameters[29].Value = model.has_discount;
            parameters[30].Value = model.freight_payer == null ? "" : model.freight_payer;
			parameters[31].Value = model.has_invoice;
			parameters[32].Value = model.has_warranty;
			parameters[33].Value = model.has_showcase;
			parameters[34].Value = model.modified;
            parameters[35].Value = model.increment == null ? "" : model.increment;
            parameters[36].Value = model.approve_status == null ? "" : model.approve_status;
			parameters[37].Value = model.postage_id;
			parameters[38].Value = model.auction_point;
            parameters[39].Value = model.property_alias == null ? "" : model.property_alias;
			parameters[40].Value = model.is_virtual;
			parameters[41].Value = model.is_taobao;
			parameters[42].Value = model.is_ex;
			parameters[43].Value = model.is_timing;
			parameters[44].Value = model.is_3D;
			parameters[45].Value = model.one_station;
            parameters[46].Value = model.second_kill == null ? "" : model.second_kill;
            parameters[47].Value = model.auto_fill == null ? "" : model.auto_fill;
			parameters[48].Value = model.violation;
			parameters[49].Value = model.created;
			parameters[50].Value = model.cod_postage_id;
			parameters[51].Value = model.sell_promise;
            parameters[52].Value = model.m_IsDeltet;
            parameters[53].Value = model.m_UpdateTime;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_GoodsInfo(int m_GoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_GoodsInfo ");
			strSql.Append(" where m_GoodsID=@m_GoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}
        /// <summary>
        /// 非真删除
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public void DeleteM_GoodsInfoNOTrue(int m_GoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsInfo set m_IsDeltet=@m_IsDeltet,m_UpdateTime=getdate()");
            strSql.Append(" where m_GoodsID=@m_GoodsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
                                        new SqlParameter("@m_IsDeltet", SqlDbType.Bit,1),};
            parameters[0].Value = m_GoodsID;
            parameters[1].Value = true;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public void ListingM_Goods(int m_GoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsInfo set approve_status='onsale',m_UpdateTime=getdate()");
            strSql.Append(" where m_GoodsID=@m_GoodsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),};
            parameters[0].Value = m_GoodsID;
            
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public void DelistingM_Goods(int m_GoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsInfo set approve_status='instock',m_UpdateTime=getdate()");
            strSql.Append(" where m_GoodsID=@m_GoodsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),};
            parameters[0].Value = m_GoodsID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public void RecommendAddM_Goods(int m_GoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsInfo set has_showcase=1,m_UpdateTime=getdate()");
            strSql.Append(" where m_GoodsID=@m_GoodsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),};
            parameters[0].Value = m_GoodsID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 取消推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public void RecommendDeleteM_Goods(int m_GoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsInfo set has_showcase=0,m_UpdateTime=getdate()");
            strSql.Append(" where m_GoodsID=@m_GoodsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4),};
            parameters[0].Value = m_GoodsID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_GoodsInfo GetM_GoodsInfoModel(int m_GoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 m_GoodsID,m_ConfigInfoID,ProductsID,(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime from tb_M_GoodsInfo ");
			strSql.Append(" where m_GoodsID=@m_GoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsID;

			M_GoodsInfo model=new M_GoodsInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_GoodsID"].ToString()!="")
				{
					model.m_GoodsID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductsID"].ToString()!="")
				{
					model.ProductsID=int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
				if(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString()!="")
				{
					model.m_ProductInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=long.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				model.outer_id=ds.Tables[0].Rows[0]["outer_id"].ToString();
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=Int64.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
				}
				model.detail_url=ds.Tables[0].Rows[0]["detail_url"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.nick=ds.Tables[0].Rows[0]["nick"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				model.props_name=ds.Tables[0].Rows[0]["props_name"].ToString();
				model.promoted_service=ds.Tables[0].Rows[0]["promoted_service"].ToString();
				if(ds.Tables[0].Rows[0]["cid"].ToString()!="")
				{
					model.cid=int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
				}

                model.mCatName = ds.Tables[0].Rows[0]["mCatName"].ToString();
				model.seller_cids=ds.Tables[0].Rows[0]["seller_cids"].ToString();
				model.props=ds.Tables[0].Rows[0]["props"].ToString();
				model.input_pids=ds.Tables[0].Rows[0]["input_pids"].ToString();
				model.input_str=ds.Tables[0].Rows[0]["input_str"].ToString();
				model.m_desc=ds.Tables[0].Rows[0]["m_desc"].ToString();
				model.pic_url=ds.Tables[0].Rows[0]["pic_url"].ToString();
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["valid_thru"].ToString()!="")
				{
					model.valid_thru=int.Parse(ds.Tables[0].Rows[0]["valid_thru"].ToString());
				}
				if(ds.Tables[0].Rows[0]["list_time"].ToString()!="")
				{
					model.list_time=DateTime.Parse(ds.Tables[0].Rows[0]["list_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["delist_time"].ToString()!="")
				{
					model.delist_time=DateTime.Parse(ds.Tables[0].Rows[0]["delist_time"].ToString());
				}
				model.stuff_status=ds.Tables[0].Rows[0]["stuff_status"].ToString();
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["post_fee"].ToString()!="")
				{
					model.post_fee=decimal.Parse(ds.Tables[0].Rows[0]["post_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["express_fee"].ToString()!="")
				{
					model.express_fee=decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ems_fee"].ToString()!="")
				{
					model.ems_fee=decimal.Parse(ds.Tables[0].Rows[0]["ems_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["has_discount"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_discount"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_discount"].ToString().ToLower()=="true"))
					{
						model.has_discount=true;
					}
					else
					{
						model.has_discount=false;
					}
				}
				model.freight_payer=ds.Tables[0].Rows[0]["freight_payer"].ToString();
				if(ds.Tables[0].Rows[0]["has_invoice"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_invoice"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_invoice"].ToString().ToLower()=="true"))
					{
						model.has_invoice=true;
					}
					else
					{
						model.has_invoice=false;
					}
				}
				if(ds.Tables[0].Rows[0]["has_warranty"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_warranty"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_warranty"].ToString().ToLower()=="true"))
					{
						model.has_warranty=true;
					}
					else
					{
						model.has_warranty=false;
					}
				}
				if(ds.Tables[0].Rows[0]["has_showcase"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_showcase"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_showcase"].ToString().ToLower()=="true"))
					{
						model.has_showcase=true;
					}
					else
					{
						model.has_showcase=false;
					}
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				model.increment=ds.Tables[0].Rows[0]["increment"].ToString();
				model.approve_status=ds.Tables[0].Rows[0]["approve_status"].ToString();
				if(ds.Tables[0].Rows[0]["postage_id"].ToString()!="")
				{
					model.postage_id=int.Parse(ds.Tables[0].Rows[0]["postage_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["auction_point"].ToString()!="")
				{
					model.auction_point=int.Parse(ds.Tables[0].Rows[0]["auction_point"].ToString());
				}
				model.property_alias=ds.Tables[0].Rows[0]["property_alias"].ToString();
				if(ds.Tables[0].Rows[0]["is_virtual"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_virtual"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_virtual"].ToString().ToLower()=="true"))
					{
						model.is_virtual=true;
					}
					else
					{
						model.is_virtual=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_taobao"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_taobao"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_taobao"].ToString().ToLower()=="true"))
					{
						model.is_taobao=true;
					}
					else
					{
						model.is_taobao=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_ex"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_ex"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_ex"].ToString().ToLower()=="true"))
					{
						model.is_ex=true;
					}
					else
					{
						model.is_ex=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_timing"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_timing"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_timing"].ToString().ToLower()=="true"))
					{
						model.is_timing=true;
					}
					else
					{
						model.is_timing=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_3D"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_3D"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_3D"].ToString().ToLower()=="true"))
					{
						model.is_3D=true;
					}
					else
					{
						model.is_3D=false;
					}
				}
				if(ds.Tables[0].Rows[0]["one_station"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["one_station"].ToString()=="1")||(ds.Tables[0].Rows[0]["one_station"].ToString().ToLower()=="true"))
					{
						model.one_station=true;
					}
					else
					{
						model.one_station=false;
					}
				}
				model.second_kill=ds.Tables[0].Rows[0]["second_kill"].ToString();
				model.auto_fill=ds.Tables[0].Rows[0]["auto_fill"].ToString();
				if(ds.Tables[0].Rows[0]["violation"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["violation"].ToString()=="1")||(ds.Tables[0].Rows[0]["violation"].ToString().ToLower()=="true"))
					{
						model.violation=true;
					}
					else
					{
						model.violation=false;
					}
				}
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cod_postage_id"].ToString()!="")
				{
					model.cod_postage_id=int.Parse(ds.Tables[0].Rows[0]["cod_postage_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sell_promise"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sell_promise"].ToString()=="1")||(ds.Tables[0].Rows[0]["sell_promise"].ToString().ToLower()=="true"))
					{
						model.sell_promise=true;
					}
					else
					{
						model.sell_promise=false;
					}
				}
                if (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() == "1") || (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString().ToLower() == "true"))
                    {
                        model.m_IsDeltet = true;
                    }
                    else
                    {
                        model.m_IsDeltet = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_UpdateTime"].ToString() != "")
                {
                    model.m_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}
        public M_GoodsInfo GetM_GoodsInfoModelByProductsID(int m_ConfigInfoID, int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_GoodsID,m_ConfigInfoID,ProductsID,(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime from tb_M_GoodsInfo ");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = ProductsID;

            M_GoodsInfo model = new M_GoodsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_GoodsID"].ToString() != "")
                {
                    model.m_GoodsID = int.Parse(ds.Tables[0].Rows[0]["m_GoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                if (ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString() != "")
                {
                    model.m_ProductInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
                {
                    model.product_id = long.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                }
                model.outer_id = ds.Tables[0].Rows[0]["outer_id"].ToString();
                if (ds.Tables[0].Rows[0]["num_iid"].ToString() != "")
                {
                    model.num_iid = Int64.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
                }
                model.detail_url = ds.Tables[0].Rows[0]["detail_url"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.nick = ds.Tables[0].Rows[0]["nick"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                model.props_name = ds.Tables[0].Rows[0]["props_name"].ToString();
                model.promoted_service = ds.Tables[0].Rows[0]["promoted_service"].ToString();
                if (ds.Tables[0].Rows[0]["cid"].ToString() != "")
                {
                    model.cid = int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
                }

                model.mCatName = ds.Tables[0].Rows[0]["mCatName"].ToString();
                model.seller_cids = ds.Tables[0].Rows[0]["seller_cids"].ToString();
                model.props = ds.Tables[0].Rows[0]["props"].ToString();
                model.input_pids = ds.Tables[0].Rows[0]["input_pids"].ToString();
                model.input_str = ds.Tables[0].Rows[0]["input_str"].ToString();
                model.m_desc = ds.Tables[0].Rows[0]["m_desc"].ToString();
                model.pic_url = ds.Tables[0].Rows[0]["pic_url"].ToString();
                if (ds.Tables[0].Rows[0]["num"].ToString() != "")
                {
                    model.num = int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["valid_thru"].ToString() != "")
                {
                    model.valid_thru = int.Parse(ds.Tables[0].Rows[0]["valid_thru"].ToString());
                }
                if (ds.Tables[0].Rows[0]["list_time"].ToString() != "")
                {
                    model.list_time = DateTime.Parse(ds.Tables[0].Rows[0]["list_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["delist_time"].ToString() != "")
                {
                    model.delist_time = DateTime.Parse(ds.Tables[0].Rows[0]["delist_time"].ToString());
                }
                model.stuff_status = ds.Tables[0].Rows[0]["stuff_status"].ToString();
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["post_fee"].ToString() != "")
                {
                    model.post_fee = decimal.Parse(ds.Tables[0].Rows[0]["post_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_fee"].ToString() != "")
                {
                    model.express_fee = decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ems_fee"].ToString() != "")
                {
                    model.ems_fee = decimal.Parse(ds.Tables[0].Rows[0]["ems_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["has_discount"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_discount"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_discount"].ToString().ToLower() == "true"))
                    {
                        model.has_discount = true;
                    }
                    else
                    {
                        model.has_discount = false;
                    }
                }
                model.freight_payer = ds.Tables[0].Rows[0]["freight_payer"].ToString();
                if (ds.Tables[0].Rows[0]["has_invoice"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_invoice"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_invoice"].ToString().ToLower() == "true"))
                    {
                        model.has_invoice = true;
                    }
                    else
                    {
                        model.has_invoice = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["has_warranty"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_warranty"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_warranty"].ToString().ToLower() == "true"))
                    {
                        model.has_warranty = true;
                    }
                    else
                    {
                        model.has_warranty = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["has_showcase"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_showcase"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_showcase"].ToString().ToLower() == "true"))
                    {
                        model.has_showcase = true;
                    }
                    else
                    {
                        model.has_showcase = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["modified"].ToString() != "")
                {
                    model.modified = DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
                }
                model.increment = ds.Tables[0].Rows[0]["increment"].ToString();
                model.approve_status = ds.Tables[0].Rows[0]["approve_status"].ToString();
                if (ds.Tables[0].Rows[0]["postage_id"].ToString() != "")
                {
                    model.postage_id = int.Parse(ds.Tables[0].Rows[0]["postage_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["auction_point"].ToString() != "")
                {
                    model.auction_point = int.Parse(ds.Tables[0].Rows[0]["auction_point"].ToString());
                }
                model.property_alias = ds.Tables[0].Rows[0]["property_alias"].ToString();
                if (ds.Tables[0].Rows[0]["is_virtual"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_virtual"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_virtual"].ToString().ToLower() == "true"))
                    {
                        model.is_virtual = true;
                    }
                    else
                    {
                        model.is_virtual = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_taobao"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_taobao"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_taobao"].ToString().ToLower() == "true"))
                    {
                        model.is_taobao = true;
                    }
                    else
                    {
                        model.is_taobao = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_ex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_ex"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_ex"].ToString().ToLower() == "true"))
                    {
                        model.is_ex = true;
                    }
                    else
                    {
                        model.is_ex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_timing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_timing"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_timing"].ToString().ToLower() == "true"))
                    {
                        model.is_timing = true;
                    }
                    else
                    {
                        model.is_timing = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_3D"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_3D"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_3D"].ToString().ToLower() == "true"))
                    {
                        model.is_3D = true;
                    }
                    else
                    {
                        model.is_3D = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["one_station"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["one_station"].ToString() == "1") || (ds.Tables[0].Rows[0]["one_station"].ToString().ToLower() == "true"))
                    {
                        model.one_station = true;
                    }
                    else
                    {
                        model.one_station = false;
                    }
                }
                model.second_kill = ds.Tables[0].Rows[0]["second_kill"].ToString();
                model.auto_fill = ds.Tables[0].Rows[0]["auto_fill"].ToString();
                if (ds.Tables[0].Rows[0]["violation"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["violation"].ToString() == "1") || (ds.Tables[0].Rows[0]["violation"].ToString().ToLower() == "true"))
                    {
                        model.violation = true;
                    }
                    else
                    {
                        model.violation = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["created"].ToString() != "")
                {
                    model.created = DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cod_postage_id"].ToString() != "")
                {
                    model.cod_postage_id = int.Parse(ds.Tables[0].Rows[0]["cod_postage_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_promise"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sell_promise"].ToString() == "1") || (ds.Tables[0].Rows[0]["sell_promise"].ToString().ToLower() == "true"))
                    {
                        model.sell_promise = true;
                    }
                    else
                    {
                        model.sell_promise = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() == "1") || (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString().ToLower() == "true"))
                    {
                        model.m_IsDeltet = true;
                    }
                    else
                    {
                        model.m_IsDeltet = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_UpdateTime"].ToString() != "")
                {
                    model.m_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public M_GoodsInfo GetM_GoodsInfoModelByNum_iid(int m_ConfigInfoID, long num_iid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_GoodsID,m_ConfigInfoID,ProductsID,(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime from tb_M_GoodsInfo ");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and num_iid=@num_iid ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = num_iid;

            M_GoodsInfo model = new M_GoodsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_GoodsID"].ToString() != "")
                {
                    model.m_GoodsID = int.Parse(ds.Tables[0].Rows[0]["m_GoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                if (ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString() != "")
                {
                    model.m_ProductInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ProductInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
                {
                    model.product_id = long.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                }
                model.outer_id = ds.Tables[0].Rows[0]["outer_id"].ToString();
                if (ds.Tables[0].Rows[0]["num_iid"].ToString() != "")
                {
                    model.num_iid = Int64.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
                }
                model.detail_url = ds.Tables[0].Rows[0]["detail_url"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.nick = ds.Tables[0].Rows[0]["nick"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                model.props_name = ds.Tables[0].Rows[0]["props_name"].ToString();
                model.promoted_service = ds.Tables[0].Rows[0]["promoted_service"].ToString();
                if (ds.Tables[0].Rows[0]["cid"].ToString() != "")
                {
                    model.cid = int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
                }

                model.mCatName = ds.Tables[0].Rows[0]["mCatName"].ToString();
                model.seller_cids = ds.Tables[0].Rows[0]["seller_cids"].ToString();
                model.props = ds.Tables[0].Rows[0]["props"].ToString();
                model.input_pids = ds.Tables[0].Rows[0]["input_pids"].ToString();
                model.input_str = ds.Tables[0].Rows[0]["input_str"].ToString();
                model.m_desc = ds.Tables[0].Rows[0]["m_desc"].ToString();
                model.pic_url = ds.Tables[0].Rows[0]["pic_url"].ToString();
                if (ds.Tables[0].Rows[0]["num"].ToString() != "")
                {
                    model.num = int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["valid_thru"].ToString() != "")
                {
                    model.valid_thru = int.Parse(ds.Tables[0].Rows[0]["valid_thru"].ToString());
                }
                if (ds.Tables[0].Rows[0]["list_time"].ToString() != "")
                {
                    model.list_time = DateTime.Parse(ds.Tables[0].Rows[0]["list_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["delist_time"].ToString() != "")
                {
                    model.delist_time = DateTime.Parse(ds.Tables[0].Rows[0]["delist_time"].ToString());
                }
                model.stuff_status = ds.Tables[0].Rows[0]["stuff_status"].ToString();
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["post_fee"].ToString() != "")
                {
                    model.post_fee = decimal.Parse(ds.Tables[0].Rows[0]["post_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_fee"].ToString() != "")
                {
                    model.express_fee = decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ems_fee"].ToString() != "")
                {
                    model.ems_fee = decimal.Parse(ds.Tables[0].Rows[0]["ems_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["has_discount"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_discount"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_discount"].ToString().ToLower() == "true"))
                    {
                        model.has_discount = true;
                    }
                    else
                    {
                        model.has_discount = false;
                    }
                }
                model.freight_payer = ds.Tables[0].Rows[0]["freight_payer"].ToString();
                if (ds.Tables[0].Rows[0]["has_invoice"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_invoice"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_invoice"].ToString().ToLower() == "true"))
                    {
                        model.has_invoice = true;
                    }
                    else
                    {
                        model.has_invoice = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["has_warranty"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_warranty"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_warranty"].ToString().ToLower() == "true"))
                    {
                        model.has_warranty = true;
                    }
                    else
                    {
                        model.has_warranty = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["has_showcase"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_showcase"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_showcase"].ToString().ToLower() == "true"))
                    {
                        model.has_showcase = true;
                    }
                    else
                    {
                        model.has_showcase = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["modified"].ToString() != "")
                {
                    model.modified = DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
                }
                model.increment = ds.Tables[0].Rows[0]["increment"].ToString();
                model.approve_status = ds.Tables[0].Rows[0]["approve_status"].ToString();
                if (ds.Tables[0].Rows[0]["postage_id"].ToString() != "")
                {
                    model.postage_id = int.Parse(ds.Tables[0].Rows[0]["postage_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["auction_point"].ToString() != "")
                {
                    model.auction_point = int.Parse(ds.Tables[0].Rows[0]["auction_point"].ToString());
                }
                model.property_alias = ds.Tables[0].Rows[0]["property_alias"].ToString();
                if (ds.Tables[0].Rows[0]["is_virtual"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_virtual"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_virtual"].ToString().ToLower() == "true"))
                    {
                        model.is_virtual = true;
                    }
                    else
                    {
                        model.is_virtual = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_taobao"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_taobao"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_taobao"].ToString().ToLower() == "true"))
                    {
                        model.is_taobao = true;
                    }
                    else
                    {
                        model.is_taobao = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_ex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_ex"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_ex"].ToString().ToLower() == "true"))
                    {
                        model.is_ex = true;
                    }
                    else
                    {
                        model.is_ex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_timing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_timing"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_timing"].ToString().ToLower() == "true"))
                    {
                        model.is_timing = true;
                    }
                    else
                    {
                        model.is_timing = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["is_3D"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_3D"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_3D"].ToString().ToLower() == "true"))
                    {
                        model.is_3D = true;
                    }
                    else
                    {
                        model.is_3D = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["one_station"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["one_station"].ToString() == "1") || (ds.Tables[0].Rows[0]["one_station"].ToString().ToLower() == "true"))
                    {
                        model.one_station = true;
                    }
                    else
                    {
                        model.one_station = false;
                    }
                }
                model.second_kill = ds.Tables[0].Rows[0]["second_kill"].ToString();
                model.auto_fill = ds.Tables[0].Rows[0]["auto_fill"].ToString();
                if (ds.Tables[0].Rows[0]["violation"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["violation"].ToString() == "1") || (ds.Tables[0].Rows[0]["violation"].ToString().ToLower() == "true"))
                    {
                        model.violation = true;
                    }
                    else
                    {
                        model.violation = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["created"].ToString() != "")
                {
                    model.created = DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cod_postage_id"].ToString() != "")
                {
                    model.cod_postage_id = int.Parse(ds.Tables[0].Rows[0]["cod_postage_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_promise"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sell_promise"].ToString() == "1") || (ds.Tables[0].Rows[0]["sell_promise"].ToString().ToLower() == "true"))
                    {
                        model.sell_promise = true;
                    }
                    else
                    {
                        model.sell_promise = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["m_IsDeltet"].ToString() == "1") || (ds.Tables[0].Rows[0]["m_IsDeltet"].ToString().ToLower() == "true"))
                    {
                        model.m_IsDeltet = true;
                    }
                    else
                    {
                        model.m_IsDeltet = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_UpdateTime"].ToString() != "")
                {
                    model.m_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取商品仓库数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <returns></returns>
        public DataTable GetM_GoodsStockList(int m_ConfigInfoID, int m_GoodsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.*,mss.StorageID,isnull(mss.m_Num,0) as m_Num,mss.m_ConfigInfoID,mss.ProductsID,mss.pName,mss.pBarcode,mss.pUnits,mss.pMaxUnits,mss.pToBoxNo from tbStorageInfo as s left join " +
                                    "(select ms.StorageID,isnull(ms.m_Num,0) as m_Num,ms.m_ConfigInfoID,ms.ProductsID,p.pName,p.pBarcode,p.pUnits,p.pMaxUnits,p.pToBoxNo from tb_M_StockInfo as ms left join tbProductsInfo as p on ms.ProductsID=p.ProductsID where ms.m_ConfigInfoID=@m_ConfigInfoID and ms.ProductsID = (select ProductsID from tb_M_GoodsInfo where m_GoodsID=@m_GoodsID)) as mss " +
                                    "on s.StorageID=mss.StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_GoodsID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_GoodsID;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else {
                return null;
            }
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetM_GoodsInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select m_GoodsID,m_ConfigInfoID,ProductsID,(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime ");
			strSql.Append(" FROM tb_M_GoodsInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_GoodsInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" m_GoodsID,m_ConfigInfoID,ProductsID,(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,m_ProductInfoID,product_id,outer_id,num_iid,detail_url,title,nick,type,props_name,promoted_service,cid,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName,seller_cids,props,input_pids,input_str,m_desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,approve_status,postage_id,auction_point,property_alias,is_virtual,is_taobao,is_ex,is_timing,is_3D,one_station,second_kill,auto_fill,violation,created,cod_postage_id,sell_promise,m_IsDeltet,m_UpdateTime ");
			strSql.Append(" FROM tb_M_GoodsInfo ");
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
		public DataTable GetM_GoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_GoodsInfo";
			parameters[1].Value = "M_GoodsID";
			parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select pName from tbProductsInfo where ProductsID=tb_M_GoodsInfo.ProductsID) as ProductsName,(select top 1 [name] from tb_M_GoodsCatInfo where cid=tb_M_GoodsInfo.cid) mCatName ";
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
        /// 返回商品数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <returns></returns>
        public DataTable GetM_GoodsStockList(int m_ConfigInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select g.*,p.pName,p.pBarcode,isnull((select isnull(sum(isnull(m_Num,0)),0) from tb_M_StockInfo where m_ConfigInfoID=g.m_ConfigInfoID and ProductsID=g.ProductsID),0) as mNum " +
                " from tb_M_GoodsInfo as g left join tbProductsInfo as p on g.ProductsID=p.ProductsID "+
                " where g.m_ConfigInfoID=@m_ConfigInfoID and m_IsDeltet=0" +
                " order by g.m_GoodsID desc");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;

          DataSet ds =  DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
          if (ds != null)
          {
              return ds.Tables[0];
          }
          else
          {
              return null;
          }
        }

        /// <summary>
        /// 更新商品数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public bool UpdateM_GoodsStockNum(int m_ConfigInfoID, int ProductsID, int Num, int StorageID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" if exists(select 0 from tb_M_StockInfo where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID and StorageID=@StorageID) \r\n");
                strSql.Append(" begin \r\n");
                strSql.Append(" update tb_M_StockInfo set m_Num=@m_Num,m_UpdateTime=getdate() where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID and StorageID=@StorageID;\r\n");
                strSql.Append(" end \r\n");
                strSql.Append(" else \r\n");
                strSql.Append(" begin \r\n");
                strSql.Append(" insert into tb_M_StockInfo(m_ConfigInfoID,ProductsID,m_Num,m_UpdateTime,StorageID)");
                strSql.Append(" values (@m_ConfigInfoID,@ProductsID,@m_Num,getdate(),@StorageID);\r\n");
                strSql.Append(" end \r\n");

                SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Num", SqlDbType.Int,4),
                                            new SqlParameter("@StorageID", SqlDbType.Int,4)};
                parameters[0].Value = m_ConfigInfoID;
                parameters[1].Value = ProductsID;
                parameters[2].Value = Num;
                parameters[3].Value = StorageID;

                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public bool UpdateM_GoodsNum(int m_ConfigInfoID, int m_GoodsID, int Num)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update  tb_M_GoodsInfo set num=@Num where m_ConfigInfoID=@m_ConfigInfoID and m_GoodsID=@m_GoodsID");
                SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                    new SqlParameter("@m_GoodsID", SqlDbType.Int,4),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                                         };
                parameters[0].Value = m_ConfigInfoID;
                parameters[1].Value = m_GoodsID;
                parameters[2].Value = Num;
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                return true;
            }
            catch {
                return false;
            }
        }
        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="num_iid"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public bool UpdateM_GoodsNum(int m_ConfigInfoID, long num_iid, int Num)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update  tb_M_GoodsInfo set num=@Num where m_ConfigInfoID=@m_ConfigInfoID and num_iid=@num_iid");
                SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                    new SqlParameter("@num_iid", SqlDbType.Int,4),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                                         };
                parameters[0].Value = m_ConfigInfoID;
                parameters[1].Value = num_iid;
                parameters[2].Value = Num;
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
		#endregion
	}
}


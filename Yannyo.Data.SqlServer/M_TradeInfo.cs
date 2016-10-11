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
	/// 数据访问类M_TradeInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  交易信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_TradeInfo(int m_ConfigInfoID, long tid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_TradeInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and tid=@tid");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@tid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = tid;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int ExistsM_TradeInfoAndReID(int m_ConfigInfoID, long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_TradeInfoID from tb_M_TradeInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@tid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = tid;
            object o = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (o != null)
            {
                return Convert.ToInt32(o);
            }
            else 
            {
                return -1;
            }
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_TradeInfo(M_TradeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("declare @m_TradeInfoID int;");
			strSql.Append("insert into tb_M_TradeInfo(");
			strSql.Append("m_ConfigInfoID,end_time,seller_nick,buyer_nick,title,type,created,num_iid,price,pic_path,num,tid,buyer_message,shipping_type,alipay_no,payment,discount_fee,adjust_fee,snapshot_url,snapshot,status,seller_rate,buyer_rate,buyer_memo,seller_memo,trade_memo,pay_time,modified,buyer_obtain_point_fee,point_fee,real_point_fee,total_fee,post_fee,buyer_alipay_no,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,consign_time,buyer_email,commission_fee,seller_alipay_no,seller_mobile,seller_phone,seller_name,seller_email,available_confirm_fee,has_post_fee,received_payment,cod_fee,cod_status,timeout_action_time,is_3D,buyer_flag,seller_flag,promotion,invoice_name,trade_from,alipay_url)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@end_time,@seller_nick,@buyer_nick,@title,@type,@created,@num_iid,@price,@pic_path,@num,@tid,@buyer_message,@shipping_type,@alipay_no,@payment,@discount_fee,@adjust_fee,@snapshot_url,@snapshot,@status,@seller_rate,@buyer_rate,@buyer_memo,@seller_memo,@trade_memo,@pay_time,@modified,@buyer_obtain_point_fee,@point_fee,@real_point_fee,@total_fee,@post_fee,@buyer_alipay_no,@receiver_name,@receiver_state,@receiver_city,@receiver_district,@receiver_address,@receiver_zip,@receiver_mobile,@receiver_phone,@consign_time,@buyer_email,@commission_fee,@seller_alipay_no,@seller_mobile,@seller_phone,@seller_name,@seller_email,@available_confirm_fee,@has_post_fee,@received_payment,@cod_fee,@cod_status,@timeout_action_time,@is_3D,@buyer_flag,@seller_flag,@promotion,@invoice_name,@trade_from,@alipay_url)");
            strSql.Append(";SET @m_TradeInfoID = SCOPE_IDENTITY();select @m_TradeInfoID;");

            if (model.orders!=null)
            {
                foreach(M_OrderInfo mo in model.orders)
                {
                    strSql.Append(" insert into tb_M_OrderInfo(m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold)");
                    strSql.Append(" values(@m_ConfigInfoID,@m_TradeInfoID," + mo.num_iid + "," + mo.total_fee + "," + mo.discount_fee + "," + mo.adjust_fee + ",'" + mo.sku_id + "','" + mo.sku_properties_name + "','" + mo.item_meal_name + "'," + mo.num + ",'" + mo.title + "'," + mo.price + ",'"+mo.pic_path+"','" + mo.seller_nick + "','" + mo.buyer_nick + "','" + mo.created + "','" + mo.refund_status + "'," + mo.oid + ",'" + mo.outer_iid + "','" + mo.outer_sku_id + "'," + mo.payment + ",'" + mo.status + "','" + mo.snapshot_url + "','" + mo.snapshot + "','" + mo.timeout_action_time + "'," + (mo.buyer_rate ? 1 : 0) + "," + (mo.seller_rate ? 1 : 0) + "," + mo.refund_id + ",'" + mo.seller_type + "','" + mo.modified + "'," + mo.cid + "," + (mo.is_oversold ? 1 : 0) + ");");
                }
            }

            if (model.promotion_details != null)
            {
                foreach (M_OrderPromotionDetailInfo mop in model.promotion_details)
                {
                    strSql.Append(" insert into tb_M_OrderPromotionDetailInfo(m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name)");
                    strSql.Append(" values(1,@m_TradeInfoID," + mop.m_id + ",'" + mop.promotion_name + "'," + mop.discount_fee + ",'" + mop.gift_item_name + "');");
                }
            }

			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,512),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.BigInt),
					new SqlParameter("@buyer_message", SqlDbType.VarChar,512),
					new SqlParameter("@shipping_type", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@adjust_fee", SqlDbType.Money,8),
					new SqlParameter("@snapshot_url", SqlDbType.VarChar,512),
					new SqlParameter("@snapshot", SqlDbType.VarChar,512),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@seller_rate", SqlDbType.Bit,1),
					new SqlParameter("@buyer_rate", SqlDbType.Bit,1),
					new SqlParameter("@buyer_memo", SqlDbType.VarChar,512),
					new SqlParameter("@seller_memo", SqlDbType.VarChar,512),
					new SqlParameter("@trade_memo", SqlDbType.VarChar,512),
					new SqlParameter("@pay_time", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@buyer_obtain_point_fee", SqlDbType.Int,4),
					new SqlParameter("@point_fee", SqlDbType.Int,4),
					new SqlParameter("@real_point_fee", SqlDbType.Int,4),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@post_fee", SqlDbType.Money,8),
					new SqlParameter("@buyer_alipay_no", SqlDbType.VarChar,128),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_state", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_city", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_district", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_address", SqlDbType.VarChar,512),
					new SqlParameter("@receiver_zip", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@consign_time", SqlDbType.DateTime),
					new SqlParameter("@buyer_email", SqlDbType.VarChar,50),
					new SqlParameter("@commission_fee", SqlDbType.Money,8),
					new SqlParameter("@seller_alipay_no", SqlDbType.VarChar,128),
					new SqlParameter("@seller_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.VarChar,50),
					new SqlParameter("@seller_name", SqlDbType.VarChar,50),
					new SqlParameter("@seller_email", SqlDbType.VarChar,128),
					new SqlParameter("@available_confirm_fee", SqlDbType.Money,8),
					new SqlParameter("@has_post_fee", SqlDbType.Bit,1),
					new SqlParameter("@received_payment", SqlDbType.Money,8),
					new SqlParameter("@cod_fee", SqlDbType.Money,8),
					new SqlParameter("@cod_status", SqlDbType.VarChar,50),
					new SqlParameter("@timeout_action_time", SqlDbType.DateTime),
					new SqlParameter("@is_3D", SqlDbType.Bit,1),
					new SqlParameter("@buyer_flag", SqlDbType.Int,4),
					new SqlParameter("@seller_flag", SqlDbType.Int,4),
					new SqlParameter("@promotion", SqlDbType.VarChar,512),
					new SqlParameter("@invoice_name", SqlDbType.VarChar,512),
					new SqlParameter("@trade_from", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_url", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.end_time;
			parameters[2].Value = model.seller_nick;
			parameters[3].Value = model.buyer_nick;
			parameters[4].Value = model.title;
			parameters[5].Value = model.type;
			parameters[6].Value = model.created;
			parameters[7].Value = model.num_iid;
			parameters[8].Value = model.price;
			parameters[9].Value = model.pic_path;
			parameters[10].Value = model.num;
			parameters[11].Value = model.tid;
			parameters[12].Value = model.buyer_message;
			parameters[13].Value = model.shipping_type;
			parameters[14].Value = model.alipay_no;
			parameters[15].Value = model.payment;
			parameters[16].Value = model.discount_fee;
			parameters[17].Value = model.adjust_fee;
			parameters[18].Value = model.snapshot_url;
			parameters[19].Value = model.snapshot;
			parameters[20].Value = model.status;
			parameters[21].Value = model.seller_rate;
			parameters[22].Value = model.buyer_rate;
			parameters[23].Value = model.buyer_memo;
			parameters[24].Value = model.seller_memo;
			parameters[25].Value = model.trade_memo;
			parameters[26].Value = model.pay_time;
			parameters[27].Value = model.modified;
			parameters[28].Value = model.buyer_obtain_point_fee;
			parameters[29].Value = model.point_fee;
			parameters[30].Value = model.real_point_fee;
			parameters[31].Value = model.total_fee;
			parameters[32].Value = model.post_fee;
			parameters[33].Value = model.buyer_alipay_no;
			parameters[34].Value = model.receiver_name;
			parameters[35].Value = model.receiver_state;
			parameters[36].Value = model.receiver_city;
			parameters[37].Value = model.receiver_district;
			parameters[38].Value = model.receiver_address;
			parameters[39].Value = model.receiver_zip;
			parameters[40].Value = model.receiver_mobile;
			parameters[41].Value = model.receiver_phone;
			parameters[42].Value = model.consign_time;
			parameters[43].Value = model.buyer_email;
			parameters[44].Value = model.commission_fee;
			parameters[45].Value = model.seller_alipay_no;
			parameters[46].Value = model.seller_mobile;
			parameters[47].Value = model.seller_phone;
			parameters[48].Value = model.seller_name;
			parameters[49].Value = model.seller_email;
			parameters[50].Value = model.available_confirm_fee;
			parameters[51].Value = model.has_post_fee;
			parameters[52].Value = model.received_payment;
			parameters[53].Value = model.cod_fee;
			parameters[54].Value = model.cod_status;
			parameters[55].Value = model.timeout_action_time;
			parameters[56].Value = model.is_3D;
			parameters[57].Value = model.buyer_flag;
			parameters[58].Value = model.seller_flag;
			parameters[59].Value = model.promotion;
			parameters[60].Value = model.invoice_name;
			parameters[61].Value = model.trade_from;
			parameters[62].Value = model.alipay_url;

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
		public void UpdateM_TradeInfo(M_TradeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_TradeInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("end_time=@end_time,");
			strSql.Append("seller_nick=@seller_nick,");
			strSql.Append("buyer_nick=@buyer_nick,");
			strSql.Append("title=@title,");
			strSql.Append("type=@type,");
			strSql.Append("created=@created,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("price=@price,");
			strSql.Append("pic_path=@pic_path,");
			strSql.Append("num=@num,");
			strSql.Append("tid=@tid,");
			strSql.Append("buyer_message=@buyer_message,");
			strSql.Append("shipping_type=@shipping_type,");
			strSql.Append("alipay_no=@alipay_no,");
			strSql.Append("payment=@payment,");
			strSql.Append("discount_fee=@discount_fee,");
			strSql.Append("adjust_fee=@adjust_fee,");
			strSql.Append("snapshot_url=@snapshot_url,");
			strSql.Append("snapshot=@snapshot,");
			strSql.Append("status=@status,");
			strSql.Append("seller_rate=@seller_rate,");
			strSql.Append("buyer_rate=@buyer_rate,");
			strSql.Append("buyer_memo=@buyer_memo,");
			strSql.Append("seller_memo=@seller_memo,");
			strSql.Append("trade_memo=@trade_memo,");
			strSql.Append("pay_time=@pay_time,");
			strSql.Append("modified=@modified,");
			strSql.Append("buyer_obtain_point_fee=@buyer_obtain_point_fee,");
			strSql.Append("point_fee=@point_fee,");
			strSql.Append("real_point_fee=@real_point_fee,");
			strSql.Append("total_fee=@total_fee,");
			strSql.Append("post_fee=@post_fee,");
			strSql.Append("buyer_alipay_no=@buyer_alipay_no,");
			strSql.Append("receiver_name=@receiver_name,");
			strSql.Append("receiver_state=@receiver_state,");
			strSql.Append("receiver_city=@receiver_city,");
			strSql.Append("receiver_district=@receiver_district,");
			strSql.Append("receiver_address=@receiver_address,");
			strSql.Append("receiver_zip=@receiver_zip,");
			strSql.Append("receiver_mobile=@receiver_mobile,");
			strSql.Append("receiver_phone=@receiver_phone,");
			strSql.Append("consign_time=@consign_time,");
			strSql.Append("buyer_email=@buyer_email,");
			strSql.Append("commission_fee=@commission_fee,");
			strSql.Append("seller_alipay_no=@seller_alipay_no,");
			strSql.Append("seller_mobile=@seller_mobile,");
			strSql.Append("seller_phone=@seller_phone,");
			strSql.Append("seller_name=@seller_name,");
			strSql.Append("seller_email=@seller_email,");
			strSql.Append("available_confirm_fee=@available_confirm_fee,");
			strSql.Append("has_post_fee=@has_post_fee,");
			strSql.Append("received_payment=@received_payment,");
			strSql.Append("cod_fee=@cod_fee,");
			strSql.Append("cod_status=@cod_status,");
			strSql.Append("timeout_action_time=@timeout_action_time,");
			strSql.Append("is_3D=@is_3D,");
			strSql.Append("buyer_flag=@buyer_flag,");
			strSql.Append("seller_flag=@seller_flag,");
			strSql.Append("promotion=@promotion,");
			strSql.Append("invoice_name=@invoice_name,");
			strSql.Append("trade_from=@trade_from,");
			strSql.Append("alipay_url=@alipay_url");
			strSql.Append(" where m_TradeInfoID=@m_TradeInfoID ;");


            if (model.orders != null)
            {
                //删除非更新或新建的数据
                strSql.Append("declare @m_OrderInfoID varchar(1024);set @m_OrderInfoID='0';");
                foreach (M_OrderInfo mo in model.orders)
                {
                    strSql.Append("select @m_OrderInfoID = @m_OrderInfoID+','+ convert(varchar,m_OrderInfoID) from tb_M_OrderInfo  where m_ConfigInfoID=@m_ConfigInfoID and m_TradeInfoID=@m_TradeInfoID and oid=" + mo.oid + ";");
                }

                strSql.Append("set @m_OrderInfoID=','+@m_OrderInfoID+',';delete tb_M_OrderInfo where charindex(','+convert(varchar,m_OrderInfoID)+',',@m_OrderInfoID)<=0 and   m_ConfigInfoID=@m_ConfigInfoID and m_TradeInfoID=@m_TradeInfoID;");

                foreach (M_OrderInfo mo in model.orders)
                {
                    strSql.Append(" if exists(select 0 from tb_M_OrderInfo where m_ConfigInfoID=@m_ConfigInfoID and m_TradeInfoID=@m_TradeInfoID and oid=" + mo.oid + ") \r\n");
                    strSql.Append(" begin \r\n");
                    strSql.Append(" update tb_M_OrderInfo set num_iid="+mo.num_iid+",total_fee="+mo.total_fee+",discount_fee="+mo.discount_fee+",adjust_fee="+mo.adjust_fee+","+
                        "sku_id='"+mo.sku_id+"',sku_properties_name='"+mo.sku_properties_name+"',item_meal_name='"+mo.item_meal_name+"',num="+mo.num+",title='"+mo.title+"',"+
                        "price="+mo.price+",pic_path='"+mo.pic_path+"',seller_nick='"+mo.seller_nick+"',buyer_nick='"+mo.buyer_nick+"',created='"+mo.created+"',refund_status='"+mo.refund_status+"',"+
                        "outer_iid='"+mo.outer_iid+"',outer_sku_id='"+mo.outer_sku_id+"',payment='"+mo.payment+"',status='"+mo.status+"',snapshot_url='"+mo.snapshot_url+"',snapshot='"+mo.snapshot+"',"+
                        "timeout_action_time='"+mo.timeout_action_time+"',buyer_rate="+(mo.buyer_rate?1:0)+",seller_rate="+(mo.seller_rate?1:0)+",refund_id="+mo.refund_id+",seller_type='"+mo.seller_type+"',"+
                        "modified='"+mo.modified+"',cid="+mo.cid+",is_oversold="+(mo.is_oversold?1:0)+" where  m_ConfigInfoID=@m_ConfigInfoID and m_TradeInfoID=@m_TradeInfoID and oid=" + mo.oid + " ;");
                    strSql.Append("end \r\n");
                    strSql.Append("else \r\n");
                    strSql.Append("begin \r\n");
                    strSql.Append(" insert into tb_M_OrderInfo(m_ConfigInfoID,m_TradeInfoID,num_iid,total_fee,discount_fee,adjust_fee,sku_id,sku_properties_name,item_meal_name,num,title,price,pic_path,seller_nick,buyer_nick,created,refund_status,oid,outer_iid,outer_sku_id,payment,status,snapshot_url,snapshot,timeout_action_time,buyer_rate,seller_rate,refund_id,seller_type,modified,cid,is_oversold)");
                    strSql.Append(" values(@m_ConfigInfoID,@m_TradeInfoID," + mo.num_iid + "," + mo.total_fee + "," + mo.discount_fee + "," + mo.adjust_fee + ",'" + mo.sku_id + "','" + mo.sku_properties_name + "','" + mo.item_meal_name + "'," + mo.num + ",'" + mo.title + "'," + mo.price + ",'" + mo.pic_path + "','" + mo.seller_nick + "','" + mo.buyer_nick + "','" + mo.created + "','" + mo.refund_status + "'," + mo.oid + ",'" + mo.outer_iid + "','" + mo.outer_sku_id + "'," + mo.payment + ",'" + mo.status + "','" + mo.snapshot_url + "','" + mo.snapshot + "','" + mo.timeout_action_time + "'," + (mo.buyer_rate ? 1 : 0) + "," + (mo.seller_rate ? 1 : 0) + "," + mo.refund_id + ",'" + mo.seller_type + "','" + mo.modified + "'," + mo.cid + "," + (mo.is_oversold ? 1 : 0) + ");");
                    strSql.Append("end \r\n");
                }
            }

            if (model.promotion_details != null)
            {
                //删除非更新或新建的数据
                strSql.Append("declare @m_Order_PromotionDetailInfoID varchar(1024);set @m_Order_PromotionDetailInfoID='0';");
                foreach (M_OrderPromotionDetailInfo mop in model.promotion_details)
                {
                    strSql.Append("select @m_Order_PromotionDetailInfoID = @m_Order_PromotionDetailInfoID+','+ convert(varchar,m_Order_PromotionDetailInfoID) from tb_M_OrderPromotionDetailInfo  where m_Type=1 and m_ObjID=@m_TradeInfoID and m_id=" + mop.m_id + ";");
                }

                strSql.Append("set @m_Order_PromotionDetailInfoID =','+m_Order_PromotionDetailInfoID+',' ;delete tb_M_OrderPromotionDetailInfo where charindex(','+convert(varchar,m_Order_PromotionDetailInfoID)+',',@m_Order_PromotionDetailInfoID)<=0 and m_Type=1 and m_ObjID=@m_TradeInfoID;");

                foreach (M_OrderPromotionDetailInfo mop in model.promotion_details)
                {
                    strSql.Append(" if exists(select 0 from tb_M_OrderPromotionDetailInfo where m_Type=1 and m_ObjID=@m_TradeInfoID and m_id=" + mop.m_id + ") \r\n");
                    strSql.Append(" begin \r\n");
                    strSql.Append(" update tb_M_OrderPromotionDetailInfo set promotion_name='" + mop.promotion_name + "',discount_fee=" + mop.discount_fee + ",gift_item_name='" + mop.gift_item_name + "' where m_Type=1 and m_ObjID=@m_TradeInfoID and m_id=" + mop.m_id + " ;");
                    strSql.Append("end \r\n");
                    strSql.Append("else \r\n");
                    strSql.Append("begin \r\n");
                    strSql.Append(" insert into tb_M_OrderPromotionDetailInfo(m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name)");
                    strSql.Append(" values(1,@m_TradeInfoID," + mop.m_id + ",'" + mop.promotion_name + "'," + mop.discount_fee + ",'" + mop.gift_item_name + "');");
                    strSql.Append("end \r\n");
                }
            }


			SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@seller_nick", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,512),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pic_path", SqlDbType.VarChar,512),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.BigInt),
					new SqlParameter("@buyer_message", SqlDbType.VarChar,512),
					new SqlParameter("@shipping_type", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@payment", SqlDbType.Money,8),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@adjust_fee", SqlDbType.Money,8),
					new SqlParameter("@snapshot_url", SqlDbType.VarChar,512),
					new SqlParameter("@snapshot", SqlDbType.VarChar,512),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@seller_rate", SqlDbType.Bit,1),
					new SqlParameter("@buyer_rate", SqlDbType.Bit,1),
					new SqlParameter("@buyer_memo", SqlDbType.VarChar,512),
					new SqlParameter("@seller_memo", SqlDbType.VarChar,512),
					new SqlParameter("@trade_memo", SqlDbType.VarChar,512),
					new SqlParameter("@pay_time", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@buyer_obtain_point_fee", SqlDbType.Int,4),
					new SqlParameter("@point_fee", SqlDbType.Int,4),
					new SqlParameter("@real_point_fee", SqlDbType.Int,4),
					new SqlParameter("@total_fee", SqlDbType.Money,8),
					new SqlParameter("@post_fee", SqlDbType.Money,8),
					new SqlParameter("@buyer_alipay_no", SqlDbType.VarChar,128),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_state", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_city", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_district", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_address", SqlDbType.VarChar,512),
					new SqlParameter("@receiver_zip", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@receiver_phone", SqlDbType.VarChar,50),
					new SqlParameter("@consign_time", SqlDbType.DateTime),
					new SqlParameter("@buyer_email", SqlDbType.VarChar,50),
					new SqlParameter("@commission_fee", SqlDbType.Money,8),
					new SqlParameter("@seller_alipay_no", SqlDbType.VarChar,128),
					new SqlParameter("@seller_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.VarChar,50),
					new SqlParameter("@seller_name", SqlDbType.VarChar,50),
					new SqlParameter("@seller_email", SqlDbType.VarChar,128),
					new SqlParameter("@available_confirm_fee", SqlDbType.Money,8),
					new SqlParameter("@has_post_fee", SqlDbType.Bit,1),
					new SqlParameter("@received_payment", SqlDbType.Money,8),
					new SqlParameter("@cod_fee", SqlDbType.Money,8),
					new SqlParameter("@cod_status", SqlDbType.VarChar,50),
					new SqlParameter("@timeout_action_time", SqlDbType.DateTime),
					new SqlParameter("@is_3D", SqlDbType.Bit,1),
					new SqlParameter("@buyer_flag", SqlDbType.Int,4),
					new SqlParameter("@seller_flag", SqlDbType.Int,4),
					new SqlParameter("@promotion", SqlDbType.VarChar,512),
					new SqlParameter("@invoice_name", SqlDbType.VarChar,512),
					new SqlParameter("@trade_from", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_url", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_TradeInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.end_time;
			parameters[3].Value = model.seller_nick;
			parameters[4].Value = model.buyer_nick;
			parameters[5].Value = model.title;
			parameters[6].Value = model.type;
			parameters[7].Value = model.created;
			parameters[8].Value = model.num_iid;
			parameters[9].Value = model.price;
			parameters[10].Value = model.pic_path;
			parameters[11].Value = model.num;
			parameters[12].Value = model.tid;
			parameters[13].Value = model.buyer_message;
			parameters[14].Value = model.shipping_type;
			parameters[15].Value = model.alipay_no;
			parameters[16].Value = model.payment;
			parameters[17].Value = model.discount_fee;
			parameters[18].Value = model.adjust_fee;
			parameters[19].Value = model.snapshot_url;
			parameters[20].Value = model.snapshot;
			parameters[21].Value = model.status;
			parameters[22].Value = model.seller_rate;
			parameters[23].Value = model.buyer_rate;
			parameters[24].Value = model.buyer_memo;
			parameters[25].Value = model.seller_memo;
			parameters[26].Value = model.trade_memo;
			parameters[27].Value = model.pay_time;
			parameters[28].Value = model.modified;
			parameters[29].Value = model.buyer_obtain_point_fee;
			parameters[30].Value = model.point_fee;
			parameters[31].Value = model.real_point_fee;
			parameters[32].Value = model.total_fee;
			parameters[33].Value = model.post_fee;
			parameters[34].Value = model.buyer_alipay_no;
			parameters[35].Value = model.receiver_name;
			parameters[36].Value = model.receiver_state;
			parameters[37].Value = model.receiver_city;
			parameters[38].Value = model.receiver_district;
			parameters[39].Value = model.receiver_address;
			parameters[40].Value = model.receiver_zip;
			parameters[41].Value = model.receiver_mobile;
			parameters[42].Value = model.receiver_phone;
			parameters[43].Value = model.consign_time;
			parameters[44].Value = model.buyer_email;
			parameters[45].Value = model.commission_fee;
			parameters[46].Value = model.seller_alipay_no;
			parameters[47].Value = model.seller_mobile;
			parameters[48].Value = model.seller_phone;
			parameters[49].Value = model.seller_name;
			parameters[50].Value = model.seller_email;
			parameters[51].Value = model.available_confirm_fee;
			parameters[52].Value = model.has_post_fee;
			parameters[53].Value = model.received_payment;
			parameters[54].Value = model.cod_fee;
			parameters[55].Value = model.cod_status;
			parameters[56].Value = model.timeout_action_time;
			parameters[57].Value = model.is_3D;
			parameters[58].Value = model.buyer_flag;
			parameters[59].Value = model.seller_flag;
			parameters[60].Value = model.promotion;
			parameters[61].Value = model.invoice_name;
			parameters[62].Value = model.trade_from;
			parameters[63].Value = model.alipay_url;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 更新交易状态
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <param name="status"></param>
        public void UpdateM_TradeStatus(int m_TradeInfoID, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_TradeInfo set status=@status where m_TradeInfoID=@m_TradeInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@status", SqlDbType.VarChar,50),
                    new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = status;
            parameters[1].Value = m_TradeInfoID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_TradeInfo(int m_TradeInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_TradeInfo ");
			strSql.Append(" where m_TradeInfoID=@m_TradeInfoID; ");
            strSql.Append("delete from tb_M_OrderInfo ");
            strSql.Append(" where m_TradeInfoID=@m_TradeInfoID; ");
            strSql.Append("delete from tb_M_ShippingInfo ");
            strSql.Append(" where m_TradeInfoID=@m_TradeInfoID; ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_TradeInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteM_TradeInfo(int m_ConfigInfoID,int m_TradeInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_TradeInfo ");
            strSql.Append(" where m_TradeInfoID=@m_TradeInfoID and m_ConfigInfoID=@m_ConfigInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_TradeInfoID;
            parameters[1].Value = m_ConfigInfoID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_TradeInfo GetM_TradeInfoModel(int m_TradeInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_TradeInfoID,m_ConfigInfoID,end_time,seller_nick,buyer_nick,title,type,created,num_iid,price,pic_path,num,tid,buyer_message,shipping_type,alipay_no,payment,discount_fee,adjust_fee,snapshot_url,snapshot,status,seller_rate,buyer_rate,buyer_memo,seller_memo,trade_memo,pay_time,modified,buyer_obtain_point_fee,point_fee,real_point_fee,total_fee,post_fee,buyer_alipay_no,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,consign_time,buyer_email,commission_fee,seller_alipay_no,seller_mobile,seller_phone,seller_name,seller_email,available_confirm_fee,has_post_fee,received_payment,cod_fee,cod_status,timeout_action_time,is_3D,buyer_flag,seller_flag,promotion,invoice_name,trade_from,alipay_url from tb_M_TradeInfo ");
			strSql.Append(" where m_TradeInfoID=@m_TradeInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_TradeInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_TradeInfoID;

			M_TradeInfo model=new M_TradeInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString()!="")
				{
					model.m_TradeInfoID=int.Parse(ds.Tables[0].Rows[0]["m_TradeInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["end_time"].ToString()!="")
				{
					model.end_time=DateTime.Parse(ds.Tables[0].Rows[0]["end_time"].ToString());
				}
				model.seller_nick=ds.Tables[0].Rows[0]["seller_nick"].ToString();
				model.buyer_nick=ds.Tables[0].Rows[0]["buyer_nick"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=long.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				model.pic_path=ds.Tables[0].Rows[0]["pic_path"].ToString();
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tid"].ToString()!="")
				{
					model.tid=long.Parse(ds.Tables[0].Rows[0]["tid"].ToString());
				}
				model.buyer_message=ds.Tables[0].Rows[0]["buyer_message"].ToString();
				model.shipping_type=ds.Tables[0].Rows[0]["shipping_type"].ToString();
				model.alipay_no=ds.Tables[0].Rows[0]["alipay_no"].ToString();
				if(ds.Tables[0].Rows[0]["payment"].ToString()!="")
				{
					model.payment=decimal.Parse(ds.Tables[0].Rows[0]["payment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["discount_fee"].ToString()!="")
				{
					model.discount_fee=decimal.Parse(ds.Tables[0].Rows[0]["discount_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["adjust_fee"].ToString()!="")
				{
					model.adjust_fee=decimal.Parse(ds.Tables[0].Rows[0]["adjust_fee"].ToString());
				}
				model.snapshot_url=ds.Tables[0].Rows[0]["snapshot_url"].ToString();
				model.snapshot=ds.Tables[0].Rows[0]["snapshot"].ToString();
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
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
				model.buyer_memo=ds.Tables[0].Rows[0]["buyer_memo"].ToString();
				model.seller_memo=ds.Tables[0].Rows[0]["seller_memo"].ToString();
				model.trade_memo=ds.Tables[0].Rows[0]["trade_memo"].ToString();
				if(ds.Tables[0].Rows[0]["pay_time"].ToString()!="")
				{
					model.pay_time=DateTime.Parse(ds.Tables[0].Rows[0]["pay_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["buyer_obtain_point_fee"].ToString()!="")
				{
					model.buyer_obtain_point_fee=int.Parse(ds.Tables[0].Rows[0]["buyer_obtain_point_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["point_fee"].ToString()!="")
				{
					model.point_fee=int.Parse(ds.Tables[0].Rows[0]["point_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["real_point_fee"].ToString()!="")
				{
					model.real_point_fee=int.Parse(ds.Tables[0].Rows[0]["real_point_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["total_fee"].ToString()!="")
				{
					model.total_fee=decimal.Parse(ds.Tables[0].Rows[0]["total_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["post_fee"].ToString()!="")
				{
					model.post_fee=decimal.Parse(ds.Tables[0].Rows[0]["post_fee"].ToString());
				}
				model.buyer_alipay_no=ds.Tables[0].Rows[0]["buyer_alipay_no"].ToString();
				model.receiver_name=ds.Tables[0].Rows[0]["receiver_name"].ToString();
				model.receiver_state=ds.Tables[0].Rows[0]["receiver_state"].ToString();
				model.receiver_city=ds.Tables[0].Rows[0]["receiver_city"].ToString();
				model.receiver_district=ds.Tables[0].Rows[0]["receiver_district"].ToString();
				model.receiver_address=ds.Tables[0].Rows[0]["receiver_address"].ToString();
				model.receiver_zip=ds.Tables[0].Rows[0]["receiver_zip"].ToString();
				model.receiver_mobile=ds.Tables[0].Rows[0]["receiver_mobile"].ToString();
				model.receiver_phone=ds.Tables[0].Rows[0]["receiver_phone"].ToString();
				if(ds.Tables[0].Rows[0]["consign_time"].ToString()!="")
				{
					model.consign_time=DateTime.Parse(ds.Tables[0].Rows[0]["consign_time"].ToString());
				}
				model.buyer_email=ds.Tables[0].Rows[0]["buyer_email"].ToString();
				if(ds.Tables[0].Rows[0]["commission_fee"].ToString()!="")
				{
					model.commission_fee=decimal.Parse(ds.Tables[0].Rows[0]["commission_fee"].ToString());
				}
				model.seller_alipay_no=ds.Tables[0].Rows[0]["seller_alipay_no"].ToString();
				model.seller_mobile=ds.Tables[0].Rows[0]["seller_mobile"].ToString();
				model.seller_phone=ds.Tables[0].Rows[0]["seller_phone"].ToString();
				model.seller_name=ds.Tables[0].Rows[0]["seller_name"].ToString();
				model.seller_email=ds.Tables[0].Rows[0]["seller_email"].ToString();
				if(ds.Tables[0].Rows[0]["available_confirm_fee"].ToString()!="")
				{
					model.available_confirm_fee=decimal.Parse(ds.Tables[0].Rows[0]["available_confirm_fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["has_post_fee"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_post_fee"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_post_fee"].ToString().ToLower()=="true"))
					{
						model.has_post_fee=true;
					}
					else
					{
						model.has_post_fee=false;
					}
				}
				if(ds.Tables[0].Rows[0]["received_payment"].ToString()!="")
				{
					model.received_payment=decimal.Parse(ds.Tables[0].Rows[0]["received_payment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cod_fee"].ToString()!="")
				{
					model.cod_fee=decimal.Parse(ds.Tables[0].Rows[0]["cod_fee"].ToString());
				}
				model.cod_status=ds.Tables[0].Rows[0]["cod_status"].ToString();
				if(ds.Tables[0].Rows[0]["timeout_action_time"].ToString()!="")
				{
					model.timeout_action_time=DateTime.Parse(ds.Tables[0].Rows[0]["timeout_action_time"].ToString());
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
				if(ds.Tables[0].Rows[0]["buyer_flag"].ToString()!="")
				{
					model.buyer_flag=int.Parse(ds.Tables[0].Rows[0]["buyer_flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["seller_flag"].ToString()!="")
				{
					model.seller_flag=int.Parse(ds.Tables[0].Rows[0]["seller_flag"].ToString());
				}
				model.promotion=ds.Tables[0].Rows[0]["promotion"].ToString();
				model.invoice_name=ds.Tables[0].Rows[0]["invoice_name"].ToString();
				model.trade_from=ds.Tables[0].Rows[0]["trade_from"].ToString();
				model.alipay_url=ds.Tables[0].Rows[0]["alipay_url"].ToString();
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
		public DataSet GetM_TradeInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_TradeInfoID,m_ConfigInfoID,end_time,seller_nick,buyer_nick,title,type,created,num_iid,price,pic_path,num,tid,buyer_message,shipping_type,alipay_no,payment,discount_fee,adjust_fee,snapshot_url,snapshot,status,seller_rate,buyer_rate,buyer_memo,seller_memo,trade_memo,pay_time,modified,buyer_obtain_point_fee,point_fee,real_point_fee,total_fee,post_fee,buyer_alipay_no,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,consign_time,buyer_email,commission_fee,seller_alipay_no,seller_mobile,seller_phone,seller_name,seller_email,available_confirm_fee,has_post_fee,received_payment,cod_fee,cod_status,timeout_action_time,is_3D,buyer_flag,seller_flag,promotion,invoice_name,trade_from,alipay_url ");
			strSql.Append(" FROM tb_M_TradeInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_TradeInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_TradeInfoID,m_ConfigInfoID,end_time,seller_nick,buyer_nick,title,type,created,num_iid,price,pic_path,num,tid,buyer_message,shipping_type,alipay_no,payment,discount_fee,adjust_fee,snapshot_url,snapshot,status,seller_rate,buyer_rate,buyer_memo,seller_memo,trade_memo,pay_time,modified,buyer_obtain_point_fee,point_fee,real_point_fee,total_fee,post_fee,buyer_alipay_no,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,consign_time,buyer_email,commission_fee,seller_alipay_no,seller_mobile,seller_phone,seller_name,seller_email,available_confirm_fee,has_post_fee,received_payment,cod_fee,cod_status,timeout_action_time,is_3D,buyer_flag,seller_flag,promotion,invoice_name,trade_from,alipay_url ");
			strSql.Append(" FROM tb_M_TradeInfo ");
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
		public DataTable GetM_TradeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_TradeInfo";
			parameters[1].Value = "M_TradeInfoID";
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


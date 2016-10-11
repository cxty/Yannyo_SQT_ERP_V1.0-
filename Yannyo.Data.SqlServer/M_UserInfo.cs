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
	/// 数据访问类M_UserInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  网店客户信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_UserInfo(int m_ConfigInfoID, long user_id, string uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_UserInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and user_id=@user_id and uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@user_id", SqlDbType.BigInt),
                                        new SqlParameter("@uid", SqlDbType.VarChar,50)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = user_id;
            parameters[2].Value = uid;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_UserInfo(M_UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_UserInfo(");
			strSql.Append("m_ConfigInfoID,user_id,uid,nick,sex,created,last_visit,birthday,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,email,magazine_subscribe,vertical_market,avatar,online_gaming,m_AppendTime,m_UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@user_id,@uid,@nick,@sex,@created,@last_visit,@birthday,@type,@has_more_pic,@item_img_num,@item_img_size,@prop_img_num,@prop_img_sizec,@auto_repost,@promoted_type,@status,@alipay_bind,@consumer_protection,@alipay_account,@alipay_no,@email,@magazine_subscribe,@vertical_market,@avatar,@online_gaming,@m_AppendTime,@m_UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.BigInt),
					new SqlParameter("@uid", SqlDbType.VarChar,50),
					new SqlParameter("@nick", SqlDbType.VarChar,50),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@last_visit", SqlDbType.DateTime),
					new SqlParameter("@birthday", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@has_more_pic", SqlDbType.Bit,1),
					new SqlParameter("@item_img_num", SqlDbType.Int,4),
					new SqlParameter("@item_img_size", SqlDbType.Int,4),
					new SqlParameter("@prop_img_num", SqlDbType.Int,4),
					new SqlParameter("@prop_img_sizec", SqlDbType.Int,4),
					new SqlParameter("@auto_repost", SqlDbType.VarChar,50),
					new SqlParameter("@promoted_type", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_bind", SqlDbType.VarChar,50),
					new SqlParameter("@consumer_protection", SqlDbType.Int,4),
					new SqlParameter("@alipay_account", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@magazine_subscribe", SqlDbType.Bit,1),
					new SqlParameter("@vertical_market", SqlDbType.VarChar,128),
					new SqlParameter("@avatar", SqlDbType.VarChar,256),
					new SqlParameter("@online_gaming", SqlDbType.Bit,1),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime),
					new SqlParameter("@m_UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.user_id;
			parameters[2].Value = model.uid;
			parameters[3].Value = model.nick;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.created;
			parameters[6].Value = model.last_visit;
			parameters[7].Value = model.birthday;
			parameters[8].Value = model.type;
			parameters[9].Value = model.has_more_pic;
			parameters[10].Value = model.item_img_num;
			parameters[11].Value = model.item_img_size;
			parameters[12].Value = model.prop_img_num;
			parameters[13].Value = model.prop_img_sizec;
			parameters[14].Value = model.auto_repost;
			parameters[15].Value = model.promoted_type;
			parameters[16].Value = model.status;
			parameters[17].Value = model.alipay_bind;
			parameters[18].Value = model.consumer_protection;
			parameters[19].Value = model.alipay_account;
			parameters[20].Value = model.alipay_no;
			parameters[21].Value = model.email;
			parameters[22].Value = model.magazine_subscribe;
			parameters[23].Value = model.vertical_market;
			parameters[24].Value = model.avatar;
			parameters[25].Value = model.online_gaming;
			parameters[26].Value = model.m_AppendTime;
			parameters[27].Value = model.m_UpdateTime;

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
		public void UpdateM_UserInfo(M_UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_UserInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("uid=@uid,");
			strSql.Append("nick=@nick,");
			strSql.Append("sex=@sex,");
			strSql.Append("created=@created,");
			strSql.Append("last_visit=@last_visit,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("type=@type,");
			strSql.Append("has_more_pic=@has_more_pic,");
			strSql.Append("item_img_num=@item_img_num,");
			strSql.Append("item_img_size=@item_img_size,");
			strSql.Append("prop_img_num=@prop_img_num,");
			strSql.Append("prop_img_sizec=@prop_img_sizec,");
			strSql.Append("auto_repost=@auto_repost,");
			strSql.Append("promoted_type=@promoted_type,");
			strSql.Append("status=@status,");
			strSql.Append("alipay_bind=@alipay_bind,");
			strSql.Append("consumer_protection=@consumer_protection,");
			strSql.Append("alipay_account=@alipay_account,");
			strSql.Append("alipay_no=@alipay_no,");
			strSql.Append("email=@email,");
			strSql.Append("magazine_subscribe=@magazine_subscribe,");
			strSql.Append("vertical_market=@vertical_market,");
			strSql.Append("avatar=@avatar,");
			strSql.Append("online_gaming=@online_gaming,");
			strSql.Append("m_AppendTime=@m_AppendTime,");
			strSql.Append("m_UpdateTime=@m_UpdateTime");
			strSql.Append(" where m_UserInfoID=@m_UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.VarChar,50),
					new SqlParameter("@nick", SqlDbType.VarChar,50),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@last_visit", SqlDbType.DateTime),
					new SqlParameter("@birthday", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@has_more_pic", SqlDbType.Bit,1),
					new SqlParameter("@item_img_num", SqlDbType.Int,4),
					new SqlParameter("@item_img_size", SqlDbType.Int,4),
					new SqlParameter("@prop_img_num", SqlDbType.Int,4),
					new SqlParameter("@prop_img_sizec", SqlDbType.Int,4),
					new SqlParameter("@auto_repost", SqlDbType.VarChar,50),
					new SqlParameter("@promoted_type", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_bind", SqlDbType.VarChar,50),
					new SqlParameter("@consumer_protection", SqlDbType.Int,4),
					new SqlParameter("@alipay_account", SqlDbType.VarChar,50),
					new SqlParameter("@alipay_no", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@magazine_subscribe", SqlDbType.Bit,1),
					new SqlParameter("@vertical_market", SqlDbType.VarChar,128),
					new SqlParameter("@avatar", SqlDbType.VarChar,256),
					new SqlParameter("@online_gaming", SqlDbType.Bit,1),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime),
					new SqlParameter("@m_UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_UserInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.user_id;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.nick;
			parameters[5].Value = model.sex;
			parameters[6].Value = model.created;
			parameters[7].Value = model.last_visit;
			parameters[8].Value = model.birthday;
			parameters[9].Value = model.type;
			parameters[10].Value = model.has_more_pic;
			parameters[11].Value = model.item_img_num;
			parameters[12].Value = model.item_img_size;
			parameters[13].Value = model.prop_img_num;
			parameters[14].Value = model.prop_img_sizec;
			parameters[15].Value = model.auto_repost;
			parameters[16].Value = model.promoted_type;
			parameters[17].Value = model.status;
			parameters[18].Value = model.alipay_bind;
			parameters[19].Value = model.consumer_protection;
			parameters[20].Value = model.alipay_account;
			parameters[21].Value = model.alipay_no;
			parameters[22].Value = model.email;
			parameters[23].Value = model.magazine_subscribe;
			parameters[24].Value = model.vertical_market;
			parameters[25].Value = model.avatar;
			parameters[26].Value = model.online_gaming;
			parameters[27].Value = model.m_AppendTime;
			parameters[28].Value = model.m_UpdateTime;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_UserInfo(int m_UserInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_UserInfo ");
			strSql.Append(" where m_UserInfoID=@m_UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_UserInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_UserInfo GetM_UserInfoModel(int m_UserInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_UserInfoID,m_ConfigInfoID,user_id,uid,nick,sex,created,last_visit,birthday,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,email,magazine_subscribe,vertical_market,avatar,online_gaming,m_AppendTime,m_UpdateTime from tb_M_UserInfo ");
			strSql.Append(" where m_UserInfoID=@m_UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_UserInfoID;

			M_UserInfo model=new M_UserInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString()!="")
				{
					model.m_UserInfoID=int.Parse(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				model.uid=ds.Tables[0].Rows[0]["uid"].ToString();
				model.nick=ds.Tables[0].Rows[0]["nick"].ToString();
				model.sex=ds.Tables[0].Rows[0]["sex"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["last_visit"].ToString()!="")
				{
					model.last_visit=DateTime.Parse(ds.Tables[0].Rows[0]["last_visit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["birthday"].ToString()!="")
				{
					model.birthday=ds.Tables[0].Rows[0]["birthday"].ToString();
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["has_more_pic"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["has_more_pic"].ToString()=="1")||(ds.Tables[0].Rows[0]["has_more_pic"].ToString().ToLower()=="true"))
					{
						model.has_more_pic=true;
					}
					else
					{
						model.has_more_pic=false;
					}
				}
				if(ds.Tables[0].Rows[0]["item_img_num"].ToString()!="")
				{
					model.item_img_num=int.Parse(ds.Tables[0].Rows[0]["item_img_num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["item_img_size"].ToString()!="")
				{
					model.item_img_size=int.Parse(ds.Tables[0].Rows[0]["item_img_size"].ToString());
				}
				if(ds.Tables[0].Rows[0]["prop_img_num"].ToString()!="")
				{
					model.prop_img_num=int.Parse(ds.Tables[0].Rows[0]["prop_img_num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["prop_img_sizec"].ToString()!="")
				{
					model.prop_img_sizec=int.Parse(ds.Tables[0].Rows[0]["prop_img_sizec"].ToString());
				}
				model.auto_repost=ds.Tables[0].Rows[0]["auto_repost"].ToString();
				model.promoted_type=ds.Tables[0].Rows[0]["promoted_type"].ToString();
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
				model.alipay_bind=ds.Tables[0].Rows[0]["alipay_bind"].ToString();
				if(ds.Tables[0].Rows[0]["consumer_protection"].ToString()!="")
				{
					model.consumer_protection=int.Parse(ds.Tables[0].Rows[0]["consumer_protection"].ToString());
				}
				model.alipay_account=ds.Tables[0].Rows[0]["alipay_account"].ToString();
				model.alipay_no=ds.Tables[0].Rows[0]["alipay_no"].ToString();
				model.email=ds.Tables[0].Rows[0]["email"].ToString();
				if(ds.Tables[0].Rows[0]["magazine_subscribe"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["magazine_subscribe"].ToString()=="1")||(ds.Tables[0].Rows[0]["magazine_subscribe"].ToString().ToLower()=="true"))
					{
						model.magazine_subscribe=true;
					}
					else
					{
						model.magazine_subscribe=false;
					}
				}
				model.vertical_market=ds.Tables[0].Rows[0]["vertical_market"].ToString();
				model.avatar=ds.Tables[0].Rows[0]["avatar"].ToString();
				if(ds.Tables[0].Rows[0]["online_gaming"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["online_gaming"].ToString()=="1")||(ds.Tables[0].Rows[0]["online_gaming"].ToString().ToLower()=="true"))
					{
						model.online_gaming=true;
					}
					else
					{
						model.online_gaming=false;
					}
				}
				if(ds.Tables[0].Rows[0]["m_AppendTime"].ToString()!="")
				{
					model.m_AppendTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_AppendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString()!="")
				{
					model.m_UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        public M_UserInfo GetM_UserInfoModel(int m_ConfigInfoID, long user_id, string uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_UserInfoID,m_ConfigInfoID,user_id,uid,nick,sex,created,last_visit,birthday,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,email,magazine_subscribe,vertical_market,avatar,online_gaming,m_AppendTime,m_UpdateTime from tb_M_UserInfo ");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and user_id=@user_id and uid=@uid");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                    new SqlParameter("@user_id", SqlDbType.BigInt),
                    new SqlParameter("@uid", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = user_id;
            parameters[2].Value = uid;

            M_UserInfo model = new M_UserInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_UserInfoID"].ToString() != "")
                {
                    model.m_UserInfoID = int.Parse(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                model.uid = ds.Tables[0].Rows[0]["uid"].ToString();
                model.nick = ds.Tables[0].Rows[0]["nick"].ToString();
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                if (ds.Tables[0].Rows[0]["created"].ToString() != "")
                {
                    model.created = DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["last_visit"].ToString() != "")
                {
                    model.last_visit = DateTime.Parse(ds.Tables[0].Rows[0]["last_visit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                }
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                if (ds.Tables[0].Rows[0]["has_more_pic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["has_more_pic"].ToString() == "1") || (ds.Tables[0].Rows[0]["has_more_pic"].ToString().ToLower() == "true"))
                    {
                        model.has_more_pic = true;
                    }
                    else
                    {
                        model.has_more_pic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["item_img_num"].ToString() != "")
                {
                    model.item_img_num = int.Parse(ds.Tables[0].Rows[0]["item_img_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item_img_size"].ToString() != "")
                {
                    model.item_img_size = int.Parse(ds.Tables[0].Rows[0]["item_img_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["prop_img_num"].ToString() != "")
                {
                    model.prop_img_num = int.Parse(ds.Tables[0].Rows[0]["prop_img_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["prop_img_sizec"].ToString() != "")
                {
                    model.prop_img_sizec = int.Parse(ds.Tables[0].Rows[0]["prop_img_sizec"].ToString());
                }
                model.auto_repost = ds.Tables[0].Rows[0]["auto_repost"].ToString();
                model.promoted_type = ds.Tables[0].Rows[0]["promoted_type"].ToString();
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                model.alipay_bind = ds.Tables[0].Rows[0]["alipay_bind"].ToString();
                if (ds.Tables[0].Rows[0]["consumer_protection"].ToString() != "")
                {
                    model.consumer_protection = int.Parse(ds.Tables[0].Rows[0]["consumer_protection"].ToString());
                }
                model.alipay_account = ds.Tables[0].Rows[0]["alipay_account"].ToString();
                model.alipay_no = ds.Tables[0].Rows[0]["alipay_no"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                if (ds.Tables[0].Rows[0]["magazine_subscribe"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["magazine_subscribe"].ToString() == "1") || (ds.Tables[0].Rows[0]["magazine_subscribe"].ToString().ToLower() == "true"))
                    {
                        model.magazine_subscribe = true;
                    }
                    else
                    {
                        model.magazine_subscribe = false;
                    }
                }
                model.vertical_market = ds.Tables[0].Rows[0]["vertical_market"].ToString();
                model.avatar = ds.Tables[0].Rows[0]["avatar"].ToString();
                if (ds.Tables[0].Rows[0]["online_gaming"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["online_gaming"].ToString() == "1") || (ds.Tables[0].Rows[0]["online_gaming"].ToString().ToLower() == "true"))
                    {
                        model.online_gaming = true;
                    }
                    else
                    {
                        model.online_gaming = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["m_AppendTime"].ToString() != "")
                {
                    model.m_AppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_AppendTime"].ToString());
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetM_UserInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_UserInfoID,m_ConfigInfoID,user_id,uid,nick,sex,created,last_visit,birthday,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,email,magazine_subscribe,vertical_market,avatar,online_gaming,m_AppendTime,m_UpdateTime ");
			strSql.Append(" FROM tb_M_UserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_UserInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_UserInfoID,m_ConfigInfoID,user_id,uid,nick,sex,created,last_visit,birthday,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,email,magazine_subscribe,vertical_market,avatar,online_gaming,m_AppendTime,m_UpdateTime ");
			strSql.Append(" FROM tb_M_UserInfo ");
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
		public DataTable GetM_UserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_UserInfo";
			parameters[1].Value = "M_UserInfoID";
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


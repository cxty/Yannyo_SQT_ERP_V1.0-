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
        private static int _lastRemoveTimeout;

        #region  UserInfo
        /// <summary>
        /// UserInfo
        /// </summary>
        public bool ExistsUserInfo(string uName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbUserInfo");
            strSql.Append(" where uName=@uName ");
            SqlParameter[] parameters = {
					new SqlParameter("@uName", SqlDbType.VarChar,50)};
            parameters[0].Value = uName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 检测密码
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="password">密码</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <param name="UserGroupsID">用户组id</param>
        /// <returns>如果用户密码正确则返回uid, 否则返回-1</returns>
        public IDataReader CheckPassword(int UserID, string uPWD, bool originalpassword)
        {

            DbParameter[] parms = {
									   DbHelper.MakeInParam("@UserID",(DbType)SqlDbType.Int,4,UserID),
									   DbHelper.MakeInParam("@uPWD",(DbType)SqlDbType.Char,32, originalpassword ? Utils.MD5(uPWD) : uPWD)
								   };
            return DbHelper.ExecuteReader(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "checkpasswordbyuid", parms);
        }

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="UserSPID">接入SPID</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <returns>如果正确则返回用户id, 否则返回-1</returns>
        public IDataReader CheckPassword(string uName, string uPWD, bool originalpassword)
        {
            DbParameter[] parms = {
									   DbHelper.MakeInParam("@uName",(DbType)SqlDbType.VarChar,50, uName),
									   DbHelper.MakeInParam("@uPWD",(DbType)SqlDbType.Char,32, originalpassword ? Utils.MD5(uPWD) : uPWD)
								   };
            return DbHelper.ExecuteReader(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "checkpasswordbyusername", parms);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddUserInfo(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbUserInfo(");
            strSql.Append("uName,uPWD,uCode,uPermissions,uAppendTime,uUpAppendTime,uLastIP,uEstate,uType,StaffID)");
            strSql.Append(" values (");
            strSql.Append("@uName,@uPWD,@uCode,@uPermissions,@uAppendTime,@uUpAppendTime,@uLastIP,@uEstate,@uType,@StaffID)");
			strSql.Append(";select @@IDENTITY;");
			strSql.Append ("insert into tbUserStorageInfo (UserID,StorageIDStr) values(@@IDENTITY,@StorageIDStr);");
            SqlParameter[] parameters = {
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@uPWD", SqlDbType.Char,32),
					new SqlParameter("@uCode", SqlDbType.Char,16),
					new SqlParameter("@uPermissions", SqlDbType.VarChar,2000),
					new SqlParameter("@uAppendTime", SqlDbType.DateTime),
					new SqlParameter("@uUpAppendTime", SqlDbType.DateTime),
					new SqlParameter("@uLastIP", SqlDbType.VarChar,15),
					new SqlParameter("@uEstate", SqlDbType.Int,4),
                                        new SqlParameter("@uType", SqlDbType.Int,4),
				new SqlParameter("@StaffID", SqlDbType.Int,4),
				new SqlParameter("@StorageIDStr", SqlDbType.VarChar,512)
			};
            parameters[0].Value = model.uName;
            parameters[1].Value = model.uPWD;
            parameters[2].Value = model.uCode;
            parameters[3].Value = model.uPermissions;
            parameters[4].Value = model.uAppendTime;
            parameters[5].Value = model.uUpAppendTime;
            parameters[6].Value = model.uLastIP;
            parameters[7].Value = model.uEstate;
            parameters[8].Value = model.uType;
            parameters[9].Value = model.StaffID;
			parameters[10].Value = model.StorageIDStr;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
				return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateUserInfo(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUserInfo set ");
            strSql.Append("uName=@uName,");
            strSql.Append("uPWD=@uPWD,");
            strSql.Append("uCode=@uCode,");
            strSql.Append("uPermissions=@uPermissions,");
            strSql.Append("uAppendTime=@uAppendTime,");
            strSql.Append("uUpAppendTime=@uUpAppendTime,");
            strSql.Append("uLastIP=@uLastIP,");
            strSql.Append("uEstate=@uEstate,");
            strSql.Append("uType=@uType,");
            strSql.Append("StaffID=@StaffID");
			strSql.Append(" where UserID=@UserID ;");
			strSql.Append ("update tbUserStorageInfo set StorageIDStr=@StorageIDStr;");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@uPWD", SqlDbType.Char,32),
					new SqlParameter("@uCode", SqlDbType.Char,16),
					new SqlParameter("@uPermissions", SqlDbType.VarChar,2000),
					new SqlParameter("@uAppendTime", SqlDbType.DateTime),
					new SqlParameter("@uUpAppendTime", SqlDbType.DateTime),
					new SqlParameter("@uLastIP", SqlDbType.VarChar,15),
					new SqlParameter("@uEstate", SqlDbType.Int,4),
                                        new SqlParameter("@uType", SqlDbType.Int,4),
				new SqlParameter("@StaffID", SqlDbType.Int,4),
				new SqlParameter("@StorageIDStr", SqlDbType.VarChar,512)
			};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.uName;
            parameters[2].Value = model.uPWD;
            parameters[3].Value = model.uCode;
            parameters[4].Value = model.uPermissions;
            parameters[5].Value = model.uAppendTime;
            parameters[6].Value = model.uUpAppendTime;
            parameters[7].Value = model.uLastIP;
            parameters[8].Value = model.uEstate;
            parameters[9].Value = model.uType;
            parameters[10].Value = model.StaffID;
			parameters[11].Value = model.StorageIDStr;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteUserInfo(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUserInfo ");
			strSql.Append(" where UserID=@UserID ;");
			strSql.Append ("delete from tbUserStorageInfo where UserID=@UserID;");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteUserInfo(string UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUserInfo ");
			strSql.Append(" where UserID in(" + UserID + ") ;");
			strSql.Append ("delete from tbUserStorageInfo where UserID in(" + UserID + ");");
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo GetUserInfoModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 UserID,uName,uPWD,uCode,uPermissions,uAppendTime,uUpAppendTime,uLastIP,uEstate,uType,StaffID,(select sName from tbStaffInfo where StaffID=tbUserInfo.StaffID) as StaffName,(select StorageIDStr from tbUserStorageInfo where UserID=tbUserInfo.UserID) as StorageIDStr from tbUserInfo ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            UserInfo model = new UserInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["uType"].ToString() != "")
                {
                    model.uType = int.Parse(ds.Tables[0].Rows[0]["uType"].ToString());
                }
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                model.uName = ds.Tables[0].Rows[0]["uName"].ToString();
                model.uPWD = ds.Tables[0].Rows[0]["uPWD"].ToString();
                model.uCode = ds.Tables[0].Rows[0]["uCode"].ToString();
                model.uPermissions = ds.Tables[0].Rows[0]["uPermissions"].ToString();
				model.StorageIDStr = ds.Tables[0].Rows[0]["StorageIDStr"].ToString();
                if (ds.Tables[0].Rows[0]["uAppendTime"].ToString() != "")
                {
                    model.uAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["uAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["uUpAppendTime"].ToString() != "")
                {
                    model.uUpAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["uUpAppendTime"].ToString());
                }
                model.uLastIP = ds.Tables[0].Rows[0]["uLastIP"].ToString();
                if (ds.Tables[0].Rows[0]["uEstate"].ToString() != "")
                {
                    model.uEstate = int.Parse(ds.Tables[0].Rows[0]["uEstate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserInfo GetUserInfoModelByUserName(string UserName)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 UserID,uName,uPWD,uCode,uPermissions,uAppendTime,uUpAppendTime,uLastIP,uEstate,uType,StaffID,(select sName from tbStaffInfo where StaffID=tbUserInfo.StaffID) as StaffName,(select StorageIDStr from tbUserStorageInfo where UserID=tbUserInfo.UserID) as StorageIDStr from tbUserInfo ");
			strSql.Append(" where uName=@uName ");
			SqlParameter[] parameters = {
				new SqlParameter("@uName", SqlDbType.Int,4)};
			parameters[0].Value = UserName;

			UserInfo model = new UserInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
				{
					model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
				{
					model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["uType"].ToString() != "")
				{
					model.uType = int.Parse(ds.Tables[0].Rows[0]["uType"].ToString());
				}
				model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
				model.uName = ds.Tables[0].Rows[0]["uName"].ToString();
				model.uPWD = ds.Tables[0].Rows[0]["uPWD"].ToString();
				model.uCode = ds.Tables[0].Rows[0]["uCode"].ToString();
				model.uPermissions = ds.Tables[0].Rows[0]["uPermissions"].ToString();
				model.StorageIDStr = ds.Tables[0].Rows[0]["StorageIDStr"].ToString();
				if (ds.Tables[0].Rows[0]["uAppendTime"].ToString() != "")
				{
					model.uAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["uAppendTime"].ToString());
				}
				if (ds.Tables[0].Rows[0]["uUpAppendTime"].ToString() != "")
				{
					model.uUpAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["uUpAppendTime"].ToString());
				}
				model.uLastIP = ds.Tables[0].Rows[0]["uLastIP"].ToString();
				if (ds.Tables[0].Rows[0]["uEstate"].ToString() != "")
				{
					model.uEstate = int.Parse(ds.Tables[0].Rows[0]["uEstate"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 取指定用户Email
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserEmail(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sEmail from tbStaffInfo where StaffID=(select StaffID from tbuserinfo where userid=" + UserID + ")");
            return DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.Append("select UserID,uName,uPWD,uCode,uPermissions,uAppendTime,uUpAppendTime,uLastIP,uEstate,uType,StaffID,(select sName from tbStaffInfo where StaffID=tbUserInfo.StaffID) as StaffName,(select StorageIDStr from tbUserStorageInfo where UserID=tbUserInfo.UserID) as StorageIDStr ");
            strSql.Append(" FROM tbUserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetUserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbUserInfo";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
			parameters[7].Value = showFName + ",(select sName from tbStaffInfo where StaffID=tbUserInfo.StaffID) as StaffName,(select StorageIDStr from tbUserStorageInfo where UserID=tbUserInfo.UserID) as StorageIDStr ";
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
        /// 根据IP获取错误登录记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public DataTable GetErrLoginRecordByIP(string ip)
        {
            DbParameter[] parms = {
										 DbHelper.MakeInParam("@ip",(DbType)SqlDbType.Char,15, ip),
			                        };
            return DbHelper.ExecuteDataset(CommandType.Text, "SELECT TOP 1 [errcount], [lastupdate] FROM [tb" + BaseConfigs.GetTablePrefix + "UserFailedLoginLogInfo] WHERE [ip]=@ip", parms).Tables[0];
        }

        /// <summary>
        /// 增加指定IP的错误记录数
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int AddErrLoginCount(string ip)
        {
            DbParameter[] parms = {
										 DbHelper.MakeInParam("@ip",(DbType)SqlDbType.Char,15, ip),
			                        };
            return DbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [tb" + BaseConfigs.GetTablePrefix + "UserFailedLoginLogInfo] SET [errcount]=[errcount]+1, [lastupdate]=GETDATE() WHERE [ip]=@ip", parms);
        }

        /// <summary>
        /// 增加指定IP的错误记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int AddErrLoginRecord(string ip)
        {
            DbParameter[] parms = {
										 DbHelper.MakeInParam("@ip",(DbType)SqlDbType.Char,15, ip),
			                        };
            return DbHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [tb" + BaseConfigs.GetTablePrefix + "UserFailedLoginLogInfo] ([ip], [errcount], [lastupdate]) VALUES(@ip, 1, GETDATE())", parms);
        }

        /// <summary>
        /// 将指定IP的错误登录次数重置为1
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int ResetErrLoginCount(string ip)
        {
            DbParameter[] parms = {
										 DbHelper.MakeInParam("@ip",(DbType)SqlDbType.Char,15, ip),
			                        };
            return DbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [tb" + BaseConfigs.GetTablePrefix + "UserFailedLoginLogInfo] SET [errcount]=1, [lastupdate]=GETDATE() WHERE [ip]=@ip", parms);
        }

        /// <summary>
        /// 删除指定IP或者超过15分钟的记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int DeleteErrLoginRecord(string ip)
        {
            DbParameter[] parms = {
										 DbHelper.MakeInParam("@ip",(DbType)SqlDbType.Char,15, ip),
			};
            return DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [tb" + BaseConfigs.GetTablePrefix + "UserFailedLoginLogInfo] WHERE [ip]=@ip OR DATEDIFF(n,[lastupdate], GETDATE()) > 15", parms);
        }

        /// <summary>
        /// 更新用户当前的在线时间和最后活动时间
        /// </summary>
        /// <param name="UserID">UserID</param>
        public void UpdateUserLastActivity(int UserID, string uLastActivity)
        {
            DbParameter[] parms = {
									   DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID),
									   DbHelper.MakeInParam("@uLastActivity", (DbType)SqlDbType.DateTime, 8, DateTime.Parse(uLastActivity))
								   };


            DbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [tb" + BaseConfigs.GetTablePrefix + "UserInfo] SET [uUpAppendTime] = @uLastActivity  WHERE [UserID] = @UserID", parms);

        }

       /// <summary>
        /// 指定权限返回用户邮箱
        /// </summary>
        /// <param name="PopedomAllStr">权限代码</param>
        public string GetUserMailByPopedom(string PopedomAllStr)
        {
            string[] PopedomAllArray = Utils.SplitString("," + PopedomAllStr + ",", ",");
            string strSql = "";
            string reValue = "";
            foreach (string _p in PopedomAllArray)
            {
                if (_p.Trim() != "")
                {
                    strSql = "select us.sEmail from (" +
                                            "select u.UserID,u.uName,u.StaffID,(','+u.uPermissions+',') uPermissions,s.sName,s.sEmail from tbuserinfo as u left join tbStaffInfo s on u.StaffID=s.StaffID where uEstate=0" +
                                            ") us where CharIndex('" + _p.Trim() + "',uPermissions)>0 ;";
                    reValue +=DbHelper.ExecuteScalarToStr(CommandType.Text, strSql)+",";
                }
            }
            return reValue;
        }

        #endregion


        #region 在线列表

        /// <summary>
        /// 获得全部在线用户数
        /// </summary>
        /// <returns></returns>
        public int GetOnlineAllUserCount()
        {
            return Utils.StrToInt(DbHelper.ExecuteScalar(CommandType.Text, "SELECT COUNT(olID) FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo]"), 1);
        }

        /// <summary>
        /// 创建在线表
        /// </summary>
        /// <returns></returns>
        public int CreateOnlineTable()
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("IF EXISTS (SELECT * FROM SYSOBJECTS WHERE id = object_id(N'[dnt_online]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) DROP TABLE [dnt_online];");
                //sb.Append("CREATE TABLE [dnt_online] ([olID] [int] IDENTITY (1, 1) NOT NULL,[userid] [int] NOT NULL,[ip] [varchar] (15) NOT NULL,[username] [nvarchar] (20) NOT NULL,[nickname] [nvarchar] (20) NOT NULL,[password] [char] (32) NOT NULL,[UserGroupsID] [smallint] NOT NULL,[olimg] [varchar] (80) NOT NULL,[adminid] [smallint] NOT NULL,[invisible] [smallint] NOT NULL,[action] [smallint] NOT NULL,[uLastActivity] [smallint] NOT NULL,[lastposttime] [datetime] NOT NULL,[lastpostpmtime] [datetime] NOT NULL,[lastsearchtime] [datetime] NOT NULL,[lastupdatetime] [datetime] NOT NULL,[forumid] [int] NOT NULL,[forumname] [nvarchar] (50) NOT NULL,[titleid] [int] NOT NULL,[title] [nvarchar] (80) NOT NULL,[verifycode] [varchar] (10) NOT NULL ) ON [PRIMARY];");
                //sb.Append("ALTER TABLE [dnt_online] WITH NOCHECK ADD CONSTRAINT [PK_dnt_online] PRIMARY KEY CLUSTERED ([olID]) ON [PRIMARY]; ");
                //sb.Append("ALTER TABLE [dnt_online] ADD CONSTRAINT [DF_dnt_online_userid] DEFAULT ((-1)) FOR [userid],CONSTRAINT [DF_dnt_online_ip] DEFAULT ('0.0.0.0') FOR [ip],CONSTRAINT [DF_dnt_online_username] DEFAULT ('') FOR [username],CONSTRAINT [DF_dnt_online_nickname] DEFAULT ('') FOR [nickname],CONSTRAINT [DF_dnt_online_password] DEFAULT ('') FOR [password],CONSTRAINT [DF_dnt_online_UserGroupsID] DEFAULT (0) FOR [UserGroupsID],CONSTRAINT [DF_dnt_online_olimg] DEFAULT ('') FOR [olimg],CONSTRAINT [DF_dnt_online_adminid] DEFAULT (0) FOR [adminid],CONSTRAINT [DF_dnt_online_invisible] DEFAULT (0) FOR [invisible],CONSTRAINT [DF_dnt_online_action] DEFAULT (0) FOR [action],CONSTRAINT [DF_dnt_online_lastactivity] DEFAULT (0) FOR [uLastActivity],CONSTRAINT [DF_dnt_online_lastposttime] DEFAULT ('1900-1-1 00:00:00') FOR [lastposttime],CONSTRAINT [DF_dnt_online_lastpostpmtime] DEFAULT ('1900-1-1 00:00:00') FOR [lastpostpmtime],CONSTRAINT [DF_dnt_online_lastsearchtime] DEFAULT ('1900-1-1 00:00:00') FOR [lastsearchtime],CONSTRAINT [DF_dnt_online_lastupdatetime] DEFAULT (getdate()) FOR [lastupdatetime],CONSTRAINT [DF_dnt_online_forumid] DEFAULT (0) FOR [forumid],CONSTRAINT [DF_dnt_online_forumname] DEFAULT ('') FOR [forumname],CONSTRAINT [DF_dnt_online_titleid] DEFAULT (0) FOR [titleid],CONSTRAINT [DF_dnt_online_title] DEFAULT ('') FOR [title],CONSTRAINT [DF_dnt_online_verifycode] DEFAULT ('') FOR [verifycode];");
                //sb.Append("CREATE INDEX [forum] ON [dnt_online]([userid], [forumid], [invisible]) ON [PRIMARY];");
                //sb.Append("CREATE INDEX [invisible] ON [dnt_online]([userid], [invisible]) ON [PRIMARY];");
                //sb.Append("CREATE INDEX [forumid] ON [dnt_online]([forumid]) ON [PRIMARY];");
                //sb.Append("CREATE INDEX [password] ON [dnt_online]([userid], [password]) ON [PRIMARY];");
                //sb.Append("CREATE INDEX [ip] ON [dnt_online]([userid], [ip]) ON [PRIMARY];");
                //sb.AppendFormat("TRUNCATE TABLE [tb{0}UserOnLineLogInfo]", BaseConfigs.GetTablePrefix);

                return DbHelper.ExecuteNonQuery(CommandType.Text, string.Format("TRUNCATE TABLE [tb{0}tbUserOnLineLogInfo]", BaseConfigs.GetTablePrefix));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 执行在线用户向表及缓存中添加的操作。
        /// </summary>
        /// <param name="onlineuserinfo">在组用户信息内容</param>
        /// <returns>添加成功则返回刚刚添加的olID,失败则返回0</returns>
        public int AddOnlineUser(OnlineUserInfo onlineuserinfo, int timeout)
        {

            string strDelTimeOutSql = "";
            // 如果timeout为负数则代表不需要精确更新用户是否在线的状态
            if (!(timeout > 0))
            {
                timeout = timeout * -1;
            }

            if (timeout > 9999)
            {
                timeout = 9999;
            }

            DbParameter[] parms = {
									   DbHelper.MakeInParam("@UserID",(DbType)SqlDbType.Int,4,onlineuserinfo.UserID),
									   DbHelper.MakeInParam("@oIP",(DbType)SqlDbType.VarChar,15,onlineuserinfo.oIP),
									   DbHelper.MakeInParam("@oUserName",(DbType)SqlDbType.VarChar,50,onlineuserinfo.oUserName),
									   DbHelper.MakeInParam("@UserSPID",(DbType)SqlDbType.Int,4,onlineuserinfo.UserSPID),
									   DbHelper.MakeInParam("@UserGroupsID",(DbType)SqlDbType.Int,4,onlineuserinfo.UserGroupsID),
									   DbHelper.MakeInParam("@oAppendTime",(DbType)SqlDbType.DateTime,8,onlineuserinfo.oAppendTime),
									   DbHelper.MakeInParam("@oLastTime",(DbType)SqlDbType.DateTime,8,onlineuserinfo.oLastTime)
								   };
            int olID = Utils.StrToInt(DbHelper.ExecuteScalar(CommandType.Text, strDelTimeOutSql + "INSERT INTO [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] ([UserID],[oIP],[oUserName],[UserSPID],[UserGroupsID],[oAppendTime],[oLastTime])VALUES(@UserID,@oIP,@oUserName,@UserSPID,@UserGroupsID,@oAppendTime,@oLastTime);SELECT SCOPE_IDENTITY()", parms).ToString(), 0);

            //系统中间隔5分钟之内不清除过期用户
            if (_lastRemoveTimeout == 0 || (System.Environment.TickCount - _lastRemoveTimeout) > 300000)
            {
                DeleteExpiredOnlineUsers(timeout);
                _lastRemoveTimeout = System.Environment.TickCount;
            }
            // 如果id值太大则重建在线表
            if (olID > 2147483000)
            {
                CreateOnlineTable();
                DbHelper.ExecuteNonQuery(CommandType.Text, strDelTimeOutSql + "INSERT INTO [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] ([UserID],[oIP],[oUserName],[UserSPID],[UserGroupsID],[oAppendTime],[oLastTime])VALUES(@UserID,@oIP,@oUserName,@UserSPID,@UserGroupsID,@oAppendTime,@oLastTime);SELECT SCOPE_IDENTITY()", parms);
                return 1;
            }
            return 0;
        }

        private void DeleteExpiredOnlineUsers(int timeout)
        {
            System.Text.StringBuilder timeoutStrBuilder = new System.Text.StringBuilder();
            System.Text.StringBuilder memberStrBuilder = new System.Text.StringBuilder();

            string strDelTimeOutSql = "";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT [olID], [UserID] FROM [tb{0}UserOnLineLogInfo] WHERE [oLastTime]<'{1}'", BaseConfigs.GetTablePrefix, DateTime.Parse(DateTime.Now.AddMinutes(timeout * -1).ToString("yyyy-MM-dd HH:mm:ss"))));
            while (dr.Read())
            {
                timeoutStrBuilder.Append(",");
                timeoutStrBuilder.Append(dr["olID"].ToString());
                if (dr["UserID"].ToString() != "-1")
                {
                    memberStrBuilder.Append(",");
                    memberStrBuilder.Append(dr["UserID"].ToString());
                }
            }
            dr.Close();

            if (timeoutStrBuilder.Length > 0)
            {
                timeoutStrBuilder.Remove(0, 1);
                strDelTimeOutSql = string.Format("DELETE FROM [tb{0}UserOnLineLogInfo] WHERE [olID] IN ({1});", BaseConfigs.GetTablePrefix, timeoutStrBuilder.ToString());
            }
            if (memberStrBuilder.Length > 0)
            {
                memberStrBuilder.Remove(0, 1);
                //strDelTimeOutSql = string.Format("{0}UPDATE [tb{1}UserInfo] SET [onlinestate]=0,[uLastActivity]=GETDATE() WHERE [UserID] IN ({2});", strDelTimeOutSql, BaseConfigs.GetTablePrefix, memberStrBuilder.ToString());
            }
            if (strDelTimeOutSql != string.Empty)
                DbHelper.ExecuteNonQuery(strDelTimeOutSql);
        }

        public void UpdateOnlineTime(int oltimespan, int UserID)
        {
			try
			{
	            DbParameter[] parms = {
	                                    DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID),
										DbHelper.MakeInParam("@oltimespan", (DbType)SqlDbType.Int, 2, oltimespan),
	                                    DbHelper.MakeInParam("@lastupdate", (DbType)SqlDbType.DateTime, 8, DateTime.Now),
	                                    DbHelper.MakeInParam("@expectedlastupdate", (DbType)SqlDbType.DateTime, 8, DateTime.Now.AddMinutes(0 - oltimespan))
	                                };
	            string sql = string.Format("UPDATE [tb{0}UserOnLineTime] SET [thismonth]=[thismonth]+@oltimespan, [total]=[total]+@oltimespan, [lastupdate]=@lastupdate WHERE [UserID]=@UserID AND [lastupdate]<=@expectedlastupdate", BaseConfigs.GetTablePrefix);
	            if (DbHelper.ExecuteNonQuery(CommandType.Text, sql, parms) < 1)
	            {
	                try
	                {
	                    DbHelper.ExecuteNonQuery(CommandType.Text, string.Format("INSERT INTO [tb{0}UserOnLineTime]([UserID], [thismonth], [total], [lastupdate]) VALUES(@UserID, @oltimespan, @oltimespan, @lastupdate)", BaseConfigs.GetTablePrefix), parms);
	                }
	                catch
	                { }
	            }
			}catch {
			}
        }

        public void SynchronizeOltime(int UserID)
        {
            DbParameter[] parms = {
                                    DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID),
                                };
            string sql = string.Format("SELECT [total] FROM [tb{0}UserOnLineTime] WHERE [UserID]=@UserID", BaseConfigs.GetTablePrefix);
            int total = Utils.StrToInt(DbHelper.ExecuteScalar(CommandType.Text, sql, parms), 0);

            if (DbHelper.ExecuteNonQuery(CommandType.Text, string.Format("UPDATE [tb{0}UserInfo] SET [olTime]={1} WHERE [olTime]<{1} AND [UserID]=@UserID", BaseConfigs.GetTablePrefix, total), parms) < 1)
            {

                try
                {
                    sql = string.Format("UPDATE [tb{0}UserOnLineTime] SET [total]=(SELECT [olTime] FROM [tb{0}UserInfo] WHERE [UserID]=@UserID) WHERE [UserID]=@UserID", BaseConfigs.GetTablePrefix);
                    DbHelper.ExecuteNonQuery(CommandType.Text, sql, parms);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 获得在线注册用户总数量
        /// </summary>
        /// <returns>用户数量</returns>
        public int GetOnlineUserCount()
        {

            return (int)DbHelper.ExecuteDataset(CommandType.Text, "SELECT COUNT(olID) FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] WHERE [UserID]>0").Tables[0].Rows[0][0];

        }


        /// <summary>
        /// 获得全部在线用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOnlineUserListTable()
        {
            return DbHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo]").Tables[0];
        }

        /// <summary>
        /// 获得全部在线用户列表
        /// </summary>
        /// <returns></returns>
        public IDataReader GetOnlineUserList()
        {
            return DbHelper.ExecuteReader(CommandType.Text, "SELECT * FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo]");
        }

        /// <summary>
        /// 根据UserID获得olID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>olID</returns>
        public int GetolIDByUid(int UserID)
        {
            DbParameter[] parms = { DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID) };
            return Utils.StrToInt(DbHelper.ExecuteScalarToStr(CommandType.Text, string.Format("SELECT olID FROM [tb{0}UserOnLineLogInfo] WHERE [UserID]=@UserID", BaseConfigs.GetTablePrefix), parms), -1);
        }

        /// <summary>
        /// 获得指定在线用户
        /// </summary>
        /// <param name="olID">在线id</param>
        /// <returns>在线用户的详细信息</returns>
        public IDataReader GetOnlineUser(int olID)
        {
            DbParameter[] parms = { DbHelper.MakeInParam("@olID", (DbType)SqlDbType.Int, 4, olID) };
            return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT * FROM [tb{0}UserOnLineLogInfo] WHERE [olID]=@olID", BaseConfigs.GetTablePrefix), parms);
        }

        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <param name="userid">在线用户ID</param>
        /// <returns>用户的详细信息</returns>
        public DataTable GetOnlineUserInfo(int UserID)
        {
            DbParameter[] parms = { 
                                        DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID)
                                    };
            return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT TOP 1 * FROM [tb{0}UserOnLineLogInfo] WHERE [UserID]=@UserID ", BaseConfigs.GetTablePrefix), parms).Tables[0];
        }

        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <param name="userid">在线用户ID</param>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        public DataTable GetOnlineUserByIP(int UserID, string oIP)
        {
            DbParameter[] parms = { 
                                        DbHelper.MakeInParam("@UserID", (DbType)SqlDbType.Int, 4, UserID),
                                        DbHelper.MakeInParam("@oIP", (DbType)SqlDbType.VarChar, 15, oIP)
                                    };
            return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT TOP 1 * FROM [tb{0}UserOnLineLogInfo] WHERE [UserID]=@UserID AND [oIP]=@oIP", BaseConfigs.GetTablePrefix), parms).Tables[0];
        }

        /// <summary>
        /// 删除符合条件的一个或多个用户信息
        /// </summary>
        /// <returns>删除行数</returns>
        public int DeleteRowsByIP(string oIP)
        {
            DbParameter[] parms = {
									   DbHelper.MakeInParam("@oIP",(DbType)SqlDbType.VarChar,15,oIP)
								   };
            DbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [tb" + BaseConfigs.GetTablePrefix + "UserInfo] SET [uUpAppendTime]=GETDATE() WHERE [UserID] IN (SELECT [UserID] FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] WHERE [UserID]>0 AND [oIP]=@oIP)", parms);
            if (oIP != "0.0.0.0")
            {
                return DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] WHERE [UserID]=-1 AND [oIP]=@oIP", parms);
            }
            return 0;
        }

        /// <summary>
        /// 删除在线表中指定在线id的行
        /// </summary>
        /// <param name="olID">在线id</param>
        /// <returns></returns>
        public int DeleteRows(int olID)
        {
            return DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] WHERE [olID]=" + olID.ToString());
        }


        /// <summary>
        /// 更新用户最后活动时间
        /// </summary>
        /// <param name="olID">在线id</param>
        public void UpdateLastTime(int olID)
        {
            DbParameter[] parms = {
										   //DbHelper.MakeInParam("@tickcount",(DbType)SqlDbType.Int,4,System.Environment.TickCount),
                                           DbHelper.MakeInParam("@lastupdatetime", (DbType)SqlDbType.DateTime, 8, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))),
										   DbHelper.MakeInParam("@olID",(DbType)SqlDbType.Int,4,olID)

									   };
            DbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [tb" + BaseConfigs.GetTablePrefix + "UserOnLineLogInfo] SET [lastupdatetime]=@lastupdatetime WHERE [olID]=@olID", parms);
        }

        /// <summary>
        /// 更新用户IP地址
        /// </summary>
        /// <param name="olID">在线id</param>
        /// <param name="ip">ip地址</param>
        public void UpdateIP(int olID, string oIP)
        {
            DbParameter[] parms = {
									   DbHelper.MakeInParam("@oIP",(DbType)SqlDbType.VarChar,15,oIP),
									   DbHelper.MakeInParam("@olID",(DbType)SqlDbType.Int,4,olID)

								   };
            DbHelper.ExecuteNonQuery(CommandType.Text, string.Format("UPDATE [tb{0}UserOnLineLogInfo] SET [oIP]=@oIP WHERE [olID]=@olID", BaseConfigs.GetTablePrefix), parms);

        }

        /// <summary>
        /// 更新用户的用户组
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="UserGroupsID">组名</param>
        public void UpdateGroupid(int userid, int UserGroupsID)
        {
            DbHelper.ExecuteNonQuery(CommandType.Text, string.Format("UPDATE [tb{0}UserOnLineLogInfo] SET [UserGroupsID]={1} WHERE [userid]={2}", BaseConfigs.GetTablePrefix, UserGroupsID.ToString(), userid.ToString()));
        }
        #endregion

        #region 用户外部账户信息
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool UserPassportInfoExists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbUserPassportInfo");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddUserPassportInfo(UserPassportInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbUserPassportInfo(");
            strSql.Append("UserID,Erp_Name,Erp_Pwd,g_Name,g_PWD)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Erp_Name,@Erp_Pwd,@g_Name,@g_PWD)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Erp_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Erp_Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@g_Name", SqlDbType.VarChar,50),
					new SqlParameter("@g_PWD", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Erp_Name;
            parameters[2].Value = model.Erp_Pwd;
            parameters[3].Value = model.g_Name;
            parameters[4].Value = model.g_PWD;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void UpdateUserPassportInfo(UserPassportInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUserPassportInfo set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Erp_Name=@Erp_Name,");
            strSql.Append("Erp_Pwd=@Erp_Pwd,");
            strSql.Append("g_Name=@g_Name,");
            strSql.Append("g_PWD=@g_PWD");
            strSql.Append(" where UserID=@UserID and Erp_Name=@Erp_Name and Erp_Pwd=@Erp_Pwd and g_Name=@g_Name and g_PWD=@g_PWD ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Erp_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Erp_Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@g_Name", SqlDbType.VarChar,50),
					new SqlParameter("@g_PWD", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Erp_Name;
            parameters[2].Value = model.Erp_Pwd;
            parameters[3].Value = model.g_Name;
            parameters[4].Value = model.g_PWD;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteUserPassportInfo(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUserPassportInfo ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserPassportInfo GetUserPassportInfoModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,Erp_Name,Erp_Pwd,g_Name,g_PWD from tbUserPassportInfo ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            UserPassportInfo model = new UserPassportInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.Erp_Name = ds.Tables[0].Rows[0]["Erp_Name"].ToString();
                model.Erp_Pwd = ds.Tables[0].Rows[0]["Erp_Pwd"].ToString();
                model.g_Name = ds.Tables[0].Rows[0]["g_Name"].ToString();
                model.g_PWD = ds.Tables[0].Rows[0]["g_PWD"].ToString();
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
        public DataSet GetUserPassportInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,Erp_Name,Erp_Pwd,g_Name,g_PWD ");
            strSql.Append(" FROM tbUserPassportInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetUserPassportInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbUserPassportInfo";
            parameters[1].Value = "UserID";
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

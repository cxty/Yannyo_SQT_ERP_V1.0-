using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.Common;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;

namespace Yannyo.BLL
{
    /// <summary>
    /// 在线用户操作类
    /// </summary>
    public class OnlineUsers
    {
        private static object SynObject = new object();

        /// <summary>
        /// 获得在线用户总数量
        /// </summary>
        /// <returns>用户数量</returns>
        public static int GetOnlineAllUserCount()
        {
            int count = DatabaseProvider.GetInstance().GetOnlineAllUserCount();
            return count == 0 ? 1 : count;
        }

        /// <summary>
        /// 返回缓存中在线用户总数
        /// </summary>
        /// <returns>缓存中在线用户总数</returns>
        public static int GetCacheOnlineAllUserCount()
        {

            int count = Utils.StrToInt(Utils.GetCookie("onlineusercount"), 0);
            if (count == 0)
            {
                count = OnlineUsers.GetOnlineAllUserCount();
                Utils.WriteCookie("onlineusercount", count.ToString(), 3);
            }
            return count;

        }

        /// <summary>
        /// 清理之前的在线表记录(本方法在应用程序初始化时被调用)
        /// </summary>
        /// <returns></returns>
        public static int InitOnlineList()
        {
            return DatabaseProvider.GetInstance().CreateOnlineTable();
        }

        /// <summary>
        /// 复位在线表, 如果系统未重启, 仅是应用程序重新启动, 则不会重新创建
        /// </summary>
        /// <returns></returns>
        public static int ResetOnlineList()
        {
            try
            {
                // 取得在线表最后一条记录的tickcount字段 (因为本功能不要求特别精确)
                //int tickcount = DatabaseProvider.GetInstance().GetLastTickCount();
                // 如果距离现在系统运行时间小于10分钟
                if (System.Environment.TickCount < 600000 && System.Environment.TickCount > 0)
                {
                    return InitOnlineList();
                }
                return -1;
            }
            catch
            {
                try
                {
                    return InitOnlineList();
                }
                catch
                {
                    return -1;
                }
            }

        }

        /// <summary>
        /// 获得在线注册用户总数量
        /// </summary>
        /// <returns>用户数量</returns>
        public static int GetOnlineUserCount()
        {
            return DatabaseProvider.GetInstance().GetOnlineUserCount();
        }

        #region 根据不同条件查询在线用户信息


        /// <summary>
        /// 返回用户在线列表
        /// </summary>
        /// <param name="forumid">版块id</param>
        /// <param name="totaluser">全部用户数</param>
        /// <param name="guest">游客数</param>
        /// <param name="user">登录用户数</param>
        /// <param name="invisibleuser">隐身会员数</param>
        /// <returns>用户在线列表DataTable</returns>
        public static DataTable GetForumOnlineUserList(int forumid, out int totaluser, out int guest, out int user, out int invisibleuser)
        {
            DataTable dt = new DataTable();

            lock (SynObject)
            {
                dt = DatabaseProvider.GetInstance().GetOnlineUserListTable();
            }

            totaluser = dt.Rows.Count;
            // 统计游客
            DataRow[] dr = dt.Select("userid=-1");
            if (dr == null)
            {
                guest = 0;
            }
            else
            {
                guest = dr.Length;
            }
            //统计隐身用户
            dr = dt.Select("invisible=1");
            if (dr == null)
            {
                invisibleuser = 0;
            }
            else
            {
                invisibleuser = dr.Length;
            }
            //统计用户
            user = totaluser - guest;
            //返回当前版块的在线用户表
            return dt;
        }
        #endregion


        #region 查看指定的某一用户的详细信息
        public static OnlineUserInfo GetOnlineUser(int olid)
        {
            IDataReader reader = DatabaseProvider.GetInstance().GetOnlineUser(olid);
            OnlineUserInfo onlineuserinfo = null;
            if (reader.Read())
            {
                onlineuserinfo = LoadSingleOnlineUser(reader);
            }
            reader.Close();
            return onlineuserinfo;
        }

        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <param name="userid">在线用户ID</param>
        /// <returns>用户的详细信息</returns>
        private static OnlineUserInfo GetOnlineUserInfo(int userid)
        {
            DataTable dt = DatabaseProvider.GetInstance().GetOnlineUserInfo(userid);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                OnlineUserInfo onlineuserinfo = LoadSingleOnlineUser(dr);
                dt.Dispose();
                return onlineuserinfo;
            }
            return null;


        }


        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <returns>用户的详细信息</returns>
        private static OnlineUserInfo GetOnlineUserByIP(int userid, string ip)
        {
            DataTable dt = DatabaseProvider.GetInstance().GetOnlineUserByIP(userid, ip);
            if (dt.Rows.Count > 0)
            {
                OnlineUserInfo oluser = LoadSingleOnlineUser(dt.Rows[0]);
                dt.Dispose();
                return oluser;

            }
            return null;


        }

        #endregion


        #region 添加新的在线用户
        /// <summary>
        /// 执行在线用户向表及缓存中添加的操作。
        /// </summary>
        /// <param name="onlineuserinfo">在组用户信息内容</param>
        /// <returns>添加成功则返回刚刚添加的olid,失败则返回0</returns>
        private static int Add(OnlineUserInfo onlineuserinfo, int timeout)
        {
            return DatabaseProvider.GetInstance().AddOnlineUser(onlineuserinfo, timeout);
        }


        /// <summary>
        /// Cookie中没有用户ID或则存的的用户ID无效时在在线表中增加一个游客.
        /// </summary>
        public static OnlineUserInfo CreateGuestUser(int timeout)
        {


            OnlineUserInfo onlineuserinfo = new OnlineUserInfo();

            onlineuserinfo.UserID = -1;
            onlineuserinfo.oUserName = "游客";
            onlineuserinfo.UserGroupsID = 0;
            onlineuserinfo.UserSPID = 0;
            onlineuserinfo.oIP = HTTPRequest.GetIP();
            onlineuserinfo.oAppendTime = DateTime.Parse(Utils.GetDateTime());
            onlineuserinfo.oLastTime = DateTime.Parse(Utils.GetDateTime());

            int olid = Add(onlineuserinfo, timeout);
            onlineuserinfo.olID = olid;

            return onlineuserinfo;

        }


        /// <summary>
        /// 增加一个会员信息到在线列表中。用户login.aspx或在线用户信息超时,但用户仍在线的情况下重新生成用户在线列表
        /// </summary>
        /// <param name="uid"></param>
        private static OnlineUserInfo CreateUser(int UserID, int timeout)
        {
            OnlineUserInfo onlineuserinfo = new OnlineUserInfo();
            if (UserID > 0)
            {
                UserInfo ui = BLL.tbUserInfo.GetUserInfoModel(UserID);
                if (ui != null)
                {

                    onlineuserinfo.UserID = UserID;
                    onlineuserinfo.oUserName = ui.uName.Trim();

                    onlineuserinfo.oIP = HTTPRequest.GetIP();
                    onlineuserinfo.oAppendTime = DateTime.Parse(Utils.GetDateTime());
                    onlineuserinfo.oLastTime = DateTime.Parse(Utils.GetDateTime());

                    int olid = Add(onlineuserinfo, timeout);
                    onlineuserinfo.olID = olid;

                    HttpCookie cookie = HttpContext.Current.Request.Cookies["Yannyo"];
                    if (cookie != null)
                    {
                        if (HttpContext.Current.Request.Cookies["Yannyo"]["expires"] != null)
                        {
                            int expires = Utils.StrToInt(HttpContext.Current.Request.Cookies["Yannyo"]["expires"].ToString(), 0);
                            if (expires > 0)
                            {
                                cookie.Expires = DateTime.Now.AddMinutes(Utils.StrToInt(HttpContext.Current.Request.Cookies["Yannyo"]["expires"].ToString(), 0));
                            }
                        }
                    }

                    string cookieDomain = GeneralConfigs.GetConfig().CookieDomain.Trim();
                    if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && UsersUtils.IsValidDomain(HttpContext.Current.Request.Url.Host))
                        cookie.Domain = cookieDomain;
                    HttpContext.Current.Response.AppendCookie(cookie);

                }
            }
            else
            {
                onlineuserinfo = CreateGuestUser(timeout);
            }
            return onlineuserinfo;

        }




        /// <summary>
        /// 用户在线信息维护。判断当前用户的身份(会员还是游客),是否在在线列表中存在,如果存在则更新会员的当前动,不存在则建立.
        /// </summary>
        /// <param name="passwordkey">系统passwordkey</param>
        /// <param name="timeout">在线超时时间</param>
        /// <param name="passwd">用户密码</param>
        public static OnlineUserInfo UpdateInfo(string passwordkey, int timeout, int uid, string passwd)
        {
           
                lock (SynObject)
                {
                    OnlineUserInfo onlineuser = new OnlineUserInfo();

                    string ip = HTTPRequest.GetIP();
                    int userid = Utils.StrToInt(UsersUtils.GetCookie("UserID"), uid);
                    string password = (passwd == string.Empty ? UsersUtils.GetCookiePassword(passwordkey) : UsersUtils.GetCookiePassword(passwd, passwordkey));

                    if (password.Length == 0)
                    {
                        userid = -1;
                    }
                    // 如果密码非Base64编码字符串则怀疑被非法篡改, 直接置身份为游客
                    else if (!Utils.IsBase64String(password))
                    {
                        userid = -1;
                    }

                    if (userid != -1)
                    {
                        onlineuser = GetOnlineUserInfo(userid);

                        if (onlineuser != null)
                        {

                            if (onlineuser.oIP != ip)
                            {
                                UpdateIP(onlineuser.olID, ip);

                                onlineuser.oIP = ip;

                                return onlineuser;
                            }
                        }
                        else
                        {

                            // 判断密码是否正确
                            userid = BLL.tbUserInfo.CheckPassword(userid, password, false);
                            if (userid != -1)
                            {
                                DeleteRowsByIP(ip);
                                return CreateUser(userid, timeout);
                            }
                            else
                            {
                                // 如密码错误则在在线表中创建游客
                                onlineuser = GetOnlineUserByIP(-1, ip);
                                if (onlineuser == null)
                                {
                                    return CreateGuestUser(timeout);
                                }
                            }
                        }

                    }
                    else
                    {
                        onlineuser = GetOnlineUserByIP(-1, ip);

                        if (onlineuser == null)
                        {
                            return CreateGuestUser(timeout);
                        }

                    }

                    //UpdateLastTime(onlineuser.Olid);

                    onlineuser.oLastTime = DateTime.Now;// DateTime.Parse(Utils.GetDateTime());
                    return onlineuser;

                }
            
        }

        /// <summary>
        /// 用户在线信息维护。判断当前用户的身份(会员还是游客),是否在在线列表中存在,如果存在则更新会员的当前动,不存在则建立.
        /// </summary>
        /// <param name="timeout">在线超时时间</param>
        /// <param name="passwd">用户密码</param>
        public static OnlineUserInfo UpdateInfo(string passwordkey, int timeout)
        {
            return UpdateInfo(passwordkey, timeout, -1, "");
        }

        #endregion


        #region 在组用户信息更新
 
        /// <summary>
        /// 更新用户最后活动时间
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <param name="timeout">超时时间</param>
        private static void UpdateLastTime(int olid, int timeout)
        {

            // 如果上次刷新cookie间隔小于5分钟, 则不刷新数据库最后活动时间
            if ((timeout < 0) && (System.Environment.TickCount - Utils.StrToInt(Utils.GetCookie("lastolupdate"), System.Environment.TickCount) < 300000))
            {
                Utils.WriteCookie("lastolupdate", System.Environment.TickCount.ToString());
            }
            else
            {
                DatabaseProvider.GetInstance().UpdateLastTime(olid);
            }
        }

        /// <summary>
        /// 更新用户IP地址
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <param name="ip">ip地址</param>
        public static void UpdateIP(int olid, string ip)
        {
            DatabaseProvider.GetInstance().UpdateIP(olid, ip);
        }

        /// <summary>
        /// 更新用户的用户组
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="groupid">组名</param>
        public static void UpdateGroupid(int userid, int groupid)
        {
            DatabaseProvider.GetInstance().UpdateGroupid(userid, groupid);
        }

        #endregion


        #region 删除符合条件的用户信息

        /// <summary>
        /// 删除符合条件的一个或多个用户信息
        /// </summary>
        /// <returns>删除行数</returns>
        private static int DeleteRowsByIP(string ip)
        {
            return DatabaseProvider.GetInstance().DeleteRowsByIP(ip);
        }

        /// <summary>
        /// 删除在线表中指定在线id的行
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <returns></returns>
        public static int DeleteRows(int olid)
        {
            return DatabaseProvider.GetInstance().DeleteRows(olid);
        }


        #endregion


        #region 条件编译的方法

        /// <summary>
        /// 返回在线用户列表
        /// </summary>
        /// <param name="totaluser">全部用户数</param>
        /// <param name="guest">游客数</param>
        /// <param name="user">登录用户数</param>
        /// <param name="invisibleuser">隐身会员数</param>
        /// <returns></returns>
#if NET1
        public static OnlineUserInfoCollection GetForumOnlineUserCollection(int forumid, out int totaluser, out int guest, out int user, out int invisibleuser)
        {
            OnlineUserInfoCollection coll = new OnlineUserInfoCollection();
#else
        public static Yannyo.Common.Generic.List<OnlineUserInfo> GetForumOnlineUserCollection(int forumid, out int totaluser, out int guest, out int user, out int invisibleuser)
        {
            Yannyo.Common.Generic.List<OnlineUserInfo> coll = new Yannyo.Common.Generic.List<OnlineUserInfo>();
#endif
            //在线游客
            guest = 0;
            //在线隐身用户
            invisibleuser = 0;
            //用户总数
            totaluser = 0;

            IDataReader reader = DatabaseProvider.GetInstance().GetOnlineUserList();
            while (reader.Read())
            {
                OnlineUserInfo info = LoadSingleOnlineUser(reader);
                //当前版块在线总用户数
                totaluser++;
                if (info.UserID == -1)
                {
                    guest++;

                }else{
                    invisibleuser++;
                }
                coll.Add(info);
            }
            reader.Close();

            //统计用户
            user = totaluser - guest;
            //返回当前版块的在线用户表
            return coll;
        }


        /// <summary>
        /// 返回在线用户列表
        /// </summary>
        /// <param name="totaluser">全部用户数</param>
        /// <param name="guest">游客数</param>
        /// <param name="user">登录用户数</param>
        /// <param name="invisibleuser">隐身会员数</param>
        /// <returns></returns>
#if NET1
        public static OnlineUserInfoCollection GetOnlineUserCollection(out int totaluser, out int guest, out int user, out int invisibleuser)
		{
			OnlineUserInfoCollection coll = new OnlineUserInfoCollection();
#else
        public static Yannyo.Common.Generic.List<OnlineUserInfo> GetOnlineUserCollection(out int totaluser, out int guest, out int user, out int invisibleuser)
        {
            Yannyo.Common.Generic.List<OnlineUserInfo> coll = new Yannyo.Common.Generic.List<OnlineUserInfo>();
#endif
            //在线注册用户数
            user = 0;
            //在线隐身用户数
            invisibleuser = 0;
            //在线总用户数
            totaluser = 0;
            IDataReader reader = DatabaseProvider.GetInstance().GetOnlineUserList();
            while (reader.Read())
            {
                OnlineUserInfo info = LoadSingleOnlineUser(reader);
                //
                if (info.UserID > 0)
                {
                    user++;
                }
                else
                { 
                    invisibleuser++;
                }

                totaluser++;
            }
            reader.Close();

            //统计游客
            if (totaluser > user)
            {
                guest = totaluser - user;
            }
            else
            {
                guest = 0;
            }
            //返回当前版块的在线用户集合
            return coll;
        }


        public static void UpdateOnlineTime(int oltimespan, int uid)
        {
            //为0代表关闭统计功能
            if (oltimespan == 0)
            {
                return;
            }
            if (Utils.GetCookie("lastactivity", "onlinetime") == string.Empty)
            {
                Utils.WriteCookie("lastactivity", "onlinetime", System.Environment.TickCount.ToString());
            }

            if ((System.Environment.TickCount - Utils.StrToInt(Utils.GetCookie("lastactivity", "onlinetime"), System.Environment.TickCount) >= oltimespan * 60 * 1000))
            {
                DatabaseProvider.GetInstance().UpdateOnlineTime(oltimespan, uid);
                Utils.WriteCookie("lastactivity", "onlinetime", System.Environment.TickCount.ToString());

                //判断是否同步oltime (登录后的第一次onlinetime更新的时候或者在线超过1小时)
                if (Utils.GetCookie("lastactivity", "oltime") == string.Empty || (System.Environment.TickCount - Utils.StrToInt(Utils.GetCookie("lastactivity", "onlinetime"), System.Environment.TickCount) >= 60 * 60 * 1000))
                {
                    DatabaseProvider.GetInstance().SynchronizeOltime(uid);
                    Utils.WriteCookie("lastactivity", "oltime", System.Environment.TickCount.ToString());
                }
            }


        }

        #endregion

        #region Helper
        private static OnlineUserInfo LoadSingleOnlineUser(IDataReader reader)
        {
            OnlineUserInfo info = new OnlineUserInfo();
            info.olID = Int32.Parse(reader["olID"].ToString());
            info.UserID = Int32.Parse(reader["UserID"].ToString());
            info.oIP = reader["oIP"].ToString();
            info.oUserName = reader["oUserName"].ToString();
            info.UserGroupsID = Int32.Parse(reader["UserGroupsID"].ToString());
            info.UserSPID = Int32.Parse(reader["UserSPID"].ToString());
            info.oAppendTime = DateTime.Parse(reader["oAppendTime"].ToString());
            info.oLastTime = DateTime.Parse(reader["oLastTime"].ToString());
 
            return info;
        }

        private static OnlineUserInfo LoadSingleOnlineUser(DataRow dr)
        {
            OnlineUserInfo info = new OnlineUserInfo();
            info.olID = Int32.Parse(dr["olID"].ToString());
            info.UserID = Int32.Parse(dr["UserID"].ToString());
            info.oIP = dr["oIP"].ToString();
            info.oUserName = dr["oUserName"].ToString();
            info.UserGroupsID = Int32.Parse(dr["UserGroupsID"].ToString());
            info.UserSPID = Int32.Parse(dr["UserSPID"].ToString());
            info.oAppendTime = DateTime.Parse(dr["oAppendTime"].ToString());
            info.oLastTime = DateTime.Parse(dr["oLastTime"].ToString());
 
            return info;
        }
        #endregion


        /// <summary>
        /// 根据UserID获得Olid
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int GetOlidByUid(int UserID)
        {
            return DatabaseProvider.GetInstance().GetolIDByUid(UserID);
        }

        /// <summary>
        /// 删除在线表中UserID的用户
        /// </summary>
        /// <param name="UserID">要删除用户的Uid</param>
        /// <returns></returns>
        public static int DeleteUserByUid(int UserID)
        {
            int olid = GetOlidByUid(UserID);
            return DeleteRows(olid);
        }
    }
}

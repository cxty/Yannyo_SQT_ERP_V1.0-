using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;

namespace Yannyo.BLL
{
    public class tbUserInfo
    {
        #region  UserInfo
        /// <summary>
        /// UserInfo
        /// </summary>
        public static bool ExistsUserInfo(string uName)
        {
            return DatabaseProvider.GetInstance().ExistsUserInfo(uName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddUserInfo(UserInfo model)
        {
            return DatabaseProvider.GetInstance().AddUserInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateUserInfo(UserInfo model)
        {
            DatabaseProvider.GetInstance().UpdateUserInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteUserInfo(int UserID)
        {
            DatabaseProvider.GetInstance().DeleteUserInfo(UserID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteUserInfo(string UserID)
        {
            if (UserID.Trim() != "")
            {
                UserID = "," + UserID + ",";
                UserID = Utils.ReSQLSetTxt(UserID);
                DatabaseProvider.GetInstance().DeleteUserInfo(UserID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UserInfo GetUserInfoModel(int UserID)
        {
            return DatabaseProvider.GetInstance().GetUserInfoModel(UserID);
        }

		public static UserInfo GetUserInfoModelByUserName(string UserName)
		{
			return DatabaseProvider.GetInstance ().GetUserInfoModelByUserName (UserName);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetUserInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetUserInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetUserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetUserInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }

        /// <summary>
        /// 检测密码
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="password">密码</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <param name="UserGroupsID">用户组id</param>
        /// <returns>如果用户密码正确则返回uid, 否则返回-1</returns>
        public static int CheckPassword(int UserID, string uPWD, bool originalpassword)
        {
            IDataReader reader = DatabaseProvider.GetInstance().CheckPassword(UserID, uPWD, originalpassword);

            UserID = -1;
            if (reader.Read())
            {
                UserID = Utils.StrToInt(reader[0].ToString(), -1);
            }
            reader.Close();
            return UserID;
        }

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="UserSPID">接入SPID</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <returns>如果正确则返回用户id, 否则返回-1</returns>
        public static int CheckPassword(string uName, string uPWD, bool originalpassword)
        {
            IDataReader reader = DatabaseProvider.GetInstance().CheckPassword(uName, uPWD, originalpassword);
            int userid = -1;
            if (reader.Read())
            {
                userid = Int32.Parse(reader[0].ToString());
            }
            reader.Close();
            return userid;
        }

        /// <summary>
        /// 根据IP获取错误登录记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static DataTable GetErrLoginRecordByIP(string ip)
        {
            return DatabaseProvider.GetInstance().GetErrLoginRecordByIP(ip);
        }

        /// <summary>
        /// 增加指定IP的错误记录数
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int AddErrLoginCount(string ip)
        {
            return DatabaseProvider.GetInstance().AddErrLoginCount(ip);
        }

        /// <summary>
        /// 增加指定IP的错误记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int AddErrLoginRecord(string ip)
        {
            return DatabaseProvider.GetInstance().AddErrLoginRecord(ip);
        }

        /// <summary>
        /// 将指定IP的错误登录次数重置为1
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int ResetErrLoginCount(string ip)
        {
            return DatabaseProvider.GetInstance().ResetErrLoginCount(ip);
        }

        /// <summary>
        /// 删除指定IP或者超过15分钟的记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int DeleteErrLoginRecord(string ip)
        {
            return DatabaseProvider.GetInstance().DeleteErrLoginRecord(ip);
        }
        /// <summary>
        /// 增加错误次数并返回错误次数, 如不存在登录错误日志则建立
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns>int</returns>
        public static int UpdateLoginLog(string ip, bool update)
        {
            DataTable dt = DatabaseProvider.GetInstance().GetErrLoginRecordByIP(ip);
            if (dt.Rows.Count > 0)
            {
                int errcount = Utils.StrToInt(dt.Rows[0][0].ToString(), 0);
                if (Utils.StrDateDiffMinutes(dt.Rows[0][1].ToString(), 0) < 15)
                {
                    if ((errcount >= 5) || (!update))
                    {
                        return errcount;
                    }
                    else
                    {
                        DatabaseProvider.GetInstance().AddErrLoginCount(ip);
                        return errcount + 1;
                    }
                }
                DatabaseProvider.GetInstance().ResetErrLoginCount(ip);
                return 1;
            }
            else
            {
                if (update)
                {
                    DatabaseProvider.GetInstance().AddErrLoginRecord(ip);
                }
                return 1;
            }
        }
        /// <summary>
        /// 更新用户当前的在线时间和最后活动时间
        /// </summary>
        /// <param name="UserID">UserID</param>
        public static void UpdateUserOnlineTime(int UserID, string activitytime)
        {
            if (UserID < 1)
            {
                return;
            }

            DatabaseProvider.GetInstance().UpdateUserLastActivity(UserID, activitytime);
        }
        #endregion

        #region UserPssportInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool UserPassportInfoExists(int UserID)
        {
            return DatabaseProvider.GetInstance().UserPassportInfoExists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddUserPassportInfo(UserPassportInfo model)
        {
           return DatabaseProvider.GetInstance().AddUserPassportInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateUserPassportInfo(UserPassportInfo model)
        {
            DatabaseProvider.GetInstance().UpdateUserPassportInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteUserPassportInfo(int UserID)
        {
            DatabaseProvider.GetInstance().DeleteUserPassportInfo(UserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UserPassportInfo GetUserPassportInfoModel(int UserID)
        {
            return DatabaseProvider.GetInstance().GetUserPassportInfoModel(UserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetUserPassportInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetUserPassportInfoList(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetUserPassportInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetUserPassportInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        #endregion
    }
}

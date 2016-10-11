using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;

using Yannyo.Entity;
using Yannyo.Common;
using Yannyo.Config;

namespace Yannyo.SOAP
{
    public class MailQueueService
    {
        /// <summary>
        /// 获取SOAP实例
        /// </summary>
        public static object GetSOAP()
        {
            MailQueueServiceRe.MailQueueService pp = new MailQueueServiceRe.MailQueueService();
            pp.Url = GeneralConfigs.GetConfig().MailQueueWEBServicesURL.Trim();
            return pp;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPWD">密码</param>
        /// <param name="mTitle">标题</param>
        /// <param name="mContent">内容</param>
        /// <param name="mSender">发件人</param>
        /// <param name="mSendMail">发件人邮件地址</param>
        /// <param name="mAddressee">收件人</param>
        /// <param name="mAddresseeMail">收件人邮件地址</param>
        /// <param name="mIsHTML">是否HTML</param>
        /// <param name="SetSendTime">预设发送时间</param>
        /// <returns>成功返回true, 否则返回false</returns>
        public static bool SendMail(string UserName, string UserPWD, string mTitle, string mContent,string mSender, string mSendMail, string mAddressee, string mAddresseeMail,bool mIsHTML,DateTime SetSendTime)
        {

            DBOwner dbo = new DBOwner(GeneralConfigs.GetConfig().DBO_API, GeneralConfigs.GetConfig().DBO_AppID, GeneralConfigs.GetConfig().DBO_AppKey,"","json","");
            try
            {
                dbo.DBOwnerDataSendMail(GeneralConfigs.GetConfig().DBO_AppID, mAddresseeMail, mTitle, mContent);
                return true;
            }
            catch {
                return false;
            }
            /*
            MailQueueServiceRe.MailQueueService pp = (MailQueueServiceRe.MailQueueService)GetSOAP();
            try
            {
                return pp.SendMail(UserName, UserPWD, mTitle, mContent, mSender, mSendMail, mAddressee, mAddresseeMail, mIsHTML, SetSendTime) > 0;
            }
            finally
            {
                pp = null;
            }
             */
        }

        /// <summary>
        /// 批量发送邮件
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPWD">密码</param>
        /// <param name="MailEntity[]"></param>
        /// <returns>成功返回true, 否则返回false</returns>
        public static bool SendMail(string UserName, string UserPWD, DataTable mailtable)
        {

			DBOwner dbo = new DBOwner(GeneralConfigs.GetConfig().DBO_API, GeneralConfigs.GetConfig().DBO_AppID, GeneralConfigs.GetConfig().DBO_AppKey,"","json","");
            try
            {
                if (mailtable != null)
                {
                    //int i = 0;
                    //MailQueueServiceRe.MailEntity[] ee = new Yannyo.SOAP.MailQueueServiceRe.MailEntity[mailtable.Rows.Count];
                    foreach (DataRow dr in mailtable.Rows)
                    {
                        string mTitle = dr["mTitle"].ToString();
                        string mContent = dr["mContent"].ToString();
                        string mAddresseeMail = dr["mAddresseeMail"].ToString();
                        dbo.DBOwnerDataSendMail(GeneralConfigs.GetConfig().DBO_AppID, mAddresseeMail, mTitle, mContent);
                    }
                }
                
                return true;
            }
            catch
            {
                return false;
            }

            /*
            MailQueueServiceRe.MailQueueService pp = (MailQueueServiceRe.MailQueueService)GetSOAP();
            try
            {
                if (mailtable != null)
                {
                    int i = 0;
                    MailQueueServiceRe.MailEntity[] ee = new Yannyo.SOAP.MailQueueServiceRe.MailEntity[mailtable.Rows.Count];
                    foreach (DataRow dr in mailtable.Rows)
                    {
                        ee[i] = new Yannyo.SOAP.MailQueueServiceRe.MailEntity();
                        ee[i].mSender = dr["mSender"].ToString();
                        ee[i].mSendMail = dr["mSendMail"].ToString();
                        ee[i].mTitle = dr["mTitle"].ToString();
                        ee[i].mContent = dr["mContent"].ToString();
                        ee[i].mAddressee = dr["mAddressee"].ToString();
                        ee[i].mAddresseeMail = dr["mAddresseeMail"].ToString();
                        ee[i].mIsHTML = bool.Parse(dr["mIsHTML"].ToString());
                        ee[i].mSetSendTime = DateTime.Parse(dr["mSetSendTime"].ToString());

                        i++;
                    }
                    return pp.SendMailByMailEntityList(UserName, UserPWD, ee) > 0;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                pp = null;
            }
             */
        }
    }


}

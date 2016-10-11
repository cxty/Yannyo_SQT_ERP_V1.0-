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
using Top.Api;
using System.Collections;
using System.Xml;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Domain;
using Yannyo.Common.Generic;
using Top.Api.Util;

namespace Yannyo.BLL
{
    public class TopApiUtils
    {

        #region 授权

        /// <summary>
        /// 获取授权后的SessionKey
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="nick">授权用户昵称</param>
        public static string GetSessionKeyByNick(M_ConfigInfo mc, string nick)
        {
            string SessionKey = "";
            string AuthorizeKey = GetAuthorizeKey(mc, nick);
            if (AuthorizeKey != "")
            {
                SessionKey = GetSessionKey(mc, AuthorizeKey);
            }
            return SessionKey;
        }

        /// <summary>
        /// 获取当前会话的AuthorizeKey
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="nick">授权用户昵称</param>
        /// <returns></returns>
        public static string GetAuthorizeKey(M_ConfigInfo mc, string nick)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            WebUtils wb = new WebUtils();
            try
            {
                System.Collections.Generic.Dictionary<string, string> parameters = new System.Collections.Generic.Dictionary<string, string>();
                parameters.Add("nick", nick);
                string ReStr = wb.DoPost(config.Taobao_Api_Authorize + mc.m_AppKey, parameters);
                if (ReStr.Trim() != "")
                {
                    ReStr = GetHiddenKeyValue(ReStr.Trim(), config.Taobao_Api_Authorize_KeyName);
                }
                return ReStr;
            }
            finally
            {
                config = null;
                wb = null;
            }
        }

        /// <summary>
        /// 取会话SessionKey
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="AuthorizeKey">授权码</param>
        /// <returns></returns>
        public static string GetSessionKey(M_ConfigInfo mc, string AuthorizeKey)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            WebUtils wb = new WebUtils();
            try
            {
                System.Collections.Generic.Dictionary<string, string> parameters = new System.Collections.Generic.Dictionary<string, string>();

                string ReStr = wb.DoGet(config.Taobao_Api_Session + AuthorizeKey, parameters);
                if (ReStr.Trim() != "")
                {
                    ReStr = GetTopSession(ReStr.Trim(), config.Taobao_Api_Session_KeyName);
                }
                return ReStr;
            }
            finally
            {
                config = null;
                wb = null;
            }
        }
        /// <summary>
        /// 截取字符串中的SessionKey
        /// </summary>
        /// <param name="html"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetTopSession(string html, string key)
        {
            string rxString = @"" + key + "=(.*)(&amp);";
            MatchCollection mc = Regex.Matches(html, rxString);
            if (mc.Count != 0)
            {
                foreach (Match m in mc)
                {
                    string a = m.Groups[1].Value.ToString();
                    return a;
                }
            }
            return null;
        }
        /// <summary>
        /// 通过Input中的Name查找Value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="inputname"></param>
        /// <returns></returns>
        public static string FindValueByName(string str, string inputname)
        {
            string pattern = "(<input.*?name='(?<Name>[^']+?)'.*?value='(?<Value>[^']+?)'.*?>)|(<input.*?value='(?<Value>[^']+?)'.*?name='(?<Name>[^']+?)'.*?>)";
            Match match = Regex.Match(str, pattern);
            while (match.Success)
            {
                string name = match.Groups["Name"].ToString();
                string value = match.Groups["Value"].ToString();
                if (name == inputname)
                    return value;
                match = match.NextMatch();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取HTML页面内制定Key的Value内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHiddenKeyValue(string html, string key)
        {
            string str = html.Substring(html.IndexOf(key));
            str = str.Substring(str.IndexOf("value") + 7);
            int eindex1 = str.IndexOf("'");
            int eindex2 = str.IndexOf("\"");
            int eindex = eindex2;
            if (eindex1 >= 0 && eindex1 < eindex2)
            {
                eindex = eindex1;
            }
            return str.Substring(0, eindex);
        }

        #endregion

        #region 用户
        /// <summary>
        /// 查询用户公共信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="nick"></param>
        /// <returns>obj:M_UserInfo</returns>
        public static PublicReMSG GetUserInfo(M_ConfigInfo mc, string nick)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_UserInfo mu = new M_UserInfo();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            UserGetRequest req = new UserGetRequest();
            try
            {
                req.Fields = "user_id,uid,nick,sex,buyer_credit,seller_credit,location,created,last_visit,birthday,type,status,alipay_no,alipay_account,alipay_account,email,consumer_protection,alipay_bind";
                req.Nick = nick;
                UserGetResponse response = client.Execute(req);
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        mu.user_id = Convert.ToInt32(response.User.UserId);
                        mu.uid = response.User.Uid;
                        mu.nick = response.User.Nick;
                        mu.sex = response.User.Sex == null ? "" : response.User.Sex;
                        mu.birthday = response.User.Birthday != null ? response.User.Birthday : "";

                        mu.buyer_credit = new M_CreditInfo();
                        mu.buyer_credit.good_num = Convert.ToInt32(response.User.BuyerCredit.GoodNum);
                        mu.buyer_credit.m_level = Convert.ToInt32(response.User.BuyerCredit.Level);
                        mu.buyer_credit.score = Convert.ToInt32(response.User.BuyerCredit.Score);
                        mu.buyer_credit.total_num = Convert.ToInt32(response.User.BuyerCredit.TotalNum);

                        mu.seller_credit = new M_CreditInfo();
                        mu.seller_credit.good_num = Convert.ToInt32(response.User.SellerCredit.GoodNum);
                        mu.seller_credit.m_level = Convert.ToInt32(response.User.SellerCredit.Level);
                        mu.seller_credit.score = Convert.ToInt32(response.User.SellerCredit.Score);
                        mu.seller_credit.total_num = Convert.ToInt32(response.User.SellerCredit.TotalNum);

                        mu.location = new M_LocationInfo();
                        mu.location.address = response.User.Location.Address == null ? "" : response.User.Location.Address;
                        mu.location.city = response.User.Location.City == null ? "" : response.User.Location.City;
                        mu.location.country = response.User.Location.Country == null ? "" : response.User.Location.Country;
                        mu.location.district = response.User.Location.District == null ? "" : response.User.Location.District;
                        mu.location.state = response.User.Location.State == null ? "" : response.User.Location.State;
                        mu.location.zip = response.User.Location.Zip == null ? "" : response.User.Location.Zip;

                        mu.created = Convert.ToDateTime(response.User.Created);
                        mu.last_visit = Convert.ToDateTime(response.User.LastVisit);
                        mu.type = response.User.Type == null ? "" : response.User.Type;

                        //隐私信息
                        mu.birthday = response.User.Birthday == null ? "" : response.User.Birthday;
                        mu.has_more_pic = response.User.HasMorePic;
                        mu.item_img_num = Convert.ToInt32(response.User.ItemImgSize);
                        mu.item_img_size = Convert.ToInt32(response.User.ItemImgNum);
                        mu.prop_img_num = Convert.ToInt32(response.User.PropImgNum);
                        mu.prop_img_sizec = Convert.ToInt32(response.User.PropImgSize);
                        mu.auto_repost = response.User.AutoRepost == null ? "" : response.User.AutoRepost;
                        mu.promoted_type = response.User.PromotedType == null ? "" : response.User.PromotedType;
                        mu.status = response.User.Status == null ? "" : response.User.Status;
                        mu.alipay_bind = response.User.AlipayBind == null ? "" : response.User.AlipayBind;
                        mu.consumer_protection = response.User.ConsumerProtection ? 1 : 0;
                        mu.alipay_account = response.User.AlipayAccount == null ? "" : response.User.AlipayAccount;
                        mu.alipay_no = response.User.AlipayNo == null ? "" : response.User.AlipayNo;
                        //mu.real_name=response.User.r
                        mu.avatar = response.User.Avatar == null ? "" : response.User.Avatar;
                        //mu.liangpin = response.User.
                        //mu.phone = response.User.
                        //mu.mobile = response.User.
                        mu.email = response.User.Email == null ? "" : response.User.Email;
                        mu.magazine_subscribe = response.User.MagazineSubscribe;
                        mu.vertical_market = response.User.VerticalMarket == null ? "" : response.User.VerticalMarket;
                        //mu.manage_book=response.User.m
                        mu.online_gaming = response.User.OnlineGaming;

                        reValue.reCode = 0;
                        reValue.reObj = mu;
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        /// <summary>
        /// 查询用户完整信息,含隐私信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="nick"></param>
        /// <param name="sessionkey"></param>
        /// <returns>obj:M_UserInfo</returns>
        public static PublicReMSG GetUserInfo(M_ConfigInfo mc, string nick, string sessionkey)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_UserInfo mu = new M_UserInfo();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            UserGetRequest req = new UserGetRequest();
            try
            {
                req.Fields = "user_id,uid,nick,sex,buyer_credit,seller_credit,location,created,last_visit,type,birthday,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_sizec,auto_repost,promoted_type,status,alipay_bind,consumer_protection,alipay_account,alipay_no,avatar,email,magazine_subscribe,vertical_market,online_gaming";
                req.Nick = nick;
                UserGetResponse response = client.Execute(req, sessionkey);
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        mu.user_id = response.User.UserId;
                        mu.uid = response.User.Uid;
                        mu.nick = response.User.Nick;
                        mu.sex = response.User.Sex;
                        mu.birthday = response.User.Birthday != null ? response.User.Birthday : "";

                        mu.buyer_credit = new M_CreditInfo();
                        mu.buyer_credit.good_num = Convert.ToInt32(response.User.BuyerCredit.GoodNum);
                        mu.buyer_credit.m_level = Convert.ToInt32(response.User.BuyerCredit.Level);
                        mu.buyer_credit.score = Convert.ToInt32(response.User.BuyerCredit.Score);
                        mu.buyer_credit.total_num = Convert.ToInt32(response.User.BuyerCredit.TotalNum);

                        mu.seller_credit = new M_CreditInfo();
                        mu.seller_credit.good_num = Convert.ToInt32(response.User.SellerCredit.GoodNum);
                        mu.seller_credit.m_level = Convert.ToInt32(response.User.SellerCredit.Level);
                        mu.seller_credit.score = Convert.ToInt32(response.User.SellerCredit.Score);
                        mu.seller_credit.total_num = Convert.ToInt32(response.User.SellerCredit.TotalNum);

                        mu.location = new M_LocationInfo();
                        mu.location.address = response.User.Location.Address == null ? "" : response.User.Location.Address;
                        mu.location.city = response.User.Location.City == null ? "" : response.User.Location.City;
                        mu.location.country = response.User.Location.Country == null ? "" : response.User.Location.Country;
                        mu.location.district = response.User.Location.District == null ? "" : response.User.Location.District;
                        mu.location.state = response.User.Location.State == null ? "" : response.User.Location.State;
                        mu.location.zip = response.User.Location.Zip == null ? "" : response.User.Location.Zip;

                        mu.created = Convert.ToDateTime(response.User.Created);
                        mu.last_visit = Convert.ToDateTime(response.User.LastVisit);
                        mu.type = response.User.Type == null ? "" : response.User.Type;

                        //隐私信息
                        mu.birthday = response.User.Birthday == null ? "" : response.User.Birthday;
                        mu.has_more_pic = response.User.HasMorePic;
                        mu.item_img_num = Convert.ToInt32(response.User.ItemImgSize);
                        mu.item_img_size = Convert.ToInt32(response.User.ItemImgNum);
                        mu.prop_img_num = Convert.ToInt32(response.User.PropImgNum);
                        mu.prop_img_sizec = Convert.ToInt32(response.User.PropImgSize);
                        mu.auto_repost = response.User.AutoRepost == null ? "" : response.User.AutoRepost;
                        mu.promoted_type = response.User.PromotedType == null ? "" : response.User.PromotedType;
                        mu.status = response.User.Status == null ? "" : response.User.Status;
                        mu.alipay_bind = response.User.AlipayBind == null ? "" : response.User.AlipayBind;
                        mu.consumer_protection = response.User.ConsumerProtection ? 1 : 0;
                        mu.alipay_account = response.User.AlipayAccount == null ? "" : response.User.AlipayAccount;
                        mu.alipay_no = response.User.AlipayNo == null ? "" : response.User.AlipayNo;
                        //mu.real_name=response.User.r
                        mu.avatar = response.User.Avatar == null ? "" : response.User.Avatar;
                        //mu.liangpin = response.User.
                        //mu.phone = response.User.
                        //mu.mobile = response.User.
                        mu.email = response.User.Email == null ? "" : response.User.Email;
                        mu.magazine_subscribe = response.User.MagazineSubscribe;
                        mu.vertical_market = response.User.VerticalMarket == null ? "" : response.User.VerticalMarket;
                        //mu.manage_book=response.User.m
                        mu.online_gaming = response.User.OnlineGaming;

                        reValue.reCode = 0;
                        reValue.reObj = mu;
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 会员
        /// <summary>
        /// 获取会员列表
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="page_size"></param>
        /// <param name="current_page"></param>
        /// <param name="buyer_nick">可选 	会员昵称 </param>
        /// <param name="min_trade_count">可选 	最小交易量 </param>
        /// <param name="max_trade_count">可选 	最大交易量 </param>
        /// <param name="min_trade_amount">可选 	最小交易额，用分表示 </param>
        /// <param name="max_trade_amoun">可选 	最大交易额，用分表示 </param>
        /// <param name="grade">可选 	买家会员级别 general：普通会员 senior ：高级会员 vip：VIP会员 king：至尊VIP </param>
        /// <returns></returns>
        public static PublicReMSG GetMembers(M_ConfigInfo mc, long page_size, long current_page, string buyer_nick, long min_trade_count, long max_trade_count, long min_trade_amount, long max_trade_amoun, string grade)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();
            
            dt.Columns.Add("buyer_id", System.Type.GetType("System.String"));
            dt.Columns.Add("buyer_nick", System.Type.GetType("System.String"));
            dt.Columns.Add("member_grade", System.Type.GetType("System.String"));
            dt.Columns.Add("trade_amount", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("trade_count", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("laste_time", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("status", System.Type.GetType("System.String"));
            dt.Columns.Add("is_new", System.Type.GetType("System.Boolean"));

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            PromotionMembersGetRequest req = new PromotionMembersGetRequest();
            try
            {
                req.PageSize = page_size;
                req.CurrentPage = current_page;
                if (buyer_nick != null)
                {
                    req.BuyerNick = buyer_nick;
                }
                if (min_trade_count > 0)
                {
                    req.MinTradeCount = min_trade_count;
                }
                if (max_trade_count >0 )
                {
                    req.MaxTradeCount = max_trade_count;
                }
                if (min_trade_amount > 0)
                {
                    req.MinTradeAmount = min_trade_amount;
                }
                if (max_trade_amoun > 0)
                {
                    req.MaxTradeAmoun = max_trade_amoun;
                }
                if (grade != null)
                {
                    req.Grade = grade;
                }
                PromotionMembersGetResponse response = new PromotionMembersGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Members != null)
                        {
                            foreach (Member m in response.Members)
                            {
                                DataRow dr = dt.NewRow();
                                dr["buyer_id"] = m.BuyerId;
                                dr["buyer_nick"] = m.BuyerNick;
                                dr["member_grade"] = m.MemberGrade;
                                dr["trade_amount"] = m.TradeAmount*0.01;
                                dr["trade_count"] = m.TradeCount;
                                dr["laste_time"] = m.LasteTime;
                                dr["status"] = m.Status;
                                dr["is_new"] = M_Utils.ExistsM_Member(mc.m_ConfigInfoID, m.BuyerId);
                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Members";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 类目
        /// <summary>
        /// 获取商品类目列表
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="parent_cid">特殊可选 父商品类目 id，0表示根节点, 传输该参数返回所有子类目。 (cids、parent_cid至少传一个)  </param>
        /// <param name="cids">特殊可选 商品所属类目ID列表，用半角逗号(,)分隔 例如:(18957,19562,) (cids、parent_cid至少传一个)  </param>
        /// <param name="datetime">特殊可选 时间戳。格式:yyyy-MM-dd HH:mm:ss 如果没有传，则取所有的类目信息(如果传了parent_cid或者cids，则忽略datetime)  </param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetGoodsCatList(M_ConfigInfo mc, long parent_cid, string cids, string datetime)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();

            dt.Columns.Add("cid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("parent_cid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("name", System.Type.GetType("System.String"));
            dt.Columns.Add("is_parent", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("status", System.Type.GetType("System.String"));
            dt.Columns.Add("sort_order", System.Type.GetType("System.Int32"));

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemcatsGetRequest req = new ItemcatsGetRequest();
            try
            {
                req.Fields = "cid,parent_cid,name,is_parent,status,sort_order";
                req.ParentCid = parent_cid;

                if (cids != null)
                {
                    req.Cids = cids;
                }
                if (datetime != null)
                {
                    req.Datetime = Convert.ToDateTime(datetime);
                }

                ItemcatsGetResponse response = new ItemcatsGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.ItemCats != null)
                        {
                            foreach (ItemCat it in response.ItemCats)
                            {
                                DataRow dr = dt.NewRow();
                                dr["cid"] = it.Cid;
                                dr["parent_cid"] = it.ParentCid;
                                dr["name"] = it.Name;
                                dr["is_parent"] = it.IsParent;
                                dr["status"] = it.Status;
                                dr["sort_order"] = it.SortOrder;

                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no ItemCats";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 获取远程商品类目列表并转存本地数据库
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="parent_cid"></param>
        /// <param name="cids"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool GetGoodsCatListToDB(M_ConfigInfo mc, long parent_cid, string cids, string datetime)
        {
            try
            {
                DataTable dt = GetGoodsCatList(mc, parent_cid, cids, datetime).reObj as DataTable;
                if (dt != null)
                {
                    return M_Utils.AddM_GoodsCatInfoByDataTable(dt, mc.m_ConfigInfoID);
                }
                else {
                    return false;
                }                
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// 获取所有商品类目
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="parent_cid"></param>
        /// <returns></returns>
        public static bool GetGoodsCatListAll(M_ConfigInfo mc, long parent_cid)
        {
            DataTable dt = GetGoodsCatList(mc, parent_cid, null, null).reObj as DataTable;
            if (dt != null)
            {
                M_Utils.AddM_GoodsCatInfoByDataTable(dt, mc.m_ConfigInfoID);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["is_parent"].ToString() == "1" || dr["is_parent"].ToString().ToLower() == "true")
                    {
                        GetGoodsCatListAll(mc, Convert.ToInt64(dr["cid"].ToString()));
                    }
                }
                return true;
            }
            else
            {
                return false;
            }  
        }

        #endregion

        #region 商品
        /// <summary>
        /// 获取所有商品列表
        /// 字段:approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="sKey">搜索关键字</param>
        /// <param name="Cid">商品内目ID</param>
        /// <param name="SellerCids">店铺内部自定义ID</param>
        /// <param name="PageNo">页码</param>
        /// <param name="PageSize">每页显示条数,最大200</param>
        /// <param name="bDate">起始修改时间</param>
        /// <param name="eDate">结束修改时间</param>
        /// <param name="IsTaobao">是否在淘宝显示</param>
        /// <param name="IsEx">是否站外</param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetGoodsList(M_ConfigInfo mc, string sKey, long Cid, string SellerCids, long PageNo, long PageSize, string bDate, string eDate, string IsTaobao, string IsEx)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();

            dt.Columns.Add("num_iid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("approve_status", System.Type.GetType("System.String"));
            dt.Columns.Add("title", System.Type.GetType("System.String"));
            dt.Columns.Add("nick", System.Type.GetType("System.String"));
            dt.Columns.Add("type", System.Type.GetType("System.String"));
            dt.Columns.Add("cid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("pic_url", System.Type.GetType("System.String"));
            dt.Columns.Add("num", System.Type.GetType("System.Int32"));
            dt.Columns.Add("props", System.Type.GetType("System.String"));
            dt.Columns.Add("valid_thru", System.Type.GetType("System.Int32"));
            dt.Columns.Add("list_time", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("price", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("has_discount", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_invoice", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_warranty", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_showcase", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("delist_time", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("postage_id", System.Type.GetType("System.Int64"));
            dt.Columns.Add("seller_cids", System.Type.GetType("System.String"));
            dt.Columns.Add("outer_id", System.Type.GetType("System.String"));

            //本地系统商品名称
            dt.Columns.Add("outer_name", System.Type.GetType("System.String"));

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
            try
            {
                req.Fields = "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id";

                req.Q = sKey;
                req.Cid = Cid;
                req.SellerCids = SellerCids;
                req.PageNo = PageNo;
                req.OrderBy = "modified:desc";
                if (IsTaobao != null)
                {
                    req.IsTaobao = Convert.ToBoolean(IsTaobao);
                }
                if (IsEx != null)
                {
                    req.IsEx = Convert.ToBoolean(IsEx);
                }
                req.PageSize = PageSize;
                if (bDate != null)
                {
                    req.StartModified = Convert.ToDateTime(bDate);
                }
                if (eDate != null)
                {
                    req.EndModified = Convert.ToDateTime(eDate);
                }

                ItemsOnsaleGetResponse response = new ItemsOnsaleGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                       M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.TotalResults > 0)
                        {
                            foreach (Item it in response.Items)
                            {
                                DataRow dr = dt.NewRow();
                                dr["approve_status"] = it.ApproveStatus;
                                dr["num_iid"] = it.NumIid;
                                dr["title"] = it.Title;
                                dr["nick"] = it.Nick;
                                dr["type"] = it.Type;
                                dr["cid"] = it.Cid;
                                dr["pic_url"] = it.PicUrl;
                                dr["num"] = it.Num;
                                dr["props"] = it.Props;
                                dr["valid_thru"] = it.ValidThru;
                                dr["list_time"] =checkDate(it.ListTime);
                                dr["price"] = it.Price;
                                dr["has_discount"] = it.HasDiscount;
                                dr["has_invoice"] = it.HasInvoice;
                                dr["has_warranty"] = it.HasWarranty;
                                dr["has_showcase"] = it.HasShowcase;
                                dr["modified"] = checkDate(it.Modified);
                                dr["delist_time"] = checkDate(it.DelistTime);
                                dr["postage_id"] = it.PostageId;
                                dr["seller_cids"] = it.SellerCids;
                                dr["outer_id"] = it.OuterId;

                                //绑定本地商品名称
                                if (Utils.StrToInt(it.OuterId.Trim(), 0)>0)
                                {
                                    ProductsInfo pi = tbProductsInfo.GetProductsInfoModel(Utils.StrToInt(it.OuterId.Trim(),0));
                                    try
                                    {
                                        if (pi != null)
                                        {
                                            dr["outer_name"] = pi.pName;
                                        }
                                    }
                                    finally
                                    {
                                        pi = null;
                                    }
                                }

                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no response";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }



        /// <summary>
        /// 获取库存中的商品列表
        /// 字段:approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="sKey">搜索关键字</param>
        /// <param name="Cid">商品内目ID</param>
        /// <param name="SellerCids">店铺内部自定义ID</param>
        /// <param name="PageNo">页码</param>
        /// <param name="PageSize">每页显示条数,最大200</param>
        /// <param name="bDate">起始修改时间</param>
        /// <param name="eDate">结束修改时间</param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetGoodsInventory(M_ConfigInfo mc, string sKey, long Cid, string SellerCids, long PageNo, long PageSize, string bDate, string eDate)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();

            dt.Columns.Add("num_iid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("approve_status", System.Type.GetType("System.String"));
            dt.Columns.Add("title", System.Type.GetType("System.String"));
            dt.Columns.Add("nick", System.Type.GetType("System.String"));
            dt.Columns.Add("type", System.Type.GetType("System.String"));
            dt.Columns.Add("cid", System.Type.GetType("System.Int64"));
            dt.Columns.Add("pic_url", System.Type.GetType("System.String"));
            dt.Columns.Add("num", System.Type.GetType("System.Int32"));
            dt.Columns.Add("props", System.Type.GetType("System.String"));
            dt.Columns.Add("valid_thru", System.Type.GetType("System.Int32"));
            dt.Columns.Add("list_time", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("price", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("has_discount", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_invoice", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_warranty", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("has_showcase", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("delist_time", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("postage_id", System.Type.GetType("System.Int64"));
            dt.Columns.Add("seller_cids", System.Type.GetType("System.String"));
            dt.Columns.Add("outer_id", System.Type.GetType("System.String"));

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemsInventoryGetRequest req = new ItemsInventoryGetRequest();
            try
            {
                req.Fields = "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id";

                req.Q = sKey;
                req.Cid = Cid;
                req.SellerCids = SellerCids;
                req.PageNo = PageNo;
                req.OrderBy = "list_time:desc";
                req.IsTaobao = true;
                req.IsEx = true;
                req.PageSize = PageSize;
                if (bDate != null)
                {
                    req.StartModified = Convert.ToDateTime(bDate);
                }
                if (eDate != null)
                {
                    req.EndModified = Convert.ToDateTime(eDate);
                }

                ItemsInventoryGetResponse response = new ItemsInventoryGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.TotalResults > 0)
                        {
                            foreach (Item it in response.Items)
                            {
                                DataRow dr = dt.NewRow();
                                dr["approve_status"] = it.ApproveStatus;
                                dr["num_iid"] = it.NumIid;
                                dr["title"] = it.Title;
                                dr["nick"] = it.Nick;
                                dr["type"] = it.Type;
                                dr["cid"] = it.Cid;
                                dr["pic_url"] = it.PicUrl;
                                dr["num"] = it.Num;
                                dr["props"] = it.Props;
                                dr["valid_thru"] = it.ValidThru;
                                dr["list_time"] = checkDate(it.ListTime);
                                dr["price"] = it.Price;
                                dr["has_discount"] = it.HasDiscount;
                                dr["has_invoice"] = it.HasInvoice;
                                dr["has_warranty"] = it.HasWarranty;
                                dr["has_showcase"] = it.HasShowcase;
                                dr["modified"] = checkDate(it.Modified);
                                dr["delist_time"] = checkDate(it.DelistTime);
                                dr["postage_id"] = it.PostageId;
                                dr["seller_cids"] = it.SellerCids;
                                dr["outer_id"] = it.OuterId;

                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no response";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 获取指定商品详细信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="nick">卖家昵称</param>
        /// <param name="num_iid">商品网店编号</param>
        /// <returns>obj:M_GoodsInfo</returns>
        public static PublicReMSG GetGoodsInfo(M_ConfigInfo mc, string nick, long num_iid)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_GoodsInfo mg = new M_GoodsInfo();

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemGetRequest req = new ItemGetRequest();
            try
            {
                req.Fields = "iid,detail_url,num_iid,title,nick,type,sku,props_name,promoted_service,cid,seller_cids,props,input_pids,input_str,desc,pic_url,num,valid_thru,list_time,delist_time,stuff_status,location,price,post_fee,express_fee,ems_fee,has_discount,freight_payer,has_invoice,has_warranty,has_showcase,modified,increment,auto_repost,approve_status,postage_id,product_id,auction_point,property_alias,item_img,prop_img,outer_id,is_virtual,is_taobao,is_ex,is_timing,video,is_3D,score,volume,one_station,second_kill,auto_fill,violation,appkey,callbackUrl,created,is_prepay,ww_status,wap_desc,wap_detail_url,after_sale_id,cod_postage_id,sell_promise";
                if (nick != null)
                {
                    req.Nick = nick;
                }
                req.NumIid = num_iid;

                ItemGetResponse response = new ItemGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item != null)
                        {
                            mg.product_id = response.Item.ProductId;
                            mg.outer_id = response.Item.OuterId;
                            mg.num_iid = response.Item.NumIid;
                            mg.detail_url = response.Item.DetailUrl;
                            mg.title = response.Item.Title;
                            mg.nick = response.Item.Nick;
                            mg.type = response.Item.Type;
                            mg.props_name = response.Item.PropsName;
                            mg.promoted_service = response.Item.PromotedService;
                            mg.cid = response.Item.Cid;
                            mg.seller_cids = response.Item.SellerCids;
                            mg.props = response.Item.Props;
                            mg.input_pids = response.Item.InputPids;
                            mg.input_str = response.Item.InputStr;
                            mg.m_desc = response.Item.Desc;
                            mg.pic_url = response.Item.PicUrl;
                            mg.num = Convert.ToInt32(response.Item.Num);
                            mg.valid_thru = Convert.ToInt32(response.Item.ValidThru);
                            mg.list_time = Convert.ToDateTime(response.Item.ListTime);
                            mg.delist_time = checkDate(response.Item.DelistTime);
                            mg.stuff_status = response.Item.StuffStatus;
                            mg.price = Convert.ToDecimal(response.Item.Price);
                            mg.post_fee = Convert.ToDecimal(response.Item.PostFee);
                            mg.express_fee = Convert.ToDecimal(response.Item.ExpressFee);
                            mg.ems_fee = Convert.ToDecimal(response.Item.EmsFee);
                            mg.has_discount = response.Item.HasDiscount;
                            mg.freight_payer = response.Item.FreightPayer;
                            mg.has_invoice = response.Item.HasInvoice;
                            mg.has_warranty = response.Item.HasWarranty;
                            mg.has_showcase = response.Item.HasShowcase;
                            mg.modified = checkDate(response.Item.Modified);
                            mg.increment = response.Item.Increment;
                            mg.approve_status = response.Item.ApproveStatus;
                            mg.postage_id = response.Item.PostageId;
                            mg.auction_point = Convert.ToInt32(response.Item.AuctionPoint);
                            mg.property_alias = response.Item.PropertyAlias;
                            mg.is_virtual = response.Item.IsVirtual;
                            mg.is_taobao = response.Item.IsTaobao;
                            mg.is_ex = response.Item.IsEx;
                            mg.is_timing = response.Item.IsTiming;
                            mg.is_3D = response.Item.Is3D;
                            mg.one_station = response.Item.OneStation;
                            mg.second_kill = response.Item.SecondKill;
                            mg.auto_fill = response.Item.AutoFill;
                            mg.violation = response.Item.Violation;
                            mg.created = checkDate(response.Item.Created);
                            mg.cod_postage_id = response.Item.CodPostageId;
                            mg.sell_promise = response.Item.SellPromise;

                            mg.m_UpdateTime = DateTime.Now;

                            int i = 0;
                            //商品Sku信息
                            if (response.Item.Skus != null)
                            {
                                if (response.Item.Skus.Count > 0)
                                {
                                    mg.skus = new M_GoodsSkuInfo[response.Item.Skus.Count];
                                    i = 0;
                                    foreach (Sku sku in response.Item.Skus)
                                    {
                                        mg.skus[i] = new M_GoodsSkuInfo();
                                        mg.skus[i].created = checkDate(sku.Created);
                                        mg.skus[i].modified = checkDate(sku.Modified);
                                        mg.skus[i].num_iid = sku.NumIid;
                                        mg.skus[i].outer_id = sku.OuterId;
                                        mg.skus[i].price = Convert.ToDecimal(sku.Price);
                                        mg.skus[i].properties = sku.Properties;
                                        mg.skus[i].quantity = Convert.ToInt32(sku.Quantity);
                                        mg.skus[i].sku_id = sku.SkuId;
                                        mg.skus[i].status = sku.Status;
                                        i++;
                                    }
                                }
                            }
                            //商品所在地
                            if (response.Item.Location != null)
                            {
                                mg.location = new M_LocationInfo();
                                mg.location.address = response.Item.Location.Address;
                                mg.location.city = response.Item.Location.City;
                                mg.location.country = response.Item.Location.Country;
                                mg.location.district = response.Item.Location.District;
                                mg.location.state = response.Item.Location.State;
                                mg.location.zip = response.Item.Location.Zip;
                            }
                            //商品图片
                            if (response.Item.ItemImgs != null)
                            {
                                if (response.Item.ItemImgs.Count > 0)
                                {
                                    mg.item_imgs = new M_ImgInfo[response.Item.ItemImgs.Count];
                                    i = 0;
                                    foreach (ItemImg img in response.Item.ItemImgs)
                                    {
                                        mg.item_imgs[i] = new M_ImgInfo();
                                        mg.item_imgs[i].created = checkDate(img.Created);
                                        mg.item_imgs[i].modified = checkDate(img.Created);
                                        mg.item_imgs[i].m_id = img.Id;
                                        mg.item_imgs[i].position = Convert.ToInt32(img.Position);
                                        mg.item_imgs[i].url = img.Url;
                                        i++;
                                    }
                                }
                            }
                            //商品属性图片
                            if (response.Item.PropImgs != null)
                            {
                                if (response.Item.PropImgs.Count > 0)
                                {
                                    mg.prop_imgs = new M_PropImgInfo[response.Item.PropImgs.Count];
                                    i = 0;
                                    foreach (PropImg img in response.Item.PropImgs)
                                    {
                                        mg.prop_imgs[i] = new M_PropImgInfo();
                                        mg.prop_imgs[i].created = checkDate(img.Created);
                                        mg.prop_imgs[i].m_id = img.Id;
                                        mg.prop_imgs[i].modified = checkDate(img.Created);
                                        mg.prop_imgs[i].position = Convert.ToInt32(img.Position);
                                        mg.prop_imgs[i].props = img.Properties;
                                        mg.prop_imgs[i].url = img.Url;
                                        i++;
                                    }
                                }
                            }
                            //商品视频
                            if (response.Item.Videos != null)
                            {
                                if (response.Item.Videos.Count > 0)
                                {
                                    mg.videos = new M_VideoInfo[response.Item.Videos.Count];
                                    i = 0;
                                    foreach (Video img in response.Item.Videos)
                                    {
                                        mg.videos[i] = new M_VideoInfo();
                                        mg.videos[i].created = checkDate(img.Created);
                                        mg.videos[i].video_id = img.Id;
                                        mg.videos[i].num_iid = img.NumIid;
                                        mg.videos[i].modified = checkDate(img.Modified);
                                        mg.videos[i].num_iid = img.NumIid;
                                        mg.videos[i].url = img.Url;
                                        mg.videos[i].video_id = img.VideoId;
                                        i++;
                                    }
                                }
                            }
                            reValue.reCode = 0;
                            reValue.reObj = mg;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Item";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 商品下架
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsDelisting(M_ConfigInfo mc, long num_iid)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemUpdateDelistingRequest req = new ItemUpdateDelistingRequest();
            try
            {
                req.NumIid = num_iid;

                ItemUpdateDelistingResponse response = new ItemUpdateDelistingResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 商品上架
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsListing(M_ConfigInfo mc, long num_iid, long num)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemUpdateListingRequest req = new ItemUpdateListingRequest();

            try
            {
                req.NumIid = num_iid;
                req.Num = num;

                ItemUpdateListingResponse response = new ItemUpdateListingResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 橱窗推荐一个商品
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsRecommendAdd(M_ConfigInfo mc, long num_iid)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemRecommendAddRequest req = new ItemRecommendAddRequest();
            try
            {
                req.NumIid = num_iid;

                ItemRecommendAddResponse response = new ItemRecommendAddResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no RefundId";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 取消一个橱窗推荐商品
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsRecommendDelete(M_ConfigInfo mc, long num_iid)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemRecommendDeleteRequest req = new ItemRecommendDeleteRequest();
            try
            {
                req.NumIid = num_iid;
                ItemRecommendDeleteResponse response = new ItemRecommendDeleteResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsDelete(M_ConfigInfo mc, long num_iid)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemDeleteRequest req = new ItemDeleteRequest();
            try
            {
                req.NumIid = num_iid;

                ItemDeleteResponse response = new ItemDeleteResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 更新商品信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid">必须 	商品数字ID</param>
        /// <param name="cid">可选 	叶子类目id </param>
        /// <param name="props">可选 	商品属性列表。格式:pid:vid;pid:vid。</param>
        /// <param name="num">可选 	商品数量</param>
        /// <param name="price">	可选 	商品价格</param>
        /// <param name="title">可选 	宝贝标题</param>
        /// <param name="desc">可选 	商品描述</param>
        /// <param name="location_state">可选 	所在地省份</param>
        /// <param name="location_city">可选 	所在地城市</param>
        /// <param name="post_fee">可选 	平邮费用</param>
        /// <param name="express_fee">	可选 	快递费用</param>
        /// <param name="ems_fee">可选 	ems费用</param>
        /// <param name="list_time">可选 	上架时间</param>
        /// <param name="increment">	可选 	加价幅度</param>
        /// <param name="stuff_status">可选 	商品新旧程度。可选值:new（全新）,unused（闲置）,second（二手）</param>
        /// <param name="auction_point">可选 	商品的积分返点比例</param>
        /// <param name="property_alias">可选 	属性值别名</param>
        /// <param name="input_pids">可选 	用户自行输入的类目属性ID串</param>
        /// <param name="sku_quantities">可选 	更新的Sku的数量串</param>
        /// <param name="sku_prices">可选 	更新的Sku的价格串</param>
        /// <param name="sku_properties">可选 	更新的Sku的属性串</param>
        /// <param name="postage_id">可选 	宝贝所属的运费模板ID</param>
        /// <param name="outer_id">可选 	商家编码</param>
        /// <param name="product_id">可选 	商品所属的产品ID</param>
        /// <param name="auto_fill">可选 	代充商品类型</param>
        /// <param name="sku_outer_ids">可选 	Sku的外部id串</param>
        /// <param name="is_taobao">可选 	是否在淘宝上显示</param>
        /// <param name="is_ex">可选 	是否在外店显示</param>
        /// <param name="is_3D">可选 	是否是3D</param>
        /// <param name="is_replace_sku">可选 	是否替换sku </param>
        /// <param name="input_str">可选 	用户自行输入的子属性名和属性值</param>
        /// <param name="lang">可选 	商品文字的版本，繁体传入”zh_HK”，简体传入”zh_CN” </param>
        /// <param name="has_discount">可选 	支持会员打折</param>
        /// <param name="has_showcase">可选 	橱窗推荐</param>
        /// <param name="approve_status">可选 	商品上传后的状态</param>
        /// <param name="freight_payer">可选 	运费承担方式</param>
        /// <param name="valid_thru">可选 	有效期</param>
        /// <param name="has_invoice">可选 	是否有发票</param>
        /// <param name="has_warranty">可选 	是否有保修</param>
        /// <param name="after_sale_id">可选 	售后服务说明模板id</param>
        /// <param name="sell_promise">可选 	是否承诺退换货服务!虚拟商品无须设置此项! </param>
        /// <param name="postage">可选 	货到付款运费模板ID </param>
        /// <param name="fileLocation">可选 更新商品图片,本地图片路径</param>
        /// <param name="seller_cids">可选 	重新关联商品与店铺类目</param>
        /// <returns></returns>
        public static PublicReMSG GoodsUpdate(M_ConfigInfo mc, long num_iid, string cid, string props, string num, string price, string title, string desc,
            string location_state, string location_city, string post_fee, string express_fee, string ems_fee, string list_time,string increment,string fileLocation, string stuff_status, string auction_point, 
            string property_alias, string input_pids, string sku_quantities, string sku_prices, string sku_properties,string seller_cids, string postage_id, string outer_id, string product_id,
            string auto_fill, string sku_outer_ids, string is_taobao, string is_ex, string is_3D, string is_replace_sku, string input_str, string lang, string has_discount,
            string has_showcase, string approve_status, string freight_payer, string valid_thru, string has_invoice, string has_warranty, string after_sale_id, string sell_promise, string postage)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            ItemUpdateRequest req = new ItemUpdateRequest();
            try
            {
                req.NumIid = num_iid;
                if (cid != null)
                {
                    req.Cid =long.Parse(cid);
                }
                if (props != null)
                {
                    req.Props = props;
                }
                if (num != null)
                {
                    req.Num =long.Parse(num);
                }
                if (price != null)
                {
                    req.Price = price;
                }
                if (title != null)
                {
                    req.Title = title;
                }
                if (desc != null)
                {
                    req.Desc = desc;
                }
                if (location_state != null)
                {
                    req.LocationState = location_state;
                }
                if (location_city != null)
                {
                    req.LocationCity = location_city;
                }
                if (post_fee != null)
                {
                    req.PostFee = post_fee;
                }
                if (express_fee != null)
                {
                    req.ExpressFee = express_fee;
                }
                if (ems_fee != null)
                {
                    req.EmsFee = ems_fee;
                }
                if (list_time != null)
                {
                    req.ListTime = Convert.ToDateTime(list_time);
                }
                if (increment != null)
                {
                    req.Increment = increment;
                }
                if (fileLocation != null)
                {
                    FileItem fItem = new FileItem(fileLocation);
                    req.Image = fItem;
                }
                if (stuff_status != null)
                {
                    req.StuffStatus = stuff_status;
                }
                if (auction_point != null)
                {
                    req.AuctionPoint = long.Parse(auction_point);
                }
                if (property_alias != null)
                {
                    req.PropertyAlias = property_alias;
                }
                if (input_pids != null)
                {
                    req.InputPids = input_pids;
                }
                if (sku_quantities != null)
                {
                    req.SkuQuantities = sku_quantities;
                }
                if (sku_prices != null)
                {
                    req.SkuPrices = sku_prices;
                }
                if (sku_properties != null)
                {
                    req.SkuProperties = sku_properties;
                }
                if (seller_cids != null)
                {
                    req.SellerCids = seller_cids;
                }
                if (postage_id != null)
                {
                    req.PostageId =long.Parse( postage_id);
                }
                if (outer_id != null)
                {
                    req.OuterId = outer_id;
                }
                if (product_id != null)
                {
                    req.ProductId = long.Parse( product_id);
                }
                //req.PicPath = "uploaded/i7/T1rfxpXcVhXXXH9QcZ_033150.jpg";
                if (auto_fill != null)
                {
                    req.AutoFill = auto_fill;
                }
                if (sku_outer_ids != null)
                {
                    req.SkuOuterIds = sku_outer_ids;
                }
                if (is_taobao != null)
                {
                    req.IsTaobao = Convert.ToBoolean(is_taobao);
                }
                if (is_ex != null)
                {
                    req.IsEx = Convert.ToBoolean(is_ex);
                }
                if (is_3D != null)
                {
                    req.Is3D = Convert.ToBoolean(is_3D);
                }
                if (is_replace_sku != null)
                {
                    req.IsReplaceSku = Convert.ToBoolean(is_replace_sku);
                }
                if (input_str != null)
                {
                    req.InputStr = input_str;
                }
                if (lang != null)
                {
                    req.Lang = lang;
                }
                if (has_discount != null)
                {
                    req.HasDiscount = Convert.ToBoolean(has_discount);
                }
                if (has_showcase != null)
                {
                    req.HasShowcase = Convert.ToBoolean(has_showcase);
                }
                if (approve_status != null)
                {
                    req.ApproveStatus = approve_status;
                }
                if (freight_payer != null)
                {
                    req.FreightPayer = freight_payer;
                }
                if (valid_thru != null)
                {
                    req.ValidThru = long.Parse(valid_thru);
                }
                if (has_invoice != null)
                {
                    req.HasInvoice = Convert.ToBoolean(has_invoice);
                }
                if (has_warranty != null)
                {
                    req.HasWarranty = Convert.ToBoolean(has_warranty);
                }
                if (after_sale_id != null)
                {
                    req.AfterSaleId = long.Parse(after_sale_id);
                }
                if (sell_promise != null)
                {
                    req.SellPromise = Convert.ToBoolean(sell_promise);
                }
                if (postage != null)
                {
                    req.CodPostageId = long.Parse(postage);
                }

                ItemUpdateResponse response = new ItemUpdateResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Item.NumIid > 0)
                        {
                            //response.Item.Modified;修改时间
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 更新商品本地编号
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid">必须 	商品数字ID</param>
        /// <param name="outer_id">将匹配的本地商品ID</param>
        /// <returns></returns>
        public static PublicReMSG GoodsUpdateOuter_id(M_ConfigInfo mc, long num_iid, string outer_id)
        {
            return GoodsUpdate(mc, num_iid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, outer_id,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null);
        }
        /// <summary>
        /// 更新商品数量
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="num_iid"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static PublicReMSG GoodsUpdateNum(M_ConfigInfo mc, long num_iid, string num)
        {
            return GoodsUpdate(mc, num_iid, null, null, num, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }
        #endregion

        #region 交易
        /// <summary>
        /// 增量查询交易信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="bDate">查询修改开始时间(修改时间跨度不能大于一天)</param>
        /// <param name="eDate">查询修改结束时间，必须大于修改开始时间(修改时间跨度不能大于一天)</param>
        /// <param name="status">可选 交易状态</param>
        /// <param name="type">可选 交易类型列表</param>
        /// <param name="tag">可选 卖家对交易的自定义分组标签</param>
        /// <param name="page_no">可选 页码</param>
        /// <param name="page_size">可选 每页条数</param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetTradesListIncrement(M_ConfigInfo mc, string bDate, string eDate, string status, string type, string tag, long page_no, long page_size)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradesSoldIncrementGetRequest req = new TradesSoldIncrementGetRequest();
            try
            {
                dt.Columns.Add("seller_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("buyer_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("title", System.Type.GetType("System.String"));
                dt.Columns.Add("type", System.Type.GetType("System.String"));
                dt.Columns.Add("created", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("tid", System.Type.GetType("System.Int64"));
                dt.Columns.Add("seller_rate", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("buyer_rate", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("status", System.Type.GetType("System.String"));
                dt.Columns.Add("payment", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("discount_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("adjust_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("post_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("total_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("pay_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("end_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("consign_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("buyer_obtain_point_fee", System.Type.GetType("System.Int64"));
                dt.Columns.Add("point_fee", System.Type.GetType("System.Int32"));
                dt.Columns.Add("real_point_fee", System.Type.GetType("System.Int64"));
                dt.Columns.Add("received_payment", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("commission_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("pic_path", System.Type.GetType("System.String"));
                dt.Columns.Add("num_iid", System.Type.GetType("System.Int64"));
                dt.Columns.Add("num", System.Type.GetType("System.Int32"));
                dt.Columns.Add("price", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("cod_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("cod_status", System.Type.GetType("System.String"));
                dt.Columns.Add("shipping_type", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_name", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_state", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_city", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_district", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_address", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_zip", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_mobile", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_phone", System.Type.GetType("System.String"));
                dt.Columns.Add("is_new", System.Type.GetType("System.Boolean"));

                req.Fields = "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee," +
                                    "real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone, orders";
                if (bDate != null)
                {
                    req.StartModified = Convert.ToDateTime(bDate);
                }
                if (eDate != null)
                {
                    req.EndModified = Convert.ToDateTime(eDate);
                }
                if (status != null)
                {
                    req.Status = status;
                }
                if (type != null)
                {
                    req.Type = type;
                }
                if (tag != null)
                {
                    req.Tag = tag;
                }
                
                    req.PageNo = page_no;
                
                    req.PageSize = page_size;
                

                TradesSoldIncrementGetResponse response = new TradesSoldIncrementGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trades.Count > 0)
                        {
                            foreach (Trade tr in response.Trades)
                            {
                                DataRow dr = dt.NewRow();
                                dr["seller_nick"] = tr.SellerNick;
                                dr["buyer_nick"] = tr.BuyerNick;
                                dr["title"] = tr.Title;
                                dr["type"] = tr.Type;
                                dr["created"] = checkDate(tr.Created);
                                dr["tid"] = tr.Tid;
                                dr["seller_rate"] = tr.SellerRate;
                                dr["buyer_rate"] = tr.BuyerRate;
                                dr["status"] = tr.Status;
                                dr["payment"] = tr.Payment;
                                dr["discount_fee"] =Convert.ToDecimal( tr.DiscountFee);
                                dr["adjust_fee"] =Convert.ToDecimal( tr.AdjustFee);
                                dr["post_fee"] =Convert.ToDecimal( tr.PostFee);
                                dr["total_fee"] =Convert.ToDecimal( tr.TotalFee);
                                dr["pay_time"] = checkDate(tr.PayTime);
                                dr["end_time"] = checkDate(tr.EndTime);
                                dr["modified"] = checkDate(tr.Modified);
                                dr["consign_time"] = checkDate(tr.ConsignTime);
                                dr["buyer_obtain_point_fee"] = tr.BuyerObtainPointFee;
                                dr["point_fee"] =Convert.ToInt32( tr.PointFee);
                                dr["real_point_fee"] = tr.RealPointFee;
                                dr["received_payment"] =Convert.ToDecimal( tr.ReceivedPayment);
                                dr["commission_fee"] =Convert.ToDecimal(tr.CommissionFee);
                                dr["pic_path"] = tr.PicPath;
                                dr["num_iid"] = tr.NumIid;
                                dr["num"] = tr.Num;
                                dr["price"] = Convert.ToDecimal(tr.Price);
                                dr["cod_fee"] =Convert.ToDecimal( tr.CodFee);
                                dr["cod_status"] = tr.CodStatus;
                                dr["shipping_type"] = tr.ShippingType;
                                dr["receiver_name"] = tr.ReceiverName;
                                dr["receiver_state"] = tr.ReceiverState;
                                dr["receiver_city"] = tr.ReceiverCity;
                                dr["receiver_district"] = tr.ReceiverDistrict;
                                dr["receiver_address"] = tr.ReceiverAddress;
                                dr["receiver_zip"] = tr.ReceiverZip;
                                dr["receiver_mobile"] = tr.ReceiverMobile;
                                dr["receiver_phone"] = tr.ReceiverPhone;

                                dr["is_new"] = M_Utils.ExistsM_TradeInfo(mc.m_ConfigInfoID, tr.Tid);

                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Trades";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 普通查询交易信息(三个月内)
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="bDate">查询三个月内交易创建时间开始</param>
        /// <param name="eDate">查询交易创建时间结束</param>
        /// <param name="buyer_nick">可选 买家</param>
        /// <param name="type">可选 交易类型列表</param>
        /// <param name="status">可选 交易状态</param>
        /// <param name="rate_status">可选 评价状态，默认查询所有评价状态的数据，除了默认值外每次只能查询一种状态</param>
        /// <param name="tag">可选 卖家对交易的自定义分组标签，目前可选值为：time_card（点卡软件代充），fee_card（话费软件代充） </param>
        /// <param name="page_no">可选 页码</param>
        /// <param name="page_size">可选 每页条数</param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetTradesList(M_ConfigInfo mc, string bDate, string eDate, string buyer_nick, string type, string status, string rate_status, string tag, long page_no, long page_size)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradesSoldGetRequest req = new TradesSoldGetRequest();
            try
            {
                dt.Columns.Add("seller_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("buyer_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("title", System.Type.GetType("System.String"));
                dt.Columns.Add("type", System.Type.GetType("System.String"));
                dt.Columns.Add("created", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("tid", System.Type.GetType("System.Int64"));
                dt.Columns.Add("seller_rate", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("buyer_rate", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("status", System.Type.GetType("System.String"));
                dt.Columns.Add("payment", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("discount_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("adjust_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("post_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("total_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("pay_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("end_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("consign_time", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("buyer_obtain_point_fee", System.Type.GetType("System.Int64"));
                dt.Columns.Add("point_fee", System.Type.GetType("System.Int32"));
                dt.Columns.Add("real_point_fee", System.Type.GetType("System.Int64"));
                dt.Columns.Add("received_payment", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("commission_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("pic_path", System.Type.GetType("System.String"));
                dt.Columns.Add("num_iid", System.Type.GetType("System.Int64"));
                dt.Columns.Add("num", System.Type.GetType("System.Int32"));
                dt.Columns.Add("price", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("cod_fee", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("cod_status", System.Type.GetType("System.String"));
                dt.Columns.Add("shipping_type", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_name", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_state", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_city", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_district", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_address", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_zip", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_mobile", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_phone", System.Type.GetType("System.String"));
                dt.Columns.Add("is_new", System.Type.GetType("System.Boolean"));

                req.Fields = "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee," +
                                    "real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone, orders";
                if (bDate != null)
                {
                    req.StartCreated = Convert.ToDateTime(bDate);
                }
                if (eDate != null)
                {
                    req.EndCreated = Convert.ToDateTime(eDate);
                }
                if (status != null)
                {
                    req.Status = status;
                }
                if (type != null)
                {
                    req.Type = type;
                }
                if (buyer_nick != null)
                {
                    req.BuyerNick = buyer_nick;
                }
                if (rate_status != null)
                {
                    req.RateStatus = rate_status;
                }
                if (tag != null)
                {
                    req.Tag = tag;
                }
               
                    req.PageNo = page_no;
                
                    req.PageSize = page_size;
                
                TradesSoldGetResponse response = new TradesSoldGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trades.Count > 0)
                        {
                            foreach (Trade tr in response.Trades)
                            {
                                DataRow dr = dt.NewRow();
                                dr["seller_nick"] = tr.SellerNick;
                                dr["buyer_nick"] = tr.BuyerNick;
                                dr["title"] = tr.Title;
                                dr["type"] = tr.Type;
                                dr["created"] = checkDate(tr.Created);
                                dr["tid"] = tr.Tid;
                                dr["seller_rate"] = tr.SellerRate;
                                dr["buyer_rate"] = tr.BuyerRate;
                                dr["status"] = tr.Status;
                                dr["payment"] =Convert.ToDecimal(tr.Payment);
                                dr["discount_fee"] =Convert.ToDecimal(tr.DiscountFee);
                                dr["adjust_fee"] = Convert.ToDecimal(tr.AdjustFee);
                                dr["post_fee"] =Convert.ToDecimal(tr.PostFee);
                                dr["total_fee"] =Convert.ToDecimal(tr.TotalFee);
                                dr["pay_time"] =Convert.ToDateTime(tr.PayTime);
                                dr["end_time"] = checkDate(tr.EndTime);
                                dr["modified"] = checkDate(tr.Modified);
                                dr["consign_time"] = checkDate(tr.ConsignTime);
                                dr["buyer_obtain_point_fee"] = tr.BuyerObtainPointFee;
                                dr["point_fee"] =Convert.ToInt32(tr.PointFee);
                                dr["real_point_fee"] = tr.RealPointFee;
                                dr["received_payment"] = tr.ReceivedPayment;
                                dr["commission_fee"] = Convert.ToDecimal(tr.CommissionFee);
                                dr["pic_path"] = tr.PicPath;
                                dr["num_iid"] = tr.NumIid;
                                dr["num"] = tr.Num;
                                dr["price"] = Convert.ToDecimal(tr.Price);
                                dr["cod_fee"] = Convert.ToDecimal(tr.CodFee);
                                dr["cod_status"] = tr.CodStatus;
                                dr["shipping_type"] = tr.ShippingType;
                                dr["receiver_name"] = tr.ReceiverName;
                                dr["receiver_state"] = tr.ReceiverState;
                                dr["receiver_city"] = tr.ReceiverCity;
                                dr["receiver_district"] = tr.ReceiverDistrict;
                                dr["receiver_address"] = tr.ReceiverAddress;
                                dr["receiver_zip"] = tr.ReceiverZip;
                                dr["receiver_mobile"] = tr.ReceiverMobile;
                                dr["receiver_phone"] = tr.ReceiverPhone;

                                dr["is_new"] = M_Utils.ExistsM_TradeInfo(mc.m_ConfigInfoID, tr.Tid);
                                
                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Trades";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 获取交易的详细信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易编号</param>
        /// <returns>obj:M_TradeInfo</returns>
        public static PublicReMSG GetTradesFullInfo(M_ConfigInfo mc, long tid)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_TradeInfo mt = new M_TradeInfo();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
            try
            {
                req.Tid = tid;
                req.Fields = "seller_nick, buyer_nick, title, type, created, tid, seller_rate,buyer_flag, buyer_rate, status, payment, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, buyer_memo, seller_memo, alipay_no, buyer_message, pic_path, num_iid, num, price, buyer_alipay_no, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone, buyer_email,seller_flag, seller_alipay_no, seller_mobile, seller_phone, seller_name, seller_email, available_confirm_fee, has_post_fee, timeout_action_time, snapshot_url, cod_fee, cod_status, shipping_type, trade_memo, is_3D,buyer_memo,buyer_email,orders,promotion_details";

                TradeFullinfoGetResponse response = new TradeFullinfoGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                   response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trade != null)
                        {
                            mt.seller_nick = response.Trade.SellerNick;
                            mt.buyer_nick = response.Trade.BuyerNick;
                            mt.title = response.Trade.Title == null ? "" : response.Trade.Title;
                            mt.type = response.Trade.Type == null ? "" : response.Trade.Type;
                            mt.created = checkDate(response.Trade.Created);
                            mt.tid = response.Trade.Tid;
                            
                            mt.status = response.Trade.Status == null ? "" : response.Trade.Status;
                            mt.payment = Convert.ToDecimal(response.Trade.Payment);
                            mt.discount_fee = Convert.ToDecimal(response.Trade.DiscountFee);
                            mt.adjust_fee = Convert.ToDecimal(response.Trade.AdjustFee);
                            mt.post_fee = Convert.ToDecimal(response.Trade.PostFee);
                            mt.total_fee = Convert.ToDecimal(response.Trade.TotalFee);
                            mt.pay_time = checkDate(response.Trade.PayTime);
                            mt.end_time = checkDate(response.Trade.EndTime);
                            mt.modified = checkDate(response.Trade.Modified);
                            mt.consign_time = checkDate(response.Trade.ConsignTime);
                            
                            mt.point_fee = Convert.ToInt32(response.Trade.PointFee);
                            mt.real_point_fee = Convert.ToInt32(response.Trade.RealPointFee);
                            mt.received_payment = Convert.ToDecimal(response.Trade.ReceivedPayment);
                            mt.commission_fee = Convert.ToDecimal(response.Trade.CommissionFee);
                            mt.pic_path = response.Trade.PicPath == null ? "" : response.Trade.PicPath;
                            mt.num_iid = response.Trade.NumIid;
                            mt.num = Convert.ToInt32(response.Trade.Num);
                            mt.price = Convert.ToDecimal(response.Trade.Price);
                            mt.cod_fee = Convert.ToDecimal(response.Trade.CodFee);
                            mt.cod_status = response.Trade.CodStatus == null ? "" : response.Trade.CodStatus;
                            mt.shipping_type = response.Trade.ShippingType == null ? "" : response.Trade.ShippingType;

                            mt.receiver_name = response.Trade.ReceiverName == null ? "" : response.Trade.ReceiverName;
                            mt.receiver_state = response.Trade.ReceiverState == null ? "" : response.Trade.ReceiverState;
                            mt.receiver_city = response.Trade.ReceiverCity == null ? "" : response.Trade.ReceiverCity;
                            mt.receiver_district = response.Trade.ReceiverDistrict == null ? "" : response.Trade.ReceiverDistrict;
                            mt.receiver_address = response.Trade.ReceiverAddress == null ? "" : response.Trade.ReceiverAddress;
                            mt.receiver_zip = response.Trade.ReceiverZip == null ? "" : response.Trade.ReceiverZip;
                            mt.receiver_mobile = response.Trade.ReceiverMobile == null ? "" : response.Trade.ReceiverMobile;
                            mt.receiver_phone = response.Trade.ReceiverPhone == null ? "" : response.Trade.ReceiverPhone;

                            mt.seller_rate = response.Trade.SellerRate;
                            mt.seller_flag = Convert.ToInt32(response.Trade.SellerFlag);
                            mt.seller_alipay_no = response.Trade.SellerAlipayNo == null ? "" : response.Trade.SellerAlipayNo;
                            mt.seller_mobile = response.Trade.SellerMobile == null ? "" : response.Trade.SellerMobile;
                            mt.seller_phone = response.Trade.SellerPhone == null ? "" : response.Trade.SellerPhone;
                            mt.seller_name = response.Trade.SellerName == null ? "" : response.Trade.SellerName;
                            mt.seller_email = response.Trade.SellerEmail == null ? "" : response.Trade.SellerEmail;
                            
                            mt.buyer_memo = response.Trade.BuyerMemo == null ? "" : response.Trade.BuyerMemo;
                            mt.buyer_email = response.Trade.BuyerEmail == null ? "" : response.Trade.BuyerEmail;
                            mt.buyer_alipay_no = response.Trade.BuyerAlipayNo == null ? "" : response.Trade.BuyerAlipayNo;
                            mt.buyer_flag = Convert.ToInt32(response.Trade.BuyerFlag);
                            mt.buyer_message = response.Trade.BuyerMessage == null ? "" : response.Trade.BuyerMessage;
                            mt.buyer_nick = response.Trade.BuyerNick == null ? "" : response.Trade.BuyerNick;
                            mt.buyer_obtain_point_fee = Convert.ToInt32(response.Trade.BuyerObtainPointFee);
                            mt.buyer_rate = response.Trade.BuyerRate;

                            mt.available_confirm_fee =Convert.ToDecimal( response.Trade.AvailableConfirmFee);
                            mt.has_post_fee = response.Trade.HasPostFee;
                            
                            mt.snapshot_url = response.Trade.SnapshotUrl;
                            mt.cod_fee =Convert.ToDecimal( response.Trade.CodFee);
                            mt.cod_status = response.Trade.CodStatus;
                            mt.shipping_type = response.Trade.ShippingType;
                            mt.trade_memo = response.Trade.TradeMemo;
                            mt.is_3D = response.Trade.Is3D;

                            mt.promotion = response.Trade.Promotion == null ? "" : response.Trade.Promotion;
                            mt.invoice_name = response.Trade.InvoiceName == null ? "" : response.Trade.InvoiceName;
                            mt.timeout_action_time = checkDate(response.Trade.TimeoutActionTime);
                            mt.alipay_no = response.Trade.AlipayNo == null ? "" : response.Trade.AlipayNo;
                            mt.trade_from = response.Trade.TradeFrom == null ? "" : response.Trade.TradeFrom;
                            mt.alipay_url = response.Trade.AlipayUrl == null ? "" : response.Trade.AlipayUrl;

                            int i = 0;
                            //优惠组合
                            if (response.Trade.PromotionDetails != null)
                            {
                                i = 0;
                                if (response.Trade.PromotionDetails.Count > 0)
                                {
                                    mt.promotion_details = new M_OrderPromotionDetailInfo[response.Trade.PromotionDetails.Count];
                                    foreach (PromotionDetail prom in response.Trade.PromotionDetails)
                                    {
                                        mt.promotion_details[i] = new M_OrderPromotionDetailInfo();
                                        mt.promotion_details[i].m_id = prom.Id;
                                        mt.promotion_details[i].promotion_name = prom.PromotionName == null ? "" : prom.PromotionName;
                                        mt.promotion_details[i].discount_fee = Convert.ToDecimal(prom.DiscountFee);
                                        mt.promotion_details[i].gift_item_name = prom.GiftItemName == null ? "" : prom.GiftItemName;
                                        i++;
                                    }
                                }
                            }
                            //订单列表
                            if (response.Trade.Orders != null)
                            {
                                i = 0;
                                if (response.Trade.Orders.Count > 0)
                                {
                                    mt.orders = new M_OrderInfo[response.Trade.Orders.Count];
                                    foreach (Top.Api.Domain.Order order in response.Trade.Orders)
                                    {
                                        mt.orders[i] = new M_OrderInfo();
                                        mt.orders[i].total_fee = Convert.ToDecimal(order.TotalFee);
                                        mt.orders[i].discount_fee = Convert.ToDecimal(order.DiscountFee);
                                        mt.orders[i].adjust_fee = Convert.ToDecimal(order.AdjustFee);
                                        mt.orders[i].sku_id = order.SkuId == null ? "" : order.SkuId;
                                        mt.orders[i].sku_properties_name = order.SkuPropertiesName == null ? "" : order.SkuPropertiesName;
                                        mt.orders[i].item_meal_name = order.ItemMealName == null ? "" : order.ItemMealName;
                                        mt.orders[i].num = Convert.ToInt32(order.Num);
                                        mt.orders[i].title = order.Title == null ? "" : order.Title;
                                        mt.orders[i].price = Convert.ToDecimal(order.Price);
                                        mt.orders[i].pic_path = order.PicPath == null ? "" : order.PicPath;
                                        mt.orders[i].seller_nick = order.SellerNick;
                                        mt.orders[i].buyer_nick = order.BuyerNick;
                                        //mt.orders[i].type = order.SellerType
                                        mt.orders[i].created = checkDate(response.Trade.Created);//交易创建时间
                                        mt.orders[i].refund_status = order.RefundStatus == null ? "" : order.RefundStatus;
                                        mt.orders[i].oid = order.Oid;
                                        mt.orders[i].outer_iid = order.OuterIid == null ? "" : order.OuterIid;

                                        if (mt.orders[i].outer_iid.Trim() == "")
                                        {
                                            M_GoodsInfo _mg = new M_GoodsInfo();
                                            try
                                            {
                                                _mg = M_Utils.GetM_GoodsInfoModelByNum_iid(mc.m_ConfigInfoID, order.NumIid);
                                                if (_mg != null)
                                                {
                                                    mt.orders[i].outer_iid = _mg.ProductsID.ToString();
                                                }
                                            }
                                            finally {
                                                _mg = null;
                                            }
                                        }

                                        mt.orders[i].outer_sku_id = order.OuterSkuId == null ? "" : order.OuterSkuId;
                                        mt.orders[i].payment = Convert.ToDecimal(order.Payment);
                                        mt.orders[i].status = order.Status == null ? "" : order.Status;
                                        mt.orders[i].snapshot_url = order.SnapshotUrl == null ? "" : order.SnapshotUrl;
                                        mt.orders[i].snapshot = order.Snapshot == null ? "" : order.Snapshot;
                                        mt.orders[i].timeout_action_time = checkDate(order.TimeoutActionTime);
                                        mt.orders[i].buyer_rate = order.BuyerRate;
                                        mt.orders[i].seller_rate = order.SellerRate;
                                        mt.orders[i].refund_id = order.RefundId;
                                        mt.orders[i].seller_type = order.SellerType == null ? "" : order.SellerType;
                                        mt.orders[i].modified = checkDate(order.Modified);
                                        mt.orders[i].num_iid = order.NumIid;
                                        //mt.orders[i].item_meal_id = order.i
                                        //mt.orders[i].item_memo = order.i
                                        mt.orders[i].cid = order.Cid;
                                        mt.orders[i].is_oversold = order.IsOversold;
                                        i++;
                                    }
                                }
                            }
                            reValue.reCode = 0;
                            reValue.reObj = mt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">主订单或子订单编号</param>
        /// <param name="close_reason">交易关闭原因</param>
        /// <returns></returns>
        public static PublicReMSG CloseTrade(M_ConfigInfo mc, long tid, string close_reason)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeCloseRequest req = new TradeCloseRequest();
            try
            {
                req.Tid = tid;
                req.CloseReason = close_reason;

                TradeCloseResponse response = new TradeCloseResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trade.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 获取交易确认后的收货费用
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易编号，或子订单编号 </param>
        /// <param name="is_detail">是否是子订单。可选值:IS_FATHER(父订单),IS_CHILD(子订单) </param>
        /// <returns>obj:M_ConfirmFeeInfo</returns>
        public static PublicReMSG GetTradeConfirmFee(M_ConfigInfo mc, long tid, string is_detail)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_ConfirmFeeInfo mcf = new M_ConfirmFeeInfo();

            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeConfirmfeeGetRequest req = new TradeConfirmfeeGetRequest();
            try
            {
                req.Tid = tid;
                req.IsDetail = is_detail;

                TradeConfirmfeeGetResponse response = new TradeConfirmfeeGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.TradeConfirmFee != null)
                        {
                            mcf.confirm_fee = Convert.ToDecimal(response.TradeConfirmFee.ConfirmFee);
                            mcf.confirm_post_fee = Convert.ToDecimal(response.TradeConfirmFee.ConfirmPostFee);
                            reValue.reCode = 0;
                            reValue.reObj = mcf;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        #region 退款
        /// <summary>
        /// 获取退款列表
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="status">
        /// 可选 退款状态，默认查询所有退款状态的数据，除了默认值外每次只能查询一种状态。
        /// WAIT_SELLER_AGREE(买家已经申请退款，等待卖家同意) 
        /// WAIT_BUYER_RETURN_GOODS(卖家已经同意退款，等待买家退货) 
        /// WAIT_SELLER_CONFIRM_GOODS(买家已经退货，等待卖家确认收货) 
        /// SELLER_REFUSE_BUYER(卖家拒绝退款) 
        /// CLOSED(退款关闭) 
        /// SUCCESS(退款成功) 
        /// </param>
        /// <param name="buyer_nick">可选 买家昵称 </param>
        /// <param name="type">
        /// 可选 交易类型列表，一次查询多种类型可用半角逗号分隔，默认同时查询guarantee_trade, auto_delivery的2种类型的数据。 
        /// fixed(一口价) 
        /// auction(拍卖) 
        /// guarantee_trade(一口价、拍卖) 
        /// independent_simple_trade(旺店入门版交易) 
        /// independent_shop_trade(旺店标准版交易) 
        /// auto_delivery(自动发货) 
        /// ec(直冲) 
        /// cod(货到付款) 
        /// fenxiao(分销) 
        /// game_equipment(游戏装备) 
        /// shopex_trade(ShopEX交易) 
        /// netcn_trade(万网交易) 
        /// external_trade(统一外部交易) 
        /// </param>
        /// <param name="bDate">可选 查询修改时间开始</param>
        /// <param name="eDate">可选 查询修改时间结束</param>
        /// <param name="page_no">可选 页码</param>
        /// <param name="page_size">可选 每页条数,最大值:100</param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetRefundsReceiveList(M_ConfigInfo mc, string status, string buyer_nick, string type, string bDate, string eDate, long page_no, long page_size)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            RefundsReceiveGetRequest req = new RefundsReceiveGetRequest();
            try
            {
                dt.Columns.Add("refund_id", System.Type.GetType("System.String"));
                dt.Columns.Add("tid", System.Type.GetType("System.String"));
                dt.Columns.Add("title", System.Type.GetType("System.String"));
                dt.Columns.Add("buyer_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("seller_nick", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("total_fee", System.Type.GetType("System.Int64"));
                dt.Columns.Add("status", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("created", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("refund_fee", System.Type.GetType("System.String"));
                dt.Columns.Add("oid", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("good_status", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("company_name", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("sid", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("payment", System.Type.GetType("System.Decimal"));
                dt.Columns.Add("reason", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("desc", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("has_good_return", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("order_status", System.Type.GetType("System.Int64"));

                req.Fields = "refund_id, tid, title, buyer_nick, seller_nick, total_fee, status, created, refund_fee, oid, good_status, company_name, sid, payment, reason, desc, has_good_return, modified, order_status";
                if (bDate != null)
                {
                    req.StartModified = Convert.ToDateTime(bDate);
                }
                if (eDate != null)
                {
                    req.EndModified = Convert.ToDateTime(eDate);
                }
                if (status != null)
                {
                    req.Status = status;
                }
                if (type != null)
                {
                    req.Type = type;
                }
                if (buyer_nick != null)
                {
                    req.BuyerNick = buyer_nick;
                }
               
                    req.PageNo = page_no;
               
                    req.PageSize = page_size;
                

                RefundsReceiveGetResponse response = new RefundsReceiveGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Refunds.Count > 0)
                        {
                            foreach (Refund rf in response.Refunds)
                            {
                                DataRow dr = dt.NewRow();
                                dr["refund_id"] = rf.RefundId;
                                dr["tid"] = rf.Tid;
                                dr["title"] = rf.Title;
                                dr["buyer_nick"] = rf.BuyerNick;
                                dr["seller_nick"] = rf.SellerNick;
                                dr["total_fee"] = rf.TotalFee;
                                dr["status"] = rf.Status;
                                dr["created"] = checkDate(rf.Created);
                                dr["refund_fee"] = rf.RefundFee;
                                dr["oid"] = rf.Oid;
                                dr["good_status"] = rf.GoodStatus;
                                dr["company_name"] = rf.CompanyName;
                                dr["sid"] = rf.Sid;
                                dr["payment"] = rf.Payment;
                                dr["reason"] = rf.Reason;
                                dr["desc"] = rf.Desc;
                                dr["has_good_return"] = rf.HasGoodReturn;
                                dr["modified"] = checkDate(rf.Modified);
                                dr["order_status"] = rf.OrderStatus;

                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 获取退款单详细信息
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="refund_id">退款单号</param>
        /// <returns>obj:M_OrderRefundInfo</returns>
        public static PublicReMSG GetRefundsReceiveInfo(M_ConfigInfo mc, long refund_id)
        {
            PublicReMSG reValue = new PublicReMSG();
            M_OrderRefundInfo mo = new M_OrderRefundInfo();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            RefundGetRequest req = new RefundGetRequest();
            try
            {
                req.Fields = "refund_id, alipay_no, tid, oid, buyer_nick, seller_nick, total_fee, status, created, refund_fee, good_status, has_good_return, payment, reason, desc, num_iid, title, price, num, good_return_time, company_name, sid, address, shipping_type, refund_remind_timeout";
                req.RefundId = refund_id;

                RefundGetResponse response = new RefundGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Refund != null)
                        {
                            mo.refund_id = response.Refund.RefundId;
                            mo.alipay_no = response.Refund.AlipayNo == null ? "" : response.Refund.AlipayNo;
                            mo.tid = response.Refund.Tid;
                            mo.oid = response.Refund.Oid;
                            mo.buyer_nick = response.Refund.BuyerNick;
                            mo.seller_nick = response.Refund.SellerNick;
                            mo.total_fee = Convert.ToDecimal(response.Refund.TotalFee);
                            mo.status = response.Refund.Status;
                            mo.created = checkDate(response.Refund.Created);
                            mo.refund_fee = Convert.ToDecimal(response.Refund.RefundFee);
                            mo.good_status = response.Refund.GoodStatus;
                            mo.has_good_return = response.Refund.HasGoodReturn;
                            mo.payment = Convert.ToDecimal(response.Refund.Payment);
                            mo.reason = response.Refund.Reason == null ? "" : response.Refund.Reason;
                            mo.m_desc = response.Refund.Desc == null ? "" : response.Refund.Desc;
                            mo.num_iid = response.Refund.NumIid;
                            mo.title = response.Refund.Title == null ? "" : response.Refund.Title;
                            mo.price = Convert.ToDecimal(response.Refund.Price);
                            mo.num = Convert.ToInt32(response.Refund.Num);
                            mo.good_return_time = checkDate(response.Refund.GoodReturnTime);
                            mo.company_name = response.Refund.CompanyName == null ? "" : response.Refund.CompanyName;
                            mo.sid = response.Refund.Sid == null ? "" : response.Refund.Sid;
                            mo.address = response.Refund.Address == null ? "" : response.Refund.Address;
                            mo.shipping_type = response.Refund.ShippingType == null ? "" : response.Refund.ShippingType;
                            if (response.Refund.RefundRemindTimeout != null)
                            {
                                mo.refund_remind_timeout = new M_TimeOutInfo();
                                mo.refund_remind_timeout.remind_type = Convert.ToInt32(response.Refund.RefundRemindTimeout.RemindType);
                                mo.refund_remind_timeout.exist_timeout = response.Refund.RefundRemindTimeout.ExistTimeout;
                                mo.refund_remind_timeout.timeout = checkDate(response.Refund.RefundRemindTimeout.Timeout);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = mo;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Refund";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 拒绝退款
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="refund_id">退款单号 </param>
        /// <param name="refuse_message">拒绝退款时的说明信息，长度2-200</param>
        /// <param name="tid">退款记录对应的交易订单号</param>
        /// <param name="oid">退款记录对应的交易子订单号 </param>
        /// <param name="fileLocation">本地文件绝对地址,拒绝退款时的退款凭证，一般是卖家拒绝退款时使用的发货凭证，最大长度130000字节，支持的图片格式：GIF, JPG, PNG支持的文件类型：gif,jpg,png</param>
        /// <returns></returns>
        public static PublicReMSG SetRefundRefuse(M_ConfigInfo mc, long refund_id, string refuse_message, long tid, long oid, string fileLocation)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            RefundRefuseRequest req = new RefundRefuseRequest();
            try
            {
                req.RefundId = refund_id;
                req.RefuseMessage = refuse_message;
                req.Tid = tid;
                req.Oid = oid;
                if (fileLocation != null)
                {
                    FileItem fItem = new FileItem(fileLocation);
                    req.RefuseProof = fItem;
                }

                RefundRefuseResponse response = new RefundRefuseResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Refund.RefundId > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no RefundId";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 备注
        /// <summary>
        /// 给交易添加备注
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易编号 </param>
        /// <param name="memo">交易备注。最大长度: 1000个字节 </param>
        /// <param name="flag">交易备注旗帜，可选值为：0(灰色), 1(红色), 2(黄色), 3(绿色), 4(蓝色), 5(粉红色)，默认值为0 </param>
        /// <returns></returns>
        public static PublicReMSG AddTradeMemo(M_ConfigInfo mc, long tid, string memo, long flag)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeMemoAddRequest req = new TradeMemoAddRequest();
            try
            {
                req.Tid = tid;
                req.Memo = memo;
                req.Flag = flag;

                TradeMemoAddResponse response = new TradeMemoAddResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trade.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 修改交易备注
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易编号 </param>
        /// <param name="memo">交易备注。最大长度: 1000个字节 </param>
        /// <param name="flag">交易备注旗帜，可选值为：0(灰色), 1(红色), 2(黄色), 3(绿色), 4(蓝色), 5(粉红色)，默认值为0 </param>
        /// <param name="reset">是否对memo的值置空若为true，则不管传入的memo字段的值是否为空，都将会对已有的memo值清空，慎用；若用false，则会根据memo是否为空来修改memo的值：若memo为空则忽略对已有memo字段的修改，若memo非空，则使用新传入的memo覆盖已有的memo的值</param>
        /// <returns></returns>
        public static PublicReMSG UpdateTradeMemo(M_ConfigInfo mc, long tid, string memo, long flag, bool reset)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeMemoUpdateRequest req = new TradeMemoUpdateRequest();
            try
            {
                req.Tid = tid;
                req.Memo = memo;
                req.Flag = flag;
                req.Reset = reset;

                TradeMemoUpdateResponse response = new TradeMemoUpdateResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trade.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改销售属性
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="sku_id"></param>
        /// <param name="sku_props"></param>
        /// <returns></returns>
        public static PublicReMSG UpdateTradeSku(M_ConfigInfo mc, long oid, long sku_id, string sku_props)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeOrderskuUpdateRequest req = new TradeOrderskuUpdateRequest();
            try
            {
                req.Oid = oid;
                req.SkuId = sku_id;
                req.SkuProps = sku_props;

                TradeOrderskuUpdateResponse response = new TradeOrderskuUpdateResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Order.Oid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Oid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 更改交易收货地址
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易编号</param>
        /// <param name="receiver_name">可选 	收货人全名。最大长度为50个字节</param>
        /// <param name="receiver_phone">可选 	固定电话。最大长度为30个字节</param>
        /// <param name="receiver_mobile">可选 	移动电话。最大长度为30个字节</param>
        /// <param name="receiver_state">可选 	省份。最大长度为32个字节</param>
        /// <param name="receiver_city">可选 	城市。最大长度为32个字节</param>
        /// <param name="receiver_district">可选 	区/县。最大长度为32个字节</param>
        /// <param name="receiver_address">可选 	收货地址</param>
        /// <param name="receiver_zip">可选 	邮政编码</param>
        /// <returns></returns>
        public static PublicReMSG UpdateTradeShippingAddress(M_ConfigInfo mc, long tid, string receiver_name, string receiver_phone, string receiver_mobile, string receiver_state, string receiver_city, string receiver_district, string receiver_address, string receiver_zip)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TradeShippingaddressUpdateRequest req = new TradeShippingaddressUpdateRequest();
            try
            {
                req.Tid = tid;
                req.ReceiverName = receiver_name;
                req.ReceiverPhone = receiver_phone;
                req.ReceiverMobile = receiver_mobile;
                req.ReceiverState = receiver_state;
                req.ReceiverCity = receiver_city;
                req.ReceiverDistrict = receiver_district;
                req.ReceiverAddress = receiver_address;
                req.ReceiverZip = receiver_zip;

                TradeShippingaddressUpdateResponse response = new TradeShippingaddressUpdateResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Trade.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #endregion

        #region 平价
        /// <summary>
        /// 添加平价
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易ID </param>
        /// <param name="oid">子订单ID </param>
        /// <param name="result">评价结果,可选值:good(好评),neutral(中评),bad(差评) </param>
        /// <param name="role">评价者角色,可选值:seller(卖家),buyer(买家) </param>
        /// <param name="content">评价内容,最大长度: 500个汉字 .注意：当评价结果为good时就不用输入评价内容.评价内容为neutral/bad的时候需要输入评价内容 </param>
        /// <param name="anony">是否匿名,卖家评不能匿名。可选值:true(匿名),false(非匿名)。注意：输入非可选值将会自动转为false </param>
        /// <returns></returns>
        public static PublicReMSG AddTradeRate(M_ConfigInfo mc, long tid, long oid, string result, string role, string content, bool anony)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TraderateAddRequest req = new TraderateAddRequest();
            try
            {
                req.Tid = tid;
                req.Oid = oid;
                req.Result = result;
                req.Role = role;
                req.Content = content;
                req.Anony = anony;

                TraderateAddResponse response = new TraderateAddResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.TradeRate.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 批量添加平价
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易ID </param>
        /// <param name="oid">可选值 子订单ID </param>
        /// <param name="result">评价结果,可选值:good(好评),neutral(中评),bad(差评) </param>
        /// <param name="role">评价者角色,可选值:seller(卖家),buyer(买家) </param>
        /// <param name="content">评价内容,最大长度: 500个汉字 .注意：当评价结果为good时就不用输入评价内容.评价内容为neutral/bad的时候需要输入评价内容 </param>
        /// <param name="anony">是否匿名,卖家评不能匿名。可选值:true(匿名),false(非匿名)。注意：输入非可选值将会自动转为false </param>
        /// <returns></returns>
        public static PublicReMSG AddTradeRateList(M_ConfigInfo mc, long tid, long oid, string result, string role, string content, bool anony)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            TraderateListAddRequest req = new TraderateListAddRequest();
            try
            {
                req.Tid = tid;
                req.Oid = oid;
                req.Result = result;
                req.Role = role;
                req.Content = content;
                req.Anony = anony;

                TraderateListAddResponse response = new TraderateListAddResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }

                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.TradeRate.Tid > 0)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no Tid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 物流

        /// <summary>
        /// 物流发货
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">交易ID</param>
        /// <param name="order_type">可选 发货类型 
        /// 可选( delivery_needed(物流订单发货),virtual_goods(虚拟物品发货). ) 
        /// 注:选择virtual_goods类型进行发货的话下面的参数可以不需填写。
        /// 如果选择delivery_needed 则company_code,out_sid,seller_name,seller_area_id,seller_address,seller_zip,seller_phone,seller_mobile,memo必须要填写
        /// </param>
        /// <param name="out_sid">可选 运单号 
        /// 具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；
        /// 若company_code中传入的代码非淘宝官方物流合作公司，此处运单号不校验。
        /// 如果orderType为delivery_needed，则必传 
        /// </param>
        /// <param name="company_code">可选 物流公司代码 
        /// 如"POST"就代表中国邮政,"ZJS"就代表宅急送.调用 taobao.logistics.companies.get 获取。
        /// 如传入的代码非淘宝官方物流合作公司，默认是“其他”物流的方式，在淘宝不显示物流具体进度，故传入需谨慎。
        /// 如果orderType为delivery_needed，则必传
        /// </param>
        /// <param name="seller_name">可选 卖家姓名 
        /// 如果orderType为delivery_needed，则必传 
        /// </param>
        /// <param name="seller_area_id">可选 卖家所在地国家公布的标准地区码 
        /// 参考:http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm 或者调用 taobao.areas.get 获取。如果orderType为delivery_needed，则必传 </param>
        /// <param name="seller_address">可选 卖家地址(详细地址). 
        /// 如:XXX街道XXX门牌,省市区不需要提供。如果orderType为delivery_needed，则必传.
        ///校验规则：
        ///1.4-60字符(字母\数字\汉字)
        ///2.不能全部数字
        ///3.不能全部字母
        ///</param>
        /// <param name="seller_zip">可选 卖家邮编 
        /// 如果orderType为delivery_needed，则必传</param>
        /// <param name="seller_phone">可选 卖家固定电话 
        /// 包含区号,电话,分机号,中间用 " – "; 卖家固定电话和卖家手机号码,必须填写一个.
        ///校验规则：
        ///1.字符不能全部相同
        ///2.长度：5-24位
        ///3.只能包含数字和横杠‘-’ </param>
        /// <param name="seller_mobile"> 可选 卖家手机号码 
        /// 必须由8到16位数字构成
        ///校验规则：
        ///1.8-16位数字
        ///2.不能数字全部相同
        ///3.不能全为字符格式</param>
        /// <param name="memo">可选 卖家备注 
        /// 最大长度为250个字符。如果orderType为delivery_needed，则必传 </param>
        public static PublicReMSG DeliverySend(M_ConfigInfo mc, long tid, string out_sid, string company_code, long sender_id, long cancel_id)
        {
            PublicReMSG reValue = new PublicReMSG();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            LogisticsOfflineSendRequest req = new LogisticsOfflineSendRequest();
            try
            {
                req.Tid = tid;
                if (out_sid != null)
                {
                    req.OutSid = out_sid;
                }
                if (company_code != null)
                {
                    req.CompanyCode = company_code;
                }
                if (sender_id > 0)
                {
                    req.SenderId = sender_id;
                }
                if (cancel_id > 0)
                {
                    req.CancelId = cancel_id;
                }


                LogisticsOfflineSendResponse response = new LogisticsOfflineSendResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)//30分钟内SessionKey有效
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Shipping.IsSuccess)
                        {
                            reValue.reCode = 0;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no IsSuccess";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }

        /// <summary>
        /// 批量查询物流订单
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="tid">可选 交易ID </param>
        /// <param name="buyer_nick"> 可选 买家昵称  </param>
        /// <param name="status">可选 物流状态 </param>
        /// <param name="seller_confirm">可选 卖家是否发货 </param>
        /// <param name="receiver_name">可选 收货人姓名 </param>
        /// <param name="start_created">可选 创建时间开始  </param>
        /// <param name="end_created"> 可选 创建时间结束  </param>
        /// <param name="freight_payer"> 可选 谁承担运费 </param>
        /// <param name="type">可选 物流方式 </param>
        /// <param name="page_no">可选 页码 </param>
        /// <param name="page_size">可选 每页条数 </param>
        /// <returns>obj:DataTable</returns>
        public static PublicReMSG GetShippingList(M_ConfigInfo mc, string tid, string buyer_nick, string status, string seller_confirm, string receiver_name, string start_created, string end_created, string freight_payer, string type, long page_no, long page_size)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dt = new DataTable();
            ITopClient client = new DefaultTopClient(mc.m_APIURL, mc.m_AppKey, mc.m_AppSecret);
            LogisticsOrdersGetRequest req = new LogisticsOrdersGetRequest();
            try
            {
                dt.Columns.Add("tid", System.Type.GetType("System.Int64"));
                dt.Columns.Add("seller_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("buyer_nick", System.Type.GetType("System.String"));
                dt.Columns.Add("delivery_start", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("delivery_end", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("out_sid", System.Type.GetType("System.String"));
                dt.Columns.Add("item_title", System.Type.GetType("System.String"));
                dt.Columns.Add("receiver_name", System.Type.GetType("System.String"));
                dt.Columns.Add("created", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("modified", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("status", System.Type.GetType("System.String"));
                dt.Columns.Add("type", System.Type.GetType("System.String"));
                dt.Columns.Add("freight_payer", System.Type.GetType("System.String"));
                dt.Columns.Add("seller_confirm", System.Type.GetType("System.String"));
                dt.Columns.Add("company_name", System.Type.GetType("System.String"));

                req.Fields = "tid,seller_nick,buyer_nick,delivery_start, delivery_end,out_sid,item_title,receiver_name, created,modified,status,type,freight_payer,seller_confirm,company_name";
                if (tid != null)
                {
                    req.Tid =long.Parse( tid);
                }
                if (buyer_nick != null)
                {
                    req.BuyerNick = buyer_nick;
                }
                if (status != null)
                {
                    req.Status = status;
                }
                if (seller_confirm != null)
                {
                    req.SellerConfirm = seller_confirm;
                }
                if (receiver_name != null)
                {
                    req.ReceiverName = receiver_name;
                }
                if (start_created != null)
                {
                    req.StartCreated = Convert.ToDateTime(start_created);
                }
                if (end_created != null)
                {
                    req.EndCreated = Convert.ToDateTime(end_created);
                }
                if (freight_payer != null)
                {
                    req.FreightPayer = freight_payer;
                }
                if (type != null)
                {
                    req.Type = type;
                }

                
                    req.PageNo = page_no;
               
                    req.PageSize = page_size;
                

                LogisticsOrdersGetResponse response = new LogisticsOrdersGetResponse();
                if (DateTime.Now.Subtract(mc.m_UpdateTime).TotalMinutes < 30)
                {
                    response = client.Execute(req, mc.m_SessionKey);
                }
                else
                {
                    response = client.Execute(req);
                }
                if (response != null)
                {
                    if (!response.IsError)
                    {
                        //更新SessionKey使用时间
                        M_Utils.UpdateM_ConfigSessionKeyTime(mc.m_ConfigInfoID);
                        if (response.Shippings.Count > 0)
                        {
                            foreach (Shipping tr in response.Shippings)
                            {
                                DataRow dr = dt.NewRow();
                                dr["tid"] = tr.Tid;
                                dr["seller_nick"] = tr.SellerNick;
                                dr["buyer_nick"] = tr.BuyerNick;
                                dr["delivery_start"] = tr.DeliveryStart;
                                dr["delivery_end"] = tr.DeliveryEnd;
                                dr["out_sid"] = tr.OutSid;
                                dr["item_title"] = tr.ItemTitle;
                                dr["receiver_name"] = tr.ReceiverName;
                                dr["created"] = checkDate(tr.Created);
                                dr["modified"] = checkDate(tr.Modified);
                                dr["status"] = tr.Status;
                                dr["type"] = tr.Type;
                                dr["freight_payer"] = tr.FreightPayer;
                                dr["seller_confirm"] = tr.SellerConfirm;
                                dr["company_name"] = tr.CompanyName;
                                dt.Rows.Add(dr);
                            }
                            reValue.reCode = 0;
                            reValue.reObj = dt;
                        }
                        else
                        {
                            reValue.reCode = 1;
                            reValue.reCodeStr = "no NumIid";
                        }
                    }
                    else
                    {
                        reValue.reCode = 1;
                        reValue.reCodeStr = response.ErrCode;
                        reValue.reMSG = response.ErrMsg;
                        reValue.reM = response.SubErrMsg;
                    }
                }
                else
                {
                    reValue.reCode = 1;
                    reValue.reCodeStr = "no response";
                }
                return reValue;
            }
            finally
            {
                req = null;
                client = null;
            }
        }
        #endregion

        #region 客服
        #endregion

        /// <summary>
        /// 验证时间,并转换
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime checkDate(string dateStr)
        {
            try
            {
                return DateTime.Parse(dateStr);
            }
            catch{
                return Convert.ToDateTime("1984-09-24");
            }
        }
    }
}

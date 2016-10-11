using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class mmembers_do : MPageBase
    {
        public string Act = "";
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public PublicReMSG reValue = new PublicReMSG();
        public string reformat = "";
        public string reVal = "";
        
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                reformat = HTTPRequest.GetString("reformat");
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-4-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }

                    #region 下载会员列表
                    if (Act == "DownLoad")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-4-1"))
                        {
                            if (!ispost)
                            {
                                reValue = TopApiUtils.GetMembers(M_Config, 20, pageindex, null, 0, 0, 0, 0, null);
                                if (reValue.reCode == 0)
                                {
                                    dList = reValue.reObj as DataTable;
                                }
                                else
                                {
                                    //判断是否有Session相关错误
                                    if (reValue.reCodeStr.ToLower().IndexOf("session") > 0)
                                    {
                                        ShowMSign = true;//前台弹出登录授权框
                                    }
                                    AddErrLine("远端错误:" + reValue.reCodeStr + "," + reValue.reMSG);
                                }
                            }
                            else
                            {
                               

                                //更新会员信息
                                string buyer_id = Utils.ChkSQL(HTTPRequest.GetString("buyer_id")).Trim();
                                string buyer_nick = Utils.ChkSQL(HTTPRequest.GetString("buyer_nick")).Trim();
                                string member_grade = Utils.ChkSQL(HTTPRequest.GetString("member_grade")).Trim();
                                decimal trade_amount = decimal.Parse(HTTPRequest.GetString("trade_amount"));
                                decimal trade_count = decimal.Parse(HTTPRequest.GetString("trade_count"));
                                string laste_time = Utils.ChkSQL(HTTPRequest.GetString("laste_time")).Trim();
                                string status = Utils.ChkSQL(HTTPRequest.GetString("status")).Trim();

                                reVal = ",\"ReValue\":{\"buyer_id\":\"" + buyer_id + "\",\"buyer_nick\":\"" + buyer_nick + "\"}";

                                if (buyer_id.Trim() != "" && buyer_nick.Trim() != "")
                                {
                                    M_MemberInfo _mm = new M_MemberInfo();
                                    if (!M_Utils.ExistsM_Member(M_Config.m_ConfigInfoID, buyer_id))
                                    {
                                        _mm.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                        _mm.buyer_id = buyer_id;
                                        
                                        _mm.buyer_nick = buyer_nick;
                                        _mm.member_grade = member_grade;
                                        _mm.trade_amount = trade_amount;
                                        _mm.trade_count = trade_count;
                                        _mm.laste_time = DateTime.Parse(laste_time);
                                        _mm.status = status;

                                        M_Utils.AddM_Member(_mm);
                                    }
                                    else 
                                    {
                                        _mm = M_Utils.GetM_MemberModel(M_Config.m_ConfigInfoID, buyer_id);
                                        if (_mm != null)
                                        {
                                            _mm.buyer_nick = buyer_nick;
                                            _mm.member_grade = member_grade;
                                            _mm.trade_amount = trade_amount;
                                            _mm.trade_count = trade_count;
                                            _mm.laste_time = DateTime.Parse(laste_time);
                                            _mm.status = status;
                                            
                                            M_Utils.UpdateM_Member(_mm);
                                        }
                                        else 
                                        {
                                            AddErrLine("参数错误!");
                                        }
                                    }
                                    //更新会员网店账户信息
                                    reValue = TopApiUtils.GetUserInfo(M_Config, buyer_nick);
                                    if (reValue.reCode == 0)
                                    {
                                        M_UserInfo _mu = reValue.reObj as M_UserInfo;
                                        if (_mu != null)
                                        {
                                            if (!M_Utils.ExistsM_UserInfo(M_Config.m_ConfigInfoID, _mu.user_id, _mu.uid))
                                            {
                                                _mu.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                                _mu.m_AppendTime = DateTime.Now;
                                                _mu.m_UpdateTime = DateTime.Now;
                                                _mu.sex = _mu.sex == null ? "" : _mu.sex;
                                                _mu.auto_repost = _mu.auto_repost == null ? "" : _mu.auto_repost;
                                                _mu.promoted_type = _mu.promoted_type == null ? "" : _mu.promoted_type;
                                                M_Utils.AddM_UserInfo(_mu);
                                            }
                                            else 
                                            {
                                                M_UserInfo _mu_n = new M_UserInfo();
                                                _mu_n = M_Utils.GetM_UserInfoModel(M_Config.m_ConfigInfoID, _mu.user_id, _mu.uid);
                                                if (_mu_n != null)
                                                {
                                                    _mu.sex = _mu.sex == null ? "" : _mu.sex;
                                                    _mu.auto_repost = _mu.auto_repost == null ? "" : _mu.auto_repost;
                                                    _mu.promoted_type = _mu.promoted_type == null ? "" : _mu.promoted_type;
                                                    _mu_n.created = _mu.created;
                                                    _mu_n.last_visit = _mu.last_visit;
                                                    //_mu_n.birthday = _mu.birthday;
                                                    _mu_n.type = _mu.type;
                                                    //_mu_n.has_more_pic = _mu.has_more_pic;
                                                   // _mu_n.item_img_num = _mu.item_img_num;
                                                    //_mu_n.item_img_size = _mu.item_img_size;
                                                    //_mu_n.prop_img_num = _mu.prop_img_num;
                                                    //_mu_n.prop_img_sizec = _mu.prop_img_sizec;
                                                    //_mu_n.auto_repost = _mu.auto_repost;
                                                    //_mu_n.promoted_type = _mu.promoted_type;
                                                    //_mu_n.status = _mu.status;
                                                    _mu_n.alipay_bind = _mu.alipay_bind;
                                                    _mu_n.consumer_protection = _mu.consumer_protection;
                                                    _mu_n.alipay_account = _mu.alipay_account;
                                                    _mu_n.alipay_no = _mu.alipay_no;
                                                    _mu_n.email = _mu.email;
                                                    _mu_n.magazine_subscribe = _mu.magazine_subscribe;
                                                    _mu_n.vertical_market = _mu.vertical_market;
                                                    _mu_n.avatar = _mu.avatar;
                                                    _mu_n.online_gaming = _mu.online_gaming;

                                                    M_Utils.UpdateM_UserInfo(_mu_n);
                                                }
                                                else
                                                {
                                                    AddErrLine("用户信息不存在!");
                                                }
                                            }
                                        }
                                        else 
                                        {
                                            AddErrLine("会员信息获取失败!");
                                        }
                                    }
                                    else {
                                        //判断是否有Session相关错误
                                        if (reValue.reCodeStr.ToLower().IndexOf("session") > 0)
                                        {
                                            ShowMSign = true;//前台弹出登录授权框
                                        }
                                        AddErrLine("远端错误:" + reValue.reCodeStr + "," + reValue.reMSG);
                                    }
                                }
                                else {
                                    AddErrLine("会员编号不能为空!");
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
            if (reformat == "json")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                Response.Expires = 0;

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "application/json";
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + reVal + "}}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 会员管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
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
    public partial class mproduct_do : MPageBase
    {
        public string Act = "";
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public long num_iid = 0;
        public int goodsid = 0;
        public int pid = 0;
        public int mNum = 0;
        public string reformat = "";
        public string reVal = "";
        public M_GoodsInfo mGoods = new M_GoodsInfo();
        public PublicReMSG reValue = new PublicReMSG();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            reformat = HTTPRequest.GetString("reformat");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-1") || CheckUserPopedoms("8-1-2") || CheckUserPopedoms("8-1-3") || CheckUserPopedoms("8-1-4") || CheckUserPopedoms("8-1-2-1") || CheckUserPopedoms("8-1-2-2") || CheckUserPopedoms("8-1-2-3") || CheckUserPopedoms("8-1-2-4") || CheckUserPopedoms("8-1-2-5"))
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

                    if (HTTPRequest.GetString("num_iid") != "")
                    {
                        num_iid = Convert.ToInt64(HTTPRequest.GetString("num_iid").Trim());
                    }

                    pid = HTTPRequest.GetInt("pid", 0);
                    goodsid = HTTPRequest.GetInt("gid", 0);

                    #region 修改
                    if (Act == "Edit")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2"))
                        {                           
                            mGoods = M_Utils.GetM_GoodsInfoModel(goodsid);
                            if (mGoods != null)
                            {
                                if (ispost)
                                {
                                    string cid = HTTPRequest.GetString("cid").Trim() != "" ? HTTPRequest.GetString("cid").Trim() : null;
                                    string props = HTTPRequest.GetString("props").Trim() != "" ? HTTPRequest.GetString("props").Trim() : null;
                                    string num = HTTPRequest.GetString("num").Trim() != "" ? HTTPRequest.GetString("num").Trim() : null;
                                    string price = HTTPRequest.GetString("price").Trim() != "" ? HTTPRequest.GetString("price").Trim() : null;
                                    string title = HTTPRequest.GetString("title").Trim() != "" ? HTTPRequest.GetString("title").Trim() : null;
                                    string desc = HTTPRequest.GetString("desc").Trim() != "" ? HTTPRequest.GetString("desc").Trim() : null;
                                    string location_state = HTTPRequest.GetString("location_state").Trim() != "" ? HTTPRequest.GetString("location_state").Trim() : null;
                                    string location_city = HTTPRequest.GetString("location_city").Trim() != "" ? HTTPRequest.GetString("location_city").Trim() : null;
                                    string post_fee = HTTPRequest.GetString("post_fee").Trim() != "" ? HTTPRequest.GetString("post_fee").Trim() : null;
                                    string express_fee = HTTPRequest.GetString("express_fee").Trim() != "" ? HTTPRequest.GetString("express_fee").Trim() : null;
                                    string ems_fee = HTTPRequest.GetString("ems_fee").Trim() != "" ? HTTPRequest.GetString("ems_fee").Trim() : null;
                                    string list_time = HTTPRequest.GetString("list_time").Trim() != "" ? HTTPRequest.GetString("list_time").Trim() : null;
                                    string increment = HTTPRequest.GetString("increment").Trim() != "" ? HTTPRequest.GetString("increment").Trim() : null;
                                    string stuff_status = HTTPRequest.GetString("stuff_status").Trim() != "" ? HTTPRequest.GetString("stuff_status").Trim() : null;
                                    string auction_point = HTTPRequest.GetString("auction_point").Trim() != "" ? HTTPRequest.GetString("auction_point").Trim() : null;
                                    string property_alias = HTTPRequest.GetString("property_alias").Trim() != "" ? HTTPRequest.GetString("property_alias").Trim() : null;
                                    string input_pids = HTTPRequest.GetString("input_pids").Trim() != "" ? HTTPRequest.GetString("input_pids").Trim() : null;
                                    string sku_quantities = HTTPRequest.GetString("sku_quantities").Trim() != "" ? HTTPRequest.GetString("sku_quantities").Trim() : null;
                                    string sku_prices = HTTPRequest.GetString("sku_prices").Trim() != "" ? HTTPRequest.GetString("sku_prices").Trim() : null;
                                    string sku_properties = HTTPRequest.GetString("sku_properties").Trim() != "" ? HTTPRequest.GetString("sku_properties").Trim() : null;
                                    string postage_id = HTTPRequest.GetString("postage_id").Trim() != "" ? HTTPRequest.GetString("postage_id").Trim() : null;
                                    string outer_id = HTTPRequest.GetString("outer_id").Trim() != "" ? HTTPRequest.GetString("outer_id").Trim() : null;
                                    string product_id = HTTPRequest.GetString("product_id").Trim() != "" ? HTTPRequest.GetString("product_id").Trim() : null;
                                    string auto_fill = HTTPRequest.GetString("auto_fill").Trim() != "" ? HTTPRequest.GetString("auto_fill").Trim() : null;
                                    string sku_outer_ids = HTTPRequest.GetString("sku_outer_ids").Trim() != "" ? HTTPRequest.GetString("sku_outer_ids").Trim() : null;
                                    string is_taobao = HTTPRequest.GetString("is_taobao").Trim() != "" ? HTTPRequest.GetString("is_taobao").Trim() : null;
                                    string is_ex = HTTPRequest.GetString("is_ex").Trim() != "" ? HTTPRequest.GetString("is_ex").Trim() : null;
                                    string is_3D = HTTPRequest.GetString("is_3D").Trim() != "" ? HTTPRequest.GetString("is_3D").Trim() : null;
                                    string is_replace_sku = HTTPRequest.GetString("is_replace_sku").Trim() != "" ? HTTPRequest.GetString("is_replace_sku").Trim() : null;
                                    string input_str = HTTPRequest.GetString("input_str").Trim() != "" ? HTTPRequest.GetString("input_str").Trim() : null;
                                    string lang = HTTPRequest.GetString("lang").Trim() != "" ? HTTPRequest.GetString("lang").Trim() : null;
                                    string has_discount = HTTPRequest.GetString("has_discount").Trim() != "" ? HTTPRequest.GetString("has_discount").Trim() : null;
                                    string has_showcase = HTTPRequest.GetString("has_showcase").Trim() != "" ? HTTPRequest.GetString("has_showcase").Trim() : null;
                                    string approve_status = HTTPRequest.GetString("approve_status").Trim() != "" ? HTTPRequest.GetString("approve_status").Trim() : null;
                                    string freight_payer = HTTPRequest.GetString("freight_payer").Trim() != "" ? HTTPRequest.GetString("freight_payer").Trim() : null;
                                    string valid_thru = HTTPRequest.GetString("valid_thru").Trim() != "" ? HTTPRequest.GetString("valid_thru").Trim() : null;
                                    string has_invoice = HTTPRequest.GetString("has_invoice").Trim() != "" ? HTTPRequest.GetString("has_invoice").Trim() : null;
                                    string has_warranty = HTTPRequest.GetString("has_warranty").Trim() != "" ? HTTPRequest.GetString("has_warranty").Trim() : null;
                                    string after_sale_id = HTTPRequest.GetString("after_sale_id").Trim() != "" ? HTTPRequest.GetString("after_sale_id").Trim() : null;
                                    string sell_promise = HTTPRequest.GetString("sell_promise").Trim() != "" ? HTTPRequest.GetString("sell_promise").Trim() : null;
                                    string fileLocation = HTTPRequest.GetString("fileLocation").Trim() != "" ? HTTPRequest.GetString("fileLocation").Trim() : null;
                                    string seller_cids = HTTPRequest.GetString("seller_cids").Trim() != "" ? HTTPRequest.GetString("seller_cids").Trim() : null;
                                    string postage = HTTPRequest.GetString("postage").Trim() != "" ? HTTPRequest.GetString("postage").Trim() : null;



                                    reValue = TopApiUtils.GoodsUpdate(M_Config, mGoods.num_iid, cid, props, num, price, title, desc,
                                                                                             location_state, location_city, post_fee, express_fee, ems_fee, list_time, increment, fileLocation, stuff_status, auction_point,
                                                                                             property_alias, input_pids, sku_quantities, sku_prices, sku_properties, seller_cids, postage_id, outer_id, product_id,
                                                                                             auto_fill, sku_outer_ids, is_taobao, is_ex, is_3D, is_replace_sku, input_str, lang, has_discount,
                                                                                             has_showcase, approve_status, freight_payer, valid_thru, has_invoice, has_warranty, after_sale_id, sell_promise, postage);


                                    try
                                    {
                                        if (reValue.reCode == 0)
                                        {
                                            reValue = TopApiUtils.GetGoodsInfo(M_Config, M_Config.m_Name, num_iid);
                                            if (reValue.reCode == 0)
                                            {
                                                M_Utils.UpdateM_GoodsInfo(reValue.reObj as M_GoodsInfo);
                                                AddMsgLine("更新成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("本地更新获取远程信息时出错.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                            }

                                        }
                                        else
                                        {
                                            AddErrLine("远程商品未实现更新.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                        }
                                    }
                                    finally
                                    {
                                        reValue = null;
                                    }
                                }
                            }
                            else
                            {
                                AddErrLine("参数错误!");
                            }
                        }
                        else 
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion
                    #region 下载商品列表
                    if (Act == "DownLoad")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-3"))
                        {
                            if (!ispost)
                            {
                                reValue = TopApiUtils.GetGoodsList(M_Config, null, 0, null, pageindex, 100, null, null, null, null);
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

                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";

                                if (num_iid > 0)
                                {
                                    reValue = TopApiUtils.GetGoodsInfo(M_Config, M_Config.m_Name, num_iid);
                                    if (reValue.reCode == 0)
                                    {
                                        M_GoodsInfo mg = reValue.reObj as M_GoodsInfo;
                                        if (mg != null)
                                        {
                                            int m_GoodsID = M_Utils.ExistsM_GoodsInfoAndGetID(M_Config.m_ConfigInfoID, num_iid);
                                            try
                                            {
                                                if (m_GoodsID > 0)
                                                {
                                                    //更新本地数据
                                                    mg.m_GoodsID = m_GoodsID;
                                                    mg.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                                    mg.ProductsID = pid;
                                                    mg.outer_id = pid.ToString();

                                                    M_Utils.UpdateM_GoodsInfo(mg);
                                                }
                                                else
                                                {
                                                    //新建商品数据
                                                    mg.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                                    mg.ProductsID = pid;
                                                    mg.outer_id = pid.ToString();

                                                    M_Utils.AddM_GoodsInfo(mg);
                                                }
                                                
                                                //更新远程商品数据
                                                PublicReMSG _reValue = TopApiUtils.GoodsUpdateOuter_id(M_Config, num_iid, pid.ToString());
                                                try
                                                {
                                                    if (_reValue.reCode == 0)
                                                    {
                                                        AddMsgLine("更新成功!");
                                                    }
                                                    else
                                                    {
                                                        AddErrLine("系统商品已更新,但远程商品未实现更新.Error:" + _reValue.reCodeStr + ":" + _reValue.reMSG);
                                                    }
                                                }
                                                finally
                                                {
                                                    _reValue = null;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                AddErrLine("系统错误:" + ex.Message);
                                            }
                                        }
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
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 删除商品
                    if (Act == "Delt")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-1"))
                        {
                            if (ispost)
                            {
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                reValue = TopApiUtils.GoodsDelete(M_Config, num_iid);
                                try
                                {
                                    if (reValue.reCode == 0)
                                    {
                                        mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID, num_iid);
                                        try
                                        {
                                            if (mGoods != null)
                                            {
                                                M_Utils.DeleteM_GoodsInfoNOTrue(mGoods.m_GoodsID);
                                                AddMsgLine("删除成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("远程已更新,但本系统未能更新!");
                                            }
                                        }
                                        finally {
                                            mGoods = null;
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("远程商品未实现删除.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                    }
                                }
                                finally
                                {
                                    reValue = null;
                                }
                            }
                        }else{
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 上架
                    if (Act == "UpList")
                    {
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-2"))
                        {
                            if (ispost)
                            {
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID, num_iid);
                                try
                                {
                                    reValue = TopApiUtils.GoodsListing(M_Config, num_iid, mGoods.num);
                                    if (reValue.reCode == 0)
                                    {
                                        M_Utils.ListingM_Goods(mGoods.m_GoodsID);
                                        AddMsgLine("上架成功!");
                                    }
                                    else
                                    {
                                        AddErrLine("远程商品未实现上架.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                    }
                                }
                                finally
                                {
                                    mGoods = null;
                                    reValue = null;
                                }
                            }
                        }else{
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 下架
                    if (Act == "DownList")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-3"))
                        {
                            if (ispost)
                            {
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                reValue = TopApiUtils.GoodsDelisting(M_Config, num_iid);
                                try
                                {
                                    if (reValue.reCode == 0)
                                    {
                                        mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID, num_iid);
                                        try
                                        {
                                            if (mGoods != null)
                                            {
                                                M_Utils.DelistingM_Goods(mGoods.m_GoodsID);
                                                AddMsgLine("下架成功!");
                                            }
                                            else 
                                            {
                                                AddErrLine("远程已更新,但本系统未能更新!");
                                            }
                                        }
                                        finally
                                        {
                                            mGoods = null;
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("远程商品未实现下架.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                    }
                                }
                                finally
                                {
                                    reValue = null;
                                }
                            }
                        }else{
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 橱窗推荐
                    if (Act == "Recommend")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-5"))
                        {
                            if (ispost)
                            {
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                reValue = TopApiUtils.GoodsRecommendAdd(M_Config, num_iid);
                                try
                                {
                                    if (reValue.reCode == 0)
                                    {
                                        mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID, num_iid);
                                        try
                                        {
                                            if (mGoods != null)
                                            {
                                                M_Utils.RecommendAddM_Goods(mGoods.m_GoodsID);
                                                AddMsgLine("推荐成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("远程已更新,但本系统未能更新!");
                                            }
                                        }
                                        finally
                                        {
                                            mGoods = null;
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("远程商品未实现推荐.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                    }
                                }
                                finally
                                {
                                    reValue = null;
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion
                    #region 取消橱窗推荐
                    if (Act == "NORecommend")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-5"))
                        {
                            if (ispost)
                            {
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                reValue = TopApiUtils.GoodsRecommendDelete(M_Config, num_iid);
                                try
                                {
                                    if (reValue.reCode == 0)
                                    {
                                        mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID, num_iid);
                                        try
                                        {
                                            if (mGoods != null)
                                            {
                                                M_Utils.RecommendDeleteM_Goods(mGoods.m_GoodsID);
                                                AddMsgLine("推荐成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("远程已更新,但本系统未能更新!");
                                            }
                                        }
                                        finally
                                        {
                                            mGoods = null;
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("远程商品未实现取消推荐.Error:" + reValue.reCodeStr + ":" + reValue.reMSG);
                                    }
                                }
                                finally
                                {
                                    reValue = null;
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion
                    #region  更新数量
                    if (Act == "UpdateNum")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-2-4"))
                        {
                            if (!ispost)
                            {
                                dList = M_Utils.GetM_GoodsStockList(M_Config.m_ConfigInfoID);
                            }
                            else
                            {
                                mNum = HTTPRequest.GetInt("num", 0);
                                reVal = ",\"ReValue\":{\"num_iid\":\"" + num_iid + "\",\"pid\":\"" + pid + "\"}";
                                try
                                {
                                    if (num_iid > 0)
                                    {
                                        PublicReMSG _reValue = TopApiUtils.GoodsUpdateNum(M_Config, num_iid, mNum.ToString());
                                        try
                                        {
                                            if (_reValue.reCode == 0)
                                            {
                                                AddMsgLine("更新成功!");
                                            }
                                            else
                                            {
                                                AddErrLine("但远程商品未实现更新.Error:" + _reValue.reCodeStr + ":" + _reValue.reMSG);
                                            }
                                        }
                                        finally
                                        {
                                            _reValue = null;
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("系统错误:" + ex.Message);
                                }
                            }
                        }else{
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
            pagetitle = " 网店商品列表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
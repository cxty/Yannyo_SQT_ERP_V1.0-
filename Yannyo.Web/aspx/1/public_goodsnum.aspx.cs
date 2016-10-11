using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class public_goodsnum : PageBase
    {
        public string objstr = "";
        public int pid = 0;
        public string num_iid = "";
        public DataTable dList = new DataTable();
        public M_GoodsInfo mGoods = new M_GoodsInfo();
        public ProductsInfo mProducts = new ProductsInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                objstr = HTTPRequest.GetString("obj");
                pid = HTTPRequest.GetInt("pid",0);
                num_iid = Utils.ChkSQL(HTTPRequest.GetString("num_iid"));
                if (pid > 0 && num_iid.Trim() != "")
                {
                    mProducts = tbProductsInfo.GetProductsInfoModel(pid); 
                    mGoods = M_Utils.GetM_GoodsInfoModelByNum_iid(M_Config.m_ConfigInfoID,long.Parse(num_iid));
                    if (mGoods != null)
                    {
                        if (!ispost)
                        {
                            dList = M_Utils.GetM_GoodsStockList(M_Config.m_ConfigInfoID, mGoods.m_GoodsID);
                        }
                        else 
                        {
                            int m_count = HTTPRequest.GetInt("m_count", 0);
                            int StorageID = 0;
                            int num = 0;
                            int sum_num = 0;
                            try
                            {
                                if (m_count > 0)
                                {
                                    for (int i = 0; i < m_count; i++)
                                    {
                                        StorageID = HTTPRequest.GetInt("m_StorageID_" + (i+1), 0);
                                        num = HTTPRequest.GetInt("num_" + (i+1), 0);
                                        sum_num += num;
                                        M_Utils.UpdateM_GoodsStockNum(M_Config.m_ConfigInfoID, pid, num, StorageID);
                                    }
                                    //更新商品总数量字段
                                    M_Utils.UpdateM_GoodsNum(M_Config.m_ConfigInfoID, long.Parse(num_iid), sum_num);
                                }
                                AddMsgLine("更新成功!");
                                AddScript("window.setTimeout('window.parent.ReCall({\"sobj\":\"" + objstr + "\",\"num\":\"" + sum_num + "\"});window.parent.HidBox();',1000);");
                            }catch(Exception ex){
                                AddErrLine("系统错误:"+ex.Message);
                            }
                        }
                    }
                    else 
                    {
                        AddErrLine("参数错误!");
                    }
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 商品数量";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
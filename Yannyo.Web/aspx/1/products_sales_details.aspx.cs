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
    public partial class products_sales_details : PageBase
    {
        public DataTable mList = new DataTable();
        public DateTime bDate = DateTime.Now;
        public int SalesType = 0;
        public string sTjson="";
        public string Act = "";
        public string regionJson = "";//区域分类
        public string regionID = "";//选择的区域编号
        public string customerJson = "";//客户分类
        public string productJson = "";//商品分类

        public string mDate="";//页面显示日期
        public int unit = 0;//单位
        public DataSet ds = new DataSet();
        public int jcount=0;//处理json
        public string doValue = "";
        public string Json_Str = "";
        public bool ReJson = false;
        public int sType;//查询类型
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-1-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    string arrayTime = "";
                    string arrayMoney = "";
                    //重新组合
                    string _arrayTime = "";
                    string _arrayMoney = "";
                    string sName="";//选择的名称
                    
                    sName=HTTPRequest.GetString("sName");
                    regionID = HTTPRequest.GetString("regionID");
                    sType = HTTPRequest.GetInt("sType", 0);
                    SalesType = HTTPRequest.GetInt("SalesType", 0);
                    bDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("bDate"))) : DateTime.Now;
                    if (SalesType == 0)
                    {
                        mDate = "[日期：" + bDate.ToString("yyyy年MM月") + "]";
                        unit = 0;
                    }
                    else
                    {
                        mDate = "[日期：" + bDate.ToString("yyyy年") + "]";
                        unit = 1;
                    }
                    if (ispost)
                    {

                        if (regionID == "")
                        {
                            //0.如果木有选择区域或客户
                            mList = tbProductsInfo.getProductsSaleDetails(SalesType, 0, bDate, "", sType);
                        }
                        else
                        {
                            string[] regionArrary = regionID.Split(',');
                            bool region_child=false;
                            string regionChildrenNode="";
                            for (int i = 0; i < regionArrary.Length - 1; i++)
                            {
                                //1.是否存在子节点
                                if (sType == 0)
                                {
                                    region_child = DataClass.ExistsRegionClassChild(Convert.ToInt32(regionArrary[i]));
                                }
                                if (sType == 1)
                                {
                                    region_child = DataClass.ExistsCustomersClassChild(Convert.ToInt32(regionArrary[i]));
                                }
                                if (sType == 2)
                                {
                                    region_child = DataClass.ExistsProductClassChild(Convert.ToInt32(regionArrary[i]));
                                }

                                if (region_child)
                                {
                                    //2.寻找子节点
                                    if (sType == 0)
                                    {
                                         regionChildrenNode = tbRegionInfo.getRegionChildrenCount(regionArrary[i]);
                                    }
                                    if (sType == 1)
                                    {
                                        regionChildrenNode = DataClass.getCustormChildrenCount(regionArrary[i]);
                                    }
                                    if (sType == 2)
                                    {
                                        regionChildrenNode = DataClass.getProductsChildrenCount(regionArrary[i]);
                                    }
                                    regionChildrenNode = regionChildrenNode.Substring(0, regionChildrenNode.Length - 1);
                                    //3.找到各个子节点下得数据
                                    DataTable listNode = tbProductsInfo.getProductsSaleDetails(SalesType, 0, bDate, regionChildrenNode, sType);
                                    //4.将找到的每次循环的值保存到dataset中
                                    DataTable dtd = listNode.Copy();
                                    dtd.TableName = "l_" + i;
                                    ds.Tables.Add(dtd);
                                }
                                else
                                {
                                    //5.如果木有子节点
                                    DataTable list = tbProductsInfo.getProductsSaleDetails(SalesType, 0, bDate, regionArrary[i].ToString(), sType);
                                    //5.1 将找到的每次循环的值保存到dataset中
                                    DataTable dtd = list.Copy();
                                    dtd.TableName = "m_" + i;
                                    ds.Tables.Add(dtd);
                                }
                            }
                        }
                        //6.如果木有选择区域
                        if (mList.Rows.Count > 0)
                        {
                            for (int i = 0; i < mList.Rows.Count; i++)
                            {
                                if (SalesType == 0)
                                {
                                    arrayTime += Convert.ToDateTime(mList.Rows[i]["searchTime"].ToString()).ToString("dd") + ",";
                                }
                                if (SalesType == 1)
                                {
                                    arrayTime += Convert.ToDateTime(mList.Rows[i]["searchTime"].ToString()).ToString("MM") + ",";
                                }
                                //dataDetails:销售金额总量；moneyDetails：销售金额百分比

                                if (sType == 2)
                                {
                                    arrayMoney += "{name:'<b>总金额</b>：" + decimal.Round(decimal.Parse(mList.Rows[i]["moneyDetails"].ToString()), 2) + "，总数量',y:" + decimal.Round(decimal.Parse(mList.Rows[i]["dataDetails"].ToString()), 2) + "},";
                                }
                                else
                                {
                                    arrayMoney += "{name:'<b>总金额</b>',y:" + decimal.Round(decimal.Parse(mList.Rows[i]["dataDetails"].ToString()), 2) + "},";
                                }
                            }
                            arrayTime = arrayTime.Substring(0, arrayTime.Length - 1);
                            arrayMoney = "{name:'全部'," + "data:[" + arrayMoney + "]}";
                        }
                        else
                        {
                            string[] spName=sName.Split('：');
                            //7.如果选择了区域
                            if (ds.Tables.Count > 0)
                            {
                                //7.1 循环dataset中的table
                                for (int m = 0; m < ds.Tables.Count; m++)
                                {
                                    _arrayTime = "";
                                    arrayMoney = "";
                                    //7.2循环每个table中得行
                                    for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                    {
                                        if (SalesType == 0)
                                        {
                                            _arrayTime += Convert.ToDateTime(ds.Tables[m].Rows[n]["searchTime"].ToString()).ToString("dd") + ",";
                                        }
                                        if (SalesType == 1)
                                        {
                                            _arrayTime += Convert.ToDateTime(ds.Tables[m].Rows[n]["searchTime"].ToString()).ToString("MM") + ",";
                                        }
                                        if (sType == 2)
                                        {
                                            arrayMoney += "{name:'<b>总金额</b>" + decimal.Round(decimal.Parse(ds.Tables[m].Rows[n]["moneyDetails"].ToString()), 2) + "<b>，总数量</b>',y:" + decimal.Round(decimal.Parse(ds.Tables[m].Rows[n]["dataDetails"].ToString()), 2) + "},";
                                        }
                                        else
                                        {
                                            arrayMoney += "{name:'<b>总金额</b>',y:" + decimal.Round(decimal.Parse(ds.Tables[m].Rows[n]["dataDetails"].ToString()), 2) + "},";
                                        }
                                    }
                                    
                                    _arrayMoney += "{name:'" + spName[m] + "'," + "data:[" + arrayMoney + "]},";
                                    arrayTime = _arrayTime.Substring(0, _arrayTime.Length - 1);
                                    jcount++;
                                }
                                arrayMoney = _arrayMoney.Substring(0, _arrayMoney.Length - 1);
                            }
                        }


                        sTjson = "cDetails:{'time':'" + arrayTime + "','salesMoney':[" + arrayMoney + "],'SalesType':'" + SalesType + "','jcount':" + jcount + ",'mDate':'" + mDate + "','unit':" + unit + "}";
                        if (Act.IndexOf("go") > -1)
                        {
                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            //Response.ContentType = "application/json";
                            Response.Clear();
                            Response.Write("{" + sTjson + "}");
                            Response.End();
                        }

                    }
                    else
                    {
                        doValue = HTTPRequest.GetQueryString("doValue").ToString();
                        string getClickStr = "";
                        getClickStr = HTTPRequest.GetString("pid");
                        if (getClickStr != "-1")
                        {
                            string[] getClickStrArray = getClickStr.Split(',');
                            for (int i = 0; i < getClickStrArray.Length; i++)
                            {
                                getClickStr = getClickStrArray[0].ToString();
                            }
                        }
                        if (doValue != "")
                        {
                            ReJson = true;
                            switch (doValue)
                            {
                                case "region":
                                    
                                    regionJson = Caches.GetRegionInfoToJson(Convert.ToInt32(getClickStr), false, true);//区域树
                                    Json_Str = "[" + regionJson + "]";
                                    break;
                                case"custorm":
                                    customerJson = Caches.GetCustomersInfoToJson(Convert.ToInt32(getClickStr), true, true);//客户树
                                    Json_Str = "[" + customerJson + "]";
                                    break;
                                case"product":
                                    productJson = Caches.GetProductsInfoToJson(Convert.ToInt32(getClickStr), true, true);
                                    Json_Str = "[" + productJson + "]";
                                    break;
                            }
                        }
                        if (Json_Str == "")
                        {
                            Json_Str = "{\"results\": []}";
                        }
                        if (ReJson)
                        {
                            Response.Write(Json_Str);
                            Response.End();
                        }
                    }

                }
                else
                {
                    AddErrLine("权限不足!");
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
            pagetitle = "商品销量图表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
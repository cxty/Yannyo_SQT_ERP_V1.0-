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
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
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
    public partial class cost_details_storehouse : PageBase
    {
        public DataTable sList = new DataTable();
        public DataSet sDateSet = new DataSet();
        public int storesID;                   //门店编号
        public int selectID;                   //借贷类型:0=借；1=贷
        public DateTime bDate = DateTime.Now;  //开始日期
        public DateTime eDate = DateTime.Now;  //结束日期
        public string sName;                   //门店名称
        public string sType;                   //门店类型
        public string kList;                   //科目类型
        public string treeChildren;            //子节点
        public string dataclass;
        public int c_count=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-3-8"))
                {
                    storesID = HTTPRequest.GetInt("sid", 0);
                    selectID = HTTPRequest.GetInt("aid", 0);
                    bDate = Convert.ToDateTime(HTTPRequest.GetString("bDate"));
                    eDate = Convert.ToDateTime(HTTPRequest.GetString("eDate"));
                    sName = HTTPRequest.GetString("sName");
                    sType = HTTPRequest.GetString("sType");

                    kList = HTTPRequest.GetString("kID");
                    string[] kList_Arrary = kList.Split(',');
                    for (int i = 0; i < kList_Arrary.Length - 1; i++)
                    {
                        //判断是否有子节点
                        bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(kList_Arrary[i]));
                        if (tl)
                        {
                            dataclass = CostDetails.getTreeChildrenCount(kList_Arrary[i]);
                            string[] dclass = dataclass.Split(',');
                            for (int j = 0; j < dclass.Length - 1; j++)
                            {
                                sList = CostDetails.getCostOfStorehouseDetails(selectID, storesID, dclass[j].ToString(), bDate, eDate);
                                DataTable dt = sList.Copy();
                                dt.TableName = "p" + j + c_count;
                                sDateSet.Tables.Add(dt);
                                c_count++;
                            }
                        }
                        else
                        {
                            sList = CostDetails.getCostOfStorehouseDetails(selectID, storesID, kList_Arrary[i], bDate, eDate);
                            DataTable dt = sList.Copy();
                            dt.TableName = "f" + i + c_count;
                            sDateSet.Tables.Add(dt);
                            c_count++;
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
            pagetitle = " 门店费用详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
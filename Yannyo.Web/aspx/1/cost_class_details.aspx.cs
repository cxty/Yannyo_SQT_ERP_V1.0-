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
    public partial class cost_class_details : PageBase
    {
        public DataTable cList = new DataTable();
        public int selectID;                   //借贷类型:0=借；1=贷
        public DateTime bDate = DateTime.Now;  //开始日期
        public DateTime eDate = DateTime.Now;  //结束日期
        public string className;               //科目名称
        public int kID;                        //科目编号
        public string dataclass;
        public int c_count=0;
        public DataSet rDateSet = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-3-8"))
                {
                    selectID = HTTPRequest.GetInt("aid", 0);
                    bDate = Convert.ToDateTime(HTTPRequest.GetString("bDate"));
                    eDate = Convert.ToDateTime(HTTPRequest.GetString("eDate"));
                    className = HTTPRequest.GetString("className");
                    kID = HTTPRequest.GetInt("kID", 0);
                    //判断是否有子节点
                    bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(kID));
                    if (tl)
                    {
                        dataclass = CostDetails.getTreeChildrenCount(kID.ToString());
                        string[] dclass = dataclass.Split(',');
                        for (int j = 0; j < dclass.Length - 1; j++)
                        {
                            cList = CostDetails.getCostOfClassDetails(selectID, bDate, eDate,Convert.ToInt32(dclass[j].ToString()));

                            DataTable rt = cList.Copy();
                            rt.TableName = "o_" + j + c_count;
                            rDateSet.Tables.Add(rt);
                            c_count = c_count + 1;
                        }
                    }
                    else
                    {
                        cList = CostDetails.getCostOfClassDetails(selectID, bDate, eDate, kID);

                        DataTable rt = cList.Copy();
                        rt.TableName = "o_" +  c_count;
                        rDateSet.Tables.Add(rt);
                        c_count = c_count + 1;
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
            pagetitle = " 科目费用详情";
            this.Load += new EventHandler(this.Page_Load);
        }

    }
}
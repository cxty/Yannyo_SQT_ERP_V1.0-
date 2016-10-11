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
    public partial class cost_details_staff : PageBase
    {
        public DataTable sList = new DataTable();
        public DataTable newTable = new DataTable();
        public int selectID;                   //借贷类型:0=借；1=贷
        public DateTime bDate = DateTime.Now;  //开始日期
        public DateTime eDate = DateTime.Now;  //结束日期
        public string staffName;               //业务员名称
        public int staffID;                    //业务员编号
        public string treeNode;                //科目编号
        public string dataclass;
        public int c_count=0;
        public DataSet sDateSet = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-3-8"))
                {
                    selectID = HTTPRequest.GetInt("aid", 0);
                    bDate = Convert.ToDateTime(HTTPRequest.GetString("bDate"));
                    eDate = Convert.ToDateTime(HTTPRequest.GetString("eDate"));
                    staffName = HTTPRequest.GetString("staffName");
                    staffID = HTTPRequest.GetInt("staffID", 0);
                    treeNode = HTTPRequest.GetString("kID");

                    string[] kList_Arrary = treeNode.Split(',');
                    for (int i = 0; i < kList_Arrary.Length - 1; i++)
                    {
                        //判断是否有子节点
                        bool tl = DataClass.ExistsFeesSubjectClassChild(Convert.ToInt32(kList_Arrary[i]));
                        if(tl)
                        {
                            dataclass = CostDetails.getTreeChildrenCount(kList_Arrary[i]);
                            string[] dclass = dataclass.Split(',');
                            for (int j = 0; j < dclass.Length - 1; j++)
                            {
                                sList = CostDetails.getCostOfStaffDetails(selectID, bDate, eDate, staffID, dclass[j].ToString());

                                DataTable dt = sList.Copy();
                                dt.TableName = "p" + j + c_count;
                                sDateSet.Tables.Add(dt);
                                c_count++;
                            }
                        }
                        else
                        {
                            sList = CostDetails.getCostOfStaffDetails(selectID, bDate, eDate, staffID, kList_Arrary[i].ToString());
                            DataTable dt = sList.Copy();
                            dt.TableName = "f" + i + c_count;
                            sDateSet.Tables.Add(dt);
                            c_count++;
                        }
                    }
                    //把dataset中的datatable合并到一张表中
                    newTable = sDateSet.Tables[0].Clone();//创建新表 克隆以有表的架构
                    object[] objArray = new object[newTable.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                    for (int m = 0; m < sDateSet.Tables.Count; m++)
                    {
                        if (sDateSet.Tables[m].Rows.Count > 0)
                        {
                            for (int n = 0; n < sDateSet.Tables[m].Rows.Count; n++)
                            {
                                sDateSet.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                newTable.Rows.Add(objArray); //将数组的值添加到新表中
                            }
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
            pagetitle = " 业务员费用详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
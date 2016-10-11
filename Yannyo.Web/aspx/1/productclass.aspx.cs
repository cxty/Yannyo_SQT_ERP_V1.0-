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
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class productclass : PageBase
    {
        public DataTable pclass = new DataTable();
        public DataTable pParent = new DataTable();
        public string ProductClassInfoParent = "";       //父节点
        public int cParentID;                            //上级节点

        public string className = "";                    //分类名称
        public int classID = 0;                          //分类编号
        public string sTjson;

        public string Act = "";                         //获得操作步骤

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-1"))
                {
					className = Utils.ChkSQL(HTTPRequest.GetString("className"));
                    classID = HTTPRequest.GetInt("classID", -1);
                    Act = HTTPRequest.GetString("Act");
                    Caches.ReSet();
                    pclass = DataClass.GetProductClassDetails(classID);
                    if (ispost)
                    {
                        if (Act.IndexOf("getNode") > -1)
                        {
                            string pid = "";
                            string pName = "";
                            string pOrder = "";
                            string pTime = "";
                            string pRarentID = "";
                            string pRarentName = "";
                            //当选择到节点是统计到该节点及子节点
                            if (classID > -1)
                            {
                                if (pclass.Rows.Count > 0)
                                {
                                    for (int i = 0; i < pclass.Rows.Count; i++)
                                    {
                                        pid += pclass.Rows[i]["ProductClassID"].ToString() + ",";
                                        pName += pclass.Rows[i]["pClassName"].ToString() + ",";
                                        pOrder += pclass.Rows[i]["pOrder"].ToString() + ",";
                                        pTime += pclass.Rows[i]["pAppendTime"].ToString() + ",";
                                        pRarentID = pclass.Rows[i]["pParentID"].ToString();
                                    }
                                    pid = pid.Substring(0, pid.Length - 1);
                                    pName = pName.Substring(0, pName.Length - 1);
                                    pOrder = pOrder.Substring(0, pOrder.Length - 1);
                                    pTime = pTime.Substring(0, pTime.Length - 1);
                                }
                                sTjson = "cDetails:{'pid':'" + pid + "','pname':'" + pName + "','porder':'" + pOrder + "','ptime':'" + pTime + "','parentID':'" + pRarentID + "'}";
                                Response.Write("{" + sTjson + "}");
                                Response.End();
                            }
                            else
                            {
                                if (pclass.Rows.Count > 0)
                                {
                                    DataView dwv = new DataView(pclass);
                                    dwv.Sort = "pParentID";
                                    pclass = dwv.ToTable(true, "pParentID");
                                    DataTable dt = new DataTable();
                                    DataSet ds = new DataSet();

                                    for (int j = 0; j < pclass.Rows.Count; j++)
                                    {
                                        DataTable dtParent = DataClass.getProductsClassList(Convert.ToInt32(pclass.Rows[j]["pParentID"].ToString()));
                                        dt = dtParent.Copy();
                                        dt.TableName = "td_" + j;
                                        ds.Tables.Add(dt);
                                    }
                                    pParent = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                                    object[] objArray = new object[pParent.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                                    for (int m = 0; m < ds.Tables.Count; m++)
                                    {
                                        if (ds.Tables[m].Rows.Count > 0)
                                        {
                                            for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                            {
                                                ds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                                pParent.Rows.Add(objArray); //将数组的值添加到新表中
                                            }
                                        }
                                    }
                                    for (int i = 0; i < pParent.Rows.Count; i++)
                                    {
                                        pid += pParent.Rows[i]["ProductClassID"].ToString() + ",";
                                        pName += pParent.Rows[i]["pClassName"].ToString() + ",";
                                        pOrder += pParent.Rows[i]["pOrder"].ToString() + ",";
                                        pTime += pParent.Rows[i]["pAppendTime"].ToString() + ",";
                                        pRarentID = pParent.Rows[i]["pParentID"].ToString();
                                        pRarentName += pParent.Rows[i]["parentName"].ToString() + ",";
                                    }
                                    pid = pid.Substring(0, pid.Length - 1);
                                    pName = pName.Substring(0, pName.Length - 1);
                                    pOrder = pOrder.Substring(0, pOrder.Length - 1);
                                    pTime = pTime.Substring(0, pTime.Length - 1);
                                    pRarentName = pRarentName.Substring(0, pRarentName.Length - 1);
                                }
                                sTjson = "cDetails:{'pid':'" + pid + "','pname':'" + pName + "','porder':'" + pOrder + "','ptime':'" + pTime + "','parentID':'" + pRarentID + "','parentName':'" + pRarentName + "'}";
                                Response.Write("{" + sTjson + "}");
                                Response.End();
                            }
                        }
                        if (Act.IndexOf("del") > -1)
                        {
                            string trNode = HTTPRequest.GetString("trNode");
                            int count = 0;

                            if (trNode != "")
                            {
                                if (trNode.IndexOf(",") > -1)
                                {
                                    string[] trNodeBits = trNode.Split(',');
                                    for (int i = 0; i < trNodeBits.Length - 1; i++)
                                    {
                                        count = DataClass.DeleteProductClassInfo(Convert.ToInt32(trNodeBits[i].ToString()));
                                    }
                                }
                                else
                                {
                                    count = DataClass.DeleteProductClassInfo(Convert.ToInt32(trNode));
                                }
                                if (count > 0)
                                {
                                    //记录删除商品
                                    Logs.AddEventLog(this.userid, "删除" + trNode + "商品分类");
                                    Response.Write("1");
                                    Response.End();
                                }
                                else
                                {
                                    Response.Write("0");
                                    Response.End();
                                }
                            }
                            else
                            {
                                Response.Write("-1");
                                Response.End();
                            }
                           
                        }
                        
                    }
                    else
                    {
                        if (pclass.Rows.Count > 0)
                        {
                            DataView dwv = new DataView(pclass);
                            dwv.Sort = "pParentID";
                            pclass = dwv.ToTable(true, "pParentID");
                            DataTable dt = new DataTable();
                            DataSet ds = new DataSet();

                            for (int j = 0; j < pclass.Rows.Count; j++)
                            {
                                DataTable dtParent = DataClass.getProductsClassList(Convert.ToInt32(pclass.Rows[j]["pParentID"].ToString()));
                                dt = dtParent.Copy();
                                dt.TableName = "td_" + j;
                                ds.Tables.Add(dt);
                            }
                            pParent = ds.Tables[0].Clone();//创建新表 克隆以有表的架构
                            object[] objArray = new object[pParent.Columns.Count]; //定义与表列数相同的对象数组 存放表的一行的值
                            for (int m = 0; m < ds.Tables.Count; m++)
                            {
                                if (ds.Tables[m].Rows.Count > 0)
                                {
                                    for (int n = 0; n < ds.Tables[m].Rows.Count; n++)
                                    {
                                        ds.Tables[m].Rows[n].ItemArray.CopyTo(objArray, 0); //将表的一行的值存放数组中
                                        pParent.Rows.Add(objArray); //将数组的值添加到新表中
                                    }
                                }
                            }
                        }
                    }
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
        }
        protected override void ShowPage()
        {
            pagetitle = " 产品分类信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
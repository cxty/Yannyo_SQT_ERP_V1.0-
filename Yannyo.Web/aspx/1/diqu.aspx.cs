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
    public partial class diqu : PageBase
    {
        public DataTable pclass = new DataTable();
        public DataTable pParent = new DataTable();
        public string ProductClassInfoParent = "";       //父节点
        public int rUpID;                            //上级节点

        public string className = "";                    //分类名称
        public int classID = 0;                          //分类编号
        public string sTjson;

        public string Act = "";                         //获得操作步骤
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-5"))
                {
                    className = HTTPRequest.GetString("className");
                    classID = HTTPRequest.GetInt("classID", -1);
                    Act = HTTPRequest.GetString("Act");
                    Caches.ReSet();
                    //1.获得地区分类详情
                    pclass = tbRegionInfo.GetAreaDetails(classID);

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
                                        //2.获得表字段组成字符串
                                        pid += pclass.Rows[i]["RegionID"].ToString() + ",";
                                        pName += pclass.Rows[i]["rName"].ToString() + ",";
                                        pOrder += pclass.Rows[i]["rOrder"].ToString() + ",";
                                        pTime += pclass.Rows[i]["rAppendTime"].ToString() + ",";
                                        pRarentID = pclass.Rows[i]["rUpID"].ToString();
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
                                    //3.将重复的ID去掉
                                    DataView dwv = new DataView(pclass);
                                    dwv.Sort = "rUpID";
                                    pclass = dwv.ToTable(true, "rUpID");
                                    DataTable dt = new DataTable();
                                    DataSet ds = new DataSet();

                                    for (int j = 0; j < pclass.Rows.Count; j++)
                                    {
                                        //4.获得地区上级分类信息
                                        DataTable dtParent = tbRegionInfo.geAreaClassList(Convert.ToInt32(pclass.Rows[j]["rUpID"].ToString()));
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
                                    //5.整合表以后的字段拼接
                                    for (int i = 0; i < pParent.Rows.Count; i++)
                                    {
                                        pid += pParent.Rows[i]["RegionID"].ToString() + ",";
                                        pName += pParent.Rows[i]["rName"].ToString() + ",";
                                        pOrder += pParent.Rows[i]["rOrder"].ToString() + ",";
                                        pTime += pParent.Rows[i]["rAppendTime"].ToString() + ",";
                                        pRarentID = pParent.Rows[i]["rUpID"].ToString();
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
                                        //6.删除操作（多个删除）
                                        count = tbRegionInfo.DeleteRegionInfo(Convert.ToInt32(trNodeBits[i].ToString()));
                                    }
                                }
                                else
                                {
                                    //7.删除操作（单个删除）
                                    count = tbRegionInfo.DeleteRegionInfo(Convert.ToInt32(trNode));
                                }
                                if (count > 0)
                                {
                                    //记录成功操作
                                    Logs.AddEventLog(this.userid, "删除" + trNode + "地区分类");
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
                            //8.页面加载时候
                            DataView dwv = new DataView(pclass);
                            dwv.Sort = "rUpID";
                            pclass = dwv.ToTable(true, "rUpID");
                            DataTable dt = new DataTable();
                            DataSet ds = new DataSet();

                            for (int j = 0; j < pclass.Rows.Count; j++)
                            {
                                //9.获得上级分类
                                DataTable dtParent = tbRegionInfo.geAreaClassList(Convert.ToInt32(pclass.Rows[j]["rUpID"].ToString()));
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
            pagetitle = "地区管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

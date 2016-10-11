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
    public partial class stockproduct : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        public int ProductID = 0;
        public int StorageID = 0;
        public DataTable StorageName = new DataTable();
        public int loop_count = 0;
        public DateTime sDate = DateTime.Now;
        public DataTable StorageList = new DataTable();

        public string StorageClassJson="";
        public string StorageClassID=""; //分类编号
        public string Aclass = "";
        public string className = "";//分类名称


        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";

            Act = HTTPRequest.GetQueryString("Act");
            if (this.userid > 0)
            {

                //仓库分类树
                StorageClassJson = Caches.GetStorageInfoToJson(-1, false, true);
                Aclass = HTTPRequest.GetString("aclass");
                if (Aclass.IndexOf("aclass") > -1)
                {
                    string sID = "";
                    string sCode = "";
                    string sName = "";

                    //获得仓库分类编号
                    StorageClassID = HTTPRequest.GetString("sClassID");
                    //获得仓库名称、编号、系统编号
                    StorageName = tbStockProductInfo.getStorageNameByClass(Convert.ToInt32(StorageClassID));
                    for (int i = 0; i < StorageName.Rows.Count; i++)
                    {
                        if (StorageName.Rows[i]["sState"].ToString() == "0")
                        {
                            sName += StorageName.Rows[i]["sName"].ToString() + "(" + StorageName.Rows[i]["sCode"].ToString() + ")" + ",";
                            sID += StorageName.Rows[i]["StorageID"].ToString() + ",";
                            sCode += StorageName.Rows[i]["sCode"].ToString() + ",";
                        }
                    }
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                    Response.Expires = 0;

                    Response.Write("{sID:'" + sID + "',sCode:'" + sCode + "',sName:'" + sName + "'}");
                    Response.End();
                }

                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-5-1") || CheckUserPopedoms("5-7") || CheckUserPopedoms("5-4"))
                {
                    

                    //StorageList = Caches.GetStorageInfoList("");
                    //StorageName = Utils.ChkSQL(HTTPRequest.GetString("StorageName"));
                   
                    ProductID = HTTPRequest.GetInt("ProductID", 0);
                    StorageID = HTTPRequest.GetInt("StorageID", 0);
                    sDate = HTTPRequest.GetString("sDate").Trim() != "" ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim() + " 23:59:59") : DateTime.Now;
                   
                    
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    if (Act.Trim() != "")
                    {
                        className = HTTPRequest.GetString("StorageClassName").Trim();
                        StorageClassID = HTTPRequest.GetString("StorageClassNum");
                        //if (StorageClassID == "")
                        //{
                        //    AddMsgLine("请选择仓库类别后再进行查询!");
                        //}
                        //else
                        //{
                            StorageName = tbStockProductInfo.getStorageNameByClass(Utils.StrToInt(StorageClassID,0));
                            if (StorageID == 0)
                            {
                                dList = tbProductsInfo.GetProductsStorageInfoByStorageID(Utils.StrToInt(StorageClassID,0), StorageID, sDate, ProductID);
                            }
                            else
                            {
                                dList = tbProductsInfo.GetProductsStorageInfoByStorageID(0, StorageID, sDate, ProductID);// DataUtils.GetStock_analysis(0, DateTime.Now, ProductID);
                            }
                        //}
                       
                    }
                    if (ispost)
                    {
                        Act = HTTPRequest.GetFormString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key")); 
                    }
                    else
                    {
                       
                        S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));

                        //导出
                        if (Act.IndexOf("Export") > -1)
                        {
                            DataTable dt = dList.Copy();
                            if (dt.Rows.Count > 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    dt.Rows[j]["pStorage"] = (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString();
                                }
                                dt.AcceptChanges();

                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(6);
                                dt.Columns.RemoveAt(6);
                                dt.Columns.RemoveAt(6);
                                dt.Columns.RemoveAt(7);
                                DataSet dset = new DataSet();
                                dt.Columns["sName"].SetOrdinal(0);
                                dset.Tables.Add(dt);
                                dset.Tables[0].Columns[0].ColumnName = "仓库名称";
                                dset.Tables[0].Columns[1].ColumnName = "商品条码";
                                dset.Tables[0].Columns[2].ColumnName = "商品名称";
                                dset.Tables[0].Columns[3].ColumnName = "默认售价";
                                dset.Tables[0].Columns[4].ColumnName = "库存数量";
                                dset.Tables[0].Columns[5].ColumnName = "入库未核销";
                                dset.Tables[0].Columns[6].ColumnName = "出库未核销";
                                dset.Tables[0].Columns[7].ColumnName = "不可用库存";

                                

                                CreateExcel(dset.Tables[0], "Data_" + sDate.ToShortDateString() + ".xls");
                            }
                            else
                            {
                                AddErrLine("请选择仓库类别后再进行查询!");
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
            pagetitle = " 实时库存管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

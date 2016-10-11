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
using System.IO;
using System.Data.OleDb;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class marketingfees_importdata : PageBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1"))
                {
                    if (ispost)
                    {
                        int sType = Utils.StrToInt(HTTPRequest.GetString("sType"), 0);
                        string PathStr = Utils.GetMapPath(config.DataPath.ToString());
                        string fileExtension = "";
                        string fileName = "";
                        string thispath = DateTime.Now.Year + "-" + DateTime.Now.Month;
                        ArrayList filearr = new ArrayList();
                        int importdata_count = 0;

                        if (!Directory.Exists(PathStr + thispath))
                        {
                            Directory.CreateDirectory(PathStr + thispath);
                        }

                        //文件上传
                        HttpFileCollection files = HttpContext.Current.Request.Files;
                        try
                        {
                            if (files.Count > 0)
                            {
                                for (int i = 0; i < files.Count; i++)
                                {
                                    HttpPostedFile postedFile = files[i];
                                    fileName = System.IO.Path.GetFileName(postedFile.FileName);
                                    if (Utils.ChkSQL(fileName) != "")
                                    {
                                        fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
                                        if (fileExtension == ".xls")
                                        {
                                            postedFile.SaveAs(PathStr + thispath + "/" + fileName);
                                            filearr.Add(PathStr + thispath + "/" + fileName);
                                        }
                                    }
                                }
                            }
                            if (filearr.Count > 0)
                            {
                                MarketingFeesInfo mi = new MarketingFeesInfo();
                                StoresInfo si = new StoresInfo();
                                FeesSubjectInfo fi = new FeesSubjectInfo();
                                StaffInfo ft = new StaffInfo();
                                try
                                {
                                    for (int j = 0; j < filearr.Count; j++)
                                    {
                                        try
                                        {
                                            DataSet ds = Excels.ExcelToDataTable(filearr[j].ToString());
                                            DataTable dt = new DataTable();
                                            try
                                            {
                                                dt = ds.Tables[0];
                                                foreach (DataRow dr in dt.Rows)
                                                {

                                                    mi.mAppendTime = DateTime.Now;


                                                    if (sType == 0)//营销费用
                                                    {
                                                        if (dr[0].ToString() != "" && dr[1].ToString() != "" && dr[2].ToString() != "" && dr[3].ToString() != "" && dr[4].ToString() != "")
                                                        {
                                                            if (Utils.IsNumeric(dr[3].ToString()))
                                                            {
                                                                si = tbStoresInfo.GetStoresInfoModelByName(dr[2].ToString().Trim());
                                                                if (si == null)
                                                                {
                                                                    si = tbStoresInfo.GetStoresInfoModelByCode(dr[1].ToString().Trim());
                                                                }
                                                                if (si != null)
                                                                {
                                                                    mi.StoresID = si.StoresID;
                                                                }
                                                                fi = tbFeesSubjectInfo.GetFeesSubjectInfoModelByName(dr[4].ToString().Trim());
                                                                if (fi != null)
                                                                {
                                                                    mi.FeesSubjectID = fi.FeesSubjectID;
                                                                }

                                                                mi.mRemark = dr[5].ToString().Trim();
                                                                mi.mFees = decimal.Parse(Utils.StrToFloat(dr[3].ToString().Trim(), 0).ToString());
                                                                mi.mDateTime = DateTime.Parse(dr[0].ToString().Trim());
                                                                mi.mType = 0;
                                                                mi.StaffID = 0;

                                                                if (tbMarketingFeesInfo.AddMarketingFeesInfo(mi) > 0)
                                                                {
                                                                    importdata_count++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (sType == 1)//公司费用
                                                    {
                                                        if (dr[0].ToString() != "" && dr[1].ToString() != "" && dr[2].ToString() != "" && dr[3].ToString() != "")
                                                        {
                                                            if (Utils.IsNumeric(dr[2].ToString()))
                                                            {
                                                                mi.StoresID = 0;
                                                                mi.mDateTime = DateTime.Parse(dr[0].ToString().Trim());
                                                                fi = tbFeesSubjectInfo.GetFeesSubjectInfoModelByName(dr[1].ToString().Trim());
                                                                if (fi != null)
                                                                {
                                                                    mi.FeesSubjectID = fi.FeesSubjectID;
                                                                }
                                                                mi.mFees = decimal.Parse(Utils.StrToFloat(dr[2].ToString().Trim(), 0).ToString());
                                                                ft = tbStaffInfo.GetStaffInfoModelByName(dr[3].ToString().Trim());
                                                                if (ft != null)
                                                                {
                                                                    mi.StaffID = ft.StaffID;
                                                                }
                                                                mi.mType = 1;
                                                                mi.mRemark = dr[4].ToString().Trim();

                                                                if (tbMarketingFeesInfo.AddMarketingFeesInfo(mi) > 0)
                                                                {
                                                                    importdata_count++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (sType == 2)//收入
                                                    {
                                                        if (dr[0].ToString() != "" && dr[1].ToString() != "" && dr[2].ToString() != "" )
                                                        {
                                                            if (Utils.IsNumeric(dr[1].ToString()))
                                                            {
                                                                mi.StoresID = 0;
                                                                mi.mDateTime = DateTime.Parse(dr[0].ToString().Trim());
                                                                if (dr[3].ToString().Trim() != "")
                                                                {
                                                                    fi = tbFeesSubjectInfo.GetFeesSubjectInfoModelByName(dr[3].ToString().Trim());
                                                                    if (fi != null)
                                                                    {
                                                                        mi.FeesSubjectID = fi.FeesSubjectID;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    mi.FeesSubjectID = 0;
                                                                }
                                                                mi.mFees = decimal.Parse(Utils.StrToFloat(dr[1].ToString().Trim(), 0).ToString());
                                                                ft = tbStaffInfo.GetStaffInfoModelByName(dr[2].ToString().Trim());
                                                                if (ft != null)
                                                                {
                                                                    mi.StaffID = ft.StaffID;
                                                                }
                                                                mi.mIsIncomeExpenditure = 1;
                                                                mi.mType = -1;
                                                                mi.mRemark = dr[4].ToString().Trim();

                                                                if (tbMarketingFeesInfo.AddMarketingFeesInfo(mi) > 0)
                                                                {
                                                                    importdata_count++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                            finally
                                            {
                                                ds.Clear();
                                                ds.Dispose();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            AddErrLine("<b>文件格式错误,请将 Xls 文件用 Excel 另存后再导入!</b>:<br>" + ex);
                                            //AddScript("window.setTimeout('history.back(1);',5000);");
                                        }
                                    }
                                    if (importdata_count > 0)
                                    {
                                        AddMsgLine("数据导入成功!共导入数据[" + importdata_count.ToString() + "]条.");
                                        AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                    }
                                    else
                                    {
                                        AddErrLine("系统忙!导入失败!");
                                        //AddScript("window.setTimeout('history.back(1);',1000);");
                                    }
                                }
                                finally
                                {
                                    mi = null;
                                    si = null;
                                    ft = null;
                                }
                            }
                            else
                            {
                                AddErrLine("为发现任何数据!导入失败!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        finally
                        {
                            files = null;
                            filearr.Clear();
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 导入费用数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

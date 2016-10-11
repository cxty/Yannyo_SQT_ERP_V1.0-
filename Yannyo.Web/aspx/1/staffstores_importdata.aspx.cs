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
    public partial class staffstores_importdata : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-2"))
                {
                    if (ispost)
                    {
                        string PathStr = Utils.GetMapPath(config.DataPath.ToString());
                        string fileExtension = "";
                        string fileName = "";
                        string thispath = DateTime.Now.Year + "-" + DateTime.Now.Month;
                        ArrayList filearr = new ArrayList();
                        int importdata_count = 0;
                        int importdata_count_Stores = 0;
                        int importdata_count_Staff = 0;
                        int importdata_count_StaffB = 0;
                        int importdata_count_All = 0;

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
                                StoresInfo si = new StoresInfo();
                                StaffInfo sfi = new StaffInfo();
                                StaffInfo sfiB = new StaffInfo();

                                StaffStoresInfo ssi = new StaffStoresInfo();
                                YHsysInfo yhi = new YHsysInfo();
                                RegionInfo ri = new RegionInfo();

                                string Stores_sCode = "";
                                string Stores_sName = "";
                                string Stores_sType = "";
                                int Stores_YHsysID = 0;
                                int Stores_RegionID = 0;
                                string Staff_Name = "";
                                string Staff_NameB = "";

                                DateTime Staff_sDateTime = DateTime.Parse("2009-1-1");//默认值
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
                                                    if (dr[0].ToString() != "" && dr[1].ToString() != "")//客户名称
                                                    {
                                                        //客户、门店
                                                        Stores_sCode = dr[0].ToString().Trim();
                                                        Stores_sName = dr[1].ToString().Trim();
                                                        Stores_sType = dr[2].ToString().Trim();
                                                        Stores_YHsysID = 0;
                                                        Stores_RegionID = 0;

                                                        if (dr[3].ToString().Trim() != "")
                                                        {
                                                            yhi = tbYHsysInfo.GetYHsysInfoModelByName(dr[3].ToString().Trim());
                                                            if (yhi != null)
                                                            {
                                                                Stores_YHsysID = yhi.YHsysID;
                                                            }
                                                        }

                                                        if (dr[5].ToString().Trim() != "")
                                                        {
                                                            ri = tbRegionInfo.GetRegionInfoModelLikeName(dr[5].ToString().Trim());
                                                            if (ri != null)
                                                            {
                                                                Stores_RegionID = ri.RegionID;
                                                            }
                                                        }
                                                        si = tbStoresInfo.GetStoresInfoModelByName(Stores_sName);
                                                        if (si == null)
                                                        {
                                                            si = new StoresInfo();
                                                            si.sName = Stores_sName;
                                                            si.sCode = Stores_sCode;
                                                            si.sType = Stores_sType;
                                                            si.YHsysID = Stores_YHsysID;
                                                            si.RegionID = Stores_RegionID;
                                                            si.sState = 0;
                                                            si.sAppendTime = DateTime.Now;

                                                            si.StoresID = tbStoresInfo.AddStoresInfo(si);

                                                            importdata_count_Stores++;
                                                        }
                                                        else
                                                        {
                                                            si.sName = Stores_sName;
                                                            si.sCode = Stores_sCode;
                                                            si.sType = Stores_sType;
                                                            si.YHsysID = Stores_YHsysID;
                                                            si.RegionID = Stores_RegionID;
                                                            si.sState = 0;
                                                            try
                                                            {
                                                                tbStoresInfo.UpdateStoresInfo(si);
                                                                importdata_count_Stores++;
                                                            }
                                                            catch
                                                            { 
                                                            }
                                                        }

                                                        //业务员
                                                        Staff_Name = dr[6].ToString().Trim();
                                                        if (Staff_Name.Trim() != "")
                                                        {
                                                            sfi = tbStaffInfo.GetStaffInfoModelByName(Staff_Name.Trim());
                                                            if (sfi == null)
                                                            {
                                                                sfi = new StaffInfo();
                                                                sfi.sName = Staff_Name.Trim();
                                                                sfi.sSex = "";
                                                                sfi.sType = 1;
                                                                sfi.sTel = "";
                                                                sfi.sState = 0;
                                                                sfi.sAppendTime = DateTime.Now;

                                                                sfi.StaffID = tbStaffInfo.AddStaffInfo(sfi);

                                                                importdata_count_Staff++;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            sfi = new StaffInfo();
                                                            sfi.StaffID = 0;
                                                        }


                                                        //促销员
                                                        Staff_NameB = dr[7].ToString().Trim();
                                                        if (Staff_NameB.Trim() != "")
                                                        {
                                                            sfiB = tbStaffInfo.GetStaffInfoModelByName(Staff_NameB.Trim());
                                                            if (sfiB == null)
                                                            {
                                                                sfiB = new StaffInfo();
                                                                sfiB.sName = Staff_NameB.Trim();
                                                                sfiB.sSex = "女";
                                                                sfiB.sType = 2;
                                                                sfiB.sTel = dr[8].ToString().Trim();
                                                                sfiB.sState = 0;
                                                                sfiB.sAppendTime = DateTime.Now;

                                                                sfiB.StaffID = tbStaffInfo.AddStaffInfo(sfiB);

                                                                importdata_count_StaffB++;
                                                            }
                                                            else
                                                            {
                                                                sfiB.sTel = dr[8].ToString().Trim();

                                                                tbStaffInfo.UpdateStaffInfo(sfiB);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            sfiB = new StaffInfo();
                                                            sfiB.StaffID = 0;
                                                        }


                                                        if (dr[9].ToString().Trim() != "")
                                                        {
                                                            Staff_sDateTime = DateTime.Parse(dr[9].ToString().Trim());
                                                        }
                                                        else
                                                        {
                                                            Staff_sDateTime = DateTime.Parse("2009-1-1");
                                                        }

                                                        //人员门店绑定
                                                        if (si.StoresID > 0)
                                                        {
                                                            ssi.StoresID = si.StoresID;

                                                            if (sfi.StaffID > 0)//绑定业务员
                                                            {
                                                                ssi.StaffID = sfi.StaffID;
                                                                ssi.sType = 0;
                                                                ssi.sDateTime = DateTime.Parse("2009-1-1");
                                                                ssi.sAppendTime = DateTime.Now;

                                                                tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                                                importdata_count++;
                                                            }
                                                            if (sfiB.StaffID > 0)//绑定促销员
                                                            {
                                                                ssi.StaffID = sfiB.StaffID;
                                                                ssi.sType = 0;
                                                                ssi.sDateTime = Staff_sDateTime;
                                                                ssi.sAppendTime = DateTime.Now;

                                                                tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                                                importdata_count++;
                                                            }
                                                        }
                                                        importdata_count_All++;
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
                                        AddMsgLine("数据导入成功!共导入数据[" + importdata_count_All.ToString() + "]条,门店[" + importdata_count_Stores.ToString() + "]条,业务员[" + importdata_count_Staff.ToString() + "]条,促销员[" + importdata_count_StaffB.ToString() + "]条,绑定上岗记录[" + importdata_count.ToString() + "]条.");
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
                                    si = null;
                                    sfi = null;
                                    sfiB = null;
                                    ssi = null;
                                    yhi = null;
                                    ri = null;
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
            pagetitle = "数据导入";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

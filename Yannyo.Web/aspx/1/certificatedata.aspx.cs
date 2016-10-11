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
    public partial class certificatedata : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int ShowType = 0;
        public string cObjectName = "";
        public string StaffName = "";
        public string TimeB = "";
        public string TimeE = "";
        public string FeesSubject = "";

        public int cObjectType = -1;
        public int cObjectID = -1;
        public int cObjectIsRoot = -1;

        public int FeesSubjectID = -1;
        public int StaffID = -1;
        public string Act = "";
        public string S_key = "";

        public decimal SumMoneyA = 0;//合计金额,借
        public decimal SumMoneyB = 0;//合计金额,贷

        public int cSteps = -1;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }

                    string tSQL = " tbCertificateDataInfo.CertificateID in (select CertificateID from tbCertificateInfo where cState=0)  ";
                    Act = HTTPRequest.GetString("Act");
                    S_key = HTTPRequest.GetString("S_key");

                    ShowType = HTTPRequest.GetInt("ShowType", 0);
                    cObjectName = HTTPRequest.GetString("cObjectName");
                    cObjectType = HTTPRequest.GetInt("cObjectType",-1);
                    cObjectID = HTTPRequest.GetInt("cObjectID", -1);
                    cObjectIsRoot = HTTPRequest.GetInt("cObjectIsRoot", -1);

                    FeesSubject = HTTPRequest.GetString("FeesSubject");
                    FeesSubjectID = HTTPRequest.GetInt("FeesSubjectID",-1);

                    StaffID = HTTPRequest.GetInt("StaffID", -1);
                    StaffName = HTTPRequest.GetString("StaffName");

                    TimeB = HTTPRequest.GetString("TimeB");
                    TimeE = HTTPRequest.GetString("TimeE");

                    cSteps = HTTPRequest.GetInt("cSteps", -1);

                    #region 单位
                    if (cObjectID > 0)
                    {
                        string cObjectIDStr = "";
                        if (cObjectIsRoot == 1)//非叶节点
                        {
                            switch (cObjectType)
                            {
                                case 0://客户
                                    cObjectIDStr = DataClass.GetCustomersClassChildStr(cObjectID);
                                    if (cObjectIDStr.Trim() != "")
                                    {
                                        cObjectIDStr = "select StoresID from tbStoresInfo where CustomersClassID in(" + cObjectIDStr + "," + cObjectID + ")";
                                    }
                                    break;
                                case 1://供应商
                                    cObjectIDStr = DataClass.GetSupplierClassChildStr(cObjectID);
                                    if (cObjectIDStr.Trim() != "")
                                    {
                                        cObjectIDStr = "select SupplierID from tbSupplierInfo where SupplierClassID in(" + cObjectIDStr + "," + cObjectID + ")";
                                    }
                                    break;
                                case 2://人员
                                    cObjectIDStr = DataClass.GetDepartmentsClassChildStr(cObjectID);
                                    if (cObjectIDStr.Trim() != "")
                                    {
                                        cObjectIDStr = "select StaffID from tbStaffInfo where DepartmentsClassID in(" + cObjectIDStr + "," + cObjectID + ")";
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            cObjectIDStr = cObjectID.ToString();
                        }
                        tSQL += " and tbCertificateDataInfo.toObject=" + cObjectType + " and tbCertificateDataInfo.toObjectID in(" + cObjectIDStr + ")";
                    }
                    #endregion

                    #region 科目
                    if (FeesSubjectID > 0)
                    {
                        string FeesSubjectIDStr = DataClass.GetFeesSubjectClassChildStr(FeesSubjectID);
                        if (FeesSubjectIDStr.Trim() != "")
                        {
                            tSQL += " and tbCertificateDataInfo.FeesSubjectID in(" + FeesSubjectIDStr + "," + FeesSubjectID + ")";
                        }
                        else
                        {
                            tSQL += " and tbCertificateDataInfo.FeesSubjectID in(" + FeesSubjectID + ")";
                        }
                    }
                    #endregion

                    #region 经办人
                    if (StaffID > 0)
                    {
                        tSQL += " and  tbCertificateDataInfo.CertificateID in (select CertificateID from tbCertificateInfo where StaffID=" + StaffID + ") ";
                    }
                    #endregion

                    #region 时间
                    if (TimeB.Trim() != "" && Utils.IsDateString(TimeB.Trim()))
                    {
                        tSQL += " and tbCertificateDataInfo.CertificateID in (select CertificateID from tbCertificateInfo where cDateTime>='" + Convert.ToDateTime(TimeB.Trim()).ToShortDateString() + " 00:00:00 ')  ";
                    }
                    if (TimeE.Trim() != "" && Utils.IsDateString(TimeE.Trim()))
                    {
                        tSQL += " and tbCertificateDataInfo.CertificateID in (select CertificateID from tbCertificateInfo where cDateTime<='" + Convert.ToDateTime(TimeE.Trim()).ToShortDateString() + " 23:59:59 ')  ";
                    }
                    #endregion

                    if (cSteps > -1)
                    {
                        tSQL += " and tbCertificateDataInfo.CertificateID in (select CertificateID from tbCertificateInfo where cSteps=" + cSteps + ")";
                    }

                    if (!IsErr())
                    {
                        if (Act.IndexOf("Export") > -1)//导出
                        {
                            tSQL = Utils.ReplaceString(tSQL, "tbCertificateDataInfo.", "cd.", false);
                            DataSet _exDs = Certificates.GetCertificateDataInfoListB(tSQL + " order by cd.CertificateDataID desc");
                            _exDs.Tables[0].Columns[0].ColumnName = "凭证编号";
                            _exDs.Tables[0].Columns[1].ColumnName = "凭证类型";
                            _exDs.Tables[0].Columns[2].ColumnName = "发生时间";
                            _exDs.Tables[0].Columns[3].ColumnName = "摘要";
                            _exDs.Tables[0].Columns[4].ColumnName = "金额";
                            _exDs.Tables[0].Columns[5].ColumnName = "科目";
                            _exDs.Tables[0].Columns[6].ColumnName = "单位类型";
                            _exDs.Tables[0].Columns[7].ColumnName = "单位";
                            _exDs.Tables[0].Columns[8].ColumnName = "经办人";
                            _exDs.Tables[0].Columns[9].ColumnName = "说明";
                            _exDs.Tables[0].Columns[10].ColumnName = "创建时间";

                            CreateExcel(_exDs.Tables[0], "Data_" + DateTime.Now.ToShortDateString() + ".xls");
                        }
                        else
                        {
                           decimal[] SumMoney = Certificates.GetCertificateDataSumMoney(tSQL);
                           SumMoneyA = SumMoney[0];
                           SumMoneyB = SumMoney[1];

                            dList = Certificates.GetCertificateDataInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");

                            PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key + "&ShowType=" + ShowType + "&cObjectName=" + cObjectName + "&cObjectType=" + cObjectType + "&cObjectID=" + cObjectID + "&cObjectIsRoot=" + cObjectIsRoot + "&FeesSubject=" + FeesSubject + "&FeesSubjectID=" + FeesSubjectID + "&StaffName=" + StaffName + "&StaffID=" + StaffID + "&TimeB=" + TimeB + "&TimeE=" + TimeE + "&cSteps=" + cSteps);
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
            pagetitle = " 收入支出";
            this.Load += new EventHandler(this.Page_Load);
        }
       
    }
}
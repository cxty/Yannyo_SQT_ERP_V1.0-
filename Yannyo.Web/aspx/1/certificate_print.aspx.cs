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
    public partial class certificate_print : PageBase
    {
        public int CertificateID = 0;
        public CertificateInfo ci = new CertificateInfo();
        public DataTable CertificateDataList = new DataTable();
        public UserInfo print_ui = new UserInfo();//开单人员
        public UserInfo print_v_ui = new UserInfo();//审核人员
        public decimal summoney = 0;//合计
        public string summoney_str = "";//大写
        public int CertificateRow = 0;//凭证内容行数
        public int CertificateMAXRow = 0;//凭证单页最大显示行数
        public DataSet CertificateDataSet = new DataSet();//分页时使用,存储分页后的多个表

        public decimal cdMoneySum = 0;
        public decimal cdMoneyBSum = 0;
        public int pageindex = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-6"))
                {
                    CertificateID = HTTPRequest.GetInt("cid",0);
                    if (CertificateID > 0)
                    {
                        ci = Certificates.GetCertificateInfoModel(CertificateID);
                        if (ci != null)
                        {
                            CertificateDataList = Certificates.GetCertificateDataInfoList(" cd.CertificateID = " + CertificateID + " order by cd.CertificateDataID asc").Tables[0];
                            //凭证行数
                            if(CertificateDataList!=null){
                                CertificateRow = CertificateDataList.Rows.Count;
                                CertificateMAXRow = config.CertificateRow;
                                //超过最大显示行数,进行数据拆分
                                //if (CertificateRow > CertificateMAXRow)
                                {
                                    int i = 0;
                                    DataTable dt = CertificateDataList.Clone();
                                    foreach (DataRow dr in CertificateDataList.Rows)
                                    {
                                        dt.ImportRow(dr);
                                        i++;
                                        if (i % CertificateMAXRow == 0)
                                        {
                                            CertificateDataSet.Tables.Add(dt);
                                            dt = CertificateDataList.Clone();
                                            dt.TableName = "t_"+i;
                                        } 
                                    }
                                    if (dt.Rows.Count > 0)
                                    {
                                        //剩下的行数
                                        CertificateDataSet.Tables.Add(dt);
                                        dt = CertificateDataList.Clone();
                                        dt.TableName = "t_" + (i + 1);
                                    }
                                }
                            }
                            //制单人
                            print_ui = tbUserInfo.GetUserInfoModel(ci.UserID);
                            //审核人
                            CertificateWorkingLogInfo owil = Certificates.GetCertificateWorkingLogUserID(ci.CertificateID, 2);
                            if (owil != null)
                            {
                                print_v_ui = tbUserInfo.GetUserInfoModel(owil.UserID);
                            }
                            else
                            {
                                print_v_ui = null;
                            }

                            CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                            co.CertificateID = CertificateID;
                            co.UserID = this.userid;
                            co.cType = 3;
                            co.cAppendTime = DateTime.Now;
                            Certificates.AddCertificateWorkingLog(co);

                        }
                        else {
                            AddErrLine("凭证不存在!");
                        }
                    }
                    else {
                        AddErrLine("参数错误!");
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
            pagetitle = " 打印凭证";
            this.Load += new EventHandler(this.Page_Load);
        }
        public string GetFeesSubjectClassParentStr(int FeesSubjectClassID,string sStr)
        {
            return DataClass.GetFeesSubjectClassParentStr(FeesSubjectClassID, sStr);
        }
    }
}
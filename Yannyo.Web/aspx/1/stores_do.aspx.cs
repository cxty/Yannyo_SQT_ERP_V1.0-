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
    public partial class stores_do : PageBase
    {
        public StoresInfo si = new StoresInfo();
        public StaffInfo sti = new StaffInfo();//业务员
        public StaffInfo sti_b = new StaffInfo();//促销员
        public DataTable StaffList = new DataTable();//业务员
        public DataTable StaffList_b = new DataTable();//促销员

        public DataTable YHsysList = new DataTable();//超市系统列表
        public DataTable PaymentSystemList = new DataTable();//结算系统列表

        public string Act = "";
        public int StoresID = 0;
        public string sName = "";
        public string sCode = "";
        public string sType = "";
        public int RegionID = 0;
        public int sState = 0;
        public int YHsysID = 0;
        public int sIsFZYH = 0;
        public int sDoDay = 0;
        public decimal sDoDayMoney = 0;
        public int PaymentSystemID = 0;
        public DateTime sAppendTime = DateTime.Now;
        public int CustomersClassID = 0;
        public string CustomersClass = "";
        public int PriceClassID = 0;
        public string PriceClass = "";
        public string Region = "";
        public string sContact = "";
        public string sTel = "";
        public string sAddress = "";
        public string sEmail = "";
        public string sLicense = "";
        
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-4"))
                {
                    Act = HTTPRequest.GetString("Act");

                    if (Act == "Edit")
                    {
                        StoresID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbStoresInfo.GetStoresInfoModel(StoresID);
                        
                    }
					if (ispost) {
						sName = Utils.ChkSQL (HTTPRequest.GetString ("sName"));
						sCode = Utils.ChkSQL (HTTPRequest.GetString ("sCode"));
						sType = Utils.ChkSQL (HTTPRequest.GetString ("sType"));
						RegionID = Utils.StrToInt (HTTPRequest.GetString ("RegionID"), 0);
						YHsysID = Utils.StrToInt (HTTPRequest.GetString ("YHsysID"), 0);
						sIsFZYH = HTTPRequest.GetString ("sIsFZYH").Trim () != "" ? 1 : 0;
						sState = HTTPRequest.GetString ("sState").Trim () != "" ? 0 : 1;
						PaymentSystemID = Utils.StrToInt (HTTPRequest.GetString ("PaymentSystemID"), 0);
						sDoDay = Utils.StrToInt (HTTPRequest.GetString ("sDoDay"), 0);
						CustomersClassID = Utils.StrToInt (HTTPRequest.GetString ("CustomersClassID"), 0);
						PriceClassID = Utils.StrToInt (HTTPRequest.GetString ("PriceClassID"), 0);
						sDoDayMoney = decimal.Parse (HTTPRequest.GetString ("sDoDayMoney").Trim () != "" ? HTTPRequest.GetString ("sDoDayMoney") : "0.0");

						sContact = Utils.ChkSQL (HTTPRequest.GetString ("sContact"));
						sTel = Utils.ChkSQL (HTTPRequest.GetString ("sTel"));
						sAddress = Utils.ChkSQL (HTTPRequest.GetString ("sAddress"));
						sEmail = Utils.ChkSQL (HTTPRequest.GetString ("sEmail"));
						sLicense = Utils.ChkSQL (HTTPRequest.GetString ("sLicense"));

						si.sState = sState;
						si.sType = sType;
						si.RegionID = RegionID;
						si.YHsysID = YHsysID;
						si.sIsFZYH = sIsFZYH;
						si.sDoDay = sDoDay;
						si.PaymentSystemID = PaymentSystemID;
						si.sDoDayMoney = sDoDayMoney;
						si.CustomersClassID = CustomersClassID;
						si.PriceClassID = PriceClassID;
						si.sContact = sContact;
						si.sTel = sTel;
						si.sAddress = sAddress;
						si.sEmail = sEmail;
						si.sLicense = sLicense;

						if (Act == "Add") {
							if (!tbStoresInfo.ExistsStoresInfo (sName)) {
								si.sName = sName;
								si.sCode = sCode;
                                
								si.sAppendTime = sAppendTime;

								if (tbStoresInfo.AddStoresInfo (si) > 0) {
									Logs.AddEventLog (this.userid, "新增客户." + si.sName);
									AddMsgLine ("创建成功!");
									AddScript ("window.setTimeout('window.parent.HidBox();',1000);");
								} else {
									AddErrLine ("创建失败!");
									AddScript ("window.setTimeout('history.back(1);',2000);");
								}
							} else {
								AddErrLine ("客户:" + sName + ",已存在,请更换!");
								AddScript ("window.setTimeout('history.back(1);',2000);");
							}                        
						}
						if (Act == "Edit") {
							bool nOK = false;

							if (si.sName != sName) {
								if (!tbStoresInfo.CheckStoresByOrder (si.StoresID) || CheckUserPopedoms("X")) {
										if (!tbStoresInfo.ExistsStoresInfo (sName)) {
											nOK = true;
										} else {
											nOK = false;
											AddErrLine ("客户:" + sName + ",已存在,请更换!");
											AddScript ("window.setTimeout('history.back(1);',2000);");
										}
									}else {
										nOK = false;
										Logs.AddEventLog (this.userid, "修改客户失败,已有单据存在，系统锁定，无法修改." + si.sName);
										AddErrLine ("修改失败,已有单据存在，系统锁定，无法修改!");
									}
							} else {
								nOK = true;
							}

						
							if (si.sCode != sCode) {
								if (!tbStoresInfo.CheckStoresByOrder (si.StoresID) || CheckUserPopedoms("X")) {
									if (!tbStoresInfo.ExistsStoresInfoCode (sCode)) {
										nOK = true;
									} else {
										nOK = false;
										AddErrLine ("客户 编码:" + sCode + ",已存在,请更换!");
										AddScript ("window.setTimeout('history.back(1);',2000);");
									}
								} else {
									nOK = false;
									Logs.AddEventLog (this.userid, "修改客户失败,已有单据存在，系统锁定，无法修改." + si.sName);
									AddErrLine ("修改失败,已有单据存在，系统锁定，无法修改!");
								}
							} else {
								nOK = true;
							}
						
							if (!this.IsErr()) {
								try {
									si.sName = sName;
									si.sCode = sCode;

									tbStoresInfo.UpdateStoresInfo (si);
									Logs.AddEventLog (this.userid, "修改客户." + si.sName);
									AddMsgLine ("修改成功!");
									AddScript ("window.setTimeout('window.parent.HidBox();',2000);");
								} catch (Exception ex) {
									AddErrLine ("修改失败!<br/>" + ex);
									AddScript ("window.setTimeout('window.parent.HidBox();',5000);");
								}
							}
						}
						Caches.ReSet ();
					}
                    else
                    {
                        

                        CustomersClass = Caches.GetCustomersClassInfoToHTML();
                        Region = Caches.GetRegionInfoToHTML();
                        PriceClass = Caches.GetPriceClassInfoToHTML();

                        YHsysList = Caches.GetYHsysInfoList();
                        PaymentSystemList = Caches.GetPaymentSystemList();

                        if (Act == "Add")
                        {
                            si.sName = "";
                            si.sCode = "";
                            si.sState = 0;
                            si.sType = "";
                            si.RegionID = 0;
                        }

                        if (Act == "Edit")
                        {
                            if (si != null)
                            {
                                sti = tbStaffStoresInfo.GetStaffByStores(si.StoresID, 1);
                                sti_b = tbStaffStoresInfo.GetStaffByStores(si.StoresID, 2);

                                StaffList = tbStaffStoresInfo.GetStaff_StoresList(0, StoresID, DateTime.Now.AddYears(-100), DateTime.Now, 1);

                                StaffList_b = tbStaffStoresInfo.GetStaff_StoresList(0, StoresID, DateTime.Now.AddYears(-100), DateTime.Now, 2);

                                DataView view = new DataView();
                                view.Table = StaffList;

                                view.Sort = "bdate DESC";
                                StaffList = view.ToTable();

                                DataView view_b = new DataView();
                                view_b.Table = StaffList_b;

                                view_b.Sort = "bdate DESC";
                                StaffList_b = view_b.ToTable();
                            }
                        }

                        if (Act == "Del")
                        {
                            try
                            {
								string _sName = "";
								string _eName = "";
								int _StoresID = 0;
								bool isOK = true;
								string[] _sid = Utils.SplitString(","+HTTPRequest.GetString("sid")+",",",");
								foreach(string _id in _sid){
									_StoresID = Utils.StrToInt(_id,0);
									if(tbStoresInfo.CheckStoresByOrder(_StoresID) && !CheckUserPopedoms("X")){
										isOK = false;
										_eName = tbStoresInfo.GetStoresInfoModel(_StoresID).sName + "ID:"+_StoresID;
										break;
									}else{
										_sName += tbStoresInfo.GetStoresInfoModel(_StoresID).sName + " ID:"+_StoresID +" ";
									}
								}

								if(isOK){

                                	tbStoresInfo.DeleteStoresInfo(HTTPRequest.GetString("sid"));
									Logs.AddEventLog(this.userid, "删除客户成功." + _sName);
                                	AddMsgLine("删除成功!");

								}else{
									Logs.AddEventLog(this.userid, "删除客户失败,已有单据存在，系统锁定，无法删除." + _eName);
									AddMsgLine("删除失败,已有单据存在，系统锁定，无法删除!");
								}
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("创建失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }

                        if (Act == "Import")
                        {
                            try {
                                int re  = tbStoresInfo.ImportErpStores();

                                if (re > 0)
                                {
                                    AddMsgLine("成功导入 "+re+" 条客户信息!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1500);");
                                }
                                else
                                {
                                    AddErrLine("没有任何客户信息被导入!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1500);");
                                }
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("导入失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
			pagetitle = " 添加修改客户信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

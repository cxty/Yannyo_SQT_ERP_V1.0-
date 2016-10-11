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
using Newtonsoft.Json;

namespace Yannyo.Web
{
    public partial class storehousestorage_add_list : PageBase
    {
        public StorehouseStorageJsonInfo ms = new StorehouseStorageJsonInfo();
        public DataTable dList = new DataTable();
        public string SName = "";
        public string sName;       //门店名称
        public string sCode;    //取门店编号
        public int StoresID;       //门店编号
        public DateTime sDate;     //时间
        public string pBarcode="";    //产品条码
        public string pName;       //产品名称
        public string productsID;     //产品系统编号
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            //检查JSON传过来是否有值
            //StorehouseStorageDataJson ssdj = new StorehouseStorageDataJson();
            //StoreHouseStorage[] shs = new StoreHouseStorage[1];
            //shs[0] = new StoreHouseStorage();
            //ssdj.StoreHouseStorage = shs;

            //Response.Write(JavaScriptConvert.SerializeObject(ssdj));
            //Response.End();

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-6-1"))
                {
                    if (ispost)
                    {
                        sName = HTTPRequest.GetString("SName").Trim();
                        sCode = storehouseStorage.GetScode(sName);
                        StoresID =Utils.StrToInt(storehouseStorage.SelectScodeBySname(sName),0);//根据门店名称获取门店编号
                        sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;
                        string reValue = HTTPRequest.GetString("reValue");//获得前台的Json
                        if (reValue.Trim() != "")
                        {
                            if (StoresID>0)
                            {
                                if (sDate > DateTime.Now)
                                {
                                    AddErrLine("日期选择错误，不能大于当前日期，请重新选择!");
                                }
                                else
                                {
                                    ms.SName = sName;
                                    ms.StoresID = StoresID;
                                    ms.SCode = sCode;
                                    ms.PAppendTime = sDate;

                                    ms.StorehouseStorageJson = (StorehouseStorageDataJson)JavaScriptConvert.DeserializeObject(reValue, typeof(StorehouseStorageDataJson));

                                    bool state=storehouseStorage.AddStorehouseStorageData(ms);
                                    if (state)
                                    {
                                        AddMsgLine("添加数据成功！");
                                        AddScript("window.setTimeout('window.parent.HidBox();'),1000");
                                    }
                                    else
                                    {
                                        AddErrLine("系统忙！添加失败");
                                    }
                                }
                            }
                            else
                            {
                                AddMsgLine("该门店[" + sName + "]编号不存在！请确认后再次输入或先添加该门店！");
                            }   
                        }
                        else {
                            AddErrLine("未获取到表单值！");
                        }                   
                    }
                    else
                    {
                        dList= tbProductsInfo.GetProductsInfoList(" pState=0 order by ProductClassID,ProductsID desc").Tables[0];
                      
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
            pagetitle = "创建门店仓库单据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
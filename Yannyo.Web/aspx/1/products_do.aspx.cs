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
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{
    public partial class products_do : PageBase
    {
        public ProductsInfo pi = new ProductsInfo();
		public DataTable ProductFieldTypeList = new DataTable();

		public DataTable ProductFieldValueList = new DataTable();
		public DataTable ProductFieldList = new DataTable();
		public string ProductFieldValueList_Json = "";
		public string ProductFieldValue_json = "";

		public string format = "";
		public string MS_Json = "";
        public string Act = "";
        public int ProductsID = 0;
        //public string pCode = "";
        public string pBarcode = "";
        public string pName = "";
        public string pEnName = "";
        public string pBrand = "";
        public string pStandard = "";
        public string pUnits = "";
        public string pMaxUnits = "";
        public int pToBoxNo = 0;
        public int pState = 0;
        public int ProductClassID = 0;
        public decimal pPrice = 0;
        public decimal pSellingPrice = 0;
        public decimal pDoDayQuantity = 0;
        public DateTime pAppendTime = DateTime.Now;
        public string ProductClassStr = "";
        public string pProducer = "";
        public string pExpireDay = "";
        public string pAddress = "";
		public string ProductFieldValue = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-2") )
                {
                    Act = HTTPRequest.GetString("Act");
					format = HTTPRequest.GetString ("format");
					ProductFieldValue_json = HTTPRequest.GetString ("ProductFieldValue");
                    if (Act == "Edit")
                    {
                        ProductsID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);
                        
                        pi = tbProductsInfo.GetProductsInfoModel(ProductsID);

						ProductFieldValueList = tbProductsFieldValueInfo.GetProductsFieldValueList (" ProductsID = "+ProductsID).Tables[0];
                    }
                    if (ispost)
                    {
                        //pCode = Utils.ChkSQL(HTTPRequest.GetString("pCode"));
                        pBarcode = Utils.ChkSQL(HTTPRequest.GetString("pBarcode").Trim());
                        pName = Utils.ChkSQL(HTTPRequest.GetString("pName").Trim());
                        pEnName = Utils.ChkSQL(HTTPRequest.GetString("pEnName").Trim());
                        pBrand = Utils.ChkSQL(HTTPRequest.GetString("pBrand").Trim());
                        pStandard = Utils.ChkSQL(HTTPRequest.GetString("pStandard").Trim());
                        pUnits = Utils.ChkSQL(HTTPRequest.GetString("pUnits").Trim());
                        pMaxUnits = Utils.ChkSQL(HTTPRequest.GetString("pMaxUnits").Trim());
                        pToBoxNo = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("pToBoxNo")),0);
                        ProductClassID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductClassID")), 0);
                        pState = HTTPRequest.GetInt("pState",1);// HTTPRequest.GetString("pState").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("pState"), 0) : 1;
                        pDoDayQuantity = 0;//暂不使用,期初在各商品库存 (HTTPRequest.GetString("pDoDayQuantity").Trim() != "") ? decimal.Parse(Utils.ChkSQL(HTTPRequest.GetString("pDoDayQuantity"))) : 0;

                        pProducer = Utils.ChkSQL(HTTPRequest.GetString("pProducer").Trim());
                        pExpireDay = Utils.ChkSQL(HTTPRequest.GetString("pExpireDay").Trim());
                        pAddress = Utils.ChkSQL(HTTPRequest.GetString("pAddress").Trim());

                        pPrice = (HTTPRequest.GetString("pPrice").Trim() != "") ? decimal.Parse(HTTPRequest.GetString("pPrice")) : 0;
                        pSellingPrice = (HTTPRequest.GetString("pSellingPrice").Trim() != "") ? decimal.Parse(HTTPRequest.GetString("pSellingPrice")) : 0;

						ProductFieldValue = HTTPRequest.GetString ("ProductFieldValue");

                        pi.pStandard = pStandard;
                        pi.pUnits = pUnits;
                        pi.pMaxUnits = pMaxUnits;
                        pi.pToBoxNo = pToBoxNo;
                        pi.pState = pState;
                        pi.pBrand = pBrand;
                        pi.pPrice = pPrice;
                        pi.pSellingPrice = pSellingPrice;
                        pi.pDoDayQuantity = pDoDayQuantity;
                        pi.ProductClassID = ProductClassID;
                        pi.pProducer = pProducer;
                        pi.pExpireDay = pExpireDay;
                        pi.pAddress = pAddress;
                        pi.pEnName = pEnName;


                        pi.ProductFieldValueJson = (ProductFieldValueJson)JavaScriptConvert.DeserializeObject(ProductFieldValue_json, typeof(ProductFieldValueJson));

                        if (Act == "Add")
                        {
                            pi.pCode = Utils.GetRanDomCode();
                            pi.pBarcode = pBarcode;
                            pi.pName = pName;
                            pi.pAppendTime = DateTime.Now;

                            if (!tbProductsInfo.ExistsProductsInfo(pName))
                            {
                                //if (!tbProductsInfo.ExistsProductsInfo_pCode(pCode))
                                {
                                    if (!tbProductsInfo.ExistsProductsInfo_pBarcode(pBarcode))
                                    {
										int _ProductsID = tbProductsInfo.AddProductsInfo (pi);
										if (_ProductsID > 0)
                                        {
											//Add ProductFieldValue
											tbProductsFieldValueInfo.AddProductsFieldValue (_ProductsID,pi.ProductFieldValueJson);

                                            Logs.AddEventLog(this.userid, "新增产品."+pi.pName);
                                            AddMsgLine("创建成功!");
                                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                        }
                                        else
                                        {
                                            AddErrLine("创建失败!");
                                            AddScript("window.setTimeout('history.back(1);',1000);");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("产品条码:" + pBarcode + ",已存在,请更换!");
                                        AddScript("window.setTimeout('history.back(1);',1000);");
                                    }
                                }
                                //else
                                {
                                   // AddErrLine("产品编码:" + pCode + ",已存在,请更换!");
                                    //AddScript("history.back(1);");
                                }
                            }
                            else
                            {
                                AddErrLine("产品:" + pName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
							if (!tbProductsInfo.CheckProductsByOrder (pi.ProductsID) || CheckUserPopedoms("X")) {
								if (pi.pName.Trim () != pName.Trim ()) {
									if (!tbProductsInfo.ExistsProductsInfo (pName)) {
										//if (pi.pCode != pCode)
										{
											//if (!tbProductsInfo.ExistsProductsInfo_pCode(pCode))
											{
												if (pi.pBarcode.Trim () != pBarcode.Trim ()) {
													if (!tbProductsInfo.ExistsProductsInfo_pBarcode (pBarcode)) {
                                                    
													} else {
														AddErrLine ("产品条码:" + pBarcode + ",已存在,请更换!");
														AddScript ("window.setTimeout('history.back(1);',1500);");
													}
												}
											}
											//else
											{
												// AddErrLine("产品编码:" + pCode + ",已存在,请更换!");
												//AddScript("history.back(1);");
											}
										}
									} else {
										AddErrLine ("产品:" + pName + ",已存在,请更换!");
										AddScript ("window.setTimeout('history.back(1);',1500);");
									}
								}
							} else {
							
								Logs.AddEventLog(this.userid, "修改失败,已有单据存在，系统锁定，无法删除." + pi.pName);
								AddMsgLine("修改失败,已有单据存在，系统锁定，无法修改!");
								AddScript("window.setTimeout('window.parent.HidBox();',2000);");
							}
                            if (!IsErr())
                            {
                                try
                                {
                                    //pi.pCode = pCode;
                                    pi.pBarcode = pBarcode;
                                    pi.pName = pName;

                                    tbProductsInfo.UpdateProductsInfo(pi);

									tbProductsFieldValueInfo.UpdateProductsFieldValue(pi.ProductsID,pi.ProductFieldValueJson);

                                    Logs.AddEventLog(this.userid, "修改产品." + pi.pName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                }
                            }
                        }
						if(Act == "UpFile"){

						}
                        Caches.ReSet();
                    }
                    else
                    {
						ProductFieldTypeList = tbProductFieldInfo.GetProductFieldTypes ();
                        ProductClassStr = DataClass.GetProductClassInfoToHTML();


						//GetProductFieldList by ProductClassID
						if(Act == "GetProductFieldList"){
							ProductClassID = HTTPRequest.GetInt ("ProductClassID",0);

							MS_Json = tbProductFieldInfo.GetProductFieldListJsonByProductClassID(ProductClassID);
						}

						if (Act == "Edit") {
						
							if (ProductFieldValueList != null) {
								string __Json = "";
								for (int k=0; k<ProductFieldValueList.Rows.Count; k++) {
									__Json += "{\"ProductsFieldValueID\":" + ProductFieldValueList.Rows [k] ["ProductsFieldValueID"].ToString () + "," +
										"\"ProductsID\":" + ProductFieldValueList.Rows [k] ["ProductsID"].ToString () + "," +
										"\"ProductFieldID\":" + ProductFieldValueList.Rows [k] ["ProductFieldID"].ToString () + "," +
										"\"pfvType\":" + ProductFieldValueList.Rows [k] ["pfvType"].ToString () + "," +
											"\"pfvData\":\"" + ProductFieldValueList.Rows [k] ["pfvData"].ToString ().Replace("\r\n","$r$") + "\"," +
										"\"pfvAppendTime\":\"" + ProductFieldValueList.Rows [k] ["pfvAppendTime"].ToString () + "\"" +
										"},";
								}
								__Json = __Json.Trim () != "" ? __Json.Trim ().Substring (0, __Json.Trim ().Length - 1) : "";
								ProductFieldValueList_Json = "{\"ProductFieldValue\":["+__Json+"]}";
							}
						}

                        if (Act == "Del")
                        {
                            try
                            {

								string _pName = "";
								string _eName = "";
								int _productsID = 0;
								bool isOK = true;
								string[] _pid = Utils.SplitString(","+HTTPRequest.GetString("pid")+",",",");
								foreach(string _id in _pid){
									_productsID = Utils.StrToInt(_id,0);
                                    if (_productsID > 0)
                                    {
                                        if (tbProductsInfo.CheckProductsByOrder(_productsID) && !CheckUserPopedoms("X"))
                                        {
                                            isOK = false;
                                            _eName = tbProductsInfo.GetProductsInfoModel(_productsID).pName + "ID:" + _productsID;
                                            break;
                                        }
                                        else
                                        {
                                            _pName += tbProductsInfo.GetProductsInfoModel(_productsID).pName + "ID:" + _productsID + " ";
                                        }
                                    }
								}

								if(isOK){

                                	tbProductsInfo.DeleteProductsInfo(HTTPRequest.GetString("pid"));
									Logs.AddEventLog(this.userid, "删除产品." + _pName);
                                	AddMsgLine("删除成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
								}else{

									Logs.AddEventLog(this.userid, "删除失败,已有单据存在，系统锁定，无法删除." + _eName);
									AddMsgLine("删除失败,已有单据存在，系统锁定，无法删除!");
                                	AddScript("window.setTimeout('window.parent.HidBox();',2000);");
								}
							}
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                            }
                        }
                        else if (Act == "Syn")
                        {
                            try
                            {
                                AddMsgLine("新增" + tbProductsInfo.SynErpProduct() + "条产品信息!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("同步失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',5000);");
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

			if (format == "json")
			{
				Response.ClearContent();
				Response.Buffer = true;
				Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
				Response.Expires = 0;

				Response.Charset = "utf-8";
				Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
				Response.ContentType = "application/json";
				string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"},\"data\":" + MS_Json + "}";
				Response.Write(Json_Str);
				Response.End();
			}
        }
        protected override void ShowPage()
        {
            pagetitle = " 添加修改产品信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}

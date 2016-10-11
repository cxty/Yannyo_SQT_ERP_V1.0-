using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web.Services
{
    public partial class uppic : PageBase
    {
        string eStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string Act = HTTPRequest.GetString("Act");
            int ReCode = 0;
            int CertificateID = HTTPRequest.GetInt("CertificateID", 0);
            string uCode_tem = HTTPRequest.GetString("c");
            if (uCode_tem.Trim() != "")
            {
                //username|pwd
                uCode_tem = DES.Decode(uCode_tem, config.Passwordkey);
                if (uCode_tem.Trim() != "")
                {
                    string[] uCode_temArr = Utils.SplitString(uCode_tem, "|");
                    if (uCode_temArr != null)
                    {
                        this.userid = tbUserInfo.CheckPassword(uCode_temArr[0], uCode_temArr[1], false);
                    }
                }
            }
            if (this.userid > 0)
            {
                if (Page.Request.InputStream != null)
                {
                    string PathStr = "/ufile/" + DateTime.Now.Year + "-" + DateTime.Now.Month;
                    string PicData = HTTPRequest.GetString("PicData");
                    string filestr;
                    int picsize = 0;
                    int picID = 0;

                    string sCode = Utils.GetRanDomCode();
                    string _PathStr = HttpContext.Current.Server.MapPath("/") + PathStr;
                    FileExtension[] fe = { FileExtension.GIF, FileExtension.JPG, FileExtension.PNG, FileExtension.BMP };
                    if (!Directory.Exists(_PathStr))
                    {
                        Directory.CreateDirectory(_PathStr);
                    }
                    filestr = _PathStr + "/" + sCode + ".jpg";

                    try
                    {
                        if (FileValidation.IsAllowedExtension(new MemoryStream(Convert.FromBase64String(PicData)), fe))
                        {
                            Thumbnail.SaveBmp(Thumbnail.BytesToImage(Convert.FromBase64String(PicData)), filestr);

                            FileStream stream = new FileStream(filestr, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            try
                            {
                                picsize = int.Parse(stream.Length.ToString());
                            }
                            finally
                            {
                                stream.Close();
                                stream.Dispose();
                            }
                            CertificatePicInfo cpi = new CertificatePicInfo();
                            try
                            {
                                cpi.UserID = userid;
                                cpi.cCode = Utils.GetRanDomCode();
                                cpi.CertificateID = CertificateID;
                                cpi.cPic = PathStr + "/" + sCode + ".jpg"; ;
                                cpi.cAppendTime = DateTime.Now;

                                picID = Certificates.AddCertificatePicInfo(cpi);
                                if (picID > 0)
                                {
                                    eStr = "<re picid=\"" + picID.ToString() + "\" />";
                                    ReCode = 0;
                                }
                            }
                            finally
                            {
                                cpi = null;
                            }
                        }
                        else
                        {
                            eStr = "<error>数据错误</error>";
                            ReCode = 4;
                        }

                    }
                    catch
                    {
                        try
                        {
                            HttpFileCollection files = HttpContext.Current.Request.Files;
                            try
                            {
                                if (files.Count > 0)
                                {
                                    HttpPostedFile postedFile = files[0];
                                    int upLength = postedFile.ContentLength;
                                    byte[] upArray = new Byte[upLength];
                                    Stream upStream = postedFile.InputStream;
                                    upStream.Read(upArray, 0, upLength);

                                    if (FileValidation.IsAllowedExtension(new MemoryStream(upArray), fe))
                                    {
                                        Thumbnail.SaveBmp(Thumbnail.BytesToImage(upArray), filestr);

                                        FileStream stream = new FileStream(filestr, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                        try
                                        {
                                            picsize = int.Parse(stream.Length.ToString());
                                        }
                                        finally
                                        {
                                            stream.Close();
                                            stream.Dispose();
                                        }
                                        CertificatePicInfo cpi = new CertificatePicInfo();
                                        try
                                        {
                                            cpi.UserID = userid;
                                            cpi.cCode = Utils.GetRanDomCode();
                                            cpi.CertificateID = CertificateID;
                                            cpi.cPic = PathStr + "/" + sCode + ".jpg"; ;
                                            cpi.cAppendTime = DateTime.Now;

                                            picID = Certificates.AddCertificatePicInfo(cpi);
                                            if (picID > 0)
                                            {
                                                eStr = "<re picid=\"" + picID.ToString() + "\" />";
                                                ReCode = 0;
                                            }
                                        }
                                        finally
                                        {
                                            cpi = null;
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                files = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            eStr = "<error>" + ex.Message.ToString() + "</error>";
                            ReCode = 3;
                        }
                    }
                }
                else
                {
                    eStr = "<error>数据校验失败</error>";
                    ReCode = 4;
                }
               
            }
            else {
                eStr = "<error>鉴权失败</error>";
                ReCode = 4;
            }
            ReMsg(ReCode);
        }
        public void ReMsg(int ReCode)
        {
            string MsgStr = "";
            switch (ReCode)
            {
                case 0:
                    MsgStr = "Success";
                    break;
                case 1:
                    MsgStr = "Authentication Failed";
                    break;
                case 2:
                    MsgStr = "Please Select Album";
                    break;
                case 3:
                    MsgStr = "System Error";
                    break;
                case 4:
                    MsgStr = "No data";
                    break;
            }
            Response.ClearContent();
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
            Response.Charset = "utf-8";
            Response.Expires = 0;
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.ContentType = "text/xml";
            Response.Write("<?xml version=\"1.0\" ?><root><remsg code=\"" + ReCode + "\" msg=\"" + MsgStr + "\"/>" + eStr + "</root>");
            Response.End();
        }
    }
}
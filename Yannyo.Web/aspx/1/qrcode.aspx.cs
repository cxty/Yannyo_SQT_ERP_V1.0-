using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using System.Text;
using System.Text.RegularExpressions;

namespace Yannyo.Web
{
    public partial class qrcode : PageBase
    {
        public int orderid = 0;
        public int ordertype = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = "";
            string Act = HTTPRequest.GetString("Act");
            if (Act.Trim() != "")
            {
                //对账单
                if (Act == "d")
                {
                    int msid = HTTPRequest.GetInt("msid", 0);
                    if (msid > 0)
                    {
                        MonthlyStatementInfo msi = MonthlyStatements.GetMonthlyStatementInfoModel(msid);
                        if (msi != null)
                        {
                            data = "" + config.Sysurl + "/m-" + msi.MonthlyStatementID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(msi.LastPrintDateTime.ToString() + "|" + msi.sCode, config.Passwordkey)).Trim();
                        }
                    }
                }
            }
            else
            {
                OrderInfo oi = new OrderInfo();
                orderid = HTTPRequest.GetInt("orderid", 0);
                ordertype = HTTPRequest.GetInt("ordertype", 0);
                if (orderid > 0)
                {
                    oi = Orders.GetOrderInfoModel(orderid);
                    if (oi != null)
                    {
                        data = "" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim();
                    }
                }
            }
            if (data != "")
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

                int scale = 2;
                qrCodeEncoder.QRCodeScale = scale;

                int version = 5;
                qrCodeEncoder.QRCodeVersion = version;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

                System.Drawing.Image image;

                //String data = "MEBKM:TITLE:OrderID(" + oi.oOrderNum + "),PrintTime(" + oi.LastPrintDateTime + ");URL:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim() + ";;";

                //String data = oi.oOrderNum;
                image = qrCodeEncoder.Encode(data);
                try
                {
                    byte[] bBuffer = PhotoImageInsert(image);
                    Response.ClearContent();
                    Response.ContentType = "image/jpeg";
                    Response.BinaryWrite(bBuffer);
                }
                finally
                {
                    image.Dispose();
                    Response.End();
                }
            }
        }
        public byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[]   
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
    }
}
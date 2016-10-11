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
    public partial class barcode : PageBase
    {
        public string codestr = "";
        public string codetype = "";
        public string backcolor = "";
        public string forecolor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            codestr = HTTPRequest.GetString("codestr");
            codetype = HTTPRequest.GetString("codetype");
            backcolor = HTTPRequest.GetString("backcolor");
            forecolor = HTTPRequest.GetString("forecolor");

            if (codestr.Trim() != "")
            {
                backcolor = backcolor.Trim() == "" ? "White" : backcolor.Trim();
                forecolor = forecolor.Trim() == "" ? "Black" : forecolor.Trim();

                System.Drawing.Color _BackColor = System.Drawing.Color.FromName(backcolor);
                System.Drawing.Color _ForeColor = System.Drawing.Color.FromName(forecolor);

                BarCodeLib.Barcode b = new BarCodeLib.Barcode();
                System.Drawing.Image image;
                
                BarCodeLib.TYPE type = BarCodeLib.TYPE.UNSPECIFIED;
                switch (codetype)
                {
                    case "UPC-A": 
                        type = BarCodeLib.TYPE.UPCA;
                        codestr = codestr.PadLeft(12, '0');
                        codestr = codestr.Substring(0, 12);
                        break;
                    case "UPC-A (Numbered)":
                        type = BarCodeLib.TYPE.UPCA;
                        codestr = codestr.PadLeft(12, '0');
                        codestr = codestr.Substring(0, 12);
                        break;
                    case "UPC-E": 
                        type = BarCodeLib.TYPE.UPCE; 
                        codestr = codestr.PadLeft(8, '0');
                        codestr = codestr.Substring(0, 8);
                        break;
                    case "UPC 2 Digit Ext.": type = BarCodeLib.TYPE.Interleaved2of5; break;
                    case "UPC 5 Digit Ext.": type = BarCodeLib.TYPE.Standard2of5; break;
                    case "EAN-13": 
                        type = BarCodeLib.TYPE.EAN13;
                        codestr = codestr.PadLeft(13, '0');
                        codestr = codestr.Substring(0, 13);
                        break;
                    case "EAN-8": 
                        type = BarCodeLib.TYPE.EAN8; 
                        codestr = codestr.PadLeft(8, '0');
                        codestr = codestr.Substring(0, 8);
                        break;
                    case "Codabar": type = BarCodeLib.TYPE.Codabar; break;
                    case "PostNet": type = BarCodeLib.TYPE.PostNet; break;
                    case "Bookland/ISBN": type = BarCodeLib.TYPE.BOOKLAND; break;
                    case "Code 11": type = BarCodeLib.TYPE.CODE11; break;
                    case "Code 39": type = BarCodeLib.TYPE.CODE39; break;
                    case "LOGMARS": type = BarCodeLib.TYPE.LOGMARS; break;
                    case "MSI": type = BarCodeLib.TYPE.MSI_Mod10; break;
                    case "Interleaved 2 of 5": type = BarCodeLib.TYPE.Interleaved2of5; break;
                    case "Standard 2 of 5": type = BarCodeLib.TYPE.Standard2of5; break;
                    case "Code 128": type = BarCodeLib.TYPE.CODE128; break;
                    default: type = BarCodeLib.TYPE.UPCA; break;
                }
                try
                {
                    b.RawData = codestr;

                    //Bitmap temp = new Bitmap(1, 1);
                    //temp.SetPixel(0, 0, _BackColor);
                    //image = (System.Drawing.Image)temp;

                    if (type != BarCodeLib.TYPE.UNSPECIFIED)
                    {
                        image = b.Encode(type, _ForeColor, _BackColor);

                        if (codetype == "UPC-A (Numbered)")
                        {
                            image = b.Generate_Labels(image);
                        }
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
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
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
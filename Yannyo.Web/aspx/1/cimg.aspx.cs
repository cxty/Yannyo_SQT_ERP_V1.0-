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
using System.IO;

namespace Yannyo.Web.Services
{
    public partial class cimg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CertificatePicID = HTTPRequest.GetInt("CertificatePicID", 0);
            if(CertificatePicID>0)
            {
                CertificatePicInfo cpi = Certificates.GetCertificatePicInfoModel(CertificatePicID);
                if (cpi != null)
                {
                    FileStream oFileStream;
                    long lFileSize;

                    oFileStream = new FileStream( HttpContext.Current.Server.MapPath("/")+cpi.cPic, FileMode.Open);
                    try
                    {
                        lFileSize = oFileStream.Length;

                        byte[] bBuffer = new byte[(int)lFileSize];
                        oFileStream.Read(bBuffer, 0, (int)lFileSize);
                        oFileStream.Close();
                        Response.ClearContent();
                        Response.ContentType = "image/jpeg";

                        Response.BinaryWrite(bBuffer);
                    }
                    finally
                    {
                        oFileStream.Close();
                        Response.End();
                    }
                }
            }
        }
    }
}
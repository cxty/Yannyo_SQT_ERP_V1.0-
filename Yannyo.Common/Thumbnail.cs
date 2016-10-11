using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;

namespace Yannyo.Common
{
	/// <summary>
	/// Thumbnail ��ժҪ˵����
	/// </summary>
	public class Thumbnail
	{
		private System.Drawing.Image srcImage;
		private string srcFileName;

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="FileName">ԭʼͼƬ·��</param>
		public bool SetImage(string FileName)
		{
			srcFileName = Utils.GetMapPath(FileName);
			try
			{
				srcImage = System.Drawing.Image.FromFile(srcFileName);
			}
			catch
			{
				return false;
			}
			return true;

		}

		/// <summary>
		/// �ص�
		/// </summary>
		/// <returns></returns>
		public bool ThumbnailCallback()
		{
			return false;
		}

		/// <summary>
		/// ��������ͼ,��������ͼ��Image����
		/// </summary>
		/// <param name="Width">����ͼ���</param>
		/// <param name="Height">����ͼ�߶�</param>
		/// <returns>����ͼ��Image����</returns>
		public System.Drawing.Image GetImage(int Width,int Height)
		{
			System.Drawing.Image img;
			System.Drawing.Image.GetThumbnailImageAbort callb = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback); 
 			img = srcImage.GetThumbnailImage(Width,Height,callb, IntPtr.Zero);
 			return img;
		}

		/// <summary>
		/// ��������ͼ
		/// </summary>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		public void SaveThumbnailImage(int Width,int Height)
		{
			switch(Path.GetExtension(srcFileName).ToLower())
			{
				case ".png":
					SaveImage(Width, Height, ImageFormat.Png);
					break;
				case ".gif":
					SaveImage(Width, Height, ImageFormat.Gif);
					break;
				default:
					SaveImage(Width, Height, ImageFormat.Jpeg);
					break;
			}
		}

		/// <summary>
		/// ��������ͼ������
		/// </summary>
		/// <param name="Width">����ͼ�Ŀ��</param>
		/// <param name="Height">����ͼ�ĸ߶�</param>
		/// <param name="imgformat">�����ͼ���ʽ</param>
		/// <returns>����ͼ��Image����</returns>
		public void SaveImage(int Width,int Height, ImageFormat imgformat)
		{
			if ((srcImage.Width > Width) || (srcImage.Height > Height))
			{
				
				System.Drawing.Image img;
				System.Drawing.Image.GetThumbnailImageAbort callb = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback); 
				img = srcImage.GetThumbnailImage(Width,Height,callb, IntPtr.Zero);
				srcImage.Dispose();
				img.Save(srcFileName, imgformat);
				img.Dispose();
			}
		}

		#region Helper

		/// <summary>
		/// ����ͼƬ
		/// </summary>
		/// <param name="image">Image ����</param>
		/// <param name="savePath">����·��</param>
		/// <param name="ici">ָ����ʽ�ı�������</param>
		private static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici)
		{
			//���� ԭͼƬ ����� EncoderParameters ����
			EncoderParameters parameters = new EncoderParameters(1);
			parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long) 100));
			image.Save(savePath, ici, parameters);
			parameters.Dispose();
		}

		/// <summary>
		/// ��ȡͼ���������������������Ϣ
		/// </summary>
		/// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) ���͵��ַ���</param>
		/// <returns>����ͼ���������������������Ϣ</returns>
		private static ImageCodecInfo GetCodecInfo(string mimeType)
		{
			ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
			foreach(ImageCodecInfo ici in CodecInfo)
			{
				if(ici.MimeType == mimeType)return ici;
			}
			return null;
		}

		/// <summary>
		/// �����³ߴ�
		/// </summary>
		/// <param name="width">ԭʼ���</param>
		/// <param name="height">ԭʼ�߶�</param>
		/// <param name="maxWidth">����¿��</param>
		/// <param name="maxHeight">����¸߶�</param>
		/// <returns></returns>
		private static Size ResizeImage(int width, int height, int maxWidth, int maxHeight)
		{
			decimal MAX_WIDTH = (decimal)maxWidth;
			decimal MAX_HEIGHT = (decimal)maxHeight;
			decimal ASPECT_RATIO = MAX_WIDTH / MAX_HEIGHT;

			int newWidth, newHeight;

			decimal originalWidth = (decimal)width;
			decimal originalHeight = (decimal)height;
			
			if (originalWidth > MAX_WIDTH || originalHeight > MAX_HEIGHT) 
			{
				decimal factor;
				// determine the largest factor 
				if (originalWidth / originalHeight > ASPECT_RATIO) 
				{
					factor = originalWidth / MAX_WIDTH;
					newWidth = Convert.ToInt32(originalWidth / factor);
					newHeight = Convert.ToInt32(originalHeight / factor);
				} 
				else 
				{
					factor = originalHeight / MAX_HEIGHT;
					newWidth = Convert.ToInt32(originalWidth / factor);
					newHeight = Convert.ToInt32(originalHeight / factor);
				}	  
			} 
			else 
			{
				newWidth = width;
				newHeight = height;
			}

			return new Size(newWidth,newHeight);
			
		}

		/// <summary>
		/// �õ�ͼƬ��ʽ
		/// </summary>
		/// <param name="name">�ļ�����</param>
		/// <returns></returns>
		public static ImageFormat GetFormat(string name)
		{
			string ext = name.Substring(name.LastIndexOf(".") + 1);
			switch(ext.ToLower())
			{
				case "jpg":
				case "jpeg":
					return ImageFormat.Jpeg;
				case "bmp":
					return ImageFormat.Bmp;
				case "png":
					return ImageFormat.Png;
				case "gif":
					return ImageFormat.Gif;
				default:
					return ImageFormat.Jpeg;
			}
		}
		#endregion

		/// <summary>
		/// ����С������
		/// </summary>
		/// <param name="fileName">ԭͼ���ļ�·��</param>
		/// <param name="newFileName">�µ�ַ</param>
		/// <param name="newSize">���Ȼ���</param>
		public static void MakeSquareImage(string fileName, string newFileName, int newSize)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);
	
			int i = 0;
			int width = image.Width;
			int height = image.Height;
			if (width > height)
			{
				i = height;
			}
			else
			{
				i = width;
			}
			Bitmap b = new Bitmap(newSize, newSize);

			try
			{
				Graphics g = Graphics.FromImage(b);
				g.InterpolationMode = InterpolationMode.High;
				g.SmoothingMode = SmoothingMode.HighQuality;

				//���������ͼ�沢��͸������ɫ���
				g.Clear(Color.Transparent);
				if (width < height)
				{
					g.DrawImage(image,  new Rectangle(0, 0, newSize, newSize), new Rectangle(0, (height-width)/2, width, width), GraphicsUnit.Pixel);
				}
				else
				{
					g.DrawImage(image, new Rectangle(0, 0, newSize, newSize), new Rectangle((width-height)/2, 0, height, height), GraphicsUnit.Pixel);
				}

                SaveImage(b, newFileName, GetCodecInfo("image/" + GetFormat(fileName).ToString().ToLower()));
			}
			finally
			{
				image.Dispose();
				b.Dispose();
			}
	
		}


		/// <summary>
		/// ��������ͼ
		/// </summary>
		/// <param name="fileName">ԭͼ·��</param>
		/// <param name="newFileName">��ͼ·��</param>
		/// <param name="maxWidth">�����</param>
		/// <param name="maxHeight">���߶�</param>
		public static void MakeThumbnailImage(string fileName, string newFileName, int maxWidth, int maxHeight)
		{
			System.Drawing.Image original = System.Drawing.Image.FromFile(fileName);

			Size _newSize = ResizeImage(original.Width,original.Height,maxWidth, maxHeight);
			//_image.Height = _newSize.Height;
			//_image.Width = _newSize.Width;
			System.Drawing.Image displayImage = new Bitmap(original,_newSize);
			//original.Dispose();

			try
			{
				displayImage.Save(newFileName, GetFormat(fileName));   
			}
			finally
			{
				original.Dispose();
			}
	
		}

        /// <SUMMARY>
        /// ͼƬ��������
        /// </SUMMARY>
        /// <PARAM name="sourceFile">ͼƬԴ·��</PARAM>
        /// <PARAM name="destFile">���ź�ͼƬ���·��</PARAM>
        /// <PARAM name="destHeight">���ź�ͼƬ�߶�</PARAM>
        /// <PARAM name="destWidth">���ź�ͼƬ���</PARAM>
        /// <RETURNS></RETURNS>
        public static bool GetThumbnail(string sourceFile, string destFile, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = System.Drawing.Image.FromFile(sourceFile);
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // ����������
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;

            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }

            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.WhiteSmoke);

            // ���û������������
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            // ���´���Ϊ����ͼƬʱ������ѹ������
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;

            try
            {
                //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x];//����JPEG����
                        break;
                    }
                }

                if (jpegICI != null)
                {
                    outBmp.Save(destFile, jpegICI, encoderParams);
                }
                else
                {
                    outBmp.Save(destFile, thisFormat);
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                imgSource.Dispose();
                outBmp.Dispose();
            }
        }


        public static System.Drawing.Bitmap BuildBitmap(int width, int height, string strBmp)
        {
            System.Drawing.Bitmap tmpBmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            string[] StmpBmp = strBmp.Split(',');
            int pos = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tmpBmp.SetPixel(x, y, Color.FromArgb(int.Parse(StmpBmp[pos], System.Globalization.NumberStyles.HexNumber)));
                    pos++;
                }
            }
            return tmpBmp;
        }

        public static System.Drawing.Bitmap Base64StringToImage(string strBmp)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strBmp);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                try
                {
                    return bmp;
                }
                finally
                {
                    arr = null;
                    ms.Dispose();
                    bmp.Dispose();
                }
            }
            catch
            { 
                return null;
            }
        }

        public static System.Drawing.Bitmap BytesToImage(byte[] arr)
        {
            try
            {
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                return bmp;
            }
            catch
            {
                return null;
            }
        }

        public static void SaveBmp(System.Drawing.Bitmap bmp, string filePathandName)
        {
            try
            {
                bmp.Save(filePathandName, System.Drawing.Imaging.ImageFormat.Bmp);
                bmp.Dispose();
            }
            catch
            {
                bmp.Dispose();
            }
        }

        /// <summary>
        /// ����ת��
        /// </summary>
        public static string ConvertString(string value, int fromBase, int toBase)
        {

            int intValue = Convert.ToInt32(value, fromBase);

            return Convert.ToString(intValue, toBase);
        }
	}

    /// <summary>
    /// �ļ�������֤
    /// </summary>
    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        PNG = 13780,
        SWF = 6787,
        RAR = 8297,
        ZIP = 8075,
        _7Z = 55122,
        BMP = 6677

        // 6787 swf

        // 7790 exe dll,

        // 8297 rar

        // 8075 zip

        // 55122 7z

        // 6063 xml

        // 6033 html

        // 239187 aspx

        // 117115 cs

        // 119105 js

        // 102100 txt

        // 255254 sql 

    }

    public class FileValidation
    {
        public static bool IsAllowedExtension(MemoryStream ms, FileExtension[] fileEx)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
            }
            br.Close();
            ms.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe)
                    return true;
            }
            return false;
        }
        public static bool IsAllowedExtension(FileUpload fu, FileExtension[] fileEx)
        {
            int fileLen = fu.PostedFile.ContentLength;
            byte[] imgArray = new byte[fileLen];
            fu.PostedFile.InputStream.Read(imgArray, 0, fileLen);
            MemoryStream ms = new MemoryStream(imgArray);
            System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
            }
            br.Close();
            ms.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe)
                    return true;
            }
            return false;
        }
        public static bool IsAllowedExtension(HttpPostedFile pu, FileExtension[] fileEx)
        {
            int fileLen = pu.ContentLength;
            byte[] imgArray = new byte[fileLen];
            pu.InputStream.Read(imgArray, 0, fileLen);
            MemoryStream ms = new MemoryStream(imgArray);
            System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
            }
            br.Close();
            ms.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe)
                    return true;
            }
            return false;
        }
    }
}

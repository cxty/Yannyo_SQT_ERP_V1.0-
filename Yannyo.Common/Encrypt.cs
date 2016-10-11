using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Yannyo.Common;
 
namespace Yannyo.Common
{ 
	/// <summary> 
	/// ����
	/// </summary> 
	public class AES
	{ 


		//Ĭ����Կ����
		//private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
		private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };
		/// <summary>
		/// DES�����ַ���
		/// </summary>
		/// <param name="encryptString">�����ܵ��ַ���</param>
		/// <param name="encryptKey">������Կ,Ҫ��Ϊ8λ</param>
		/// <returns>���ܳɹ����ؼ��ܺ���ַ���,ʧ�ܷ���Դ��</returns>
//		public static string Encode(string encryptString, string encryptKey)
//		{
//			encryptKey = Utils.GetSubString(encryptKey, 8, "");
//			encryptKey = encryptKey.PadRight(8, ' ');
//			byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
//			byte[] rgbIV = Keys;
//			byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
//			DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
//			MemoryStream mStream = new MemoryStream();
//			CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//			cStream.Write(inputByteArray, 0, inputByteArray.Length);
//			cStream.FlushFinalBlock();
//			return Convert.ToBase64String(mStream.ToArray());
//
//		}

		public static string Encode(string encryptString, string encryptKey)
		{
			encryptKey = Utils.GetSubString(encryptKey, 32, "");
			encryptKey = encryptKey.PadRight(32, ' ');

			RijndaelManaged rijndaelProvider = new RijndaelManaged();
			rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
			rijndaelProvider.IV = Keys;
			ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();
 
			byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
			byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData,0,inputData.Length);

			return Convert.ToBase64String(encryptedData);
		}

		/// <summary>
		/// DES�����ַ���
		/// </summary>
		/// <param name="decryptString">�����ܵ��ַ���</param>
		/// <param name="decryptKey">������Կ,Ҫ��Ϊ8λ,�ͼ�����Կ��ͬ</param>
		/// <returns>���ܳɹ����ؽ��ܺ���ַ���,ʧ�ܷ�Դ��</returns>
//		public static string Decode(string decryptString, string decryptKey)
//		{
//			try
//			{
//				decryptKey = Utils.GetSubString(decryptKey, 8, "");
//				decryptKey = decryptKey.PadRight(8, ' ');
//				byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
//				byte[] rgbIV = Keys;
//				byte[] inputByteArray = Convert.FromBase64String(decryptString);
//				DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
//
//				MemoryStream mStream = new MemoryStream();
//				CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//				cStream.Write(inputByteArray, 0, inputByteArray.Length);
//				cStream.FlushFinalBlock();
//				return Encoding.UTF8.GetString(mStream.ToArray());
//			}
//			catch
//			{
//				return "";
//			}
//
//		}

		public static string Decode(string decryptString, string decryptKey)
		{
			try
			{
				decryptKey = Utils.GetSubString(decryptKey, 32, "");
				decryptKey = decryptKey.PadRight(32, ' ');

				RijndaelManaged rijndaelProvider = new RijndaelManaged();
				rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
				rijndaelProvider.IV = Keys;
				ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();
 
				byte[] inputData = Convert.FromBase64String(decryptString);
				byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData,0,inputData.Length);

				return Encoding.UTF8.GetString(decryptedData);
			}
			catch
			{
				return "";
			}

		}

	}

	/// <summary> 
	/// ����
	/// </summary> 
	public class DES
	{ 


		//Ĭ����Կ����
		private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
		
		
		/// <summary>
		/// DES�����ַ���
		/// </summary>
		/// <param name="encryptString">�����ܵ��ַ���</param>
		/// <param name="encryptKey">������Կ,Ҫ��Ϊ8λ</param>
		/// <returns>���ܳɹ����ؼ��ܺ���ַ���,ʧ�ܷ���Դ��</returns>
		public static string Encode(string encryptString, string encryptKey)
		{
			encryptKey = Utils.GetSubString(encryptKey, 8, "");
			encryptKey = encryptKey.PadRight(8, ' ');
			byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
			byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
			DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
			MemoryStream mStream = new MemoryStream();
			CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
			cStream.Write(inputByteArray, 0, inputByteArray.Length);
			cStream.FlushFinalBlock();

			return Convert.ToBase64String(mStream.ToArray());
		}

		/// <summary>
		/// DES�����ַ���
		/// </summary>
		/// <param name="decryptString">�����ܵ��ַ���</param>
		/// <param name="decryptKey">������Կ,Ҫ��Ϊ8λ,�ͼ�����Կ��ͬ</param>
		/// <returns>���ܳɹ����ؽ��ܺ���ַ���,ʧ�ܷ�Դ��</returns>
		public static string Decode(string decryptString, string decryptKey)
		{
			try
			{
				decryptKey = Utils.GetSubString(decryptKey, 8, "");
				decryptKey = decryptKey.PadRight(8, ' ');
				byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Encoding.UTF8.GetBytes(decryptKey);
				byte[] inputByteArray = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
		
				MemoryStream mStream = new MemoryStream();
				CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(mStream.ToArray());
			}
			catch
			{
				return "";
			}
		}
	}

    public class DES_Base64
    {
        /// <summary>
        /// DES + Base64 ����
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>�Ѽ����ַ���</returns>
        public static string DesBase64Encrypt(string input, string decryptKey)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.ECB;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = Encoding.UTF8.GetBytes(decryptKey);
            byte[] IV = Encoding.UTF8.GetBytes(decryptKey);

            ct = des.CreateEncryptor(Key, IV);

            byt = Encoding.GetEncoding("GB2312").GetBytes(input); //���� GB2312 ������ַ�������ת���� byte ����

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            byte[] answer = ms.ToArray();
            for (int j = 0; j < answer.Length; j++)
            {
                Console.Write(answer[j].ToString() + " ");
            }
            Console.WriteLine();
            return Convert.ToBase64String(ms.ToArray()); // �����ܵ� byte �������� Base64 ����ת�����ַ���
        }

        /**/
        /// <summary>
        /// DES + Base64 ����
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>�����ַ���</returns>
        public static string DesBase64Decrypt(string input, string decryptKey)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.ECB;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = Encoding.UTF8.GetBytes(decryptKey);
            byte[] IV = Encoding.UTF8.GetBytes(decryptKey);

            ct = des.CreateDecryptor(Key, IV);
            byt = Convert.FromBase64String(input); // �� ���� �� Base64 ����ת���� byte ����

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.GetEncoding("GB2312").GetString(ms.ToArray()); // �� ���� �� GB2312 ����ת�����ַ���
        }
    }

}
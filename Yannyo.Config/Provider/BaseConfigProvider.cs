using System;
using System.IO;
using System.Web;
using Yannyo.Common;

namespace Yannyo.Config.Provider
{
	public class BaseConfigProvider
	{
		private BaseConfigProvider()
		{
		}

		static BaseConfigProvider()
		{
			config = GetRealBaseConfig();
		}

		private static BaseConfigInfo config = null;

		/// <summary>
		/// ��ȡ��������ʵ��
		/// </summary>
		/// <returns></returns>
		public static BaseConfigInfo Instance()
		{
			return config;
		}

		/// <summary>
		/// ���ö���ʵ��
		/// </summary>
		/// <param name="anConfig"></param>
		public static void SetInstance(BaseConfigInfo anConfig)
		{
			if (anConfig == null)
				return;
			config = anConfig;
		}

		/// <summary>
		/// ��ȡ��ʵ�������ö���
		/// </summary>
		/// <returns></returns>
		public static BaseConfigInfo GetRealBaseConfig()
		{
			BaseConfigInfo newBaseConfig = null;
            string filename = BaseConfigFileManager.ConfigFilePath;
			try
			{
				newBaseConfig = (BaseConfigInfo)SerializationHelper.Load(typeof(BaseConfigInfo), filename);
			}
			catch
			{
				newBaseConfig = null;
			}
			
			if (newBaseConfig == null)
			{
				try
				{
					BaseConfigInfoCollection bcc = (BaseConfigInfoCollection)SerializationHelper.Load(typeof(BaseConfigInfoCollection), filename);
					foreach (BaseConfigInfo bc in bcc)
					{
						if (Utils.GetTrueSysPath() == bc.Syspath)
						{
							newBaseConfig = bc;
							break;
						}
					}
					if (newBaseConfig == null)
					{
						BaseConfigInfo rootConfig = null;
						foreach (BaseConfigInfo bc in bcc)
						{
                            if (Utils.GetTrueSysPath().StartsWith(bc.Syspath) && bc.Syspath != "/")
							{
								newBaseConfig = bc;
								break;
							}
                            if (("/").Equals(bc.Syspath))
							{
								rootConfig = bc;
							}
						}
						if (newBaseConfig == null)
						{
							newBaseConfig = rootConfig;
						}
					}

				}
				catch
				{
					newBaseConfig = null;
				}
			}
			if (newBaseConfig == null) 
			{
                throw new Exception("��������: ����Ŀ¼����վ��Ŀ¼��û����ȷ��Yannyo.config�ļ�������û�����л�Ȩ��");
			}
			return newBaseConfig;

		}


	}
}

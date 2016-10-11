using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;

using Yannyo.Entity;
using Yannyo.Common;
using Yannyo.Config;

namespace Yannyo.SOAP
{
    public class WeatherWebService
    {
        /// <summary>
        /// 获取SOAP实例
        /// </summary>
        public static object GetSOAP()
        {
            WeatherWebServiceRe.WeatherWebService pp = new WeatherWebServiceRe.WeatherWebService();
            pp.Url = GeneralConfigs.GetConfig().WeatherWebServiceURL.Trim();
            return pp;
        }

        public static Weather getWeatherbyCityName(string CityName)
        {
            Weather w = new Weather();
            WeatherWebServiceRe.WeatherWebService pp = (WeatherWebServiceRe.WeatherWebService)GetSOAP();
            try
            {
                try
                {
                    string[] tCityWeatherArr = pp.getWeatherbyCityName(CityName);
                    if (tCityWeatherArr.Length > 0)
                    {
                        w.Province = tCityWeatherArr[0].ToString();// 省份
                        w.City = tCityWeatherArr[1].ToString();//城市
                        w.CityCode = tCityWeatherArr[2].ToString();//城市代码
                        w.CityImage = tCityWeatherArr[3].ToString();//城市图片名称
                        w.LastUpdateTime = tCityWeatherArr[4].ToString();//最后更新时间
                        w.Temperature = tCityWeatherArr[5].ToString();//当天的 气温
                        w.Overview = tCityWeatherArr[6].ToString();//概况
                        w.Wind = tCityWeatherArr[7].ToString();//风向和风力
                        w.IconsA = tCityWeatherArr[8].ToString();//天气趋势开始图片名称(以下称：图标一)
                        w.IconsB = tCityWeatherArr[9].ToString();//天气趋势结束图片名称(以下称：图标二)
                        w.Weathers = tCityWeatherArr[10].ToString();//现在的天气实况
                        w.LivingIndex = tCityWeatherArr[11].ToString();//天气和生活指数
                        w.NextDayTemperature = tCityWeatherArr[12].ToString();//第二天的 气温
                        w.NextDayOverview = tCityWeatherArr[13].ToString();//概况
                        w.NextDayWind = tCityWeatherArr[14].ToString();// 风向和风力
                        w.NextDayIconsA = tCityWeatherArr[15].ToString();//图标一
                        w.NextDayIconsB = tCityWeatherArr[16].ToString();//图标二
                        w.ThirdDayTemperature = tCityWeatherArr[17].ToString();// 第三天的 气温
                        w.ThirdDayOverview = tCityWeatherArr[18].ToString();//概况
                        w.ThirdDayWind = tCityWeatherArr[19].ToString();//风向和风力
                        w.ThirdDayIconsA = tCityWeatherArr[20].ToString();//图标一
                        w.ThirdDayIconsB = tCityWeatherArr[21].ToString();//图标二
                        w.Introduction = tCityWeatherArr[22].ToString();//城市或地区的介绍
                    }
                }
                catch { 
                
                }
            }
            finally
            {
                pp = null;
            }
            return w;
        }
    }
}

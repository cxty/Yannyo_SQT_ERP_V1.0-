using System;

namespace Yannyo.Entity
{
    public class Weather
    {
        private string _Province="";// 省份
        private string _City="";//城市
        private string _CityCode="";//城市代码
        private string _CityImage="";//城市图片名称
        private string _LastUpdateTime ="";//最后更新时间
        private string _Temperature = "";//当天的 气温
        private string _Overview = "";//概况
        private string _Wind = "";//风向和风力
        private string _IconsA = "";//天气趋势开始图片名称(以下称：图标一)
        private string _IconsB = "";//天气趋势结束图片名称(以下称：图标二)
        private string _Weather = "";//现在的天气实况
        private string _LivingIndex ="";//天气和生活指数
        private string _NextDayTemperature  = "";//第二天的 气温
        private string _NextDayOverview = "";//概况
        private string _NextDayWind="";// 风向和风力
        private string _NextDayIconsA = "";//图标一
        private string _NextDayIconsB = "";//图标二
        private string _ThirdDayTemperature  = "";// 第三天的 气温
        private string _ThirdDayOverview = "";//概况
        private string _ThirdDayWind="";//风向和风力
        private string _ThirdDayIconsA = "";//图标一
        private string _ThirdDayIconsB = "";//图标二
        private string _Introduction = "";//城市或地区的介绍

        /// <summary>
        /// 省份
        /// </summary>
        public string Province
        {
            set { _Province = value; }
            get { return _Province; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _City = value; }
            get { return _City; }
        }
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityCode
        {
            set { _CityCode = value; }
            get { return _CityCode; }
        }
        /// <summary>
        /// 城市图片名称
        /// </summary>
        public string CityImage
        {
            set { _CityImage = value; }
            get { return _CityImage; }
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string LastUpdateTime
        {
            set { _LastUpdateTime = value; }
            get { return _LastUpdateTime; }
        }
        /// <summary>
        /// 当天的 气温
        /// </summary>
        public string Temperature
        {
            set { _Temperature = value; }
            get { return _Temperature; }
        }
        /// <summary>
        /// 概况
        /// </summary>
        public string Overview
        {
            set { _Overview = value; }
            get { return _Overview; }
        }
        /// <summary>
        /// 风向和风力
        /// </summary>
        public string Wind
        {
            set { _Wind = value; }
            get { return _Wind; }
        }
        /// <summary>
        /// 天气趋势开始图片名称
        /// </summary>
        public string IconsA
        {
            set { _IconsA = value; }
            get { return _IconsA; }
        }
        /// <summary>
        /// 天气趋势结束图片名称
        /// </summary>
        public string IconsB
        {
            set { _IconsB = value; }
            get { return _IconsB; }
        }
        /// <summary>
        /// 现在的天气实况
        /// </summary>
        public string Weathers
        {
            set { _Weather = value; }
            get { return _Weather; }
        }
        /// <summary>
        /// 天气和生活指数
        /// </summary>
        public string LivingIndex
        {
            set { _LivingIndex = value; }
            get { return _LivingIndex; }
        }
        /// <summary>
        /// 第二天的 气温
        /// </summary>
        public string NextDayTemperature
        {
            set { _NextDayTemperature = value; }
            get { return _NextDayTemperature; }
        }
        /// <summary>
        /// 概况
        /// </summary>
        public string NextDayOverview
        {
            set { _NextDayOverview = value; }
            get { return _NextDayOverview; }
        }
        /// <summary>
        /// 风向和风力
        /// </summary>
        public string NextDayWind
        {
            set { _NextDayWind = value; }
            get { return _NextDayWind; }
        }
        /// <summary>
        /// 图标一
        /// </summary>
        public string NextDayIconsA
        {
            set { _NextDayIconsA = value; }
            get { return _NextDayIconsA; }
        }
        /// <summary>
        /// 图标二
        /// </summary>
        public string NextDayIconsB
        {
            set { _NextDayIconsB = value; }
            get { return _NextDayIconsB; }
        }
        /// <summary>
        /// 第三天的 气温
        /// </summary>
        public string ThirdDayTemperature
        {
            set { _ThirdDayTemperature = value; }
            get { return _ThirdDayTemperature; }
        }
        /// <summary>
        /// 概况
        /// </summary>
        public string ThirdDayOverview
        {
            set { _ThirdDayOverview = value; }
            get { return _ThirdDayOverview; }
        }
        /// <summary>
        /// 风向和风力
        /// </summary>
        public string ThirdDayWind
        {
            set { _ThirdDayWind = value; }
            get { return _ThirdDayWind; }
        }
        /// <summary>
        /// 图标一
        /// </summary>
        public string ThirdDayIconsA
        {
            set { _ThirdDayIconsA = value; }
            get { return _ThirdDayIconsA; }
        }
        /// <summary>
        /// 图标二
        /// </summary>
        public string ThirdDayIconsB
        {
            set { _ThirdDayIconsB = value; }
            get { return _ThirdDayIconsB; }
        }
        /// <summary>
        /// 城市或地区的介绍
        /// </summary>
        public string Introduction
        {
            set { _Introduction = value; }
            get { return _Introduction; }
        }

    }
}

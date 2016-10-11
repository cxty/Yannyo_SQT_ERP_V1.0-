using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Yannyo.Config;
using Yannyo.Common;

namespace Yannyo.Cache
{
    public class JSCache
    {
        public static string GetJsCodeByCache(string f)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string jscode = cache.RetrieveObject("/Sys/js_" + Utils.MD5(f)) as string;

            if (jscode == null)
            {
                jscode = GetJsCodeByFile(f);

                cache.AddObject("/Sys/js_" + Utils.MD5(f), jscode);
            }
            return jscode;
        }
        public static string GetJsCodeByFile(string f)
        {
            string jscode = "";
            StreamReader sr = new StreamReader(Utils.GetMapPath("/public/js/" + f + ".js"), System.Text.UTF8Encoding.UTF8);
            JavaScriptMinifier jss = new JavaScriptMinifier();
            string sw = "";
            try
            {
                jss.Minify(sr.ReadToEnd(), out sw);
                jscode = sw;
            }
            finally
            {
                jss = null;
                sr.Close();
                sr.Dispose();
            }
            return jscode;
        }
    }
}

using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;

namespace Yannyo.BLL
{
    public class tbRegionInfo
    {
        #region  RegionInfo
        /// <summary>
        /// 获得区域子节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        public static string getRegionChildrenCount(string kid)
        {
            return DatabaseProvider.GetInstance().getRegionChildrenCount(kid);
        }

        public static DataTable geAreaClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().geAreaClassList(ParentID);
        }

        public static DataTable GetAreaDetails(int AreaClassID)
        {
            return DatabaseProvider.GetInstance().GetAreaDetails(AreaClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsRegionInfo(string rName, int rUpID)
        {
            return DatabaseProvider.GetInstance().ExistsRegionInfo( rName,  rUpID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddRegionInfo(RegionInfo model)
        {
            return DatabaseProvider.GetInstance().AddRegionInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateRegionInfo(RegionInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateRegionInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int DeleteRegionInfo(int RegionID)
        {
            return DatabaseProvider.GetInstance().DeleteRegionInfo(RegionID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static RegionInfo GetRegionInfoModel(int RegionID)
        {
            return DatabaseProvider.GetInstance().GetRegionInfoModel(RegionID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static RegionInfo GetRegionInfoModelByName(string rName)
        {
            return DatabaseProvider.GetInstance().GetRegionInfoModelByName(rName);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static RegionInfo GetRegionInfoModelLikeName(string rName)
        {
            return DatabaseProvider.GetInstance().GetRegionInfoModelLikeName(rName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetRegionInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetRegionInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetRegionInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetRegionInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="sCID">源</param>
        /// <param name="tCID">目标</param>
        /// <param name="nCIDstr">排序后的目标同级ID串</param>
        /// <param name="pCID">目标父级编号</param>
        public static void UpdateRegionOrder(string sCID, string tCID, string nCIDstr, string pCID)
        {
            DatabaseProvider.GetInstance().UpdateRegionOrder(sCID, tCID, nCIDstr, pCID);
        }

        /// <summary>
        /// 获取分类的xml列表
        /// </summary>
        public static string GetRegionListToXML()
        {
            string ReXML = "";
            DataSet ds = new DataSet();
            try
            {
                ds = GetRegionInfoList(" RegionID>0 order by rOrder asc");
                if (ds.Tables.Count > 0)
                {
                    ReXML = GetRegionListToXML_Loop(ds.Tables[0], 0);
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            return ReXML;
        }
        /// <summary>
        /// 获取分类的xml列表
        /// </summary>
        public static string GetRegionListToXML(int PaterID)
        {
            string ReXML = "";
            DataSet ds = new DataSet();
            try
            {
                ds = GetRegionInfoList(" RegionID>0 order by rOrder asc");
                if (ds.Tables.Count > 0)
                {
                    ReXML = GetRegionListToXML_Loop(ds.Tables[0], PaterID);
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            return ReXML;
        }
        public static string GetRegionListToXML_Loop(DataTable DT, int bvPaterID)
        {
            string Rss_XML = "";
            for (int j = 0; j <= DT.Rows.Count - 1; j++)
            {
                if (int.Parse(DT.Rows[j]["rUpID"].ToString()) == bvPaterID)
                {
                    Rss_XML += "<Region_List>" +
                        "<RegionID>" + DT.Rows[j]["RegionID"].ToString() + "</RegionID>" +
                        "<rName><![CDATA[" + DT.Rows[j]["rName"].ToString() + "]]></rName>" +
                        "<rUpID><![CDATA[" + DT.Rows[j]["rUpID"].ToString() + "]]></rUpID>" +
                        "<rOrder><![CDATA[" + DT.Rows[j]["rOrder"].ToString() + "]]></rOrder>" +
                        "<rState><![CDATA[" + DT.Rows[j]["rState"].ToString() + "]]></rState>" +
                        "<rAppendTime><![CDATA[" + DT.Rows[j]["rAppendTime"].ToString() + "]]></rAppendTime>" +
                        GetRegionListToXML_Loop(DT, int.Parse(DT.Rows[j]["RegionID"].ToString())) +
                        "</Region_List>";
                }
            }
            return Rss_XML;
        }
        /// <summary>
        /// 获取指定数据定义属性值的子孙编号集合
        /// </summary>
        public static string GetRegionChildrenStr(int RegionID)
        {
            return UsersUtils.GetDataFieldStr("tbRegionInfo", "RegionID", "rUpID", RegionID, "");
        }
        /// <summary>
        /// 获取所有父列表
        /// </summary>
        public static string GetRegionPaterStr(int RegionID)
        {
            return UsersUtils.GetDataFieldStr("tbRegionInfo", "rName", "rUpID", "RegionID", RegionID, "");
        }
        #endregion
    }
}

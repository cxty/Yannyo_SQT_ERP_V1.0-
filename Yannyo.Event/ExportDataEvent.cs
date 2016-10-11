using System;
using System.Collections.Generic;
using System.Text;
using Yannyo.BLL;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Public;
using Yannyo.Public.ScheduledEvents;
using System.Data;
using System.Threading;

namespace Yannyo.Event
{
    public class ExportDataEvent : IEvent
    {
        public void Execute(object state)
        {
            //执行计划任务

            //每日早上5点执行,时间点为当前时间减1天

            //同步数据进入SCM系统
            GeneralConfigInfo _config = new GeneralConfigInfo();
            _config = GeneralConfigs.GetConfig();

            if (_config.DBO_CompanyID.Trim() != "" && _config.DBO_ErpSys.Trim() != "" && _config.DBO_AppID.Trim() != "" && _config.DBO_AppKey.Trim() != "" && _config.DBO_API.Trim()!="")
            {
                //Orders.SyncData2SCM();
            }

            DataTable dt = new DataTable();

            dt = tbDataToMailInfo.GetDataToMailInfoList(" dState=0 ").Tables[0];

            //执行统计数据导出并发送邮件
            DateTime now = DateTime.Now;
            //每周第一天
            DateTime startWeek = now.AddDays(1 - Convert.ToInt32(now.DayOfWeek.ToString("d")));
            //每月第一天
            DateTime startMonth = now.AddDays(1 - now.Day);

			DateTime _getDateTime = (now.Hour<=8)?DateTime.Now.AddDays(-1):DateTime.Now;

            foreach (DataRow dr in dt.Rows)
            {
                //日计划
                if (Convert.ToInt32(dr["dDateType"].ToString()) == 1)
                {
                    //客户销售数据_分解
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 1)
                    {
						DataUtils.getStorageSalesDetails(1, (_getDateTime).ToString("yyyy-MM-dd"), 0, dr["dEmail"].ToString());
                        

						DataUtils.getStorageSalesDetails(2, (_getDateTime).ToString("yyyy-MM-dd"), 0, dr["dEmail"].ToString());
                        

						DataUtils.getStorageSalesDetails(3, (_getDateTime).ToString("yyyy-MM-dd"), 0, dr["dEmail"].ToString());
                        

						DataUtils.getStorageSalesDetails(4, (_getDateTime).ToString("yyyy-MM-dd"), 0, dr["dEmail"].ToString());
                        

                        DataUtils.getStorageSalesDetails(5, (_getDateTime).ToString("yyyy-MM-dd"), 0, dr["dEmail"].ToString());
                        
                    }
                    //联营库存数据_分解
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 2)
                    {
                        DataUtils.getJointInventoryDetails(_getDateTime, 0, 1, dr["dEmail"].ToString());
                        
                    }
                    //仓库库存数据_分解
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 5)
                    {
                        DataUtils.getStockDetails(dr["dEmail"].ToString(), 0, _getDateTime, 0);
                        
                    }

                    //客户销售数据_打包
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 6)
                    {
                        DataUtils.getStorageSalesDetails_ToMail((_getDateTime).ToString("yyyy-MM-dd"), dr["dEmail"].ToString());
                        
                    }
                    //联营库存数据_打包
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 7)
                    {
                        DataUtils.getJointInventoryDetails_ToMail(_getDateTime, 1, dr["dEmail"].ToString());
                        
                    }
                    //公司销售数据_打包
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 8)
                    {
                        DataUtils.getIslandSalesDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                        
                    }
                    //公司出货数据_打包
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 9)
                    {
                        DataUtils.getIslandShipmentDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                        
                    }
                    //仓库库存数据_打包
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 10)
                    {
                        DataUtils.getStockDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                        
                    }

                    //客户销售,联营库存,公司销售,公司出货,仓库库存
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 11)
                    {
                        DataUtils.getAll_ToMail(_getDateTime, dr["dEmail"].ToString());
                    }

                    //仓库库存分仓库单独文件
                    if (Convert.ToInt32(dr["dDataType"].ToString()) == 12)
                    {
                        DataUtils.getStockDetails_all_file(dr["dEmail"].ToString(), _getDateTime);
                    }

					//仓库库存实时数据_多仓库单表单文件
					if (Convert.ToInt32 (dr ["dDataType"].ToString ()) == 13) {
						DataUtils.getStockDetails_all_file_oneTable(dr["dEmail"].ToString(), _getDateTime);
					}
                }
                
                //周计划
                if (Convert.ToInt32(dr["dDateType"].ToString()) == 2)
                {
                    if (now == startWeek)
                    {
                        //客户销售数据
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 1)
                        {
                            DataUtils.getStorageSalesDetails(1, (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd"), 1, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(2, (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd"), 1, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(3, (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd"), 1, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(4, (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd"), 1, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(5, (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd"), 1, dr["dEmail"].ToString());
                            
                        }

                        //客户销售数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 6)
                        {
                            DataUtils.getStorageSalesDetails_ToMail((_getDateTime).ToString("yyyy-MM-dd"), dr["dEmail"].ToString());
                            
                        }
                        //联营库存数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 7)
                        {
                            DataUtils.getJointInventoryDetails_ToMail(_getDateTime, 1, dr["dEmail"].ToString());
                            
                        }
                        //公司销售数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 8)
                        {
                            DataUtils.getIslandSalesDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //公司出货数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 9)
                        {
                            DataUtils.getIslandShipmentDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //仓库库存数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 10)
                        {
                            DataUtils.getStockDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //客户销售,联营库存,公司销售,公司出货,仓库库存
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 11)
                        {
                            DataUtils.getAll_ToMail(_getDateTime, dr["dEmail"].ToString());
                        }
                    }
                }
                
                //月计划
                if (Convert.ToInt32(dr["dDateType"].ToString()) == 3)
                {
                    if (now == startMonth)
                    {
                        //客户销售数据
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 1)
                        {
                            DataUtils.getStorageSalesDetails(1, (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd"), 2, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(2, (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd"), 2, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(3, (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd"), 2, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(4, (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd"), 2, dr["dEmail"].ToString());
                            

                            DataUtils.getStorageSalesDetails(5, (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd"), 2, dr["dEmail"].ToString());
                            
                        }
                        //公司销售数据
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 3)
                        {
                            DataUtils.getIslandSalesDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), (DateTime.Now.AddDays(1 - now.Day)).AddDays(-1));
                            
                        }
                        //公司出货数据
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 4)
                        {
                            DataUtils.getIslandShipmentDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), 0);
                            

                            DataUtils.getIslandShipmentDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), 1);
                            

                            DataUtils.getIslandShipmentDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), 2);
                            

                            DataUtils.getIslandShipmentDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), 3);
                            

                            DataUtils.getIslandShipmentDetails(dr["dEmail"].ToString(), (DateTime.Now.AddDays(1 - now.Day)).AddMonths(-1), 4);
                            
                        }


                        //客户销售数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 6)
                        {
                            DataUtils.getStorageSalesDetails_ToMail((_getDateTime).ToString("yyyy-MM-dd"), dr["dEmail"].ToString());
                            
                        }
                        //联营库存数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 7)
                        {
                            DataUtils.getJointInventoryDetails_ToMail(_getDateTime, 1, dr["dEmail"].ToString());
                            
                        }
                        //公司销售数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 8)
                        {
                            DataUtils.getIslandSalesDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //公司出货数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 9)
                        {
                            DataUtils.getIslandShipmentDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //仓库库存数据_打包
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 10)
                        {
                            DataUtils.getStockDetails_ToMail(_getDateTime, dr["dEmail"].ToString());
                            
                        }
                        //客户销售,联营库存,公司销售,公司出货,仓库库存
                        if (Convert.ToInt32(dr["dDataType"].ToString()) == 11)
                        {
                            DataUtils.getAll_ToMail(_getDateTime, dr["dEmail"].ToString());
                        }
                    }
                }
            }
        }
    }
}

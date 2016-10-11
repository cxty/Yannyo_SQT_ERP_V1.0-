using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yannyo.SOAP;
using Yannyo.Config;

namespace Yannyo.Install
{
   public class Utils
    {
       public static void toSystemReg(GeneralConfigInfo ManageConfig)
       {
           //Mail To System
           GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
           MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, 
               "商企通注册：" + ManageConfig.CompanyName,
                ManageConfig.CompanyName+"<br/>"+
                ManageConfig.RegistrationNo+"<br/>"+
                ManageConfig.Address +"<br/>"+
                ManageConfig.Phone +"<br/>"
               , configs.CompanyName, configs.SendMailUserName, "support@yannyo.com", "support@yannyo.com", true, DateTime.Now.AddSeconds(10));

       }
    }
}

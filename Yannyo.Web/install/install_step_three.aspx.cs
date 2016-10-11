using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Install;
using System.IO;
namespace Yannyo.Web
{
    public partial class install_step_three : Page
    {
        public string Act = "";             //获得步骤
        public string databaseAdress = "";  //数据库地址
        public string databaseName = "";    //数据库名称
        public string accountName = "";     //账户名称
        public string accountPwd = "";      //账户密码
        public string prefix = "";          //表前缀

        protected void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("act");
            databaseAdress = HTTPRequest.GetString("databaseAdress");
            databaseName = HTTPRequest.GetString("databaseName");
            accountName = HTTPRequest.GetString("accountName");
            accountPwd = HTTPRequest.GetString("accountPwd");
            prefix = HTTPRequest.GetString("prefix");

            if (!IsPostBack)
            {
                DataBaseOperating dbo = new DataBaseOperating();
                //检查数据库连接
                if (Act.IndexOf("check_sql") > -1)
                {
                    if (databaseAdress != "" && databaseName != "" && accountName != "" && accountPwd != "")
                    {
                        //检测是否连接成功
                        if (dbo.CheckDataBaseConnetion(databaseAdress, accountName, accountPwd, databaseName))
                        {
                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            //Response.ContentType = "application/json";
                            Response.Clear();
                            Response.Write(1);
                            Response.End();
                        }
                    }
                }
                //写入config以及创建数据库
                if (Act.IndexOf("write_sql") > -1)
                {
                    if (databaseAdress != "" && databaseName != "" && accountName != "" && accountPwd != "")
                    {
                        //将信息写入config
                        if (dbo.getClientConfigDetails(databaseAdress, databaseName, accountName, accountPwd, prefix))
                        {
                            string mappath = Yannyo.Common.Utils.GetMapPath("/install/Sql_Script/sqlsever.sql");
                            string varFileName = File.ReadAllText(mappath, System.Text.Encoding.GetEncoding("GB2312"));
                            if (File.Exists(Yannyo.Common.Utils.GetMapPath("/install/Sql_Script/sql.sql")))
                            {
                                FileInfo file = new FileInfo(Yannyo.Common.Utils.GetMapPath("/install/Sql_Script/sql.sql"));
                                file.Delete();
                            }
                            using (FileStream str = new FileStream(Yannyo.Common.Utils.GetMapPath("/install/Sql_Script/sql.sql"), FileMode.CreateNew))
                            {
                                using (StreamWriter sw = new StreamWriter(str))
                                {
                                    sw.Write(varFileName);
                                }
                            }
                            //执行数据库
                            int count = dbo.ExecuteSql(databaseAdress, accountName, accountPwd, databaseName, "", Yannyo.Common.Utils.GetMapPath("/install/Sql_Script/sql.sql"));
                            Response.Charset = "utf-8";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                            //Response.ContentType = "application/json";
                            Response.Clear();
                            Response.Write(count);
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}
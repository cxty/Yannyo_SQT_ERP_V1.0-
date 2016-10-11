using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using System.Xml;
namespace Yannyo.Web
{
    public partial class usermanageclass_do : PageBase
    {
        public int Classid = 0;
        public string name = "";
        public string Popedoms = "";

        public string Act = "";
        public string UserPopedomJson = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X"))
                {
                    Classid = HTTPRequest.GetInt("Classid", 0);
                    name = HTTPRequest.GetString("cName");
                    Popedoms = HTTPRequest.GetString("Popedoms");

                    Act = HTTPRequest.GetString("Act");

                    
                        if (!ispost)
                        {
                            UserPopedomJson = UsersUtils.GetUserPopedomToJsonStr();

                            if (Act == "Edit")
                            {
                                if (Classid > 0)
                                {
                                    DataTable UserTypeList = UsersUtils.GetUserType();
                                    foreach (DataRow dr in UserTypeList.Rows)
                                    {
                                        if (Classid == int.Parse(dr["id"].ToString()))
                                        {
                                            name = dr["name"].ToString().Trim();
                                            Popedoms = dr["Popedoms"].ToString().Trim();
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误!");
                                }
                            }
                            if (Act == "Del")
                            {
                                if (Classid > 0)
                                {
                                    DataTable UserTypeList = UsersUtils.GetUserType();
                                    foreach (DataRow dr in UserTypeList.Rows)
                                    {
                                        if (Classid == Convert.ToInt32(dr["id"].ToString()))
                                        {
                                            dr.Delete();
                                            break;
                                        }
                                    }
                                    UserTypeList.AcceptChanges();
                                    if (SaveDataToConfig(UserTypeList))
                                    {
                                        Logs.AddEventLog(this.userid, "删除用户组");
                                        AddMsgLine("删除成功");
                                        AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误!");
                                }
                            }
                        }
                        else
                        {
                            if (Act == "Add")
                            {
                                DataTable UserTypeList = UsersUtils.GetUserType();
                                foreach (DataRow dr in UserTypeList.Rows)
                                {
                                    if (name == dr["name"].ToString())
                                    {
                                        AddErrLine("用户组:" + name+",已经存在!无法添加!");
                                        break;
                                    }
                                }
                                if(!IsErr())
                                {
                                    DataRow[] dr = UserTypeList.Select("", "id desc");
                                    if (dr.Length > 0)
                                    {
                                        Classid =Convert.ToInt32(dr[0]["id"]) + 1;
                                    }
                                    DataRow _dr = UserTypeList.NewRow();
                                    _dr["Name"] = name;
                                    _dr["ID"] = Classid;
                                    _dr["Popedoms"] = Popedoms;
                                    UserTypeList.Rows.Add(_dr);
                                    UserTypeList.AcceptChanges();

                                    if (SaveDataToConfig(UserTypeList))
                                    {
                                        Logs.AddEventLog(this.userid, "添加用户组");
                                        AddMsgLine("添加成功");
                                        AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                                    }
                                }
                            }
                            if (Act == "Edit")
                            {
                                if (Classid > 0)
                                {
                                    DataTable UserTypeList = UsersUtils.GetUserType();
                                    foreach (DataRow dr in UserTypeList.Rows)
                                    {
                                        if (Classid !=Convert.ToInt32(dr["id"].ToString()))
                                        {
                                            if (name == dr["name"].ToString())
                                            {
                                                AddErrLine("用户组:" + name + ",已经存在!无法修改!");
                                                break;
                                            }
                                        }
                                    }
                                    if (!IsErr())
                                    {
                                        foreach (DataRow dr in UserTypeList.Rows)
                                        {
                                            if (Classid == Convert.ToInt32(dr["id"].ToString()))
                                            {
                                                dr["name"] = name;
                                                dr["Popedoms"] = Popedoms;
                                            }
                                        }
                                        UserTypeList.AcceptChanges();
                                        if (SaveDataToConfig(UserTypeList))
                                        {
                                            Logs.AddEventLog(this.userid, "修改用户组");
                                            AddMsgLine("修改成功");
                                            AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                                        }
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误!");
                                }
                            }
                        }
                    
                }
                else
                {
                    AddErrLine("权限不足!");
                }
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 用户组管理";
            this.Load += new EventHandler(this.Page_Load);
        }
        //保存更新后的 DataTable 为 managerclass.config
        public bool SaveDataToConfig(DataTable dt)
        {
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            XmlNode xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmldoc.AppendChild(xmlnode);
            XmlElement xmlelem  = xmldoc.CreateElement("", "ManagerClass", "");
            //XmlText xmltext = xmldoc.CreateTextNode("Root Text");
            //xmlelem.AppendChild(xmltext);

            XmlElement _xmlelem;
            foreach (DataRow dr in dt.Rows)
            {
                _xmlelem = xmldoc.CreateElement("", "Manager", "");
                _xmlelem.SetAttribute("name",dr["name"].ToString());
                _xmlelem.SetAttribute("Classid", dr["id"].ToString());
                _xmlelem.SetAttribute("Popedoms", dr["Popedoms"].ToString());
                
                xmlelem.AppendChild(_xmlelem);
            }

            xmldoc.AppendChild(xmlelem);

            try {
                xmldoc.Save(Utils.GetMapPath(BaseConfigs.GetSysPath + "config/managerclass.config"));
                Caches.ReSet();
                //UsersUtils.User_Class()
                AddMsgLine("系统配置信息需更新缓存,稍后才能作用到本系统.请稍候.");
                return true;
            }
            catch (Exception ex){
                AddErrLine(ex.Message);
                return false;
            }
        }
    }
}
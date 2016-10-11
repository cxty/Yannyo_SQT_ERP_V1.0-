using System;
using System.Collections;
using System.IO;
using System.Security.AccessControl;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Public;
using Yannyo.Data;


namespace Yannyo.Install
{
    public class SetDirPermission
    {
        /// <summary>
        /// 设置文件权限
        /// </summary>
        /// <param name="FileName">文件路径</param>
        /// <param name="Account">系统管理员:administrator</param>
        /// <param name="UserRights">文件的权限（R=读，C=更改权限，F=完全控制，W=文件可写）</param>
        /// <returns></returns>
        public string SetFilePermission(string FileName, string Account, string UserRights)
        {
            string getPermission = "";
            //系统文件权限实例化
            FileSystemRights Rights = new FileSystemRights();

            if (UserRights.IndexOf("R") >= 0)
            {
                //系统文件只读
                Rights = Rights | FileSystemRights.Read;
            }
            if (UserRights.IndexOf("C") >= 0)
            {
                //更改系统文件权限
                Rights = Rights | FileSystemRights.ChangePermissions;
            }
            if (UserRights.IndexOf("F") >= 0)
            {
                //完全控制
                Rights = Rights | FileSystemRights.FullControl;
            }
            if (UserRights.IndexOf("W") >= 0)
            {
                //系统文件可写
                Rights = Rights | FileSystemRights.Write;
            }

            bool ok;
            //将文件路径修改为f\a\..
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            //获取文件的访问控制
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //继承标志
            InheritanceFlags iFlags = new InheritanceFlags();
            //获得继承方向：容器继承或对象继承
            iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            //系统文件的访问规则：Account是否管理员；Rights是否读写或全部操作；iFlags如何继承；不允许传播；允许访问控制
            FileSystemAccessRule AccessRule2 = new FileSystemAccessRule(Account, Rights, iFlags, PropagationFlags.None, AccessControlType.Allow);
            //修改文件的访问规则
            dSecurity.ModifyAccessRule(AccessControlModification.Add, AccessRule2, out ok);
            //为该路径下得文件设置访问控制权限
            dInfo.SetAccessControl(dSecurity);

            //列出目标目录所具有的权限
            DirectorySecurity sec = Directory.GetAccessControl(FileName, AccessControlSections.All);
            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if ((rule.FileSystemRights & FileSystemRights.Read) != 0)
                {
                    getPermission= rule.FileSystemRights.ToString();
                }
            }
            return getPermission;
        }
        /// <summary>
        /// 文件或文件夹是否可写；true=可写，false=只读
        /// </summary>
        /// <param name="FileNameMappath">文件或文件夹路径</param>
        /// <param name="Account">权限账户</param>
        /// <param name="FileName">新建文件名（任意）</param>
        /// <returns></returns>
        public bool GetFilePermission(string FileNameMappath,string FileName)
        {
            string  isWrite = "";
            //修改文件夹路径
            DirectoryInfo filePath = new DirectoryInfo(FileNameMappath);
            //判断该路径下是文件还是文件夹
            if (File.Exists(filePath.ToString()))//文件
            {
                //复制该文件的内容
                CopyDir(Yannyo.Common.Utils.GetMapPath("/"), Yannyo.Common.Utils.GetMapPath("/install/saveConfig"));
                FileStream fs = new FileStream(filePath.ToString(),FileMode.Open,FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    fs.SetLength(0);//清空文件
                }
                catch (Exception e)
                {
                    isWrite = e.Message;
                }
                finally
                { 
                    string str="<?xml version=\"1.0\"?>"+
                              "<BaseConfigInfo xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
                              "<Dbconnectstring>Data Source=.;User ID=sa;Password=1q2w3e;Initial Catalog=IsLand_Sales_DB;Pooling=false;Connect Timeout=1000;</Dbconnectstring>"+
                              "<Tableprefix></Tableprefix>"+
                              "<Syspath>/</Syspath>"+
                              "<Dbtype>SqlServer</Dbtype>"+
                              "<Founderuid>1</Founderuid>"+
                              "</BaseConfigInfo>";
                    sw.Write(str);
                    sw.Close();

                    fs.Close();
                    CopyDir(Yannyo.Common.Utils.GetMapPath("/install/saveConfig"), Yannyo.Common.Utils.GetMapPath("/"));
                }
                

            }
            if (Directory.Exists(filePath.ToString()))//文件夹
            {
                //在该路径下写一个文件
                string writeFile = filePath.ToString() + "\\" + FileName;
                try
                {
                    if (File.Exists(writeFile))
                    {
                        File.Delete(writeFile);
                    }
                    
                    File.CreateText(writeFile).Close();
                    
                    
                    //Directory.CreateDirectory(writeFile);
                }
                catch (Exception e)
                {
                    isWrite = e.Message;
                }
                finally
                {
                    File.Delete(writeFile);
                    //File.Delete(writeFile);
                    //Directory.Delete(writeFile, true);
                    Directory.CreateDirectory(FileNameMappath);
                }
            }
            if (isWrite == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 将文件复制到某个目录下
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="aimPath"></param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            //检查目标目录是否以目录分割字符结束如果不是则添加之 
            if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                aimPath += Path.DirectorySeparatorChar;
            }
            //判断目标目录是否存在如果不存在则新建
            if (!Directory.Exists(aimPath)) Directory.CreateDirectory(aimPath);
            {
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍历所有的文件和目录 
                foreach (string file in fileList)
                {
                    if (file == Yannyo.Common.Utils.GetMapPath("/Yannyo.config"))
                    {
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                    }
                    if (file == Yannyo.Common.Utils.GetMapPath("/install/saveConfig/Yannyo.config"))
                    {
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                    }
                }
            }
        }   
    }
}

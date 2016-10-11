using System;

namespace Yannyo.Entity
{
    /// <summary>
    /// 返回信息
    /// </summary>
   public class PublicReMSG
    {
       private int _reCode;
       private string _reCodeStr;
       private string _reMSG;
       private string _reM;
       private object _obj;

       /// <summary>
       /// 返回代码,0正常,1失败
       /// </summary>
       public int reCode
       {
           set { _reCode = value; }
           get { return _reCode; }
       }
       /// <summary>
       /// 返回代码字符串
       /// </summary>
       public string reCodeStr
       {
           set { _reCodeStr = value; }
           get { return _reCodeStr; }
       }
       /// <summary>
       /// 返回信息
       /// </summary>
       public string reMSG
       {
           set { _reMSG = value; }
           get { return _reMSG; }
       }
       /// <summary>
       /// 返回信息附加内容
       /// </summary>
       public string reM
       {
           set { _reM = value; }
           get { return _reM; }
       }
       /// <summary>
       /// 附加对象
       /// </summary>
       public object reObj
       {
           set { _obj = value; }
           get { return _obj; }
       }
    }
}

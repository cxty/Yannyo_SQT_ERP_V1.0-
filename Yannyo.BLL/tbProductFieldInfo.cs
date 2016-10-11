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
using System.Collections;
using System.Xml;

namespace Yannyo.BLL
{
	public class tbProductFieldInfo
	{
		public static bool ExistsProductField(int ProductClassID,string pfName)
		{
			return DatabaseProvider.GetInstance().ExistsProductField( ProductClassID, pfName);
		}
		public static int AddProductField (ProductFieldInfo model)
		{
			return DatabaseProvider.GetInstance().AddProductField (model);
		}
		public static int UpdateProductField(ProductFieldInfo model)
		{
			return DatabaseProvider.GetInstance().UpdateProductField (model);
		}
		public static void DeleteProductField(int ProductFieldID)
		{
			DatabaseProvider.GetInstance().DeleteProductField (ProductFieldID);
		}
		public static void DeleteProductField (string ProductFieldID)
		{
			if (ProductFieldID.Trim () != "") {
				ProductFieldID = "," + ProductFieldID + ",";
				ProductFieldID = Utils.ReSQLSetTxt (ProductFieldID);
				DatabaseProvider.GetInstance ().DeleteProductField (ProductFieldID);
			}
		}
		public static ProductFieldInfo GetProductFieldModel(int ProductFieldID)
		{
			return DatabaseProvider.GetInstance().GetProductFieldModel (ProductFieldID);
		}
		public static DataTable GetProductFieldList(string strWhere)
		{
			DataTable dt = DatabaseProvider.GetInstance().GetProductFieldList (strWhere).Tables[0];
			DataTable FieldTypesList = GetProductFieldTypes ();

			dt.Columns.Add("TypeName", typeof(string));
			dt.Columns.Add("TypeFormat", typeof(string));
			dt.Columns.Add("TypeOther", typeof(string));

			for (int j = 0; j < dt.Rows.Count; j++) {
				dt.Rows [j] ["TypeName"] = FieldTypesList.Rows [(int)dt.Rows [j] ["pfType"]] ["Name"].ToString ();
				dt.Rows [j] ["TypeFormat"] = FieldTypesList.Rows [(int)dt.Rows [j] ["pfType"]] ["Format"].ToString ();
				dt.Rows [j] ["TypeOther"] = FieldTypesList.Rows [(int)dt.Rows [j] ["pfType"]] ["Other"].ToString ();
			}
			dt.AcceptChanges();
			return dt;
		}

		public static DataTable GetProductFieldList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
		{
			return DatabaseProvider.GetInstance().GetProductFieldList( PageSize,  PageIndex,  strWhere, out  pagetotal, OrderType,  showFName);
		}

		public static string GetProductFieldListJsonByProductClassID(int ProductClassID){

			DataTable ProductFieldList = new DataTable ();

			string ProductClassID_Str = DataClass.GetProductClassParentStr (ProductClassID);

			ProductClassID_Str = ProductClassID_Str.Trim () != "" ? ProductClassID_Str+","+ProductClassID : "0,"+ProductClassID;

			ProductFieldList = GetProductFieldList (" ProductClassID in("+ProductClassID_Str+") and pfState=0 order by pfOrder desc");
			string ProductFieldList_Json = "";
			for (int i = 0; i < ProductFieldList.Rows.Count; i++) {
				ProductFieldList_Json += "{\"Field\":{\"ProductFieldID\":" + ProductFieldList.Rows [i] ["ProductFieldID"].ToString () + "," +
					"\"ProductClassID\":" + ProductFieldList.Rows [i] ["ProductClassID"].ToString () + "," +
						"\"ProductClassName\":\"" + ProductFieldList.Rows [i] ["ProductClassName"].ToString () + "\"," +
						"\"pfName\":\"" + ProductFieldList.Rows [i] ["pfName"].ToString () + "\"," +
						"\"pfType\":" + ProductFieldList.Rows [i] ["pfType"].ToString () + "," +
						"\"TypeName\":\"" + ProductFieldList.Rows [i] ["TypeName"].ToString () + "\"," +
						"\"pfOrder\":" + ProductFieldList.Rows [i] ["pfOrder"].ToString () + "," +
						"\"pfState\":" + ProductFieldList.Rows [i] ["pfState"].ToString () + "," +
						"\"pfAppendTime\":\"" + ProductFieldList.Rows [i] ["pfAppendTime"].ToString () + "\"," +
						"\"Types\":{\"Name\":\""+ProductFieldList.Rows [i] ["TypeName"].ToString ()+"\","+
						"\"Format\":\""+ProductFieldList.Rows [i] ["TypeFormat"].ToString ()+"\","+
						"\"Other\":\""+ProductFieldList.Rows [i] ["TypeOther"].ToString ()+"\""+
						"}"+
						"}},";
			}
			ProductFieldList_Json = ProductFieldList_Json.Trim () != "" ? ProductFieldList_Json.Trim ().Substring (0, ProductFieldList_Json.Trim ().Length - 1) : "";
			return "{\"FieldList\":[" + ProductFieldList_Json + "]}";
		}

		/// <summary>
		/// 商品自定义字段类型为DataTable
		/// </summary>
		public static DataTable GetProductFieldTypes()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Name", typeof(string));
			dt.Columns.Add("ID", typeof(string));
			dt.Columns.Add("Format", typeof(string));
			dt.Columns.Add("Other", typeof(string));

			foreach (ProductFieldTypes.Rewrite FieldTypes in ProductFieldTypes.GetProductFieldType().FieldTypes)
			{
				DataRow dr = dt.NewRow();
				dr["Name"] = FieldTypes.Name;
				dr["ID"] = FieldTypes.ID;
				dr["Format"] = FieldTypes.Format;
				dr["Other"] = FieldTypes.Other;

				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();
			return dt;
		}
		/// <summary>
		/// 字段类型
		/// </summary>
		public class ProductFieldTypes
		{
			private static object lockHelper = new object();
			private static volatile ProductFieldTypes instance = null;
			string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/productfieldtype.config");
			private System.Collections.ArrayList _FieldTypes;
			public System.Collections.ArrayList FieldTypes
			{
				get
				{
					return _FieldTypes;
				}
				set
				{
					_FieldTypes = value;
				}
			}
			private ProductFieldTypes()
			{
				FieldTypes = new ArrayList();
				XmlDocument xml = new XmlDocument();
				xml.Load(Files);
				try
				{
					XmlNode root = xml.SelectSingleNode("//FieldTypes");
					foreach (XmlNode n in root.ChildNodes)
					{
						if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "fieldtype")
						{
							XmlAttribute _Name = n.Attributes["name"];
							XmlAttribute _ID = n.Attributes["id"];
							XmlAttribute _format = n.Attributes["format"];

							if (_Name != null && _ID != null)
							{
								FieldTypes.Add(new Rewrite(_Name.Value, _ID.Value, _format.Value, n.InnerText));
							}
						}
					}
				}
				finally
				{
					xml = null;
				}
			}
			public static ProductFieldTypes GetProductFieldType()
			{
				if (instance == null)
				{
					lock (lockHelper)
					{
						if (instance == null)
						{
							instance = new ProductFieldTypes();
						}
					}
				}
				return instance;

			}

			public static void SetInstance(ProductFieldTypes anInstance)
			{
				if (anInstance != null)
					instance = anInstance;
			}

			public static void SetInstance()
			{
				SetInstance(new ProductFieldTypes());
			}
			public class Rewrite
			{
				#region 成员变量
				private string _Name;
				public string Name
				{
					get
					{
						return _Name;
					}
					set
					{
						_Name = value;
					}
				}
				private string _ID;
				public string ID
				{
					get
					{
						return _ID;
					}
					set
					{
						_ID = value;
					}
				}
				private string _format;
				public string Format
				{
					get
					{
						return _format;
					}
					set
					{
						_format = value;
					}
				}
				private string _Other;
				public string Other
				{
					get
					{
						return _Other;
					}
					set
					{
						_Other = value;
					}
				}
				#endregion
				#region 构造函数
				public Rewrite(string name, string id, string format, string other)
				{
					_Name = name;
					_ID = id;
					_format = format;
					_Other = other;
				}
				#endregion
			}
		}
	}
}


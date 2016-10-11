using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;


namespace Yannyo.Common
{
	/// <summary>
	/// TemplateΪҳ��ģ����.
	/// </summary>
	public abstract class PageTemplate
	{
		public static Regex[] r = new Regex[24];

		static PageTemplate()
		{

            RegexOptions options = Utils.GetRegexCompiledOptions();

			r[0] = new Regex(@"<%template ([^\[\]\{\}\s]+)%>", options);

			r[1] = new Regex(@"<%loop ((\(([a-zA-Z]+)\) )?)([^\[\]\{\}\s]+) ([^\[\]\{\}\s]+)%>", options);

			r[2] = new Regex(@"<%\/loop%>", options);

			r[3] = new Regex(@"<%while ([^\[\]\{\}\s]+)%>", options);

			r[4] = new Regex(@"<%\/while ([^\[\]\{\}\s]+)%>", options);

			r[5] = new Regex(@"<%if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?)(?:\s*)%>", options);
			//r[5] = new Regex(@"<%if ([^\s]+)%>", options);

			r[6] = new Regex(@"<%else(( (?:\s*)if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?))?)(?:\s*)%>", options);

			r[7] = new Regex(@"<%\/if%>", options);

			//����{var.a}
			r[8] = new Regex(@"(\{strtoint\(([^\s]+?)\)\})", options);

			//����{request[a]}
			r[9] = new Regex(@"(<%urlencode\(([^\s]+?)\)%>)", options);

			//����{var[a]}
			r[10] = new Regex(@"(<%datetostr\(([^\s]+?),(.*?)\)%>)", options);
			r[11] = new Regex(@"(\{([^\.\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\})", options);

			//������ͨ����{}
			r[12] = new Regex(@"(\{request\[([^\[\]\{\}\s]+)\]\})", options);

			//����==���ʽ
			r[13] = new Regex(@"(\{([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\})", options);

			//����==���ʽ
			r[14] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);

			//������ͨ����{}
			r[15] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);

			//����==���ʽ
			r[16] = new Regex(@"(([=|>|<|!]=)\\" + "\"" + @"([^\s]*)\\" + "\")", options);
			
			//�����ռ�
            r[17] = new Regex(@"<%namespace (?:""?)([\s\S]+?)(?:""?)%>", options);
			
			//C#����
			r[18] = new Regex(@"<%csharp%>([\s\S]+?)<%/csharp%>", options);

			//set��ǩ
			r[19] = new Regex(@"<%set ((\(([a-zA-Z]+)\))?)(?:\s*)\{([^\s]+)\}(?:\s*)=(?:\s*)(.*?)(?:\s*)%>", options);

            //��ȡ�ַ���
            r[20] = new Regex(@"(<%getsubstring\(([^\s]+?),(.\d*?),([^\s]+?)\)%>)", options);
          
            //repeat��ǩ
            r[21] = new Regex(@"<%repeat\(([^\s]+?)(?:\s*),(?:\s*)([^\s]+?)\)%>", options);

            //�̳���Inherits
            r[22] = new Regex(@"<%inherits (?:""?)([\s\S]+?)(?:""?)%>", options);

            //����r[5]�޷�������if���
            r[23] = new Regex(@"<%if (.+)%>", options);

    
		}


		/// <summary>
		/// ���ģ���ַ���. ���Ȳ��һ���. ������ڻ�������������е�ģ��·������ȡģ���ļ�.
		/// ģ���ļ���·����Web.config�ļ�������.
		/// �����ȡ�ļ��ɹ���Ὣ���ݷ��ڻ�����.
		/// </summary>
		/// <param name="skinName">ģ����</param>
		/// <param name="templateName">ģ���ļ����ļ�����, Ҳ�ǻ����е�ģ������.</param>
		/// <param name="nest">Ƕ�״���</param>
		/// <returns>stringֵ,���ʧ����Ϊ"",�ɹ���Ϊģ�����ݵ�string</returns>
        public virtual string GetTemplate(string forumpath, string skinName, string templateName, int nest,  string Inherits)
		{
			StringBuilder strReturn = new StringBuilder();
			if (nest < 1)
			{
				nest = 1;
			}
			else if (nest > 5)
			{
				return "";
			}


			string extNamespace = "";
			//string csharpCode = "";
            //����ģ��config���ȣ������htm
            string configPathFormatStr = "{0}{1}{2}{3}{4}.config";
			string htmlPathFormatStr = "{0}{1}{2}{3}{4}.htm";
            string configFilePath = string.Format(configPathFormatStr, Utils.GetMapPath(forumpath + "templates"), System.IO.Path.DirectorySeparatorChar, skinName, System.IO.Path.DirectorySeparatorChar, templateName);
            string htmlFilePath = string.Format(htmlPathFormatStr, Utils.GetMapPath(forumpath + "templates"), System.IO.Path.DirectorySeparatorChar, skinName, System.IO.Path.DirectorySeparatorChar, templateName);
            string createFilePath = "";
            string inherits = Inherits+"." + templateName;
            //���ָ������configģ���ļ�����
            if (System.IO.File.Exists(configFilePath))
            {
                createFilePath = configFilePath;    //����config�ļ�ģ��
            }
            else if (System.IO.File.Exists(htmlFilePath))    //���ָ������htmģ���ļ�����
            {
                createFilePath = htmlFilePath;
            }
            else			//���ָ������config��htmģ���ļ���������...
            {
                //Ĭ�Ϸ���ģ���Ƿ����...
                createFilePath = string.Format(htmlPathFormatStr, Utils.GetMapPath(forumpath + "templates"), System.IO.Path.DirectorySeparatorChar, "default", System.IO.Path.DirectorySeparatorChar, templateName);
                if (!System.IO.File.Exists(createFilePath))
                {
                    return "";
                }
            }

            using (System.IO.StreamReader objReader = new System.IO.StreamReader(createFilePath,Encoding.UTF8))
			{
				System.Text.StringBuilder textOutput = new System.Text.StringBuilder();
				
				textOutput.Append(objReader.ReadToEnd());
				objReader.Close();

				//���������ռ�
				if (nest == 1)
				{
                    //�����ռ�
                    foreach (Match m in r[17].Matches(textOutput.ToString()))
                    {
                        extNamespace += "\r\n<%@ Import namespace=\"" + m.Groups[1].ToString() + "\" %>";
                        textOutput.Replace(m.Groups[0].ToString(), string.Empty);
                    }

                    //inherits
                    foreach (Match m in r[22].Matches(textOutput.ToString()))
                    {
                        inherits = m.Groups[1].ToString();
                        textOutput.Replace(m.Groups[0].ToString(), string.Empty);
                        break;
                    }
                    if ("\"".Equals(inherits))
                    {
                        inherits = "Yannyo.Public.PageBase";
                    }

				}
				//����Csharp���
				foreach (Match m in r[18].Matches(textOutput.ToString()))
				{
					//csharpCode += "\r\n" + m.Groups[1].ToString() + "\r\n";
					textOutput.Replace(m.Groups[0].ToString(), m.Groups[0].ToString().Replace("\r\n", "\r\t\r"));
				}

				textOutput.Replace("\r\n", "\r\r\r");
				textOutput.Replace("<%", "\r\r\n<%");
				textOutput.Replace("%>", "%>\r\r\n");

				textOutput.Replace("<%csharp%>\r\r\n", "<%csharp%>").Replace("\r\r\n<%/csharp%>", "<%/csharp%>");
				

				string[] strlist = Utils.SplitString(textOutput.ToString(), "\r\r\n");
				int count = strlist.GetUpperBound(0);
		
				for (int i = 0; i <= count; i++)
				{
                    strReturn.Append(ConvertTags(nest, forumpath, skinName, strlist[i], Inherits));
				}
			}
			if (nest == 1)
			{
                //strReturn = strReturn.Replace("\r\r\r\r\r\r", "\r\r\r");   //Codebehind=\"{0}.aspx.cs\" 
                string template = string.Format("<%@ Page language=\"c#\" AutoEventWireup=\"false\" EnableViewState=\"false\" Inherits=\"{0}\" %>\r\n<%@ Import namespace=\"System.Data\" %>\r\n<%@ Import namespace=\"Yannyo.Common\" %>\r\n<%@ Import namespace=\"Yannyo.Entity\" %>\r\n{1}\r\n<script runat=\"server\">\r\noverride protected void OnLoad(EventArgs e)\r\n{{\r\n\r\n\t/* \r\n\t\t��ҳ�������Yannyoģ������������ {2}. \r\n\t*/\r\n\r\n\tbase.OnLoad(e);\r\n{3}\r\n\tWriteHTML(templateBuilder.ToString());\r\n}}\r\n</script>\r\n", inherits, extNamespace, DateTime.Now.ToString(), strReturn.ToString());

                string pageDir = Utils.GetMapPath(forumpath + "aspx\\" + skinName.ToString() + "\\");
				if (!Directory.Exists(pageDir))
				{
					Utils.CreateDir(pageDir);
				}

				string outputPath = pageDir  + templateName + ".aspx";
				
					
				
				using (FileStream fs = new FileStream(outputPath, FileMode.Create,FileAccess.ReadWrite, FileShare.ReadWrite))
				{
					Byte[] info = System.Text.Encoding.UTF8.GetBytes(template);
					fs.Write(info, 0, info.Length);
					fs.Close();
				}
				
			}
			return strReturn.ToString();
		}
		
		/// <summary>
		/// ת����ǩ
		/// </summary>
		/// <param name="nest">���</param>
		/// <param name="skinName">ģ������</param>
		/// <param name="inputStr">ģ������</param>
		/// <returns></returns>
        private string ConvertTags(int nest, string forumpath, string skinName, string inputStr, string Inherits)
		{
			string strReturn = "";
			bool IsCodeLine;
			//Regex r;
			string strTemplate;
			strTemplate = inputStr.Replace("\\", "\\\\");
			strTemplate = strTemplate.Replace("\"", "\\\"");
			strTemplate = strTemplate.Replace("</script>", "</\" + \"script>");
			//strTemplate = strlist[i];
			IsCodeLine = false;
		

			foreach (Match m in r[0].Matches(strTemplate))
			{
				IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\n" + GetTemplate(forumpath, skinName, m.Groups[1].ToString(), nest + 1, Inherits) + "\r\n");
			}

			//r = new Regex(@"<%loop ([^\[\]\{\}\s]+) ([^\[\]\{\}\s]+)%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[1].Matches(strTemplate))
			{
				IsCodeLine = true;
				if (m.Groups[3].ToString() == "")
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						string.Format("\r\n\tint {0}__loop__id=0;\r\n\tforeach(DataRow {0} in {1}.Rows)\r\n\t{{\r\n\t\t{0}__loop__id++;\r\n", m.Groups[4].ToString(), m.Groups[5].ToString()));
				}
				else
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						string.Format("\r\n\tint {1}__loop__id=0;\r\n\tforeach({0} {1} in {2})\r\n\t{{\r\n\t\t{1}__loop__id++;\r\n", m.Groups[3].ToString(), m.Groups[4].ToString(), m.Groups[5].ToString()));
				}
			}

			//r = new Regex(@"<%\/loop%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[2].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"\r\n\t}\t//end loop\r\n");
			}

			//r = new Regex(@"<%while ([^\[\]\{\}\s]+)%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[3].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					string.Format("\r\n\tint {0}__loop__id=0;\r\nwhile({0}.Read())\r\n\t{{\r\n{0}__loop__id++;\r\n", m.Groups[1].ToString()));
			}

			//r = new Regex(@"<%\/while ([^\[\]\{\}\s]+)%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[4].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"\r\n\t}\t//end while\r\n" + m.Groups[1] + ".Close();\r\n");
			}

			//r = new Regex(@"<%if ([^\s]+)%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[5].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"\r\n\tif (" + m.Groups[1].ToString().Replace("\\\"", "\"") + ")\r\n\t{\r\n");
			}


			//r = new Regex(@"<%else%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[6].Matches(strTemplate))
			{
				IsCodeLine = true;
				if (m.Groups[1].ToString() == string.Empty)
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"\r\n\t}\r\n\telse\r\n\t{\r\n");
				}
				else
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						"\r\n\t}\r\n\telse if (" + m.Groups[3].ToString().Replace("\\\"", "\"") + ")\r\n\t{\r\n");
				}
			}

			//r = new Regex(@"<%\/if%>", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[7].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"\r\n\t}\t//end if\r\n");
			}

			//����set
			//
			foreach (Match m in r[19].Matches(strTemplate.ToString()))
			{
				IsCodeLine = true;
				string type = "";
				if (m.Groups[3].ToString() != string.Empty)
				{
					type = m.Groups[3].ToString();
				}
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    string.Format("\t{0} {1} = {2};\r\n\t", type, m.Groups[4].ToString(), m.Groups[5].ToString()).Replace("\\\"", "\"")
					);
			}

            //����repeat @"<%repeat\(([^\s]+?)(?:\s*),(?:\s*)([0-9]*)\)%>"
            foreach (Match m in r[21].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                //if (Utils.StrToInt(m.Groups[2], 0) > 0)
                //{
 				    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\tfor (int i = 0; i < " + m.Groups[2] + "; i++)\r\n\t{\r\n\t\ttemplateBuilder.Append(" + m.Groups[1].ToString().Replace("\\\"", "\"").Replace("\\\\", "\\") + ");\r\n\t}\r\n");

                //}
            }

			//r = new Regex(@"(\{strtoint\(([^\s]+?)\)\})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[8].Matches(strTemplate))
			{
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"Utils.StrToInt(" + m.Groups[2].ToString() + ", 0)");
			}
			//r[8].Replace(strTemplate, "Utils.StrToInt($2, 0)");

			//r = new Regex(@"(<%urlencode\(([^\s]+?)\)%>)", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[9].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					"templateBuilder.Append(Utils.UrlEncode(" + m.Groups[2].ToString() + "));");
			}

			//r = new Regex(@"(<%datetostr\(([^\s]+?),(.*?)\)%>)", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[10].Matches(strTemplate))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					string.Format("\ttemplateBuilder.Append(Convert.ToDateTime({0}).ToString(\"{1}\"));", m.Groups[2].ToString(), m.Groups[3].ToString().Replace("\\\"", string.Empty)));
			}

            //����substring
            //
            foreach (Match m in r[20].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    string.Format("\ttemplateBuilder.Append(Utils.GetUnicodeSubString({0},{1},\"{2}\"));", m.Groups[2].ToString(), m.Groups[3].ToString(), m.Groups[4].ToString().Replace("\\\"", string.Empty)));

                //  strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                //      string.Format("templateBuilder.Append(Convert.ToDateTime({0}).ToString(\"{1}\"));", m.Groups[2].ToString(), m.Groups[3].ToString().Replace("\\\"", string.Empty)));

            }
					
			//����{var.a}
			//r = new Regex(@"(\{([^\.\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[11].Matches(strTemplate))
			{
				if (IsCodeLine)
				{
                    //string.Format("{0}.{1}{2}", m.Groups[2].ToString(), Utils.CutString(m.Groups[3].ToString(), 0, 1).ToUpper(), m.Groups[3].ToString().Substring(1, m.Groups[3].ToString().Length - 1)));
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						string.Format("{0}.{1}", m.Groups[2].ToString(),  m.Groups[3].ToString()));
				}
				else
				{
                    //string.Format("\" + {0}.{1}{2}.ToString().Trim() + \"", m.Groups[2].ToString(), Utils.CutString(m.Groups[3].ToString(), 0, 1).ToUpper(), m.Groups[3].ToString().Substring(1, m.Groups[3].ToString().Length - 1)));
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						string.Format("\" + {0}.{1}.ToString().Trim() + \"", m.Groups[2].ToString(),  m.Groups[3].ToString()));

				}

			}

			//����{request[a]}
			//r = new Regex(@"(\{request\[([^\[\]\{\}\s]+)\]\})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[12].Matches(strTemplate))
			{
				if (IsCodeLine)
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "HTTPRequest.GetString(\"" + m.Groups[2].ToString() + "\")");
				}
				else
				{
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + HTTPRequest.GetString(\"{0}\") + \"", m.Groups[2].ToString()));
				}

			}

			//����{var[a]}
			//r = new Regex(@"(\{([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[13].Matches(strTemplate))
			{
				if (IsCodeLine)
				{
					if (Utils.IsNumeric(m.Groups[3].ToString()))
					{
						strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[" + m.Groups[3].ToString() + "].ToString().Trim()");
					}
					else
					{
						if (m.Groups[3].ToString() == "_id")
						{
							strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "__loop__id");
						}
						else
						{
							strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[\"" + m.Groups[3].ToString() + "\"].ToString().Trim()");
						}
					}
				}
				else
				{
					if (Utils.IsNumeric(m.Groups[3].ToString()))
					{
						strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[{1}].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
					}
					else
					{
						if (m.Groups[3].ToString() == "_id")
						{
							strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}__loop__id.ToString() + \"", m.Groups[2].ToString()));
						}
						else
						{
							strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[\"{1}\"].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
						}
					}
				}
				//strTemplate = "\"" + strTemplate + "\\r\\n\");\r\n";
			}

			strTemplate = ReplaceSpecialTemplate(forumpath,skinName,strTemplate);

			//r = new Regex(@"({([^\[\]/\{\}='\s]+)})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[14].Matches(strTemplate))
			{
				if (m.Groups[0].ToString() == "{commonversion}")
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(), Utils.GetAssemblyVersion());
				}
			}
                    
					
			
			//������ͨ����{}
			//r = new Regex(@"({([^\[\]/\{\}='\s]+)})", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[15].Matches(strTemplate))
			{
				//IsCodeLine = false;
				if (IsCodeLine)
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						m.Groups[2].ToString());
				}
				else
				{
					strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
						string.Format("\" + {0}.ToString() + \"", m.Groups[2].ToString().Trim()));
				}

			}
					
					
			//����==���ʽ
			//r = new Regex(@"(([>=|==|<=|!=])\\" + "\"" + @"([^\[\]\{\}\s]*)\\" + "\")", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			//r = new Regex(@"(([=|>|<|!]=)\\" + "\"" + @"([^\s]*)\\" + "\")", RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
			foreach (Match m in r[16].Matches(strTemplate))
			{
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
					m.Groups[2].ToString() + "\"" + m.Groups[3].ToString() + "\"");

			}
			//r[16].Replace(strTemplate, "$2\"$3\"");
				
				
			//����csharpcode
			//
			foreach (Match m in r[18].Matches(strTemplate.ToString()))
			{
				IsCodeLine = true;
				strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[1].ToString().Replace("\r\t\r", "\r\n\t").Replace("\\\"", "\""));
			}

            //����r[5]�޷�������if���
            foreach (Match m in r[23].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\r\n\tif (" + m.Groups[1].ToString().Replace("\\\"", "\"") + ")\r\n\t{\r\n");
            }
					
			//HttpContext.Current.Response.Write(i.ToString() + "* " + HttpUtility.HtmlEncode(strTemplate) + "<br />");
			if (IsCodeLine)
			{
				strReturn = strTemplate + "\r\n";
				//System.Web.HttpContext.Current.Response.Write(" " + i.ToString() + strTemplate);
			}
			else
			{
				if (strTemplate.Trim() != "")
				{
					StringBuilder sb = new StringBuilder();
					foreach (string temp in Utils.SplitString(strTemplate,"\r\r\r"))
					{
						if (temp.Trim() == "")
							continue;
						sb.Append("\ttemplateBuilder.Append(\"" + temp + "\\r\\n\");\r\n");
					}
					strReturn = sb.ToString();
				}
				//System.Web.HttpContext.Current.Response.Write(" *" + i.ToString());
			}
			return strReturn;
		}



		/// <summary>
		/// �����������
		/// </summary>
		/// <returns></returns>
		public abstract string ReplaceSpecialTemplate(string forumpath,string skinName,string strTemplate);
		

	}



}
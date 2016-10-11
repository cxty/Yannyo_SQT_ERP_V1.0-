/**
 * @author cxty@msn.com
 */
function TMain_Class()
{
	this.Main_Class_Tree_Box = null;
	this.Main_Class_Edit_Box = null;
	
	this.E_Class_Name = null;
	this.E_Class_ENName = null;
	this.E_Class_ReMake = null;
	this.E_Class_cState_A = null;
	this.E_Class_cState_B = null;
	this.E_Submit_B = null;
	this.E_CID = null;
	this.E_cUpID = null;
	this.checkbox = null;
	this.A_Button_A = null;
	this.A_Button_D = null;
	this.Main_ClassAttribute_List = null;
	this.Page_Bar = null;
	
	this.UserName = '';
	this.UserPWDCode = '';
	this.UserCode = '';
	this.OldUserCode = '';
	this.IsLogin = false;
	
	this.Class_Menu = null;
	this.Selected_ClassID = null;
	this.Pagetree = null;
	this.Tree = null;
	this.Class_Tool_Box = null;
	this.Action_Type = 0;//默认为添加事件,0=添加,1=修改,2=删除
	
	this.Main_ClassAttribute = null;
	
	this.Class_Name = null;
	this.Class_ENName = null;
	this.Class_ReMake = null;
	this.Class_cState_A = null;
	this.Class_cState_B = null;
	this.Submit_B = null;
}
TMain_Class.prototype.ini = function()
{
	this.Main_Class_Tree_Box = Sys.getObj('Main_Class_Tree_Box');
	this.Main_Class_Edit_Box = Sys.getObj('Main_Class_Edit_Box');
	
	this.E_Class_Name = Sys.getObj('E_Class_Name');
	this.E_Class_ENName = Sys.getObj('E_Class_ENName');
	this.E_Class_ReMake = Sys.getObj('E_Class_ReMake');
	this.E_Class_cState_A = Sys.getObj('E_Class_cState_A');
	this.E_Class_cState_B = Sys.getObj('E_Class_cState_B');
	this.E_Submit_B = Sys.getObj('E_Submit_B');
	this.A_Button_A = Sys.getObj('A_Button_A');
	this.A_Button_D = Sys.getObj('A_Button_D');
	this.checkbox = Sys.getObj('checkbox');
	this.Main_ClassAttribute_List = Sys.getObj('Main_ClassAttribute_List');
	this.Page_Bar = Sys.getObj('Page_Bar');
	
	this.Class_Menu = Class_Menu;//右键菜单
	this.Pagetree = Pagetree;//分类树
	this.Class_Tool_Box = new SysComm.WriteBox('Class_Tool_Box','');
	
	this.Main_ClassAttribute = new TMain_ClassAttribute;
	this.Main_ClassAttribute.Class_Tool_Box = this.Class_Tool_Box;
	
	this.OldUserCode = GetQueryString('UCode');
	this.UserCode = Sys.urlEncode(clsURLvalue(this.OldUserCode));
	
	this.CheckUser();
}
TMain_Class.prototype.CheckUser = function()
{//校验用户信息
	ShowLoadBar();
	if(Trim(this.UserCode) != '' && this.UserCode != null){
		//ShowLoadBar();
		var tXML = '<xml><Code><![CDATA['+ this.UserCode +']]></Code></xml>';
		SysComm.PostData(tXML,Main_Class.CheckUser_ReCall,'CheckPassport');
		tXML = null;
	}else{
		this.IsLogin = false;
		alert('对不起,用户代码验证错误,请重新登陆.');
		window.top.location = Singin+'?&c='+Math.random();
	}
}
TMain_Class.prototype.CheckUser_ReCall = function(ReXML)
{
	HitLoadBar();
	try
	{
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				Main_Class.IsLogin = true;
				Main_Class.UserName = GetXMLData(xmldom,'User_Name');
				Main_Class.UserPWDCode = GetXMLData(xmldom,'User_PWD');
				Main_Class.ShowPage();
			}else{
				alert(GetXMLData(xmldom,'MSG'));
				window.top.location = Singin+'?&c='+Math.random();
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
			Main_Class.IsLogin = false;
		}
		xmldom = null;
	}
	catch (e)
	{
	}
}
TMain_Class.prototype.ShowPage = function()
{
	ShowLoadBar();
	this.E_Class_Name.disabled = 'disabled';
	this.E_Class_ENName.disabled = 'disabled';
	this.E_Class_ReMake.disabled = 'disabled';
	this.E_Class_cState_A.disabled = 'disabled';
	this.E_Class_cState_B.disabled = 'disabled';
	this.E_Submit_B.disabled = 'disabled';

	this.A_Button_A.disabled = 'disabled';
	this.A_Button_D.disabled = 'disabled';
	
	this.checkbox.disabled = 'disabled';

	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><UpCID><![CDATA[ ]]></UpCID><Pagesize>1</Pagesize><PageIndex>1</PageIndex><Word_Key><![CDATA[ ]]></Word_Key></xml>';
	SysComm.PostData(tXML,Main_Class.ShowPage_ReCall,'List_Class');
	tXML = null;
}
TMain_Class.prototype.ShowPage_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			var nodes = xmldom.getElementsByTagName('Data');
			if(Error_Type == "-1"){
				Main_Class.Show_Class_Tree(nodes);
			}else{
				switch(Error_Type)
				{
					case '4':case 4:
					
					break;
					default:
						alert(GetXMLData(xmldom,'MSG'));
					break;
				}
			}
			nodes = null;
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
			Main_SystemUser.IsLogin = false;
		}
		xmldom = null;
	}
	catch (e)
	{
		alert(e.message);
	}
}
TMain_Class.prototype.Show_Class_Tree = function(nodes)
{//显示分类树
	
	if(this.Tree == null)
	{
		this.Tree = new cPublicBuild_Tree;
		this.Tree.PageTreeObj = Pagetree;
		this.Tree.ini(nodes,0);
	}
	else
	{
		//Sys.getObj(this.Pagetree+'-cont').innerHTML = '';
		this.Tree.Reini(nodes,0);
	}
}
TMain_Class.prototype.Re_ClassObj = function()
{//返回当前选中分类的分类对象
	var SelectEdTObj = this.Pagetree.getSelected();
	if(SelectEdTObj)
	{
		if(SelectEdTObj == this.Pagetree)
		{//根返回空
			return null;
		}
		else
		{
			return SelectEdTObj;
		}
	}
}

/*右键菜单调用函数*/
TMain_Class.prototype.Add_Class = function()
{//添加子分类
	if(this.Re_ClassObj() == null)
	{
		this.Selected_ClassID = 0;
	}
	else
	{
		this.Selected_ClassID = this.Tree.getCheckedValue(this.Re_ClassObj().id);
	}

	this.Show_Class_Box('A',this.Selected_ClassID);
	this.Action_Type = 0;
}
TMain_Class.prototype.Edit_Class = function()
{//修改分类
	
	if(this.Re_ClassObj() == null)
	{
		alert('根分类无法修改,请选中其他分类.');
	}
	else
	{
		this.Selected_ClassID = this.Tree.getCheckedValue(this.Re_ClassObj().id);
		this.Show_Class_Box('E',this.Re_ClassObj().id);
		this.Action_Type = 1;
	}
}
TMain_Class.prototype.Del_Class = function()
{//删除分类
	
	if(this.Re_ClassObj() == null)
	{
		alert('根分类无法删除,请选中其他分类.');
	}
	else
	{
		this.Selected_ClassID = this.Tree.getCheckedValue(this.Re_ClassObj().id);
		
		if(window.confirm('删除该分类的同时系统会自动删除与其相关联的所有数据.\n\n您确定要删除分类 <'+this.Tree.getCheckedTxt(this.Re_ClassObj().id)+'> 吗?'))
		{
			this.Action_Type = 2;
			
			this.Save_Add_Edit_Del_Class();
		}
	}
}
TMain_Class.prototype.Add_ClassAttribute = function()
{//添加属性
	if(this.Re_ClassObj() == null)
	{
		alert('请选择一个分类.');
	}
	else
	{
		this.Selected_ClassID = this.Tree.getCheckedValue(this.Re_ClassObj().id);
	}
}
TMain_Class.prototype.Edit_ClassAttribute = function()
{//查看修改属性
	if(this.Re_ClassObj() == null)
	{
		alert('请选择一个分类.');
	}
	else
	{
		this.Selected_ClassID = this.Tree.getCheckedValue(this.Re_ClassObj().id);
	}
}

/*数据处理*/
TMain_Class.prototype.Check_Class_F = function()
{//校验数据
	if(Trim(this.Class_Name.value) == ''){alert('请填写分类名称.');this.Class_Name.focus();return false;}
	else
	{this.Class_Name.value = Trim(this.Class_Name.value);}
}
TMain_Class.prototype.Save_Add_Edit_Del_Class = function()
{//保存添加修改操作
	var SelectID = 0;
	var tXML = '';
	ShowLoadBar();
	if(this.Action_Type != 2)
	{
		if(this.Check_Class_F() != false)
		{
			var cState = (this.Class_cState_A.checked) ? this.Class_cState_A.value : this.Class_cState_B.value;
			if(this.Action_Type == 0)
			{//添加
				if(Trim(this.Selected_ClassID) != '')
				{
					tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cName><![CDATA['+ escape(this.Class_Name.value) +']]></cName><cENName><![CDATA['+ escape(this.Class_ENName.value) +']]></cENName><cRemake><![CDATA['+ escape(this.Class_ReMake.value) +']]></cRemake><cUpID><![CDATA['+ this.Selected_ClassID +']]></cUpID><cState>'+ cState +'</cState><cOrder>0</cOrder></xml>';
					SysComm.PostData(tXML,Main_Class.Save_Add_Class_ReCall,'Add_Class');
				}
				else
				{
					alert('请选择一个要添加子分类的分类.');
				}
			}
			if(this.Action_Type == 1)
			{//修改
				if(this.Selected_ClassID == null)
				{
					alert('根分类无法修改.请选择其他分类');
				}
				else
				{
					if(Trim(SelectID) != ''){
						tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+this.Selected_ClassID+'</cID><cName><![CDATA['+ escape(this.Class_Name.value) +']]></cName><cENName><![CDATA['+ escape(this.Class_ENName.value) +']]></cENName><cRemake><![CDATA['+ escape(this.Class_ReMake.value) +']]></cRemake><cState>'+ cState +'</cState><cOrder>0</cOrder></xml>';
						SysComm.PostData(tXML,Main_Class.Save_Edit_Class_ReCall,'Edit_Class');
					}
					else
					{
						alert('请选择一个要修改的分类.');
					}
				}
			}
			cState = null;
		}
	}else{//删除
		if(this.Selected_ClassID == null)
		{
			alert('根分类无法删除.请选择其他分类');
		}
		else
		{
			if(Trim(this.Selected_ClassID) != ''){
				tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+this.Selected_ClassID+'</cID></xml>';
				SysComm.PostData(tXML,Main_Class.Save_Del_Class_ReCall,'Del_Class');
			}
			else
			{
				alert('请选择一个要删除的分类.');
			}
		}
	}
	tXML = null;
	SelectID = null;
}
TMain_Class.prototype.Save_Add_Class_ReCall = function(ReXML)
{//添加回调
	try
	{
		HitLoadBar();
		HiddenToolBox();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.Save_Edit_Class_ReCall = function(ReXML)
{//修改回调
	try
	{
		HitLoadBar();
		HiddenToolBox();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));

			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.Save_Del_Class_ReCall = function(ReXML)
{//删除回调
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));

			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}

TMain_Class.prototype.Show_Class_Box = function(ShowType,ActionID)
{//显示操作对话框

	switch(ShowType)
	{
		case 'A': //添加分类
			var Box_HTML = '<div style="width:250px">'+
					'<table width="100%" border="0" cellspacing="2" cellpadding="2">'+
					  '<tr><td align="left"><b>添加分类</b></td>'+
					  '</tr><tr><td align="left">&nbsp;</td>'+
					  '</tr><tr><td align="center">名称<input name="Class_Name" type="text" id="Class_Name" style="width:80%" /></td>'+
					  '</tr><tr><td align="center">英文<input name="Class_ENName" type="text" id="Class_ENName" style="width:80%" /></td>'+
					  '</tr><tr><td>备注<textarea name="Class_ReMake" rows="10" id="Class_ReMake" style="width:80%"></textarea></td>'+
					  '</tr><tr><td><input name="cState" id="Class_cState_A" type="radio" value="T" checked="checked" />正常'+
					  '<input name="cState" id="Class_cState_B" type="radio" value="F" />屏蔽</td>'+
					  '</tr><tr>'+
					    '<td align="center"><input type="submit" name="Submit_B" id="Submit_B" value="确定" onclick="javascript:Main_Class.Save_Add_Edit_Del_Class();" />'+
					      '<input type="button" name="Submit2" value="取消" onclick="javascript:HiddenToolBox();"/></td>'+
					  '</tr><tr><td>&nbsp;</td></tr></table></div>';
			this.Class_Tool_Box.wHTML = Box_HTML;
			this.Class_Tool_Box.ini();
			this.Class_Tool_Box.Center();
			this.Class_Tool_Box.Show();
			Show_Page_M_Box();
			
			this.Class_Name = Sys.getObj('Class_Name');
			this.Class_ENName = Sys.getObj('Class_ENName');
			this.Class_ReMake = Sys.getObj('Class_ReMake');
			this.Class_cState_A = Sys.getObj('Class_cState_A');
			this.Class_cState_B = Sys.getObj('Class_cState_B');
			this.Submit_B = Sys.getObj('Submit_B');
		break;
		case 'B': //修改分类
			this.Show_Class_Edit_Box();
		break;
	}
	Box_HTML = null;
}
TMain_Class.prototype.Show_Class_Edit_Box = function(eID)
{//返回修改分类的数据
	if(Trim(eID) != ''){
		ShowLoadBar();
		this.Selected_ClassID = eID;
		var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><CID>'+eID+'</CID></xml>';
		SysComm.PostData(tXML,Main_Class.Show_Class_Edit_Box_ReCall,'Re_Class');
		tXML = null;
	}
	else
	{
		alert('请选中一个分类.');
	}
}
TMain_Class.prototype.Show_Class_Edit_Box_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				this.E_Class_Name.disabled = '';
				this.E_Class_ENName.disabled = '';
				this.E_Class_ReMake.disabled = '';
				this.E_Class_cState_A.disabled = '';
				this.E_Class_cState_B.disabled = '';
				this.E_Submit_B.disabled = '';

				this.A_Button_A.disabled = '';
				this.A_Button_D.disabled = '';
				
				this.checkbox.disabled = '';
				
				Main_Class.E_Class_Name.value = GetXMLData(xmldom,'cName');
				Main_Class.E_Class_ENName.value = GetXMLData(xmldom,'cENName');
				Main_Class.E_Class_ReMake.value = GetXMLData(xmldom,'cRemake');
				if(GetXMLData(xmldom,'cState') == 'T')
				{
					Main_Class.E_Class_cState_A.checked = true;
					Main_Class.E_Class_cState_B.checked = false;
				}
				else
				{
					Main_Class.E_Class_cState_A.checked = false;
					Main_Class.E_Class_cState_B.checked = true;
				}
				Main_Class.E_CID = GetXMLData(xmldom,'cID');
				Main_Class.E_cUpID = GetXMLData(xmldom,'cUpID');
				
				Main_Class.Main_ClassAttribute.Class_Tool_Box = Main_Class.Class_Tool_Box;
				Main_Class.Main_ClassAttribute.UserCode = Main_Class.UserCode;
				Main_Class.Main_ClassAttribute.ClassID = Main_Class.E_CID;
				Main_Class.Main_ClassAttribute.ini();
				
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.Save_EditClass = function()
{//保存分类修改
	if(Trim(this.E_Class_Name.value) == ''){alert('请填写分类名称.');this.E_Class_Name.focus();return false;}
	else
	{this.E_Class_Name.value = Trim(this.E_Class_Name.value);}
	var cState = (this.E_Class_cState_A.checked) ? this.E_Class_cState_A.value : this.E_Class_cState_B.value;
	ShowLoadBar();
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+this.E_CID+'</cID><cName><![CDATA['+escape(this.E_Class_Name.value)+']]></cName><cENName><![CDATA['+escape(this.E_Class_ENName.value)+']]></cENName><cRemake><![CDATA['+escape(this.E_Class_ReMake.value)+']]></cRemake><cUpID>'+this.E_cUpID+'</cUpID><cState>'+cState+'</cState></xml>';
	SysComm.PostData(tXML,Main_Class.Save_EditClass_ReCall,'Edit_Class');
	tXML = null;
	cState = null;
}
TMain_Class.prototype.Save_EditClass_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));

			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.Save_EditClass_State = function(cID,cState)
{//修改分类状态
	ShowLoadBar();
	var State = (cState == 'T') ? 'F' : 'T';
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+cID+'</cID><cState>'+State+'</cState></xml>';
	SysComm.PostData(tXML,Main_Class.Save_EditClass_State_ReCall,'Edit_Class_State');
	State = null;
	tXML = null;
}
TMain_Class.prototype.Save_EditClass_State_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));

			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.Save_EditClass_TopShowState = function(cID,cState)
{//修改分类状态
	ShowLoadBar();
	var State = (cState == 'T') ? 'F' : 'T';
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+cID+'</cID><cTopShowState>'+State+'</cTopShowState></xml>';
	SysComm.PostData(tXML,Main_Class.Save_EditClass_TopShowState_ReCall,'Edit_Class_TopShowState');
	State = null;
	tXML = null;
}
TMain_Class.prototype.Save_EditClass_TopShowState_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));

			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
//分类属性部分
function TMain_ClassAttribute()
{
	this.ClassID = null;
	this.Button_Del = null;
	this.Main_ClassAttribute_List = null;
	this.Page_Bar = null;
	this.pcheckbox = null;
	
	this.Class_Tool_Box = null;
	
	this.List_Pagesize = 10;
	this.List_PageIndex = 1;
	this.List_Page_PageCount = 0;
	this.UserCode = '';
	
	this.aID = null;
	this.aName = null;
	this.aType = null;
	this.aState_A = null;
	this.aState_B = null;
	this.Submit_AF = null;
	this.ClassData_Box = null;
	this.ClassAttribute_List_Box = null;
	this.BoxAction = null;
	
	this.ShowHie_Tab = new SysComm.ShowHie_Tab;
	//this.Main_ClassAttribute_Value = new TMain_ClassAttribute_Value;
	
}
TMain_ClassAttribute.prototype.ini = function()
{
	this.Main_ClassAttribute_List = Sys.getObj('Main_ClassAttribute_List');
	this.Page_Bar = Sys.getObj('Page_Bar');
	this.ClassData_Box = Sys.getObj('ClassData_Box');
	this.ClassAttribute_List_Box = Sys.getObj('ClassAttribute_List_Box');
	this.Button_Del = Sys.getObj('A_Button_D');
	
	this.pcheckbox = 'checkbox';
	
	this.ShowHie_Tab.Tab.push(this.ClassData_Box);
	this.ShowHie_Tab.Tab.push(this.ClassAttribute_List_Box);
	
	//this.Main_ClassAttribute_Value.Class_Tool_Box = this.Class_Tool_Box;
	//this.Main_ClassAttribute_Value.UserCode = this.UserCode;
	//this.Main_ClassAttribute_Value.ini();
	
	this.ShowHie_Tab.SelectTab(this.ClassData_Box);
	this.ShowPage();
}
TMain_ClassAttribute.prototype.ShowPage = function()
{
	ShowLoadBar();
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+this.ClassID+'</cID><Pagesize>'+this.List_Pagesize+'</Pagesize><PageIndex>'+this.List_PageIndex+'</PageIndex><Word_Key><![CDATA[ ]]></Word_Key></xml>';
	SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.ShowPage_ReCall,'List_ClassAttribute');
	tXML = null;
}
TMain_ClassAttribute.prototype.ShowPage_ReCall = function(ReXML)
{
	var re_t;
	var tHTML = '';
	HitLoadBar();
	if(Trim(ReXML) != ''){
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				Main_Class.Main_ClassAttribute.List_Page_PageCount = GetXMLData(xmldom,'PageCount');
				Main_Class.Main_ClassAttribute.List_PageIndex = GetXMLData(xmldom,'PageIndex');
				re_t = true;
				var nodes = xmldom.getElementsByTagName('ClassAttribute_List');
				if(nodes.length>0){
					var aID = '';
					var cID = '';
					var aCode = '';
					var aName = '';
					var aType = '';
					var aState = '';
					var aOrder = '';
					var aAppendTime = '';
					var ListClassAttributeValue = '';
					var StateImg = '';
					var tChildNodesTool = '';
					var aType_Txt = '';
					var isThisClass = false;
					for(i=0;i<nodes.length;i++){
						if(nodes[i].hasChildNodes()){
							aID = GetXMLData(nodes[i],'aID');
							cID = GetXMLData(nodes[i],'cID');
							aCode = GetXMLData(nodes[i],'aCode');
							aName = GetXMLData(nodes[i],'aName');
							aType = GetXMLData(nodes[i],'aType');
							aState = GetXMLData(nodes[i],'aState');
							aOrder = GetXMLData(nodes[i],'aOrder');
							aAppendTime = GetXMLData(nodes[i],'aAppendTime');
							ListClassAttributeValue = GetXMLData(nodes[i],'ListClassAttributeValue');

							if(Number(cID) != Number(Main_Class.Main_ClassAttribute.ClassID)){isThisClass = false;}else{isThisClass = true;}
							if(isThisClass)
							{
								StateImg = (aState == 'T') ? '<img src="../Img/T.gif" border="0" style="cursor:hand;" onClick="javascript:Main_Class.Main_ClassAttribute.Edit_State(\''+aID+'\',\'F\');"/>' : '<img src="../Img/F.gif" border="0" style="cursor:hand;" onClick="javascript:Main_Class.Main_ClassAttribute.Edit_State(\''+aID+'\',\'T\');"/>';
								tChildNodesTool = (aType != '1') ? '<a href="javascript:void(0);" onclick="javascript:Main_Class.Main_ClassAttribute.Show_ValueBox('+aID+',\''+aName+'\','+aType+');return false;">[设定值]</a>' : '';
							}
							else
							{
								StateImg = (aState == 'T') ? '<img src="../Img/T.gif" border="0" style="cursor:hand;" />' : '<img src="../Img/F.gif" border="0" style="cursor:hand;" />';
								tChildNodesTool = '';
							}
							if(aType == '1')
							{
								aType_Txt = '<span title="产品维护时可以直接填写该属性值.(无默认值)">输入框</span>';
							}
							if(aType == '2')
							{
								aType_Txt = '<span title="产品维护时可以选择该属性得默认值.(有默认值)">单选</span>';
							}
							if(aType == '3')
							{
								aType_Txt = '<span title="产品维护时可以多选该属性得默认值.(有默认值)">复选</span>';
							}
							tHTML +='<tr style="cursor:hand;" bgcolor="#ffffff" onMouseOut="this.style.backgroundColor=\'#ffffff\'" onMouseOver="this.style.backgroundColor=\'#C6E0FD\'">'+
												'<td width="1%" align="left">'+((isThisClass) ? '<input type="checkbox" name="checkbox" value="'+aID+'" />':'')+'</td>'+
												'<td align="left">'+aName+'</td>'+
												'<td width="20%" align="left">'+aType_Txt+tChildNodesTool+'</td>'+
												//'<td width="15%" align="left">'+ListClassAttributeValue+'</td>'+
												'<td width="15%" align="left">'+StateImg+'</td>'+
												'<td width="15%" align="left">'+ aAppendTime +'</td>'+
												'<td width="15%" align="left">'+((isThisClass) ? '<a href="javascript:void(0);" onclick="javascript:Main_Class.Main_ClassAttribute.Edit_ShowBox(\''+aID+'\');return false;" >[修改]</a> <a href="javascript:void(0);" onclick="javascript:Main_Class.Main_ClassAttribute.Del_Sub_B(\''+aID+'\');return false;">[删除]</a>':'')+'</td>'+
												'</tr>';
						}
					}
					
					isThisClass = null;
					aType_Txt = null;
					tChildNodesTool = null;			  
					StateImg = null;
					aID = null;
					cID = null;
					aCode = null;
					aName = null;
					aType = null;
					aState = null;
					aOrder = null;
					aAppendTime = null;
					ListClassAttributeValue = null;
					
					Main_Class.Main_ClassAttribute.Main_ClassAttribute_List.innerHTML = '<table width="100%" border="0" cellspacing="1" cellpadding="1">'+tHTML+'</table>';
					Main_Class.Main_ClassAttribute.Page_Bar.innerHTML = '<div style="margin:2px;">'+C_Pager(Main_Class.Main_ClassAttribute.List_Page_PageCount,Main_Class.Main_ClassAttribute.List_PageIndex,'ListMSGList_toPage',Main_Class.Main_ClassAttribute.List_Pagesize)+'</div>';

				}else{
					Main_Class.Main_ClassAttribute.Main_ClassAttribute_List.innerHTML = '还没有任何数据';
				}
				nodes = null;
			}else{
				Main_Class.Main_ClassAttribute.Main_ClassAttribute_List.innerHTML = GetXMLData(xmldom,'MSG');
				re_t = false;
			}
			Error_Type = null;
		}else{
			re_t = false;
		}
		xmldom = null;
	}else{
		re_t = false;
	}
	tHTML = null;
	if(re_t){

	}
	else
	{

	}
	return re_t;
}
TMain_ClassAttribute.prototype.Edit_State = function(eID,eState)
{//修改属性状态
	var tTxt = (eState == 'T') ? '启用':'禁用';
	if(window.confirm('确定要 '+ tTxt+' 该属性吗?'))
	{
		ShowLoadBar();
		var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><AID>'+eID+'</AID><AState>'+eState+'</AState></xml>';
		SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Edit_State_ReCall,'Edit_ClassAttribute_State');
		tXML = null;
	}
	tTxt = null;
}
TMain_ClassAttribute.prototype.Edit_State_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.Main_ClassAttribute.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_ClassAttribute.prototype.Show_ToolBox = function()
{
	var tHTML = '<div style="width:250px" ><table width="100%" border="0" cellspacing="0" cellpadding="0">'+
				'<tr><td colspan="2" align="left"><b>分类属性</b></td>'+
				'</tr><tr><td colspan="2">&nbsp;</td>'+
				'</tr><tr><td width="40%" align="right">名称:</td>'+
				'<td align="left"><label><input name="aName" type="text" id="aName" maxlength="50" />'+
				'</label></td></tr><tr><td align="right">数据类型:</td><td align="left">'+
				'<select name="aType" id="aType">'+
				'<option value="1">输入框</option>'+
				'<option value="2">单选</option>'+
				'<option value="3">复选</option>'+
				'</select></td></tr><tr><td colspan="2" align="center">'+
				'<input name="aState" id="aState_A" type="radio" value="T" checked="checked" />正常'+
				'<input name="aState" id="aState_B" type="radio" value="F" /> 屏蔽</td>'+
				'</tr><tr><td colspan="2" align="center"><input type="submit" name="Submit_AF" id="Submit_AF" value="确定" onclick="javascript:Main_Class.Main_ClassAttribute.Add_Sub();"/>'+
				'<input type="button" name="Submit2" value="取消" onClick="javascript:HiddenToolBox();"/></td></tr>'+
				'<tr><td colspan="2">&nbsp;</td></tr></table></div>';
	this.Class_Tool_Box.wHTML = tHTML;
	this.Class_Tool_Box.ini();
	this.Class_Tool_Box.Center();
	this.Class_Tool_Box.Show();
	Show_Page_M_Box();
	
	this.aName = Sys.getObj('aName');
	this.aType = Sys.getObj('aType');
	this.aState_A = Sys.getObj('aState_A');
	this.aState_B = Sys.getObj('aState_B');
	this.Submit_AF = Sys.getObj('Submit_AF');
	
	tHTML = null;
				
}
TMain_ClassAttribute.prototype.Add_ShowBox = function()
{
	this.BoxAction = '';
	this.Show_ToolBox();
}
TMain_ClassAttribute.prototype.Edit_ShowBox = function(aID)
{//修改属性对话框
	if(aID != '')
	{
		this.aID = aID;
		this.BoxAction = 'Edit';
		this.Show_ToolBox();
		var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><AID>'+aID+'</AID></xml>';
		SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Edit_ShowBox_ReCall,'Re_ClassAttribute');
		tXML = null;
	}
}
TMain_ClassAttribute.prototype.Edit_ShowBox_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				this.aName.value = GetXMLData(xmldom,'aName');
				SysComm.selectedOption(this.aType,'',GetXMLData(xmldom,'aType'));
				
				if(GetXMLData(xmldom,'aState') == 'T')
				{
					this.aState_A.checked = true;
					this.aState_B.checked = false;
				}
				else
				{
					this.aState_A.checked = false;
					this.aState_B.checked = true;
				}
				
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_ClassAttribute.prototype.Check_F = function()
{
	if(Trim(this.aName.value) == ''){alert('请填写属性名称.');this.aName.focus();return false;}
	else
	{this.aName.value = Trim(this.aName.value);}
}
TMain_ClassAttribute.prototype.Add_Sub = function()
{//添加属性
	if(this.Check_F() != false)
	{
		ShowLoadBar();
		this.Submit_AF.disabled = 'disabled';
		if(this.BoxAction == 'Edit')
		{
			var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><aID>'+this.aID+'</aID><cID>'+this.ClassID+'</cID><aName><![CDATA['+escape(this.aName.value)+']]></aName><aType>'+SysComm.ReselectedOption_Value(this.aType)+'</aType><aState>'+((this.aState_A.checked)?'T':'F')+'</aState></xml>';
			SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Edit_Sub_ReCall,'Edit_ClassAttribute');
			tXML = null;
		}
		else
		{
			var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><cID>'+this.ClassID+'</cID><aName><![CDATA['+escape(this.aName.value)+']]></aName><aType>'+SysComm.ReselectedOption_Value(this.aType)+'</aType><aState>'+((this.aState_A.checked)?'T':'F')+'</aState><aOrder>0</aOrder></xml>';
			SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Add_Sub_ReCall,'Add_ClassAttribute');
			tXML = null;
		}
	}
}
TMain_ClassAttribute.prototype.Add_Sub_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		this.Submit_AF.disabled = '';
		HiddenToolBox();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
				
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.Main_ClassAttribute.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_ClassAttribute.prototype.Edit_Sub_ReCall = function(ReXML)
{
	try
	{
		HitLoadBar();
		this.Submit_AF.disabled = '';
		HiddenToolBox();
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
				
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.Main_ClassAttribute.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_ClassAttribute.prototype.Del_Sub = function()
{
	if(window.confirm('删除属性的同时系统会自动删除与该属性相关的所有数据.\n\n确定要这么做吗?'))
	{
		ShowLoadBar();
		this.Button_Del.disabled = 'disabled';
		var tCheckValue = SysComm.Re_checkbox_Value(this.pcheckbox);
		var tXML = '<xml><UserCode>'+this.UserCode+'</UserCode><aID>'+tCheckValue+' </aID></xml>';
		SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Del_Sub_ReCall,'Dll_ClassAttribute');
		tCheckValue = null;
		tXML = null;
	}
}
TMain_ClassAttribute.prototype.Del_Sub_B = function(dId)
{
	if(window.confirm('删除属性的同时系统会自动删除与该属性相关的所有数据.\n\n确定要这么做吗?'))
	{
		ShowLoadBar();
		this.Button_Del.disabled = 'disabled';
		var tCheckValue = SysComm.Re_checkbox_Value(this.pcheckbox);
		var tXML = '<xml><UserCode>'+this.UserCode+'</UserCode><aID>'+dId+' </aID></xml>';
		SysComm.PostData(tXML,Main_Class.Main_ClassAttribute.Del_Sub_ReCall,'Dll_ClassAttribute');
		tCheckValue = null;
		tXML = null;
	}
}
TMain_ClassAttribute.prototype.Del_Sub_ReCall = function(ReXML)
{
	Main_Class.Main_ClassAttribute.Button_Del.disabled = '';
	HitLoadBar();
	try
	{
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
				Main_Class.Main_ClassAttribute.ShowPage();
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_ClassAttribute.prototype.Show_ValueBox = function(aID,aName,aType)
{//显示属性值对话框

	if(aID != ''){
		this.aID = aID;
		this.aName = aName;
		this.aType = aType;
		
		this.Class_Tool_Box.wHTML = '<iframe style="width:380px;height:242px;overflow:hidden;" scroll="no" scrolling="no" frameborder="0" src="Main_Class_Attribute_Value.html?UCode='+Main_Class.OldUserCode+'&c='+Math.random()+'"></iframe>';
		this.Class_Tool_Box.ini();
		this.Class_Tool_Box.Center();
		this.Class_Tool_Box.Show();
		Show_Page_M_Box();
	}
}
TMain_Class.prototype.Re_CClassID = function(pClassID)
{//返回指定的分类的所有子级分类编号
	var reTxt = '';
	if(this.Tree.t_Tree.length > 0)
	{
		var i = 0;
		for(i = 0;i<this.Tree.t_Tree.length;i++)
		{
			if(this.Tree.t_Tree[i][2] == pClassID)
			{
				reTxt += this.Re_CClassID(this.Tree.t_Tree[i][0])+','+this.Tree.t_Tree[i][0];
			}
		}
		i = null;
	}
	return reTxt;
}
TMain_Class.prototype.Re_PClassID = function(pClassID)
{
	var reTxt = '';
	if(this.Tree.t_Tree.length > 0)
	{
		var i = 0;
		for(i = 0;i<this.Tree.t_Tree.length;i++)
		{
			if(this.Tree.t_Tree[i][0] == pClassID)
			{
				reTxt = this.Tree.t_Tree[i][2];
				break;
			}
		}
		i = null;
	}
	return reTxt;
}
TMain_Class.prototype.Re_tPClassID = function(pClassID)
{
	var reTxt = '';
	if(this.Tree.t_Tree.length > 0)
	{
		var i = 0;
		for(i = 0;i<this.Tree.t_Tree.length;i++)
		{
			if(this.Tree.t_Tree[i][2] == pClassID)
			{
				reTxt += ','+this.Tree.t_Tree[i][0];
			}
		}
		i = null;
	}
	return reTxt;
}
TMain_Class.prototype.EditClassToChild = function(sCID,tCID)
{//移动分类到指定分类
	ShowLoadBar();
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><sCID><![CDATA['+sCID+']]></sCID><tCID><![CDATA['+tCID+']]></tCID></xml>';
	SysComm.PostData(tXML,Main_Class.EditClassToChild_ReCall,'MoveToClassChild');
	tXML = null;
}
TMain_Class.prototype.EditClassToChild_ReCall = function(ReXML)
{
	HitLoadBar();
	try
	{
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
				Main_Class.ShowPage();
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
	}
	catch (e)
	{
		//alert(e.message);
	}
}
TMain_Class.prototype.EditClassToOrder = function(sCID,tCID,nCIDstr,pCID)
{//移动分类并排序该级分类,sCID=源,tCID=目标,nCIDstr=排序后的目标同级ID串,pCID=目标父级编号
	ShowLoadBar();
	var tXML = '<xml><UserCode><![CDATA['+ this.UserCode +']]></UserCode><sCID><![CDATA['+sCID+']]></sCID><tCID><![CDATA['+tCID+']]></tCID><nCIDstr><![CDATA['+nCIDstr+']]></nCIDstr><pCID><![CDATA['+pCID+']]></pCID></xml>';
	SysComm.PostData(tXML,Main_Class.EditClassToOrder_ReCall,'OrderToClassTop');
	tXML = null;
}
TMain_Class.prototype.EditClassToOrder_ReCall = function(ReXML)
{
	HitLoadBar();
	try
	{
		var xmldom = createXMLDOM();
		if(xmldom.loadXML(ReXML)){
			var Error_Type = GetXMLData(xmldom,'Error');
			if(Error_Type == "-1"){
				alert(GetXMLData(xmldom,'MSG'));
			}else{
				alert(GetXMLData(xmldom,'MSG'));
			}
			Error_Type = null;
		}else{
			alert('服务器返回代码格式错误.请联系管理员.');
		}
		xmldom = null;
		Main_Class.ShowPage();
	}
	catch (e)
	{
		//alert(e.message);
	}
}
//外部调用
function ListMSGList_toPage(page){
	try{
		Main_Class.Main_ClassAttribute.List_PageIndex = page;
		Main_Class.Main_ClassAttribute.ShowPage();
	}catch(e){

	}
}
function CheckTreeNode(sObj)
{//鼠标点击选中节点
	if(sObj)
	{
		var i;
		for(i=0;i<Main_Class.Tree.t_Tree.length;i++)
		{
			if(Main_Class.Tree.t_Tree[i][3].id == sObj.id)
			{
				Main_Class.Show_Class_Edit_Box(Main_Class.Tree.t_Tree[i][0]);
			}
		}
	}
}
function CheckTreeNodeState(sObj)
{//鼠标点击修改状态
	if(sObj)
	{
		Main_Class.Save_EditClass_State(sObj.c_ID,sObj.c_State);
	}
}
function CheckTreeNodeTopShowState(sObj)
{//鼠标点击修改状态
	if(sObj)
	{
		Main_Class.Save_EditClass_TopShowState(sObj.c_ID,sObj.c_State);
	}
}
function CheckTreeNodeAdd(sObj)
{//添加子分类
	Main_Class.Add_Class();
}
function CheckTreeNodeDel(sObj)
{//删除该分类
	Main_Class.Del_Class();
}
function ShowTab(sObj)
{//切换标签
	Main_Class.Main_ClassAttribute.ShowHie_Tab.SelectTab(Sys.getObj(sObj));
}
function HiddenToolBox()
{//隐藏对话框
	Main_Class.Class_Tool_Box.Hidden();
	Hit_Page_M_Box();
}
function Add_Class_Attribute_Value()
{//添加分类属性值
	Main_Class.Main_ClassAttribute.Main_ClassAttribute_Value.Add_Class_Attribute_Value();
}
function Edit_Class_Attribute_Value()
{//修改分类属性值
	Main_Class.Main_ClassAttribute.Main_ClassAttribute_Value.Edit_Class_Attribute_Value();
}
function Del_Class_Attribute_Value()
{//删除分类属性值
	Main_Class.Main_ClassAttribute.Main_ClassAttribute_Value.Del_Class_Attribute_Value();
}
function Re_Class_Attribute_Value()
{//刷新分类属性值树
	Main_Class.Main_ClassAttribute.Main_ClassAttribute_Value.Re_Class_Attribute_Value();
}

function MoveFunction(sObj,tObj)
{//移动分类,sObj=选中的对象,tObj=目的对象

//目标有 "_treenode0_0" 标示移动到该分类前,没有则移动到该分类里

	if(sObj)
	{
		if(tObj)
		{
			var sCID = sObj.c_ID;
			var tCID = tObj.c_ID;

			var sCName = sObj.c_Name;
			var tCName = tObj.c_Name;
			var IsMoveToChild = false;//是否为移动到子分类

			if(sCID != tCID && sCName != 'undefined' && tCName != 'undefined')
			{
				var message='您是否要将\"'+sCName+'\"移动到\"'+tCName+'\"';
				if(tObj.id.indexOf('_treenode0_0')>-1)
				{
					message+='之前吗?';
					IsMoveToChild = false;
				}
				else
				{
					message+='的子分类下吗?';
					IsMoveToChild = true;
				}
				if(confirm(message))
				{
					//找出选中对象的父级节点编号集合,判断是否可以移动,避免本级移动到自身子节点的错误
					if(IsMoveToChild)
					{
						var cClassID = ','+Main_Class.Re_CClassID(sCID)+',';
						if(cClassID.indexOf(','+tCID+',') > -1)
						{
							alert('无法将该分类移动到自己的子分类中');
						}
						else
						{
							Main_Class.EditClassToChild(sCID,tCID);
						}
						
						cClassID = null;
					}
					else
					{
						//获取目标分类的父级分类编号
						var pClassID_s = Main_Class.Re_PClassID(sCID);
						var pClassID_t = Main_Class.Re_PClassID(tCID);
						//获取目标分类的所有同级分类编号
						var ClassID_tt = ','+Main_Class.Re_tPClassID(pClassID_t)+',';
						var pClassID_t_index = ClassID_tt.indexOf(','+tCID+',');
						if(pClassID_t_index>-1)
						{
							//截取目标分类前后编号
							ClassID_tt = ClassID_tt.replace(sCID,'');
							var ClassID_t_A = ClassID_tt.substring(0,pClassID_t_index);
							var ClassID_t_B = ClassID_tt.substring(pClassID_t_index,ClassID_tt.length);
							var ClassID_t_C = ClassID_t_A+','+sCID+','+ClassID_t_B;

							Main_Class.EditClassToOrder(sCID,tCID,ClassID_t_C,pClassID_t);
						}
						
						pClassID_t_index = null;
						pClassID_s = null;
						pClassID_t = null;
						ClassID_tt = null;
					}
				}
			}
			sCID = null;
			tCID = null;
			sCName = null;
			tCName = null;
		}
	}
}
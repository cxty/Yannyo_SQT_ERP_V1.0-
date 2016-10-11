
function Tmanage_class()
{
	this.AValue_Tree = null;
    this.AValue_Title = null;
    this.Value_T = null;
	this.Submit_AValue = null;
	this.Edit_AValue = null;
	this.Class_Tool_Box = null;
	this.Del_AValue = null;
	this.Re_AValue = null;
	
	this.CAID = null;//操作的分类属性编号
	this.CAName = null;//名称
	this.CAType = null;//类型
    this.CAV_Tree = new WebFXTree('地区');//树
	this.CAV_Tree.setBehavior('classic');
	this.Tree = null;
	this.Selected_VID = null;//当前选中的分类属性值编号
	this.Selected_VID_UPID = null;
	
	this.parentObj = null;
	this.NavHtmlStr = '';
	this.NavBar = null;

	this.PaterID = Trim(GetQueryString('pid'))==''?0:Number(GetQueryString('pid'));

}
Tmanage_class.prototype.ini = function()
{
	this.AValue_Tree = Sys.getObj('AValue_Tree');
    this.AValue_Title = Sys.getObj('AValue_Title');
    this.Value_T = Sys.getObj('Value_T');
	this.Edit_AValue = Sys.getObj('Edit_AValue');
	this.Del_AValue = Sys.getObj('Del_AValue');
	this.Re_AValue = Sys.getObj('Re_AValue');
	this.Submit_AValue = Sys.getObj('Submit_AValue');
	this.NavBar = Sys.getObj('NavBar');
	this.parentObj = parent.DataTypeBody_Add;
	
	this.ShowPage();
}
Tmanage_class.prototype.ShowPage = function()
{
	this.ShowBox(this.CAID,this.CAName,this.CAType);
}
Tmanage_class.prototype.ShowTree = function(nodes)
{
    if(this.Tree == null)
	{
		this.Tree = new cavPublicBuild_Tree;
		this.Tree.PageTreeObj = this.CAV_Tree;
		this.Tree.pid = this.PaterID;
		this.Tree.ini(nodes,0);
	}
	else
	{
		this.Tree.Reini(nodes,0);
	}
}
Tmanage_class.prototype.Re_ClassObj = function()
{//返回当前选中对象
	var SelectEdTObj = this.CAV_Tree.getSelected();
	if(SelectEdTObj)
	{
		if(SelectEdTObj == this.CAV_Tree)
		{//根返回空
			return null;
		}
		else
		{
			return SelectEdTObj;
		}
	}
}
Tmanage_class.prototype.Re_SelectID = function()
{
	try{
		var tRe = new Array(1);
		if(this.Re_ClassObj() == null)
		{
			tRe[0] = 0;
			tRe[1] = 0;
		}
		else
		{
			tRe[0] = this.Tree.getCheckedValue(this.Re_ClassObj().id);
			tRe[1] = this.Tree.getCheckedValueUp(this.Re_ClassObj().id);
		}
		return tRe;
		tRe = null;
	}catch(e)
	{

	}
}
Tmanage_class.prototype.Re_CClassID = function(pClassID)
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
Tmanage_class.prototype.Re_PClassID = function(pClassID)
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
Tmanage_class.prototype.Re_tPClassID = function(pClassID)
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
Tmanage_class.prototype.CheckF = function()
{//验证数据
	if(Trim(this.Value_T.value) == ''){alert('请填写名称.');this.Value_T.focus();return false;}
	else
	{this.Value_T.value = Trim(this.Value_T.value);}
}
Tmanage_class.prototype.Add_Class_Attribute_Value = function()
{//添加
	if(this.CheckF() != false)
	{
		var AID = this.Re_SelectID();
		if(isArray(AID))
		{
			if(this.PaterID>0 && Number(AID[0])==0)
			{
				AID[0] = this.PaterID;
			}
			var vArray = this.Value_T.value.split(' ');
			
			for(var j=0;j<vArray.length;j++)
			{
				if(Trim(vArray[j])!='')
				{
						var url = 'Services/CAjax.aspx?do=AddRegion&RCode='+Math.random();
						tXML = '<xml>'+
						''+
						'<PaterID><![CDATA['+AID[0]+']]></PaterID>'+
						'<vValue><![CDATA['+vArray[j]+']]></vValue>'+
						'</xml>';
						var xml = new HTTPXml();
						xml.load(tXML,true,'POST',url);
						xml.onComplete = function(){
				
							//manage_class.ReAdd_Class_Attribute_Value(xml);
				
						}
						tXML = null;
						url = null;
					}
			}
			vArray = null;
			this.Re_Class_Attribute_Value();
		}
		else
		{
			alert('请选择一个节点.');
		}
		AID = null;
	}
}
Tmanage_class.prototype.ReAdd_Class_Attribute_Value = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Re_Class_Attribute_Value();
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
}
Tmanage_class.prototype.Edit_Class_Attribute_Value = function()
{//修改
	if(this.CheckF() != false)
	{
		var AID = this.Re_SelectID();
		if(isArray(AID))
		{
			var url = 'Services/CAjax.aspx?do=EditRegion&RCode='+Math.random();
			tXML = '<xml>'+
			'<RegionID><![CDATA['+AID[0]+']]></RegionID>'+
			''+
			'<PaterID><![CDATA['+AID[1]+']]></PaterID>'+
			'<vValue><![CDATA['+this.Value_T.value+']]></vValue>'+
			'</xml>';
			var xml = new HTTPXml();
			xml.load(tXML,true,'POST',url);
	        xml.onComplete = function(){
	
	            manage_class.ReEdit_Class_Attribute_Value(xml);
	
	        }
	        tXML = null;
	        url = null;
		}else
		{
			alert('请选择一个节点');
		}
		AID = null;
	}
}
Tmanage_class.prototype.ReEdit_Class_Attribute_Value = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Re_Class_Attribute_Value();
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
}
Tmanage_class.prototype.Del_Class_Attribute_Value = function()
{//删除
	var AID = this.Re_SelectID();
	if(isArray(AID))
	{
		if (AID[0] > 0) {
			var url = 'Services/CAjax.aspx?do=DelRegion&RCode=' + Math.random();
			tXML = '<xml>' +
			'' +
			'<RegionID><![CDATA[' +
			AID[0] +
			']]></RegionID>' +
			'</xml>';
			var xml = new HTTPXml();
			xml.load(tXML, true, 'POST', url);
			xml.onComplete = function(){
			
				manage_class.ReDel_Class_Attribute_Value(xml);
				
			}
			tXML = null;
			url = null;
		}else
		{
			alert('请选择一个节点');
		}
	}else
	{
		alert('请选择一个节点');
	}
	AID = null;
}
Tmanage_class.prototype.ReDel_Class_Attribute_Value = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Re_Class_Attribute_Value();
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
}
Tmanage_class.prototype.Re_Class_Attribute_Value = function()
{//刷新
	this.ShowBox();
}
Tmanage_class.prototype.Set_Class_Attribute_Value = function()
{
	//window.open('DataType_Add_Master-'+this.Re_SelectID()[0]+'.aspx');
}
Tmanage_class.prototype.EditClassToChild = function(sCID,tCID)
{//移动分类到指定分类
	ShowLoadBar();
	var url = 'Services/CAjax.aspx?do=EditRegionPaterID&RCode='+Math.random();
	tXML = '<xml>'+
	''+
	'<RegionID><![CDATA['+sCID+']]></RegionID>'+
	'<PaterID><![CDATA['+tCID+']]></PaterID>'+
	'</xml>';
	var xml = new HTTPXml();
	xml.load(tXML,true,'POST',url);
    xml.onComplete = function(){

        manage_class.ReEditClassToChild(xml);

    }
    tXML = null;
    url = null;
}
Tmanage_class.prototype.ReEditClassToChild = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Re_Class_Attribute_Value();
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
	HitLoadBar();
}
Tmanage_class.prototype.EditClassToOrder = function(sCID,tCID,nCIDstr,pCID)
{//移动分类并排序该级分类,sCID=源,tCID=目标,nCIDstr=排序后的目标同级ID串,pCID=目标父级编号
	ShowLoadBar();
	var url = 'Services/CAjax.aspx?do=EditRegionOrder&RCode='+Math.random();
	tXML = '<xml>'+
	''+
	'<sCID><![CDATA['+sCID+']]></sCID>'+
	'<tCID><![CDATA['+tCID+']]></tCID>'+
	'<nCIDstr><![CDATA['+nCIDstr+']]></nCIDstr>'+
	'<pCID><![CDATA['+pCID+']]></pCID>'+
	'</xml>';
	var xml = new HTTPXml();
	xml.load(tXML,true,'POST',url);
    xml.onComplete = function(){

        manage_class.ReEditClassToOrder(xml);

    }
    tXML = null;
    url = null;
}
Tmanage_class.prototype.ReEditClassToOrder = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Re_Class_Attribute_Value();
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
	HitLoadBar();
}
Tmanage_class.prototype.ShowBox = function(){
			
	var aType_Txt = '';
	switch(this.CAType)
	{
		case '13':case 13:
			aType_Txt = '<span title="支持多级下拉.(有默认值)">下拉列表</span>';
		break;
		case '14':case 14:
			aType_Txt = '<span title="可以多选该属性的默认值.(有默认值)">复选</span>';
		break;
		case '15':case 15:
			aType_Txt = '<span title="可以选择该属性的默认值.(有默认值)">单选</span>';
		break;
	}
			
	this.AValue_Title.innerHTML = '属性值('+aType_Txt+')';
	this.AValue_Tree.innerHTML = this.CAV_Tree;
	aType_Txt = null;
		
		
	//if(this.DataTypeBodyID>0)
	{
		ShowLoadBar();
		if(this.PaterID>0)
		{
			var url = 'Services/CAjax.aspx?do=GetRegionTreeChildList_noCaches&RCode='+Math.random();
		}else
		{
			var url = 'Services/CAjax.aspx?do=GetRegionTreeList_noCaches&RCode='+Math.random();
		}
		tXML = '<xml>'+
		'<PaterID>'+this.PaterID+'</PaterID>'+
		'</xml>';
		var xml = new HTTPXml();
		xml.load(tXML,true,'POST',url);
        xml.onComplete = function(){

            manage_class.ReShowBox(xml);

        }
        tXML = null;
        url = null;
	}
	//else
	{
	//	alert('对不起参数错误.');
	}
}
Tmanage_class.prototype.ReShowBox = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.ShowTree(xml.selectNodes('//root/RegionValues'));
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
	HitLoadBar();
}
Tmanage_class.prototype.GetNavHtmlStr = function()
{//返回选择分类的导航html
	var tHTML = '';
	var AID = this.Re_SelectID();
	if (isArray(AID)) {
		if (AID[0] > 0) {
			tHTML = this.GetNavHtmlStr_loop(AID[1])+'->'+this.GetNavHtmlStr_Self(AID[0]);
		}else
		{
			tHTML='';
		}
	}
	this.NavBar.innerHTML=tHTML;
}
Tmanage_class.prototype.GetNavHtmlStr_loop = function(pClassID)
{
	var reTxt='';
	if(this.Tree.t_Tree.length > 0)
	{
		var i = 0;
		for(i = 0;i<this.Tree.t_Tree.length;i++)
		{
			if(this.Tree.t_Tree[i][0] == pClassID)
			{
				reTxt = this.GetNavHtmlStr_loop(this.Tree.t_Tree[i][2])+'->'+this.Tree.t_Tree[i][1];
				break;
			}
		}
		i = null;
	}
	return reTxt;
}
Tmanage_class.prototype.GetNavHtmlStr_Self = function(SelfID)
{
	var reTxt='';
	if(this.Tree.t_Tree.length > 0)
	{
		var i = 0;
		for(i = 0;i<this.Tree.t_Tree.length;i++)
		{
			if(this.Tree.t_Tree[i][0] == SelfID)
			{
				reTxt = this.Tree.t_Tree[i][1];
				break;
			}
		}
		i = null;
	}
	return reTxt;
}

//外部调用
function CheckTreeNode(sObj)
{//鼠标点击选中节点
	if(sObj)
	{
		for(i=0;i<manage_class.Tree.t_Tree.length;i++)
		{
			if(manage_class.Tree.t_Tree[i][3].id == sObj.id)
			{
				manage_class.Selected_VID = manage_class.Tree.t_Tree[i][0];
				manage_class.Value_T.value = manage_class.Tree.t_Tree[i][1];
			}
		}
		manage_class.GetNavHtmlStr();
	}
}
function CheckTreeExpandNode(sObj)
{
	if (sObj) {
		var i;
		for(i=0;i<manage_class.Tree.t_Tree.length;i++)
		{
			if(manage_class.Tree.t_Tree[i][3].id == sObj.id.replace('-plus',''))
			{
				manage_class.Tree.t_Tree[i][3].expand();
			}
		}
	}
}
function GetNavHtmlStr()
{
	manage_class.GetNavHtmlStr();
}
function CheckTreeNodeState(sObj)
{//鼠标点击修改状态
	if(sObj)
	{
		location='diqu.aspx?pid='+sObj.c_ID;
		//window.open('DataType_Add_Master-'+sObj.c_ID+'.aspx');
		//manage_class.Save_EditClass_State(sObj.c_ID,sObj.c_State);
	}
}
function Add_Class_Attribute_Value()
{
	manage_class.Add_Class_Attribute_Value();
}
function Edit_Class_Attribute_Value()
{
	manage_class.Edit_Class_Attribute_Value();
}
function Del_Class_Attribute_Value()
{
	manage_class.Del_Class_Attribute_Value();
}
function Re_Class_Attribute_Value()
{
	manage_class.Re_Class_Attribute_Value();
}
function Set_Class_Attribute_Value()
{
	manage_class.Set_Class_Attribute_Value();
}
function MoveFunction(sObj,tObj)
{//移动分类,sObj=选中的对象,tObj=目的对象

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
				if(tObj.id.indexOf('_treenode1')>-1)
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
						var cClassID = ','+manage_class.Re_CClassID(sCID)+',';
						if(cClassID.indexOf(','+tCID+',') > -1)
						{
							alert('无法将该分类移动到自己的子分类中');
						}
						else
						{
							manage_class.EditClassToChild(sCID,tCID);
						}
						
						cClassID = null;
					}
					else
					{
						//获取目标分类的父级分类编号
						var pClassID_s = manage_class.Re_PClassID(sCID);
						var pClassID_t = manage_class.Re_PClassID(tCID);
						//获取目标分类的所有同级分类编号
						var ClassID_tt = ','+manage_class.Re_tPClassID(pClassID_t)+',';
						var pClassID_t_index = ClassID_tt.indexOf(','+tCID+',');
						if(pClassID_t_index>-1)
						{
							//截取目标分类前后编号
							ClassID_tt = ClassID_tt.replace(sCID,'');
							var ClassID_t_A = ClassID_tt.substring(0,pClassID_t_index);
							var ClassID_t_B = ClassID_tt.substring(pClassID_t_index,ClassID_tt.length);
							var ClassID_t_C = ClassID_t_A+','+sCID+','+ClassID_t_B;

							manage_class.EditClassToOrder(sCID,tCID,ClassID_t_C,pClassID_t);
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
			//Re_Class_Attribute_Value();
		}
	}
}
/*
   @author cxty@msn.com
   创建,Input,Select,Checkbox等对象
   sType=对象类型
   sTxt=显示文字
   sValue_nodes=值XML,格式:
 					<sData>
						<sValue>默认值</sValue>
						<sTxt>显示文字</sTxt>
					</sData>
	iAction=回调函数,用于用户点击对象的相应事件
	ObjKey=对象代码,用于程序识别
 */
//重写String
String.prototype.Trim = function() { 
var m = this.match(/^\s*(\S+(\s+\S+)*)\s*$/); 
return (m == null) ? "" : m[1]; 
}

String.prototype.isMobile = function() { 
return (/^(?:13\d|15[89])-?\d{5}(\d{3}|\*{3})$/.test(this.Trim())); 
}

String.prototype.isTel = function()
{
    //"兼容格式: 国家代码(2到3位)-区号(2到3位)-电话号码(7到8位)-分机号(3位)"
    return (/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/.test(this.Trim()));
}
String.prototype.isUrl = function()
{
    return (/^[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/.test(this.Trim()));
}
String.prototype.isEmail = function()
{
    return (/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(this.Trim()));
}
String.prototype.isIdCardNo =function()
{
     num = this.Trim();
     var factorArr = new Array(7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2,1);
     var error;
     var varArray = new Array();
     var intValue;
     var lngProduct = 0;
     var intCheckDigit;
     var intStrLen = num.length;
     var idNumber = num;
     // initialize
     if ((intStrLen != 15) && (intStrLen != 18)) {
         //error = "输入身份证号码长度不对！";
         //alert(error);
         //frmAddUser.txtIDCard.focus();
         return false;
     }
     // check and set value
     for(i=0;i<intStrLen;i++) {
         varArray[i] = idNumber.charAt(i);
         if ((varArray[i] < '0' || varArray[i] > '9') && (i != 17)) {
             //error = "错误的身份证号码！.";
             //alert(error);
             //frmAddUser.txtIDCard.focus();
             return false;
         } else if (i < 17) {
             varArray[i] = varArray[i]*factorArr[i];
         }
    }
     if (intStrLen == 18) {
         //check date
        var date8 = idNumber.substring(6,14);
        if (checkDate(date8) == false) {
			//error = "身份证中日期信息不正确！.";
             //alert(error);
             return false;
         }
        // calculate the sum of the products
         for(i=0;i<17;i++) {
             lngProduct = lngProduct + varArray[i];
         }
         // calculate the check digit
         intCheckDigit = 12 - lngProduct % 11;
         switch (intCheckDigit) {
             case 10:
                 intCheckDigit = 'X';
                 break;
             case 11:
                 intCheckDigit = 0;
                 break;
             case 12:
                 intCheckDigit = 1;
                 break;
         }
         // check last digit
         if (varArray[17].toUpperCase() != intCheckDigit) {
             //error = "身份证效验位错误!正确为： " + intCheckDigit + ".";
             //alert(error);
            return false;
         }
     }
     else{        //length is 15
         //check date
         var date6 = idNumber.substring(6,12);
         if (checkDate(date6) == false) {
             //alert("身份证日期信息有误！.");
             return false;
         }
     }
     //alert ("Correct.");
     return true;
 }
 
 var TCxty_XTool_Config = {
	 idCounter : 0,
	 idPrefix  : 'Cxty_XTool_Obj',
	 all       : {},
	 getId     : function() { return this.idPrefix + this.idCounter++; },
	 onchange   : function (oItem) { return this.all[oItem.id].onchange(oItem); },//下拉列表专用
	 onmap : function(oItem,IsReturn){return this.all[oItem].onmap(IsReturn);},//地图
	 onediter : function(oItem){return this.all[oItem].onediter();},//多功能编辑器
	 insertHTMLBeforeEnd	:	function (oElement, sHTML) {
		if (oElement.insertAdjacentHTML != null) {
			oElement.insertAdjacentHTML("BeforeEnd", sHTML)
			return;
		}
		var df;	// DocumentFragment
		var r = oElement.ownerDocument.createRange();
		r.selectNodeContents(oElement);
		r.collapse(false);
		df = r.createContextualFragment(sHTML);
		oElement.appendChild(df);
	}
};
function TCxty_XTool(sType,sTxt,sValue_nodes,iAction,eParent,ObjKey,PageBox)
{
	this.base = TCxty_XTool_Obj;
	this.base(sType,sTxt,sValue_nodes,iAction,eParent);
	this._sType = (sType) ? sType:1;
	this._sTxt = (sTxt) ? sTxt:'';
	this._sValue_nodes = (sValue_nodes) ? sValue_nodes:null;
	this._iAction = (iAction) ? iAction:'';
	this._ObjKey = (ObjKey) ? ObjKey:this.id;
	this._NodesArray = new Array();
	this.XMLtoArray(this._sValue_nodes);
	
	this._PageBox = (PageBox)?PageBox:null;
	
	this._SelectObj = null;
	
	this._EditerObj = null;
}
TCxty_XTool.prototype = new TCxty_XTool_Obj;

TCxty_XTool.prototype.toString = function()
{
	var tStr = '';
	switch(this._sType)
	{
	    //文本输入框
		case 'Input': case '1': case 1:
			tStr = this.Input_toString();
		break;
		//数字输入框
		case 'Number':case '2': case 2:
		    tStr = this.Input_toString(2);
		break;
		//日期输入框
		case 'Date':case '3': case 3:
		    tStr = this.Input_toString(3);
		break;
		//图片上传
		case 'UpImg':case '4': case 4:
		    //tStr = 
		break;
		//视频
		case 'Video':case '5': case 5:
		    //tStr = 
		break;
		//音频
		case 'Sound':case '6': case 6:
		    //tStr = 
		break;
		//电话号码
		case 'Tel':case '7': case 7:
		    tStr = this.Input_toString(7);
		break;
		//手机号码
		case 'Mobile':case '8': case 8:
		    tStr = this.Input_toString(8);
		break;
		//经纬度
		case 'LonLat':case '9': case 9:
		    tStr = this.LonLat_toString();
		break;
		//网址
		case 'URL':case '10': case 10:
		    tStr = this.Input_toString(10);
		break;
		//邮箱
		case 'Email':case '11': case 11:
		    tStr = this.Input_toString(11);
		break;
		//身份证
		case 'IDCard':case '12': case 12:
		    tStr = this.Input_toString(12);
		break;
		//下来框
		case 'Select': case '13': case 13:
			tStr = this.Select_toString();
		break;
		//复选框
		case 'Checkbox': case '14': case 14:
			tStr = this.Checkbox_toString();
		break;
		//单选框
		case 'Checkbox': case '15': case 15:
			tStr = this.Radio_toString();
		break;
		//路线
		case 'Route': case '16': case 16:
			tStr = this.Route_toString();
		break;
		//多行文本框
		case 'InputBox': case '17': case 17:
			tStr = this.Input_toString(13);
		break;
	}
	return '<div id="'+this.id+'_Box">'+tStr+'</div>';
}
TCxty_XTool.prototype.Input_toString = function(oType)
{
    oType = (oType)?oType:1;
	var tStr = '';
	switch(oType)
	{
	    case 2://数字
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onkeyup="value=value.replace(/[^\d.]/g,\'\')"   onbeforepaste="clipboardData.setData(\'text\',clipboardData.getData(\'text\').replace(/[^\d.]/g,\'\'))"  />';
	    break;
	    case 3://日期
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onclick="new Calendar().show(this);" />';
	    break;
	    case 7://电话号码
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onblur="if(!this.value.isTel()){alert("电话号码格式错误.");this.focus();this.value="";}" />';
	    break;
	    case 8://手机号码
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onblur="if(!this.value.isMobile()){alert("手机号码格式错误.");this.focus();this.value="";}" />';
	    break;
	    case 10://网址
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onblur="if(!this.value.isUrl()){alert("网址格式错误.");this.focus();this.value="";}" />';
	    break;
	    case 11://邮箱
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onblur="if(!this.value.isEmail()){alert("Email地址格式错误.");this.focus();this.value="";}" />';
	    break;
	    case 12://身份证
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" onblur="if(!this.value.isIdCardNo()){alert("身份证号码格式错误.");this.focus();this.value="";}" />';
	    break;
		case 13://多行文本框
			tStr = '<textarea xTool="xeditor" name="'+this.id+'" KeyID="'+this._ObjKey+'" id="'+this.id+'" style="width:80%" rows="10" onclick="javascript:TCxty_XTool_Config.onediter(\''+this.id+'\');"></textarea>';
		break;
	    default:
	        tStr = '<input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="text" id="'+this.id+'" />';
	    break;
	}
	return tStr;
	tStr = null;
}
TCxty_XTool.prototype.LonLat_toString = function()
{//地图,点
	tStr = '<ul id="'+this.id+'">'+
			'<li><nobr>纬度:<input name="'+this.id+'_Lat" id="'+this.id+'_Lat" type="text"></nobr></li>'+
			'<li><nobr>经度:<input name="'+this.id+'_Lon" id="'+this.id+'_Lon" type="text"></nobr></li>'+
			'<li><a href="javascript:void(0);" onclick="javascript:TCxty_XTool_Config.onmap(\''+this.id+'\',true);"><img src="/images/Map.png" border="0"></a></li>'+
			'</ul>';

	return tStr;
}
TCxty_XTool.prototype.Route_toString = function()
{//地图,线
	//onmap_line
	tStr = '<ul id="'+this.id+'">'+
			'</ul>';
	return tStr;
}
TCxty_XTool.prototype.Select_toString = function()
{
	this._SelectObj = new TCxty_XTool_Select(this.id,this._ObjKey,this._NodesArray);
	return this._SelectObj;
}
TCxty_XTool.prototype.Checkbox_toString = function()
{
	var tStr = '';
	var i;
	if(this._sValue_nodes)
	{
		for(i=0;i<this._sValue_nodes.length;i++)
		{
			if(this._sValue_nodes[i].hasChildNodes())
			{
				tStr += '<nobr><input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="checkbox" id="'+this.id+'_'+i+'" value="'+GetXMLData(this._sValue_nodes[i],'DataTypeBodyValueID')+'" onclick="'+this._iAction+'" tTxt="'+GetXMLData(this._sValue_nodes[i],'bvValue')+'"/><label for="'+this.id+'_'+i+'">'+GetXMLData(this._sValue_nodes[i],'bvValue')+'&nbsp;</label></nobr>';
			}
		}
	}
	i = null;
	return tStr;
	tStr = null;
}
TCxty_XTool.prototype.Radio_toString = function()
{
	var tStr = '';
	var i;
	if(this._sValue_nodes)
	{
		for(i=0;i<this._sValue_nodes.length;i++)
		{
			if(this._sValue_nodes[i].hasChildNodes())
			{
				tStr += '<nobr><input name="'+this.id+'" KeyID="'+this._ObjKey+'" type="radio" id="'+this.id+'_'+i+'" value="'+GetXMLData(this._sValue_nodes[i],'ataTypeBodyValueID')+'" onclick="'+this._iAction+'" tTxt="'+GetXMLData(this._sValue_nodes[i],'bvValue')+'"/><label for="'+this.id+'_'+i+'">'+GetXMLData(this._sValue_nodes[i],'bvValue')+'&nbsp;</label></nobr>';
			}
		}
	}
	i = null;
	return tStr;
	tStr = null;
}
TCxty_XTool.prototype.getValue = function()
{//返回对象值
	var tStr = '';
	switch(this._sType)
	{
		case 'Input': case '1': case 1:case 'Number':case '2': case 2:case 'Date':case '3': case 3:case 'Tel':case '7': case 7:case 'Mobile':case '8': case 8:case 'URL':case '10': case 10:case 'Email':case '11': case 11:case 'IDCard':case '12': case 12:case 'InputBox': case '17': case 17:
			tStr = document.getElementById(this.id).value;
		break;
		case 'LonLat':case '9': case 9:
			tStr = [document.getElementById(this.id+'_Lat').value,document.getElementById(this.id+'_Lon').value];
		break;
		case 'Select': case '13': case 13:
			tStr = this._SelectObj.getValue();
		break;
		case 'Checkbox': case '14': case 14:
			tStr = SysComm.Re_checkbox_Value(this.id);
		break;
		case 'Radio': case '15': case 15:
			tStr = SysComm.Re_radio_Value(this.id);
		break;
	}
	return tStr;
	tStr = null;
}
TCxty_XTool.prototype.getValueB = function()
{
	var tStr = '';
	switch(this._sType)
	{
		case 'Select': case '13': case 13:
			tStr = this._SelectObj.LastUpValue;
		break;
	}
	return tStr;
	tStr = null;
}
TCxty_XTool.prototype.getPValue = function(pValue)
{//递归获取所有父级编号
	var reTxt = '';
	if(this._NodesArray.length > 0)
	{
		var i = 0;
		for(i = 0;i<this._NodesArray.length;i++)
		{
			if(this._NodesArray[i][0] == pValue)
			{
				reTxt += this.getPValue(this._NodesArray[i][2])+','+this._NodesArray[i][0];
			}
		}
		i = null;
	}
	return reTxt;
}
TCxty_XTool.prototype.setValue = function(sValue)
{
	switch(this._sType)
	{
		case 'Input': case '1': case 1:case 'Number':case '2': case 2:case 'Date':case '3': case 3:case 'Tel':case '7': case 7:case 'Mobile':case '8': case 8:case 'URL':case '10': case 10:case 'Email':case '11': case 11:case 'IDCard':case '12': case 12:case 'InputBox': case '17': case 17:
			document.getElementById(this.id).value = sValue;
		break;
		case 'LonLat':case '9': case 9:
			var tem_sValue = null;
			try{
				if(sValue.indexOf(',')>-1)
				{
					tem_sValue = sValue.split(',');
				}
			}catch(e)
			{
				tem_sValue = [sValue.lat(),sValue.lng()];
			}
			if(tem_sValue)
			{
				document.getElementById(this.id+'_Lat').value = tem_sValue[0];
				document.getElementById(this.id+'_Lon').value = tem_sValue[1];
			}
			tem_sValue = null;

		break;
		case 'Select': case '13': case 13:
			this.setValue_Select(sValue);
		break;
		case 'Checkbox': case '14': case 14:
			this.setValue_Checkbox(sValue);
		break;
		case 'Radio': case '15': case 15:
			this.setValue_Radio(sValue);
		break;
	}
}
TCxty_XTool.prototype.setValue_Select = function(sValue)
{
	//取所有父编号
	sValue = ',0'+this.getPValue(sValue)+',';
	var sValueArray = sValue.split(',');
	if(sValueArray.length > 0)
	{
		var j = 0;				
		for(j = 0;j<sValueArray.length;j++)
		{
			if(sValueArray[j] != '')
			{
				var sObj = Sys.getObj(this.id+'_'+sValueArray[j]);
				if(sObj)
				{
					var k = 0;
					for(k = 0;k<sObj.length;k++)
					{
						{
							if(sValue.indexOf(','+sObj.options[k].value+',') > -1)
							{
								sObj.options[k].selected = true;
							}
						}
					}
					k = null;
					TCxty_XTool_Config.onchange(sObj);
				}
				sObj = null;
			}
		}
		j = null;
	}
	sValueArray = null;
}
TCxty_XTool.prototype.setValue_Checkbox = function(sValue)
{
	sValue = ','+sValue;
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var i = 0;
	for(i=0; i<len; i++)
	{
		if((el[i].type == 'checkbox') && (el[i].name == this.id))
		{
			if(sValue.indexOf(','+el[i].value+',') > -1)
			{
				el[i].checked = true;
			}
			else
			{
				el[i].checked = false;
			}
		}
	}
	i = null;
	len = null;
	el = null;
}
TCxty_XTool.prototype.setValue_Radio = function(sValue)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var i = 0;
	for(i=0; i<len; i++)
	{
		if((el[i].type == 'radio') && (el[i].name == this.id))
		{
			if(sValue == el[i].value)
			{
				el[i].checked = true;
			}
			else
			{
				el[i].checked = false;
			}
		}
	}
	i = null;
	len = null;
	el = null;
}

TCxty_XTool.prototype.setValueToTXT = function(sValue)
{
	var tHTML = '';
	switch(this._sType)
	{
		case 'Input': case '1': case 1:case 'Number':case '2': case 2:case 'Date':case '3': case 3:case 'Tel':case '7': case 7:case 'Mobile':case '8': case 8:case 'URL':case '10': case 10:case 'Email':case '11': case 11:case 'IDCard':case '12': case 12:case 'InputBox': case '17': case 17:
			tHTML = sValue;
		break;
		case 'LonLat':case '9': case 9:
			tHTML = this.setValueToTXT_LonLat(sValue);
		break;
		case 'Select': case '13': case 13:
			tHTML = this.setValueToTXT_Select(sValue);
		break;
		case 'Checkbox': case '14': case 14:
			tHTML = this.setValueToTXT_Checkbox(sValue);
		break;
		case 'Radio': case '15': case 15:
			tHTML = this.setValueToTXT_Radio(sValue);
		break;
	}
	document.getElementById(this.id+'_Box').innerHTML = tHTML;
}
TCxty_XTool.prototype.setValueToTXT_LonLat = function(sValue)
{
	var tHTML = '';
	if(sValue.indexOf(',')>-1)
	{
		sValue = sValue.split(',');
	}
	tStr = '<ul id="'+this.id+'">'+
			'<li><nobr>纬度:'+sValue[0]+'</nobr></li>'+
			'<li><nobr>经度:'+sValue[1]+'</nobr></li>'+
			'<li><a href="javascript:void(0);" onclick="javascript:TCxty_XTool_Config.onmap(\''+this.id+'\',false);"><img src="/images/Map.png" border="0"></a></li>'+
			'</ul>';

	return tHTML;
}
TCxty_XTool.prototype.setValueToTXT_Select = function(sValue)
{
	var tHTML='';
	//取所有父编号
	sValue = ',0'+this.getPValue(sValue)+',';
	var sValueArray = sValue.split(',');
	if(sValueArray.length > 0)
	{
		var j = 0;				
		for(j = 0;j<sValueArray.length;j++)
		{
			if(sValueArray[j] != '')
			{
				var sObj = Sys.getObj(this.id+'_'+sValueArray[j]);
				if(sObj)
				{
					var k = 0;
					for(k = 0;k<sObj.length;k++)
					{
						{
							if(sValue.indexOf(','+sObj.options[k].value+',') > -1)
							{
								sObj.options[k].selected = true;
								tHTML += sObj.options[k].text +' ';
							}
						}
					}
					k = null;
					TCxty_XTool_Config.onchange(sObj);
				}
				sObj = null;
			}
		}
		j = null;
	}
	sValueArray = null;
	return tHTML;
}
TCxty_XTool.prototype.setValueToTXT_Checkbox = function(sValue)
{
	var tHTML='';
	sValue = ','+sValue;
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var i = 0;
	for(i=0; i<len; i++)
	{
		if((el[i].type == 'checkbox') && (el[i].name == this.id))
		{
			if(sValue.indexOf(','+el[i].value+',') > -1)
			{
				//el[i].checked = true;
				tHTML += el[i].tTxt+' ';
			}
			else
			{
				//el[i].checked = false;
			}
		}
	}

	i = null;
	len = null;
	el = null;
	return tHTML;
}
TCxty_XTool.prototype.setValueToTXT_Radio = function(sValue)
{
	var tHTML = '';
	sValue = ','+sValue;
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var i = 0;
	for(i=0; i<len; i++)
	{
		if((el[i].type == 'radio') && (el[i].name == this.id))
		{
			if(sValue == el[i].value)
			{
				//el[i].checked = true;
				tHTML += el[i].tTxt+' ';
			}
			else
			{
				//el[i].checked = false;
			}
		}
	}

	i = null;
	len = null;
	el = null;
	return tHTML;
}
TCxty_XTool.prototype.ShowPageBox = function(name,w,h)
{
	this._PageBox = SysComm.WriteBox(name,'<iframe src="about:blank" id="'+name+'_if_PageBox" name="'+name+'_if_PageBox" width="'+w+'px" height="'+h+'px" scrolling="no" frameborder="0"></iframe>');
    this._PageBox.ini();
    this._PageBox.Show();
    this._PageBox.Center();
}
TCxty_XTool.prototype.onmap = function(IsReturn)
{
	var LatLon = this.getValue();
	this.ShowPageBox('gmap_Box',500,450);
	if (IsReturn)//需返回值
	{
		window.setTimeout('Sys.getObj("'+this._PageBox.BoxID+'_if_PageBox").src="GMap.aspx?Lat='+LatLon[0]+'&Lon='+LatLon[1]+'&act=r&r='+Math.random()+'&Obj='+this.id+'";',500);
	}else {
		window.setTimeout('Sys.getObj("'+this._PageBox.BoxID+'_if_PageBox").src="GMap.aspx?Lat='+LatLon[0]+'&Lon='+LatLon[1]+'act=s&r='+Math.random()+'&Obj='+this.id+'";',500);
	}
	LatLon = null;
}
TCxty_XTool.prototype.onmap_line = function(IsReturn)
{
	
}
TCxty_XTool.prototype.onediter = function()
{
	this._EditerObj = $('#'+this.id).xheditor(true,{tools:'ubb',showBlocktag:false,beforeSetSource:ubb2html,beforeGetSource:html2ubb})[0].xheditor;
}
TCxty_XTool.prototype.CloseBox = function()
{
    if(this._PageBox)
    {
        this._PageBox.Hidden();
        this.BoxIsShow = false;
    }
}
TCxty_XTool.prototype.XMLtoArray = function(Nodes)
{//将XML转成数组
	if(Nodes != null)
	{
		if(Nodes.length > 0)
		{
			var i = 0;
			for(i=0;i<Nodes.length;i++)
			{
				if(Nodes[i].nodeName != '#text'){
					if(Nodes[i].nodeName == 'Value_List'){
						this._NodesArray.push(new Array(GetXMLData(Nodes[i],'DataTypeBodyValueID'),
																		 GetXMLData(Nodes[i],'DataTypeBodyID'),
																		 GetXMLData(Nodes[i],'bvPaterID'),
																		 GetXMLData(Nodes[i],'bvCode'),
																		 GetXMLData(Nodes[i],'bvValue'),
																		 GetXMLData(Nodes[i],'bvState'),
																		 GetXMLData(Nodes[i],'bvTaxis')));
						
					}
					if(Nodes[i].childNodes.length>0){
						if(Nodes[i].nodeType==3) continue;
						this.XMLtoArray(Nodes[i].childNodes);
					}
				}
			}
			i = null;
		}
	}
}

function TCxty_XTool_Obj_none(sType,sTxt,sValue_nodes,iAction,eParent)
{
	this.id = TCxty_XTool_Config.getId();
	this._sType = sType;
	this._sTxt = sTxt;
	this._sValue_nodes = sValue_nodes;
	this._iAction = iAction;
	TCxty_XTool_Config.all[this.id] = this;
}
TCxty_XTool_Obj_none.prototype.Add = function(node)
{
	node.parentNode = this;
	TCxty_XTool_Config.insertHTMLBeforeEnd(document.getElementById(this.id + '_Box'),node.toString());
	return node;
}

function TCxty_XTool_Obj(sType,sTxt,sValue_nodes,iAction,eParent)
{
	this.base = TCxty_XTool_Obj_none;
	this.base(sType,sTxt,sValue_nodes,iAction,eParent);
	if (eParent) { eParent.add(this); }
}
TCxty_XTool_Obj.prototype = new TCxty_XTool_Obj_none;


function TCxty_XTool_Select(pID,ObjKey,NodesArray)
{
	this.id = null;
	this._pID = pID;
	this._ObjKey = ObjKey
	this._NodesArray = NodesArray;
	this.MaxLeve = 0;
	this.LastValue = '';
	this.LastUpValue = '';//最后一个之前的一个下拉值
	
}
TCxty_XTool_Select.prototype.toString = function()
{
	return this.toString_Loop(0,0);
}
TCxty_XTool_Select.prototype.toString_Loop = function(upID,leve)
{//构建
	var tStr = '';
	var i;
	var isTrue = false;
	if(this._NodesArray.length > 0)
	{
		for(i=0;i<this._NodesArray.length;i++)
		{
			if(this._NodesArray[i][0] != '')
			{
				if(this._NodesArray[i][2] == upID)
				{
					isTrue = true;
					tStr += '<option value="'+this._NodesArray[i][0]+'">'+this._NodesArray[i][4]+'</option>';
				}
			}
		}
	}
	if(isTrue)
	{
		this.id = this._pID+'_'+upID;
		TCxty_XTool_Config.all[this.id] = this;
		tStr = '<select name="'+this.id+'" id="'+this.id+'" leve="'+leve+'" pID="'+this._pID+'" KeyID="'+this._ObjKey+'" onchange="javascript:return TCxty_XTool_Config.onchange(this);"><option value="-1">请选择</option>'+tStr+'</select>';
		tStr += '<span id="'+this.id+'_Box"></span>';
	}
	else
	{
		tStr = '';
	}
	i = null;
	return tStr;
}
TCxty_XTool_Select.prototype.onchange = function(cObj)
{
	var thisSelectValue = SysComm.ReselectedOption_Value(cObj);
	var thisSelectLeve = cObj.leve;
	this.MaxLeve = Number(thisSelectLeve) + 1;
	this.LastUpValue = thisSelectValue;
	Sys.getObj(cObj.id+'_Box').innerHTML = this.toString_Loop(thisSelectValue,this.MaxLeve);
	thisSelectValue = null;
	thisSelectLeve = null;
	this.getValue();//取值
}

TCxty_XTool_Select.prototype.getValue = function()
{
	//搜索返回父div下的所有对象
	var tObj = Sys.getObj(this._pID+'_Box');
	if(tObj.hasChildNodes())
	{
		this.getValue_loop(tObj.childNodes);//返回-1则还有最后一项未选中
		return this.LastValue;
	}
	else
	{
		return '';
	}
	tObj = null;
}
TCxty_XTool_Select.prototype.getValue_loop = function(tObj_Child)
{
	if(tObj_Child.length > 0)
	{
		var i = 0;
		for(i=0;i<tObj_Child.length;i++)
		{
			/*
			try
			{
				if(tObj_Child[i].parentNode.type == 'select-one')
				{
					this.LastUpValue = SysComm.ReselectedOption_Value(tObj_Child[i].parentNode);
				}
			}catch(e){
			
			}
			*/

			if(tObj_Child[i].type == 'select-one')
			{
				this.LastValue = SysComm.ReselectedOption_Value(tObj_Child[i]);
			}
			if(tObj_Child[i].childNodes.length>0){
				
				if(tObj_Child[i].nodeType==3) continue;
				this.getValue_loop(tObj_Child[i].childNodes);
				
				//if(tObj_Child[i].type == 'select-one')
				{
				//	this.LastUpValue = SysComm.ReselectedOption_Value(tObj_Child[i]);
				}
			}
			
		}
		i = null;
	}
}
function TCxty_XTool_Editer(pID,ObjKey)
{
	this._pID = pID;
	this._ObjKey = ObjKey;
	return $('#'+pID).xheditor(true,{tools:'ubb',showBlocktag:false,beforeSetSource:ubb2html,beforeGetSource:html2ubb})[0].xheditor;
}
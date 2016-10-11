/*系统公用函数*/
function killErrors() {return true;}
//window.onerror = killErrors;//开启脚本容错

function LTrim(str){//LTrim(string):去除左边的空格
	var whitespace = new String(" \t\n\r");
	var s = new String(str);    
	if (whitespace.indexOf(s.charAt(0)) != -1){
		var j=0, i = s.length;
		while (j < i && whitespace.indexOf(s.charAt(j)) != -1){
			j++;
		}
		s = s.substring(j, i);
	}
	return s;
}
function RTrim(str){//RTrim(string):去除右边的空格
	var whitespace = new String(" \t\n\r");
	var s = new String(str);
	if (whitespace.indexOf(s.charAt(s.length-1)) != -1){
		var i = s.length - 1;
		while (i >= 0 && whitespace.indexOf(s.charAt(i)) != -1){
			i--;
		}
		s = s.substring(0, i+1);
	}
	return s;
}
function Trim(str){//Trim(string):去除前后空格
	return RTrim(LTrim(str));
}
function HextoStr(hex)   
{
	str16='0123456789ABCDEF';
	var rs='';
	for(var c=0,rs='';c<4;c++)
	{
		cn=hex%0x10;
		hex=(hex-cn)/0x10;
		rs=str16.charAt(cn)+rs;
	}     
	return rs;
} 

function welcome(){
	var tNow = new Date();
	var iHour = tNow.getHours();
	var sWelcome;
	if(iHour == 23||iHour < 1){sWelcome='午夜';}
	else if(iHour <  6){sWelcome='凌晨';}
	else if(iHour <  8){sWelcome='早晨';}
	else if(iHour < 11){sWelcome='上午';}
	else if(iHour < 13){sWelcome='中午';}
	else if(iHour < 17){sWelcome='下午';}
	else if(iHour < 19){sWelcome='傍晚';}
	else{sWelcome='晚上';}
	sWelcome += '好!';
	document.write(sWelcome);
}
//提取查找字符串前面所有的字符
function getFront(mainStr,searchStr){
    foundOffset=mainStr.indexOf(searchStr);
    if(foundOffset==-1){
       return null;
    }
    return mainStr.substring(0,foundOffset);
}
//提取查找字符串后面的所有字符
function getEnd(mainStr,searchStr){
    foundOffset=mainStr.indexOf(searchStr);
    if(foundOffset==-1){
       return null;
    }
    return mainStr.substring(foundOffset+searchStr.length,mainStr.length);
}
//在字符串 searchStr 前面插入字符串 insertStr 
function insertString(mainStr,searchStr,insertStr){
    var front=getFront(mainStr,searchStr);
    var end=getEnd(mainStr,searchStr);
    if (front != null && end != null) {
		return front + insertStr + searchStr + end;
	}
	else {
		return mainStr;
	}
}
//删除字符串 deleteStr
function deleteString(mainStr,deleteStr){
    return replaceString(mainStr,deleteStr,"");
}
//将字符串 searchStr 修改为 replaceStr
function replaceString(mainStr,searchStr,replaceStr){
    var front=getFront(mainStr,searchStr);
    var end=getEnd(mainStr,searchStr);
    if(front!=null && end!=null){
       return front+replaceStr+end;
    }
    else {
		return mainStr;
	}
}
/**
 * 兼容IE和firefox取XML文档节点的值
 * @param nodeObj // nodeObj like oNodes[i].attributes.getNamedItem('Id')[0]
 */
function getTextByNodeObj(nodeObj){
	if(document.all) {
		return nodeObj.text;
	} else {
		return nodeObj.textContent;
	}
}

/*数据验证函数部分*/
function isArray(a) 
{
	return isObject(a) && a.constructor == Array;
}

function isBoolean(a)
{
	return typeof a == 'boolean';
}

function isEmpty(o) 
{
	var i, v;
	if (isObject(o)) 
	{
		for(i in o) 
		{
			v = o[i];
			if (isUndefined(v) && isFunction(v)) 
			{
				return false;
			}
		}
	}
	return true;
}

function isFunction(a) 
{
	return typeof a == 'function';
}

function isNull(a) 
{
	return typeof a == 'object' && !a;
}

function isNumber(a) 
{
	return typeof a == 'number' && isFinite(a);
}

function isObject(a) 
{
	return (a && typeof a == 'object') || isFunction(a);
}

function isString(a) 
{
	return typeof a == 'string';
}

function isUndefined(a) 
{
	return typeof a == 'undefined';
}
/*数据验证函数到此*/

function GetXMLData(obj,name){//返回XML节点数据
	try{
		var result = '';
		if (typeof(obj) == 'object' && name != null && name != '') {
			var node = null;
			//if(document.all){
				node = obj.getElementsByTagName(name);
				if (node != null && node.length > 0){
					result = node[0].firstChild.data;
				}
			//}else{
			//	node = obj;
			//	if (node != null && node.length > 0){
			//		if(node[0].firstChild)
			//		{
			//			result = node[0].firstChild.data;
			//		}
			//		else
			//		{
			//			result = node[0].nodeValue;
			//		}
			//	}
			//}
			node = null;
		}
		return result;
	}catch(e){
		alert(e.message);
	}
}
function GetQueryString(key){//读取网址后缀
	var returnValue =""; 
	var sURL = window.document.URL;
	if (sURL.indexOf("?") > 0)
	{
		var arrayParams = sURL.split("?");
		var arrayURLParams = arrayParams[1].split("&");
		for (var i = 0; i < arrayURLParams.length; i++)
		{
			var sParam =  arrayURLParams[i].split("=");

			if ((sParam[0] ==key) && (sParam[1] != ""))
				returnValue=sParam[1];
		}
	}
	return returnValue;
}
function copy_clip(meintext){
	if (window.clipboardData){   
		// the IE-manier
		window.clipboardData.setData("Text", meintext);   
		// waarschijnlijk niet de beste manier om Moz/NS te detecteren;
		// het is mij echter onbekend vanaf welke versie dit precies werkt:
   	}else if (window.netscape){    
		// dit is belangrijk maar staat nergens duidelijk vermeld:
		// you have to sign the code to enable this, or see notes below
		try {
			netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");   
		} catch (e) {   
			alert("按Ctrl+C复制链接地址，按Ctrl +V粘贴到聊天窗口发送给好友");
			return;   
		}   
		//netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
		// maak een interface naar het clipboard
		var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
		if (!clip) return;
				
		// maak een transferable
		var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
		if (!trans) return;
		
		// specificeer wat voor soort data we op willen halen; text in dit geval
		trans.addDataFlavor('text/unicode');
		
		// om de data uit de transferable te halen hebben we 2 nieuwe objecten 
		// nodig om het in op te slaan
		var str = new Object();
		var len = new Object();
		
		var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
		
		var copytext=meintext;		
		str.data=copytext;		
		trans.setTransferData("text/unicode",str,copytext.length*2);		
		var clipid=Components.interfaces.nsIClipboard;		
		if (!clip) return false;		
		clip.setData(trans,null,clipid.kGlobalClipboard);		
	} else {
		alert("按Ctrl+C复制链接地址，按Ctrl +V粘贴到聊天窗口发送给好友");
		return;   
	}
	alert("地址复制成功！ 按Ctrl+V 粘贴到聊天窗口发送给好友");
	return false;
}

var _isChecked=false;//必须放在函数外
function checkNumber(obj,type,unsigned){
obj.style.imeMode='disabled';
if(type.toUpperCase()!=new String("integer").toUpperCase())
    type="double";
else
    type="integer";
if(unsigned)
    unsigned=true;
else
    unsigned=false;
if(!_isChecked) {
    _isChecked=true;
    var str=new String(obj.value);
    var num=new Number(obj.value);
    var ok=true;
    if(unsigned)
      ok=str.match("-")==null;
    if(type=="integer"&&ok)
      ok=str.match("\\.")==null;
/* \.是正则表达式中代替小数点的方法，但是因为match函数中要求输入一个字符串参数，所以要用\\来代替\，所以最终用\\.来代替小数点 */
    if(num.toString()=="NaN"&&str!="-")
      ok=false;
    if(obj.value.match("\\-0\\d|\\b^\\.?0\\d"))
      ok=false;//避免输入01,-0000.01之类的数字
    if(!ok)
      obj.value=obj.backupValue==undefined?"":obj.backupValue;
    else{
      matchStr=obj.value.match("\\-?\\b[0-9]*\\.?[0-9]*\\b\\.?|\\-");//用正则表达式清空前后空格
      if(matchStr!=obj.value){
        obj.value=matchStr==null?"":matchStr;
        _isChecked=true;
      }
      obj.backupValue=obj.value;
    }
}
else{
    _isChecked=false;//避免无限递归
    return;
}
}

function strDateTime(str)
{
var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/; 
var r = str.match(reg); 
if(r==null)return false; 
var d= new Date(r[1], r[3]-1,r[4],r[5],r[6],r[7]); 
return (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]&&d.getHours()==r[5]&&d.getMinutes()==r[6]&&d.getSeconds()==r[7]);
}

function getFormatDate(date_obj,date_templet){
  var year,month,day,hour,minutes,seconds,short_year,full_month,full_day,full_day,full_hour,full_minutes,full_seconds;
  if(!date_templet)date_templet = "yyyy-mm-dd hh:ii:ss";
  year = date_obj.getFullYear().toString();
  short_year = year.substring(2,4);
  month = (date_obj.getMonth()+1).toString();
  month.length == 1 ? full_month = "0"+month : full_month = month;
  day = date_obj.getDate().toString();
  day.length == 1 ? full_day = "0"+day : full_day = day;
  hour = date_obj.getHours().toString();
  hour.length == 1 ? full_hour = "0"+hour : full_hour = hour;
  minutes = date_obj.getMinutes().toString();
  minutes.length == 1 ? full_minutes = "0"+minutes : full_minutes = minutes;
  seconds = date_obj.getSeconds().toString();
  seconds.length == 1 ? full_seconds = "0"+seconds : full_seconds = seconds;
  return date_templet.replace("yyyy",year).replace("mm",full_month).replace("dd",full_day).replace("yy",short_year).replace("m",month).replace("d",day).replace("hh",full_hour).replace("ii",full_minutes).replace("ss",full_seconds).replace("h",hour).replace("i",minutes).replace("s",seconds);
}

function deleteparent(obj){
	var p = obj.parentNode.parentNode;
	if(document.all)
	{
		p.removeNode(true);
	}else	{
		var parent = p.parentNode;
		parent.removeChild(p);
	}
	p = null;
}

/*进度条部分*/
function ShowLoadBar()
{
	var w=document.documentElement.clientWidth+document.documentElement.scrollLeft;
	var h=document.documentElement.clientHeight+document.documentElement.scrollTop;
	//var w = 200;
	//var h = 200;
	var tHTML = '<div id="LoadBar_Box" name="LoadBar_Box" style="Z-INDEX: 300;POSITION: absolute;border:#66CC00 solid 1px;background-color:#FFFFFF;width:150px;font-size:12px"><img src="/images/loading.gif" width="16" height="16" />数据加载中,请稍后...</div>';
	try{
		if(Sys.getObj('LoadBar_Box')){
			if(document.all)
			{
				Sys.getObj('LoadBar_Box').style.left = w/2-60;
				Sys.getObj('LoadBar_Box').style.top = h/2-Sys.getObj('LoadBar_Box').style.height/2;
				Sys.getObj('LoadBar_Box').style.visibility = "visible";
			}else{
				Sys.getObj('LoadBar_Box').style.left = (w/2-60)+'px';
				Sys.getObj('LoadBar_Box').style.top = (h/2-Sys.getObj('LoadBar_Box').style.height/2)+'px';
				Sys.getObj('LoadBar_Box').style.visibility = "visible";
			}
			//Show_Page_M_Box();
		}else{
			//document.body.innerHTML += tHTML;
			document.body.insertAdjacentHTML('afterBegin',tHTML);
			tHTML = null;
			ShowLoadBar();
		}
	}catch(e){
		//document.body.innerHTML += tHTML;
		document.body.insertAdjacentHTML('afterBegin',tHTML);
		tHTML = null;
		ShowLoadBar();
	}
}
function HitLoadBar()
{
	try{
		if(Sys.getObj('LoadBar_Box')){
			Sys.getObj('LoadBar_Box').style.visibility = "hidden";
			//Hit_Page_M_Box();
		}
	}catch(e){
	}
}

function Comm(){
	this.ReXML_URL = '';
}
//切换验证码
Comm.prototype.changeimg = function(imgObj){if(imgObj){imgObj.src='Code.aspx?c='+Math.random();}}
Comm.prototype.PostData = function(tXML,ReCallF,Actions)
{//POST数据
	A_XMLHTTP(this.ReXML_URL+'?do='+Actions+'&doValue=&rCode='+ReRanCode(),tXML,'POST',ReCallF);
}
Comm.prototype.GetData = function(tXML,ReCallF,Actions)
{//Get数据
	A_XMLHTTP(this.ReXML_URL+'?do='+Actions+'&doValue='+tXML+'&rCode='+ReRanCode(),tXML,'GET',ReCallF);
}
Comm.prototype.check_checkbox = function(sobj,name)
{
	if(sobj)
	{
		if(sobj.checked)
		{
			this.check_checkboxAll(name);
		}
		else
		{
			this.clear_checkboxAll(name);
		}
	}
}
Comm.prototype.check_checkboxAll = function(name)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	for(var i=0; i<len; i++)
	{
		if((el[i].type=="checkbox") && (el[i].name==name))
		{
			el[i].checked = true;
		}
	}
}
Comm.prototype.clear_checkboxAll = function(name)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	for(var i=0; i<len; i++)
	{
		if((el[i].type=="checkbox") && (el[i].name==name))
		{
			el[i].checked = false;
		}
	}
}
Comm.prototype.Re_checkbox_Value = function(name)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var tRe = '';
	for(var i=0; i<len; i++)
	{
		if((el[i].type=="checkbox") && (el[i].name==name))
		{
			if(el[i].checked)
			{
				tRe += el[i].value+',';
			}
		}
	}
	len = null;
	el = null;
	return tRe;
}
Comm.prototype.Re_radio_Obj = function(name)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var tRe = null;
	for(var i=0; i<len; i++)
	{
		if((el[i].type=="radio") && (el[i].name==name))
		{
			if(el[i].checked)
			{
				tRe = el[i];
			}
		}
	}
	len = null;
	el = null;
	return tRe;
}
Comm.prototype.Re_radio_Value = function(name)
{
	var el = document.getElementsByTagName('input');
	var len = el.length;
	var tRe = null;
	for(var i=0; i<len; i++)
	{
		if((el[i].type=="radio") && (el[i].name==name))
		{
			if(el[i].checked)
			{
				tRe = el[i].value;
			}
		}
	}
	len = null;
	el = null;
	return tRe;
}
Comm.prototype.removeSelectAllChild = function(sObj)
{//移除指定Select对象内所有子项目
	//var i;
	if(sObj)
	{
		sObj.options.length=0;
		
		//for(i=0;i<sObj.options.length;i++){ 
		//	sObj.removeChild(sObj.options[i]);
		//}
		
	}
	//i = null;
}
Comm.prototype.TrimremoveSelectChild = function(sObj)
{//移除指定Select对象内所有子项目
	var i;
	if(sObj)
	{
		for(i=0;i<sObj.options.length;i++){
			if(sObj.options[i].text == '')
			{
				sObj.removeChild(sObj.options[i]);
			}
		}
	}
	i = null;
}
Comm.prototype.removeSelectEdChild = function(sObj)
{//删除选中项
	if(sObj)
	{
		if(sObj.options.length > 0)
		{
			var i;
			for(i=0;i<sObj.options.length;i++){
				if(sObj.options[i].selected == true)
				{
					sObj.removeChild(sObj.options[i]);
				}
			}
			i = null;
		}
	}
}
Comm.prototype.appendSelectChild = function(sObj,aTxt,aValue)
{//添加子选项到指定的Select对象内
	if(sObj)
	{
		sObj.add(new Option(aTxt,aValue));   
	}
}
Comm.prototype.ArrayappendSelectChild = function(sObj,aArray)
{//将数据数据,添加子选项到指定的Select对象内
	if(sObj && aArray.length>0)
	{
		var i = 0;
		for(i=0;i<aArray.length;i++)
		{
			if(aArray[i][0] != '')
			{
				this.appendSelectChild(sObj,aArray[i][0],aArray[i][1]);
			}
		}
		i = null;
	}
}
Comm.prototype.selectedOption = function(sObj,sTxt,sValue)
{//选中Select内指定项目

	if(sObj)
	{
		var i;
		for(i=0;i<sObj.options.length;i++){
			
			if(sTxt != '')
			{
				if(sObj.options[i].text == sTxt)
				{
					sObj.options[i].selected = true;
				}
			}
			if(sValue != '')
			{
				if(sObj.options[i].value == sValue)
				{
					sObj.options[i].selected = true;
				}
			}
		}
		i=null;
	}
}
Comm.prototype.removeChildrenRecursively = function(node) {   
    if (!node) return;   
    while (node.hasChildNodes()) {   
        removeChildrenRecursively(node.firstChild);   
        node.removeChild(node.firstChild);   
    }   
}  
Comm.prototype.ReselectedOption_Txt = function(sObj)
{//返回选中项目的Txt
	if(sObj)
	{
		return sObj.options[sObj.selectedIndex].text;
	}
}
Comm.prototype.ReselectedOption_Value = function(sObj)
{//返回选中项目的Value
	if(sObj)
	{
		return sObj.options[sObj.selectedIndex].value;
	}
}
Comm.prototype.ReselectedAllOption_Value = function(sObj)
{//返回选中项目的所有项目Value
	var reStr = '';
	if(sObj)
	{
		if(sObj.options.length > 0)
		{
			var i=0;
			for(i=0;i<sObj.options.length;i++)
			{
				if(sObj.options[i].value != '')
				{
					if(reStr != ''){reStr += ',';}
					reStr += sObj.options[i].value;
				}
			}
			i = null;
		}
	}
	return reStr;
}
Comm.prototype.CheckselectedOption_Value = function(sObj,cValue)
{//检查是否有重复项
	var reValue = false;
	if(sObj)
	{
		if(sObj.options.length > 0)
		{
			var i=0;
			for(i=0;i<sObj.options.length;i++)
			{
				if(sObj.options[i].value == cValue)
				{
					reValue = true;
					break;
				}
			}
		}
	}
	return reValue;
}
Comm.prototype.ShowPageBox = function(PageURL,w,h,stype)
{
	stype = (stype)?stype:'no';
	var pTemID = 'if_PageBox_'+Math.random();
	var pObj = SysComm.WriteBox('PageBox','<iframe src="about:blank" id="'+pTemID+'" name="'+pTemID+'" width="'+w+'px" height="'+h+'px" scrolling="'+stype+'" frameborder="0"></iframe>')
	pObj.ini();
    pObj.Show();
    pObj.Center();
	window.setTimeout('Sys.getObj("'+pTemID+'").src="'+PageURL+'";',1000);
	return pObj;
}
Comm.prototype.HiddenPageBox = function(hObj)
{
	if (hObj) {
		hObj.Hidden();
	}
}
Comm.prototype.WriteBox = function(BoxID,wHTML)
{
	this.BoxID = BoxID;
	this.wHTML = wHTML;
	this.obj = null;
	this.obj_m = null;
	this.obj_if = null;
	this.timeOutID = null;

	this.ini = function()
	{

		if(Sys.getObj(this.BoxID))
		{
			this.obj = Sys.getObj(this.BoxID);
			this.obj.innerHTML = this.wHTML;
			this.obj_m = Sys.getObj(this.BoxID+'_M');
			this.obj_if = Sys.getObj(this.BoxID+'_if');
		}
		else{
			document.body.insertAdjacentHTML('afterBegin','<div id="'+this.BoxID+'_M" style="Z-INDEX: 199;display:none;position:absolute;Left:0px;Top:0px;background-color: #000000;filter:alpha(opacity=60);/* IE */-moz-opacity:0.4; /* Moz + FF */opacity: 0.4; " onselectstart="return false" ></div><iframe id="'+this.BoxID+'_if" src="javascript:false" style="position:absolute; visibility:inherit; top:0px; left:0px; width:100px; height:200px; z-index:200; filter:alpha(opacity=0);/* IE */-moz-opacity:0; /* Moz + FF */opacity: 0;"></iframe><div id="'+this.BoxID+'" style="Z-INDEX: 201;position:absolute;border:#CCCCCC solid 1px;background-color: #FFFFFF;"></div>');
			this.ini();
		}
	}
	this.Show = function()
	{
		if(this.obj)
		{
			this.obj.style.visibility = '';
			this.obj.style.display = '';
			this.obj_m.style.visibility = '';
			this.obj_m.style.display = '';
			this.obj_if.style.visibility = '';
			this.obj_if.style.display = '';
			if(document.all)
			{
				this.obj_m.style.width = $(document).width();// document.documentElement.clientWidth;
				this.obj_m.style.height =$(document).height();// document.documentElement.clientHeight;
				this.obj_if.style.width = $(document).width();//document.documentElement.clientWidth;
				this.obj_if.style.height =$(document).height();// document.documentElement.clientHeight;
			}else
			{
				this.obj_m.style.width = $(document).width()+'px';
				this.obj_m.style.height = $(document).height()+'px';
				this.obj_if.style.width = $(document).width()+'px';
				this.obj_if.style.height = $(document).height()+'px';
			}
		}
	}
	this.Hidden = function()
	{
		if(this.obj)
		{
			this.obj.style.visibility = 'hidden';
			this.obj.style.display = 'none';
			
			this.obj_m.style.visibility = 'hidden';
			this.obj_m.style.display = 'none';
			this.obj_if.style.visibility = 'hidden';
			this.obj_if.style.display = 'none';
		}
	}
	this.Center = function()
	{//居中显示
		if(this.obj)
		{
			var l=(document.documentElement.clientWidth / 2) - this.obj.offsetWidth/2 + document.documentElement.scrollLeft;
			var t=(document.documentElement.clientHeight / 2) - this.obj.offsetHeight/2 + document.documentElement.scrollTop;
			if(document.all)
			{
				this.obj.style.left = l;
				this.obj.style.top = t;
			}else
			{
				this.obj.style.left = l+'px';
				this.obj.style.top = t+'px';
			}
			l = null;
			t = null;
		}
	}
	this.MCenter = function()
	{//动态居中
		if(this.obj)
		{
			var l=(document.documentElement.clientWidth / 2) - this.obj.offsetWidth/2 + document.documentElement.scrollLeft;
			var t=(document.documentElement.clientHeight / 2) - this.obj.offsetHeight/2 + document.documentElement.scrollTop;
			if(document.all)
			{
				this.obj.style.left = l;
				this.obj.style.top = t;
			}else
			{
				this.obj.style.left = l+'px';
				this.obj.style.top = t+'px';
			}
			l = null;
			t = null;
		}
	}
	this.ShowTop = function(topX)
	{//至顶显示
		if(document.all)
		{
			this.obj.style.top = topX;
		}
		else
		{
			this.obj.style.top = topX+'px';
		}
	}
	this.ShowLeft = function(LeftX)
	{//至顶显示
		if(document.all)
		{
			this.obj.style.left = LeftX;
		}
		else
		{
			this.obj.style.left = LeftX+'px';
		}
	}
	return this;
}
Comm.prototype.ShowHie_Tab = function()
{
	this.Tab = new Array;
	
	this.ini = function()
	{
		
	}
	this.SelectTab = function(sTab)
	{//点击Tab后切换显示
		this.HiAll();
		var i;
		for(i=0;i<this.Tab.length;i++)
		{
			if(this.Tab[i] == sTab)
			{
				this.Tab[i].style.display = '';
			}
		}
		i = null;
	}
	this.HiAll = function()
	{
		var i;
		for(i=0;i<this.Tab.length;i++)
		{
			if(this.Tab[i])
			{
				this.Tab[i].style.display = 'none';
			}
		}
		i = null;
	}
}
Comm.prototype.LoginBar = function()
{
	this.tHTML = '';
}
Comm.prototype.MoveObj = function()  //实现对象的拖移
{
	this.t_X;
	this.t_Y;
	
	this.mDown = function()
	{
		this.t_X=event.x-parentNode.style.pixelLeft;
		this.t_Y=event.y-parentNode.style.pixelTop;
		setCapture();
	}
	this.mMove = function(obj)
	{
		if(event.button==1)
		{
			this.t_X=obj.parentNode.clientLeft;
			this.t_Y=obj.parentNode.clientTop;
			obj.parentNode.style.pixelLeft=obj.parentNode.clientLeft+(event.x-this.t_X);
			obj.parentNode.style.pixelTop=bj.parentNode.clientTop+(event.y-this.t_Y);
		}
	}
	this.mUp = function()
	{
		releaseCapture();
	}
}
Comm.prototype.Obj_Listener = function()
{//监听事件,满足指定要求触法新事件
	this.RunEventListeners = new Array(); 
	this.AddEvent = function(key,value,fun)
	{
	}
	this.Dispose = function()
	{
		this.RunEventListeners = null;
	}
}
Comm.prototype.CutTxt = function(TxtStr,CutNO,cutstr)
{//截断字符

	if(Trim(TxtStr) != '')
	{
		if(Number(CutNO)>TxtStr.length){CutNO = TxtStr.length;cutstr='';}
		TxtStr = TxtStr.substring(0,CutNO)+cutstr;
	}
	return TxtStr;
}
Comm.prototype.FormatNumber = function(srcStr,nAfterDot)
{
	var srcStr,nAfterDot;
    var resultStr,nTen;
    srcStr = ""+srcStr+"";
    strLen = srcStr.length;
    dotPos = srcStr.indexOf(".",0);
    if (dotPos == -1){
        resultStr = srcStr+".";
        for (i=0;i<nAfterDot;i++){
            resultStr = resultStr+"0";
        }
        return resultStr;
    } else{
        if ((strLen - dotPos - 1) >= nAfterDot){
            nAfter = dotPos + nAfterDot + 1;
            nTen =1;
            for(j=0;j<nAfterDot;j++){
            nTen = nTen*10;
        }
        resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
        return resultStr;
        } else{
            resultStr = srcStr;
            for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
                resultStr = resultStr+"0";
            }
            return resultStr;
        }
    }
}

Sys = function(){;}
Sys.NS = (document.layers) ? true : false;
Sys.IE = (document.all) ? true : false;
Sys.DOM = (document.getElementById) ? true : false;
if (Sys.IE) Sys.DOM = false;
Sys.MAC = (navigator.platform) && (navigator.platform.toUpperCase().indexOf('MAC') >= 0);
if (Sys.NS) Sys.MAC = false;
Sys.getObj = function(objId){if (document.getElementById)return document.getElementById(objId);else if (document.all)return document.all(objId);};
Sys.urlEncode = function(str)
{
	var i,c,ret="",strSpecial="!\"#$%&'()*+,/:;<=>?@[\]^`{|}~%"
	for(i=0;i<str.length;i++)
	{
		c=str.charAt(i);
		if(c==" ")
		ret+="+";
		else if(strSpecial.indexOf(c)!=-1)
			ret+="%"+str.charCodeAt(i).toString(16);
		else
		ret+=c;
	}
	i=null;
	c=null;
	strSpecial=null;
	return ret;
}; 
Sys.urlDecode = function(str)
{
	if("undefined" == typeof decodeURIComponent)
	{
		return unescape(str).replace(/\+/g, ' ').replace(/%2B/g,'+');
  	} else {
  		return unescape(str).replace(/\+/g, ' ').replace(/%2B/g,'+');
  }
};
Sys.urlToParams = function(urlContent)
{
	cmdMap = new Array();
	cmdParams = new Array();
    pos = -1;
    while (true)
	{
        newPos = urlContent.indexOf('&', pos+1);
        if (newPos>=0) {
            encodedProperty = urlContent.substring(pos+1, newPos);
        }
        else {
            encodedProperty = urlContent.substring(pos+1, urlContent.length);
        }
        equalsPos = encodedProperty.indexOf('=');
        paramName = encodedProperty.substring(0, equalsPos);
        paramValue =(encodedProperty.substring(equalsPos+1, encodedProperty.length));

        cmdParams[paramName] = paramValue;

        if (newPos==-1) {
            break;
        }
        pos = newPos;
    }
	return cmdParams;
};
Sys.addEvent = function(objectId, eventName, eventFunction)
{
	if(document.attachEvent)
		objectId.attachEvent("on"+eventName, eventFunction);
	else
		objectId.addEventListener(eventName, eventFunction, false);
}

SysComm = new Comm();



Date.prototype.format = function(format) {   
 var o = {
  "M+" : this.getMonth()+1,  //month
  "d+" : this.getDate(),   //day
  "h+" : this.getHours(),   //hour
  "m+" : this.getMinutes(),  //minute
  "s+" : this.getSeconds(),  //second
  "q+" : Math.floor((this.getMonth()+3)/3),  //quarter
  "S" : this.getMilliseconds() //millisecond
 }
 if(/(y+)/.test(format)) format = format.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));
 for(var k in o)
  if(new RegExp("("+ k +")").test(format))
 format = format.replace(RegExp.$1, RegExp.$1.length==1 ? o[k] : ("00"+ o[k]).substr((""+ o[k]).length));
 return format;
}

//渐变显示对象
function fadeIn(element, opacity) {
	var reduceOpacityBy = 5;
	var rate = 30;	// 15 fps
	if (opacity < 100) {
		opacity += reduceOpacityBy;
		if (opacity > 100) {
			opacity = 100;
		}

		if (element.filters) {
			try {
				element.filters.item("DXImageTransform.Microsoft.Alpha").opacity = opacity;
			} catch (e) {
				// If it is not set initially, the browser will throw an error.  This will set it if it is not set yet.
				element.style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=' + opacity + ')';
			}
		} else {
			element.style.opacity = opacity / 100;
		}
	}

	if (opacity < 100) {
		setTimeout(function () {
			fadeIn(element, opacity);
		}, rate);
	}
}


if(typeof HTMLElement!="undefined" && !HTMLElement.prototype.insertAdjacentElement)
{
     HTMLElement.prototype.insertAdjacentElement = function(where,parsedNode)
     {
        switch (where)
        {
            case 'beforeBegin':
                this.parentNode.insertBefore(parsedNode,this)
                break;
            case 'afterBegin':
                this.insertBefore(parsedNode,this.firstChild);
                break;
            case 'beforeEnd':
                this.appendChild(parsedNode);
                break;
            case 'afterEnd':
                if (this.nextSibling) this.parentNode.insertBefore(parsedNode,this.nextSibling);
                    else this.parentNode.appendChild(parsedNode);
                break;
         }
     }

     HTMLElement.prototype.insertAdjacentHTML = function (where,htmlStr)
     {
         var r = this.ownerDocument.createRange();
         r.setStartBefore(this);
         var parsedHTML = r.createContextualFragment(htmlStr);
         this.insertAdjacentElement(where,parsedHTML)
     }

     HTMLElement.prototype.insertAdjacentText = function (where,txtStr)
     {
         var parsedText = document.createTextNode(txtStr)
         this.insertAdjacentElement(where,parsedText)
     }
}
function selectCheck(sform,sObj)
{
	if (sform && sObj) {
		for (var i = 0; i < sform.elements.length; i++) {
			if (sform.elements[i].name == sObj.name) {
				e = sform.elements[i];
				if (sObj.checked) {
					e.checked = true;
				}
				else {
					e.checked = false;
				}
			}
		}
	}
}


//分别是奇数行默认颜色,偶数行颜色,鼠标放上时奇偶行颜色
var aBgColor = ["#E3E3E3","#EFEFEF","#FFFFCC","#FFFFCC"];
//从前面iHead行开始变色，直到倒数iEnd行结束
function addTableListener(o,iHead,iEnd)
{

	jQuery(document).ready(function(){
	  jQuery(".tBox tr:odd").addClass("trColor1");
	  jQuery(".tBox tr:even").addClass("trColor2");
	  jQuery(".tBox tr").hover(function(){
		jQuery(this).addClass("trColor3")
	  },function(){
		jQuery(this).removeClass("trColor3")
	  });
	});

/*
	if(o)
	{
		o.style.cursor = "normal";
		//iEnd = iEnd == 0 ? o.rows.length:iEnd;
		iHead = iHead > o.rows.length?0:iHead;
		iEnd = iEnd > o.rows.length?0:iEnd;
		for (var i=iHead;i<o.rows.length-iEnd ;i++ )
		{
			o.rows[i].onmouseover = function(){setTrBgColor(this,true)}
			o.rows[i].onmouseout = function(){setTrBgColor(this,false)}
		}

		var trs = o.getElementsByTagName("tr"); 
		for(var j=0; j<trs.length; j++) 
		{ 
			if (trs[j].parentNode.parentNode == o) {
				if (j % 2 != 0) {
					trs[j].style.backgroundColor = aBgColor[1];
				}
				else {
					trs[j].style.backgroundColor = aBgColor[0];
				}
			}
		}
		trs = null;
	}
*/
}
function setTrBgColor(oTr,b)
{
	oTr.rowIndex % 2 != 0 ? oTr.style.backgroundColor = b ? aBgColor[3] : aBgColor[1] : oTr.style.backgroundColor = b ? aBgColor[2] : aBgColor[0];
}

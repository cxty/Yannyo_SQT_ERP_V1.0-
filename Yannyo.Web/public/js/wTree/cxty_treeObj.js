/**
 * @author Cxty@msn.com
 */

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
function cxty_treeObjgetETarget(e)
{
	if (!e){return null;}
	if (!e.srcElement && !e.target){return null;}
	obj = e.srcElement ? e.srcElement : e.target;
	if (obj == null){return null};
	
	while (obj.getAttribute("treetype") == null && obj.tagName != "BODY" && obj.tagName != "HTML"){
		obj = obj.parentNode;
		if(obj == null){break;}
	}
	return obj;
}

function cxty_treeObjreplacestr(str)
{
	//try
	{
		if (str) {
			str = deleteString(str,'_treenode1');
			str = deleteString(str,'_treenode0');
			str = deleteString(str,'_treenode');
		}
		return str;
	}
	//catch(x)
	{
		//alert(x);
	}
}
var cxty_treeObjHandler = {
	all       : {},
	onmousedown:function(oItem,e){
		if (e) {
			if (oItem.id) {
				var t = this.all[cxty_treeObjreplacestr(oItem.id)];
				if (t) {
					if (t.onmousedown) {
						return t.onmousedown(e);
					}
					else {
						return false;
					}
				}
				else {
					return false;
				}
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	},
	onmouseup	:function(oItem,e){
		if (e) {
			if (oItem.id) {
				var t = this.all[cxty_treeObjreplacestr(oItem.id)];
				if (t) {
					if (t.document_onmouseup) {
						return t.document_onmouseup(e);
					}
					else {
						return false;
					}
				}
				else {
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		else {
			return false;
		}
	},
	onmouseover	:function(oItem,e){
		if (e) {
			if (oItem.id) {
				var t = this.all[cxty_treeObjreplacestr(oItem.id)];
				if (t) {
					if(t.onmouseover)
					{
						return t.onmouseover(e);
					}
					else
					{
						return false;
					}
				}else
				{
					return  false;
				}
			}
			else
			{
				return  false;
			}
		}
		else {
			return false;
		}
	},
	onmousemove	:function(oItem,e){
		if (cxty_treeObjdragObj) {
			var t = this.all[cxty_treeObjreplacestr(cxty_treeObjdragObj.id)];
			if (t) {
				if(t.document_onmousemove)
				{
					return t.document_onmousemove(e);
				}
				else
				{
					return false;
				}
			}else
			{
				return  false;
			}
		}
		else
		{
			return  false;
		}
	},
	onmouseout	:function(oItem,e){
		if (e) {
			if (oItem.id) {
				var t = this.all[cxty_treeObjreplacestr(oItem.id)];
				if (t) {
					if(t.onmouseout)
					{
						return t.onmouseout(e);
					}else
					{
						return  false;
					}				
				}else
				{
					return  false;
				}
			}
			else
			{
				return  false;
			}
		}
		else {
			return false;
		}
	},
	onselectstart: function(oItem, e){
		if (e) {
			if (oItem.id) {
				var t = this.all[cxty_treeObjreplacestr(oItem.id)];
				if (t) {
					if (t.document_onselectstart) {
						return t.document_onselectstart(e);
					}
					else {
						return false;
					}
				}
				else {
					return false;
				}
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
};
//var treeID = null;
var cxty_treeObjdrag = false;
var cxty_treeObjdragObj = null;

function Tcxty_treeObj(sText, sAction, bState, eParent, sIcon, sOpenIcon, sValue, iAction, iState, iEAction, iDAction, TopShowState, iTopShowState, MoveFunction,pObj,iExpandAction)
{
	this.base = WebFXTreeItem;
	this.base(sText, sAction, eParent, sIcon, sOpenIcon);
	
	this._sText = sText;
	this._state = bState;
	this._value = sValue;
	this._iAction = iAction;
	this._iState = iState;
	this._iEAction = iEAction;
	this._iDAction = iDAction;
	this._TopShowState = TopShowState;
	this._iTopShowState = iTopShowState;
	this._MoveFunction = MoveFunction;
	this._PaterObj = pObj;//父对象
	this._ExpandAction = iExpandAction;//展开时
	
	this.oldClass = '';

	cxty_treeObjHandler.all[this.id] = this;
	//treeID = this;
}
Tcxty_treeObj.prototype = new WebFXTreeItem;

Tcxty_treeObj.prototype.toString = function (nItem, nItemCount) {
	var foo = this.parentNode;
	var indent = '';
	if (nItem + 1 == nItemCount) { this.parentNode._last = true; }
	var i = 0;
	while (foo.parentNode) {
		foo = foo.parentNode;
		indent = "<img id=\"" + this.id + "-indent-" + i + "\" src=\"" + ((foo._last)?webFXTreeConfig.blankIcon:webFXTreeConfig.iIcon) + "\">" + indent;
		i++;
	}
	this._level = i;
	if (this.childNodes.length) { this.folder = 1; }
	else { this.open = false; }
	if ((this.folder) || (webFXTreeHandler.behavior != 'classic')) {
		if (!this.icon) { this.icon = webFXTreeConfig.folderIcon; }
		if (!this.openIcon) { this.openIcon = webFXTreeConfig.openFolderIcon; }
	}
	else if (!this.icon) { this.icon = webFXTreeConfig.fileIcon; }
	var label = this.text.replace(/</g, '&lt;').replace(/>/g, '&gt;');
	var str = "";
	str += "<div id=\"" + this.id + "_control\" class=\"contral\" >";
	str += "<div id = \"" + this.id + "_treenode_move\" class=\"treenode_move\"></div>";
	str += "<div id = \"" + this.id + "_line\" ></div>";
	str += "<div class=\"treenode0\" style=\"display:none;\" id = \"" + this.id + "_treenode0\" onmousedown=\"cxty_treeObjHandler.onmousedown(this,event);\" onmouseup=\"cxty_treeObjHandler.onmouseup(this,event);\" onmouseover=\"cxty_treeObjHandler.onmouseover(this,event);\" onmouseout=\"cxty_treeObjHandler.onmouseout(this,event);\"></div>";
	str += "<div class=\"treenode_1\" treetype=\"0\" index=\"0\" style=\"display:none;\" id = \"" + this.id + "_treenode\" onmousedown=\"cxty_treeObjHandler.onmousedown(this,event);\" onmouseup=\"cxty_treeObjHandler.onmouseup(this,event);\" onmouseover=\"cxty_treeObjHandler.onmouseover(this,event);\" onmouseout=\"cxty_treeObjHandler.onmouseout(this,event);\"></div>";
	str += "<div class=\"treenode1_noselected\" treetype=\"0\" index=\"0\" c_ID=\""+this._value+"\" c_Name=\""+this._sText+"\" id = \"" + this.id + "_treenode1\" onmousedown=\"cxty_treeObjHandler.onmousedown(this,event);\" onmouseup=\"cxty_treeObjHandler.onmouseup(this,event);\" onmouseover=\"cxty_treeObjHandler.onmouseover(this,event);\" onmouseout=\"cxty_treeObjHandler.onmouseout(this,event);\"></div>";

	str += "<div id=\"" + this.id + "\" treetype=\"1\" index=\"0\" c_ID=\""+this._value+"\" c_Name=\""+this._sText+"\" ondblclick=\"webFXTreeHandler.toggle(this);\" onclick=\"webFXTreeHandler.select(this);webFXTreeHandler.toggle(this);"+this._iAction+";\" class=\"webfx-tree-item\" onkeydown=\"return webFXTreeHandler.keydown(this, event);webFXTreeHandler.select(this);"+this._iAction+";\" onmousedown=\"cxty_treeObjHandler.onmousedown(this,event);\" onmouseup=\"cxty_treeObjHandler.onmouseup(this,event);\" onmouseover=\"cxty_treeObjHandler.onmouseover(this,event);\" onmouseout=\"cxty_treeObjHandler.onmouseout(this,event);\">";

	str += indent;
	str += "<img id=\"" + this.id + "-plus\" src=\"" + ((this.folder)?((this.open)?((this.parentNode._last)?webFXTreeConfig.lMinusIcon:webFXTreeConfig.tMinusIcon):((this.parentNode._last)?webFXTreeConfig.lPlusIcon:webFXTreeConfig.tPlusIcon)):((this.parentNode._last)?webFXTreeConfig.lIcon:webFXTreeConfig.tIcon)) + "\" onclick=\"webFXTreeHandler.toggle(this);"+this._ExpandAction+"\">";
	str += "<img id=\"" + this.id + "-icon\" class=\"webfx-tree-icon\" src=\"" + ((webFXTreeHandler.behavior == 'classic' && this.open)?this.openIcon:this.icon) + "\" onclick=\"webFXTreeHandler.select(this);\"><a href=\"" + this.action + "\" id=\"" + this.id + "-anchor\" onfocus=\"webFXTreeHandler.focus(this);"+this._iAction+";\" onblur=\"webFXTreeHandler.blur(this);\">("+this._value+")" + label + "</a>";
	
	if(this._iState != null)
	{
		//状态
		str += "<img id=\"" + this.id + "-Stateicon\" c_ID=\""+this._value+"\" title=\""+((this._state) ? '点击禁用该分类':'点击启用该分类')+"\" c_State=\""+((this._state) ? 'T':'F')+"\" style=\"cursor:hand\" src=\"" + ((webFXTreeHandler.behavior == 'classic' && this._state)?webFXTreeConfig.unlockIcon:webFXTreeConfig.lockIcon) + "\" onclick=\""+this._iState+";\">";
	}
	if(this._TopShowState != null)
	{
		//状态2
		str += "<img id=\"" + this.id + "-TopShowStateicon\" c_ID=\""+this._value+"\" title=\""+((this._TopShowState) ? '点击前台页面将禁用该分类':'点击前台页面将启用该分类')+"\" c_State=\""+((this._TopShowState) ? 'T':'F')+"\" style=\"cursor:hand\" src=\"" + ((webFXTreeHandler.behavior == 'classic' && this._TopShowState)?webFXTreeConfig.starIcon:webFXTreeConfig.NstarIcon) + "\" onclick=\""+this._iTopShowState+";\">";
	}
	//添加
	//str += "<img id=\"" + this.id + "-Addicon\" title=\"添加子分类\" style=\"cursor:hand\" src=\""+webFXTreeConfig.AddIcon+"\" onclick=\""+this._iEAction+";\">";
	//删除
	//str += "<img id=\"" + this.id + "-Delicon\" title=\"删除该分类\" style=\"cursor:hand\" src=\""+webFXTreeConfig.DelIcon+"\" onclick=\""+this._iDAction+";\">";
	str += "</div>";
	
	str += "<div id=\"" + this.id + "-cont\" class=\"webfx-tree-container\" style=\"display: " + ((this.open)?'block':'none') + ";\">";
	for (var i = 0; i < this.childNodes.length; i++) {
		str += this.childNodes[i].toString(i,this.childNodes.length);
	}
	str += "</div></div>";
	
	this.plusIcon = ((this.parentNode._last)?webFXTreeConfig.lPlusIcon:webFXTreeConfig.tPlusIcon);
	this.minusIcon = ((this.parentNode._last)?webFXTreeConfig.lMinusIcon:webFXTreeConfig.tMinusIcon);
	return str;
}
Tcxty_treeObj.prototype.getChecked = function () {

};
Tcxty_treeObj.prototype.setChecked = function (bChecked) {

};
Tcxty_treeObj.prototype.setAt = function()
{

};
Tcxty_treeObj.prototype.getCheckedValue = function () {
	var divEl = document.getElementById(this.id);
	//return this._value;
	return divEl.c_ID;
};

Tcxty_treeObj.prototype.getPos=function(el,sProp)
{
	var iPos = 0;
	while (el!=null) {
		iPos+=el["offset" + sProp];
		el = el.offsetParent;
	}
	return iPos;
}
		
//鼠标按下
Tcxty_treeObj.prototype.onmousedown = function(e){
	if (this._MoveFunction != null) {
		if (!e) {
			return false;
		}
		if (cxty_treeObjdragObj) {
			cxty_treeObjdragObj.className = "noselected";
		}
		
		cxty_treeObjdragObj = cxty_treeObjgetETarget(e);
		
		
		if (!cxty_treeObjdragObj) {
			return;
		}
		
		if (!cxty_treeObjdragObj.getAttribute("treetype")) {
			return;
		}
		
		var mX = e.x ? e.x : e.pageX;
		var mY = e.y ? e.y : e.pageY;
		
		cxty_treeObjdrag = true;
		cxty_treeObjdragObj.className = "treenode_selected";
		this.oldClass = "treenode_selected";
		
		var textContent = cxty_treeObjdragObj.textContent ? cxty_treeObjdragObj.textContent : this.findObj(cxty_treeObjdragObj.id + '_control').innerHTML;
		
		this.ShowMove(mX, mY, textContent);
		
		//thisonselectstartobj = cxty_treeObjHandler.all[this.id];
		
		document.onmousedown = function(){
			return false
		};
		document.onmousemove = function(e){
			cxty_treeObjHandler.onmousemove(cxty_treeObjOnSelectstart(e),e);
			//thisonselectstartobj.document_onmousemove(e);
		};
		alignElWithMouse(mX, mY);
	}
};
		
//Tcxty_treeObj.prototype.onmouseup = function(e){thisonselectstartobj.document_onmouseup(e);};
Tcxty_treeObj.prototype.onmouseover = function(e){
	if (e) {
		if (this._MoveFunction != null) {
			if (cxty_treeObjdrag) {
				//if (cxty_treeObjdragObj != cxty_treeObjgetETarget(e)) 
				{
					this.oldClass = cxty_treeObjgetETarget(e).className;
					if (cxty_treeObjgetETarget(e).getAttribute("treeType") == 1) {
						cxty_treeObjgetETarget(e).className = "treenode_over";
					}
					else {
						cxty_treeObjgetETarget(e).className = "treenode0_over";
					}
				}
				//else
				{
					
				}
			}
			var mX = e.x ? e.x : e.pageX;
			var mY = e.y ? e.y : e.pageY;
			alignElWithMouse(mX, mY);
		}
	}else
	{
		return false;
	}
};
Tcxty_treeObj.prototype.onmouseout = function(e){
	if(this._MoveFunction != null){
		if (cxty_treeObjdrag){
			cxty_treeObjgetETarget(e).className = this.oldClass;
			if (cxty_treeObjdragObj.id == cxty_treeObjgetETarget(e).id){
				this.findObj(this.id + "_treenode_move").style.display="block";
			}
		}
	}
};
Tcxty_treeObj.prototype.findObj = function(objname){
	if (document.getElementById(objname)){
		return document.getElementById(objname);
	}
	else if(document.getElementsByName(objname)){
		return document.getElementsByName(objname);
	}
	else{
		return null;
	}
};

Tcxty_treeObj.prototype.HideMove = function(){
	if (this.findObj(this.id + "_treenode_move").style.display!="none"){
		this.findObj(this.id + "_treenode_move").style.display="none";
	}
};

Tcxty_treeObj.prototype.ShowMove = function(mX ,mY,innerHTML){
	this.findObj(this.id + "_treenode_move").innerHTML = innerHTML;
	this.findObj(this.id + "_treenode_move").style.left =(mX + 10) + "px";
	this.findObj(this.id + "_treenode_move").style.top = (mY) + "px";
};

Tcxty_treeObj.prototype.SetMove = function(e,mX,mY){
	this.findObj(this.id + "_treenode_move").style.left =(mX + 10) + "px";
	this.findObj(this.id + "_treenode_move").style.top = (mY) + "px";			
};
//document事件
Tcxty_treeObj.prototype.document_onmouseup = function(e)
{
	if(this._MoveFunction != null)
	{
		if (cxty_treeObjdrag){
			cxty_treeObjdrag = false;
			try{
				cxty_treeObjgetETarget(e).className = this.oldClass;
				if(this._MoveFunction != null)
				{
					eval(this._MoveFunction+ "(cxty_treeObjdragObj,cxty_treeObjgetETarget(e))");
				}
			}
			catch(e){
				
			}
			
			this.HideMove();
			//thisonselectstartobj = null;
			document.onmousedown = function(){return true};
			document.onmousemove = function(){null;};
		}
	}

}
//document.onmouseup = new Function("thisonselectstartobj.document_onmouseup();");
	
Tcxty_treeObj.prototype.document_onmousemove = function(e)
{
	if(this._MoveFunction != null)
	{
		e= e ? e : window.event;
		var mX = e.x ? e.x : e.pageX;
		var mY = e.y ? e.y : e.pageY;
		this.SetMove(e,mX,mY);	
	}
}
		
Tcxty_treeObj.prototype.document_onselectstart = function(e){
	if(this._MoveFunction != null)
	{
		return !cxty_treeObjdrag;
	}
}
//document.onselectstart = new Function("return thisonselectstartobj.document_onselectstart();");


if (navigator.appName == 'Netscape')
{
	document.addEventListener(Event.MOUSEMOVE,netscapeMouseMove,true);//captureEvents
	document.onmousemove = netscapeMouseMove;
} 
function netscapeMouseMove(e) {
	if(e.screenY>(document.body.offsetHeight-10))
	{
		window.scrollTo(e.screenX, e.screenY+1000);
	}
	if(e.screenY<10)
	{
		window.scrollTo(e.screenX, e.screenY-1000);
	}
}

function microSoftMouseMove()
{
	if(window.event.y>(document.body.offsetHeight-10))
	{
		window.scrollTo(window.event.x, window.event.y+1000);
	}
	if(window.event.y<10)
	{
		window.scrollTo(window.event.x, window.event.y-1000);
	}
}
var countdown=1;
var countup=1;
function alignElWithMouse(x,y)
{
	/*
 if(navigator.appName.indexOf("Explorer") > -1)
 {
    var pos=50;
   
	if(y>(document.body.offsetHeight-pos))
	{
		window.scrollTo(x, 30*countdown);
		countdown++;
		countup=1;
	}

	if(y<pos)
	{
	    countdown=1;
		window.scrollTo(x, document.body.clientHeight-(countup*30));
		countup++;
	}
 }
 else
 {
    var pos=100;
    document.getElementById('x').textContent="pos:"+pos+" "+window.innerHeight;
    document.getElementById('y').textContent="y"+y;
   
    if(y>(window.innerHeight-100))
	{
	    window.scrollTo(x, 30*countdown+window.innerHeight-450);
		// alert('y:'+y+ '\r\n'+document.body.offsetHeight);
		countdown++;
		countup=1;
       // window.scrollTo(x, y+window.innerHeight);
	}
	
    if(((document.body.offsetHeight-y)>=(window.innerHeight-5))&&(y>window.innerHeight))
	{
		//window.scrollTo(x, y-window.innerHeight);
		countdown=1;
		countup++;
		window.scrollTo(x, document.body.clientHeight-(countup*30)-window.innerHeight+400);
		
	}
 }*/
}

function cxty_treeObjOnMouseup(e)
{
	cxty_treeObjHandler.onmouseup(cxty_treeObjgetETarget(e),e);
}
function cxty_treeObjOnSelectstart(e)
{
	if (e) {
		cxty_treeObjHandler.onselectstart(cxty_treeObjOnSelectstart(e),e);
	}else
	{
		return false;
	}
}
document.onmouseup = cxty_treeObjOnMouseup;	
document.onselectstart = cxty_treeObjOnSelectstart;
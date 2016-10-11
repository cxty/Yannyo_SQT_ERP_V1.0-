/**
 * @author Cxty
 */
var isIE = (document.all) ? true : false;
var isIE6 = isIE && (navigator.userAgent.indexOf('MSIE 6.0') != -1);
var isIE7 = isIE && (navigator.userAgent.indexOf('MSIE 7.0') != -1);
var isIE6or7 = isIE6 || isIE7;
var isChrome = navigator.userAgent.indexOf('Chrome') != -1;
var $$ = function (id) {
	return "string" == typeof id ? document.getElementById(id) : id;
};
var Extend = function(destination, source) {
	for (var property in source) {
		destination[property] = source[property];
	}
	return destination;
}
var CurrentStyle = function(element){
	return element.currentStyle || document.defaultView.getComputedStyle(element, null);
}
var forEach = function(array, callback, thisObject){
	if (array) {
		if (array.forEach) {
			array.forEach(callback, thisObject);
		}
		else {
			for (var i = 0, len = array.length; i < len; i++) {
				callback.call(thisObject, array[i], i, array);
			}
		}
	}
}
var Filter = function(array, callback, thisObject){
	if(array.filter){
		return array.filter(callback, thisObject);
	}else{
		var res = [];
		for (var i = 0, len = array.length; i < len; i++) { callback.call(thisObject, array[i], i, array) && res.push(array[i]); }
		return res;
	}
}
var Bind = function(object, fun) {
	var args = Array.prototype.slice.call(arguments).slice(2);
	return function() {
		return fun.apply(object, args.concat(Array.prototype.slice.call(arguments)));
	}
}
function addEventHandler(oTarget, sEventType, fnHandler) {
	if (oTarget.addEventListener) {
		oTarget.addEventListener(sEventType, fnHandler, false);
	} else if (oTarget.attachEvent) {
		oTarget.attachEvent("on" + sEventType, fnHandler);
	} else {
		oTarget["on" + sEventType] = fnHandler;
	}
};
var TableFixed = function(table, options){
	this._oTable = $$(table);//原table
	this._nTable = this._oTable.cloneNode(false);//新table
	this._nTable.id = "";//避免id冲突
	
	this._oTableLeft = this._oTableTop = this._oTableBottom = 0;//记录原table坐标参数
	this._oRowTop = this._oRowBottom = 0;//记录原tr坐标参数
	this._viewHeight = this._oTableHeight = this._nTableHeight = 0;//记录高度
	this._nTableViewTop = 0;//记录新table视框top
	this._selects = [];//select集合，用于ie6覆盖select
	this._style = this._nTable.style;//用于简化代码
	//chrome的scroll用document.body
	this._doc = isChrome ? document.body : document.documentElement;
	//chrome透明用rgba(0, 0, 0, 0)
	this._transparent = isChrome ? "rgba(0, 0, 0, 0)" : "transparent";
	
	this.SetOptions(options);
	
	this._index = this.options.Index;
	this._pos = this.options.Pos;
	
	this.Auto = !!this.options.Auto;
	this.Hide = !!this.options.Hide;
	
	addEventHandler(window, "resize", Bind(this, this.SetPos));
	addEventHandler(window, "scroll", Bind(this, this.Run));
	
	this._oTable.parentNode.insertBefore(this._nTable, this._oTable);
	this.Clone();
};
TableFixed.prototype = {
  //设置默认属性
  SetOptions: function(options) {
	this.options = {//默认值
		Index:	0,//tr索引
		Auto:	true,//是否自动定位
		Pos:	0,//自定义定位位置百分比(0到1)
		Hide:	false//是否隐藏（不显示）
	};
	Extend(this.options, options || {});
  },
  //克隆表格
  Clone: function(index) {
	//设置table样式
	this._style.width = this._oTable.offsetWidth + "px";
	this._style.position = isIE6 ? "absolute" : "fixed";
	//this._style.zIndex = 100;
	//设置index
	this._index = Math.max(0, Math.min(this._oTable.rows.length - 1, isNaN(index) ? this._index : index));
	//克隆新行
	this._oRow = this._oTable.rows[this._index];
	var oT = this._oRow, nT = oT.cloneNode(false);
	if(oT.parentNode != this._oTable){
		nT = oT.parentNode.cloneNode(true).appendChild(nT).parentNode;
	}
	//插入新行
	if(this._nTable.firstChild){
		this._nTable.replaceChild(nT, this._nTable.firstChild);
	}else{
		this._nTable.appendChild(nT);
	}
	//去掉table上面和下面的边框
	if(this._oTable.border > 0){
		switch (this._oTable.frame) {
			case "above" :
			case "below" :
			case "hsides" :
				this._nTable.frame = "void"; break;
			case "" :
			case "border" :
			case "box" :
				this._nTable.frame = "vsides"; break;
		}
	}
	this._style.borderTopWidth = this._style.borderBottomWidth = 0;
	//设置td样式
	var nTds = this._nTable.rows[0].cells;
	forEach(this._oRow.cells, Bind(this, function(o, i){
		var css = CurrentStyle(o), style = nTds[i].style;
		//设置td背景
		style.backgroundColor = this.GetBgColor(o, css.backgroundColor);
		//设置td的width,没考虑ie8/chrome设scroll的情况
		style.width = (document.defaultView ? parseFloat(css.width)
			: (o.clientWidth - parseInt(css.paddingLeft) - parseInt(css.paddingRight))) + "px";
	}));
	//获取table高度
	this._oTableHeight = this._oTable.offsetHeight;
	this._nTableHeight = this._nTable.offsetHeight;
	
	this.SetRect();
	this.SetPos();
  },
  //获取背景色
  GetBgColor: function(node, bgc) {
	//不要透明背景（没考虑图片背景）
	while (bgc == this._transparent && (node = node.parentNode) != document) {
		bgc = CurrentStyle(node).backgroundColor;
	}
	return bgc == this._transparent ? "#fff" : bgc;
  },
  //设置坐标属性
  SetRect: function() {
	if(this._oTable.getBoundingClientRect){
		//用getBoundingClientRect获取原table位置
		var top = this._doc.scrollTop, rect = this._oTable.getBoundingClientRect();
		this._oTableLeft = rect.left + this._doc.scrollLeft;
		this._oTableTop = rect.top + top;
		this._oTableBottom = rect.bottom + top;
		//获取原tr位置
		rect = this._oRow.getBoundingClientRect();
		this._oRowTop = rect.top + top;
		this._oRowBottom = rect.bottom + top;
	}else{//chrome不支持getBoundingClientRect
		//获取原table位置
		var o = this._oTable, iLeft = o.offsetLeft, iTop = o.offsetTop;
		while (o.offsetParent) { o = o.offsetParent; iLeft += o.offsetLeft; iTop += o.offsetTop; }
		this._oTableLeft = iLeft;
		this._oTableTop = iTop;
		this._oTableBottom = iTop + this._oTableHeight;
		//获取原tr位置
		o = this._oRow; iTop = o.offsetTop;
		while (o.offsetParent) { o = o.offsetParent; iTop += o.offsetTop; }
		this._oRowTop = iTop;
		this._oRowBottom = iTop + this._oRow.offsetHeight;
	}
  },
  //设置新table位置属性
  SetPos: function(pos) {
	//设置pos
	this._pos = Math.max(0, Math.min(1, isNaN(pos) ? this._pos : pos));
	//获取位置
	this._viewHeight = document.documentElement.clientHeight;
	this._nTableViewTop = (this._viewHeight - this._nTableHeight) * this._pos;
	this.Run();
  },
  //运行
  Run: function() {
	if(!this.Hide){
		var top = this._doc.scrollTop, left = this._doc.scrollLeft
			//原tr是否超过顶部和底部
			,outViewTop = this._oRowTop < top, outViewBottom = this._oRowBottom > top + this._viewHeight;
		//原tr超过视窗范围
		if(outViewTop || outViewBottom){
			var viewTop = !this.Auto ? this._nTableViewTop
				: (outViewTop ? 0 : (this._viewHeight - this._nTableHeight))//视窗top
				,posTop = viewTop + top;//位置top
			//在原table范围内
			if(posTop > this._oTableTop && posTop + this._nTableHeight < this._oTableBottom){
				//定位
				if(isIE6){
					this._style.top = posTop + "px";
					this._style.left = this._oTableLeft + "px";
					setTimeout(Bind(this, this.SetSelect), 0);//iebug
				}else{
					this._style.top = viewTop + "px";
					this._style.left = this._oTableLeft - left + "px";
				}
				return;
			}
		}
	}
	//隐藏
	this._style.top = "-99999px";
	isIE6 && this.ResetSelect();
  },
  //设置select集合
  SetSelect: function() {
	this.ResetSelect();
	var rect = this._nTable.getBoundingClientRect();
	//把需要隐藏的放到_selects集合
	this._selects = Filter(this._oTable.getElementsByTagName("select"), Bind(this, function(o){
		var r = o.getBoundingClientRect();
		if(r.top <= rect.bottom && r.bottom >= rect.top){
			o._count ? o._count++ : (o._count = 1);//防止多个实例冲突
			//设置隐藏
			var visi = o.style.visibility;
			if(visi != "hidden"){ o._css = visi; o.style.visibility = "hidden"; }
			
			return true;
		}
	}))
  },
  //恢复select样式
  ResetSelect: function() {
	forEach(this._selects, function(o){ !--o._count && (o.style.visibility = o._css); });
	this._selects = [];
  }
};
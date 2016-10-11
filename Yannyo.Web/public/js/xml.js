function HTTPXml(_url){
this.url=_url;
this.oDocument=null;
this.oXmlHttp=null;
this.isNS=(document.all)?false:true;
this.isIE=this.isNS?false:true;
this.getXmlHttp=function(){if(this.isIE){try{this.oXmlHttp=new ActiveXObject("Msxml2.XMLHTTP");}catch(e){try{this.oXmlHttp=new ActiveXObject("Microsoft.XMLHTTP");}catch(e){}
}
}else if(window.XMLHttpRequest){this.oXmlHttp=new XMLHttpRequest();}
}

this.load=function(_content,_isAsynchronous,_mothed,_xmlUrl){_isAsynchronous=(!_isAsynchronous)? false:true;if(!this.oXmlHttp){this.getXmlHttp();}
if(_xmlUrl){this.url=_xmlUrl;}
if(!_mothed){_mothed='POST';}
this.oXmlHttp.open(_mothed,this.url,_isAsynchronous);if(_mothed=='POST'){this.oXmlHttp.setRequestHeader('Content-Type','application/x-www-form-urlencoded');}
if(_content){this.oXmlHttp.send(_content);}else{this.oXmlHttp.send(null);}
if(!_isAsynchronous){if(this.oXmlHttp.status==200){this.oDocument=this.oXmlHttp.responseXML;return true;}else{alert('XML 请求错误: '+this.oXmlHttp.statusText
+' ('+this.oXmlHttp.status+')');}
}else{this.oXmlHttp.onreadystatechange=function(){switch(this.oXmlHttp.readyState){case 0:
this.onUninitialized();break;case 1:
this.onLoading();break;case 2:
this.onLoaded();break;case 3:
this.onInteractive();break;case 4:
if(this.oXmlHttp.status==200){this.oDocument=this.oXmlHttp.responseXML;this.onComplete();}else{alert('XML 请求错误: '+this.oXmlHttp.statusText
+' ('+this.oXmlHttp.status+')');}
break;}
}.bind(this);}
return false;}
this.onUninitialized=function(){};this.onLoading=function(){};this.onLoaded=function(){};this.onInteractive=function(){};this.onComplete=function(){};
this.selectNodes=function(xpath){if(this.isIE){return this.oDocument.selectNodes(xpath);}else{var aNodeArray=new Array();var xPathResult=this.oDocument.evaluate(xpath,this.oDocument,
this.oDocument.createNSResolver(this.oDocument.documentElement),
XPathResult.ORDERED_NODE_ITERATOR_TYPE,null);if(xPathResult){var oNode=xPathResult.iterateNext();while(oNode){aNodeArray[aNodeArray.length]=oNode;oNode=xPathResult.iterateNext();}
}
return aNodeArray;}
}

this.selectSingleNode=function(xpath){if(this.isIE){return this.oDocument.selectSingleNode(xpath);}else{var xPathResult=this.oDocument.evaluate(xpath,this.oDocument,
this.oDocument.createNSResolver(this.oDocument.documentElement),9,null);if(xPathResult&&xPathResult.singleNodeValue){return xPathResult.singleNodeValue;}else{return null;}
}
}

this.getText=function(xpath){var oNode=(typeof(xpath)=="string")? this.selectSingleNode(xpath):xpath;if(oNode){return(this.isIE)? oNode.text:oNode.textContent;}else{return this.oXmlHttp.responseText;}
}

this.getAttribute=function(xpath,attributeName){var oNode=(typeof(xpath)=="string")? this.selectSingleNode(xpath):xpath;if(oNode){var oAttribute=oNode.attributes.getNamedItem(attributeName);return(oAttribute)? oAttribute.value:null;}else{return null;}
}
}
Function.prototype.bind=function(){var __method=this,args=$A(arguments),object=args.shift();return function(){return __method.apply(object,args.concat($A(arguments)));}
}
var $A=Array.from=function(iterable){if(!iterable)return [];if(iterable.toArray){return iterable.toArray();}else{var results=[];for(var i=0;i < iterable.length;i++){results.push(iterable[i]);}
return results;}
}

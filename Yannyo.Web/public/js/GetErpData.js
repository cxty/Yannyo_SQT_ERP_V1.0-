/**
 * cxty@qq.com
 */
function TGetErpData()
{
	this.productlist = null;
	this.productlistMsg = null;
	this.productlistMsgB = null;
	this.button1 = null;
	this.button2 = null;
	this.bDateTime = null;
	this.eDateTime = null;
	this.ProductArr = new Array();
	this.ProductSuccessCount = 0;
	this.AllSuccessCount	 = 0;
	this.AllFailureCount	 = 0;
}
TGetErpData.prototype.ini = function()
{
	this.productlist = document.getElementById('productlist');
	this.productlistMsg = document.getElementById('productlistMsg');
	this.productlistMsgB = document.getElementById('productlistMsgB');
	this.button1 = document.getElementById('button1');
	this.button2 = document.getElementById('button2');
	this.bDateTime = document.getElementById('bDateTime');
	this.eDateTime = document.getElementById('eDateTime');
	this.getProductList();
}
TGetErpData.prototype.getProductList = function()
{
	var url = 'Services/CAjax.aspx?do=GetErpProductList&RCode='+Math.random();
	var tXML = '<xml>'+
	'<tSQL></tSQL>'+
	'</xml>';
	var xml = new HTTPXml();
	xml.load(tXML,true,'POST',url);
	xml.onComplete = function(){
		GetErpData.RegetProductList(xml);
	}
	tXML = null;
	url = null;
}
TGetErpData.prototype.RegetProductList = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.ProductXMLtoArray(xml.selectNodes('//root/ProductList/Product'));
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
}
TGetErpData.prototype.ProductXMLtoArray = function(pNode)
{
	if (pNode) {
		if (pNode.length > 0) {
			for (var i = 0; i < pNode.length; i++) {
				if (pNode[i].nodeName != '#text') {
					if (pNode[i].nodeName == 'Product') {
						this.ProductArr.push(new Array(GetXMLData(pNode[i],'P_NAME'),
						GetXMLData(pNode[i],'P_CODE'),
						GetXMLData(pNode[i],'TYPENAME'),
						GetXMLData(pNode[i],'P_ID')));
					}
				}
			}
			this.BProductList();
		}
	}
}
TGetErpData.prototype.BProductList = function()
{
	if(this.ProductArr != null)
	{
		var tHTML = '';
		for(i=0;i<this.ProductArr.length;i++)
		{
			tHTML+='<li name="pListNode" pid="'+this.ProductArr[i][3]+'" value="'+this.ProductArr[i][3]+'"><nobr>['+this.ProductArr[i][2]+']('+this.ProductArr[i][1]+') '+this.ProductArr[i][0]+'</nobr><li>';
		}
		this.productlist.innerHTML = '<ul id="productlistUL">'+tHTML+'</ul>';
		this.productlistMsg.innerHTML = '共(<b>'+i+'</b>)个产品';
		tHTML = null;
	}
}
TGetErpData.prototype.Go = function(pid,SuccessCount,FailureCount)
{
	var ProductID=0;
	var bDate=this.bDateTime.value;
	var eDate=this.eDateTime.value;
	var IsRun = false;
	
	this.button1.disabled = 'disabled';
	this.button2.disabled = 'disabled';
	this.bDateTime.disabled = 'disabled';
	this.eDateTime.disabled = 'disabled';
	this.productlistUL = document.getElementById('productlistUL');
	var tLiArray = this.productlistUL.childNodes;

	if(pid==0){this.productlistMsgB.innerHTML='<img src="images/loading.gif" />数据处理中,该过程需要10-30分钟,请不要刷新,切换或关闭此页面!';}
	
	if(this.ProductArr != null && tLiArray !=null && this.ProductSuccessCount<this.ProductArr.length)
	{
		for(i=0;i<this.ProductArr.length;i++)
		{
			if (IsRun) {break;}
			for(j=0;j<tLiArray.length;j++)
			{
				if (IsRun) {break;}
				if (tLiArray[j].innerHTML != '') {
					if (tLiArray[j].value) {
						if (tLiArray[j].className != 'ok') {
							if (Number(pid) == Number(tLiArray[j].value)) {
								var tObj = document.createElement('div');
								tObj.appendChild(document.createTextNode('成功:' + SuccessCount + ' 失败:' + FailureCount));
								tLiArray[j].className = 'ok';
								tLiArray[j].appendChild(tObj);
								//tLiArray[j].focus();
								tObj = null;
								this.AllSuccessCount += Number(SuccessCount);
								this.AllFailureCount += Number(FailureCount);
								this.ProductSuccessCount++;
								this.productlistMsgB.innerHTML='已导入(<b>'+this.ProductSuccessCount+'</b>)产品信息,成功(<b>'+this.AllSuccessCount+'</b>),失败(<b>'+this.AllFailureCount+'</b>)<img src="images/loading.gif" />';
							}
							else {
								if (tLiArray[j].className != 'm') {
									if ((Number(tLiArray[j].value) == Number(this.ProductArr[i][3]))&& Number(tLiArray[j].value)!=0) {
										tLiArray[j].className = 'm';
										var tpid = this.ProductArr[i][3];
										eval('setTimeout(function(){GetErpData.getproductOrderList('+tpid+', \''+bDate+'\', \''+eDate+'\');}, 1500);');
										tpid = null;
										IsRun = true;
										break;
									}
								}
							}
						}
					}
				}
				if(this.ProductSuccessCount>=this.ProductArr.length){
					this.button1.disabled = '';
					this.button2.disabled = '';
					this.bDateTime.disabled = '';
					this.eDateTime.disabled = '';
					this.productlistMsgB.innerHTML='导入结束(<b>'+this.ProductSuccessCount+'</b>)产品信息,成功(<b>'+this.AllSuccessCount+'</b>),失败(<b>'+this.AllFailureCount+'</b>)';
					break;}
			}
			if(this.ProductSuccessCount>=this.ProductArr.length){
				this.button1.disabled = '';
				this.button2.disabled = '';
				this.bDateTime.disabled = '';
				this.eDateTime.disabled = '';
				this.productlistMsgB.innerHTML='导入结束(<b>'+this.ProductSuccessCount+'</b>)产品信息,成功(<b>'+this.AllSuccessCount+'</b>),失败(<b>'+this.AllFailureCount+'</b>)';
				break;}
		}
	}
	tLiArray = null;
}
TGetErpData.prototype.getproductOrderList = function(ProductID,bDate,eDate)
{
	if (ProductID > 0) {
		var url = 'Services/CAjax.aspx?do=GetErpProductOrderList&RCode=' + Math.random();
		var tXML = '<xml>' +
		'<pID><![CDATA[' +
		ProductID +
		']]></pID>' +
		'<oType><![CDATA[0]]></oType>' +
		'<bDate><![CDATA[' +
		bDate +
		']]></bDate>' +
		'<eDate><![CDATA[' +
		eDate +
		']]></eDate>' +
		'</xml>';
		var xml = new HTTPXml();
		xml.load(tXML, true, 'POST', url);
		xml.onComplete = function(){
			GetErpData.RegetproductOrderList(xml);
		}
		tXML = null;
		url = null;
	}
}
TGetErpData.prototype.RegetproductOrderList = function(xml)
{
	if(xml)
	{
		var MSG = xml.getText('//root/MSG');
        switch(xml.getText('//root/Error'))
        {
            case '-1':case -1:
				this.Go(xml.getText('//root/pID'),xml.getText('//root/SuccessCount'),xml.getText('//root/FailureCount'));
			break;
			default:
                alert(MSG);
            break;
        }
        MSG = null;
	}
}

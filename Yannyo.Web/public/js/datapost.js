/**
 * cxty@qq.com
 */
function TDataPost()
{
	this.pagesize = 20;
	this.page = 1;
	this.lcount = 1;
	this.datacount = 0;
}
TDataPost.prototype.ini = function()
{
	$('#page_num').val(this.page);
	$('#subbutton_add').click(function(){
		DataPost.page=$('#page_num').val();
		DataPost.GetOrderList($('#page_num').val());
	});
	$('#subbutton_p').click(function(){
		DataPost.PAttribute();
	});
}
TDataPost.prototype.PAttribute = function()
{
	var pList = $('#ProductList').children('ul').children('li');
	if(pList)
	{
		for(var i=0;i<pList.length;i++)
		{
			if(pList[i])
			{
				$.getJSON('/datapost.aspx?Act=GetPAttribute&pid='+$(pList[i]).attr('id').replace('p_',''),function(data){
					if(data.PAttributePrice)
					{
						$.post('/datapost.aspx?Act=PAttribute&pid='+data.Productid,{JsonStr:$.toJSON(data)},function(redata){
							
						});
						
					}
				});
			}
		}
	}
}
TDataPost.prototype.GetOrderList = function(page)
{
	$('#page_num').val(page);
	$.getJSON('/datapost.aspx?Act=GetOrderList&pagesize='+this.pagesize+'&page='+page+'&r='+Math.random(),function(data){
		if(data.Order)
		{
			try {
				for (var i = 0; i < data.Order.length; i++) {
					$('#OrderList').prepend('<li id="' + data.Order[i].O_ORDERNUM + '">单号:' + data.Order[i].O_ORDERNUM + '</li>');
					$.post('/datapost.aspx?Act=Add', {
						json: $.toJSON(data.Order[i])
					}, function(redata){
						DataPost.lcount++;
						DataPost.datacount++;
						$('#sMsg').html('累计:' + DataPost.datacount);
						if (redata.results == true) {
							$('#' + redata.orderid).prepend('[OK]');
						}
						else 
							if (redata.orderid) {
								$('#' + redata.orderid).prepend('[Error]' + redata.msg);
							}
							else {
								alert(redata.msg);
							}
						DataPost.ToLoop();
					}, 'json');
					
				}
			}catch(e)
			{
				DataPost.lcount++;
				DataPost.ToLoop();
			}
			
		}else{
			alert('已无数据!');
		}
	});
}
TDataPost.prototype.ToLoop = function()
{
	if(this.lcount == this.pagesize)
	{
		this.page++;
		this.lcount=1;
		this.GetOrderList(this.page);
	}
}

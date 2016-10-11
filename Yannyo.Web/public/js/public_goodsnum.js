/**
 * @author Cxty
 */
function TPublic_GoodsNum()
{
	this.reobj = '';
	this.pUnits = '';
	this.pMaxUnits = '';
	this.pToBoxNo = '';
}
TPublic_GoodsNum.prototype.ini = function()
{
	$('#bt_updatenum').click(function(){
		Public_GoodsNum.Save();
	});
	$('#bt_cancel').click(function(){
		window.parent.HidBox();
	});
	this.sum();
}
//输入框触发事件
TPublic_GoodsNum.prototype.onChange = function(sObj)
{
	if(sObj)
	{
		CheckNumber($(sObj));
	}
	this.sum();
}
//合计
TPublic_GoodsNum.prototype.sum = function()
{
	var tnum = $('#tBoxs :text');
	var sum = 0;
	var tMaxSum = '';
	for(var i=0;i<tnum.length;i++)
	{
		
		sum += Number($(tnum[i]).val());
		
	}
	if(this.pMaxUnits!='')
	{
		tMaxSum = ',合'+(sum/Number(this.pToBoxNo)).toFixed(2)+this.pMaxUnits;
	}
	$('#sum_num').html('<b>'+sum+this.pUnits+tMaxSum+'</b>');
}
//保存
TPublic_GoodsNum.prototype.Save = function()
{
	var m_count = 0;
	var tnum = $('#tBoxs :text');
	for(var i=0;i<tnum.length;i++)
	{
		
		CheckNumber($(tnum[i]));
		m_count++;
		
	}
	$('#m_count').val(m_count);
	$('#form1').submit();
}
function CheckNumber(obj)
{
	var t = obj.val();
	if (/^[-\+]?\d+(\.\d+)?$/.test(t)) 
	{
		
	}
	else if(t.substr(t.length-1)=='.')
	{
	
	}
	else
	{

		obj.val(0);
	}
}
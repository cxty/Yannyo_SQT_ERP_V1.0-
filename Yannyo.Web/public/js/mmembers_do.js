/**
 * @author Cxty
 */
function TM_Members_do()
{
	this.MConfigID = 0;
	this.PageIndex = 0;
	this.ActStr = '';
	this.PageBox = null;
	this.PageForm = null
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = document.body.clientWidth-20+'px';
		this.dh = $(window).height()-80+'px';
	}
}
TM_Members_do.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	$('#bt_download').click(function(){
		M_Members_do.SaveSelect();
	});
	$('#bt_cancel').click(function(){
		parent.HidBox();
	});
}
TM_Members_do.prototype.HidUserBox = function()
{
	CloseBox();
}
TM_Members_do.prototype.PageUp = function()
{
	location='mmembers_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex-1);
}
TM_Members_do.prototype.PageDown = function()
{
	location='mmembers_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex+1);
}
//保存选中的
TM_Members_do.prototype.SaveSelect = function()
{
	var tValue = '';
    for(var i=0 ;i<this.PageForm.elements.length;i++){ 
        if(this.PageForm.elements[i].name=="cCheck"){ 
            e=this.PageForm.elements[i];
            if(e.checked == true)
            {
				//进行导入更新操作
				if($(e).val())
				{
					$.post('mmembers_do-'+this.MConfigID+'-DownLoad.aspx?reformat=json',{"buyer_id":''+$(e).val()+'',"buyer_nick":''+$('#ch_'+$(e).val()).attr('buyer_nick')+'',"trade_amount":''+$('#ch_'+$(e).val()).attr('trade_amount')+'',"trade_count":''+$('#ch_'+$(e).val()).attr('trade_count')+'',"laste_time":''+$('#ch_'+$(e).val()).attr('laste_time')+'',"status":''+$('#ch_'+$(e).val()).attr('status')+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								jAlert(data.results.msg,'提示');
								$('#tr_'+data.results.ReValue.buyer_id).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.buyer_id).hide(500);
							}
						}
					},'json');
					tValue+=e.value+',';
				}
            }
        }
    }
    if(Trim(tValue) != '')
	{
		
	}else{
		jAlert('请选择要更新的会员.','提示');
	}
}

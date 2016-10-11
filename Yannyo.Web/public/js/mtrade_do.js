/**
 * @author Cxty
 */
function TM_Trade_do()
{
	this.MConfigID = '';
	this.ActStr = '';
	this.PageIndex = 0;
	this.PageForm = null;
	this.PageBox = null;
}
TM_Trade_do.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	//下载
	$('#bt_download').click(function()
	{
		M_Trade_do.SaveSelect();
	});
	//取消
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
}
TM_Trade_do.prototype.HidUserBox = function()
{
	CloseBox();
}
//上一页
TM_Trade_do.prototype.PageUp = function()
{
	location='mtrade_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex-1);
}
//下一页
TM_Trade_do.prototype.PageDown = function()
{
	location='mtrade_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex+1);
}
//保存选中的
TM_Trade_do.prototype.SaveSelect = function()
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
					$.post('mtrade_do-'+this.MConfigID+'-DownLoad.aspx?reformat=json',{"tid":''+$(e).val()+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								alert(data.results.msg);
								$('#tr_'+data.results.ReValue.tid).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.tid).hide(500);
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
		alert('请选择要更新的商品.');
	}
}
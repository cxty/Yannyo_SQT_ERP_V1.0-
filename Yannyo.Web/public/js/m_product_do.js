/**
 * @author Cxty
 */
function TM_Product_do()
{
	this.PageBox = null;
	this.PageForm = null;
	this.MConfigID = 0;
	this.PageIndex = 0;
	this.ActStr = '';
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
TM_Product_do.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	//取消
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
	//下载保存
	$('#bt_download').click(function()
	{
		M_Product_do.SaveSelect();
	});
	//更新数量
	$('#bt_updatenum').click(function()
	{
		M_Product_do.UpdateNum();
	});
	//更新商品信息
	$('#bt_edit').click(function()
	{
		M_Product_do.UpdateGoods();
	});
}
TM_Product_do.prototype.HidUserBox = function()
{
	CloseBox();
}
//上一页
TM_Product_do.prototype.PageUp = function()
{
	location='mproduct_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex-1);
}
//下一页
TM_Product_do.prototype.PageDown = function()
{
	location='mproduct_do-'+this.MConfigID+'-'+this.ActStr+'.aspx?page='+(this.PageIndex+1);
}
//弹出产品选择
TM_Product_do.prototype.ShowProductTree = function(sid)
{
	if(sid)
	{
		this.PageBox=dialog("匹配系统产品","iframe:public_producttree.aspx?pid="+$('#'+sid).attr('pid')+'&obj='+sid,this.dw,this.dh,"iframe");
	}
}
//匹配后的处理
TM_Product_do.prototype.SetProductID = function(pObj,sObj)
{
	if(pObj && sObj)
	{
		$('#'+sObj).attr('pid',pObj.id);
		$('#'+sObj).html('<a href="javascript:void(0);" onClick="javascript:M_Product_do.ShowProductTree(\''+sObj+'\');">'+pObj.name+'</a>');
		$('#ch_'+sObj.replace('loop_','')).attr('checked','checked');

	}
	CloseBox();
}
//保存选中的
TM_Product_do.prototype.SaveSelect = function()
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
					$.post('mproduct_do-'+this.MConfigID+'-DownLoad.aspx?reformat=json',{"num_iid":''+$(e).val()+'',"pid":''+$('#loop_'+$(e).val()).attr('pid')+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								alert(data.results.msg);
								$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.num_iid).hide(500);
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
		jAlert('请选择要更新的商品.','提示');
	}
}
//数量框
TM_Product_do.prototype.ShowNum = function(sid)
{
	if(sid)
	{
		this.PageBox=dialog('设置数量','iframe:public_goodsnum-'+this.MConfigID+'-'+$('#'+sid).attr('pid')+'.aspx?num_iid='+$('#'+sid).attr('num_iid')+'&obj='+sid,this.dw,this.dh,"iframe");
	}
}
//回调更新总数量
TM_Product_do.prototype.numReCall = function(rObj)
{
	if(rObj)
	{
		$('#a_'+rObj.sobj.replace('tr_','')).html(rObj.num);
		$('#ch_'+rObj.sobj.replace('tr_','')).attr('checked','checked');
	}
}
//更新选中的数量
TM_Product_do.prototype.UpdateNum = function()
{
	var tValue = '';
	var num_iid = '';
	var num = 0;
	var pid = 0;
    for(var i=0 ;i<this.PageForm.elements.length;i++){ 
        if(this.PageForm.elements[i].name=="cCheck"){ 
            e=this.PageForm.elements[i];
            if(e.checked == true)
            {
				num_iid =$(e).val();
				if(num_iid)
				{
					num = Number($.trim($('#a_'+num_iid).html()));
					pid = $('#tr_'+num_iid).attr('pid');
					
					$.post('mproduct_do-'+this.MConfigID+'-UpdateNum.aspx?reformat=json',{"num_iid":''+num_iid+'',"pid":''+pid+'',"num":''+num+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								alert(data.results.msg);
								$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.num_iid).hide(500);
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
		jAlert('请选择要更新的商品.','提示');
	}
}
//更新商品信息
TM_Product_do.prototype.UpdateGoods = function()
{
	var tValue = '';
	var ttValue='';
    for(var i=0 ;i<this.PageForm.elements.length;i++){ 
        if(this.PageForm.elements[i].name=="cCheck"){ 
            e=this.PageForm.elements[i];
            if(e.checked == true)
            {
				
				tValue+=e.value+',';
            }else{
				ttValue = $(e).val();
				$(document.getElementById(ttValue)).val('');
			}
        }
    }
    if(Trim(tValue) != '')
	{
		$(this.PageForm).submit();
	}else{
		jAlert('请选择要更新的商品属性.','提示');
	}
}

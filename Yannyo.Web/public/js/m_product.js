/**
 * @author Cxty
 */
function TM_Product()
{
	this.PageBox = null;
	this.PageForm = null;
	this.MConfigID = 0;
}
TM_Product.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	if(!(this.MConfigID > 0))
	{
		alert('参数错误!请返回!');
	}
	//下载更新
	$('#bt_DownLoad').click(function()
	{
		M_Product.DownLoad();
	});
	//更新数量
	$('#bt_UpdateNum').click(function()
	{
		M_Product.UpdateNum();
	});
	//删除
	$('#bt_Delt').click(function()
	{
		M_Product.Delt();
	});
	//上架
	$('#bt_UpList').click(function()
	{
		M_Product.UpList();
	});
	//下架
	$('#bt_DownList').click(function()
	{
		M_Product.DownList();
	});
	//推荐
	$('#bt_Recommend').click(function()
	{
		M_Product.Recommend();
	});
	//取消推荐
	$('#bt_NORecommend').click(function()
	{
		M_Product.NORecommend();
	});
}
TM_Product.prototype.GetPid = function(pid)
{
	var tValue = '';
	if(pid)
	{
		tValue = pid;
	}else{
	    for(var i=0 ;i<this.PageForm.elements.length;i++){ 
	        if(this.PageForm.elements[i].name=="cCheck"){ 
	            e=this.PageForm.elements[i];
	            if(e.checked == true)
	            {
	                tValue+=e.value+',';
	            }
	        }
	    }
	}
	return tValue;
}
//下载商品列表
TM_Product.prototype.DownLoad = function()
{
	this.PageBox = dialog("下载商城商品","iframe:mproduct_do-"+M_Product.MConfigID+"-DownLoad.aspx","550px","450px","iframe");
}
TM_Product.prototype.UpdateNum = function()
{
	this.PageBox = dialog("更新商城商品数量","iframe:mproduct_do-"+M_Product.MConfigID+"-UpdateNum.aspx","550px","450px","iframe");
}
//删除商品
TM_Product.prototype.Delt = function(sObj)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			if(sObj)
			{
				M_Product.DeltDo($(sObj));
			}else{
				var tValue = '';
				for(var i=0 ;i<M_Product.PageForm.elements.length;i++){ 
			        if(M_Product.PageForm.elements[i].name=="cCheck"){ 
			            e=M_Product.PageForm.elements[i];
			            if(e.checked == true)
			            {
							if ($(e).attr('num_iid')) {
								M_Product.DeltDo($(e));
								
								tValue += e.value + ',';
							}
			            }
			        }
			    }
				if(tValue=='')
				{
					jAlert('请选择商品!','提示');
				}
			}
		}
	});
}
TM_Product.prototype.DeltDo = function(sObj)
{
	
	$.post('mproduct_do-'+M_Product.MConfigID+'-Delt.aspx?reformat=json',{"num_iid":''+sObj.attr('num_iid')+'',"pid":''+$('#loop_'+sObj.attr('num_iid')).attr('pid')+''},function(data){
		if(data)
		{
			if(data.results.state.toLowerCase()=='false')
			{
				jAlert(data.results.msg,'提示');
				$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
			}else{
				$('#tr_'+data.results.ReValue.num_iid).hide(500);
			}
		}
	},'json');
		
}
//上架
TM_Product.prototype.UpList = function(sObj)
{
	if(sObj)
	{
		this.UpListDo($(sObj));
	}else{
		var tValue = '';
		for(var i=0 ;i<this.PageForm.elements.length;i++){ 
	        if(this.PageForm.elements[i].name=="cCheck"){ 
	            e=this.PageForm.elements[i];
	            if(e.checked == true)
	            {
					if ($(e).attr('num_iid')) {
						this.UpListDo($(e));
						
						tValue += e.value + ',';
					}
	            }
	        }
	    }
		if(tValue=='')
		{
			alert('请选择商品!');
		}
	}
}
TM_Product.prototype.UpListDo = function(sObj)
{
	$.post('mproduct_do-'+this.MConfigID+'-UpList.aspx?reformat=json',{"num_iid":''+sObj.attr('num_iid')+'',"pid":''+$('#loop_'+sObj.attr('num_iid')).attr('pid')+''},function(data){
		if(data)
		{
			if(data.results.state.toLowerCase()=='false')
			{
				alert(data.results.msg);
				$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
			}else{
				$('#list_'+data.results.ReValue.num_iid).html('已上架');
			}
		}
	},'json');
}
//下架
TM_Product.prototype.DownList = function(sObj)
{
	if(sObj)
	{
		this.DownListDo($(sObj));
	}else{
		var tValue = '';
		for(var i=0 ;i<this.PageForm.elements.length;i++){ 
	        if(this.PageForm.elements[i].name=="cCheck"){ 
	            e=this.PageForm.elements[i];
	            if(e.checked == true)
	            {
					if ($(e).attr('num_iid')) {
						this.DownListDo($(e));
						
						tValue += e.value + ',';
					}
	            }
	        }
	    }
		if(tValue=='')
		{
			alert('请选择商品!');
		}
	}
}
TM_Product.prototype.DownListDo = function(sObj)
{
	$.post('mproduct_do-'+this.MConfigID+'-DownList.aspx?reformat=json',{"num_iid":''+sObj.attr('num_iid')+'',"pid":''+$('#loop_'+sObj.attr('num_iid')).attr('pid')+''},function(data){
		if(data)
		{
			if(data.results.state.toLowerCase()=='false')
			{
				alert(data.results.msg);
				$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
			}else{
				$('#list_'+data.results.ReValue.num_iid).html('已下架');
			}
		}
	},'json');
}
//推荐
TM_Product.prototype.Recommend = function(sObj)
{
	if(sObj)
	{
		this.DownListDo($(sObj));
	}else{
		var tValue = '';
		for(var i=0 ;i<this.PageForm.elements.length;i++){ 
	        if(this.PageForm.elements[i].name=="cCheck"){ 
	            e=this.PageForm.elements[i];
	            if(e.checked == true)
	            {
					if ($(e).attr('num_iid')) {
						this.RecommendDo($(e));
						
						tValue += e.value + ',';
					}
	            }
	        }
	    }
		if(tValue=='')
		{
			alert('请选择商品!');
		}
	}
}
TM_Product.prototype.RecommendDo = function(sObj)
{
	$.post('mproduct_do-'+this.MConfigID+'-Recommend.aspx?reformat=json',{"num_iid":''+sObj.attr('num_iid')+'',"pid":''+$('#loop_'+sObj.attr('num_iid')).attr('pid')+''},function(data){
		if(data)
		{
			if(data.results.state.toLowerCase()=='false')
			{
				alert(data.results.msg);
				$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
			}else{
				$('#recommend_'+data.results.ReValue.num_iid).html('是');
			}
		}
	},'json');
}
//取消推荐
TM_Product.prototype.NORecommend = function(sObj)
{
	if(sObj)
	{
		this.DownListDo($(sObj));
	}else{
		var tValue = '';
		for(var i=0 ;i<this.PageForm.elements.length;i++){ 
	        if(this.PageForm.elements[i].name=="cCheck"){ 
	            e=this.PageForm.elements[i];
	            if(e.checked == true)
	            {
					if ($(e).attr('num_iid')) {
						this.NORecommendDo($(e));
						
						tValue += e.value + ',';
					}
	            }
	        }
	    }
		if(tValue=='')
		{
			alert('请选择商品!');
		}
	}
}
TM_Product.prototype.NORecommendDo = function(sObj)
{
	$.post('mproduct_do-'+this.MConfigID+'-NORecommend.aspx?reformat=json',{"num_iid":''+sObj.attr('num_iid')+'',"pid":''+$('#loop_'+sObj.attr('num_iid')).attr('pid')+''},function(data){
		if(data)
		{
			if(data.results.state.toLowerCase()=='false')
			{
				alert(data.results.msg);
				$('#tr_'+data.results.ReValue.num_iid).css("ErrorBox");
			}else{
				$('#recommend_'+data.results.ReValue.num_iid).html('否');
			}
		}
	},'json');
}
//修改
TM_Product.prototype.Edit = function(gid)
{
	M_Product.PageBox = dialog("修改商城商品","iframe:mproduct_do-"+M_Product.MConfigID+"-Edit.aspx?gid="+gid,"580px","450px","iframe");
}

TM_Product.prototype.HidUserBox = function()
{
	CloseBox();
}
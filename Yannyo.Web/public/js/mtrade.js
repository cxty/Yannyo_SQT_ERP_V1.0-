/**
 * @author Cxty
 */
function TM_Trade()
{
	this.MConfigID = '';
	this.ActStr = '';
	this.PageBox = null;
	this.PageForm = null;
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
TM_Trade.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	$('#bt_DownLoad').click(function(){
		M_Trade.DownLoad();
	});
	$('#bt_Reload').click(function()
	{
		M_Trade.ReLoad();
	});
	$('#bt_Delt').click(function()
	{
		M_Trade.Delete();
	});
	$('#bt_Close').click(function()
	{
		M_Trade.PageBox = dialog("关闭选中交易","iframe:mrecallmsg-"+M_Trade.MConfigID+".aspx","550px","230px","iframe");
	});
	$('#bt_Union').click(function()
	{
		M_Trade.Union();
	});
	$('#bt_Good').click(function()
	{
		M_Trade.Good();
	});
	$('#bt_Search').click(function()
	{
		M_Trade.Search();
	});
}
//搜索
TM_Trade.prototype.Search = function()
{
	location='/mtrade~'+this.MConfigID+'~'+$('#status').children('option:selected').val()+'~'+$('#sendgoods').children('option:selected').val()+'~'+$('#rate').children('option:selected').val()+'.aspx?oDateTimeB='+$('#oDateTimeB').val()+'&oDateTimeE='+$('#oDateTimeE').val()+'&S_key='+$('#S_key').val();
}
//下载交易信息
TM_Trade.prototype.DownLoad = function()
{
	this.PageBox = dialog("下载商城交易信息","iframe:mtrade_do-"+M_Trade.MConfigID+"-DownLoad.aspx","550px","450px","iframe");
}
//重载选中交易信息
TM_Trade.prototype.ReLoad = function()
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
					$.post('mtrade_do-'+this.MConfigID+'-DownLoad.aspx?reformat=json',{"tid":''+$(e).attr('tid')+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								jAlert(data.results.msg,'提示');
								$('#tr_'+data.results.ReValue.tid).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.tid).hide(500);
								$('#total_fee_'+data.results.ReValue.tid).html(data.results.Trade.total_fee);
								$('#post_fee_'+data.results.ReValue.tid).html(data.results.Trade.post_fee);
								$('#all_fee_'+data.results.ReValue.tid).html(Number(data.results.Trade.post_fee)+Number(data.results.Trade.total_fee));
								$('#type_'+data.results.ReValue.tid).html(data.results.Trade.type);
								$('#shipping_type_'+data.results.ReValue.tid).html(data.results.Trade.shipping_type);
								$('#status_'+data.results.ReValue.tid).html(data.results.Trade.status);
								$('#trade_from_'+data.results.ReValue.tid).html(data.results.Trade.trade_from);
								$('#seller_rate_'+data.results.ReValue.tid).html(data.results.Trade.seller_rate);
								$('#buyer_rate_'+data.results.ReValue.tid).html(data.results.Trade.buyer_rate);
								$('#pay_time_'+data.results.ReValue.tid).html(data.results.Trade.pay_time);
								$('#modified_'+data.results.ReValue.tid).html(data.results.Trade.modified);
								$('#tr_'+data.results.ReValue.tid).show(500);
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
//删除选中交易信息
TM_Trade.prototype.Delete = function()
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
					$.post('mtrade_do-'+this.MConfigID+'-Delete.aspx?reformat=json',{"tid":''+$(e).attr('tid')+'',"m_TradeInfoID":''+$(e).val()+''},function(data){
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
		jAlert('请选择要更新的商品.','提示');
	}
}
//关闭选中交易
TM_Trade.prototype.Close = function(Close_Msg)
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
					$.post('mtrade_do-'+this.MConfigID+'-Close.aspx?reformat=json',{"tid":''+$(e).attr('tid')+'',"m_TradeInfoID":''+$(e).val()+'',"Close_Msg":''+Close_Msg+''},function(data){
						if(data)
						{
							if(data.results.state.toLowerCase()=='false')
							{
								alert(data.results.msg);
								$('#tr_'+data.results.ReValue.tid).css("ErrorBox");
							}else{
								$('#tr_'+data.results.ReValue.tid).hide(500);
								
								$('#status_'+data.results.ReValue.tid).html('关闭');
								
								$('#modified_'+data.results.ReValue.tid).html(data.results.Trade.modified);
								$('#tr_'+data.results.ReValue.tid).show(500);
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

//平价选中交易
TM_Trade.prototype.Good = function()
{
	
}
//编辑交易,调整金额
TM_Trade.prototype.Edit = function(m_TradeInfoID)
{
	if(m_TradeInfoID)
	{
		
	}
}
//交易备注
TM_Trade.prototype.TradeMemo = function(m_TradeInfoID)
{
	if(m_TradeInfoID)
	{
		this.PageBox = dialog("交易备注","iframe:mrecallmsg-"+M_Trade.MConfigID+".aspx?Act=TradeMemo&m_TradeInfoID="+m_TradeInfoID+"","550px","230px","iframe");
	}
}
//合并选中交易,并发货哦
TM_Trade.prototype.Union = function()
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
					tValue+=e.value+',';
				}
            }
        }
    }
    if(Trim(tValue) != '')
	{
		this.PageBox = dialog("合并开单发货","iframe:msendgoods-"+M_Trade.MConfigID+".aspx?Act=Add&m_TradeInfoID="+tValue+"",this.dw,this.dh,"iframe");
	}else{
		jAlert('请选择要更新的商品.','提示');
	}
}
//发货
TM_Trade.prototype.SendGoods = function(m_TradeInfoID)
{
	if(m_TradeInfoID)
	{
		this.PageBox = dialog("开单发货","iframe:msendgoods-"+M_Trade.MConfigID+".aspx?Act=Add&m_TradeInfoID="+m_TradeInfoID+"",this.dw,this.dh,"iframe");
	}
}
//显示隐藏子单
TM_Trade.prototype.SHOrder = function(sObj)
{
	if(sObj)
	{
		var tStr = $(sObj).attr('id').replace('tr_','');
		var tObj =$('#order_'+tStr);
		if(tObj)
		{
			if(tObj.is(":hidden"))
			{
				$('#sh_'+tStr).html('关闭');
				tObj.show(500);
			}else{
				$('#sh_'+tStr).html('查看');
				tObj.hide(500);
			}
		}
		tStr = null;
		tObj = null;
	}
}
//查看发货单
TM_Trade.prototype.SHSendGoods = function(tid)
{
	if(tid){
		this.PageBox = dialog("发货单","iframe:msendgoods-"+M_Trade.MConfigID+".aspx?Act=Edit&m_TradeInfoID="+tid+"",this.dw,this.dh,"iframe");
	}
}
TM_Trade.prototype.HidUserBox = function()
{
	CloseBox();
}
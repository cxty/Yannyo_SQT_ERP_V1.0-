/**
 * cxty@qq.com
 */

function TMonthlyStatementList_do()
{
	this.sType = 0;
	this.orderrowid = 0;
	this.certificateid = 0;
	this.paymoneyid = 0;
	this.MonthlyStatementID = 0;
	this.MonthlyStatementDataJsonStr = '';
	this.MonthlyStatementDataJson = null;
	this.IsEdit = false;
	this.PrintPageWidth = '';
	this.UserCode = '';
	this.DepartmentsJsonStr = '';
	this.SupplierJsonStr = '';
	this.CustomersJsonStr = '';
	this.PaymentSystemJsonStr = '';
	this.tObjJson = null;
	this.ToObjectTreeIsOK = false;
	this.cObj = null;
	this.IsEditAct = false;
	this.sSteps = -1;//步骤

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
TMonthlyStatementList_do.prototype.ini = function()
{
	//隐藏凭证列表
	$('#certificate_box').hide();
	$('#SumCertificateMoney').hide();
	//隐藏金额列表
	$('#money_box').hide();
	$('#SumPayMoney').hide();

	if(this.MonthlyStatementDataJsonStr)
	{
		this.MonthlyStatementDataJson = jQuery.parseJSON(this.MonthlyStatementDataJsonStr);
		if (this.MonthlyStatementDataJson.MonthlyStatementDataJson) {
			this.AddOrderData(this.MonthlyStatementDataJson.MonthlyStatementDataJson,false);
			this.AddCertificateData(this.MonthlyStatementDataJson.MonthlyStatementDataJson);
			this.AddPayMoneyData(this.MonthlyStatementDataJson.MonthlyStatementDataJson);
		}
	}
	if (this.DepartmentsJsonStr && this.SupplierJsonStr && this.CustomersJsonStr) {
		this.tObjJson = jQuery.parseJSON('{"data":[' +
		'{"data":"客户","state":"closed","attr":{"rel":"root","stype":"0"},"children":[' +
		this.CustomersJsonStr +
		']}' +
		',{"data":"供应商","state":"closed","attr":{"rel":"root","stype":"1"},"children":[' +
		this.SupplierJsonStr +
		']}' +
		',{"data":"人员","state":"closed","attr":{"rel":"root","stype":"2"},"children":[' +
		this.DepartmentsJsonStr +
		']}' +
		(this.PaymentSystemJsonStr ? ',{"data":"结算系统","state":"closed","attr":{"rel":"root","stype":"3"},"children":[' + this.PaymentSystemJsonStr + ']}' : '') +
		']}');
		
	}
	$("body").append('<div id="ToObjectTreeBox"><div id="ToObjectTree"></div></div>');
	$("#ToObjectTreeBox").hide();

	if(this.sSteps>=0)
	{
		$('#certificate_box').show();
		$('#SumCertificateMoney').show();
	}
	if(this.sSteps>=1)
	{
		$('#money_box').show();
		$('#SumPayMoney').show();
	}
	if(this.sSteps>=1)
	{
		SetReadOnly(document.getElementById('sObjectName'));
		SetReadOnly(document.getElementById('sDateTime'));
		SetReadOnly(document.getElementById('sType'));
		SetReadOnly(document.getElementById('sReceiptState'));
	}
	switch(this.sSteps)
	{
		case 0://等待确认对账
			
		break;
		case 1://等待收付款
		
		break;
		case 2://等到结账
		
		break;
		case 3://已结账
		
		break;
	}
	$('#sDateTime').click(function(){
		if (MonthlyStatementList_do.sSteps < 1) {
			new Calendar().show(this);
		}else{
			jAlert('确认对账后对账时间无法修改,如需修改必须作废该对账单!','提示');
		}
	});
	//点击单位输入框
	$('#toobjbt').click(function()
	{
		if (MonthlyStatementList_do.sSteps < 1) {
			MonthlyStatementList_do.IsEditAct = true;
			
			if ($("#ToObjectTreeBox").is(":hidden")) {
				MonthlyStatementList_do.ShowToObjectTree($('#sObjectName'));
			}
			else {
				$("#ToObjectTreeBox").hide();
			}
		}else{
			jAlert('确认对账后对账单位无法修改,如需修改必须作废该对账单!','提示');
		}
	});
	$('#sObjectName').keyup(function(){
		MonthlyStatementList_do.IsEditAct = true;
		
		if($(this).val()=='')
		{
			$('#sObjectType').val(0);
			$('#sObjectID').val(0);
			$("#ToObjectTreeBox").hide();
		}else{
			MonthlyStatementList_do.ShowToObjectTree(this);
		}
		tID = null;
	}).bind("paste",function(){
		MonthlyStatementList_do.IsEditAct = true;
		if($(this).val()=='')
		{
			$('#sObjectType').val(0);
			$('#sObjectID').val(0);
			$("#ToObjectTreeBox").hide();
		}else{
			MonthlyStatementList_do.ShowToObjectTree(this);
		}
		tID = null;
	});
	//对账单类型
	$('#sType').change(function(){
		MonthlyStatementList_do.sType = $(this).children('option:selected').val();
	});
	//对账对象
	//$('#sObjectType').change(function(){
	//	MonthlyStatementList_do.SettoObj($(this).children('option:selected').val());
	//});
	//单据列表
	$('#subbutton_add_order').click(function(){
		//if ($("#sObjectID").val() != '') {
		
		//确认对账前可修改单据列表
		if (MonthlyStatementList_do.sSteps<1) {
			MonthlyStatementList_do.IsEditAct = true;
			dialog($('#sType').children('option:selected').text() + " 单据列表", 'iframe:/monthlystatementlist_orderlist-' + $('#sType').children('option:selected').val() + '.aspx', MonthlyStatementList_do.dw, MonthlyStatementList_do.dh, "iframe", 'HidBox();');
		}else{
			jAlert('确认对账后单据列表无法修改,如需修改必须作废该对账单!','提示');
		}
		
		//}else{
		//	jAlert('请填写对账对象!','提示',function(){
		//		$('#sObjectName').focus();	
		//	});
			
		//}
	});
	//凭证列表
	$('#subbutton_add_certificate').click(function(){
		//if ($("#sObjectID").val() != '') {
		if (MonthlyStatementList_do.sSteps < 1) {
			MonthlyStatementList_do.IsEditAct = true;
			dialog("凭证列表", 'iframe:/certificate_do_box-s.aspx', MonthlyStatementList_do.dw, MonthlyStatementList_do.dh, "iframe", 'HidBox();');
		}else{
			jAlert('确认对账后凭证列表无法修改,如需修改必须作废该对账单!','提示');
		}
		//}else{
		//	jAlert('请填写对账对象!','提示',function(){
		//		$('#sObjectName').focus();	
		//	});
		//}
	});
	//添加金额
	$('#subbutton_add_money').click(function(){
		if (MonthlyStatementList_do.sSteps < 2) {
			MonthlyStatementList_do.IsEditAct = true;
			dialog("对账单收付款金额", 'iframe:/monthlystatementlist_money.aspx', 300, 280, "iframe", 'HidBox();');
		}else{
			jAlert('确认收付款后对账单金额无法修改,如需修改必须作废该对账单!','提示');
		}
	});
	//新建
	$('#subbutton_add').click(function(){
		jConfirm('是否 <b>确认保存本次操作生成对账单</b> ?<br>生成对账单后所选单据将进入对账状态.','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({
					opacity: "0.5"
				}, "normal", function(){
					var OrderData = MonthlyStatementList_do.GetOrderData();
					var CertificateData = MonthlyStatementList_do.GetCertificateData();
					var PayMoneyData = MonthlyStatementList_do.GetPayMoneyData();
					if (OrderData) {
						OrderData = '"MonthlyStatementData":[' + OrderData + ']';
						CertificateData = '"MonthlyStatementAppendData":[' + CertificateData + ']';
						PayMoneyData = '"MonthlyStatementAppendMoneyData":['+PayMoneyData+']';
						var tJson = '{' + OrderData + ',' + CertificateData + ','+PayMoneyData+'}';
						$('#MonthlyStatementDataJson').val(tJson);
						$('#bForm').submit();
					}else{
						jAlert('请将需对账的单据添加至<b>单据列表</b>','提示',function(){
							$('#floatBoxBg').hide('slow');
							$('#floatBoxBg').remove();
						});
					}
				});
			}
		});
	});
	//更新
	$('#subbutton_edit').click(function(){
		jConfirm('是否 <b>确认保存本次操作更新对账单</b> ?','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({
					opacity: "0.5"
				}, "normal", function(){
					var OrderData = MonthlyStatementList_do.GetOrderData();
					var CertificateData = MonthlyStatementList_do.GetCertificateData();
					var PayMoneyData = MonthlyStatementList_do.GetPayMoneyData();
					if (OrderData) {
						OrderData = '"MonthlyStatementData":[' + OrderData + ']';
						CertificateData = '"MonthlyStatementAppendData":[' + CertificateData + ']';
						PayMoneyData = '"MonthlyStatementAppendMoneyData":['+PayMoneyData+']';
						var tJson = '{' + OrderData + ',' + CertificateData + ','+PayMoneyData+'}';
						$('#MonthlyStatementDataJson').val(tJson);
						$('#bForm').submit();
					}else{
						jAlert('请将需对账的单据添加至<b>单据列表</b>','提示',function(){
							$('#floatBoxBg').hide('slow');
							$('#floatBoxBg').remove();
						});
					}
				});
			}
		});
	});
	//对账确认
	$('#subbutton_d').click(function(){
		if (!MonthlyStatementList_do.IsEditAct) {
			jConfirm('是否 <b>确认对账</b> ?', '提示', function(r){
				if (r) {
					//if (Number($('#SumOrderMoney').html()) == Number($('#SumCertificateMoney').html())) {
						$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
						$("#floatBoxBg").animate({
							opacity: "0.5"
						}, "normal", function(){
							$.getJSON('/monthlystatementlist_do-d-' + MonthlyStatementList_do.MonthlyStatementID + '.aspx?format=json', function(data){
								if (data.results.state == 'True') {
									jConfirmYesNo(data.results.msg + ',是否跳转至下一条?', '提示', function(r){
										if (r == 'yes') {
											var nmid = data.results.NextMonthlyStatementID;
											if(nmid>0){
												location.href = '/monthlystatementlist_do-Edit-' + nmid + '-' + MonthlyStatementList_do.sType + '.aspx';
											}else{
												jAlert('已经是最后一条!', '提示',function(){location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';});
											}
										}else{
											location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';
										}
									});
								}
								else {
									jAlert(data.results.msg, '提示');
								}
							});
						});
					//}else{
						//jAlert('单据金额与凭证金额不相等!无法完成对账!','提示');
					//}
				}
			});
		}else{
			jAlert('请先保存更新.','提示');
		}
	});
	//完成付款,到款
	$('#subbutton_m').click(function(){
		if (!MonthlyStatementList_do.IsEditAct) {
			jConfirm('是否 <b>完成付款</b> ?', '提示', function(r){
				if (r) {
					if (Number($('#SumOrderMoney').html()) == Number($('#SumPayMoney').html())) {
						$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
						$("#floatBoxBg").animate({
							opacity: "0.5"
						}, "normal", function(){
						
							$.getJSON('/monthlystatementlist_do-m-' + MonthlyStatementList_do.MonthlyStatementID + '.aspx?format=json', function(data){
								if (data.results.state == 'True') {
									jConfirmYesNo(data.results.msg + ',是否跳转至下一条?', '提示', function(r){
										if (r == 'yes') {
											var nmid = data.results.NextMonthlyStatementID;
											if(nmid>0){
												location.href = '/monthlystatementlist_do-Edit-' + nmid + '-' + MonthlyStatementList_do.sType + '.aspx';
											}else{
												jAlert('已经是最后一条!', '提示',function(){location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';});
											}
										}else{
											location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';
										}
									});
								}
								else {
									jAlert(data.results.msg, '提示');
								}
							});
						});
					}else{
						jAlert('单据金额与收付款金额不相等!无法完成收付款操作!','提示');
					}
				}
			});
		}else{
			jAlert('请先保存更新.','提示');
		}
	});
	//结账
	$('#subbutton_e').click(function(){
		if (!MonthlyStatementList_do.IsEditAct) {
			jConfirm('是否 <b>结账</b> ?', '提示', function(r){
				if (r) {
					$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
					$("#floatBoxBg").animate({
						opacity: "0.5"
					}, "normal", function(){
						$.getJSON('/monthlystatementlist_do-e-' + MonthlyStatementList_do.MonthlyStatementID + '.aspx?format=json', function(data){
							if (data.results.state == 'True') {
									jConfirmYesNo(data.results.msg + ',是否跳转至下一条?', '提示', function(r){
										if (r == 'yes') {
											var nmid = data.results.NextMonthlyStatementID;
											if(nmid>0){
												location.href = '/monthlystatementlist_do-Edit-' + nmid + '-' + MonthlyStatementList_do.sType + '.aspx';
											}else{
												jAlert('已经是最后一条!', '提示',function(){location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';});
											}
										}else{
											location.href = '/monthlystatementlist_do-Edit-' + MonthlyStatementList_do.MonthlyStatementID + '-' + MonthlyStatementList_do.sType + '.aspx';
										}
									});
								}
							else {
								jAlert(data.results.msg, '提示');
							}
						});
					});
				}
			});
		}else{
			jAlert('请先保存更新.','提示');
		}
	});
	//作废
	$('#subbutton_invalid').click(function(){
		jConfirm('是否 <b>作废</b> ?','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
					$.getJSON('/monthlystatementlist_do-i-'+MonthlyStatementList_do.MonthlyStatementID+'.aspx?format=json',function(data){
						if(data.results.state)
						{
							jAlert(data.results.msg,'提示',function(){
								location.href = '/monthlystatementlist_do-Edit-'+MonthlyStatementList_do.MonthlyStatementID+'-'+MonthlyStatementList_do.sType+'.aspx';
							});
						}
						else
						{
							jAlert(data.results.msg,'提示');
						}
					});
				});
			}
		});
	});
	//查看操作记录
	$('#subbutton_log').click(function(){
		dialog("查看对账单操作记录",'iframe:/monthlystatementworkinglog-'+MonthlyStatementList_do.MonthlyStatementID+'.aspx',"500px","400px","iframe");
	});
	//打印
	$('#subbutton_print').click(function(){
		jConfirm('提示:每次打印系统都将留下打印记录!','提示',function(r){
			if (r) {
				var LODOP;
				try {
					LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
					try {
						LODOP.PRINT_INIT("对账单打印");
						//LODOP.SET_PRINT_PAGESIZE(3, MonthlyStatementList_do.PrintPageWidth, "0", "");
						LODOP.SET_PRINT_STYLE("FontSize", 12);
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", '/monthlystatementprint-'+MonthlyStatementList_do.MonthlyStatementID+'.aspx?UserCode=' + MonthlyStatementList_do.UserCode );
						LODOP.PREVIEW();
					} 
					catch (e) {
						jAlert('请安装打印控件![' + e + ']');
					}
					
					return false;
				} 
				catch (e) {
					window.open('', "top");
					setTimeout(window.open('//monthlystatementprint-'+MonthlyStatementList_do.MonthlyStatementID+'.aspx?UserCode=' + MonthlyStatementList_do.UserCode, "top"), 100);
					return false;
				}
			}
		});
		//window.open('', "top"); 
		//setTimeout(window.open('/monthlystatementprint-'+MonthlyStatementList_do.MonthlyStatementID+'.aspx', "top"), 100); 
		//return false;
	});
	
	//上期余额变动
	$('#sUpMoney').keyup(function(){
		CheckNumber($(this));
		MonthlyStatementList_do.SetSumTxt();
	}).bind('paste',function(){
		CheckNumber($(this));
		MonthlyStatementList_do.SetSumTxt();
	});
	//实际对账金额
	$('#sMoney').keyup(function(){
		CheckNumber($(this));
		MonthlyStatementList_do.SetSumTxt();
	}).bind('paste',function(){
		CheckNumber($(this));
		MonthlyStatementList_do.SetSumTxt();
	});
	
	$('#sObjectType').change();//初始化
	this.IsEdit = false;//初始化后
}
TMonthlyStatementList_do.prototype.SetSumTxt = function()
{
	var y_Money = Number($('#sUpMoney').val())+Number($('#sThisMoney').val());
	var t_Money = y_Money-Number($('#sMoney').val());
	var c_money = Number($('#sMoney').val())-Number($('#sToMoney').val());
	$('#y_money').html(Number(y_Money).toFixed(2));
	$('#t_sBalanceMoney').html(Number(t_Money).toFixed(2));
	$('#c_money').html(Number(c_money).toFixed(2));
	$('#sBalanceMoney').val(t_Money.toFixed(2));
}
TMonthlyStatementList_do.prototype.SettoObj = function(stype)
{
	$('#sObjectName').unautocomplete();//移除原绑定
	if(!this.IsEdit){
		$('#sObjectName').val('');
		$('#sObjectID').val('');
	}
	
	if(stype==1 || stype=='1')
	{
		$('#sObjectName').autocomplete('Services/CAjax.aspx',{ 
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetSupplierList',
			'RCode':Math.random(),
			'SupplierName':function(){return $('#sObjectName').val();
			}
		},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value +"("+ tArray[i].info+")",    
					value:tArray[i].id,    
					result:tArray[i].value    
					};    
				  }
			   return rows; 
			 },
		formatItem: function(row, i, max) {  
			   return row;
		},
		formatMatch: function(row, i, max) {
					return row.value; 
		},
		formatResult: function(row) { 
					return row.value;
		}
	  }).result(function(event, data, formatted) {
			$("#sObjectID").val((formatted!=null)?formatted:"0");
			MonthlyStatementList_do.GetSObjectUpMoney();
		}
	  );
	}
	if(stype==0 || stype=='0')
	{
		$('#sObjectName').autocomplete('Services/CAjax.aspx',{ 
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetStoresList',
			'RCode':Math.random(),
			'StoresName':function(){return $('#sObjectName').val();
			}
			},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value +"("+ tArray[i].info+")",    
					value:tArray[i].id,    
					result:tArray[i].value    
					};    
				  }
			   return rows; 
			 },
		formatItem: function(row, i, max) {  
			   return row;
		},
		formatMatch: function(row, i, max) {
					return row.value; 
		},
		formatResult: function(row) { 
					return row.value;
		}
	  }).result(function(event, data, formatted) {
			$("#sObjectID").val((formatted!=null)?formatted:"0");
			MonthlyStatementList_do.GetSObjectUpMoney();
		}
	  );
	}
	if(stype==2 || stype=='2')
	{
		$('#sObjectName').autocomplete('Services/CAjax.aspx',{ 
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetStaffList',
			'sType':'-1',
			'RCode':Math.random(),
			'StaffName':function(){return $('#sObjectName').val();
			}
			},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value +"("+ tArray[i].info+")",    
					value:tArray[i].id,    
					result:tArray[i].value    
					};    
				  }
			   return rows; 
			 },
		formatItem: function(row, i, max) {  
			   return row;
		},
		formatMatch: function(row, i, max) {
					return row.value; 
		},
		formatResult: function(row) { 
					return row.value;
		}
	  }).result(function(event, data, formatted) {
			$("#sObjectID").val((formatted!=null)?formatted:"0");
			MonthlyStatementList_do.GetSObjectUpMoney();
		}
	  );
	}
	if(stype==3 || stype=='3')
	{
		$('#sObjectName').autocomplete('Services/CAjax.aspx',{ 
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetPaymentSystemList',
			'RCode':Math.random(),
			'PaymentSystemName':function(){return $('#sObjectName').val();
			}
			},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value,    
					value:tArray[i].id,    
					result:tArray[i].value    
					};    
				  }
			   return rows; 
			 },
		formatItem: function(row, i, max) {  
			   return row;
		},
		formatMatch: function(row, i, max) {
					return row.value; 
		},
		formatResult: function(row) { 
					return row.value;
		}
	  }).result(function(event, data, formatted) {
			$("#sObjectID").val((formatted!=null)?formatted:"0");
			MonthlyStatementList_do.GetSObjectUpMoney();
		}
	  );
	}
}
TMonthlyStatementList_do.prototype.GetSObjectUpMoney = function()
{
	$.getJSON('/Services/CAjax.aspx?do=GetSObjectUpMoney&sObjectID='+$('#sObjectID').val()+'&sObjectType='+$('#sObjectType').children('option:selected').val()+'&sType='+$('#sType').children('option:selected').val(),function(data){
		if(data)
		{
			if(data.results.UpMoney)
			{
				$('#sUpMoney').val(data.results.UpMoney);
			}
		}
	});
}
TMonthlyStatementList_do.prototype.HidUserBox = function()
{
	CloseBox();
	//location=location;
}

//"MonthlyStatementDataJson":{
//"MonthlyStatementData":[{"MonthlyStatementDataID":0,"MonthlyStatementID":0,"OrderID":0,"oMoney":0,"sRemake":null,"sAppendTime":"\/Date(1292828094096+0800)\/"}],
//"MonthlyStatementAppendData":[{"MonthlyStatementAppendDataID":0,"MonthlyStatementID":0,"CertificateID":0,"aState":0,"aRemake":null,"aAppendTime":"\/Date(1292828094096+0800)\/","cMoney":0}]
//}

//添加单据列表数据
TMonthlyStatementList_do.prototype.AddOrderData = function(re,addc)
{
	if(re)
	{
		var tr = $('#orderLoop');
		var tHTML = '';

		if (tr) 
		{
			//建立列表
			for(var i=0;i<re.MonthlyStatementData.length;i++)
			{
				if(re.MonthlyStatementData[i])
				{
					tHTML+='<tr id="r_'+this.orderrowid+'" MonthlyStatementDataID="'+re.MonthlyStatementData[i].MonthlyStatementDataID+'" MonthlyStatementID="'+re.MonthlyStatementData[i].MonthlyStatementID+'" oMoney="'+re.MonthlyStatementData[i].oMoney+'" OrderID="'+re.MonthlyStatementData[i].OrderID+'" class="' + ((this.orderrowid % 2 != 0) ? 'trA' : 'trB') + '">'+
								'<td width="10%">'+re.MonthlyStatementData[i].oOrderNum+'</td>'+
						        '<td width="15%">'+re.MonthlyStatementData[i].oTypeStr+'</td>'+
								'<td width="15%">'+re.MonthlyStatementData[i].StoresSupplierName+'</td>'+
						        '<td >'+re.MonthlyStatementData[i].StaffName+'</td>'+
						        '<td width="15%" align="right">'+re.MonthlyStatementData[i].oOrderDateTime+'</td>'+
						        '<td width="10%" align="right">'+Number(re.MonthlyStatementData[i].oMoney).toFixed(2)+'</td><td width="10%" align="center"><a href="javascript:void(0);" onclick="javascript:MonthlyStatementList_do.DelOrderData('+this.orderrowid+');">删除</a></td></tr>';
					this.orderrowid++;
					if (addc) {//需要加载随附凭证
						//读取单据随附凭证列表,并建立
						$.getJSON('/Services/CAjax.aspx?do=GetOrderCertificateList&OrderID=' + re.MonthlyStatementData[i].OrderID, function(data){
							if (data) {
								MonthlyStatementList_do.AddCertificateData(data.results);
							}
						});
					}
				}
			}
			
			jQuery(tHTML).appendTo(tr);
			this.SumOrderMoney();
		}
	}
}
//整理返回单据列表Json
TMonthlyStatementList_do.prototype.GetOrderData = function()
{
	var reval = '';
	var tr = $('#orderLoop').children('tr');
	if(tr)
	{
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				reval+='{"MonthlyStatementDataID":\"'+$(tr[i]).attr('MonthlyStatementDataID')+'\","MonthlyStatementID":\"'+$(tr[i]).attr('MonthlyStatementID')+'\","OrderID":\"'+$(tr[i]).attr('OrderID')+'\","oMoney":\"'+$(tr[i]).attr('oMoney')+'\","sRemake":"","sAppendTime":"\/Date(1292828094096+0800)\/"},';
			}
		}
		if (reval != '') {
			reval = reval.substring(0, reval.length - 1);
		}
		//reval='"MonthlyStatementData":['+reval+']';
	}
	return reval;
}
//添加凭证列表数据
TMonthlyStatementList_do.prototype.AddCertificateData = function(re)
{
	if(re)
	{
		var tr = $('#certificateLoop');
		var tHTML = '';
		if(tr)
		{
			for(var i=0;i<re.MonthlyStatementAppendData.length;i++)
			{
				if(re.MonthlyStatementAppendData[i])
				{
					tHTML+='<tr id="c_'+this.certificateid+'" MonthlyStatementAppendDataID="'+re.MonthlyStatementAppendData[i].MonthlyStatementAppendDataID+'" MonthlyStatementID="'+re.MonthlyStatementAppendData[i].MonthlyStatementID+'" cType="'+re.MonthlyStatementAppendData[i].cType+'" cMoney="'+re.MonthlyStatementAppendData[i].cMoney+'" CertificateID="'+re.MonthlyStatementAppendData[i].CertificateID+'" cObject="'+re.MonthlyStatementAppendData[i].cObject+'" cObjectID="'+re.MonthlyStatementAppendData[i].cObjectID+'" class="' + ((this.certificateid % 2 != 0) ? 'trA' : 'trB') + '">'+
					        '<td width="10%">'+re.MonthlyStatementAppendData[i].cCode+'</td>'+
					        '<td width="15%">'+re.MonthlyStatementAppendData[i].cTypeStr+'</td>'+
					        '<td>'+re.MonthlyStatementAppendData[i].StaffName+'</td>'+
					        '<td width="20%" align="right">'+re.MonthlyStatementAppendData[i].cDateTime+'</td>'+
					        '<td width="15%" align="right">'+Number(re.MonthlyStatementAppendData[i].cMoney).toFixed(2)+'</td>'+
					        '<td width="10%" align="center"><a href="javascript:void(0);" onclick="javascript:MonthlyStatementList_do.DelCertificateData('+this.certificateid+');">删除</a></td></tr>';
							
					this.certificateid++;
				}
			}
			jQuery(tHTML).appendTo(tr);
			this.SumCertificateDataMoney();
		}
	}
}
//添加对账单发生收付款记录
TMonthlyStatementList_do.prototype.AddPayMoneyData = function(re)
{
	if (re) {
		var tr = $('#moneyLoop');
		var tHTML = '';
		if (tr) {
			for(var i=0;i<re.MonthlyStatementAppendMoneyData.length;i++)
			{
				if(re.MonthlyStatementAppendMoneyData[i])
				{
					tHTML+='<tr id="m_'+this.paymoneyid+'" MonthlyStatementAppendMoneyDataID="'+re.MonthlyStatementAppendMoneyData[i].MonthlyStatementAppendMoneyDataID+'" MonthlyStatementID="'+re.MonthlyStatementAppendMoneyData[i].MonthlyStatementID+'" mState="'+re.MonthlyStatementAppendMoneyData[i].mState+'" mMoney="'+re.MonthlyStatementAppendMoneyData[i].mMoney+'" mDateTime="'+re.MonthlyStatementAppendMoneyData[i].mDateTime+'" mRemake="'+re.MonthlyStatementAppendMoneyData[i].mRemake+'" title="'+re.MonthlyStatementAppendMoneyData[i].mRemake+'"  class="' + ((this.paymoneyid % 2 != 0) ? 'trA' : 'trB') + '">'+
					        '<td align="right">'+Number(re.MonthlyStatementAppendMoneyData[i].mMoney).toFixed(2)+'</td>'+
					        '<td width="15%" align="right">'+re.MonthlyStatementAppendMoneyData[i].mDateTime+'</td>'+
					        '<td width="10%" align="center"><a href="javascript:void(0);" onclick="javascript:MonthlyStatementList_do.DelPayMoneyData('+this.paymoneyid+');">删除</a></td></tr>';
							
					this.paymoneyid++;
				}
			}
			jQuery(tHTML).appendTo(tr);
			this.SumPayMoneyData();
		}
	}
}
//整理返回凭证列表Json
TMonthlyStatementList_do.prototype.GetCertificateData = function()
{
	var reval = '';
	var tr = $('#certificateLoop').children('tr');
	if(tr)
	{
		var _sum = 0;
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				reval+='{"MonthlyStatementAppendDataID":\"'+$(tr[i]).attr('MonthlyStatementAppendDataID')+'\","MonthlyStatementID":\"'+$(tr[i]).attr('MonthlyStatementID')+'\","CertificateID":\"'+$(tr[i]).attr('CertificateID')+'\","aState":0,"aRemake":"","aAppendTime":"\/Date(1292828094096+0800)\/","cMoney":\"'+$(tr[i]).attr('cMoney')+'\"},';
			}
		}
		if (reval != '') {
			reval = reval.substring(0, reval.length - 1);
		}
		//reval = '"MonthlyStatementAppendData":['+reval+']';
	}
	return reval;
}
//整理返回发生金额列表Json
TMonthlyStatementList_do.prototype.GetPayMoneyData = function()
{
	var reval = '';
	var tr = $('#moneyLoop').children('tr');
	if(tr)
	{
		var _sum = 0;
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				reval+='{"MonthlyStatementAppendMoneyDataID":\"'+$(tr[i]).attr('MonthlyStatementAppendMoneyDataID')+'\","MonthlyStatementID":\"'+$(tr[i]).attr('MonthlyStatementID')+'\","mMoney":\"'+$(tr[i]).attr('mMoney')+'\","mState":0,"mRemake":"'+$(tr[i]).attr('mRemake')+'","mAppendTime":"\/Date(1292828094096+0800)\/","mDateTime":\"'+$(tr[i]).attr('mDateTime')+'\"},';
			}
		}
		if (reval != '') {
			reval = reval.substring(0, reval.length - 1);
		}
		//reval = '"MonthlyStatementAppendData":['+reval+']';
	}
	return reval;
}
//删除单据列表数据
TMonthlyStatementList_do.prototype.DelOrderData = function(sObj)
{
	if (this.sSteps < 1) {
		this.IsEditAct = true;
		//删除该单据随附凭证
		var tr = $('#r_' + sObj);
		
		//删除随附单据
		this.DelCertificateDataByOrderID($(tr).attr('OrderID'));
		
		$(tr).remove();
		this.SumOrderMoney();
	}else{
		jAlert('确认对账后单据列表无法修改,如需修改必须作废该对账单!','提示');
	}
}
//取单据列表中编号集合
TMonthlyStatementList_do.prototype.GetOrderIDStr = function()
{
	var reStr = '';
	var tr = $('#orderLoop').children('tr');
	if (tr) {
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				reStr+=$(tr[i]).attr('OrderID')+',';
			}
		}
	}
	return reStr;
}
//删除凭证列表数据
TMonthlyStatementList_do.prototype.DelCertificateData = function(sObj)
{
	if (this.sSteps < 1) {
		this.IsEditAct = true;
		var tr = $("#c_" + sObj);
		//判断是否凭证已随附单据,已随附的不能删除,需先删除单据
		if ($.trim($(tr).attr('cobject')) == '1')//此为已随附凭证
		{
			jAlert('请先删除单据,不能删除已随附凭证.', '提示');
		}
		else {
			$(tr).remove();
		}
		this.SumCertificateDataMoney();
	}
	else {
		jAlert('确认对账后凭证列表无法修改,如需修改必须作废该对账单!', '提示');
	}
}
//删除单据随附凭证
TMonthlyStatementList_do.prototype.DelCertificateDataByOrderID = function(OrderID)
{
	var tr = $('#certificateLoop').children('tr');
	if (tr) 
	{
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				if($.trim($(tr[i]).attr('cObject'))=='1' && $.trim($(tr[i]).attr('cObjectID'))==$.trim(OrderID)){
					$(tr[i]).remove();
				}
			}
		}
		this.SumCertificateDataMoney();
	}
}
//删除发生金额
TMonthlyStatementList_do.prototype.DelPayMoneyData = function(PayMoneyID)
{
	if (this.sSteps < 2) {
		$('#m_' + PayMoneyID).remove();
		this.SumPayMoneyData();
	}
	else
	{
		jAlert('确认收付款后对账单金额无法修改,如需修改必须作废该对账单!', '提示');
	}
}
//取凭证列表中编号集合
TMonthlyStatementList_do.prototype.GetCertificateIDStr = function()
{
	var reStr = '';
	var tr = $('#certificateLoop').children('tr');
	if (tr) {
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				reStr+=$(tr[i]).attr('CertificateID')+',';
			}
		}
	}
	return reStr;
}
//合计单据金额
TMonthlyStatementList_do.prototype.SumOrderMoney = function()
{
	var tr = $('#orderLoop').children('tr');
	if(tr)
	{
		var _sum = 0;
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				_sum += Number($(tr[i]).attr('oMoney'));
			}
		}
		$('#SumOrderMoney').html(_sum.toFixed(2));
		$('#sThisMoney').val(_sum.toFixed(2));
	}
	this.SetSumTxt();
}
//合计凭证金额
TMonthlyStatementList_do.prototype.SumCertificateDataMoney = function()
{
	var tr = $('#certificateLoop').children('tr');
	if(tr)
	{
		var _sum = 0;
		var sType = $('#sType').children('option:selected').val();
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				if (sType == '1') {
					if ($.trim($(tr[i]).attr('cType')) == '1') {
						_sum += Number($(tr[i]).attr('cMoney'));
					}
					else {
						_sum -= Number($(tr[i]).attr('cMoney'));
					}
				}else if(sType=='2')
				{
					if ($.trim($(tr[i]).attr('cType')) == '1') {
						_sum -= Number($(tr[i]).attr('cMoney'));
					}
					else {
						_sum += Number($(tr[i]).attr('cMoney'));
					}
				}
			}
		}
		$('#SumCertificateMoney').html(_sum.toFixed(2));
		$('#sToMoney').val(_sum.toFixed(2));
	}
	this.SetSumTxt();
}
//合计发生金额
TMonthlyStatementList_do.prototype.SumPayMoneyData = function()
{
	var tr = $('#moneyLoop').children('tr');
	if(tr)
	{
		var _sum = 0;
		for(var i=0;i<tr.length;i++)
		{
			if (tr[i]) {
				_sum += Number($(tr[i]).attr('mMoney'));
			}
		}
		$('#SumPayMoney').html(_sum.toFixed(2));
		$('#sToMoney').val(_sum.toFixed(2));
	}
}
TMonthlyStatementList_do.prototype.Show  = function(sid,sType)
{
	if (sid) {
		location = 'monthlystatementlist_do-Edit-'+sid+'-'+sType+'.aspx';
	}
}

//显示单位树
TMonthlyStatementList_do.prototype.ShowToObjectTree = function(sObj)
{
	if(!this.ToObjectTreeIsOK)
	{
		$("#ToObjectTree").jstree({
			"json_data":MonthlyStatementList_do.tObjJson,
			"types" : {  
			 "valid_children" : [ "dt" ],  
			 "types" : {
				 "dt" : {
					 "icon" : { 
						"image" : "/images/dot.png" 
					},
					 "valid_children" : [ "default" ],
					 "max_depth" : 2,
					 "hover_node" : true,
					 "open_node":false,
					 "select_node" : true
				 },
				"root":{
					"valid_children" : [ "default" ],
					"hover_node" : false,
					"select_node" : function () {return false;}
				 }  
			 }  
			},
			"themes" : {"theme" : "default"}, 
			"plugins" : [ "themes", "json_data", "ui", "crrm", "types", "hotkeys","search"]
		}).bind("select_node.jstree",function (e,data){
			var sID = data.rslt.obj.attr("id").replace('d_','');
			var sType = data.rslt.obj.attr("otype");
			var sName = data.rslt.obj.context.text;
			var isRoot = data.rslt.obj.attr("rel") == 'root'?1:0;
			MonthlyStatementList_do.ShowcObjectBox_ReCall(sID,sType,sName);
			
		});
		this.ToObjectTreeIsOK = true;
	}
	this.cObj = $(sObj);
	var cObjoffset = this.cObj.offset();
	$("#ToObjectTreeBox").show();
	$("#ToObjectTreeBox").offset({ top: cObjoffset.top+25, left: cObjoffset.left });
	$("#ToObjectTree").jstree("search",$(this.cObj).val());
	cObjoffset = null;
	
}
TMonthlyStatementList_do.prototype.ShowcObjectBox_ReCall = function(sID,sType,sName)
{
	if(this.cObj)
	{
		this.cObj.val(sName);
		$('#sObjectID').val(sID);
		$('#sObjectType').val(sType);
	}
	$("#ToObjectTreeBox").hide();
}
function CheckNumber(obj)
{
	var t = obj.val();
	if (/^[-\+]?\d+(\.\d+)?$/.test(t)) {
		
	}
	else if(t.substr(t.length-1)=='.')
	{
	
	}else
	{

		obj.val(0);
	}
}
function SetReadOnly(obj){  
    if(obj){  
        obj.onbeforeactivate = function(){return false;};  
        obj.onfocus = function(){obj.blur();};  
        obj.onmouseover = function(){obj.setCapture();};  
        obj.onmouseout = function(){obj.releaseCapture();};  
    }  
} 
function AddPayMoneyData(re)
{
	MonthlyStatementList_do.AddPayMoneyData(re);
	CloseBox();
}

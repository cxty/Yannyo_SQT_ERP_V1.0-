/**
 * cxty@qq.com
 */
function TCertificate_do_box()
 {
 	this.OrderType = 0;
	this.OrderID = 0;
	this.P_CertificateIDStr = '';
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
TCertificate_do_box.prototype.ini = function()
{
	if (parent.MonthlyStatementList_do) {
		this.P_CertificateIDStr = parent.MonthlyStatementList_do.GetCertificateIDStr();
		this.iniCertificateList();
	}
	
	//添加随附,凭证
	$('#subbutton_add').click(function(){
		dialog("凭证录入",'iframe:/certificate_do-Add-'+Certificate_do_box.OrderType+'-'+Certificate_do_box.OrderID+'.aspx',Certificate_do_box.dw,Certificate_do_box.dh,"iframe",'HidBox();');
	});
	//完成操作
	$('#subbutton_save').click(function(){
		var CertificateIDStr = '';
		var tr = $('#dloop tr');
		if (tr) {
			if (tr.length > 0) {
				for (var i = 0; i < tr.length; i++) {
					CertificateIDStr +=$(tr[i]).attr('CertificateID')+',';
				}
			}
		}
		$.post('/certificate_do_box-'+Certificate_do_box.OrderType+'-'+Certificate_do_box.OrderID+'.aspx?Act=Finish&CertificateIDStr='+CertificateIDStr,null,function(redata){
			alert(redata.results.msg);
			if(redata.results.state=='false')
			{
				
			}else{
				parent.OrderDO.HidUserBox();
			}
		});
	});
	//搜索
	$('#button_Search').click(function(){
		location='certificate_do_box.aspx?Act=s&cNumber='+$('#cNumber').val()+'&cType='+$('#cType').children('option:selected').val()+'&cDateTimeB='+$('#cDateTimeB').val()+'&cDateTimeE='+$('#cDateTimeE').val();
	});
	//添加选中
	$('#subbutton_addto').click(function(){
		Certificate_do_box.ToAdd();
	});
	//全选
	$('#checkbox_b').click(function(){
		if ($(this).attr("checked") == true) { // 全选
		   $('#dloop tr').find(':checkbox').each(function() {
		   $(this).attr("checked", true);
		  });
		} else { // 取消全选
		   $('#dloop tr').find(':checkbox').each(function() {
		   $(this).attr("checked", false);
		  });
		}
	});
}
//过滤单据列表中已存在的单据
TCertificate_do_box.prototype.iniCertificateList = function()
{
	var tr = $('#dloop tr').find(':checkbox');
	if(tr)
	{
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				if((','+this.P_CertificateIDStr+',').indexOf($(tr[i]).val())>-1)
				{
					$(tr[i]).remove();
				}
			}
		}
	}
}
//查看凭证
TCertificate_do_box.prototype.ShowData = function(CertificateID,cCode)
{
	dialog("凭证:"+cCode,'iframe:/certificate_do-Edit-'+this.OrderType+'-'+this.OrderID+'-'+CertificateID+'.aspx',this.dw,this.dh,"iframe",'HidBox();');
}
//移除项目
TCertificate_do_box.prototype.Del = function(sObj,CertificateID)
{
	if(CertificateID && sObj)
	{
		$(sObj).parent().parent().remove();
		$.getJSON('/Services/CAjax.aspx?do=RemoveCertificateToObject&cid='+CertificateID,function(data){
			if(data.results == true){
				
			}else{
				alert(data.msg);
			}
			});
		this.SumT();
	}
}
//合计金额
TCertificate_do_box.prototype.SumT = function()
{
	var tM = 0;
	var tr = $('#dloop tr');
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tM+=Number($(tr[i]).children('td').children('.loop_Money').first().html());
			}
		}
	}
	$('#SumMoney').html(Number(tM).toFixed(2));
	tM = null;
	tr = null;
}
//关闭页面
TCertificate_do_box.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
}
//添加选中
TCertificate_do_box.prototype.ToAdd = function()
{
	var redata = null;
	var reloopdata = '';
	var tr = $('#dloop input:checked');
	if (tr) {
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				reloopdata+='{"MonthlyStatementAppendDataID":0,"MonthlyStatementID":0,"CertificateID":"'+$(tr[i]).val()+'",'+
				'"aState":0,"aRemake":"",'+
				'"cCode":"'+$(tr[i]).attr('cCode')+'",'+
				'"aAppendTime":"'+$(tr[i]).attr('cAppendTime')+'","cMoney":"'+$(tr[i]).attr('cMoney')+'",'+
				'"cType":"'+$(tr[i]).attr('cType')+'","cTypeStr":"'+$(tr[i]).attr('cTypeStr')+'",'+
				'"UserID":"'+$(tr[i]).attr('UserID')+'","UserName":"'+$(tr[i]).attr('UserName')+'",'+
				'"UserStaffName":"'+$(tr[i]).attr('UserStaffName')+'","StaffName":"'+$(tr[i]).attr('StaffName')+'",'+
				'"StaffID":"'+$(tr[i]).attr('StaffID')+'","cDateTime":"'+$(tr[i]).attr('cDateTime')+'",'+
				'"cObject":"'+$(tr[i]).attr('cObject')+'","cObjectID":"'+$(tr[i]).attr('cObjectID')+'"},'
			}
		}
		if (reloopdata != '') {
			reloopdata = reloopdata.substring(0, reloopdata.length - 1);
		}
		redata = '{"MonthlyStatementAppendData":['+reloopdata+']}';
		parent.MonthlyStatementList_do.AddCertificateData(jQuery.parseJSON(redata));
		$(tr).remove();
	}
}

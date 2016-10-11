/**
 * @author Cxty
 */
function TImportdata()
{
	this.setps = 1;//步骤
	this.sDateTime = '';
	this.ok_count = 0;
	this.sIdStr='';
	this.add_count = 0;
}
TImportdata.prototype.ini = function()
{
	if (this.setps == 1) {
		var sDateTime_A = $('#sDateTime_A');
		var sDateTime = $('#sDateTime');
		if (sDateTime_A.attr('checked') == true) {
			sDateTime.show();
		}
		else {
			sDateTime.hide();
			sDateTime.val('');
		}
		
		sDateTime_A = null;
		
		sDateTime = null;
		
		$('#bt_step_a').click(function(){
			if ($('#sDateTime').val() != '' || !$('#sDateTime_A').attr('checked')) {
				$('#Box_A').hide();
				$('#Box_B').hide();
				$('#Box_C').hide();
				
				$('#Box_D').show();
				
				$('#bForm').submit();
			}
			else {
				jAlert('时间不能为空!','提示');
			}
		});
	}
	if (this.setps == 2) {
		this.add_count = Number($('#add_count').text());
		$('#bt_re').hide();
		$('#bt_sub').click(function(){
			$('#bt_sub').hide();
			var tr = $('#tBoxs').children('tbody').children('tr');
			for (var i = 0; i < tr.length; i++) {
				if(tr[i])
				{
					jQuery.post('/importdata.aspx?steps=2&format=Json&act=add',{'tID':$(tr[i]).attr('id'),
					'sStoresID':$(tr[i]).attr('sStoresID'),
					'sStoresName':$(tr[i]).attr('sStoresName'),
					'pBarcode':$(tr[i]).attr('pBarcode'),
					'sProductsName':$(tr[i]).attr('sProductsName'),
					'sNum':$(tr[i]).attr('sNum'),
					'sPrice':$(tr[i]).attr('sPrice'),
					'sDateTime':Importdata.sDateTime},function(data){
						if (data.results.state == 'True') {
							Importdata.sIdStr+=','+data.results.sID;
							$('#'+data.results.tID).hide();
							$('#'+data.results.tID).remove();
							Importdata.ok_count++;
							$('#add_ok').html(Importdata.ok_count);
							if(Importdata.add_count==Importdata.ok_count)
							{
								jConfirm('数据已全部导入成功!是否继续导入?','提示',function(r){
									if(r)
									{
										location='/importdata.aspx';
									}else{
										parent.HidBox();
									}
								});
							}							
						}else{
							jAlert(data.results.msg,'提示');
						}
					});
				}
			}
			$('#bt_re').show();
		});
		$('#bt_re').click(function(){
			jConfirm('是否确认删除刚上传的数据?删除后需重新上传!','提示',function(r){
				if (r) {
					jQuery.post('/importdata.aspx?steps=2&format=Json&act=del', {
						'sDateTime': Importdata.sDateTime,
						'sIDStr': Importdata.sIdStr
					}, function(data){
						if (data.results.state == 'True') {
							jAlert(data.results.msg, '提示');
						}
						else {
							jAlert(data.results.msg, '提示');
						}
					});
				}
			});
		});
	}
}

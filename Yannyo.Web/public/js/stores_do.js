/**
 * @author Cxty
 */
function TStores_do()
{
	
}
TStores_do.prototype.ini = function()
{
	$('#bt_ok').click(function(){
		var dd = $("#category").mcDropdown();
		if(dd!=''){
			var ddarray = dd.getValue();
			if(ddarray.length>0)
			{
				if(Number(ddarray[0])>0){
					$('#CustomersClassID').val(Number(ddarray[0]));
					
					var dd_b = $("#category_b").mcDropdown();
					if(dd_b!=''){
						var dd_barray = dd_b.getValue();
						if(dd_barray.length>0)
						{
							if(Number(dd_barray[0])>0){
								$('#RegionID').val(Number(dd_barray[0]));

								var dd_c = $("#category_c").mcDropdown();
								if(dd_c!=''){
									var dc_barray = dd_c.getValue();
									if(dc_barray.length>0)
									{
										if(Number(dc_barray[0])>0){
											$('#PriceClassID').val(Number(dc_barray[0]));
											
											var dd_d = $("#category_d").mcDropdown();
											var dd_e = $("#category_e").mcDropdown();
											if(dd_d)
											{
												var dd_barray = dd_d.getValue();
												if(dd_barray.length>0)
												{
													$('#YHsysID').val(Number(dd_barray[0]));
												}
											}
											if(dd_e)
											{
												var de_barray = dd_e.getValue();
												if(de_barray.length>0)
												{
													$('#PaymentSystemID').val(Number(de_barray[0]));
												}
											}

											if($('#sName').val() != '')
											{
												if ($('#sType').val().length > 1) {
													jAlert('门店类型请填写A,B,C,D!','提示');	
												}
												else {
													$('#bForm').submit();
												}

											}else
											{
												jAlert('门店名称不能为空!','提示');	
											}
										}else
										{
											jAlert('请选择价格分类!','提示');		
										}
									}
									else
									{
										jAlert('请选择价格分类!','提示');	
									}
								}
								else
								{
									jAlert('请选择价格分类!','提示');	
								}
							}else
							{
								jAlert('请选择地区!','提示');	
							}
						}
						else
						{
							jAlert('请选择地区!','提示');	
						}
					}
					else
					{
						jAlert('请选择地区!','提示');	
					}
				}else
				{
					jAlert('请选择客户分类!','提示');	
				}
			}
			else
			{
				jAlert('请选择客户分类!','提示');
			}
		}
		else
		{
			jAlert('请选择客户分类!','提示');
		}
	});
}

/**
 * @author Cxty
 */
function TM_Goodscat_do()
{
	this.MConfigID = 0;
	
}
TM_Goodscat_do.prototype.ini = function()
{
	$('#cat_msg_a').show();
	$('#cat_msg_b').hide();
	$('#bt_go').click(function(){
		$(this).attr('disabled','disabled');
		
		$('#cat_msg_a').hide(500,function(){
			$('#cat_msg_b').show(500);
		});
		
		jQuery.post('/mgoodscat_do-'+M_Goodscat_do.MConfigID+'-download.aspx?reformat=json','',function(data){
			if(data)
			{
				jAlert(data.results.msg,'ÌבÊ¾',function(){
					if(data.results.state.toLowerCase()=='false')
					{
						$('#bt_go').removeAttr('disabled');
						$('#cat_msg_b').hide(500,function(){
							$('#cat_msg_a').show(500);
						});
					}else{
						parent.HidBox();
					}
				});
			}
		},'json');

	});
}

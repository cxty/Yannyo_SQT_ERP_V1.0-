/*
//google统计
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-23955592-1']);
_gaq.push(['_trackPageview']);

(function() {
var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
*/

$().ready(function(){
  //清理缓存
  $('#top_clear_caches').click(function(){
	jConfirm('是否确认进行 <b>缓存清理</b> 操作?<br>提示:清理缓存会使系统部分功能变缓慢,清理后10分钟内恢复正常.', '提示', function(r){
		if (r) {
			$("body").append('<div id="floatBoxBg" style="height:'+$(document).height()+'px;filter:alpha(opacity=0);opacity:0;"></div>');
			$("#floatBoxBg").animate({opacity:'0.5'},'normal',function(){
				$.getJSON('/default.aspx?CachesClear=1', function(data){
					jAlert('清理成功!', '提示',function(){
						location=location;
					});
				});
			});
		}
	});
  });
  
  //修改密码
  $('#top_edit_pwd').click(function(){
	dialog('修改密码','iframe:manage_pwd.aspx',400,250,'iframe');
  });


  //替换分页条样式
  var _tbar = $('.datalist')?$('.datalist').find('font'):$('#footer_tool').find('font');
	if(_tbar)
	{
		for(var i = 0;i<_tbar.length;i++)
		{
			if(_tbar[i])
			{
				if($(_tbar[i]).attr('style') == 'font-family: Webdings;')
				{
					switch($(_tbar[i]).html())
					{
						case 9:case '9':
							$(_tbar[i]).html('<img src="/images/prev_1.gif" />');
						break;
						case ':':
							$(_tbar[i]).html('<img src="/images/next_1.gif" />');
						break;
					}
					
				}
			}
		}	
	}
  //报表数字突显
  $('#tBox td span').hover(function(){

			var w = $(document).width();
			$(this).parent().removeClass('tdTextH');
			$(this).parent().addClass('tdTextS');
			var p = $(this).parent().position();
			var l = p.left;
			
			var ww = $(this).width();
			if(w<(p.left+ww-5))
			{
				l = w-ww;
			}
	
			$(this).offset({top:p.top-5,left:l-5});
			p = null;
		},
		function(){

		$(this).parent().removeClass('tdTextS');
		$(this).parent().addClass('tdTextH');
		
		$(this).offset();
		}
	);
	//输入框加提示信息
	$('input').each(function(i,dom){
		if($(dom).attr('showtitle'))
		{
			$(dom).focusin(function(){
				$('body').append(jQuery('<span class="showtitle" id="'+$(this).attr('id')+'titlebox'+'">'+$(this).attr('showtitle')+'</span>'));
				var p = $(this).position();
				$('#'+$(this).attr('id')+'titlebox').offset({top:p.top,left:p.left+3+$(this).width()});
				p = null;
			});
			$(dom).focusout(function(){
				$('#'+$(this).attr('id')+'titlebox').remove();
			});
		}
	});
});
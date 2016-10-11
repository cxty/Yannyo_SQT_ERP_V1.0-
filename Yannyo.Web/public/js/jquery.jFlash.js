/**
 * @author ToFishes
 * @version 1.0
 * 根据指定css属性闪烁的插件
 */
;(function($){
    $.fn.jFlash = function(c){
        c = $.extend({
            css: {}, //闪烁变化的css属性
            time: 100, //interval time 闪烁间隔时间
            count: 20, //闪烁的次数
            status: "jFlashing", //表示闪烁中
            onStop: function(t){} //闪烁完的回调函数，传入闪烁对象的引用
        }, c);
 
        return this.each(function(){
            var _t = $(this), init = _t.data("initCss") || {};
            /* 如果正在闪烁中，则清除当前的，继续调用下一个闪烁 */
            if(_t.hasClass(c.status)) {
				_t.css(init);
                clearTimeout(_t.data("jFlashId") || 0);
			};

	        for(var n in c.css) {
                init[n] = _t.css(n);
            };
			_t.data("initCss", init);
 
            var params = {
                "0": init,
                "1": c.css
            },  flashId, count = c.count % 2 == 0 ? c.count : c.count + 1; //count保证为偶，这样最后的css才是最初的状态。
 
            function flash(){
                _t.css(params[count % 2]).addClass(c.status);
                count--;
                if(count < 0) {
                    c.onStop(_t.removeClass(c.status));
                    return;
                };
                flashId = setTimeout(flash, c.time);
				_t.data("jFlashId", flashId);
            };
            flash();
        });
    };
})(jQuery);
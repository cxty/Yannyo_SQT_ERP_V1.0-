/*
 * biGrid for jQuery - Grid for BI
 *
 * Copyright (C) 2008 Jasper Lau (jasper_liu@msn.com)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * Date: Oct. 4 2008 11:46 PM -0800
*/
(function($){
    var _bigrid_moving = null;
    var _bigrid_x = 0;
    var _bigrid_y = 0;
    var _bigrid_interval = null;
    var _bigrid_timeinterval = 200;

    // Init the bi grid
    $.init_biGrid = function(table, property){
    
        // Apply default properties
        property = $.extend({
            fixedrow : 1,       // fixed row don't scroll while the scroll bar moves
            fixedcolumn : 1,    // fixed column don't scroll while the scroll bar moves            
            visiblerow : -1,    // total rows to be displayed, not include the fixed rows; 
                                // -1 means all rows will be displayed.
            visiblecolumn : -1, // total columns to be displayed, not include the fixed columns; 
                                // -1 means all columns will be displayed.
            totalrow : 0,       // total rows including the fixed rows
            totalcolumn : 0,    // total columns including the fixed columns
            startrow : 1,       // the index of the first visible row, except the fixed rows, index starts from 1
            startcolumn: 1,    // the index of the first visible column, except the fixed columns, index starts from 1

            rowheight: 20,     // the height of each row

            enableedit: false, // enable edit or not
            promptbeforesave: true, // prompt users before save the changes to data.
            saveurl: "", // the ajax server side page for saving changes.
            
            datatype : 'JSON',  // 'JSON', 'XML'
            initbyajax: false, // Init data through ajax
            
            skin : 'default',   // skin name, 'none', 'default'
            imagefolder : ''    // the image folder
            
            
        }, property);
        $(table).resize(function(){
            //alert("resize");
        });
        
        
        var grid = {
            // Scroll functions
            prepareScroll : function() {
                var table_parent = document.createElement('table');
                
                $(table_parent).attr({cellPadding:0, cellSpacing:0, border:0, align:$(table).attr('align')})
                .addClass('biGrid')
                .removeAttr('width');
                
                $(table_parent).html("<tr><td valign='top'></td><td valign='top'></td></tr>");
                $(table).before(table_parent);
                
                var scrollbarHorizon = "<div class='gScrollbarHorizon' onselectstart='return false'><img class='gScrollbarBtnLeft' src='" + property.imagefolder + "public/js/skin/default/images/sl.gif' /><img class='gScrollbarBtnRight' src='" + property.imagefolder + "public/js/skin/default/images/sr.gif' /></div><table border=0 cellpadding=0 cellspacing=0 class='gScrollbarHorizonItem' onselectstart='return false'><tr><td align='left'><img src='" + property.imagefolder + "public/js/skin/default/images/sh_left.gif' /></td><td align='right'><img src='" + property.imagefolder + "public/js/skin/default/images/sh_right.gif' /></td></tr></table>";
                var scrollbarVertical = "<div class='gScrollbarVertical' onselectstart='return false'><img class='gScrollbarBtnUp' src='" + property.imagefolder + "public/js/skin/default/images/su.gif' /><img class='gScrollbarBtnDown' src='" + property.imagefolder + "public/js/skin/default/images/sd.gif' /></div><table border=0 cellpadding=0 cellspacing=0 class='gScrollbarVerticalItem' onselectstart='return false'><tr><td valign='top'><img src='" + property.imagefolder + "public/js/skin/default/images/sv_up.gif' /></td></tr><tr><td valign='bottom'><img src='" + property.imagefolder + "public/js/skin/default/images/sv_down.gif' /></td></tr></table>";
                
                $(table_parent).find("td:eq(1)").html(scrollbarVertical);
                $(table_parent).find("td:eq(0)").append(table);
                $(table).after(scrollbarHorizon);
                
                var row = property.fixedrow + property.visiblerow;
                
                for(var i=row; i<property.totalrow; i++)
                {
                    this.toggleRow(i);
                }
                
                $(table).find("tr").attr("height", property.rowheight);
                $(table).find("tr:lt(" + property.fixedrow + ")").css("background-color", "#ccc").css("text-align", "center").find("td").css("font-weight", "bold");
                $(table).find("tr:gt(" + (property.fixedrow-1) + ")").find("td:eq(0)").css("background-color", "#ccc").css("font-weight", "bold");
                
                
                if(property.fixedrow>0)
                {
                    $(table).find("tr:lt(" + property.fixedrow + ") td").attr("colindex", 0);
                    
                    for(var i=0; i<property.fixedrow; i++)
                    {
                        var colindex = 0;
                        var tr = $(table).find("tr:eq(" + i + ")");
                        tr.find("td").each(function() {
                            $(this).attr("colindex", parseInt($(this).attr("colindex")) + colindex);
                            var colspan = parseInt($(this).attr("colspan"));
                            if(isNaN(colspan))
                            {
                                colspan = 1;
                            }
                                                        
                            colindex += colspan;
                        });
                    }
                    
                    for(var i=0; i<property.fixedrow; i++)
                    {
                        var tr = $(table).find("tr:eq(" + i + ")");
                        
                        var colindex = 0;
                        tr.find("td").each(function() {
                            if($(this).attr("rowspan")>1)
                            {
                                var td_index = parseInt($(this).attr("colindex"));
                                
                                var colspan = parseInt($(this).attr("colspan"));
                                if(isNaN(colspan))
                                {
                                    colspan = 1;
                                }
                                
                                for(var j=i+1; j<i+$(this).attr("rowspan") && j<property.fixedrow; j++)
                                {
                                    $(table).find("tr:eq(" + j + ")").find("td").each(function() {
                                        if(parseInt($(this).attr("colindex")) >= td_index)
                                        {
                                            $(this).attr("colindex", parseInt($(this).attr("colindex")) + colspan);
                                        }
                                    });
                                }
                            }
                        });                                                
                    }
                }
                
                //$(table).find("tr:lt(" + property.fixedrow + ") td").each(function() {
                //    $(this).html($(this).html() + ":" + $(this).attr("colindex"));
                //});
                
                //return;
                
                //$(table).find("tr:lt(" + property.fixedrow + ")").find("td[rowspan=1]").addClass("fixedrow");     
                //$(table).find("tr:lt(" + property.fixedrow + ")").find("td[rowspan!=1]").addClass("fixedrow2");     
                
                var column = property.fixedcolumn + property.visiblecolumn;
                for(var i=column; i<property.totalcolumn; i++)
                {
                    this.toggleColumn(i);
                }
                
                this.calculateScroll();
                
                $(table_parent).find(".gScrollbarBtnLeft").mousedown(function(){
                    window.clearInterval(_bigrid_interval);
                    _bigrid_interval = window.setInterval(function(){
                        grid.doScroll("Left");
                    }, _bigrid_timeinterval);
					
					return false;
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                })
                .click(function(){
                    grid.doScroll("Left");
                    
                    return false;
                });

                $(table_parent).find(".gScrollbarBtnRight").mousedown(function(){
                    window.clearInterval(_bigrid_interval);
                    _bigrid_interval = window.setInterval(function(){
                        grid.doScroll("Right");
                    }, _bigrid_timeinterval);
					
					return false;
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                })
                .click(function(){
                    grid.doScroll("Right");
                    
                    return false;
                });
                
                $(table_parent).find(".gScrollbarBtnUp").mousedown(function(){
                    window.clearInterval(_bigrid_interval);
                    _bigrid_interval = window.setInterval(function(){
                        grid.doScroll("Up");
                    }, _bigrid_timeinterval);
					
					return false;
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                })
                .click(function(){
                    grid.doScroll("Up");
                    
                    return false;
                });

                $(table_parent).find(".gScrollbarBtnDown").mousedown(function(){
                    window.clearInterval(_bigrid_interval);
                    _bigrid_interval = window.setInterval(function(){
                        grid.doScroll("Down");
                    }, _bigrid_timeinterval);
					
					return false;
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                })
                .click(function(){
                    grid.doScroll("Down");
                    
                    return false;
                });

                $(table_parent).find(".gScrollbarHorizon").mousedown(function(e){
                    window.clearInterval(_bigrid_interval);

					_bigrid_interval = window.setInterval(function(){
						grid.moveScrollHorizon(e);
					}, _bigrid_timeinterval);
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                }).click(function(e){
					grid.moveScrollHorizon(e);
                });

                $(table_parent).find(".gScrollbarVertical").mousedown(function(e){
                    window.clearInterval(_bigrid_interval);

					_bigrid_interval = window.setInterval(function(){
						grid.moveScrollVertical(e);
					}, _bigrid_timeinterval);
                })
                .mouseup(function(){
                    window.clearInterval(_bigrid_interval);
                }).click(function(e){
                    grid.moveScrollVertical(e);
                });
                
                $(window).mouseup(function(){
                    _bigrid_moving = null;
					window.clearInterval(_bigrid_interval);
                }).mousemove(function(){
					
				});
                
                $(table_parent).find(".gScrollbarHorizonItem").mousedown(function(e){
                    _bigrid_x = e.pageX;
                    _bigrid_moving = $(this);
                })
                .mousemove(function(e){
                    if(_bigrid_moving!=null)
                    {
                        var table_parent = _bigrid_moving.parent().parent().parent().parent();
                        
                        var btn_right = $(table_parent).find(".gScrollbarBtnRight"); 
                        var width = parseInt(btn_right.css("width"));
                    
	                    var x = e.pageX - _bigrid_x;
	                    
	                    _bigrid_x = e.pageX;

                        var max_width = width + (property.totalcolumn - property.fixedcolumn - property.visiblecolumn) * (parseInt($(table).width()) - 2 * width) / (property.totalcolumn - property.fixedcolumn);
	                    
	                    max_width = parseInt(max_width);
	                    
	                    var left = parseInt($(this).css("left")) + x;
	                    
	                    if(left<width) return ;
	                    if(left>max_width) return; 
	                    
                        var index = 1 + Math.round((left - width) * (property.totalcolumn - property.fixedcolumn) / (1.0*(parseInt($(table).width()) - 2*width)));
                        
                        if(index < property.startcolumn){
                            grid.doScroll("Left");
                        }
                        else if(index > property.startcolumn)
                        {
                            grid.doScroll("Right");
                        }
	                    
	                    $(this).css("left", left);
                    }
                });

                $(table_parent).find(".gScrollbarVerticalItem").mousedown(function(e){
                    _bigrid_y = e.pageY;
                    _bigrid_moving = $(this);
                })
                .mousemove(function(e){
                    if(_bigrid_moving!=null)
                    {
                        var table_parent = _bigrid_moving.parent().parent().parent().parent();
                        
                        var btn_down = $(table_parent).find(".gScrollbarBtnDown"); 
                        var height = parseInt(btn_down.css("height"));
                    
	                    var y = e.pageY - _bigrid_y;
	                    
	                    _bigrid_y = e.pageY;

                        var max_height = height - $(table).height() + (property.totalrow - property.fixedrow - property.visiblerow) * (parseInt($(table).height()) - 2*height) / (property.totalrow - property.fixedrow);
                        
                        max_height = parseInt(max_height);
	                    
	                    var top = parseInt($(this).css("top")) + y;
	                    	                    
	                    if(top<height - parseInt($(table).height())) return ;
	                    if(top>max_height) return; 
	                    
                        var index = 1 + Math.round((top - height + parseInt($(table).height())) * (property.totalrow - property.fixedrow) / (parseInt($(table).height()) - 2*height));// + parseInt((left - width) * (property.totalcolumn - property.fixedcolumn) / (parseInt($(table).width()) - 2*width));
                        
                        if(index < property.startrow){
                            grid.doScroll("Up");
                        }
                        else if(index > property.startrow)
                        {
                            grid.doScroll("Down");
                        }
                        	                    
	                    $(this).css("top", top);
                    }
                });

                $(table).width($(table).width());
            },
            
            moveScrollHorizon : function(e){
                    var table_parent = $(table).parent().parent().parent().parent();
                    
                    var btn_right = $(table_parent).find(".gScrollbarBtnRight"); 
                    var width = parseInt(btn_right.css("width"));
                    
	                var x = e.pageX - $(table_parent).find(".gScrollbarHorizon").position().left;
                    var left = parseInt(table_parent.find(".gScrollbarHorizonItem").css("left"));
                    
                    var bar_width = parseInt(table_parent.find(".gScrollbarHorizonItem").css("width"));
                    
                    if(x<left && x>width)
                    {
                        grid.doScroll("Left");
                    }
                    else if(x>left + bar_width && x<parseInt($(table).width()) - width)
                    {
                        grid.doScroll("Right");
					}
			},
			
			moveScrollVertical : function(e){
                    var table_parent = $(table).parent().parent().parent().parent();
                    
                    var btn_down = $(table_parent).find(".gScrollbarBtnDown");
                    var height = parseInt(btn_down.css("height"));
                    
	                var y = e.pageY - $(table_parent).find(".gScrollbarVertical").position().top;
                    var top = parseInt(table_parent.find(".gScrollbarVerticalItem").css("top")) + parseInt(table_parent.find(".gScrollbarVertical").height());
                                        
                    var bar_height = parseInt(table_parent.find(".gScrollbarVerticalItem").css("height"));
                    
                    if(y<top && y>height)
                    {
                        grid.doScroll("Up");
                    }
                    else if(y>top + bar_height && y<parseInt(table_parent.find(".gScrollbarVertical").height()) - height)
                    {
                        grid.doScroll("Down");
                    }
			},
            
            calculateScroll : function() {
                var table_parent = $(table).parent().parent().parent().parent();                
                
                if(property.totalcolumn - property.visiblecolumn - property.fixedcolumn > 0)
                {
                    var btn_right = $(table_parent).find(".gScrollbarBtnRight");                
                    var width = parseInt($(table).width()) - 2 * parseInt(btn_right.css("width"));

                    btn_right.css("left", width);
                                                         
                    width = width - parseInt((property.totalcolumn - property.fixedcolumn - property.visiblecolumn) * width / (property.totalcolumn - property.fixedcolumn));
                    
                    //width = width * property.visiblecolumn / (property.totalcolumn - property.fixedcolumn);
                    
                    //width = parseInt(width);
                                                                                
                    $(table_parent).find(".gScrollbarHorizonItem").css("width", width);
                
                    this.positionScrollbarHorizon();
                }
                else {
                    $(table_parent).find(".gScrollbarHorizon").hide();
                    $(table_parent).find(".gScrollbarHorizonItem").hide();
                }
                
                if(property.totalrow - property.visiblerow - property.fixedrow > 0)
                {
                    table_parent.find(".gScrollbarVertical").css("height", $(table).height());
                    
                    var btn_down = $(table_parent).find(".gScrollbarBtnDown");
                    var height = parseInt($(table).height()) - 2 * parseInt(btn_down.css("height"));
                    
                    btn_down.css("top", height);

                    height = height * property.visiblerow / (property.totalrow - property.fixedrow);
                    
                    height = parseInt(height);  
                    $(table_parent).find(".gScrollbarVerticalItem").css("height", height);
                    
                    this.positionScrollbarVertical();
                }
                else{
                    $(table_parent).find(".gScrollbarVertical").hide();
                    $(table_parent).find(".gScrollbarVerticalItem").hide();
                }
            },
            
            positionScrollbarHorizon : function(){                
                var parent = $(table).parent().parent().parent();

                var btn_right = parent.find(".gScrollbarBtnRight");
                
                var width = parseInt(btn_right.css("width"));

                var left = (property.startcolumn - 1 ) * ($(table).width() - 2*width) / (property.totalcolumn - property.fixedcolumn);                                                        
                
                left = parseInt(left);
                
                parent.find(".gScrollbarHorizonItem").css("left", width + left);
            },
            
            positionScrollbarVertical : function(){                
                var parent = $(table).parent().parent().parent();

                var btn_down = parent.find(".gScrollbarBtnDown");
                
                var height = parseInt(btn_down.css("height"));

                var top = (property.startrow - 1 ) * ($(table).height() - 2*height) / (property.totalrow - property.fixedrow);                                                        
                
                top = top - $(table).height();
                
                top = parseInt(top);
                                
                parent.find(".gScrollbarVerticalItem").css("top", top + height);
            },

            doScroll : function(type) {
                switch(type)
                {
                    case "Left":
                        if(property.startcolumn>1)
                        {
                            property.startcolumn --;    
                            this.toggleColumn(property.startcolumn + property.fixedcolumn - 1);
                            this.toggleColumn(property.startcolumn + property.visiblecolumn + property.fixedcolumn - 1);

                            this.positionScrollbarHorizon();
                         }
                        break;
                                
                    case "Right":
                        if(property.startcolumn<=property.totalcolumn - property.visiblecolumn - property.fixedcolumn)
                        {
                            this.toggleColumn(property.startcolumn + property.fixedcolumn - 1);
                            this.toggleColumn(property.startcolumn + property.visiblecolumn + property.fixedcolumn - 1);

                            property.startcolumn ++;
                            
                            this.positionScrollbarHorizon();                            
                        }
                        break;
                    
                    case "Up":
                        if(property.startrow>1)
                        {
                            property.startrow --;    
                            this.toggleRow(property.startrow + property.fixedrow - 1);
                            this.toggleRow(property.startrow + property.visiblerow + property.fixedrow - 1);

                            this.positionScrollbarVertical();
                         }
                        break;
                    
                    case "Down":
                        if(property.startrow<=property.totalrow - property.visiblerow - property.fixedrow)
                        {
                            this.toggleRow(property.startrow + property.fixedrow - 1);
                            this.toggleRow(property.startrow + property.visiblerow + property.fixedrow - 1);

                            property.startrow ++;
                            
                            this.positionScrollbarVertical();                            
                        }
                        break;
                }
            },  // End scroll functions
            
            toggleRow : function(index) {
                $(table).find("tr:eq(" + index + ")").toggle();
            },
            
            toggleColumn : function(index) {
                var td = $(table).find("tr:eq(0)").find("td:eq(" + index + ")");
                var colspan = parseInt(td.attr("colspan"));
                if(isNaN(colspan))
                {
                    colspan = 1;
                }

                var colspan1 = parseInt(td.attr("colindex"));
                var colspan2 = colspan1 + colspan;
                                
                var row = property.fixedrow - 1;
                
                for(var i=colspan1; i<colspan2; i++)
                {
                    $(table).find("tr:gt(" + row + ")").find("td:eq(" + i + ")").toggle();
                }
                                
                for(var i=0; i<property.fixedrow; i++)
                {
                    var tr = $(table).find("tr:eq(" + i + ")");
                    
                    tr.find("td").each(function() {
                        var colindex = parseInt($(this).attr("colindex"));
                        
                        if(colindex>=colspan1 && colindex<colspan2)
                        {
                            $(this).toggle();
                        }
                    });
                }

            }                                                
        };
        
        if(!property.initbyajax){   // the table includes data
            property.totalrow = $(table).find("tr").length;
            property.totalcolumn = $(table).find("tr:eq(0)").children().length;
            
            if(property.visiblerow==-1) property.visiblerow = property.totalrow - property.fixedrow;
            if(property.visiblecolumn==-1) property.visiblecolumn = property.totalcolumn - property.fixedcolumn;
        }
        else{   // init data by ajax first, but the header must be included in the original table
        }

        grid.prepareScroll();
        
        table.grid = grid;
            
    };

	var _bigrid_docloaded = false;
	$(document).ready(function() { _bigrid_docloaded = true; } );

    // bigrid start
	$.fn.bigrid = function(property){

		return this.each(function(){
				if (!_bigrid_docloaded)
				{
					//$(this).hide();
					var table = this;
					$(document).ready
					(
						function()
						{
						$.init_biGrid(table, property);
						}
					);
				} else {
					$.init_biGrid(this, property);
				}
			});

	}; //bigrid end

})(jQuery);
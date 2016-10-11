//费用统计
$(document).ready(function () { 
      //监听表格实现表头下拉滚动
    addTableListener(document.getElementById("tBoxs"), 0, 0);
    window.onscroll = function () {
        var t = document.body.getBoundingClientRect().top;

        var head = document.getElementById("title_space");
        if ((t + document.getElementById("space").offsetTop) < 0) {

            head.style.position = "absolute";
            document.getElementById("title_space").style.top = (-t) + "px";
        }
        else {
            head.style.position = "";
        }
    }
   

     //选择改变时
    $("#tjType").change(function () {
        $("#get_tree_Node").empty();
        var getTjType = $("#tjType").children('option:selected').val();

        if (getTjType == 0) {
            $(".category_val").remove();
            $("#className").remove();
            $("#direction").remove();
            $("#classN").remove();
            $("#kDirection").remove();
            var boardDiv = "<select class='Maori_val' style='width:50%'><option value='0'>区域</option><option value='1'>客户</option><option value='2'>业务员</option><option value='3'>品牌</option> <option value='4'>单品</option></select>";
            $("#getType").append(boardDiv);

            var xType="<span id='xType'>销售类型：</span><select id='saleType' style='width:20%'><option value='0'>购销</option><option value='1'>联营</option><option value='2'>直销</option></select>"
                       
        }
        if (getTjType == 1) {
            $(".Maori_val").remove();
            $("#xType").remove();
            $("#saleType").remove();
            var boardDiv = "<select class='category_val' style='width:50%'><option value='0'>客户</option><option value='1'>科目</option><option value='2'>业务员</option><option value='3'>赠品</option></select>";
            $("#getType").append(boardDiv);
                        
            var kTypeDiv="<span id='classN'>科目选择：</span><input type='text' id='className' name='className' style='width:120px;' /><span id='kDirection'>&nbsp;&nbsp;&nbsp;借贷方向：</span><select id='direction'><option value='0'>借方</option> <option value='1'>贷方</option></select>";
            $("#classType").append(kTypeDiv);
                      
        }
    });

    $(".category_val").live("change",function(){
        var getType=$(".category_val").children('option:selected').val();
        if(getType==0)
        {
            $("#className").remove();
            $("#direction").remove();
            $("#classN").remove();
            $("#kDirection").remove();
            var kTypeDiv="<span id='classN'>科目选择：</span><input type='text' id='className' name='className' style='width:120px;' /><span id='kDirection'>&nbsp;&nbsp;&nbsp;借贷方向：</span><select id='direction'><option value='0'>借方</option> <option value='1'>贷方</option></select>";
            $("#classType").append(kTypeDiv);
        }
        if(getType==1)
        {
            $("#className").remove();
            $("#direction").remove();
            $("#classN").remove();
            $("#kDirection").remove();
            var kTypeDiv="<span id='classN'>科目选择：</span><input type='text' id='className' name='className' style='width:120px;' /><span id='kDirection'>&nbsp;&nbsp;&nbsp;借贷方向：</span><select id='direction'><option value='0'>借方</option> <option value='1'>贷方</option></select>";
            $("#classType").append(kTypeDiv);
        }
        if(getType==2)
        {
            $("#className").remove();
            $("#direction").remove();
            $("#classN").remove();
            $("#kDirection").remove();
            var kTypeDiv="<span id='classN'>科目选择：</span><input type='text' id='className' name='className' style='width:120px;' /><span id='kDirection'>&nbsp;&nbsp;&nbsp;借贷方向：</span><select id='direction'><option value='0'>借方</option> <option value='1'>贷方</option></select>";
            $("#classType").append(kTypeDiv);
        }
        if(getType==3)
        {
        $("#className").remove();
        $("#direction").remove();
        $("#classN").remove();
        $("#kDirection").remove();
        }
    });

     //点击出现科目
        $("#className").live("click",function(){
            var get_tjType= $("#tjType").children('option:selected').val();
            if(get_tjType==1)
            {
                $("#winType").fadeIn("slow");  
                $("#winbody").fadeIn("slow");
            }
        });

        //关闭弹窗
        $("#winClose").click(function () {
            $("#winType").fadeOut("slow");
        });
        $("#res_btn").click(function(){
            $("#winType").fadeOut("slow");
        });
        //提交页面
        $("#tbn_submit").click(function () {
                    
            //获得日期选择
            var bDate = $("#sDate").val();
            var eDate = $("#stDate").val();

            //将统计类型选择获取到input中
            $("#tType").val($("#tjType").children('option:selected').val());   //统计类型 ：毛利或费用
            $("#feeType").val($(".category_val").children('option:selected').val());//费用统计类别
            $("#moriType").val($(".Maori_val").children('option:selected').val());//毛利统计类别
            $("#get_direction").val($("#direction").children('option:selected').val());//借贷方向
            $("#maori_ID").val($("#saleType").children('option:selected').val());//毛利销售类型
            var getClass=$("#className").val();
            var gettType=$("#tjType").children('option:selected').val();
            var getGift=$(".category_val").children('option:selected').val();
            var cookie_className_val=$("#cookie_className").val();
            var get_treeNode=$("#get_treeNode").val();
            if (bDate <= eDate) {
                if(gettType==0)
                {
                    $("div#winAll").fadeIn("slow");
                    $("#bForm").submit();
                }
                if(gettType==1)
                {
                    if(getGift==3)
                    {
                        $("div#winAll").fadeIn("slow");
                        $("#bForm").submit();
                    }
                    else
                    {
                        if(getClass !='')
                        {
                            if(get_treeNode !='')
                            {
                                $("div#winAll").fadeIn("slow");
                                $("#bForm").submit();
                            }
                            else
                            {
                                document.getElementById("get_treeNode").value=cookie_className_val;
                                $("div#winAll").fadeIn("slow");
                                $("#bForm").submit();
                            }
                        }
                        else
                        {
                            jAlert("请选择科目！", "友情提示");
                        }
                    }
                }
            }
            else {
                jAlert("日期选择错误，请重新选择", "友情提示");
            }
        });


      //科目选择点击确定
         $("#win_btn").click(function(){
          $("#get_tree_Node").empty();
          var getTreeNode = $("#trTree").jstree('get_checked');
          
          var ids = "";
          for (i = 0; i < getTreeNode.size(); i++) {
             ids+=getTreeNode[i].id.replace('t_', '')+',';
             var sName = $("#trTree").jstree('get_text');
           }
            if (ids == "") {
            jAlert("请选择科目！", "友情提示");
            }
            else {
             $("#winType").fadeOut("slow");
             $("#get_treeNode").val(ids);
             $("#className").val(sName);
            }
         });

                //科目树
        $("#trTree").jstree({   
         "json_data":{"ajax":{
			"url":"/Services/CAjax.aspx",
			"data" : function (n) {
						return { 
							"do" : "DataClass",
							"doValue" : "select",
							"DataType" : "FeesSubjectClass",
							"NOCaches":0,
							"pid" : n.attr ? n.attr("id").replace("t_","") : -1
						};}
		 }}, 
		 "core" : { 
				"initially_open" : [ "t_0" ]
			},	
		"ui":{},
		"lang":{     
                 loading : "加载中……"    
             },

         "plugins" : [ "themes", "json_data", "ui", "crrm", "types","dnd", "hotkeys","dnd", "contextmenu","cCode","checkbox","data" ]
         
     });

      //导出数据
    $("#export_data").click(function(){
            var tjType=$("#tjType").children('option:selected').val();
            var bDate=$("#sDate").val();
            var eDate=$("#stDate").val();
            //毛利统计
            if(tjType==0)
            {
                var _url='/cost_details.aspx?Act=act&bDate='+bDate+'&eDate='+eDate+'&mType='+$(".Maori_val").children('option:selected').val()+'&tType='+tjType; 
                window.open('',"top");
                setTimeout(window.open(_url,"top"),100);
            }
            if(tjType==1)
            {
            var feeType=$(".category_val").children('option:selected').val();
            var get_treeNode=$("#cookie_className").val();
            var direction=$("#direction").children('option:selected').val();
                var _url='/cost_details.aspx?Act=act&bDate='+bDate+'&eDate='+eDate+'&feeType='+feeType+'&get_treeNode='+get_treeNode+'&get_direction='+direction+'&tType='+tjType;
            if(feeType==3)
            {
                window.open('',"top");
                setTimeout(window.open(_url,"top"),100);
            }
            else
            {
                if(get_treeNode !='')
                {
                    window.open('',"top");
                    setTimeout(window.open(_url,"top"),100);
                }
                else
                {
                    jAlert("请重新选择科目再导出数据","友情提示");
                }
            }
            }
                  
    });

});

    //门店费用详情    
    function sendInFo(sID,aID,bDate,eDate,sName,sType,kID) {
            if (document.all) {
                this.dw = $(document).width() - 100;
                this.dh = $(window).height() - 100;
            }
            else {
                this.dw = $(document).width() - 100 + 'px';
                this.dh = $(window).height() - 100 + 'px';
            }
            this.PageBox = dialog("门店费用详情", 'iframe:/cost_details_storehouse.aspx?sid=' + sID + '&aid=' + aID + '&bDate=' + bDate + '&eDate='+eDate+'&sName=' + sName + '&sType='+sType+'&kID='+kID, this.dw, this.dh, "iframe", '');
        }
    //科目费用详情
    function sendInFoClass(aID,bDate,eDate,className,kID) {
        if (document.all) {
            this.dw = $(document).width() - 100;
            this.dh = $(window).height() - 100;
        }
        else {
            this.dw = $(document).width() - 100 + 'px';
            this.dh = $(window).height() - 100 + 'px';
        }
        this.PageBox = dialog("门店费用详情", 'iframe:/cost_class_details.aspx?aid=' + aID + '&bDate=' + bDate + '&eDate='+eDate+'&className=' + className + '&kID='+kID, this.dw, this.dh, "iframe", '');
    }
    //业务员费用详情
    function sendInFoStaff(aID,bDate,eDate,staffName,kID,staffID) {
        if (document.all) {
            this.dw = $(document).width() - 100;
            this.dh = $(window).height() - 100;
        }
        else {
            this.dw = $(document).width() - 100 + 'px';
            this.dh = $(window).height() - 100 + 'px';
        }
        this.PageBox = dialog("业务费用详情", 'iframe:/cost_details_staff.aspx?aid=' + aID + '&bDate=' + bDate + '&eDate='+eDate+'&staffName=' + staffName + '&kID='+ kID +'&staffID='+staffID, this.dw, this.dh, "iframe", '');
    }
    //赠品费用详细
    function sendInFoGifts(sid,sname,pid,pname,pbarcode,bDate,eDate) {
        if (document.all) {
            this.dw = $(document).width() - 100;
            this.dh = $(window).height() - 100;
        }
        else {
            this.dw = $(document).width() - 100 + 'px';
            this.dh = $(window).height() - 100 + 'px';
        }
        this.PageBox = dialog("业务费用详情", 'iframe:/cost_details_gifts.aspx?sid=' + sid +'&sname='+sname+'&pid='+pid+'&pname='+pname+'&pbarcode='+pbarcode+ '&bDate=' + bDate + '&eDate='+eDate, this.dw, this.dh, "iframe", '');
    }

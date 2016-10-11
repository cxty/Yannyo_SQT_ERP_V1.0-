var divValue = "";
var divTitle = "";
var ckName = ""; //每次点击保存Name
var text_attr = ""; //文本重组
var selectType;

$(document).ready(function () {
    //0.鼠标移动改变背景
    $("#sRegion").mouseover(function () {
        $(this).attr("style", "background:lightblue");
    });
    $("#sRegion").mouseout(function () {
        $(this).attr("style", "background:#EDEDED");
    });
    $("#sCustorm").mouseover(function () {
        $(this).attr("style", "background:lightblue");
    });
    $("#sCustorm").mouseout(function () {
        $(this).attr("style", "background:#EDEDED");
    });
    $("#sProduct").mouseover(function () {
        $(this).attr("style", "background:lightblue");
    });
    $("#sProduct").mouseout(function () {
        $(this).attr("style", "background:#EDEDED");
    }); 
    //1.数据比较选择
    $("#DataCompare").click(function () {
        $("#showSelect").slideToggle("slow");
    });

    //2.提交页面
    $("#submit_btn").click(function () {
        var get_graphType = $("#graph_Type").val();
        if (get_graphType == 0) {
            $("#winAll").fadeIn("slow");
            getJsonToGchar("line", $("#regionID").val(), selectType, text_attr.substring(0, text_attr.length - 1));
        }
        if (get_graphType == 1) {
            $("#winAll").fadeIn("slow");
            getJsonToGchar("column", $("#regionID").val(), selectType, text_attr.substring(0, text_attr.length - 1));
        }
    });
    //3.选择区域查询对比
    $("#sRegion").click(function () {
        $("div#winType").fadeIn("slow");
        selectType = 0;
        document.getElementById("sTitle").innerHTML = "";
        document.getElementById("sTitle").innerHTML = "<b>区域选择</b>"
        getdoValue("region");
    });

    //选择客户对比
    $("#sCustorm").click(function () {
        $("div#winType").fadeIn("slow");
        selectType = 1;
        document.getElementById("sTitle").innerHTML = "";
        document.getElementById("sTitle").innerHTML = "<b>客户选择</b>"
        getdoValue("custorm");
    });
    //选择商品对比
    $("#sProduct").click(function () {
        $("div#winType").fadeIn("slow");
        selectType = 2;
        document.getElementById("sTitle").innerHTML = "";
        document.getElementById("sTitle").innerHTML = "<b>商品选择</b>"
        getdoValue("product");
    });

    //4.关闭选择
    $("#winClose").click(function () {
        $("#winType").fadeOut("slow");
    });
    $("#res_btn").click(function () {
        $("#winType").fadeOut("slow");
    });


    //区域分类选择点击确定
    $("#win_btn").click(function () {
        var getTreeNode = $("#treeNode").jstree('get_checked');
        var ids_array = [];
        var ids = "";
        //数字重组
        var num = "";
        var text = "";
        for (i = 0; i < getTreeNode.size(); i++) {
            //包含ID和Name
            ids += getTreeNode[i].id.replace('t_', '') + ',';
        }
        if (ids == "") {
            jAlert("请选择区域！", "友情提示");
        }
        else {
            //拆分为ID和Name
            ids_array = ids.split(',');
            for (var i = 0; i < ids_array.length - 1; i++) {
                if (ids_array[i].match("^[0-9]+$")) {
                    num += ids_array[i] + ",";
                }
                else {
                    text += ids_array[i] + "：";
                    text_attr = text;
                }
            }
            //重新将num组成数组
            var num_array = [];
            num_array = num.split(',');
            if (num_array.length - 1 > 3) {
                jAlert("至多同时选择3个数据进行分析！", "友情提示");
            }
            else {
                $("#regionID").val(num);
                $("#SalesType").val($("#tType").children('option:selected').val());
                $("#winType").fadeOut("slow");
                $("#DataCompare").val(text.substring(0, text.length - 1));
            }
        }
    });
    //图表类型选择
    $("#graphType").change(function () {
        var get_graphType = $("#graphType").children('option:selected').val();
        $("#graph_Type").val(get_graphType);
        if (get_graphType == 0) {
            $("#winAll").fadeIn("slow");
            getJsonToGchar("line", $("#regionID").val(), selectType, text_attr.substring(0, text_attr.length - 1));
        }
        if (get_graphType == 1) {
            $("#winAll").fadeIn("slow");
            getJsonToGchar("column", $("#regionID").val(), selectType, text_attr.substring(0, text_attr.length - 1));
        }
    });
});
//树
function getdoValue(doValue) {
    $("#treeNode").jstree({
        "json_data": { "ajax": {
            "url": "/products_sales_details.aspx",
            "data": function (n) {
                return {
                    "doValue": doValue,
                    "pid": n.attr ? n.attr("id").replace("t_", "") : -1
                };
            }
        }
        },
        "core": {
            "initially_open": ["t_0"]
        },
        "ui": {},
        "lang": {
            loading: "加载中……"
        },

        "plugins": ["themes", "json_data", "ui", "crrm", "types", "dnd", "hotkeys", "dnd", "contextmenu", "cCode", "checkbox", "data"]

    });
}
//画图表 
function getJsonToGchar(gcharType, regionID, sType, sName) {
    $.post('/products_sales_details.aspx?Act=go' + '&SalesType=' + $("#tType").children('option:selected').val() + '&bDate=' + $("#bDate").val() + '&regionID=' + regionID + '&sType=' + sType + '&sName=' + sName, '', function (data) {
        if (data != '') {
            var arrayTime = []; //日期
            var arrayData = []; //金额

            var dobSalesType;   //销售类型
            var chartTitle;     //图表标题
            var jcount;         //判断是否有选择区域
            var mDate = "";     //获得标题
            var unit;           //获得单位
            var dateType = "";  //日期类型
            var yTitle = ""; //Y轴
            var tTitle = ""; //显示tooltip
            var dFunction = "";

            //解析成功返回json格式
            var dataObj = eval("(" + data + ")");

            arrayData = dataObj.cDetails.salesMoney;
            arrayTime = dataObj.cDetails.time.split(',');     //日期
            dobSalesType = dataObj.cDetails.SalesType;        //销售类型
            jcount = dataObj.cDetails.jcount;
            mDate = dataObj.cDetails.mDate;
            unit = dataObj.cDetails.unit;
            if (mDate != '') {
                document.getElementById("showDate").innerHTML = "";
                document.getElementById("showDate").innerHTML = mDate;
            }
            if (unit == 0) {
                document.getElementById("unit").innerHTML = "";
                document.getElementById("unit").innerHTML = "[单位：元/日]";
                dateType = "日";
            }
            if (unit == 1) {
                document.getElementById("unit").innerHTML = "";
                document.getElementById("unit").innerHTML = "[单位：元/月]";
                dateType = "月";
            }
            if (unit == 0 && sType == 2) {
                document.getElementById("unit").innerHTML = "";
                document.getElementById("unit").innerHTML = "[单位：瓶(件)/日]";
                dateType = "日";
            }
            if (unit == 1 && sType == 2) {
                document.getElementById("unit").innerHTML = "";
                document.getElementById("unit").innerHTML = "[单位：瓶(件)/月]";
                dateType = "月";
            }
            //标题变更
            if (dobSalesType == '0') {
                chartTitle = '购销日销售额';
            }
            else {
                chartTitle = '购销月销售额';
            }

            if (dobSalesType == '0' && sType == 2) {
                chartTitle = '购销日销售数量';
            }
            if (dobSalesType != '0' && sType == 2) {
                chartTitle = '购销月销售数量';
            }

            if (sType == 2) {
                yTitle = "销售数量";
                tTitle = "：";
                //dFunction=
            }
            else {
                yTitle = "销售额";
                tTitle = "：￥";
            }
            //画图
            var chart;
            chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'graph',          //放置图表的容器
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    defaultSeriesType: gcharType//column
                },
                title: {
                    text: chartTitle    //标题
                },
                /*
                subtitle: {
                text: '副标题'
                },*/
                xAxis: {
                    minPadding: 0.05,
                    maxPadding: 0.05,
                    categories: arrayTime, //X轴数据
                    labels: {
                        rotation: 0,    //字体倾斜
                        align: 'right',
                        style: { font: 'normal 13px 宋体' }
                    }

                },
                yAxis: {//Y轴显示文字
                    title: {
                        text: yTitle
                    }
                },

                tooltip: {
                    backgroundColor: '#F8F8FF',
                    borderColor: '#36648B',
                    padding: 10,
                    fontWeight: 'bold',
                    style: {
                        fontSize: '11pt',
                        padding: 5
                    },
                    enabled: true,
//                    formatter:function () {
//                        return '<b>' + this.x + dateType + '</b><br/>' + this.series.name + tTitle + Highcharts.numberFormat(this.y, 0);
//                    },
                    shadow: true
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true//是否显示title
                    }
                },
                series: arrayData
            });

            $("#winAll").fadeOut("slow");
        }
    });
}
//失去焦点隐藏
function hide() {
    $("#showSelect").slideToggle("slow");
}
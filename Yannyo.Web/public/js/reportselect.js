/**
*yangangol
*/
var xmlHttp;
function createXMLHTTPRequest() {
  //浏览器兼容
    if (window.ActiveXObject) {
        return new ActiveXObject("MSXML2.XMLHTTP.3.0");
    }
    else if (window.XMLHttpRequest) {
        return new XMLHttpRequest();
    }
}
//当选择区域的时候
function serch(path) {
    xmlHttp = createXMLHTTPRequest();
    var url = "report_storehousestorage.aspx?id=0&Act=act&path=" + path; //将值通过url传到服务器端
    xmlHttp.onreadystatechange = callback;
    xmlHttp.open("post", url, true);
    xmlHttp.send();
}
//回调函数通过区域找到门店
function callback() {
    var staffName = document.getElementById("staffName");
    var storageName = document.getElementById("storageName");
    if (xmlHttp.readyState == 4) {
        if (xmlHttp.status == 200) {
            var getStaffName = xmlHttp.responseText;
            var staffNameAry = getStaffName.split(",");
            var count = staffNameAry.length;
            if (count == 1) {
                staffName.options.add(new Option("选择全部", "-1"));
                storageName.length = 0;
                storageName.options.add(new Option("选择全部", "-1"));
            }
            else {
                staffName.length = 0;
                staffName.options.add(new Option("选择全部", "-1"));

                for (var i = 0; i < count - 1; i++) {
                    staffName.options.add(new Option(staffNameAry[i], staffNameAry[i]));
                }
            }
        }
    }
}
function changeOptions()
{
     var dlRname = $('#rName');
     var dlSname = document.getElementById("staffName");
     dlSname.length=0;
     if(dlRname.value==-1){
         dlSname.options.add(new Option("选择全部","-1"));
     }
     else {
         var sendData = escape(dlRname.val());
         serch(sendData);
     }
     return;
 }

//==============门店--营业员==============
 //将门店的选择的值传到服务器端
 function sendStorageInfo(rInfo,info) {
         xmlHttp = createXMLHTTPRequest();
         var url = "report_storehousestorage.aspx?id=0&Act=act&pathend=" + info + "&pathRname=" + rInfo;
         xmlHttp.onreadystatechange = getStorageNameByStaffName;
         xmlHttp.open("post", url, true);
         xmlHttp.send(null);
 }
 //通过回调函数将服务器响应的数据添加到营业员的下拉列表中
 function getStorageNameByStaffName() {
     var getStorageName = document.getElementById("storageName");
     if (xmlHttp.readyState == 4) {
         if (xmlHttp.status == 200) {
             var getstorageName = xmlHttp.responseText;
             var getStorageNameAry = getstorageName.split(",");
             var count = getStorageNameAry.length;
             getStorageName.length = 0;
             getStorageName.options.add(new Option("选择全部", "-1"));
                 for (var i = 0; i < count - 1; i++) {
                     getStorageName.options.add(new Option(getStorageNameAry[i], getStorageNameAry[i]));
                 }
             }
     }
 }
 function changeOptionsStorage() {
     var staffName = $('#staffName');
     var regionName = $('#rName');
     var getStorageName = document.getElementById("storageName");
     getStorageName.length = 0;
     if (getStorageName.value == -1) {
         getStorageName.options.add(new Option("选择全部", "-1"));
     }
     else {
         var sendInfo = escape(staffName.val());
         var sendRInfo = escape(regionName.val());
         sendStorageInfo(sendRInfo,sendInfo);
     }
 }

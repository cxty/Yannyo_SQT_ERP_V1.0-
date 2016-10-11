
function TDataImprotExport() {

}

TDataImprotExport.prototype.ini = function () {
    $('#down_bt').click(function () {
        window.open('', "top");
        var _url = (location.href.indexOf('?') > -1 ? location.href + '&Do=down' : location.href + '?Do=down');
        
        setTimeout(window.open(_url, "top"), 100);
    });
    $('#upload_bt').click(function () {
        $('#bForm').submit();
    });
};

var DataImprotExport  = new TDataImprotExport();
$(document).ready(function () {
    DataImprotExport.ini();
});

$(window).unload(function () {
    DataImprotExport = null;
});
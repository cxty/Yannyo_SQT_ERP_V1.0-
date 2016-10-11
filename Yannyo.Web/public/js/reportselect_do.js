function getListOfRegion() {
    this.PageBox = null;
    this.PageForm = null;
}
getListOfRegion.prototype.ini = function () {
    this.PageForm = document.getElementById('form1');
}
getListOfRegion.prototype.HidUserBox = function () {
    //    SysComm.HiddenPageBox(this.PageBox);
    CloseBox();
    $("#form1").animate({ opacity: "0.5" }, "normal", function () { $(this).show(); location = location; });
}
getListOfRegion.prototype.GetDataList= function (sid,sname,scode,bDate,eDate)
{
    if (document.all) {
        dw = $(document).width() - 20;
        dh = $(window).height() - 80;
    }
    else {
        dw = $(document).width() - 20 + 'px';
        dh = $(window).height() - 80 + 'px';
    }
    this.PageBox = dialog("单品地区进销存详细数据", 'iframe:reportstorageselect_do.aspx?sid=' +escape(sid) + '&sname=' +sname+ '&scode=' +escape(scode)+'&bDate='+bDate+'&eDate='+eDate, dw, dh, "iframe", 'HidBox();');
}


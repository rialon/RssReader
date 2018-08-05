/// <reference path="jquery-3.3.1.js" />

function GetData(data, status) {
    var a = data;
    alert("Data:" + data);
}

function onSuccess(data, status) {
    var a = data;
    alert("Data:" + data);
}

function AddParameters() {
    var url = $("#newsLink").prop("href");
    url = url.replace(/sourceId=\d*/, "sourceId=" + $("#sourceList").val());
    url = url.replace(/isDate=\w+/, "isDate=" + $("input:radio[name ='IsDateSorted']:checked").val());
    $("#newsLink").prop("href", url);
}

function AddNavParameters() {
    var _navLinks = $('a[name=navLink]');
    for (var i = 0; i < _navLinks.length; i++) {
        var navUrl = $(_navLinks[i]).prop("href");
        navUrl = navUrl + "&sourceId=" + $("#sourceList").val();
        navUrl = navUrl + "&isDate=" + $("input:radio[name ='IsDateSorted']:checked").val();
        $(_navLinks[i]).prop("href", navUrl);
    }
}

$(function () {
    $("#newsLink").mouseenter(AddParameters);

    $("#getBtn").click(function () {
        var sourceId = $("#sourceList").val();

        var date = $("input:radio[name ='sortRadio']:checked").val();

        var data = { SourceId: sourceId, IsDateSorted: date, SourcesList: null };

        $.ajax({
            type: "GET",
            url: '/News/ShowNews',
            data: { sourceId: sourceId == "" ? 0 : sourceId, isDate: date }
        });
    });
    //$("#showNews").click(getData);

    //function getData() {
    //    var sourceId = $("#sourceList").val();

    //    var date = $("input:radio[name ='sortRadio']:checked").val();

    //    var data = { SourceId: sourceId, IsDateSorted: date, SourcesList: null };

    //    $.ajax({
    //        type: "GET",
    //        url: '/News/ShowNews',
    //        data: { sourceId: sourceId == "" ? 0 : sourceId, isDate: date },
    //        success: successFunc,
    //        error: errorFunc
    //    });

    //    function successFunc(data, status) {
    //        alert(data);
    //    }

    //    function errorFunc(jxr, textStatus, error) {
    //        var a = 1;
    //        alert('error');
    //    }
    //}
})

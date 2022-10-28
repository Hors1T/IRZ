// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Onchange(selectObject) {
    var value = selectObject.value;
    if (value == 1) {
        document.getElementById('min').type = "date";
        document.getElementById('max').type = "date";
        $("#min").removeAttr('disabled');
        $("#max").removeAttr('disabled');
    }
    if (value == 2) {
        document.getElementById('min').type = "text";
        document.getElementById('max').type = "text";
        $("#min").removeAttr('disabled');
        $("#max").removeAttr('disabled');
    }
    if (value == 0) {
        document.getElementById('min').type = "text";
        document.getElementById('max').type = "text";  
        document.getElementById('min').disabled = "disabled";
        document.getElementById('max').disabled = "disabled";
    }


}
function Request() {
    var fromdate = new Date($("#fromdate").val());
    var todate = new Date($("#todate").val());
    var one = Math.floor(fromdate.getTime() / 1000);
    var two = Math.floor(todate.getTime() / 1000);
    var Data =
    {
        fromdate: one,
        todate: two,
        tagged: $("#tagged").val(),
    }
    if ($("#page").val() != '') {
        Data.page = $("#page").val();
    }
    if ($("#nottagged").val() != '') {
        Data.nottagged = $("#nottagged").val();
    }
    if ($("#pagesize").val() != '') {
        Data.pagesize = $("#pagesize").val();
    }
    if ($("#intitle").val() != '') {
        Data.intitle = $("#intitle").val();
    }
    if ($("#order option:selected").text() != '') {
        Data.order = $("#order option:selected").text();
    }
    if ($("#sort option:selected").text() != '') {
        Data.sort = $("#sort option:selected").text();
    }
    if ($("#min").val() != '' && document.getElementById('min').disabled != "disabled" && document.getElementById('min').type == "date") {
        var datemin = new Date($("#min").val());
        var unixmin = Math.floor(datemin.getTime() / 1000);
        Data.min = unixmin;
    }
    if ($("#min").val() != '' && document.getElementById('min').disabled != "disabled" && document.getElementById('min').type == "text") {
        Data.min = $("#min").val();
    }
    if ($("#max").val() != '' && document.getElementById('max').disabled != "disabled" && document.getElementById('max').type == "date") {
        var datemax = new Date($("#max").val());
        var unixmax = Math.floor(datemax.getTime() / 1000);
        Data.max = unixmax;
    }
    if ($("#max").val() != '' && document.getElementById('max').disabled != "disabled" && document.getElementById('max').type == "text") {
        Data.max = $("#max").val();
    }
    
    $.ajax({
        url: 'http://localhost:53706/api/values/post',
        method: 'post',
        data: {        
            post: Data
        },
        dataType:'text',
        success: function (data) {
            console.log(data);
        }
    });
}
function Get() {
    $(".tbody").empty();
    $.ajax({
        url: 'http://localhost:53706/api/values/get',
        type: 'GET',
        dataType: 'text',
        success: function (data) {
            $(data).appendTo(".tbody");
        }
    });
}
function Delete() {
    $.ajax({
        url: 'http://localhost:53706/api/values/delete',
        type: 'delete',
        success: function (data) {
            $(".tbody").empty();
        }
    });
}
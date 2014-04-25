var oTable;
var giRedraw = false;
var dataTab;
var aData;
var iframe;

function cargarDatos() {
    myApp.showPleaseWait();
    var version = QueryString.version;
    var toque = QueryString.toque;
    var datae = { 'version': version,'toque':toque };
    $.ajax({
        type: "POST",
        url: "ver_ediciones.aspx/traerEdiciones",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxGetFieldDataSucceeded,
        error: AjaxGetFieldDataFailed
    });
}

function cargarDatos2() {
    var version = QueryString.version;
    var toque = QueryString.toque;
    var datae = { 'version': version, 'toque': toque };
    $.ajax({
        type: "POST",
        url: "ver_ediciones.aspx/traerEdiciones",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxRefreshDataSucceeded,
        error: AjaxRefreshDataFailed
    });
}

function AjaxRefreshDataSucceeded(result) {
    if (result.d != "[]") {
        var jposts = result.d;
        var mensaje;
        var titulo;
        dataTab = $.parseJSON(jposts);
        oTable.fnClearTable();
        oTable.fnAddData(dataTab);
    } else {
        oTable.fnClearTable();
        message("Alert, No data found", "Partner News", "danger");
    }
}

function AjaxRefreshDataFailed(result) {
    alert(result.status + ' ' + result.statusText);
}

function AjaxGetFieldDataSucceeded(result) {
    if (result.d != "fail") {
        var jposts = result.d;
        var mensaje;
        var titulo;
        try {
            dataTab = $.parseJSON(jposts);
        } catch (exception) {
            dataTab = "error";
        }
        if (dataTab != "error") {
            $("#datatables").css("visibility", "visible");
            oTable = $('#datatables').dataTable({
                "bProcessing": true,
                "aaData": dataTab,
                "aoColumns": [{ "mDataProp": "Edition" }, { "mDataProp": "Version" }, { "mDataProp": "Touch" }, { "mDataProp": "Language" }, { "mDataProp": "View" }, { "mDataProp": "Edit" }, { "mDataProp": "Delete" }, { "mDataProp": "Publish" }],
                "sPaginationType": "bootstrap",
                "aaSorting": [[0, "asc"]],
                "bJQueryUI": true
            });
        };
        myApp.hidePleaseWait();
    } else {
        myApp.hidePleaseWait();
        message("Error.  Please contact with the administrator", "Alert", "danger");
    }
}

function AjaxGetFieldDataFailed(result) {
    myApp.hidePleaseWait();
    message("Error.  Please contact with the administrator", "Alert", "danger");
}

$(document).ready(function () {

    cargarDatos();

    $("#createEditions").click(function () {
        myApp.showPleaseWait();
        var version = QueryString.version;
        var datae = { 'Id_Version': version };
        $.ajax({
            type: "POST",
            url: "ver_ediciones.aspx/crearEdiciones",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(datae),
            dataType: "json",
            success: function () {
                myApp.hidePleaseWait();
                cargarDatos2();
                message("Editions created succesfully.", "Information", "primary");
            },
            error: function () {
                myApp.hidePleaseWait();
                message("Error.  Please contact with the administrator", "Alert", "danger");
            }
        });
    });

    $("#datatables #tbody").click(function (event) {
        $(oTable.fnSettings().aoData).each(function () {
            $(this.nTr).removeClass('row_selected');
        });
        $(event.target.parentNode).addClass('row_selected');

        var tds = $(event.target.parentNode).find("td");
        if (tds.value !== undefined) {
            var node = tds[0].childNodes[0];
            aData = node.data;
        }
    });

});
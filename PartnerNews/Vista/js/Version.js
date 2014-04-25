var oTable;
var giRedraw = false;
var dataTab;
var aData;
var iframe;

function cargarDatos() {
    myApp.showPleaseWait();
   
    $.ajax({
        type: "POST",
        url: "Version.aspx/traerVersiones",
        contentType: "application/json; charset=utf-8",
        data: "{ }",
        dataType: "json",
        success: AjaxGetFieldDataSucceeded,
        error: AjaxGetFieldDataFailed
    });
}

function cargarDatos2() {

    $.ajax({
        type: "POST",
        url: "Version.aspx/traerVersiones",
        contentType: "application/json; charset=utf-8",
        data: "{ }",
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
    if (result.d != "[]") {
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
                "aoColumns": [{ "mDataProp": "nombre" }, { "mDataProp": "Details_t1" }, { "mDataProp": "Details_t2" }],
                "sPaginationType": "bootstrap",
                "aaSorting": [[0, "asc"]],
                "bJQueryUI": true
            });
        };
        myApp.hidePleaseWait();
    } else {
        myApp.hidePleaseWait();
        message("No Requests found", "Information", "danger");
    }
}



function AjaxGetFieldDataFailed(result) {
    alert(result.status + ' ' + result.statusText);
}



function validar(obj) {
    var respuesta = 0;
    for (var i in obj) {
        if (obj[i] == null || obj[i].length < 1 || /^\s+$/.test(obj[i])) {
            respuesta = respuesta + 1;
            $("#" + i).css('background', '#E2E4FF');
        } else {
            respuesta = respuesta + 0;
            $("#" + i).css('background', '#FFF');
        }
    }
    if (respuesta === 0) {
        return true;
    } else {
        return false;
    }
}

function limpiarCampos(obj) {
    var respuesta = 0;
    for (var i in obj) {
        $("#" + i).val("");
    }
}


$(document).ready(function () {
    
    cargarDatos();

    $('#Register').click(function () {
        var formulario = getForm();
        var validado = validar(formulario);
        if (validado) {
            agregarVersion(formulario);
        } else {
            message("Please check the Mandatory fields", "Register", "danger");
        }
        return false;
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

    
    var date = new Date();
    date.setDate(date.getDate());

    $("#exit").click(function () {
        cerrarSession();
    });
});

function cerrarSession() {
    $.ajax({
        type: "POST",
        url: "service_utilidades.asmx/cerrarSession",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (resultado) {
            document.location.href = "admin.aspx";
        }
    });
    return false;
}

function validaSession() {
    $.ajax({
        type: "POST",
        url: "service_utilidades.asmx/validaSession",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (resultado) {
            if (resultado == "fail") {
                document.location.href = "admin.aspx";
            }
        }
    });
    return false;
}

function agregarVersion(formulario) {
    myApp.showPleaseWait();
    var datae = { 'mes': formulario.mes, 'anio': formulario.anio };
    $.ajax({
        type: "POST",
        url: "Version.aspx/agregarVersion",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            myApp.hidePleaseWait();
            if (resultado.d === "ok") {
                message("The Version is successfully created", "Partner News", "danger");
                limpiarCampos(formulario);
                cargarDatos2();
            } else if (resultado.d == "exist") {
                myApp.hidePleaseWait();
                message("Alert, This version already exists", "Partner News", "danger");
            } else if (resultado.d == "fail") {
                myApp.hidePleaseWait();
                message("Alert, please try again", "Partner News", "danger");
            }
        }
    });
    return false;
}

function ver_version(version, toque) {
    if (toque === 1) {
        document.location.href = "crear_articulos.aspx?version="+version+"&toque="+toque;
    }
    else {
        validarToque(version, toque);
    }
}

function validarToque(version, toque) {
    var datae = { 'version': version, 'toque': toque };
    $.ajax({
        type: "POST",
        url: "Version.aspx/validarToque",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            if (resultado.d === true) {
                document.location.href = "editar_toque2.aspx?version="+version;
            } else {
                message("Alert, please publish T1 first", "Partner News", "danger");
            }
        },
        error: function () {
            return false;
        }
    });
}


function getForm() {
    var mes = $("#month_version");
    var anio = $("#year_version");

    var formulario = new Object();
    formulario.mes = mes.val();
    formulario.anio = anio.val();
    
    return formulario;
}


var oTable;
var giRedraw = false;
var dataTab;
var aData;
var iframe;

function cargarDatos() {
    myApp.showPleaseWait();
    var version = QueryString.version;
    var datae = { 'version': version };
    $.ajax({
        type: "POST",
        url: "ver_articulos.aspx/traerArticulos",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxGetFieldDataSucceeded,
        error: AjaxGetFieldDataFailed
    });
}

function cargarDatos2() {
    var version = QueryString.version;
    var datae = { 'version': version };
    $.ajax({
        type: "POST",
        url: "ver_articulos.aspx/traerArticulos",
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
                "aoColumns": [{ "mDataProp": "titulo" }, { "mDataProp": "idioma" }, { "mDataProp": "edicion" }, { "mDataProp": "seccion" }, { "mDataProp": "top_new" }, { "mDataProp": "destacada" }, { "mDataProp": "editorial" }, { "mDataProp": "visible" }, { "mDataProp": "detalles" }, { "mDataProp": "editar" }, { "mDataProp": "borrar" }],
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

$(document).ready(function () {
    
    cargarDatos();

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

    $("#gotoNewArticle").click(function () {
        var version = QueryString.version;
        document.location.href = "crear_articulos.aspx?version=" + QueryString.version + "&toque=" + QueryString.toque;
    });

    
});

function editarArticulo(articulo) {
    var version = QueryString.version;
    document.location.href = "editar_articulos.aspx?version=" + QueryString.version + "&toque=" + QueryString.toque + "&articulo=" + articulo;
}

function detalleArticulo(articulo) {
    //myApp.showPleaseWait();
    var datae = { 'articulo': articulo };
    $.ajax({
        type: "POST",
        url: "ver_articulos.aspx/traerContenido",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxGetContenidoSucceeded,
        error: AjaxGetContenidoFailed
    });
}

function AjaxGetContenidoSucceeded(result) {
    if (result.d != "fail") {
        var item = $.parseJSON(result.d);
        $("#full-width .modal-header h4").html(item[0].titulo);
        $("#full-width .modal-body2").html(item[0].contenido);
        $('#full-width').modal('show');
        //myApp.hidePleaseWait();

    } else {
        //myApp.hidePleaseWait();
        message("No Data found", "Information", "danger");
    }
}



function AjaxGetContenidoFailed(result) {
    alert(result.status + ' ' + result.statusText);
}

function borrarArticulo(articulo) {
    BootstrapDialog.show({
        message: 'Are you sure delete this Article?',
        cssClass: 'type-danger',
        buttons: [{
            label: 'Delete Article',
            cssClass: 'btn-danger',
            autospin: true,
            action: function (dialogRef) {
                var datae = { 'articulo': articulo };
                $.ajax({
                    type: "POST",
                    url: "ver_articulos.aspx/eliminarArticulo",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(datae),
                    dataType: "json",
                    success: function (resultado) {
                        dialogRef.close();
                        message("Article deleted succesfully", "Information", "primary");
                        cargarDatos2();
                    },
                    error: function () {
                        
                        message("Error, please try again", "Error", "danger");
                    }
                });
            }
        }, {
            label: 'Cancel',
            action: function (dialogRef) {
                dialogRef.close();
            }
        }]
    });


    
}



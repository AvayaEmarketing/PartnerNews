//tipo de mensajes ->  default, info, primary, sucess, warning, danger
function message(texto, titulo, tipo) {
    BootstrapDialog.show({
        title: titulo,
        message: texto,
        cssClass: 'type-' + tipo
    });
    return false;
}

var myApp;
myApp = myApp || (function () {
    var pleaseWaitDiv = $('<div class="modal hide" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false"><div class="modal-header"><h1>Processing...</h1></div><div class="modal-body"><div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div></div></div>');

    return {
        showPleaseWait: function () {
            pleaseWaitDiv.modal();
        },
        hidePleaseWait: function () {
            pleaseWaitDiv.modal('hide');
        },

    };
})();

function cargarSecciones() {
    $("#article_section").html("");
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/cargarSecciones",
        contentType: "application/json; charset=utf-8",
        data: '{ }',
        dataType: "json",
        success: AjaxGetcargarSeccionesSucceeded,
        error: AjaxGetcargarSeccionesFailed
    });
}

function AjaxGetcargarSeccionesSucceeded(result) {
    if (result.d != "No data Found") {
        var jposts = result.d;
        var item = $.parseJSON(jposts);
        var error = "";
        $("#article_section").append('<option value="" selected="selected"></option>');
        $.each(item, function (i, valor) {
            $("#article_section").append('<option value="' + valor.Id + '">' + valor.nombre + '</option>');
        });
    }
}

function AjaxGetcargarSeccionesFailed(result) {
    alert(result.status + ' ' + result.statusText);
}

function cargarDetalleSeccion() {
    var seccion = $("#article_section").val();
    var datae = { 'seccion': seccion };
    $("#article_section_detail").html("");
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/cargarDetalleSeccion",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxGetcargarDetalleSeccionSucceeded,
        error: AjaxGetcargarDetalleSeccionFailed
    });
}

function AjaxGetcargarDetalleSeccionSucceeded(result) {
    if (result.d != "No data Found") {
        var jposts = result.d;
        var item = $.parseJSON(jposts);
        var error = "";
        $("#article_section_detail").append('<option value="" selected="selected"></option>');
        $.each(item, function (i, valor) {
            $("#article_section_detail").append('<option value="' + valor.Id + '">' + valor.nombre + '</option>');
        });
    }
}

function AjaxGetcargarDetalleSeccionFailed(result) {
    alert(result.status + ' ' + result.statusText);
}

function cargarEdiciones() {
    idioma = $("#article_language").val();
    var datae = { 'idioma': idioma };
    $("#ediciones").html("");
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/cargarEdiciones",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: AjaxGetCargarEdicionesSucceeded,
        error: AjaxGetCargarEdicionesFailed
    });
}

function AjaxGetCargarEdicionesSucceeded(result) {
    if (result.d != "No data Found") {
        var jposts = result.d;
        var item = $.parseJSON(jposts);
        var error = "";
        $.each(item, function (i, valor) {
            $("#ediciones").append('<div class="checkbox"><label for="checkboxes-'+ i + '"><input name="checkboxes" type="checkbox" value="'+ valor.Id +'"/>'+ valor.nombre+ '</label></div>');
        });
    }
}

function AjaxGetCargarEdicionesFailed(result) {
    alert(result.status + ' ' + result.statusText);
}

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

function validarDetalleSeccion(seccion) {
    var datae = { 'seccion': seccion };
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/validarDetalleSeccion",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            if (resultado.d == true) {
                $("#section_detail").css("display", "block");
                cargarDetalleSeccion();
            } else {
                $("#section_detail").css("display", "none");
                $("#article_section_detail").html('');
            }
        },
        error: function () {
            var error = "Alert, please try again";
        }
    });
    return false;
}

function getForm() {

    //var Id_Version = $("#Id_Version");
    var Titulo = $("#article_title");
    var Contenido = CKEDITOR.instances.txtCkEditor.document.getBody().getHtml(); 
    var Idioma = $("#article_language");
    var Seccion = $("#article_section");
    var Seccion_d = $("#article_section_detail").val();
    var Seccion_detalle = (Seccion_d == null) ? 0 : Seccion_d;
    
    var valores2 = "";
    $('#ediciones :checkbox:checked').each(function () {
        valores2 = valores2 + $(this).val() + ',';
    });
    if ((valores2.substring(valores2.length - 1, valores2.length)) === ',') 
        valores2 = valores2.substring(0, valores2.length - 1);
    

    var Edicion = valores2;
    var Top = $("#article_top_new").prop('checked');
    var Top_new = (Top) ? "YES" : "NO";
    

    var Vis = $("#article_visible").prop('checked');
    var Visible = (Vis) ? "YES" : "NO";

    var Dest = $("#article_outstanding").prop('checked');
    var Destacada = (Dest) ? "YES" : "NO";

    var Ed = $("#article_editorial").prop('checked');
    var Editorial = (Ed) ? "YES" : "NO";


    var formulario = new Object();
    //formulario.Id_Version = Id_Version.val();
    formulario.Id_Version = 1;
    formulario.Titulo = Titulo.val();
    formulario.Contenido = Contenido;
    formulario.Idioma = Idioma.val();
    formulario.Seccion = Seccion.val();
    formulario.Seccion_detalle = Seccion_detalle;
    formulario.Edicion = Edicion;
    formulario.Top_new = Top_new;
    formulario.Visible = Visible;
    formulario.Destacada = Destacada;
    formulario.Editorial = Editorial;


    return formulario;
}

function setSelectByValue(eID, val) { //Loop through sequentially//
    var ele = document.getElementById(eID);
    for (var ii = 0; ii < ele.length; ii++)
        if (ele.options[ii].value == val) { //Found!
            ele.options[ii].selected = true;
            return true;
        }
    return false;
}


function limpiarCampos() {
   
    CKEDITOR.instances.txtCkEditor.setData('');
    $("#article_title").val('');
    $("#article_language").val('');
    $("#article_section").val('');
    $("#article_top_new").prop('checked',false);
    $("#article_visible").prop('checked',true);
    $("#article_outstanding").prop('checked',false);
    $("#article_editorial").prop('checked', false);
    $('#ediciones').html('');

}

function crearArticulo(formulario) {

    var datae = {
        'Id_Version': formulario.Id_Version, 'Titulo': formulario.Titulo, 'Contenido': formulario.Contenido, 'Idioma': formulario.Idioma, 'Seccion': formulario.Seccion, 'Seccion_detalle': formulario.Seccion_detalle, 'Edicion': formulario.Edicion, 'Top_new': formulario.Top_new, 'Visible': formulario.Visible, 'Destacada': formulario.Destacada, 'Editorial': formulario.Editorial
    };
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/agregarArticulo",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            if (resultado.d === "session") {
                message("Your session has expired. Please log in again.  Redirecting...", "Partner News", "danger");
                setTimeout(function () {
                    document.location.href = "../index.aspx";
                }, 3000);
            } else if (resultado.d === "ok") {
                message("Your Article was created successfully", "Partner News", "primary");
                limpiarCampos();
            } else {
                message("Alert, please try again","Partner News", "primary");
            }
        },
        error: function () {
            message("Alert, please try again", "Partner News", "primary");
        }
    });
    return false;
}

$(document).ready(function () {
    jQuery('body')
	  .delay(500)
	  .queue(
	  	function (next) {
	  	    jQuery(this).css('padding-right', '1px');
	  	}
	);

    $("#btn_create_article").click(function () {
        formulario = getForm();
        crearArticulo(formulario);
    });

    cargarSecciones();

    $("#article_section").change(function () {
        seccion = this.value;
        validarDetalleSeccion(seccion);
    });

    $("#article_language").change(function () {
        cargarEdiciones();
    });

    $("#exit").click(function () {
        cerrarSession();
    });

    $('#article_top_new').click(function () {
        if (this.checked) {
            $('#article_editorial').prop('checked', false);
            $('#article_outstanding').prop('checked', false);
        }

    });

    $("#article_editorial").change(function () {
        if (this.checked) {
            $('#article_top_new').prop('checked', false);
            $('#article_outstanding').prop('checked', false);
        }
    });

    $("#article_outstanding").change(function () {
        if (this.checked) {
            $('#article_top_new').prop('checked', false);
            $('#article_editorial').prop('checked', false);
        }
    });
    
    


});
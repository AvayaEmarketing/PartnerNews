function editarArticulo(formulario) {
    var id_articulo = QueryString.articulo;
    var datae = {
        'id_articulo': id_articulo, 'Id_Version': formulario.Id_Version, 'Titulo': formulario.Titulo, 'Contenido': formulario.Contenido, 'Idioma': formulario.Idioma, 'Seccion': formulario.Seccion, 'Seccion_detalle': formulario.Seccion_detalle, 'Edicion': formulario.Edicion, 'Top_new': formulario.Top_new, 'Visible': formulario.Visible, 'Destacada': formulario.Destacada, 'Editorial': formulario.Editorial, 'creador':1
    };
    $.ajax({
        type: "POST",
        url: "editar_articulos.aspx/actualizarArticulo",
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
                message("Your Article was updated successfully.  Redirecting... Please wait", "Partner News", "primary");
                limpiarCamposArticulo();
                setTimeout(function () {
                    var version = QueryString.version;
                    document.location.href = "ver_articulos.aspx?version="+version;
                }, 3000);
            } else {
                message("Alert, please try again", "Partner News", "danger");
            }
        },
        error: function () {
            message("Alert, please try again", "Partner News", "danger");
        }
    });
    return false;
}

function cargarEdiciones2(edicion) {
    idioma = $("#article_language").val();
    var datae = { 'idioma': idioma };
    var existe;
    $("#ediciones").html("");
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/cargarEdiciones",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (result) {
            if (result.d != "No data Found") {
                var jposts = result.d;
                var item = $.parseJSON(jposts);
                var error = "";
                $.each(item, function (i, valor) {
                    existe = 0;
                    if (edicion.indexOf(",") == -1) {
                        if (valor.Id == edicion) {
                            $("#ediciones").append('<div class="checkbox"><label for="checkboxes-' + i + '"><input name="checkboxes" type="checkbox" value="' + valor.Id + '" checked="checked"/>' + valor.nombre + '</label></div>');
                        } else {
                            $("#ediciones").append('<div class="checkbox"><label for="checkboxes-' + i + '"><input name="checkboxes" type="checkbox" value="' + valor.Id + '"/>' + valor.nombre + '</label></div>');
                        }
                    } else {

                        var array = edicion.split(",");
                        $.each(array, function (j) {
                            if (valor.Id == array[j]) {
                                existe = 1;
                            } 
                        });
                        if (existe == 0) {
                            $("#ediciones").append('<div class="checkbox"><label for="checkboxes-' + i + '"><input name="checkboxes" type="checkbox" value="' + valor.Id + '"/>' + valor.nombre + '</label></div>');
                        } else {
                            $("#ediciones").append('<div class="checkbox"><label for="checkboxes-' + i + '"><input name="checkboxes" type="checkbox" value="' + valor.Id + '" checked="checked"/>' + valor.nombre + '</label></div>');
                        }
                    }

                   
                });
            }
        },
        error: AjaxGetCargarEdicionesFailed2
    });
}

function AjaxGetCargarEdicionesFailed2(result) {
    alert(result.status + ' ' + result.statusText);
}

function traerInfoEditarArticulo(articulo) {
    var datae = { 'articulo': articulo };
    $.ajax({
        type: "POST",
        url: "editar_articulos.aspx/traerInfoEditarArticulo",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            var jposts = resultado.d;
            jposts = validarJson(jposts);
            var item = $.parseJSON(jposts);

            var Id = item.Id;
            var titulo = item.titulo;
            var idioma = item.idioma;
            var edicion = item.edicion;
            var seccion = item.seccion;
            var top_new = item.top_new;
            var destacada = item.destacada;
            var editorial = item.editorial;
            var visible = item.visible;
            var contenido = item.contenido;
            var Seccion_detalle = item.Seccion_detalle;

            $("#article_title").val(titulo);
            CKEDITOR.instances.txtCkEditor.setData(contenido);
            setSelectByValue("article_language", idioma);
            
            setSelectByValue("article_section", seccion);

            validarDetalleSeccion2(seccion, Seccion_detalle);
            
            if (top_new == 'YES')
                $("#article_top_new").prop('checked',true);
            
            if (editorial == 'YES')
                $("#article_editorial").prop('checked',true);

            if (visible == 'YES')
                $("#article_visible").prop('checked',true);

            if (destacada == 'YES')
                $("#article_outstanding").prop('checked', true);

            //setChecks("ediciones", edicion);
           
            cargarEdiciones2(edicion);


        },
        error: function () {
            message("Alert, please try again", "Partner News", "danger");
        }
    });
    return false;
}

$(document).ready(function () {

    var articulo = QueryString.articulo;
    traerInfoEditarArticulo(articulo);
    
    $("#btn_edit_article").click(function () {
        formulario = getForm();
        editarArticulo(formulario);
    });

});

function setChecks(div_id, stringComma) {
    var contenido = $('#' + div_id).html();

    if (stringComma.indexOf(",") == -1) {
        var ediciones = $("input[name='checkboxes']");
        ediciones.each(function () {
            if ($(this).val == stringComma) {
                $(this).prop('checked', true);
            }
        });
    } else {

        var array = stringComma.split(",");
        $.each(array, function (i) {
            $('#' + div_id + ' input:checkbox').each(function () {
                if ($(this).value == array[i]) {
                    $(this).prop('checked', true);
                }
            });
        });
    }
}

function validarDetalleSeccion2(seccion, Seccion_detalle) {
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
                cargarDetalleSeccion2(Seccion_detalle);
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


function cargarDetalleSeccion2(Seccion_detalle) {
    var seccion = $("#article_section").val();
    var datae = { 'seccion': seccion };
    $("#article_section_detail").html("");
    $.ajax({
        type: "POST",
        url: "crear_articulos.aspx/cargarDetalleSeccion",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (result) {
            if (result.d != "No data Found") {
                var jposts = result.d;
                var item = $.parseJSON(jposts);
                var error = "";
                $("#article_section_detail").append('<option value="" selected="selected"></option>');
                $.each(item, function (i, valor) {
                    if (valor.Id == Seccion_detalle) {
                        $("#article_section_detail").append('<option value="' + valor.Id + '" selected="selected">' + valor.nombre + '</option>');
                    } else {
                        $("#article_section_detail").append('<option value="' + valor.Id + '">' + valor.nombre + '</option>');
                    }
                });
            }
        },
        error: function (resut) {
            alert(result.status + ' ' + result.statusText);
        }
    });
}


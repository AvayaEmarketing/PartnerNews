$(document).ready(function () {

    $("#crear").click(function () {
        $.ajax({
            type: "POST",
            url: "Articulo.aspx/crear",
            contentType: "application/json; charset=utf-8",
            data: '{}',
            dataType: "json",
            success: function (resultado) {
                if (resultado.d !== "ok") {
                    alert("OK")
                    //limpiar campos
                } else {
                    alert("Alert, please try again");
                }
            }
        });
        return false;
    });


    $("#new_solicit").click(function () {
        $("#dt_my_solicits").css({ "display": "none" });
        $("#nueva_solicitud").css({ "display": "block", "margin-right": "auto", "margin-left": "auto", "*zoom": "1", "position": "relative" });
    });



  
});



function registrarInfo(formulario) {

    var datae = {
        'Id_Version': formulario.Id_Version, 'Titulo': formulario.Titulo, 'Contenido': formulario.Contenido, 'Idioma': formulario.Idioma, 'Seccion': formulario.Seccion, 'Seccion_detalle': formulario.Seccion_detalle, 'Edicion': formulario.Edicion, 'Top_new': formulario.Top_new, 'Visible': formulario.Visible, 'Destacada': formulario.Destacada, 'Editorial': formulario.Editorial
    };
    $.ajax({
        type: "POST",
        url: "Articulo.aspx/agregarArticulo",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datae),
        dataType: "json",
        success: function (resultado) {
            if (resultado.d !== "ok") {
                alert("OK")
                //limpiar campos
            } else {
                alert("Alert, please try again");
            }
        }
    });
    return false;
}


function getForm() {
    
    var Id_Version = $("#Id_Version");
    var Titulo = $("#Titulo");
    var Contenido = $("#Contenido");
    var Idioma = $("#Idioma");
    var Seccion = $("#Seccion");
    var Seccion_detalle = $("#Seccion_detalle");
    var Edicion = $("#Edicion");
    var Top_new = $("#Top_new");
    var Visible = $("#Visible");
    var Destacada = $("#Destacada");
    var Editorial = $("#Editorial");

    
    var formulario = new Object();
    formulario.Id_Version = Id_Version.val();
    formulario.Titulo = Titulo.val();
    formulario.Contenido = Contenido.val();
    formulario.Idioma = Idioma.val();
    formulario.Seccion = Seccion.val();
    formulario.Seccion_detalle = Seccion_detalle.val();
    formulario.Edicion = Edicion.val();
    formulario.Top_new = Top_new.val();
    formulario.Visible = Visible.val();
    formulario.Destacada = Visible.val();
    formulario.Editorial = Visible.val();


    return formulario;
}


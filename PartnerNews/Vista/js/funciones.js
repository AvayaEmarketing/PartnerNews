//Obtener los parametros de la URL
var QueryString = function () {
    var query_string = {};
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (typeof query_string[pair[0]] === "undefined") {
            query_string[pair[0]] = pair[1];
        } else if (typeof query_string[pair[0]] === "string") {
            var arr = [query_string[pair[0]], pair[1]];
            query_string[pair[0]] = arr;
        } else {
            query_string[pair[0]].push(pair[1]);
        }
    }
    return query_string;
}();

$(document).ready(function () {
    //Actualiza el contenido del body  ************* Resuelve el problema de Chrome  ****************
    jQuery('body')
	  .delay(500)
	  .queue(
	  	function (next) {
	  	    jQuery(this).css('padding-right', '1px');
	  	}
	);

    $("#menu_top").addClass("highlight3");
    $("#logo_p_n").click(function () {
        $("#buttons_menu_top").toggleClass("display");
        $("#buttons_menu_top").toggleClass("display2");
        $("#menu_top").toggleClass("highlight2");
        $("#menu_top").toggleClass("highlight");
    });

    enquire.register("screen and (max-width:450px) and (max-width : 800px) ", {

        // OPTIONAL
        // If supplied, triggered when a media query matches.
        match: function () {
            $("#menu_top").removeClass("highlight3");
            $("#menu_top").addClass("highlight2");
            $("#buttons_menu_top").removeClass("display");
            $("#buttons_menu_top").addClass("display2");
        },

        // OPTIONAL
        // If supplied, triggered when the media query transitions 
        // *from a matched state to an unmatched state*.
        unmatch: function () {
            $("#menu_top").removeClass("highlight");
            $("#menu_top").removeClass("highlight2");
            $("#menu_top").addClass("highlight2");
            $("#menu_top").addClass("highlight3");

            $("#buttons_menu_top").removeClass("display2");
            $("#buttons_menu_top").addClass("display");
        },
    });

    enquire.register("screen and (min-width : 800px) ", {

        // OPTIONAL
        // If supplied, triggered when a media query matches.
        match: function () {
            $("#menu_top").removeClass("highlight3");
            $("#menu_top").addClass("highlight4");
        },

        // OPTIONAL
        // If supplied, triggered when the media query transitions 
        // *from a matched state to an unmatched state*.
        unmatch: function () {
            $("#menu_top").removeClass("highlight4");
            $("#menu_top").addClass("highlight3");
        },
    });

    //Operaciones del Menu General
    $("#goHome").click(function () {
        goHome();
    });


    $("#logOut").click(function () {
        cerrarSession();
    });

    $("#gotoArticles").click(function () {
        document.location.href = "ver_articulos.aspx?version=" + QueryString.version;
    });

    $("#gotoEditions").click(function () {
        document.location.href = "ver_ediciones.aspx?version=" + QueryString.version;
    });

    
});

$(function () {
    $('.datatable').each(function () {
        var datatable = $(this);
        // SEARCH - Add the placeholder for Search and Turn this into in-line formcontrol
        var search_input = datatable.closest('.dataTables_wrapper').find('div[id$=_filter] input');
        search_input.attr('placeholder', 'Search')
        search_input.addClass('form-control input-small')
        search_input.css('width', '250px')

        // SEARCH CLEAR - Use an Icon
        var clear_input = datatable.closest('.dataTables_wrapper').find('div[id$=_filter] a');
        clear_input.html('<i class="icon-remove-circle icon-large"></i>')
        clear_input.css('margin-left', '5px')

        // LENGTH - Inline-Form control
        var length_sel = datatable.closest('.dataTables_wrapper').find('div[id$=_length] select');
        length_sel.addClass('form-control input-small')
        length_sel.css('width', '75px')

        // LENGTH - Info adjust location
        var length_sel = datatable.closest('.dataTables_wrapper').find('div[id$=_info]');
        length_sel.css('margin-top', '18px')
    });
});

$.extend($.fn.dataTableExt.oStdClasses, {
    "sWrapper": "dataTables_wrapper form-inline"
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
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("some error");
        }
    });
    return false;
}

function validarJson(divs_id) {
    if ((divs_id.substring(divs_id.length - 1, divs_id.length)) === ']')
        divs_id = divs_id.substring(0, divs_id.length - 1);

    if ((divs_id.substring(0, 1)) === '[')
        divs_id = divs_id.substring(1, divs_id.length);

    return divs_id;

}

function goHome() {
    $.ajax({
        type: "POST",
        url: "service_utilidades.asmx/goHome",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (resultado) {
            document.location.href = "Version.aspx";
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("some error");
        }
    });
    return false;
}

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

//Asignar el valor a un select
//Por valor
function setSelectByValue(eID, val) {
    var ele = document.getElementById(eID);
    for (var ii = 0; ii < ele.length; ii++)
        if (ele.options[ii].value == val) {
            ele.options[ii].selected = true;
            return true;
        }
    return false;
}
//Por texto
function setSelectByText(eID, text) {
    var ele = document.getElementById(eID);
    for (var ii = 0; ii < ele.length; ii++)
        if (ele.options[ii].text == text) {
            ele.options[ii].selected = true;
            return true;
        }
    return false;
}


//Validaciones de campos
function validate(valor) {
    if (valor == null || valor.length < 1 || /^\s+$/.test(valor)) {
        return false;
    }
    else {
        return true;
    }
}

//Validar campo email
function validateEmail(valor) {
    var correo = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!correo.exec(valor)) {
        return false;
    } else {
        return true;
    }
}

//Validar si es un numero
function validateNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function eliminarUltimaComa(Cadena) {
    if ((Cadena.substring(Cadena.length - 1, Cadena.length)) === ',') {
        Cadena = Cadena.substring(0, Cadena.length - 1);
    }
    return Cadena;
}


//Validar extension maliciosa en un archivo  recibe el nombre del archivo como parametro
function validarExtension(nombre) {
    var ext = (nombre.substring(nombre.lastIndexOf(".") + 1)).toUpperCase();
    var respuesta = 0;
    var extension = new Object();
    extension.EXE = "EXE";
    extension.COM = "COM";
    extension.VB = "VB";
    extension.VBS = "VBS";
    extension.VBEE = "VBE";
    extension.CMDD = "CMD";
    extension.BATT = "BAT";
    extension.WSS = "WS";
    extension.WSFF = "WSF";
    extension.SCRR = "SCR";
    extension.SHS = "SHS";
    extension.PIF = "PIF";
    extension.HTA = "HTA";
    extension.JAR = "JAR";
    extension.JS = "JS";
    extension.JSE = "JSE";
    extension.LNK = "LNK";

    for (var i in extension) {
        if (extension[i] === ext) {
            respuesta = respuesta + 1;
            return false;
        }
        else {
            respuesta = respuesta + 0;
        }
    }
    if (respuesta === 0) {
        return true;
    } else {
        return false;
    }
}

//Detecta si el navegador es IE  *******  No funciona para IE 11   ********
function isIE() {
    var myNav = navigator.userAgent.toLowerCase();
    return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : false;
}

//Trae la version de internet Explorer  ***  SI funciona con IE 11  ***
function getInternetExplorerVersion() {
    var rv = -1;
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    else if (navigator.appName == 'Netscape') {
        var ua = navigator.userAgent;
        var re = new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}


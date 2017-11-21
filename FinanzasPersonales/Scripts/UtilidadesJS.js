$(document).ready(function () {
    $(".loadFadein").addClass("animated fadeIn");
    $('.parallax').parallax();
    //Transforma las validaciones dadas por html helper en un pop up de materialize

    if ($(".validation-summary-errors").length) {
        $("<div>", { "class": "modal" }).append($(".validation-summary-errors").addClass("modal-content center-align")).append($("<div>", { "class": "modal-footer" }).append($("<a>", { "class": "modal-action modal-close waves-effect waves-green btn-flat", "html": "ACEPTAR" }))).appendTo($("body"));
        $('.modal').modal();
        $(".modal").modal("open");
    }
    //$(".validation-summary-errors").appendTo($("<div>", { "class": "modal" })).appendTo($("body"));


});
function objectifyForm(jqueryForm) {
    var paramObj = {};
    $.each(jqueryForm.serializeArray(), function (_, kv) {
        paramObj[kv.name] = kv.value;
    });
    return paramObj;
}
function getEstadosCuentaBanco() {
    var Datos = [];
    $.ajax({
        type: "GET",
        async: false,
        url: "/CuentaBanco/GetEstadosCuentaBanco",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");
            
        }
    });
    return Datos;
}

function getBancos() {
    var Datos = []
    $.ajax({
        type: "GET",
        async: false,
        url: "/Banco/GetBancosUsuario",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
    return Datos;
}

function getMonedas() {
    var Datos = []
    $.ajax({
        type: "GET",
        async: false,
        url: "/Moneda/GetMonedas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
    return Datos;
}
function getCuentasBanco() {
    var Datos = []
    $.ajax({
        type: "GET",
        async: false,
        url: "/CuentaBanco/GetCuentasBanco",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
    return Datos;
}
//A partir de aqui los guardar
function guardarBanco(banco) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/Banco/CrearBanco",
        data: JSON.stringify(banco),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data;
            Materialize.toast(Data.Message, 3000, 'rounded')
            console.log(Data);
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
}

function guardarCuentaBanco(cuenta) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/CuentaBanco/CrearCuenta",
        data: JSON.stringify(cuenta),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Data) {
            Datos = Data.Data;
            Materialize.toast(Data.Message, 3000, 'rounded')
            console.log(Data);
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            Materialize.toast("Error al intentar conectarse con el servidor", 3000, 'rounded')
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
}
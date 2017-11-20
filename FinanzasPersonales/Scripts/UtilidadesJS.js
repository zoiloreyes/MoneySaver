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
            alert("Error al intentar comunicarce con el servidor!");
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
            alert("Error al intentar comunicarce con el servidor!");
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
            console.log(Data);  
            //var temp = JSON.parse(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //OcultarProgreso();
            alert("Error al intentar comunicarce con el servidor!");
            console.log("Respuesta = " + XMLHttpRequest.responseText + "\n Estatus = " + textStatus + "\n Error = " + errorThrown, "Error: Grid ");

        }
    });
    return Datos;
}
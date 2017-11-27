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
/*Valida formularios por clases:

*Retorna un objeto con la propiedad Estado que determina si cumplió con las validaciones
y una propiedad Errores que es un arreglo con los campos que no cumplieron con la validacion

*Requiere que los inputs tengan un atributo title

-Requerido: indica que el formulario no puede estar vacío
-numero: indica que el campo es un numero
-email: indica que el campo es un email
-longitud: indica que el campo debe tener la longitud especificada en el data-longitud
-repetido: indica que el campo debe tener el mismo valor que el campo de id contenido en el data-repetido*/
function validarForm(form) {
    var retorno = {
        Estado: true,
        Errores: []
    }
    function elemento(objeto, msg) {
        this.objeto = objeto;
        this.msg = msg;
    }
    var value = true;

    $(form).find(".requerido:enabled").each(function () {
        if ($(this).val().trim() == "" || $(this).val() == 0) {
            retorno.Estado = false;
            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " es requerido");
            retorno.Errores.push(problematico);
        } else {

        }
    });
    $(form).find(".tinyMCErequerido:enabled").each(function () {
        if (window.parent.tinyMCE.get($(this).attr("id")).getContent("").length <= 0) {
            retorno.Estado = false;
            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " es requerido");
            retorno.Errores.push(problematico);
        }
    });
    $(form).find(".numero:enabled").each(function () {
        if (!$.isNumeric($(this).val().trim())) {
            retorno.Estado = false;
            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " debe ser un numero");
            retorno.Errores.push(problematico);
        } else {

        }
    });
    $(form).find(".email:enabled").each(function () {
        var pattern = new RegExp(/^(("[\w-+\s]+")|([\w-+]+(?:\.[\w-+]+)*)|("[\w-+\s]+")([\w-+]+(?:\.[\w-+]+)*))(@((?:[\w-+]+\.)*\w[\w-+]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][\d]\.|1[\d]{2}\.|[\d]{1,2}\.))((25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\.){2}(25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\]?$)/i);
        if (pattern.test($(this).val())) {

        } else {
            retorno.Estado = false;
            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " debe ser un email");
            retorno.Errores.push(problematico);
        }
    });
    $(form).find(".longitud:enabled").each(function () {
        if ($(this).val().trim().length <= $(this).data("longitud")) {

            retorno.Estado = false;
            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " es muy corto");
            retorno.Errores.push(problematico);
        } else {

        }
    });
    $(form).find(".repetido:enabled").each(function () {
        var valorComparado = $(this).data("repetido");

        if ($(this).val() != $(valorComparado).val()) {

            retorno.Estado = false;

            var problematico = new elemento($(this), "El campo " + $(this).attr("title") + " no es igual a " + $(valorComparado).attr("title"));
            retorno.Errores.push(problematico);
        } else {

        }
    });

    return retorno;
}

//Funcion jquery para clickear afuera de un objeto jquery
$.fn.clickOff = function (callback, selfDestroy) {
    var clicked = false;
    var parent = this;
    var destroy = selfDestroy || true;

    parent.click(function () {
        clicked = true;
    });

    $(document).click(function (event) {
        if (!clicked) {
            callback(parent, event);
        }
        if (destroy) {
            //parent.clickOff = function() {};
            //parent.off("click");
            //$(document).off("click");
            //parent.off("clickOff");
        };
        clicked = false;
    });
};


//Esta funcion utiliza los jAlert de jquery.alert.js https://github.com/aurels/jquery.alerts
//Toma un array y despliega todos sus indices, el indice de inicio es opcional
function crearAlertas(array, indice) {
    indice = indice || 0;
    if (typeof array != "undefined" && array != null && array.length > 0) {
        jAlert(array[indice], 'Alerta', function () {
            if (indice < array.length - 1) {
                crearAlertas(array, indice + 1);
            }
        });
    }
}

//Formatea una fecha iso a dd/mm/yyyy
function ISOToDate(isodate) {
    var date = new Date(isodate);

    return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
}
function ISOToDateUnFormat(isodate) {
    var date = new Date(isodate);

    return ("0" + date.getDate()).slice(-2) + "" + ("0" + (date.getMonth() + 1)).slice(-2) + date.getFullYear();
}

//dd/mm/yyyy a mm/dd/yyyy
function ESdateToUSdate(ESdate) {
    return USdate = ESdate.split(/\//).reverse().join('/');
}


//MultiSelect
//El select debe estar contenido en un elemento de posicion relativa
//V0.1 Volatil
$.fn.CheckboxSelect = function () {
    var contadorDeElementos = 0;
    return this.each(function () {
        if ($(this).is("select")) {
            contadorDeElementos++;

            var selectOriginal = $(this);
            var selectBox = $("<div>", {
                class: "selectBox",
                width: $(this).css("width"),
                "data-expanded": "false"
            }).css("position", "relative");

            $(selectBox).append($(this).clone());
            $(this).replaceWith(selectBox);
            var overSelect = $("<div>", {
                class: "overSelect"
            }).css({
                position: "absolute",
                left: "0",
                right: "0",
                top: "0",
                bottom: "0"
            });
            $(overSelect).appendTo(selectBox);

            //Toma los valores del option
            var Opciones = [];
            $(this)
                .children("option:enabled")
                .each(function () {
                    var opcion = {
                        valor: $(this).val(),
                        html: $(this).html()
                    };
                    Opciones.push(opcion);
                });

            var SelectDiv = $("<div>", {
                id: "MultiSelectDiv" + contadorDeElementos
            }).css({
                display: "none",
                border: "1px #dadada solid",
                "background-color": "white",
                "position": "absolute",

                "z-index": "10"
            }).data("SelectOriginal", selectOriginal);

            for (var i in Opciones) {
                var label = $("<label>", {
                    for: "MultiselectLabel" + contadorDeElementos + i,
                    html: Opciones[i].html
                })
                    .css({
                        display: "block",
                        "fontSize": "10px",
                        "fontWeight": "normal",
                        "padding": "0px 4px",
                        "margin": "0"
                    })
                    .mouseover(function () {
                        $(this).css("background-color", "#1e90ff");
                    })
                    .mouseout(function () {
                        $(this).css("background-color", "transparent");
                    });
                var checkBox = $("<input>", {
                    id: "MultiselectLabel" + contadorDeElementos + i,
                    type: "checkbox"
                }).css({ "margin": "0" })
                    .val(Opciones[i].valor)
                    .prependTo(label);

                $(SelectDiv).append($(label));
            }
            $(SelectDiv).insertAfter(selectBox);
            $(selectBox)
                .children("select")
                .empty()
                .append(
                $("<option>", {
                    value: "0",
                    html: "[Seleccione una opción]"
                })
                );
            $(selectBox).click(function () {
                if ($(this).data("expanded")) {
                    $(SelectDiv).css("display", "none");
                    $(this).data("expanded", false);
                } else {
                    $(SelectDiv).css("display", "block");
                    $(this).data("expanded", true);
                }
            });
            $(selectBox).clickOff(function () {
                if ($(selectBox).data("expanded")) {
                    $(SelectDiv).css("display", "none");
                    $(selectBox).data("expanded", false);
                }
            })
            $(SelectDiv).click(function () {
                var valores = [];
                var textos = [];
                $(this)
                    .find("input:checkbox:checked")
                    .each(function () {
                        var opcion = {
                            valor: $(this).val(),
                            html: $(this)
                                .parent()
                                .text()
                        };
                        valores.push($(this).val());
                        textos.push(
                            $(this)
                                .parent()
                                .text()
                        );
                    });
                $(selectBox)
                    .children("select")
                    .empty()
                    .append(
                    $("<option>", {
                        value: valores.length > 0 ? JSON.stringify(valores) : 0,
                        html: "(" + textos.length + ") Seleccionado(s) "
                    })
                    );
            });

        }
    });
};
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
function getEstadosTarjetaCredito() {
    var Datos = [];
    $.ajax({
        type: "GET",
        async: false,
        url: "/TarjetaCredito/GetEstadosTarjetaCredito",
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
function getContactos() {
    var Datos = [];
    $.ajax({
        type: "GET",
        async: false,
        url: "/Contacto/GetContactos",
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
function getCuentasPrestamo() {
    var Datos = []
    $.ajax({
        type: "GET",
        async: false,
        url: "/CuentaPrestamo/GetCuentasPrestamo",
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
function getTarjetasCredito() {
    var Datos = []
    $.ajax({
        type: "GET",
        async: false,
        url: "/TarjetaCredito/GetTarjetasCredito",
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
function guardarCuentaPrestamo(prestamo) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/CuentaPrestamo/CrearPrestamo",
        data: JSON.stringify(prestamo),
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
function guardarTarjetaCredito(tarjeta) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/TarjetaCredito/CrearTarjetaCredito",
        data: JSON.stringify(tarjeta),
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

function guardarContacto(contacto) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/Contacto/CrearContacto",
        data: JSON.stringify(contacto),
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

function guardarCategoria(categoria) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/Categoria/CrearCategoria",
        data: JSON.stringify(categoria),
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
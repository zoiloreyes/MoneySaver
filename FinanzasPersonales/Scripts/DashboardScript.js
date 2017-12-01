 $(document).ready(function () {

            $('.modal').modal();
            cargarSelectMoneda();
            cargarSelectBanco();
            cargarSelectEstadoCuentaBanco();
            cargarSelectEstadoTarjetaCredito();
            cargarSelectCuenta();
            cargarCuentasBanco();
            cargarCuentasPrestamo();
            cargarTarjetasCredito();
            cargarSelectContacto();
            $('.datepicker').pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 90, // Creates a dropdown of 15 years to control year,
                today: 'Today',
                clear: 'Clear',
                close: 'Ok',
                closeOnSelect: true, // Close upon selecting a date,
                format: 'dd/mm/yyyy'
            });
            $(".select2").select2({ width: '100%' });

            //Preparar selects de moneda+-----
            function cargarSelectMoneda() {
                $(".MonedaSelect").empty();
                var monedas = getMonedas();
                if (monedas.length > 0) {
                    $(".MonedaSelet").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in monedas) {
                        moneda = monedas[i];
                        $(".MonedaSelect").append(
                            $("<option>", {
                                value: moneda.Value,
                                html: moneda.Text
                            }).data("codigo", moneda.Codigo)
                        );
                    }
                } else {
                    $(".MonedaSelet").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay monedas disponibles"
                        })
                    );
                }
                $(".select2").select2({ width: '100%' });
            }

            function cargarSelectBanco() {
                $(".BancoSelect").empty();
                var bancos = getBancos();
                if (bancos.length > 0) {
                    $(".BancoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in bancos) {
                        banco = bancos[i];
                        $(".BancoSelect").append(
                            $("<option>", {
                                value: banco.Value,
                                html: banco.Text
                            })
                        );
                    }
                } else {
                    $(".BancoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay bancos disponibles"
                        })
                    );
                }
                $(".select2").select2({ width: '100%' });

            }

            function cargarSelectCuenta() {
                $(".CuentaSelect").empty();
                var cuentas = getCuentas();
                if (cuentas.length > 0) {
                    $(".CuentaSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in cuentas) {
                        cuenta = cuentas[i];
                        $(".CuentaSelect").append(
                            $("<option>", {
                                value: cuenta.Value,
                                html: cuenta.Text
                            }).data("name", cuenta.Name)
                        );
                    }
                } else {
                    $(".CuentaSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay cuentas disponibles"
                        })
                    );
                }
                $(".select2").select2({ width: '100%' });
                $(".CuentaSelect").on("change", function (e) {
                    var optionSelected = $("option:selected", this);
                    var name = $(optionSelected).data("name");
                    $(this).attr("name", name);
                });
            }

            function cargarSelectEstadoTarjetaCredito() {
                $(".EstadoTarjetaCreditoSelect").empty();
                var estados = getEstadosCuentaBanco();
                if (estados.length > 0) {
                    $(".EstadoTarjetaCreditoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in estados) {
                        estado = estados[i];
                        $(".EstadoTarjetaCreditoSelect").append(
                            $("<option>", {
                                value: estado.Value,
                                html: estado.Text
                            })
                        );
                    }
                } else {
                    $(".EstadoTarjetaCreditoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay opciones disponibles"
                        })
                    );
                }
                $(".select2").select2({ width: '100%' });
            }

            function cargarSelectEstadoCuentaBanco() {
                $(".EstadoCuentaBancoSelect").empty();
                var estados = getEstadosCuentaBanco();
                if (estados.length > 0) {
                    $(".EstadoCuentaBancoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in estados) {
                        estado = estados[i];
                        $(".EstadoCuentaBancoSelect").append(
                            $("<option>", {
                                value: estado.Value,
                                html: estado.Text
                            })
                        );
                    }
                } else {
                    $(".EstadoCuentaBancoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay opciones disponibles"
                        })
                    );
                }
                $(".select2").select2({ width: '100%' });
            }

            function cargarSelectContacto() {
                $(".ContactoSelect").empty();
                var contactos = getContactos();
                if (contactos.length > 0) {
                    $(".ContactoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "Selecciona una opcion"
                        })
                    );
                    for (var i in contactos) {
                        contacto = contactos[i];
                        $(".ContactoSelect").append(
                            $("<option>", {
                                value: contacto.Id,
                                html: contacto.Nombre
                            })
                        );
                    }
                } else {
                    $(".ContactoSelect").append(
                        $("<option>", {
                            value: "",
                            disabled: "disabled",
                            selected: "selected",
                            html: "No hay contactos disponibles"
                        })
                    );
                }

                $(".select2").select2({ width: '100%' });
            }

            function cargarCuentasBanco() {
                $(".contenedorCuentaBanco").find(".CuentaBancoLi").remove();
                var cuentasDeBanco = getCuentasBanco();
                for (var i in cuentasDeBanco) {
                    var cuentaI = cuentasDeBanco[i];
                    $(".contenedorCuentaBanco").append(
                        $("<li>", {
                            class: "CuentaBancoLi"
                        }).append(
                            $("<a>", {
                                class: "waves-effect waves-green sideButton",
                                html: cuentaI.NombreCuenta,
                                href: "/CuentaBanco/DetalleCuenta/" + cuentaI.CuentaBancoID
                            }).data("CuentaBancoID", cuentaI.CuentaBancoID)
                            )
                    )
                }
            }

            function cargarCuentasPrestamo() {
                $(".contenedorCuentaPrestamo").find(".CuentaPrestamoLi").remove();
                var cuentasDePrestamo = getCuentasPrestamo();
                for (var i in cuentasDePrestamo) {
                    var cuentaI = cuentasDePrestamo[i];
                    $(".contenedorCuentaPrestamo").append(
                        $("<li>", {
                            class: "CuentaPrestamoLi"
                        }).append(
                            $("<a>", {
                                class: "waves-effect waves-green sideButton",
                                html: cuentaI.NombrePrestamo
                            }).data("CuentaPrestamoID", cuentaI.CuentaPrestamoID)
                            )
                    )
                }
            }

            function cargarTarjetasCredito() {
                $(".contenedorTarjetasCredito").find(".TarjetaCreditoLi").remove();
                var tarjetasCredito = getTarjetasCredito();
                for (var i in tarjetasCredito) {
                    var cuentaI = tarjetasCredito[i];
                    $(".contenedorTarjetasCredito").append(
                        $("<li>", {
                            class: "TarjetaCreditoLi"
                        }).append(
                            $("<a>", {
                                class: "waves-effect waves-green sideButton",
                                html: cuentaI.NombreTarjeta
                            }).data("TarjetaCreditoID", cuentaI.TarjetaCreditoID)
                            )
                    )
                }

            }

            $(".btnSubmitBanco").click(function () {
                var objeto = objectifyForm($("#" + $(this).data("form")));
                guardarBanco(objeto);
                $("#" + $(this).data("form"))[0].reset();
                cargarSelectBanco()
            });

            $(".btnSubmitCuentaPrestamo").click(function () {
                var objeto = objectifyForm($("#" + $(this).data("form")));
                guardarCuentaPrestamo(objeto);
                $("#" + $(this).data("form"))[0].reset();
                cargarCuentasPrestamo();
                cargarSelectCuenta();
            });

            $(".btnSubmitTarjetaCredito").click(function () {
                var objeto = objectifyForm($("#" + $(this).data("form")));
                guardarTarjetaCredito(objeto);
                $("#" + $(this).data("form"))[0].reset();
                cargarTarjetasCredito();
                cargarSelectCuenta();
            });

            $(".btnSubmitContacto").click(function () {
                var objeto = objectifyForm($("#" + $(this).data("form")));
                guardarContacto(objeto);
                $("#" + $(this).data("form"))[0].reset();
                cargarSelectContacto();
            });

            $(".btnSubmitCuentaBanco").click(function () {
                var objeto = objectifyForm($("#" + $(this).data("form")));
                guardarCuentaBanco(objeto);
                $("#" + $(this).data("form"))[0].reset();
                cargarCuentasBanco();
                cargarSelectCuenta();
            });

            $(".sideButton").click(function () {
                $(this).css("color", "white");
                var that = $(this);
                setTimeout(function () { $(that).css("color", "#757575"); }, 500);
                $(this).children().each(function () {
                    var that = $(this);
                    $(this).css("color", "white");
                    setTimeout(function () { $(that).css("color", "#757575"); }, 500);

                });
            })

        });
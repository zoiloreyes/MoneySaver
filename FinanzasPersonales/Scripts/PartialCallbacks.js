function javascriptContacto() {
    $("#Agenda #txtBuscar").on("change paste keyup", function () {
        var patron = $(this).val();
        $("#Agenda").find(".contacto").each(function () {
            var nombre = $(this).find(".Nombre").text();
            var correo = $(this).find(".Correo").text();
            if (nombre.includes(patron) || correo.includes(patron)) {
                $(this).fadeIn(300);
                //$(this).css("display", "block");
            } else {
                $(this).fadeOut(300);
                //$(this).css("display", "none");
            }
        })
        $("#Agenda").find(".Nombre").text();
    });
    $("#Agenda .contacto").click(function () {
        alert($(this).data("id"));
    });
}
function javascriptCategorias() {
    $("#tree").Colapsificar();
}
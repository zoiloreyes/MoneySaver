
function javascriptResumen(){
    var ctx = document.getElementById('myChart').getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'bar',

        // The data for our dataset
        data: {
            labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre",
                "Octubre", "Noviembre", "Diciembre"],
            datasets: [{
                label: "My First dataset",
                backgroundColor: 'rgb(137, 191, 67)',
                borderColor: 'rgb(225,225,225)',
                data: [8, 10, 5, 2, 20, 30, 45, 50, 71, 60, 30, 44],
            }]
        },

        // Configuration options go here
        options: {}
    });

    var ctx = document.getElementById('myChartMes').getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'doughnut',

        // The data for our dataset
        data: {
            labels: ["Comida", "Ropa", "Cine"],
            datasets: [{
                label: "My First dataset",
                backgroundColor: ['rgb(137, 191, 67)', 'rgb(235, 52, 52)', 'rgb(41, 128, 185)'],
                borderColor: 'rgb(255, 255, 255)',
                data: [8, 10, 5,],
            }]
        },

        // Configuration options go here
        options: {}
    });
}
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
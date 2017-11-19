$(document).ready(function () {
    $(".loadFadein").addClass("animated fadeIn");
    $('.parallax').parallax();
    //Transforma las validaciones dadas por html helper en un pop up de materialize
    console.log($(".validation-summary-errors").length)
    if ($(".validation-summary-errors").length) {
        $("<div>", { "class": "modal" }).append($(".validation-summary-errors").addClass("modal-content center-align")).append($("<div>", { "class": "modal-footer" }).append($("<a>", { "class": "modal-action modal-close waves-effect waves-green btn-flat", "html": "ACEPTAR" }))).appendTo($("body"));
        $('.modal').modal();
        $(".modal").modal("open");
    }
    //$(".validation-summary-errors").appendTo($("<div>", { "class": "modal" })).appendTo($("body"));
    
});

$('.btn-group a').click(function (e) {

    var id = $(this).attr('id');
    $('.btn-group a').next("ul").fadeOut(300);
    $('#' + id).next("ul").fadeIn(600);
    e.stopPropagation();

})
$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {

        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });

});
function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    /*$('#replacetarget').load('Agencia/listar-endereco');*/ // Carrega o resultado HTML para a div demarcada
                    document.location.href = result.url;
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        return false;
    });
}

$('button[title="Buscar"]').each(function () {
    $('input[name="Buscar"]').val('');
});

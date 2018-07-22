// Limpar o campo de nome
$('#btnsalvarcelula').each(function () {
    $('#txtcelulanomecelula').val('');
});

//Capturar o nome e os ids no dropdownlist

var alterar = $("#btnalterarcelula");
var deletar = $("#btndeletarcelula");

alterar.prop('disabled', true);
deletar.prop('disabled', true);


var celulaid;
$("#menucelula a").click(function () {
    var result = $(this).text();
    $('#txtcelulanomecelula').val(result);

    celulaid = $(this).attr('id');

    alterar.prop('disabled', false);

    deletar.prop('disabled', false);

    $('#CelulaId').val(celulaid);
    e.stopPropagation();
});


//Excluir Célula
var deletar = $("#btndeletarcelula");
$('#btndeletarcelula').click(function () {

    deletar.html('Carregando...')
    deletar.prop('disabled', true);

    $.get("/Celula/excluir-celula/" + celulaid, { id: celulaid }).done(function (data) {

        if (data.retorno === "OK") {
            deletar.html('Deletar')
            deletar.prop('disabled', false);
            document.location.href = "/Celula/listar-celula";
        } else {

            deletar.html('Deletar')
            deletar.prop('disabled', false);
            $('#myModalContent').html(data);
            $('#myModal').modal('show');
        }

    });
    return false;
});






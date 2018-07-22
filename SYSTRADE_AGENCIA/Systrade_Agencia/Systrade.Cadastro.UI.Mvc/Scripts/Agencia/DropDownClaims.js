/*Carregar DropDownlis*/
$(function () {
    $.ajax({
        type: "Post",
        url: "/AgenciaUsuario/listar-permissao",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var result = data.retorno;

            if (result.length > 0) {
                $.each(result, function () {

                    $("#permissoes").append("<option value='" + this.Id + "'>" + this.ClaimValue + "</option>");
                    $('.selectpicker').selectpicker('refresh');
                })

                $.post("/AgenciaUsuario/BuscarPermissaoUsuario", { id: $("input[name='UsuarioId']").val() }).done(function (data) {
                    var resultado = data.Permissao;

                    switch (resultado) {
                        case "A":
                            $('option[value="1"]').attr('selected', 'selected').change();
                            break;
                        case "C":
                            $('option[value="2"]').attr('selected', 'selected').change();
                            break;
                        case "S":
                            $('option[value="3"]').attr('selected', 'selected').change();
                            break;
                        case "E":
                            $('option[value="4"]').attr('selected', 'selected').change();
                            break;
                        case "P":
                            $('option[value="5"]').attr('selected', 'selected').change();
                            break;
                        case "R":
                            $('option[value="6"]').attr('selected', 'selected').change();
                            break;
                        case "O":
                            $('option[value="7"]').attr('selected', 'selected').change();
                            break;
                        case "V":
                            $('option[value="8"]').attr('selected', 'selected').change();
                            break;
                        default:
                    }
                })
            }
        },
        error: function (erro) {
        }
    })
})


$('#adicionarusuario').click(function () {
    $('#salvarpermissao').val('');
    var result = $("option:selected").text();
    $('#salvarpermissao').val(result);
});


$('#btnatualizaragenciausuario').click(function () {

    $('#editarpermissao').val('');
    var result = $("option:selected").text();
    $('#editarpermissao').val(result);

});

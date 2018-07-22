function limpa_formulário_cep() {
    $("#txtregisterlogradouro").val("");
    $("#txtregistercidade").val("");
    $("#txtregisterestado").val("");
}
$("#txtregistercepagencia").blur(function () {
    var cep = $(this).val().replace(/\D/g, '');
    if (cep != "") {
        var validacep = /^[0-9]{8}$/;
        if (validacep.test(cep)) {
            $("#txtregisterlogradouro").val("...");
            $("#txtregistercidade").val("...");
            $("#txtregisterestado").val("...");
            $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                if (!("erro" in dados)) {
                    $("#txtregisterlogradouro").val(dados.logradouro);
                    $("#txtregistercidade").val(dados.localidade);
                    $("#txtregisterestado").val(dados.uf);
                }
                else {

                    limpa_formulário_cep();
                }
            });
        }
        else {
            limpa_formulário_cep();
        }
    }
    else {
        limpa_formulário_cep();
    }
}), "Por favor, digite um CEP válido"
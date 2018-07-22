function limpa_formulário_cep() {
    $("#txtenderecoagencia").val("");
    $("#txtcidadeagencia").val("");
    $("#txtestadoagencia").val("");
}
$("#txtcepagencia").blur(function () {
    var cep = $(this).val().replace(/\D/g, '');
    if (cep != "") {
        var validacep = /^[0-9]{8}$/;
        if (validacep.test(cep)) {
            $("#txtendereco").val("...");
            $("#txtcidadeagencia").val("...");
            $("#txtestadoagencia").val("...");
            $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                if (!("erro" in dados)) {
                    $("#txtenderecoagencia").val(dados.logradouro);
                    $("#txtcidadeagencia").val(dados.localidade);
                    $("#txtestadoagencia").val(dados.uf);
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
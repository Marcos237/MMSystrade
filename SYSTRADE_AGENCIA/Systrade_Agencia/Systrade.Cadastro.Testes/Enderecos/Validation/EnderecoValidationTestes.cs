using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidades.Enderecos.Validations;
using Xunit;

namespace Systrade.Cadastro.Testes.Enderecos.Validation
{
    public class EnderecoValidationTestes
    {
        public Endereco endereco { get; set; }

        Guid agenciaid = Guid.NewGuid();
        Guid id = Guid.NewGuid();

        [Fact(DisplayName = "Endereco inconsistente para cadastro")]
        [Trait("Categoria", "Validar Endereco")]
        public void Endereco_Inapto_Cadastro()
        {
            endereco = new Endereco(agenciaid, id, "Nada", "R", "Nada","","0440","S","S");

            var validate = new EnderecoConsistenteParaCadastroValidation();

            var result = validate.Validate(endereco);
            Assert.False(validate.Validate(endereco).IsValid);
            Assert.Contains(result.Erros, e => e.Message == "A Cidade deve ter pelo menos 2 caracteres.");
            Assert.Contains(result.Erros, e => e.Message == "O Estado deve ter 2 caracteres.");
            Assert.Contains(result.Erros, e => e.Message == "O Logradouro deve ter pelo menos 2 caracteres.");
            Assert.Contains(result.Erros, e => e.Message == "O Número não pode ser nulo.");

        }
    }
}

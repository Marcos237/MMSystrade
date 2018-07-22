using Moq;
using System;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidades.Validations;
using Systrade.Dominio.Interfaces.Repository;
using Xunit;

namespace Systrade.Cadastro.Testes.Validation
{
    public class AgenciaConsistenteParaCadastroTestes
    {
        public Agencia agencia { get; set; }

        Guid agenciaid = Guid.NewGuid();

        [Fact(DisplayName = "Agencia está consistente para cadastro")]
        [Trait("Categoria", "Validar agencia Cadastro")]
        public void Agencia_Inapto_Cadastro()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "74.968.636/0001-68", "(11)5677-5967");
            var mock = new Mock<IAgenciaRepository>();
            mock.Setup(c => c.BuscarAgenciaCnpj(agencia.CNPJ.Codigo)).Returns(agencia);

            var validate = new AgenciaConsistenteParaCadastroValidation(mock.Object);

            var result = validate.Validate(agencia);
            Assert.False(validate.Validate(agencia).IsValid);
            Assert.Contains(result.Erros, e => e.Message == "CNPJ já cadastrado.");

        }
    }
}

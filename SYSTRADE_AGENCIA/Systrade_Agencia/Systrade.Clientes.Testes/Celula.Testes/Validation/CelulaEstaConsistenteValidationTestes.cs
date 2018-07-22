using Moq;
using System;
using Systrade.Clientes.Domain.Entidades;
using Systrade.Clientes.Domain.Entidades.Validation;
using Systrade.Clientes.Domain.Intefaces.Repository;
using Xunit;

namespace Systrade.Clientes.Testes.Testes.Validation
{
    public class CelulaEstaConsistenteValidationTestes
    {
        public Celula celula { get; set; }

        Guid id = Guid.NewGuid();
        Guid agenciaid = Guid.NewGuid();

        [Fact(DisplayName = "Celula está consistente para cadastro")]
        [Trait("Categoria", "Validar Celula")]
        public void Celula_Apto_Cadastro()
        {
            celula = new Celula(id, agenciaid, "Tabajara Sa");
            var mock = new Mock<ICelulaRepository>();
            mock.Setup(c => c.BuscarNomeCelula(null)).Returns(celula);
            var validate = new CelulaEstaConsistenteValidation(mock.Object);

            var result = validate.Validate(celula);
            Assert.DoesNotContain(result.Erros, e => e.Message == "Nome em tamanho incorreto.");
            Assert.DoesNotContain(result.Erros, e => e.Message == "Nome já cadastrado.");
        }

        [Fact(DisplayName = "Celula inconsistente para cadastro")]
        [Trait("Categoria", "Validar Celula")]
        public void Celula_Inapto_Cadastro()
        {
            celula = new Celula(id, agenciaid, "T");
            var mock = new Mock<ICelulaRepository>();
            mock.Setup(c => c.BuscarNomeCelula(celula.NomeCelula)).Returns(celula);
            var validate = new CelulaEstaConsistenteValidation(mock.Object);

            var result = validate.Validate(celula);
            Assert.Contains(result.Erros, e => e.Message == "Nome em tamanho incorreto.");
            Assert.Contains(result.Erros, e => e.Message == "Nome já cadastrado.");
        }
    }
}

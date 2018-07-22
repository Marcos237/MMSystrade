using Moq;
using System;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Specification;
using Systrade.Dominio.Interfaces.Repository;
using Xunit;

namespace Systrade.Cadastro.Testes.Specifications
{
    public class CNPJUnicoSpecificationTestes
    {

        public Agencia agencia { get; set; }

        Guid agenciaid = Guid.NewGuid();

        [Fact(DisplayName = "CNPJ é único")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_EhUnico_Correto()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "", "(11)5677-5967");
            var mock = new Mock<IAgenciaRepository>();

            mock.Setup(c => c.BuscarAgenciaCnpj(null)).Returns(agencia);
            var cnpj = new CnpjUnicoSpecification(mock.Object);

            Assert.True(cnpj.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "CNPJ não é único")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_EhUnico_Incorreto()
        {
            var mock = new Mock<IAgenciaRepository>();
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "77.962.261/0001-17", "(11)5677-5967");

            mock.Setup(c => c.BuscarAgenciaCnpj(agencia.CNPJ.Codigo)).Returns(agencia);
            var cnpj = new CnpjUnicoSpecification(mock.Object);

            Assert.False(cnpj.IsSatisfiedBy(agencia));
        }
    }
}

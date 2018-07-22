using Xunit;
using Systrade.Clientes.Domain.Entidades;
using System;
using Systrade.Clientes.Domain.Entidades.Specifications;

namespace Systrade.Clientes.Testes.Testes.Entidade
{
    public class CelulaSpecificationTestes
    {
        public Celula celula { get; set; }

        Guid id = Guid.NewGuid();
        Guid agenciaid = Guid.NewGuid();


        [Fact(DisplayName = "Nome da Celula com Mais de 2 caracteres")]
        [Trait("Categoria", "Validar Celula")]
        public void ValidarNomesFormatoCorretoTeste()
        {
            celula = new Celula(id, agenciaid, "Tabajara");

            var nomecelula = new NomeCelulaTamanhoCorretoSpecification();
            Assert.True(nomecelula.IsSatisfiedBy(celula));

        }


        [Fact(DisplayName = "Nome da celula com menos de 2 caracteres")]
        [Trait("Categoria", "Validar Celula")]
        public void ValidarNomesFormatoIncorretoTeste()
        {
            celula = new Celula(id, agenciaid, "T");

            var nomecelula = new NomeCelulaTamanhoCorretoSpecification();
            Assert.False(nomecelula.IsSatisfiedBy(celula));

        }
    }
}

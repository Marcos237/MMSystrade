using System;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Entidades.Specification;
using Xunit;

namespace Systrade.Cadastro.Testes.Specifications
{
    public class AgenciaScopesTestes
    {
        public Agencia agencia { get; set; }

        Guid agenciaid = Guid.NewGuid();

        [Fact(DisplayName = "CNPJ Válido Specifications")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_Formato_Correto()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "47.293.567/0001-67", "(11)5677-5967");
            var cnpj = new CnpjFormatoCorretoSpecification();

            Assert.True(cnpj.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "CNPJ Inválido Specifications")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_Formato_Incorreto()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "47.2/0001-67", "(11)5677-5967");
            var cnpj = new CnpjFormatoCorretoSpecification();

            Assert.False(cnpj.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "CNPJ Tamanho Válido")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_Tamanho_Correto()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "47.293.567/0001-67", "(11)5677-5967");
            var cnpj = new CnpjTamanhoIncorretoSpecification();
            Assert.True(cnpj.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "CNPJ Tamanho Inválido")]
        [Trait("Categoria", "Validar CNPJ")]
        public void CNPJ_Tamanho_Incorreto()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "47.293.567/0001-67000", "(11)5677-5967");
            var cnpj = new CnpjTamanhoIncorretoSpecification();
            Assert.False(cnpj.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "Nome Fantasia Formato Válido")]
        [Trait("Categoria", "Validar Nome Fantasia")]
        public void NomeFantasia_Apto_Cadastro()
        {
            agencia = new Agencia(agenciaid, "Tabajara", "Tabajara SA", "47.293.567/0001-67000", "(11)5677-5967");
            var nome = new NomeFantasiaFormatoCorretoSpecification();
            Assert.True(nome.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "Nome Fantasia Formato Inválido")]
        [Trait("Categoria", "Validar Nome Fantasia")]
        public void NomeFantasia_Inapto_Cadastro()
        {
            agencia = new Agencia(agenciaid, "T", "Tabajara SA", "47.293.567/0001-67000", "(11)5677-5967");
            var nome = new NomeFantasiaFormatoCorretoSpecification();
            Assert.False(nome.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "Razão Social Formato Válido")]
        [Trait("Categoria", "Validar Razão Social")]
        public void RazaoSocial_Apto_Correto()
        {
            agencia = new Agencia(agenciaid, "T", "Tabajara SA", "47.293.567/0001-67000", "(11)5677-5967");
            var nome = new RazaoSocialFormatoSpecification();
            Assert.True(nome.IsSatisfiedBy(agencia));
        }

        [Fact(DisplayName = "Razão Social Formato Inválido")]
        [Trait("Categoria", "Validar Razão Social")]
        public void NomeFantasia_Inapto_Falso()
        {
            agencia = new Agencia(agenciaid, "T", "T", "47.293.567/0001-67000", "(11)5677-5967");
            var nome = new RazaoSocialFormatoSpecification();
            Assert.False(nome.IsSatisfiedBy(agencia));
        }
    }
}

using System;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidades.Enderecos.Specifications;
using Xunit;

namespace Systrade.Cadastro.Testes.Enderecos.Specifications
{
    public class EnderecoSpecification
    {
        public Endereco endereco { get; set; }
        Guid id = Guid.NewGuid();
        Guid enderecoid = Guid.NewGuid();

        [Fact(DisplayName = "Cep Válido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void CEP_NaoEhNulo_Correto()
        {

            var _cep = new CEP("04403-060");
            var cep = new CepTamanhoCorretoSpecification();

            Assert.True(cep.IsSatisfiedBy(_cep));
        }

        [Fact(DisplayName = "Logradouro Válido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Logradouro_NaoEhNulo_Correto()
        {

            endereco = new Endereco(id, enderecoid, "","Rua Tabajara","", "140", "04403-060", "São Paulo","SP");
            var logradouro = new LogradouroNaoPodeSerNuloSpecification();

            Assert.True(logradouro.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Logradouro Inválido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Logradouro_NaoEhNulo_False()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "140", "04403-060", "São Paulo", "SP");
            var logradouro = new LogradouroNaoPodeSerNuloSpecification();

            Assert.False(logradouro.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Número Válido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Numero_NaoEhNulo_Correto()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "140", "04403-060", "São Paulo", "SP");
            var numero = new NumeroNaoPodeSerNuloSpecification();

            Assert.True(numero.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Número Inválido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Numero_NaoEhNulo_False()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "", "04403-060", "São Paulo", "SP");
            var numero = new NumeroNaoPodeSerNuloSpecification();
            Assert.False(numero.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Cidade Válido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Cidade_NaoEhNulo_Correto()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "", "04403-060", "São Paulo", "SP");
            var cidade = new CidadeNaoPodeSerNuloSpecification();
            Assert.True(cidade.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Cidade Inválido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Cidade_NaoEhNulo_Falso()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "", "04403-060", "S", "SP");
            var cidade = new CidadeNaoPodeSerNuloSpecification();
            Assert.False(cidade.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Estado Válido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Estado_NaoEhNulo_Correto()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "", "04403-060", "S", "SP");
            var estado = new EstadoNaoPodeSerNuloSpecification();
            Assert.True(estado.IsSatisfiedBy(endereco));
        }

        [Fact(DisplayName = "Estado Inválido")]
        [Trait("Categoria", "Validar Enderecos")]
        public void Estado_NaoEhNulo_False()
        {
            endereco = new Endereco(id, enderecoid, "", "R", "", "", "04403-060", "S", "SPpp");
            var estado = new EstadoNaoPodeSerNuloSpecification();
            Assert.False(estado.IsSatisfiedBy(endereco));
        }
    }
}

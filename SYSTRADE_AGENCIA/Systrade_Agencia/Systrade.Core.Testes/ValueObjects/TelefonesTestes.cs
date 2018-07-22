using Systrade.Core.ValueObjects;
using Xunit;

namespace Systrade.Core.Testes.ValueObjects
{
    public class TelefonesTestes
    {
        [Fact(DisplayName = "Telefone fixo em formato correto")]
        [Trait("Telefone Fixo", "Validar Telefone Fixo")]
        public void TelefoneFixo_ValidarTelefoneFixo_TelefoneFixoFormatoCorreto()
        {
            var numero = "1156775967";
            var result = Telefones.ValidarTelefoneFixo(numero);
            Assert.Equal(result, numero);
        }

        [Fact(DisplayName = "Telefone fixo em formato incorreto")]
        [Trait("Telefone Fixo", "Validar Telefone Fixo")]
        public void TelefoneFixo_ValidarTelefoneFixo_TelefoneFixoFormatoIncorreto()
        {
            var numero = "1156773";
            var result = Telefones.ValidarTelefoneFixo(numero);
            Assert.Equal(result, numero);
        }

        [Fact(DisplayName = "Telefone Fixo com máscaras")]
        [Trait("Telefone Fixo", "Validar Telefone Fixo")]
        public void TelefoneFixo_ValidarTelefoneFixo_TelefoneFixoComMascaras()
        {
            var numero = "(11)5677-5967";
            var result = Telefones.ValidarTelefoneFixo(numero);
            Assert.NotEqual(result, numero);
        }

        [Fact(DisplayName = "Celular em formato correto")]
        [Trait("Celular", "Validar Celular")]
        public void Celular_ValidarCelular_CelularFormatoCorreto()
        {
            var numero = "11976337887";
            var result = Telefones.ValidarCelular(numero);
            Assert.True(result);
        }

        [Fact(DisplayName = "Celular em formato incorreto")]
        [Trait("Celular", "Validar Celular")]
        public void Celular_ValidarCelular_CelularFormatoIncorreto()
        {
            var numero = "1197633788";
            var result = Telefones.ValidarCelular(numero);
            Assert.False(result);
        }

        [Fact(DisplayName = "Celular em com máscaras")]
        [Trait("Celular", "Validar Celular")]
        public void Celular_ValidarCelular_CelularComMascaras()
        {
            var numero = "(11)97633-7887";
            var semmascara = "11976337887";
            var result = Telefones.RetornarCelular(numero);
            Assert.Equal(result, semmascara);
        }
    }
}

using Systrade.Core.ValueObjects;
using Xunit;

namespace Systrade.Core.Testes.ValueObjects
{
    public class CpfTestes
    {
        [Fact(DisplayName = "CPF em formato correto")]
        [Trait("CPF", "Validar CPF")]
        public void CPF_ValidarCPF_CPEFormatoCorreto()
        {
            var numero = "30350080860";
            var result = CPF.Validar(numero);
            Assert.True(result);
        }

        [Fact(DisplayName = "CPF em formato incorreto")]
        [Trait("CPF", "Validar CPF")]
        public void CPF_ValidarCPF_CPFFormatoIncorreto()
        {
            var numero = "303500808";
            var result = CPF.Validar(numero);
            Assert.False(result);
        }

        [Fact(DisplayName = "CPF com máscaras")]
        [Trait("CPF", "Validar CPF")]
        public void CPF_ValidarCPF_CPFComMascaras()
        {
            var numero = "303.500.808-60";
            var numerosemmascara = "30350080860";
            var result = CPF.LimparCpf(numero);
            Assert.Equal(result,numerosemmascara);
        }
    }
}

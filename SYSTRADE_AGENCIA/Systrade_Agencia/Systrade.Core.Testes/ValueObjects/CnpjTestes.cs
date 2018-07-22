using Systrade.Core.ValueObjects;
using Xunit;

namespace Systrade.Core.Testes.ValueObjects
{
    public class CnpjTestes
    {
        [Fact(DisplayName = "Cnpj em formato correto")]
        [Trait("CNPJ", "Validar CNPJ")]
        public void CPF_ValidarCPF_CnpjEhValido()
        {
            var numero = "81667443000132";
            var result = CNPJ.Validar(numero);
            Assert.True(result);
        }

        [Fact(DisplayName = "Cnpj em formato incorreto")]
        [Trait("CNPJ", "Validar CNPJ")]
        public void CPF_ValidarCPF_CnpjInvalido()
        {
            var numero = "21857261000103";
            var result = CNPJ.Validar(numero);
            Assert.False(result);
        }

        [Fact(DisplayName = "Cnpj com máscaras")]
        [Trait("CNPJ", "Validar CNPJ")]
        public void CPF_ValidarCPF_CPFComMascaras()
        {
            var numero = "21.857.261/0001-00";
            var numerosemmascara = "21857261000100";
            var result = CNPJ.LimparCnpj(numero);
            Assert.Equal(result, numerosemmascara);
        }
    }
}

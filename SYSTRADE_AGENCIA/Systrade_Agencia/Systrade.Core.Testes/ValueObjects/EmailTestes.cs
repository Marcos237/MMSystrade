using Systrade.Core.ValueObjects;
using Xunit;

namespace Systrade.Core.Testes.ValueObjects
{
    public class EmailTestes
    {
        [Fact(DisplayName = "Email em formato Correto")]
        [Trait("Email", "Validar Email")]
        public void Email_ValidarEmail_EmailFormatoCorreto()
        {
            var endereco = "marcos@marcos.com";
            var result = Email.IsValid(endereco);
            Assert.True(result);
        }

        [Fact(DisplayName = "Email em formato Incorreto")]
        [Trait("Email", "Validar Email")]
        public void Email_ValidarEmail_EmailFormatoIncorreto()
        {
            var endereco = "marcosmarcos.com";
            var result = Email.IsValid(endereco);
            Assert.False(result);
        }
    }
}

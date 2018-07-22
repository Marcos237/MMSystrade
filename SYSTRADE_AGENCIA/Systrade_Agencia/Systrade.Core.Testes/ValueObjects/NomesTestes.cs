using System;
using Systrade.Core.ValueObjects;
using Xunit;

namespace Systrade.Core.Testes
{
    public class NomesTestes
    {
        [Fact(DisplayName = "Nomes e sobrenomes com mais de 2 caracteres")]
        [Trait("Nomes", "Validar Nomes e Sobrenomes")]
        public void Nomes_ValidarNomesSobrenomes_NomesSobrnomesDevemTerMaisDeDoisCaracteres()
        {
            var nome = "Marcos";
            var result = Nomes.ValidarNomes(nome);
            Assert.True(result);
        }

        [Fact(DisplayName = "Nomes e sobrenomes com menos de 2 carateres.")]
        [Trait("Nomes", "Validar Nomes e Sobrenomes")]
        public void Nomes_ValidarNomesSobrenomes_NomesSobrnomesComMenosDeDoisCaracteres()
        {
            var nome = "M";
            var result = Nomes.ValidarNomes(nome);
            Assert.False(result);
        }
    }
}

using Systrade.Core.ValueObjects;

namespace Systrade.Clientes.Domain.Entidades.Celulas
{
    public static class CelulasScopes
    {
        public static bool DefinirNomeCelulaEhValido(this Celula celula, string nomecelula)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nomecelula, "O Nome da Célula é obrigatório."),
                AssertionConcern.AssertLength(nomecelula, 2, 150, "O Nome da Célula deve conter entre 2 e 150 caracteres.")
            );
        }
    }
}

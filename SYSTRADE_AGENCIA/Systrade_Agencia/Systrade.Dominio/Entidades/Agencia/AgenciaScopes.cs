using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Entidades
{
    public static class AgenciaScopes
    {
        public static bool DefinirNomeFAntasiaScopeValido(this Agencia agencia, string nomefantasia)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nomefantasia ,"O Nome Fantasia é obrigatório."),
                AssertionConcern.AssertLength(nomefantasia, 2, 150, "O Nome Fantasia deve conter entre 2 e 150 caracteres.")
            );
        }


        public static bool DefinirRazaoSocialScopeEhValido(this Agencia agencia, string razaosocial)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(razaosocial, "A Razão Social é obrigatória."),
                AssertionConcern.AssertLength(razaosocial, 2, 150, "A Razão Social deve conter entre 2 e 150 caracteres.")
            );
        }
        public static bool DefinirCnpjScopeEhValido(this Agencia agencia, string cnpj)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cnpj, "O CNPJ é obrigatório."),
                AssertionConcern.AssertLength(cnpj, 14, 14, "O CNPJ deve conter 14 caracteres.")
            );
        }
    }
}
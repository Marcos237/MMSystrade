using Systrade.Core.ValueObjects;

namespace Systrade.Dominio.Enderecos.Entidades
{
    public static class EnderecoScopes
    {
        public static bool DefinirCEPScopeEhValido(this Endereco endereco, string cep)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(CEP.ObterCepFormatado(cep), "O CEP é obrigatório.")
            );
        }


        public static bool DefinirLogradouroScopeEhValido(this Endereco endereco, string logradouro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(logradouro, "O logradouro é obrigatório."),
                AssertionConcern.AssertLength(logradouro,2, 256, "O logradouro deve conter entre 2 e 256 caracteres.")
            );
        }
        public static bool DefinirNumeroScopeEhValido(this Endereco endereco, string numero)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(numero, "O número é obrigatório."),
                AssertionConcern.AssertLength(numero, 2, 6, "O logradouro deve conter entre 1 e 6 caracteres.")
            );
        }

        public static bool DefinirCidadeScopeEhValido(this Endereco endereco, string cidade)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cidade, "A cidade é obrigatório."),
                AssertionConcern.AssertLength(cidade, 2, 256, "A Cidade deve conter entre 2 e 256 caracteres.")
            );
        }

        public static bool DefinirEstadoScopeEhValido(this Endereco endereco, string estado)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(estado, "O Estado é obrigatório."),
                AssertionConcern.AssertLength(estado, 2, 2, "A Cidade deve conter entre 2 e 256 caracteres.")
            );
        }
    }
}
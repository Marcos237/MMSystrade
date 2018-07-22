using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Dominio.Entidades.Enderecos.Specifications
{
    public class CidadeNaoPodeSerNuloSpecification : ISpecification<Endereco>
    {
        public bool IsSatisfiedBy(Endereco endereco)
        {
            return Nomes.ValidarNomes(endereco.Cidade);
        }
    }
}

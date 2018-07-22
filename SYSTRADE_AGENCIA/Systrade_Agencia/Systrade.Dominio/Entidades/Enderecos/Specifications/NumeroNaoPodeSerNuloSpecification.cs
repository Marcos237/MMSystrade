using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Dominio.Entidades.Enderecos.Specifications
{
    public class NumeroNaoPodeSerNuloSpecification : ISpecification<Endereco>
    {
        public bool IsSatisfiedBy(Endereco endereco)
        {
            if (endereco.Numero.Length == 0 & string.IsNullOrEmpty(endereco.Numero))
                return false;
            else
                return true;
        }
    }
}

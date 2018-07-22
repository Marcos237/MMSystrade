using DomainValidation.Interfaces.Specification;
using System;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Dominio.Entidades.Enderecos.Specifications
{
    public class EstadoNaoPodeSerNuloSpecification : ISpecification<Endereco>
    {
        public bool IsSatisfiedBy(Endereco endereco)
        {
            if (!String.IsNullOrEmpty(endereco.Estado) & endereco.Estado.Length == 2)
                return true;
            else
                return false;
        }
    }
}

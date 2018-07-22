using DomainValidation.Interfaces.Specification;
using System;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Dominio.Entidades.Enderecos.Specifications
{
    public class CepTamanhoCorretoSpecification : ISpecification<CEP>
    {
        public bool IsSatisfiedBy(CEP cep)
        {
            var result = !String.IsNullOrEmpty(cep.CepCod);
            return result;
        }
    }
}

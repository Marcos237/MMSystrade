using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Entidades.Specification
{
    public class CnpjTamanhoIncorretoSpecification : ISpecification<Agencia>
    {
        public bool IsSatisfiedBy(Agencia agencia)
        {
            if (agencia.CNPJ.Codigo.Length == 14)
                return true;
            else
                return false;
        }
    }
}

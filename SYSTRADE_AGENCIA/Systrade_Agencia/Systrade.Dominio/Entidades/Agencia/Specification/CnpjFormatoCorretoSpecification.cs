using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Entidades.Specification
{
    public class CnpjFormatoCorretoSpecification : ISpecification<Agencia>
    {
        public bool IsSatisfiedBy(Agencia entity)
        {
            return CNPJ.Validar(entity.CNPJ.Codigo);
        }
    }
}

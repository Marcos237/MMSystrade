using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Entidades.Specification
{
    public class RazaoSocialFormatoSpecification : ISpecification<Agencia>
    {
        public bool IsSatisfiedBy(Agencia agencia)
        {
            return Nomes.ValidarNomes(agencia.RazaoSocial);
        }
    }
}

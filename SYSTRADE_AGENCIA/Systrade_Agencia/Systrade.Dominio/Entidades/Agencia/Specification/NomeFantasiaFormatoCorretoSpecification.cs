using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Entidades.Specification
{
    public class NomeFantasiaFormatoCorretoSpecification : ISpecification<Agencia>
    {
        public bool IsSatisfiedBy(Agencia agencia)
        {
            return Nomes.ValidarNomes(agencia.NomeFantasia);
        }
    }
}

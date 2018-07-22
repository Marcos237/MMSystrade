using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;

namespace Systrade.Clientes.Domain.Entidades.Specifications
{
    public class NomeCelulaTamanhoCorretoSpecification : ISpecification<Celula>
    {
        public bool IsSatisfiedBy(Celula entity)
        {
            return Nomes.ValidarNomes(entity.NomeCelula);
        }
    }
}

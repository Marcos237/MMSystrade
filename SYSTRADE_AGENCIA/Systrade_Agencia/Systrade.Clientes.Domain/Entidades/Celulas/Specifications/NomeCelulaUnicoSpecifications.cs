using DomainValidation.Interfaces.Specification;
using Systrade.Clientes.Domain.Intefaces.Repository;

namespace Systrade.Clientes.Domain.Entidades.Celulas.Specifications
{
    public class NomeCelulaUnicoSpecifications : ISpecification<Celula>
    {
        private readonly ICelulaRepository _celularepository;

        public NomeCelulaUnicoSpecifications(ICelulaRepository celularepository)
        {
            _celularepository = celularepository;
        }

        public bool IsSatisfiedBy(Celula entity)
        {
            return _celularepository.BuscarNomeCelula(entity.NomeCelula) == null;
        }
    }
}

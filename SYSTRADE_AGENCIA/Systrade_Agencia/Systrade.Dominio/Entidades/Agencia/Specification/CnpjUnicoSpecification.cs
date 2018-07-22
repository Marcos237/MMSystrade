using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Interfaces.Repository;

namespace Systrade.Dominio.Entidade.Specification
{
    public class CnpjUnicoSpecification : ISpecification<Agencia>
    {
        private readonly IAgenciaRepository _agenciarepositorio;

        public CnpjUnicoSpecification(IAgenciaRepository agenciarepositorio)
        {
            _agenciarepositorio = agenciarepositorio;
        }

        public bool IsSatisfiedBy(Agencia agencia)
        {
            return _agenciarepositorio.BuscarAgenciaCnpj(agencia.CNPJ.Codigo) == null;
        }
    }
}

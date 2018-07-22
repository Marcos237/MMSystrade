using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;

namespace Systrade.Dominio.Specifications
{
    public class EmailUnicoSpecification : ISpecification<AgenciaUsuario>
    {
        private readonly IAgenciaUsuarioRepository _agenciaUsuarioRepositorio;

        public EmailUnicoSpecification(IAgenciaUsuarioRepository agenciaUsuarioRepositorio)
        {
            _agenciaUsuarioRepositorio = agenciaUsuarioRepositorio;
        }

        public bool IsSatisfiedBy(AgenciaUsuario agencia)
        {
            return _agenciaUsuarioRepositorio.BuscarAgenciaUsuarioEmail(agencia.Email.Endereco) == null;
        }
    }
}

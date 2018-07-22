using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;

namespace Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios
{
    public class EmailUnicoEditarSpecification : ISpecification<AgenciaUsuario>
    {
        private readonly IAgenciaUsuarioRepository _agenciaUsuarioRepositorio;

        public EmailUnicoEditarSpecification(IAgenciaUsuarioRepository agenciaUsuarioRepositorio)
        {
            _agenciaUsuarioRepositorio = agenciaUsuarioRepositorio;
        }

        public bool IsSatisfiedBy(AgenciaUsuario agencia)
        {
            return _agenciaUsuarioRepositorio.BuscarAgenciaUsuarioEmailParaEditar(agencia.Email.Endereco, agencia.UsuarioId.ToString()) == null;
        }
    }
}

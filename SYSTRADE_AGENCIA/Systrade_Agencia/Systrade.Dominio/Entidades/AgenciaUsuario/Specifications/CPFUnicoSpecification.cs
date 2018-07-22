using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;

namespace Systrade.Dominio.Specifications
{
    public class CPFUnicoSpecification:ISpecification<AgenciaUsuario>
    {
        private readonly IAgenciaUsuarioRepository _agenciausuariorepositorio;

        public CPFUnicoSpecification(IAgenciaUsuarioRepository agenciaUsuarioRepositorio)
        {
            _agenciausuariorepositorio = agenciaUsuarioRepositorio;
        }

        public bool IsSatisfiedBy(AgenciaUsuario agenciaUsuario)
        {
            return _agenciausuariorepositorio.BuscarAgenciaUsuarioCpf(agenciaUsuario.CPF.Codigo) == null;
        }
    }
}

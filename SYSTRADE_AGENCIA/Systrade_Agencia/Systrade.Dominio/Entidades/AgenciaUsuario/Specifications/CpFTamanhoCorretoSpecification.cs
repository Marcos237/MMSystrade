using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios
{
    public class CpFTamanhoCorretoSpecification : ISpecification<AgenciaUsuario>
    {
        public bool IsSatisfiedBy(AgenciaUsuario entity)
        {
            if (entity.CPF.Codigo.Length == 11)
                return true;
            else
                return false;
        }
    }
}

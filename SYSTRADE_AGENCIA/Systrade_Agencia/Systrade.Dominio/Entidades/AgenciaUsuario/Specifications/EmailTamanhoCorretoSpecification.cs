using DomainValidation.Interfaces.Specification;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios
{
    public class EmailTamanhoCorretoSpecification : ISpecification<AgenciaUsuario>
    {
        public bool IsSatisfiedBy(AgenciaUsuario entity)
        {
            if ((entity.Email.Endereco.Length < 254) & (entity.Email.Endereco.Length > 5))
                return true;
            else
                return false;
        }
    }
}

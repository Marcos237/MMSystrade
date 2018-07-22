using DomainValidation.Interfaces.Specification;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios
{
    public class EmailFormatoCorretoSpecification : ISpecification<AgenciaUsuario>
    {
        public bool IsSatisfiedBy(AgenciaUsuario entity)
        {
            return Email.IsValid(entity.Email.Endereco);
        }
    }
}

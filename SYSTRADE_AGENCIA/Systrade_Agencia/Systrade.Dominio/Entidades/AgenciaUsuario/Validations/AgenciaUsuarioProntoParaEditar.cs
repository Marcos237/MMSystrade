using DomainValidation.Validation;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios;

namespace Systrade.Dominio.Usuarios.Validations.AgenciaUsuarios
{
    public class AgenciaUsuarioProntoParaEditar : Validator<AgenciaUsuario>
    {
        public AgenciaUsuarioProntoParaEditar(IAgenciaUsuarioRepository agenciausuariorepository)
        {
            var emailDuplicado = new EmailUnicoEditarSpecification(agenciausuariorepository);
            var celularTamanho = new CelularTamanhoCorretoSpecification();
            var celularFormato = new CelularFormatoCorretoSpecification();
            var emailTamanho = new EmailTamanhoCorretoSpecification();
            var emailFormato = new EmailFormatoCorretoSpecification();
            var nomeFormato = new NomeFormatoCorretoSpecification();


            base.Add("emailDuplicado", new Rule<AgenciaUsuario>(emailDuplicado, "Email já cadastrado."));
            base.Add("emailTamanho", new Rule<AgenciaUsuario>(emailTamanho, "O Email deve ter entre 5 e 254 caracteres."));
            base.Add("emailFormato", new Rule<AgenciaUsuario>(emailFormato, "Email com formato incorreto."));
            base.Add("celularTamanho", new Rule<AgenciaUsuario>(celularTamanho, "Celular com tamanho incorreto."));
            base.Add("celularFormato", new Rule<AgenciaUsuario>(celularFormato, "Celular com formato incorreto."));
            base.Add("nomeFormato", new Rule<AgenciaUsuario>(nomeFormato, "O nome deve ter entre 2 e 150 caracteres."));

        }
    }
}

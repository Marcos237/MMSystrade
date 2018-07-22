using DomainValidation.Validation;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Specifications;
using Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios;

namespace Systrade.Dominio.Validations
{
    public class AgenciaUsuarioProntoParaCadastroValidation : Validator<AgenciaUsuario>
    {
        public AgenciaUsuarioProntoParaCadastroValidation(IAgenciaUsuarioRepository agenciausuariorepository)
        {
            var cpfDuplicado = new CPFUnicoSpecification(agenciausuariorepository);
            var emailDuplicado = new EmailUnicoSpecification(agenciausuariorepository);
            var cpfFormato = new CpfFormatoCorretoSpecification();
            var cpfTamanho = new CpFTamanhoCorretoSpecification();
            var celularTamanho = new CelularTamanhoCorretoSpecification();
            var celularFormato = new CelularFormatoCorretoSpecification();
            var emailTamanho = new EmailTamanhoCorretoSpecification();
            var emailFormato = new EmailFormatoCorretoSpecification();
            var nomeFormato = new NomeFormatoCorretoSpecification();

            base.Add("cpfDuplicado", new Rule<AgenciaUsuario>(cpfDuplicado, "CPF já cadastrado."));
            base.Add("cpfFormato", new Rule<AgenciaUsuario>(cpfFormato, "CPF com formato incorreto."));
            base.Add("cpfTamanho", new Rule<AgenciaUsuario>(cpfTamanho, "CPF com tamanho incorreto."));
            base.Add("emailDuplicado", new Rule<AgenciaUsuario>(emailDuplicado, "Email já cadastrado."));
            base.Add("emailTamanho", new Rule<AgenciaUsuario>(emailTamanho, "O Email deve ter entre 5 e 254 caracteres."));
            base.Add("emailFormato", new Rule<AgenciaUsuario>(emailFormato, "Email com formato incorreto."));
            base.Add("celularTamanho", new Rule<AgenciaUsuario>(celularTamanho, "Celular com tamanho incorreto."));
            base.Add("celularFormato", new Rule<AgenciaUsuario>(celularFormato, "Celular com formato incorreto."));
            base.Add("nomeFormato", new Rule<AgenciaUsuario>(nomeFormato, "O nome deve ter entre 2 e 150 caracteres."));

        }
    }
}

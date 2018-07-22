using Moq;
using System;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Validations;
using Xunit;

namespace Systrade.Cadastro.Testes.AgenciaUsuarios.Validations
{
    public class AgenciaUsuarioValidationTestes
    {
        public AgenciaUsuario agenciausuario { get; set; }

        Guid agenciaid = Guid.NewGuid();
        Guid usuarioId = Guid.NewGuid();


        [Fact(DisplayName = "Usuário está consistente para cadastro")]
        [Trait("Categoria", "Validar Agencia_Usuário Cadastro")]
        public void AgenciaUsuario_Inapto_Cadastro()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "M", "Lima", "300080860", "m", "1197887", "1156775967", "Nada");
            var mock = new Mock<IAgenciaUsuarioRepository>();
            mock.Setup(c => c.BuscarAgenciaUsuarioCpf(agenciausuario.CPF.Codigo)).Returns(agenciausuario);
            mock.Setup(c => c.BuscarAgenciaUsuarioCpf(agenciausuario.Email.Endereco)).Returns(agenciausuario);

            var validate = new AgenciaUsuarioProntoParaCadastroValidation(mock.Object);

            var result = validate.Validate(agenciausuario);
            Assert.False(validate.Validate(agenciausuario).IsValid);
            Assert.Contains(result.Erros, e => e.Message == "CPF já cadastrado.");
            Assert.Contains(result.Erros, e => e.Message == "CPF com formato incorreto.");
            Assert.Contains(result.Erros, e => e.Message == "O Email deve ter entre 5 e 254 caracteres.");
            Assert.Contains(result.Erros, e => e.Message == "Email com formato incorreto.");
            Assert.Contains(result.Erros, e => e.Message == "Celular com tamanho incorreto.");
            Assert.Contains(result.Erros, e => e.Message == "Celular com formato incorreto.");
            Assert.Contains(result.Erros, e => e.Message == "O nome deve ter entre 2 e 150 caracteres.");


        }
    }
}

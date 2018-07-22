using System;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Usuarios.Specifications.AgenciaUsuarios;
using Xunit;

namespace Systrade.Cadastro.Testes.AgenciaUsuarios.Specifications
{

    public class AgenciaUsuarioSpecificationTestes
    {
        public AgenciaUsuario agenciausuario { get; set; }


        Guid agenciaid = Guid.NewGuid();
        Guid usuarioId = Guid.NewGuid();

        [Fact(DisplayName = "CPF Tamanho Válido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Tamanho_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid,usuarioId.ToString(),"Marcos","Lima","30350080860","marcslima237@outlook.com","11976337887","1156775967","Nada");
            var cpf = new CpFTamanhoCorretoSpecification();

            Assert.True(cpf.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "CPF Formato Válido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Formato_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "30350080860", "marcslima237@outlook.com", "11976337887", "1156775967", "Nada");
            var cpf = new CpfFormatoCorretoSpecification();

            Assert.True(cpf.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "CPF Formato Inválido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Formato_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "marcslima237@outlook.com", "11976337887", "1156775967", "Nada");
            var cpf = new CpfFormatoCorretoSpecification();

            Assert.False(cpf.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Email Formato Válido Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Email_Formato_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "marcslima237@outlook.com", "11976337887", "1156775967", "Nada");
            var email = new EmailFormatoCorretoSpecification();

            Assert.True(email.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Email Formato Inválido Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Email_Formato_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "mm.com", "11976337887", "1156775967", "Nada");
            var email = new EmailFormatoCorretoSpecification();

            Assert.False(email.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Email Tamanho Válido Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Email_Tamanho_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "marcos@marcos.com", "11976337887", "1156775967", "Nada");
            var email = new EmailFormatoCorretoSpecification();

            Assert.True(email.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Email Tamanho Inválido Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Email_Tamanho_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "11976337887", "1156775967", "Nada");
            var email = new EmailFormatoCorretoSpecification();

            Assert.False(email.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Celular Tamanho Válido Specifications")]
        [Trait("Categoria", "Validar Celular")]
        public void Celular_Tamanho_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "11976337887", "1156775967", "Nada");
            var celular = new CelularTamanhoCorretoSpecification();

            Assert.True(celular.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Celular Tamanho Inválido Specifications")]
        [Trait("Categoria", "Validar celular")]
        public void Celular_Tamanho_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "76337887", "1156775967", "Nada");
            var celular = new CelularTamanhoCorretoSpecification();

            Assert.False(celular.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Celular Formato Válido Specifications")]
        [Trait("Categoria", "Validar Celular")]
        public void Celular_Formato_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "11976337887", "1156775967", "Nada");
            var celular = new CelularTamanhoCorretoSpecification();

            Assert.True(celular.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Celular Formato Inválido Specifications")]
        [Trait("Categoria", "Validar celular")]
        public void Celular_Formato_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "7@@@555", "1156775967", "Nada");
            var celular = new CelularTamanhoCorretoSpecification();

            Assert.False(celular.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Nome Formato Válido Specifications")]
        [Trait("Categoria", "Validar Nome")]
        public void Nome_Formato_Correto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "Marcos", "Lima", "3035A00800", "m@m", "7@@@555", "1156775967", "Nada");
            var nome = new NomeFormatoCorretoSpecification();

            Assert.True(nome.IsSatisfiedBy(agenciausuario));
        }

        [Fact(DisplayName = "Nome Formato Inválido Specifications")]
        [Trait("Categoria", "Validar Nome")]
        public void Nome_Formato_InCorreto()
        {
            agenciausuario = new AgenciaUsuario(agenciaid, usuarioId.ToString(), "M", "Lima", "3035A00800", "m@m", "7@@@555", "1156775967", "Nada");
            var nome = new NomeFormatoCorretoSpecification();

            Assert.False(nome.IsSatisfiedBy(agenciausuario));
        }
    }
}

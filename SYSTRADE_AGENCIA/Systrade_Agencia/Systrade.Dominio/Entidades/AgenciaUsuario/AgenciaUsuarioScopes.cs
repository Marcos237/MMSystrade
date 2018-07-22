using Systrade.Core.ValueObjects;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Dominio.Scopes
{
    public static class AgenciaUsuarioScopes
    {

        public static bool DefinirSenhaAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, string password, string confirmPassword)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertNotNullOrEmpty(confirmPassword, "A confirmação de senha é obrigatória"),
                AssertionConcern.AssertAreEquals(password, confirmPassword, "As senhas são iguais")
            );
        }

        public static bool ValidarSenhaAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, string password)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertLength(password, AgenciaUsuario.SenhaMinLength, AgenciaUsuario.SenhaMaxLength, "O tamanho da senha não corresponde")
            );
        }

        public static bool DefinirEmailAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, "E-mail em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, "O e-mail obrigatório"),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), "E-mail em formato inválido")
            );
        }

        public static bool DefinirCPFAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, CPF cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(cpf.Codigo, CPF.ValorMaxCpf, "CPF em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, "O Cpf é obrigatório"),
                AssertionConcern.AssertTrue(CPF.Validar(cpf.Codigo), "CPF em formato inválido")
            );
        }

        public static bool DefinirNomeAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertTrue(Nomes.ValidarNomes(nome), "Nome em formato inválido")
            );
        }

        public static bool DefinirCelularAgenciaUsuarioScopeEhValido(this AgenciaUsuario agenciausuario, string celular)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(celular, "O celular é obrigatório"),
                AssertionConcern.AssertTrue(Telefones.ValidarCelular(celular), "Celular em formato inválido")
            );
        }
    }
}
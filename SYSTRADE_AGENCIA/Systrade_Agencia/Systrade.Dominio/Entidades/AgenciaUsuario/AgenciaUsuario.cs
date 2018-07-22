using DomainValidation.Validation;
using System;
using Systrade.Core.Helpers;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Scopes;

namespace Systrade.Dominio.Entidade.Usuarios
{
    public class AgenciaUsuario
    {
        public Guid AgenciaId { get; private set; }
        public string UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public CPF CPF { get; private set; }
        public Telefones Telefone { get; private set; }
        public Email Email { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public string ClaimValue { get; set; }

        public virtual Agencia Agencia { get; set; }

        protected AgenciaUsuario()
        {
        }

        public AgenciaUsuario(Guid agenciaid, string usuarioid, string nomeusuario, string sobrenome, string cpf, string email, string celular, string telefone,
            string descricao)
        {
            AgenciaId = agenciaid;
            UsuarioId = usuarioid;
            ValidarNome(nomeusuario);
            Sobrenome = sobrenome;
            DefinirCPF(cpf);
            DefinirEmail(email);
            DefinirTelefones(celular, telefone);
            Descricao = descricao;
            Status = true;
        }

        public void ValidarNome(string nome)
        {
            this.DefinirNomeAgenciaUsuarioScopeEhValido(nome);
            Nome = TextoHelper.RemoverAcentos(nome);
        }

        public void DefinirEmail(string email)
        {
            var meuemail = new Email(email);

            this.DefinirEmailAgenciaUsuarioScopeEhValido(meuemail);
            Email = meuemail;
        }

        public void DefinirCPF(string cpf)
        {
            var meucpf = new CPF(cpf);

            this.DefinirCPFAgenciaUsuarioScopeEhValido(meucpf);
            CPF = meucpf;
        }

        public void DefinirTelefones(string celular, string fixo)
        {
            var telefones = new Telefones(celular, fixo);

            this.DefinirCelularAgenciaUsuarioScopeEhValido(celular);
            Telefone = telefones;
        }

        public bool DesativarAgenciaUsuario()
        {
            Status = false;
            return Status;
        }

        public bool AtivarAgenciaUsuario()
        {
            Status = true;
            return Status;
        }

        public void ValidarSenha(string senha)
        {
            if (this.ValidarSenhaAgenciaUsuarioScopeEhValido(senha))
                return;
        }

        #region Constantes

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        #endregion
    }
}

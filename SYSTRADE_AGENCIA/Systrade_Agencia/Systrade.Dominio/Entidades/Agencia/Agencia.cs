using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using Systrade.Core.Helpers;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;

namespace Systrade.Dominio.Entidade
{
    public class Agencia
    {
        public Guid AgenciaId { get; private set; }
        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public CNPJ CNPJ { get;  private set; }
        public string TelefoneFixo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<AgenciaUsuario> AgenciaUsuario { get; set; }


        public Agencia(string cnpj)
        {
            CNPJ = new CNPJ(cnpj);
        }

        protected Agencia()
        { }

        public Agencia(Guid agenciaid, string nomefantasia, string razaosocial, string cnpj, string fixo)
        {
            AgenciaId = agenciaid;
            DefinirNomeFantasia(nomefantasia);
            DefinirRazaoSocial(razaosocial);
            DefinirCnpj(cnpj);
            TelefoneFixo = TextoHelper.GetNumeros(fixo);
            Enderecos = new List<Endereco>();
        }

        public void DefinirNomeFantasia(string nome)
        {
            this.DefinirNomeFAntasiaScopeValido(nome);
            NomeFantasia = TextoHelper.RemoverAcentos(nome);
        }

        public void DefinirRazaoSocial(string nome)
        {
            this.DefinirRazaoSocialScopeEhValido(nome);
            RazaoSocial = TextoHelper.RemoverAcentos(nome);
        }

        public void DefinirCnpj(string cnpj)
        {
            this.DefinirCnpjScopeEhValido(cnpj);
            CNPJ = new CNPJ(cnpj);
        }
    }
}

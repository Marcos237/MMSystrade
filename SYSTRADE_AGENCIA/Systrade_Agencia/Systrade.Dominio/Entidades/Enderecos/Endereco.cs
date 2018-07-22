using System;
using Systrade.Core.Helpers;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Enderecos.Entidades
{
    public class Endereco
    {
        public Guid EnderecoId { get; private set; }
        public Guid AgenciaId { get; private set; }
        public string Descricao { get; set; }
        public virtual string Logradouro { get; private set; }
        public virtual string Complemento { get; private set; }
        public virtual string Numero { get; private set; }
        public virtual string Cidade { get; private set; }
        public string Estado { get; private set; }
        public virtual CEP Cep { get; private set; }

        public virtual Agencia Agencia { get; set; }

        public Endereco()
        {
        }

        public Endereco(Guid enderecoid, Guid agenciaid, string descricao, string logradouro, string complemento, string numero, string cep, string cidade, string estado)
        {
            Cep = new CEP(cep);
            DefinirComplemento(complemento);
            DefinirDescricao(descricao);
            DefinirLogradouro(logradouro);
            DefinirNumero(numero);
            DefinirCidade(cidade);
            DefinirEstado(estado);
            EnderecoId = enderecoid;
            AgenciaId = agenciaid;
        }

        public void DefinirCep(string cep)
        {
            if (this.DefinirCEPScopeEhValido(cep))
                Cep = new CEP(cep);
        }

        public void DefinirDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                descricao = "";
            Descricao = TextoHelper.RemoverAcentos(descricao);
        }

        public void DefinirComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextoHelper.RemoverAcentos(complemento);
        }

        public void DefinirLogradouro(string logradouro)
        {
            if (this.DefinirLogradouroScopeEhValido(logradouro))
                if (string.IsNullOrEmpty(logradouro))
                    logradouro = "";
            Logradouro = TextoHelper.RemoverAcentos(logradouro);
        }

        public void DefinirNumero(string numero)
        {
            if (this.DefinirNumeroScopeEhValido(numero))
                if (string.IsNullOrEmpty(numero))
                    numero = "";
            Numero = numero;
        }

        public void DefinirCidade(string cidade)
        {
            if (this.DefinirCidadeScopeEhValido(cidade))
                if (string.IsNullOrEmpty(cidade))
                    cidade = "";
            Cidade = TextoHelper.RemoverAcentos(cidade); ;
        }

        public void DefinirEstado(string estado)
        {
            if (this.DefinirEstadoScopeEhValido(estado))
                if (string.IsNullOrEmpty(estado))
                    estado = "";
            Estado = estado;
        }
    }
}
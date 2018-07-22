using System;
using Systrade.Core.Interfaces;

namespace Systrade.Dominio.Entidades.AgenciaUsuario.Events
{
    public class AgenciaUsuarioEvent : IDomainEvent
    {
        public Guid UsuarioId { get; private set; }
        public string NomeUsuario { get; private set; }
        public string UsuarioModificadoId { get; set; }
        public string UsuarioModificado { get; private set; }
        public string CPF { get; private set; }
        public string ClaimValue { get; private set; }
        public string Acao { get; private set; }
        public DateTime DataOcorrencia { get; private set; }
        public int Versao { get; private set; }

        public AgenciaUsuarioEvent(Guid usuarioid, string nomeusuario, string usuariomodificadoid, string usuariuomodificado, string cpf, string claimvalue, string acao)
        {
            UsuarioId = usuarioid;
            NomeUsuario = nomeusuario;
            UsuarioModificadoId = usuariomodificadoid;
            UsuarioModificado = usuariuomodificado;
            CPF = cpf;
            ClaimValue = claimvalue;
            Acao = acao;
            DataOcorrencia = DateTime.Now;
            Versao = 1;
        }
    }
}

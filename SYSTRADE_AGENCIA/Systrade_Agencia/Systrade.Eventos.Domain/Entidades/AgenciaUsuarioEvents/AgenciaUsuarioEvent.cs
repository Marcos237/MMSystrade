using System;

namespace Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents
{
    public class UsuarioEvents
    {
        public Guid LogadoId { get; private set; }
        public Guid ModificadoId { get; private set; }
        public string Logado { get; private set; }
        public string Modificado { get; private set; }
        public string Permissao { get; private set; }
        public string Menssagem { get; private set; }
        public DateTime DataOcorrencia { get; set; }

        public UsuarioEvents(Guid logadoid, Guid modificadoid, string logado, string modificado, string permissao, string menssagem)
        {
            LogadoId = logadoid;
            ModificadoId = modificadoid;
            Logado = logado;
            Modificado = modificado;
            Permissao = permissao;
            Menssagem = menssagem;
            DataOcorrencia = DateTime.Now;
        }

    }
}

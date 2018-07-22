using MongoRepository;
using System;

namespace Systrade.Cadastro.Infra.Logging.Entidades
{
    public class ExceptionAuditoria : Entity
    {
        public Guid ExceptionId { get; set; }
        public DateTime DataOcorrencia { get; private set; }
        public string Sistema { get; private set; }
        public string UserId { get; private set; }
        public string IP { get; private set; }
        public string Acao { get; private set; }
        public string ExceptionLog { get; private set; }

        public ExceptionAuditoria(string userId, string sistema, string ip, string acao, string exception)
        {
            UserId = userId;
            Sistema = sistema;
            IP = ip;
            Acao = acao;
            ExceptionLog = exception;
            ExceptionId = Guid.NewGuid();
            DataOcorrencia = DateTime.Now;
        }
    }
}

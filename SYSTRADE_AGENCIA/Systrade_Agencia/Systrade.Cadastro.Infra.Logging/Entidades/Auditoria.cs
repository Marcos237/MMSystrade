using MongoRepository;
using System;

namespace Systrade.Cadastro.Infra.Logging.Entidades
{
    public class Auditoria : Entity
    {
        public Guid LogId { get; set; }
        public DateTime DataOcorrencia { get; private set; }
        public string Sistema { get; private set; }
        public string UserId { get; private set; }
        public string IP { get; private set; }
        public string Acao { get; private set; }
        public string Model { get; private set; }

        public Auditoria(string userId, string sistema, string ip, string acao, string model = null)
        {
            UserId = userId;
            Sistema = sistema;
            IP = ip;
            Acao = acao;
            Model = model;
            LogId = Guid.NewGuid();
            DataOcorrencia = DateTime.Now;
        }

    }
}
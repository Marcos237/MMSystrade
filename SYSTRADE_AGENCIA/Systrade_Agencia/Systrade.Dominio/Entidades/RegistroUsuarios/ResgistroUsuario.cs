using System;

namespace Systrade.Dominio.Entidades
{
    public class RegistroUsuario
    {
        public Guid RegistroUsuarioId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string UserName { get; private set; }
        public string IP { get; private set; }
        public string Registro { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected  RegistroUsuario()
        {

        }

        public RegistroUsuario(Guid usuarioid, string login, string ip, string registro)
        {
            RegistroUsuarioId = Guid.NewGuid();
            UsuarioId = usuarioid;
            UserName = login;
            IP = ip;
            Registro = registro;
        }
    }
}

using MongoRepository;
using System;
using System.Collections;

namespace Systrade.Events.Dominio.Entidades
{
    public class UsuarioEvents : Entity
    {
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string UsuarioModificadoId { get; set; }
        public string UsuarioModificado { get; set; }
        public string CPF { get; set; }
        public string ClaimValue { get; set; }
        public string Acao { get; set; }
        public string DataOcorrencia { get; set; }
        public int Versao { get; private set; }

        public UsuarioEvents(Guid usuarioid, string nomeusuario, string usuariomodificadoid, string usuariuomodificado, string cpf, string claimvalue, string acao, DateTime datacorrencia)
        {
            UsuarioId = usuarioid;
            NomeUsuario = nomeusuario;
            UsuarioModificadoId = usuariomodificadoid;
            UsuarioModificado = usuariuomodificado;
            CPF = cpf;
            ClaimValue = ValidarPermissao(claimvalue);
            Acao = acao;
            DataOcorrencia = datacorrencia.ToString();
            Versao = 1;
        }

        public string ValidarPermissao(string claimvalue)
        {
            switch (claimvalue)
            {
                case "A":
                    claimvalue = "ADMINISTRADOR";
                    break;
                case "C":
                    claimvalue = "COORDENADOR";
                    break;
                case "S":
                    claimvalue = "SUPERVISOR";
                    break;
                case "E":
                    claimvalue = "EXTERNO";
                    break;
                case "P":
                    claimvalue = "PROMOTOR";
                    break;
                case "R":
                    claimvalue = "RH";
                    break;
                case "O":
                    claimvalue = "OPERADOR";
                    break;
                case "V":
                    claimvalue = "VENDEDOR";
                    break;
            }
            return claimvalue;
        }
    }
}


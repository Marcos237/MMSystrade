using System;

namespace Systrade.Dominio.DTO
{
    public class AgenciaUsuarioDto
    {
        public Guid AgenciaId { get; private set; }
        public string UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CPF { get; private set; }
        public string Celular { get; private set; }
        public string TelefoneFixo { get; private set; }
        public string Email { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string ClaimValue { get; private set; }

        public AgenciaUsuarioDto()
        {
        }
    }
}

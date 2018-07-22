using System;

namespace Systrade.Dominio.DTO
{
    public class AgenciaDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Guid UsuarioId { get; set; }
        public string TelefoneFixo { get; set; }
        public string CNPJ { get; set; }
        public Guid AgenciaId { get; set; }

        public AgenciaDto()
        {

        }

    }
}

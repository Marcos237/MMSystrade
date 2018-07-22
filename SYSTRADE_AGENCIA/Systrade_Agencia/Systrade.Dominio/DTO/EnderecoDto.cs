using System;

namespace Systrade.Dominio.DTO
{
    public class EnderecoDto
    {
        public Guid EnderecoId { get; set; }
        public Guid AgenciaId { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Descricao { get; set; }


        public EnderecoDto()
        {

        }
    }
}

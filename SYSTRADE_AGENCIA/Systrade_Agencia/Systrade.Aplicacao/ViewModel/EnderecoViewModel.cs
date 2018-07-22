using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoId { get; set; }

        public Guid AgenciaId { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [MaxLength(11, ErrorMessage = "Máximo 8 caracteres")]
        [DisplayName("Cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número")]
        [MaxLength(6, ErrorMessage = "Máximo 6 caracteres")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }
    }
}

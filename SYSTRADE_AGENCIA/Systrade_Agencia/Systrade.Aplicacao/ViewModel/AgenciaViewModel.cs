using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class AgenciaViewModel
    {
        [Key]
        public Guid AgenciaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo com nome da agência")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo com nome da agência")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Razao Social")]
        public string RazaoSocial { get; set; }


        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [MaxLength(13, ErrorMessage = "Máximo de 10 caracteres")]
        [DisplayName("Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

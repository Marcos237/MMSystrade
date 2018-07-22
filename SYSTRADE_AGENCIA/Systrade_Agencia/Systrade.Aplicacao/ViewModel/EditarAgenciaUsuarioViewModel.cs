using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class EditarAgenciaUsuarioViewModel
    {
        [Key]
        public Guid UsuarioId { get; set; }

        public Guid AgenciaId { get; set; }


        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo  celular")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [MaxLength(13, ErrorMessage = "Máximo 10 caracteres")]
        [DisplayName("Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "Preencha o campo  email")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 50 caracteres")]
        [DisplayName("Permissão")]
        [Required(ErrorMessage = "Preencha o campo permissão")]
        public string ClaimValue { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
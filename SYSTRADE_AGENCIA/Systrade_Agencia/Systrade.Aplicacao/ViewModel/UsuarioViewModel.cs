using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }

        [Key]
        public Guid UsuarioId { get; set; }

        public Guid AgenciaId { get; set; }


        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14, ErrorMessage = "Máximo 11 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo  celular")]
        [MaxLength(14, ErrorMessage = "Máximo 11 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [MaxLength(13, ErrorMessage = "Máximo 10 caracteres")]
        [DisplayName("Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "Preencha o campo  email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
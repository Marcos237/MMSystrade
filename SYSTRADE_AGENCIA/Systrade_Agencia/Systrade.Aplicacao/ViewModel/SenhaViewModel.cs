using System;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class SenhaViewModel
    {

        public SenhaViewModel()
        {
        }

        public string UsuarioId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter pelo menos 2 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter pelo menos 2 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "Confirmação de senha incorreta.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}

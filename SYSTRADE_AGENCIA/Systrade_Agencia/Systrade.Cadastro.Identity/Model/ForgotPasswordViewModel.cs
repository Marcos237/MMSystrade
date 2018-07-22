using System.ComponentModel.DataAnnotations;

namespace Systrade.Cadastro.Identity.Model
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

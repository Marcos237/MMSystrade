using System.ComponentModel.DataAnnotations;

namespace Systrade.Cadastro.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
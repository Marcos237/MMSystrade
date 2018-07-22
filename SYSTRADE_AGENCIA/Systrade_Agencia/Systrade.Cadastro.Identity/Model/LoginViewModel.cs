using System.ComponentModel.DataAnnotations;

namespace Systrade.Cadastro.Identity.Model
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Me lembrar?")]
        public bool RememberMe { get; set; }
    }
}
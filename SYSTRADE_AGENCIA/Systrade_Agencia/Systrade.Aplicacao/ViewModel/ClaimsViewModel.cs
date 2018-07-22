using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class ClaimsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo com a Permissão")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Permissão")]
        public string Permissao { get; set; }
    }
}

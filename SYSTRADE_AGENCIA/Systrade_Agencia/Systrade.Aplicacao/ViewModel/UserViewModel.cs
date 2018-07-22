using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Aplicacao.ViewModel
{
    public class UserViewModel
    {
        public Guid RegistroUsuario { get; set; }
        public Guid UserId { get; set; }
        public Guid AgenciaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo de login")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Preencha o campo de IP")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("IP")]
        public string IP { get; set; }


        [Required(ErrorMessage = "Preencha o campo de Registro")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Registro")]
        public string Registro { get; set; }

        [Required(ErrorMessage = "Preencha o campo de Registro")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data de Login")]
        public string DataCadastro { get; set; }

        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systrade.Eventos.Application.ViewModel
{
    public class UsuarioEventViewModel
    {
        [Key]
        public Guid LogadoId { get;  set; }
        public Guid ModificadoId { get; set; }

        [DisplayName("Logado")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Logado { get;  set; }

        [DisplayName("Modificado")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Modificado { get;  set; }

        [DisplayName("Permissao")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Permissao { get; set; }

        [DisplayName("Menssagem")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Menssagem { get;  set; }

    }
}

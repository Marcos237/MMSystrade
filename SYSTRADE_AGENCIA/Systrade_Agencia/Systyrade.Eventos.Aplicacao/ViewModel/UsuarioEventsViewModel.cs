using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Eventos.Aplicacao.ViewModel
{
    public class UsuarioEventsViewModel
    {
        [Key]
        public Guid UsuarioId { get; set; }

        public string UsuarioModificadoId { get; set; }

        [DisplayName("Logado")]
        public string NomeUsuario { get;  set; }

        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Modificado")]
        public string UsuarioModificado { get;  set; }

        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get;  set; }

        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Permissão")]
        public string ClaimValue { get;  set; }

        [DisplayName("Data Ocorrência")]
        [DataType(DataType.DateTime)]
        public DateTime DataOcorrencia { get;  set; }

        [DisplayName("Ação")]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Acao { get;  set; }

    }
}

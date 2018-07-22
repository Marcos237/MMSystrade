using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Clientes.Applications.ViewModel
{
    public class CelulaViewModel
    {

        [Key]
        public Guid CelulaId { get; set; }

        public Guid AgenciaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo célula.")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [DisplayName("Nome da Célula")]
        public string NomeCelula { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        public string DataCadastro { get; set; }

        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }


        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

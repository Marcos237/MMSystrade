using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systrade.Cadastro.Identity.Model
{
    public class RegisterViewModel
    { 
        public RegisterViewModel()
        {
            AgenciaId = Guid.NewGuid();
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid AgenciaId { get; set; }
        public Guid EnderecoId { get; set; }
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo com nome da agência")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo com nome da razão social")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Razao social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo  de 14 caracteres")]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [MaxLength(13, ErrorMessage = "Máximo de 10 caracteres")]
        [DisplayName("Telefone Agência")]
        public string TelefoneAgencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo com nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo com sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14, ErrorMessage = "Máximo de 11 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo de email")]
        [EmailAddress]
        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo de celular")]
        [MaxLength(14, ErrorMessage = "Máximo de 11 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [MaxLength(13, ErrorMessage = "Máximo de 10 caracteres")]
        [DisplayName("Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [MaxLength(11, ErrorMessage = "Máximo de 8 caracteres")]
        [DisplayName("Cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número")]
        [MaxLength(6, ErrorMessage = "Máximo de 6 caracteres")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(2, ErrorMessage = "Máximo de 2 caracteres")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o campo de login")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter pelo menos 2 caracteres e no máximo 16.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "Confirmação de senha incorreta.")]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 50 caracteres")]
        [DisplayName("Permissão")]
        [ScaffoldColumn(false)]
        public string Permissao { get; set; }

    }
}

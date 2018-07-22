using DomainValidation.Validation;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Specification;
using Systrade.Dominio.Entidades.Specification;
using Systrade.Dominio.Interfaces.Repository;

namespace Systrade.Dominio.Entidades.Validations
{
    public class AgenciaConsistenteParaCadastroValidation : Validator<Agencia>
    {
        public AgenciaConsistenteParaCadastroValidation(IAgenciaRepository agenciarepository)
        {
            var cnpjduplicado = new CnpjUnicoSpecification(agenciarepository);
            var cnpjFormato = new CnpjFormatoCorretoSpecification();
            var cnpjTamanho = new CnpjTamanhoIncorretoSpecification();
            var nomeFantasia = new NomeFantasiaFormatoCorretoSpecification();
            var razaoSocial = new RazaoSocialFormatoSpecification();

            base.Add("cnpjduplicado", new Rule<Agencia>(cnpjduplicado, "CNPJ já cadastrado."));
            base.Add("cnpjFormato", new Rule<Agencia>(cnpjFormato, "O CNPJ está em formato incorreto."));
            base.Add("cnpjTamanho", new Rule<Agencia>(cnpjTamanho, "O CNPJ está em tamanho incorreto."));
            base.Add("nomeFantasia", new Rule<Agencia>(nomeFantasia, "O Nome Fantasia deve ter pelo meno 2 caracteres."));
            base.Add("razaoSocial", new Rule<Agencia>(razaoSocial, "A Razão Social deve dete ter pelo menos 2 caracteres."));


        }
    }
}

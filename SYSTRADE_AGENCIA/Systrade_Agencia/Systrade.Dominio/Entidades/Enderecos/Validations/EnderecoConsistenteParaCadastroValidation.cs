using DomainValidation.Validation;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidades.Enderecos.Specifications;

namespace Systrade.Dominio.Entidades.Enderecos.Validations
{
    public class EnderecoConsistenteParaCadastroValidation :  Validator<Endereco>
    {
        public EnderecoConsistenteParaCadastroValidation()
        {

            var cidadeFormato = new CidadeNaoPodeSerNuloSpecification();
            var ufFormato = new EstadoNaoPodeSerNuloSpecification();
            var logradouroFormato = new LogradouroNaoPodeSerNuloSpecification();
            var numeroFormato = new NumeroNaoPodeSerNuloSpecification();

            base.Add("cidadeFormato", new Rule<Endereco>(cidadeFormato, "A Cidade deve ter pelo menos 2 caracteres."));
            base.Add("ufFormato", new Rule<Endereco>(ufFormato, "O Estado deve ter 2 caracteres."));
            base.Add("logradouroFormato", new Rule<Endereco>(logradouroFormato, "O Logradouro deve ter pelo menos 2 caracteres."));
            base.Add("numeroFormato", new Rule<Endereco>(numeroFormato, "O Número não pode ser nulo."));
        }
    }
}

using DomainValidation.Validation;
using Systrade.Clientes.Domain.Entidades.Specifications;

namespace Systrade.Clientes.Domain.Entidades.Celulas.Validation
{
    public class CelulaEstaConsitenteParaEditarSpecification : Validator<Celula>
    {
        public CelulaEstaConsitenteParaEditarSpecification()
        {
            var NomeCelula = new NomeCelulaTamanhoCorretoSpecification();

            base.Add("NomeCelula", new Rule<Celula>(NomeCelula, "Nome em tamanho incorreto."));
        }
    }
}

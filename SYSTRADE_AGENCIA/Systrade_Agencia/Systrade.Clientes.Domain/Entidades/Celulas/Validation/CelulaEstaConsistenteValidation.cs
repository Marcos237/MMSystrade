using DomainValidation.Validation;
using Systrade.Clientes.Domain.Entidades.Celulas.Specifications;
using Systrade.Clientes.Domain.Entidades.Specifications;
using Systrade.Clientes.Domain.Intefaces.Repository;

namespace Systrade.Clientes.Domain.Entidades.Validation
{
    public class CelulaEstaConsistenteValidation : Validator<Celula>
    {
        public CelulaEstaConsistenteValidation(ICelulaRepository celularepository)
        {
            var NomeCelula = new NomeCelulaTamanhoCorretoSpecification();
            var NomeCelulaunico = new NomeCelulaUnicoSpecifications(celularepository);

            base.Add("NomeCelula", new Rule<Celula>(NomeCelula, "Nome em tamanho incorreto."));
            base.Add("NomeCelulaunico", new Rule<Celula>(NomeCelulaunico, "Nome já cadastrado."));
        }
    }
}

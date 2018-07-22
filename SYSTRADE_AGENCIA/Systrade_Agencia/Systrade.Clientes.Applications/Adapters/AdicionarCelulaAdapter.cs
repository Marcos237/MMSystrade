using Systrade.Clientes.Applications.ViewModel;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Applications.Adapters
{
    public class AdicionarCelulaAdapter
    {
        public static Celula ToDomainModel(CelulaViewModel model)
        {
            var celula = new Celula(
                model.CelulaId,
                model.AgenciaId,
                model.NomeCelula
                );

            return celula;
        }
    }
}

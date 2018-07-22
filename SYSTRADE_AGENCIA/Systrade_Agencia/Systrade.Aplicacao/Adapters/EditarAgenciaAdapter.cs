using Systrade.Aplicacao.ViewModel;
using Systrade.Dominio.Entidade;

namespace Systrade.Aplicacao.Adapters
{
    public class EditarAgenciaAdapter
    {
        public static Agencia ToDomainModel(AgenciaViewModel model)
        {
            var agencia = new Agencia(
                model.AgenciaId,
                model.NomeFantasia,
                model.RazaoSocial,
                model.CNPJ,
                model.TelefoneFixo);

            return agencia;
        }
    }
}

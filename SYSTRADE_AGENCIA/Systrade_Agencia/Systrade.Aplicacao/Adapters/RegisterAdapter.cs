using Systrade.Cadastro.Identity.Model;
using Systrade.Dominio.Entidade;

namespace Systrade.Aplicacao.Adpters
{
    public class RegisterAdapter
    {
        public static Agencia ToDomainModel(RegisterViewModel model)
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

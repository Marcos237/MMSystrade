using Systrade.Aplicacao.ViewModel;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Aplicacao.Adapters
{
    public class AdicionarEnderecoAdapter
    {
        public static Endereco ToDomainModel(EnderecoViewModel model)
        {
            var endereco = new Endereco(
                model.EnderecoId,
                model.AgenciaId,
                model.Descricao,
                model.Logradouro,
                model.Complemento,
                model.Numero,
                model.Cep,
                model.Cidade,
                model.Estado
                );

            return endereco;
        }
    }
}

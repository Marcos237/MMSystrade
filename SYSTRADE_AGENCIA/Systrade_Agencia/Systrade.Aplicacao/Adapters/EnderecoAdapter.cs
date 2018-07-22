using Systrade.Cadastro.Identity.Model;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Aplicacao.Adapters
{
    public class EnderecoAdapter
    {
        public static Endereco ToDomainModel(RegisterViewModel model)
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

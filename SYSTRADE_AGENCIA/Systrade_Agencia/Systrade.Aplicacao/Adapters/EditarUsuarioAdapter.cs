using Systrade.Aplicacao.ViewModel;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Aplicacao.Adapters
{
    public class EditarUsuarioAdapter
    {
        public static AgenciaUsuario ToDomainModel(UsuarioViewModel model, string Id)
        {
            var agenciausuario = new AgenciaUsuario(
                model.AgenciaId,
                Id,
                model.Nome,
                model.Sobrenome,
                model.CPF,
                model.Email,
                model.Celular,
                model.TelefoneFixo,
                "");

            return agenciausuario;
        }
    }
}

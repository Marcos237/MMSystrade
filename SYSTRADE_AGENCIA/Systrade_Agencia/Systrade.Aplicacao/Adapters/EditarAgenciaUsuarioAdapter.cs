using Systrade.Aplicacao.ViewModel;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Aplicacao.Adapters
{
    public class EditarAgenciaUsuarioAdapter
    {
        public static AgenciaUsuario ToDomainModel(EditarAgenciaUsuarioViewModel model)
        {
            var agenciausuario = new AgenciaUsuario(
                model.AgenciaId,
                model.UsuarioId.ToString(),
                model.Nome,
                model.Sobrenome,
                model.CPF,
                model.Email,
                model.Celular,
                model.TelefoneFixo,
                model.Descricao);

            return agenciausuario;
        }
    }
}
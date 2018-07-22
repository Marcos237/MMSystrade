using System;
using Systrade.Aplicacao.ViewModel;

namespace Systrade.Aplicacao.Interface
{
    public interface IRegistroAppService
    {
        void AdicionarRegistro(string login);
        PagedViewModel<UserViewModel> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber);
        void DeletarRegistroUsuario(Guid id);
    }
}

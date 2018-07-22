using System;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidades;

namespace Systrade.Dominio.Interfaces.Servicos
{
    public interface  IRegistroUsuarioService : IDisposable
    {
        Paged<RegistroUsuario> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber);

        RegistroUsuario ObterRegistroUsuarioPorId(Guid id);
        RegistroUsuario AdicionarRegistro(RegistroUsuario registro);
        void DeletarRegistroUsuario(Guid id);
    }
}

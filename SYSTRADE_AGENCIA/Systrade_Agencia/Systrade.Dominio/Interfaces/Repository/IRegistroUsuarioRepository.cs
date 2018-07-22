using System;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidades;

namespace Systrade.Dominio.Interfaces.Repository
{
    public interface IRegistroUsuarioRepository
    {
        RegistroUsuario ObterRegistroUsuarioPorId(Guid id);
        RegistroUsuario AdicionarRegistro(RegistroUsuario registro);
        Paged<RegistroUsuario> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber);
        void DeletarRegistroUsuario(Guid id);
        void Dispose();
    }
}

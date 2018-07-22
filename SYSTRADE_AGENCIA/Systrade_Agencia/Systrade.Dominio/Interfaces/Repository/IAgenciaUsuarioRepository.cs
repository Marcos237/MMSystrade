using System;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Dominio.Interfaces.Repository
{
    public interface IAgenciaUsuarioRepository : IRepository<AgenciaUsuario>
    {
        AgenciaUsuario AdicionarAgenciaUsuario(AgenciaUsuario obj);
        AgenciaUsuario AtualizarAgenciaUsuario(AgenciaUsuario obj);

        AgenciaUsuario BuscarAgenciaUsuarioPorId(Guid id);
        AgenciaUsuario BuscarAgenciaUsuarioCpf(string cpf);
        AgenciaUsuario BuscarAgenciaUsuarioEmail(string email);
        AgenciaUsuario BuscarAgenciaUsuarioEmailParaEditar(string email, string id);
        AgenciaUsuario RestaurarAgenciaUsuario(AgenciaUsuario obj);


        AgenciaUsuario DeletarAgenciaUsuario(AgenciaUsuario agenciausuario);
        Paged<AgenciaUsuarioDto> ObterTodosAgenciaUsuario(Guid id, string descricao, int pageSize, int pageNumber);
        Paged<AgenciaUsuarioDto> ObterTodosUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber);
    }
}

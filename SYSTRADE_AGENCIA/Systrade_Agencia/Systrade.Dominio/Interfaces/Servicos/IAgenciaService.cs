using System;
using System.Collections.Generic;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;

namespace Systrade.Dominio.Interfaces.Servicos
{
    public interface IAgenciaService : IDisposable
    {
        Agencia AdicionarAgencia(Agencia obj);
        Agencia AtualizarAgencia(Agencia obj);
        Agencia BuscarPorId(Guid id);
        Agencia BuscarAgenciaCnpj(string cnpj);


        AgenciaUsuario AdicionarAgenciaUsuario(AgenciaUsuario obj);
        AgenciaUsuario AtualizarUsuario(AgenciaUsuario obj);
        AgenciaUsuario BuscarAgenciaUsuarioPorId(Guid id);
        AgenciaUsuario BuscarAgenciaUsuarioCpf(string cpf);
        AgenciaUsuario BuscarAgenciaUsuarioEmail(string email);
        AgenciaUsuario BuscarAgenciaUsuarioEmailParaEditar(string email, string id);
        AgenciaUsuario DeletarAgenciaUsuario(AgenciaUsuario agenciausuario);
        Paged<AgenciaUsuarioDto> ObterTodosUsuario(Guid id, string descricao, int pageSize, int pageNumber);
        Paged<AgenciaUsuarioDto> ObterTodosUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber);
        AgenciaUsuario RestaurarAgenciaUsuario(AgenciaUsuario obj);

        Endereco AdicionarEndereco(Endereco obj);
        Endereco AtualizarEndereco(Endereco obj);
        Endereco BuscarEnderecoPorId(Guid id);
        Paged<EnderecoDto> ObterTodosEnderecos(Guid Id, string descricao, int pageSize, int pageNumber);
        void DeletarEndereco(Guid id);


        List<Claims> BuscarClaims();
        Claims BuscarClaimsPorId(Guid id);
    }
}

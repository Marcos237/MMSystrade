using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Model;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Entidades;

namespace Systrade.Aplicacao.Interface
{
    public interface IAgenciaAppService
    {
        Agencia AdicionarAgencia(Agencia agencia);
        bool AtualizarAgencia(AgenciaViewModel agencia);
        AgenciaViewModel ObterPorId(Guid id);
        IdentityResult AdicionarIdentidade(RegisterViewModel register);

        Endereco AdicionarEndereco(Endereco endereco);
        EnderecoViewModel AdaptarEndereco(EnderecoViewModel endereco);
        bool AtualizarEndereco(EnderecoViewModel model);
        EnderecoViewModel ObterEnderecoPorId(Guid id);
        PagedViewModel<EnderecoViewModel> ObterTodosEnderecos(Guid id, string descricao, int pageSize, int pageNumber);
        void DeletarEndereco(Guid id);

        bool AtualizarAgenciaUsuario(EditarAgenciaUsuarioViewModel agenciausuario);
        AgenciaUsuarioViewModel ObterAgenciaUsuarioPorId(Guid id);
        PagedViewModel<AgenciaUsuarioViewModel> ObterTodosAgenciaUsuario(Guid id, string descricao, int pageSize, int pageNumber);
        bool DeletarAgenciaUsuario(EditarAgenciaUsuarioViewModel agenciausuario);
        bool AtualizarSenhaAgenciaUsuario(SenhaViewModel changepassword);
        EditarAgenciaUsuarioViewModel ObterAgenciaUsuarioEditarPorId(Guid id);
        PagedViewModel<AgenciaUsuarioViewModel> ObterTodosAgenciaUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber);
        bool RestaurarAgenciaUsuario(EditarAgenciaUsuarioViewModel agenciausuario);

        bool AtualizarUsuario(UsuarioViewModel usuario);
        UsuarioViewModel ObterUsuarioPorId(Guid id);

        List<Claims> BuscarClaims();
        ClaimsViewModel BuscarClaimsPorId(Guid id);
        bool BloquearUsuario(Guid id);
      
    }
}

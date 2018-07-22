using System;
using System.Collections.Generic;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Usuarios.Validations.AgenciaUsuarios;
using Systrade.Dominio.Validations;

namespace Systrade.Dominio.Servicos
{
    public partial class AgenciaService
    {

        public AgenciaUsuario AdicionarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            if (PossuiConformidade(new AgenciaUsuarioProntoParaCadastroValidation(_agenciausuariorepository).Validate(agenciausuario)))
                _agenciausuariorepository.AdicionarAgenciaUsuario(agenciausuario);

            return agenciausuario;
        }

        public AgenciaUsuario AtualizarUsuario(AgenciaUsuario agenciausuario)
        {
            if (PossuiConformidade(new AgenciaUsuarioProntoParaEditar(_agenciausuariorepository).Validate(agenciausuario)))
                _agenciausuariorepository.AtualizarAgenciaUsuario(agenciausuario);
            return agenciausuario;
        }

        public AgenciaUsuario BuscarAgenciaUsuarioPorId(Guid id)
        {
            return _agenciausuariorepository.BuscarAgenciaUsuarioPorId(id);
        }

        public AgenciaUsuario BuscarAgenciaUsuarioEmail(string email)
        {
            return _agenciausuariorepository.BuscarAgenciaUsuarioEmail(email);

        }

        public AgenciaUsuario BuscarAgenciaUsuarioCpf(string cpf)
        {
            return _agenciausuariorepository.BuscarAgenciaUsuarioCpf(cpf);
        }

        public AgenciaUsuario BuscarAgenciaUsuarioEmailParaEditar(string email, string id)
        {
            return _agenciausuariorepository.BuscarAgenciaUsuarioEmailParaEditar(email, id);
        }


        public Paged<AgenciaUsuarioDto> ObterTodosUsuario(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return _agenciausuariorepository.ObterTodosAgenciaUsuario(id, descricao, pageSize, pageNumber);
        }

        public Paged<AgenciaUsuarioDto> ObterTodosUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return _agenciausuariorepository.ObterTodosUsuarioInativos(id, descricao, pageSize, pageNumber);
        }

        public AgenciaUsuario DeletarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            agenciausuario.DesativarAgenciaUsuario();
            return _agenciausuariorepository.DeletarAgenciaUsuario(agenciausuario);
        }


        public AgenciaUsuario RestaurarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            agenciausuario.AtivarAgenciaUsuario();
            return _agenciausuariorepository.RestaurarAgenciaUsuario(agenciausuario);
        }

        public List<Claims> BuscarClaims()
        {
            return _claimrepository.BuscarClaims();
        }

        public Claims BuscarClaimsPorId(Guid id)
        {
            return _claimrepository.BuscarClaimsPorId(id);
        }
    }
}

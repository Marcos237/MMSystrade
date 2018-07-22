using System;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Interfaces.Servicos;

namespace Systrade.Dominio.Servicos
{
    public class RegistroUsuarioService : IRegistroUsuarioService
    {
        private readonly IRegistroUsuarioRepository _registrousuariorepository;
        public RegistroUsuarioService(IRegistroUsuarioRepository registrousuariorepository)
        {
            _registrousuariorepository = registrousuariorepository;
        }

        public Paged<RegistroUsuario> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return _registrousuariorepository.ObterTodosUsers(id, descricao, pageSize, pageNumber);
        }

        public RegistroUsuario ObterRegistroUsuarioPorId(Guid id)
        {
            return _registrousuariorepository.ObterRegistroUsuarioPorId(id);
        }

        public RegistroUsuario AdicionarRegistro(RegistroUsuario registro)
        {
            _registrousuariorepository.AdicionarRegistro(registro);

            return registro;
        }

        public void Dispose()
        {
            _registrousuariorepository.Dispose();
            _registrousuariorepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void DeletarRegistroUsuario(Guid id)
        {
            _registrousuariorepository.DeletarRegistroUsuario(id);
        }
    }
}

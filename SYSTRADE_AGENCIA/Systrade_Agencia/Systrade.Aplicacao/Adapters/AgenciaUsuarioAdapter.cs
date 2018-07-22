using System;
using Systrade.Cadastro.Identity.Model;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Aplicacao.Adapters
{
    public class AgenciaUsuarioAdapter
    {
        public static AgenciaUsuario ToDomainModel(RegisterViewModel model, string id)
        {
            var agenciausuario = new AgenciaUsuario(
                model.AgenciaId,
                id,
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

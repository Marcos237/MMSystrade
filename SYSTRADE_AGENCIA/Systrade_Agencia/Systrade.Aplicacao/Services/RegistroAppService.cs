using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Security.Claims;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.Services.UoW;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Model.Configuration;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Interfaces.Servicos;
using Systrade.Dominio.Interfaces.Uow;

namespace Systrade.Aplicacao.Services
{
    public class RegistroAppService : ApplicationService, IRegistroAppService
    {
        private readonly IRegistroUsuarioService _registroappservice;
        private ApplicationUserManager _userManager;

        public RegistroAppService(IUnitOfWork unitOfWork, IRegistroUsuarioService registroappservice, ApplicationUserManager userManager)
            : base(unitOfWork)
        {
            _registroappservice = registroappservice;
            _userManager = userManager;
        }

        public void AdicionarRegistro(string login)
        {
            var manager = _userManager;
            var user = manager.FindByName(login);
            var nomemaquina = Dns.GetHostName();

            Claim claim = new Claim(user.UserName, user.Email, nomemaquina);

            string ip = Dns.GetHostAddresses(nomemaquina)[1].ToString();
            var result = new RegistroUsuario(Guid.Parse(user.Id), user.UserName, nomemaquina + "--" + ip, user.SecurityStamp);
            _registroappservice.AdicionarRegistro(result);
            if (Commit()) { }

        }

        public PagedViewModel<UserViewModel> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return Mapper.Map<PagedViewModel<UserViewModel>>(_registroappservice.ObterTodosUsers(id, descricao, pageSize, pageNumber));
        }

        public void DeletarRegistroUsuario(Guid id)
        {
            _registroappservice.DeletarRegistroUsuario(id);
            if (Commit()) { }
        }
    }
}

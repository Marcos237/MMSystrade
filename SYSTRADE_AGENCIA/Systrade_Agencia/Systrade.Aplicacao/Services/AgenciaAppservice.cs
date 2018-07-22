using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Web;
using Systrade.Aplicacao.Adapters;
using Systrade.Aplicacao.Adpters;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.Services.UoW;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Context;
using Systrade.Cadastro.Identity.Model;
using Systrade.Cadastro.Identity.Model.Configuration;
using Systrade.Core.Events;
using Systrade.Core.Helpers;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidades.AgenciaUsuario.Events;
using Systrade.Dominio.Interfaces.Servicos;
using Systrade.Dominio.Interfaces.Uow;
using Systrade.Infra.Data.Helpers;

namespace Systrade.Aplicacao.Services
{
    public partial class AgenciaAppservice : ApplicationService, IAgenciaAppService
    {
        private readonly IAgenciaService _agenciaService;
        private ApplicationUserManager _userManager;
        private ILogAuditoria _logauditoria;

        string usuario = HttpContext.Current.User.Identity.GetUserId();
        string nomeusuario = HttpContext.Current.User.Identity.GetUserName();


        public AgenciaAppservice(IAgenciaService agenciaService, IUnitOfWork unitOfWork, ApplicationUserManager userManager, ILogAuditoria logauditoria)
            : base(unitOfWork)
        {
            _agenciaService = agenciaService;
            _userManager = userManager;
            _logauditoria = logauditoria;
        }

        public IdentityResult AdicionarIdentidade(RegisterViewModel register)
        {

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;

            var user = new ApplicationUser { UserName = register.Login, Email = register.Email };
            var result = manager.Create(user, register.Password);

            if (result.Succeeded)
            {
                if (usuario == null)
                {
                    var agencia = RegisterAdapter.ToDomainModel(register);
                    AdicionarAgencia(agencia);
                    var endereco = EnderecoAdapter.ToDomainModel(register);
                    AdicionarEndereco(endereco);
                    var agenciausuario = AgenciaUsuarioAdapter.ToDomainModel(register, user.Id);
                    AdicionarUsuario(agenciausuario);

                    if (Commit())
                    {
                    }
                    else
                    {
                        manager.Delete(user);
                        return new IdentityResult(Notifications.ToString());
                    }

                }
                else
                {
                    var agenciausuario = AgenciaUsuarioAdapter.ToDomainModel(register, user.Id);
                    AdicionarUsuario(agenciausuario);
                    AdicionarPermissao(user, register);

                    if (Commit())
                    {
                        DomainEvent.Raise(new AgenciaUsuarioEvent(Guid.Parse(usuario), nomeusuario, agenciausuario.UsuarioId, agenciausuario.Nome, agenciausuario.CPF.Codigo, register.Permissao, "CADASTRAR"));
                    }
                    else
                    {
                        manager.Delete(user);
                        return new IdentityResult(Notifications.ToString());
                    }
                }
            }
            else
            {
                var errosBr = new List<string>();
                var notificationList = new List<DomainNotification>();

                foreach (var erro in result.Errors)
                {
                    string erroBr;
                    if (erro.Contains("As senhas devem ter pelo menos um dígito ('0'-'9')."))
                    {
                        erroBr = "A senha precisa ter ao menos um dígito";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("As senhas devem ter pelo menos um caractere que não seja letra ou um caractere de dígito."))
                    {
                        erroBr = "A senha precisa ter ao menos um caractere especial (@, #, etc...)";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("As senhas devem ter pelo menos um caractere em letra minúscula ('a'-'z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em minúsculo";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("As senhas devem ter pelo menos um caractere em letra maiúscula ('A'-'Z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em maiúsculo";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("O nome " + register.Login + " já foi escolhido."))
                    {
                        erroBr = "Login já registrado, esqueceu sua senha?";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }

                    if (erro.Contains("Name " + register.Email + " is already taken"))
                    {
                        erroBr = "E-mail já registrado, esqueceu sua senha?";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                }
                notificationList.ForEach(DomainEvent.Raise);
                result = new IdentityResult(errosBr);
            }

            return result;
        }


        public Agencia AdicionarAgencia(Agencia agencia)
        {
            if (!Notifications.HasNotifications())
            {
                _agenciaService.AdicionarAgencia(agencia);
            }

            return agencia;
        }

        public bool AtualizarAgencia(AgenciaViewModel model)
        {
            var status = false;
            var agencia = AgenciaAdapter.ToDomainModel(model);
            _agenciaService.AtualizarAgencia(agencia);
            if (Commit())
            {
                status = true;
            }
            return status;
        }

        public AgenciaViewModel ObterPorId(Guid id)
        {
            var result = Mapper.Map<AgenciaViewModel>(_agenciaService.BuscarPorId(id));

            return result;
        }

        public EnderecoViewModel AdaptarEndereco(EnderecoViewModel model)
        {
            var endereco = AdicionarEnderecoAdapter.ToDomainModel(model);
            _agenciaService.AdicionarEndereco(endereco);
            if (Commit()) { }

            return model;
        }

        public Endereco AdicionarEndereco(Endereco endereco)
        {

            if (!Notifications.HasNotifications())
            {
                _agenciaService.AdicionarEndereco(endereco);
            }

            return endereco;
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return Mapper.Map<EnderecoViewModel>(_agenciaService.BuscarEnderecoPorId(id));
        }

        public bool AtualizarEndereco(EnderecoViewModel model)
        {
            var status = false;
            var endereco = EditarEnderecoAdapter.ToDomainModel(model);

            if (!Notifications.HasNotifications())
            {
                _agenciaService.AtualizarEndereco(endereco);
            }
            if (Commit())
                status = true;

            return status;
        }


        public bool BloquearUsuario(Guid id)
        {
            var status = false;
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;
            var user = manager.FindById(id.ToString());
            user.LockoutEnabled = true;
            user.LockoutEndDateUtc = DateTime.UtcNow.AddYears(100);
            var result = manager.Update(user);

            if (result.Succeeded)
                status = true;

            return status;
        }

        public PagedViewModel<EnderecoViewModel> ObterTodosEnderecos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<EnderecoViewModel>>(_agenciaService.ObterTodosEnderecos(id, descricaoformatada, pageSize, pageNumber));
        }


        public void DeletarEndereco(Guid id)
        {
            _agenciaService.DeletarEndereco(id);
            if (Commit()) { }
        }
    }
}
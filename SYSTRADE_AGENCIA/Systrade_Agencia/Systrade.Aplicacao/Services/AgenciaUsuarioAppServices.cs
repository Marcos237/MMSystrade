using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Systrade.Aplicacao.Adapters;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Context;
using Systrade.Cadastro.Identity.Model;
using Systrade.Core.Events;
using Systrade.Core.Helpers;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades.AgenciaUsuario.Events;

namespace Systrade.Aplicacao.Services
{
    public partial class AgenciaAppservice
    {
        private AgenciaUsuario AdicionarUsuario(AgenciaUsuario agenciausuario)
        {
            if (!Notifications.HasNotifications())
            {
                _agenciaService.AdicionarAgenciaUsuario(agenciausuario);
            }

            return agenciausuario;
        }

        public bool AtualizarAgenciaUsuario(EditarAgenciaUsuarioViewModel model)
        {
            var status = false;
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;

            var user = manager.FindById(model.UsuarioId.ToString());
            var voltaremailantigo = user.Email;

            user.Email = model.Email;
            var result = manager.Update(user);

            if (result.Succeeded)
            {
                var agenciausuario = EditarAgenciaUsuarioAdapter.ToDomainModel(model);
                _agenciaService.AtualizarUsuario(agenciausuario);

                RegisterViewModel register = new RegisterViewModel();
                register.Permissao = model.ClaimValue;

                if (Commit())
                {
                    status = true;
                    AtualizarPermissao(user, register);
                    DomainEvent.Raise(new AgenciaUsuarioEvent(Guid.Parse(usuario), nomeusuario, agenciausuario.UsuarioId, agenciausuario.Nome, agenciausuario.CPF.Codigo, model.ClaimValue, "ATUALIZAR"));

                }

                else
                {
                    user.Email = voltaremailantigo;
                    manager.Update(user);
                    status = false;
                }
            }
            return status;
        }

        public AgenciaUsuarioViewModel ObterAgenciaUsuarioPorId(Guid id)
        {
            return Mapper.Map<AgenciaUsuarioViewModel>(_agenciaService.BuscarAgenciaUsuarioPorId(id));
        }

        public PagedViewModel<AgenciaUsuarioViewModel> ObterTodosAgenciaUsuario(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<AgenciaUsuarioViewModel>>(_agenciaService.ObterTodosUsuario(id, descricaoformatada, pageSize, pageNumber));
        }

        public PagedViewModel<AgenciaUsuarioViewModel> ObterTodosAgenciaUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<AgenciaUsuarioViewModel>>(_agenciaService.ObterTodosUsuarioInativos(id, descricaoformatada, pageSize, pageNumber));
        }

        public bool DeletarAgenciaUsuario(EditarAgenciaUsuarioViewModel model)
        {
            var status = false;

            var agenciausuario = EditarAgenciaUsuarioAdapter.ToDomainModel(model);
            var user = _userManager.FindById(model.UsuarioId.ToString());
            _agenciaService.DeletarAgenciaUsuario(agenciausuario);

            if (Commit())
            {
                status = true;
                BloquearUsuario(model.UsuarioId);
                DomainEvent.Raise(new AgenciaUsuarioEvent(Guid.Parse(usuario), nomeusuario, agenciausuario.UsuarioId, agenciausuario.Nome, agenciausuario.CPF.Codigo, model.ClaimValue, "DELETAR"));
            }
            return status;
        }

        public List<Claims> BuscarClaims()
        {
            return _agenciaService.BuscarClaims();
        }

        public ClaimsViewModel BuscarClaimsPorId(Guid id)
        {
            var claim = _agenciaService.BuscarClaimsPorId(id);
            var result = new ClaimsViewModel() { Permissao = claim.ClaimValue };
            return result;
        }

        public void AdicionarPermissao(ApplicationUser user, RegisterViewModel register)
        {
            var claim = register.Permissao[0].ToString();
            _userManager.AddClaim(user.Id, new Claim("Systrade", claim));
        }

        public void AtualizarPermissao(ApplicationUser user, RegisterViewModel register)
        {
            var claim = register.Permissao[0].ToString();
            var permissao = _userManager.GetClaims(user.Id);
            var claimatual = "";
            foreach (var item in permissao)
            {
                claimatual = item.Value;
            }
            _userManager.RemoveClaim(user.Id, new Claim("Systrade", claimatual));
            _userManager.AddClaim(user.Id, new Claim("Systrade", claim));
        }

        public bool AtualizarUsuario(UsuarioViewModel model)
        {
            var status = false;
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;

            var user = manager.FindById(model.UsuarioId.ToString());
            var voltaremailantigo = user.Email;

            user.Email = model.Email;
            var result = manager.Update(user);

            if (result.Succeeded)
            {
                var agenciausuario = EditarUsuarioAdapter.ToDomainModel(model, user.Id);
                _agenciaService.AtualizarUsuario(agenciausuario);

                if (Commit())
                {
                    status = true;
                }

                else
                {
                    user.Email = voltaremailantigo;
                    manager.Update(user);
                    status = false;
                }
            }
            return status;
        }

        public UsuarioViewModel ObterUsuarioPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_agenciaService.BuscarAgenciaUsuarioPorId(id));
        }

        public EditarAgenciaUsuarioViewModel ObterAgenciaUsuarioEditarPorId(Guid id)
        {
            return Mapper.Map<EditarAgenciaUsuarioViewModel>(_agenciaService.BuscarAgenciaUsuarioPorId(id));
        }

        public bool AtualizarSenhaAgenciaUsuario(SenhaViewModel model)
        {
            var status = false;
            var manager = _userManager;
            model.Code = _userManager.GeneratePasswordResetToken(model.UsuarioId);
            var user = manager.FindById(model.UsuarioId);

            var result = _userManager.ResetPassword(model.UsuarioId, model.Code.ToString(), model.Password);

            if (result.Succeeded)
            {
                status = true;
                var agenciausuario = ObterAgenciaUsuarioEditarPorId(Guid.Parse(user.Id));
                DomainEvent.Raise(new AgenciaUsuarioEvent(Guid.Parse(usuario), nomeusuario, agenciausuario.UsuarioId.ToString(), agenciausuario.Nome, agenciausuario.CPF, agenciausuario.ClaimValue, "ALTERAR SENHA"));
            }
            else
            {
                var errosBr = new List<string>();
                var notificationList = new List<DomainNotification>();
                foreach (var erro in result.Errors)
                {
                    string erroBr;
                    if (erro.Contains("Senha incorreta."))
                    {
                        erroBr = "Senha atual está incorreta.";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
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
                }
                notificationList.ForEach(DomainEvent.Raise);
                result = new IdentityResult(errosBr);
            }

            return status;
        }

        public bool RestaurarAgenciaUsuario(EditarAgenciaUsuarioViewModel model)
        {
            var status = false;

            var agenciausuario = EditarAgenciaUsuarioAdapter.ToDomainModel(model);
            var user = _userManager.FindById(model.UsuarioId.ToString());

            _agenciaService.RestaurarAgenciaUsuario(agenciausuario);

            if (Commit())
            {
                status = true;
                DesbloquearUsuario(model.UsuarioId);
                DomainEvent.Raise(new AgenciaUsuarioEvent(Guid.Parse(usuario), nomeusuario, agenciausuario.UsuarioId, agenciausuario.Nome, agenciausuario.CPF.Codigo, model.ClaimValue, "RESTAURAR"));
            }

            return status;
        }
        public bool DesbloquearUsuario(Guid id)
        {
            var status = false;
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;
            var user = manager.FindById(id.ToString());
            user.LockoutEndDateUtc = DateTime.UtcNow.AddYears(-100);
            var result = manager.Update(user);

            if (result.Succeeded)
                status = true;

            return status;
        }
    }
}

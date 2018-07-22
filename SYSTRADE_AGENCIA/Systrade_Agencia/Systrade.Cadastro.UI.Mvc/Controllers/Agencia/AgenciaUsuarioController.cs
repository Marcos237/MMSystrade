using System;
using System.Net;
using System.Web.Mvc;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.Services;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Model;
using Systrade.CrossCutting.Filters;
using Systyrade.Eventos.Aplicacao.Repository;

namespace Systrade.Cadastro.UI.Mvc.Controllers.Agencia
{
    [Authorize]
    [ClaimsAuthorize("Systrade", "A")]
    [RoutePrefix("AgenciaUsuario")]
    [Route("{action=manipular}")]
    public class AgenciaUsuarioController : BaseController
    {
        private readonly IAgenciaAppService _agenciaappservice;        

        public AgenciaUsuarioController(AgenciaAppservice agenciaappservice)
        {
            _agenciaappservice = agenciaappservice;
        }

        [Route("listar-usuario")]
        public ActionResult ListarUsuarios(AgenciaUsuarioViewModel model, int pageNumber = 1)
        {
            var agencia = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));

            var paged = _agenciaappservice.ObterTodosAgenciaUsuario(agencia.AgenciaId, model.Buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = model.Buscar;
            ViewBag.Count = paged.Count;


            if (contador > 0)
            {
                ViewBag.Menssagem = "Dados atualizado com sucesso!";
                contador = 0;
            }
            return View("ListarUsuarios", paged.List);
        }

        [HttpPost]
        [Route("listar-permissao")]
        public JsonResult BuscarPermissoes()
        {
            var retorno = _agenciaappservice.BuscarClaims();
            if (_agenciaappservice == null)
                ValidarErrosDominio();

            return Json(new { retorno }, JsonRequestBehavior.AllowGet);
        }

        // GET: AgenciaUsuario/Create
        [Route("adicionar-usuario")]
        public ActionResult AdicionarAgenciaUsuario(Guid? id)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaUsuarioViewModel usuario = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));
            ViewBag.AgenciaId = usuario.AgenciaId;
            return PartialView("_AdicionarAgenciaUsuario");

        }

        // POST: AgenciaUsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("adicionar-usuario")]
        public ActionResult AdicionarAgenciaUsuario(AgenciaUsuarioViewModel model)
        {
            RegisterViewModel register = new RegisterViewModel()
            {
                AgenciaId = model.AgenciaId,
                UsuarioId = model.UsuarioId,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                CPF = model.CPF,
                Celular = model.Celular,
                TelefoneFixo = model.TelefoneFixo,
                Email = model.Email,
                Descricao = model.Descricao,
                Permissao = model.ClaimValue,
                Login = model.Login,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,

            };

            if (ModelState.IsValid)
            {
                var result = _agenciaappservice.AdicionarIdentidade(register);

                if (result.Succeeded)
                {
                    contador = 1;
                    string url = Url.Action("ListarUsuarios", "AgenciaUsuario", new { id = model.AgenciaId });
                    return Json(new { success = true, url = url });
                }
                ValidarErrosDominio();
            }

            return PartialView("_AdicionarAgenciaUsuario", model);
        }

        // GET: AgenciaUsuario/Edit/5
        [Route("editar-usuario/{id:guid}")]
        public ActionResult AtualizarAgenciaUsuario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditarAgenciaUsuarioViewModel model = _agenciaappservice.ObterAgenciaUsuarioEditarPorId(id.Value);
            return PartialView("_AtualizarAgenciausuario", model);
        }

        // POST: AgenciaUsuario/Edit/5
        [HttpPost]
        [Route("editar-usuario/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarAgenciaUsuario(EditarAgenciaUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_agenciaappservice.AtualizarAgenciaUsuario(model) == false)
                    ValidarErrosDominio();
                else
                {
                    contador = 1;

                    string url = Url.Action("ListarUsuarios", "AgenciaUsuario", new { id = model.AgenciaId });
                    return Json(new { success = true, url = url });

                }

            }
            return PartialView("_AtualizarAgenciaUsuario", model);

        }

        [Route("atualizar-usuario/{id:guid}")]
        public ActionResult AtualizarUsuario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel model = _agenciaappservice.ObterUsuarioPorId(id.Value);
            return PartialView("AtualizarUsuario", model);
        }

        // POST: AgenciaUsuario/Edit/5
        [HttpPost]
        [Route("atualizar-usuario/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarUsuario(UsuarioViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_agenciaappservice.AtualizarUsuario(model) == false)
                    ValidarErrosDominio();
                else
                {
                    ViewBag.Menssagem = "Dados atualizados com sucesso!";
                }

            }
            return View("AtualizarUsuario", model);
        }

        [Route("atualizar-senha/{id:guid}")]
        public ActionResult AlterarSenha(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UsuarioId = id;
            return PartialView("_AlterarSenha");
        }

        [HttpPost]
        [Route("atualizar-senha/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(SenhaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_agenciaappservice.AtualizarSenhaAgenciaUsuario(model) == false)
                    ValidarErrosDominio();
                else
                {
                    contador = 1;

                    string url = Url.Action("ListarUsuarios", "AgenciaUsuario", new { id = model.UsuarioId });
                    return Json(new { success = true, url = url });
                }
            }

            return PartialView("_AlterarSenha", model);
        }

        // GET: AgenciaUsuario/Delete/5
        [Route("excluir-usuario/{id:guid}")]
        [HttpGet]
        public ActionResult DeletarUsuario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditarAgenciaUsuarioViewModel model = _agenciaappservice.ObterAgenciaUsuarioEditarPorId(id.Value);
            return PartialView("_DeletarUsuario", model);
        }

        // POST: AgenciaUsuario/Delete/5
        [Route("excluir-usuario/{id:guid}")]
        [HttpPost, ActionName("DeletarUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarUsuarioConfirmacao(Guid id)
        {
            EditarAgenciaUsuarioViewModel model = _agenciaappservice.ObterAgenciaUsuarioEditarPorId(id);

            if (model != null)
            {
                if (_agenciaappservice.DeletarAgenciaUsuario(model))
                {
                    contador = 1;
                    string url = Url.Action("ListarUsuarios", "AgenciaUsuario", new { id = model.AgenciaId });
                    return Json(new { success = true, url = url });
                }
                ValidarErrosDominio();
            }

            return PartialView("_DeletarUsuario", model);
        }

        [HttpPost]
        public JsonResult BuscarPermissaoUsuario(Guid? id)
        {
            ClaimsViewModel claim = new ClaimsViewModel();
            if (id != null)
                claim = _agenciaappservice.BuscarClaimsPorId(id.Value);

            return Json(new { claim.Permissao }, JsonRequestBehavior.AllowGet);
        }

        [Route("listar-inativos")]
        public ActionResult ListarUsuariosInativos(AgenciaUsuarioViewModel model, int pageNumber = 1)
        {
            var agencia = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));

            var paged = _agenciaappservice.ObterTodosAgenciaUsuarioInativos(agencia.AgenciaId, model.Buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = model.Buscar;
            ViewBag.Count = paged.Count;


            if (contador > 0)
            {
                ViewBag.Menssagem = "Dados atualizado com sucesso!";
                contador = 0;
            }
            return View("ListarUsuariosInativos", paged.List);
        }

        // GET: AgenciaUsuario/Delete/5
        [Route("restaurar-usuario/{id:guid}")]
        [HttpGet]
        public ActionResult RestaurarAgencuaUsuario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditarAgenciaUsuarioViewModel model = _agenciaappservice.ObterAgenciaUsuarioEditarPorId(id.Value);
            return PartialView("_RestaurarUsuarios", model);
        }

        // POST: AgenciaUsuario/Delete/5
        [Route("restaurar-usuario/{id:guid}")]
        [HttpPost, ActionName("RestaurarAgencuaUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult RestaurarAgencuaUsuarioConfirmacao(Guid id)
        {
            EditarAgenciaUsuarioViewModel model = _agenciaappservice.ObterAgenciaUsuarioEditarPorId(id);

            if (model != null)
            {
                if (_agenciaappservice.RestaurarAgenciaUsuario(model))
                {
                    contador = 1;
                    string url = Url.Action("ListarUsuariosInativos", "AgenciaUsuario", new { id = model.AgenciaId });
                    return Json(new { success = true, url = url });
                }
                ValidarErrosDominio();
            }

            return PartialView("_RestaurarUsuarios", model);
        }

    }
}

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.Services;
using Systrade.Aplicacao.ViewModel;
using Systrade.CrossCutting.Filters;

namespace Systrade.Cadastro.UI.Mvc.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Systrade", "A")]
    [RoutePrefix("Agencia")]
    [Route("{action=manipular}")]
    public class AgenciaController : BaseController
    {
        private readonly IAgenciaAppService _agenciaappservice;

        public AgenciaController(AgenciaAppservice agenciaappservice)
        {
            _agenciaappservice = agenciaappservice;
        }
        // GET: AgenciaUsuario
        [Route("listar-endereco")]
        public ActionResult ListarEnderecos(EnderecoViewModel model, int pageNumber = 1)
        {
            var agencia = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));

            var paged = _agenciaappservice.ObterTodosEnderecos(agencia.AgenciaId, model.Buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = model.Buscar;
            ViewBag.Count = paged.Count;

            if (contador > 0)
            {
                ViewBag.Menssagem = "Dados atualizado com sucesso!";
                contador = 0;
            }

            return View("ListarEnderecos", paged.List);
        }

        // GET: AgenciaUsuario/Details/5
        [HttpGet]
        [Route("atualizar-endereco/{id:guid}")]
        public ActionResult AtualizarEndereco(Guid? id)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var enderecos = _agenciaappservice.ObterEnderecoPorId(id.Value);
            return PartialView("_AtualizarEndereco", enderecos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("atualizar-endereco/{id:guid}")]
        public ActionResult AtualizarEndereco(EnderecoViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_agenciaappservice.AtualizarEndereco(model) == false)
                    ValidarErrosDominio();
                else
                    contador = 1;


                string url = Url.Action("ListarEnderecos", "Agencia", new { id = model.AgenciaId });
                return Json(new { success = true, url = url });

            }
            return PartialView("_AtualizarEndereco", model);
        }

        // GET: AgenciaUsuario/Create
        [Route("adicionar-novo")]
        public ActionResult AdicionarEndereco(Guid? id)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaUsuarioViewModel endereco = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));
            ViewBag.AgenciaId = endereco.AgenciaId;
            return PartialView("_AdicionarEndereco");
        }

        // POST: AgenciaUsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("adicionar-novo")]
        public ActionResult AdicionarEndereco(EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endereco = _agenciaappservice.AdaptarEndereco(model);
                if (_agenciaappservice == null)
                    ValidarErrosDominio();
                else
                    contador = 1;

                string url = Url.Action("ListarEnderecos", "Agencia", new { id = model.AgenciaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", model);
        }

        [Route("excluir-endereco/{id:guid}")]
        [HttpGet]
        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_agenciaappservice == null)
                return HttpNotFound();

            var endereco = _agenciaappservice.ObterEnderecoPorId(id.Value);

            return PartialView("_DeletarEnderecos", endereco);
        }

        [Route("excluir-endereco/{id:guid}")]
        [HttpPost, ActionName("DeletarEndereco")]
        public ActionResult DeletarEnderecoConfirmacao(Guid id)
        {
            var agenciaid = _agenciaappservice.ObterEnderecoPorId(id);
            _agenciaappservice.DeletarEndereco(id);

            if (_agenciaappservice == null)
                ValidarErrosDominio();

            else
                contador = 1;

            string url = Url.Action("ListarEnderecos", "Agencia", new {id = agenciaid });
            return Json(new { success = true, url = url });
        }

        // GET: AgenciaUsuario/Edit/5
        [Route("editar/{id:guid}")]
        public ActionResult EditarAgencia(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaViewModel model = _agenciaappservice.ObterPorId(id.Value);

            return View(model);
        }

        // POST: AgenciaUsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{id:guid}")]
        public ActionResult EditarAgencia(AgenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_agenciaappservice.AtualizarAgencia(model) == false)
                    ValidarErrosDominio();
                else
                    ViewBag.Menssagem = "Dados atualizados com sucesso!";
            }
            return View();
        }

        public ActionResult BloquearConta()
        {
            return View();
        }


        public ActionResult ExcluirConta(Guid id)
        {
            if (_agenciaappservice.BloquearUsuario(id) == true)
            {
                var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
                AuthenticationManager.SignOut();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Systrade.Aplicacao.Interface;
using Systrade.Clientes.Applications.Interfaces;
using Systrade.Clientes.Applications.Services;
using Systrade.Clientes.Applications.ViewModel;
using Systrade.CrossCutting.Filters;

namespace Systrade.Cadastro.UI.Mvc.Controllers.Clientes
{
    [Authorize]
    [ClaimsAuthorize("Systrade", "A")]
    [RoutePrefix("Celula")]
    [Route("{action=manipular}")]
    public class CelulaController : BaseController
    {

        private readonly IClienteAppService _clienteappservice;
        private readonly IAgenciaAppService _agenciaappservice;

        public CelulaController(ClienteAppService clienteappservice, IAgenciaAppService agenciaappservice)
        {
            _clienteappservice = clienteappservice;
            _agenciaappservice = agenciaappservice;
        }


        // GET: Cliente
        [Route("listar-celula")]
        public ActionResult ListarCelulas(CelulaViewModel model, int pageNumber = 1)
        {
            ListarCelula();

            ValidarErrosDominio();

            if (contador > 0)
            {
                ViewBag.Menssagem = "Dados atualizado com sucesso!";
                contador = 0;
            }

            return View("ListarCelulas", ListarCelulasInativas(model, pageNumber).List);
        }

        [Route("adicionar-celula")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarCelula(CelulaViewModel model)
        {
            var pageNumber = 1;

            model.CelulaId = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                if (_clienteappservice.AdicionarCelula(model) == false)
                    ValidarErrosDominio();
                else
                    ViewBag.Menssagem = "Dados atualizado com sucesso!";
            }
            return View("ListarCelulas", ListarCelulasInativas(model, pageNumber).List);
        }

        [HttpPost]
        public ActionResult AlterarCelula(CelulaViewModel model)
        {
            var pageNumber = 1;

            if (model.CelulaId != Guid.Empty)
            {
                if (_clienteappservice.AtualizarCelula(model) == false)
                    ValidarErrosDominio();
                else
                    ViewBag.Menssagem = "Dados atualizado com sucesso!";
            }
            return View("ListarCelulas", ListarCelulasInativas(model, pageNumber).List);
        }

        [Route("excluir-celula/{id:guid}")]
        [HttpGet]
        public ActionResult ExcluirCelula(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _clienteappservice.ObeterCelulaPorId(id.Value);

            ViewBag.CelulaId = model.CelulaId;

            return PartialView("_ExcluirCelula", model);
        }

        [Route("excluir-celula/{id:guid}")]
        [HttpPost, ActionName("ExcluirCelula")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirCelulaConfirmacao(Guid id)
        {
            var model = _clienteappservice.ObeterCelulaPorId(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (_clienteappservice.DeletarCelula(model))
            {
                contador = 1;
                return RedirectToAction("ListarCelulas");
            }
            ValidarErrosDominio();

            return PartialView("_ExcluirCelula", model);
        }

        [Route("restaurar-celula/{id:guid}")]
        [HttpGet]
        public ActionResult RestaurarCelulas(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _clienteappservice.ObeterCelulaPorId(id.Value);
            return PartialView("_RestaurarCelula", model);
        }

        [Route("restaurar-celula/{id:guid}")]
        [HttpPost, ActionName("RestaurarCelulas")]
        [ValidateAntiForgeryToken]
        public ActionResult RestaurarCelulaConfirmacao(Guid id)
        {

            var model = _clienteappservice.ObeterCelulaPorId(id);

            if (model != null)
            {

                if (_clienteappservice.RestaurarCelula(model))
                {
                    contador = 1;
                    string url = Url.Action("ListarCelulas", "Celula", new { id = model.AgenciaId });
                    return Json(new { success = true, url = url });
                }

                ValidarErrosDominio();
            }
            return PartialView("_RestaurarCelula", model);
        }


        #region Metodos

        public void ListarCelula()
        {
            var usuario = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));

            ViewBag.AgenciaId = usuario.AgenciaId;

            var celulas = _clienteappservice.BuscarCelulasPorAgenciaid(usuario.AgenciaId);

            ViewBag.Celulas = new SelectList(celulas, "CelulaId", "NomeCelula");

        }

        public PagedClienteViewModel<CelulaViewModel> ListarCelulasInativas(CelulaViewModel model, int pageNumber)
        {

            var usuario = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));

            var paged = _clienteappservice.ObterTodosCelulasInativos(usuario.AgenciaId, model.Buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = model.Buscar;
            ViewBag.Count = paged.Count;

            ListarCelula();

            return paged;
        }

        #endregion
    }
}
using System;
using System.Net;
using System.Web.Mvc;
using Systrade.CrossCutting.Filters;
using Systyrade.Eventos.Aplicacao.Repository;

namespace Systrade.Cadastro.UI.Mvc.Controllers.Eventos
{
    [Authorize]
    [ClaimsAuthorize("Systrade", "A")]
    [RoutePrefix("Eventos")]
    [Route("{action=manipular}")]
    public class EventosController : BaseController
    {
        private readonly IUsuarioEventsAppService _usuarioeventsappservice;
        public EventosController(IUsuarioEventsAppService usuarioeventsappservice)
        {
            _usuarioeventsappservice = usuarioeventsappservice;
        }
        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }

        [Route("informacoes-usuario/{id:guid}")]
        [HttpGet]
        public ActionResult BuscarUsuariosEvento(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _usuarioeventsappservice.BuscarUsuarioEventos(id);
            return PartialView("_ListarUsuarioEvents" , model.List);
        }
    }
}
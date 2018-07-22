using System;
using System.Net;
using System.Web.Mvc;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.ViewModel;
using Systrade.CrossCutting.Filters;

namespace Systrade.Cadastro.UI.Mvc.Controllers.Agencia
{
    [Authorize]
    [ClaimsAuthorize("Systrade", "A")]
    [RoutePrefix("Acesso")]
    [Route("{action=manipular}")]
    public class RegistroAcessoAgenciaUsuarioController : BaseController
    {
        private readonly IRegistroAppService _registroappservice;
        private readonly IAgenciaAppService _agenciaappservice;

        public RegistroAcessoAgenciaUsuarioController(IRegistroAppService registroappservice, IAgenciaAppService agenciaappservice)
        {
            _registroappservice = registroappservice;
            _agenciaappservice = agenciaappservice;
        }

        [Route("listar-usuarios")]
        public ActionResult ListarUsuarios(UserViewModel model, int pageNumber = 1)
        {
            var usuario = _agenciaappservice.ObterAgenciaUsuarioPorId(Guid.Parse(UserId));
            ViewBag.AgenciaId = usuario.AgenciaId;

            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paged = _registroappservice.ObterTodosUsers(usuario.AgenciaId, model.Buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = model.Buscar;
            ViewBag.Count = paged.Count;


            return View("ListarUsuarios", paged.List);
        }
    }
}
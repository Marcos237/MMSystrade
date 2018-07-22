using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Systrade.Aplicacao.Interface;

namespace Systrade.Cadastro.UI.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAgenciaAppService _agenciaUsuarioAppService;

        public HomeController(IAgenciaAppService agenciaUsuarioAppService)
        {
            _agenciaUsuarioAppService = agenciaUsuarioAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Lockout()
        {
            return View("Lockout");
        }
    }
}
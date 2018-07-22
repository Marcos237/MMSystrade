using System.Web.Mvc;

namespace Systrade.Cadastro.UI.Mvc.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("403");
        }

        public ActionResult NorFound()
        {
            return View("404");
        }

        public ActionResult InternalServerError()
        {
            return View("Erro");
        }
    }
}
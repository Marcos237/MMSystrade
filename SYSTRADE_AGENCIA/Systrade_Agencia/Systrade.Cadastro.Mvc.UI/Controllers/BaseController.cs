using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Systrade.Cadastro.Mvc.UI.Controllers
{
    public class BaseController : Controller
    {
        public string UserId
        {
            get
            {
                return ControllerContext.HttpContext.User.Identity.IsAuthenticated ? ControllerContext.HttpContext.User.Identity.GetUserId() : "0";
            }
        }

        public const int PageSize = 5;
    }
}
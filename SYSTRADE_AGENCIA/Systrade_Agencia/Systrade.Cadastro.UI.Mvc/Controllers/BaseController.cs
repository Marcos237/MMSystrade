using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using Systrade.Core.Events;
using Systrade.Core.Interfaces;

namespace Systrade.Cadastro.UI.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public IHandler<DomainNotification> Notifications;

       public string UserId
        {
            get
            {
                return ControllerContext.HttpContext.User.Identity.IsAuthenticated ? ControllerContext.HttpContext.User.Identity.GetUserId() : "0";
            }
        }


        public BaseController()
        {
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool ValidarErrosDominio()
        {
            if (!Notifications.HasNotifications()) return false;

            foreach (var error in Notifications.GetValues())
            {
                ModelState.AddModelError(string.Empty, error.Value);
            }
            return true;
        }

        public const int PageSize = 10;
        public static int contador = 0;
    }
}

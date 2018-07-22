using System.Web.Mvc;
using Systrade.Infra.Data.Helpers;

namespace Systrade.CrossCutting.Filters
{
    public class GlobalFilterTool : ActionFilterAttribute
    {
        private readonly ILogAuditoria _logAuditoria;

        public GlobalFilterTool(ILogAuditoria logAuditoria)
        {
            _logAuditoria = logAuditoria;
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //if (log.IsDebugEnabled)
        //    //{
        //    //    var loggingWatch = Stopwatch.StartNew();
        //    //    filterContext.HttpContext.Items.Add(StopwatchKey, loggingWatch);

        //    //    var message = new StringBuilder();
        //    //    message.Append(string.Format("Executing controller {0}, action {1}",
        //    //        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
        //    //        filterContext.ActionDescriptor.ActionName));

        //    //    log.Debug(message);
        //    //}
        //}
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _logAuditoria.RegistrarLog(filterContext);

            if (filterContext.Exception != null)
            {
                filterContext.Controller.TempData["ErrorMessage"] = filterContext.Exception.Message;
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}
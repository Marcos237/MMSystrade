﻿using System.Web.Mvc;
using Systrade.Auditoria.Infra.Data.Helpers;

namespace Systrade.Auditoria.Infra.CrossCutting.Filters
{
    public class GlobalFilterTool : ActionFilterAttribute
    {
        private readonly ILogAuditoria _logAuditoria;

        public GlobalFilterTool(ILogAuditoria logAuditoria)
        {
            _logAuditoria = logAuditoria;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Inicio Log - Metodo, detalhes
        }

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
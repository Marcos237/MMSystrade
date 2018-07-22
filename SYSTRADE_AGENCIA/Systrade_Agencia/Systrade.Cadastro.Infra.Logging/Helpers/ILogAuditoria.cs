using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Systrade.Cadastro.Infra.Logging.Entidades;

namespace Systrade.Infra.Data.Helpers
{
    public interface ILogAuditoria 
    {
        void RegistrarLog(ActionExecutedContext filterContext);
        IEnumerable<Auditoria> ObterLogs();
    }
}

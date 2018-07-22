using Microsoft.AspNet.Identity;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Systrade.Cadastro.Infra.Logging.Entidades;
using Systrade.Infra.Data.Helpers;

namespace Systrade.Cadstro.Infra.CrossCutting.Loggin
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LogAuditoriaHelper : ILogAuditoria
    {
        MongoRepository<Auditoria> _context = new MongoRepository<Auditoria>();
        MongoRepository<ExceptionAuditoria> _exception = new MongoRepository<ExceptionAuditoria>();
        public Dictionary<string, string> Item = new Dictionary<string, string>();

        public LogAuditoriaHelper()
        {
        }

        public void RegistrarLog(ActionExecutedContext filterContext)
        {
            try
            {
                var modelJson = "";
                if (filterContext.HttpContext.Request.HttpMethod.ToLower() == "post")
                {
                    var form = Form(filterContext.HttpContext);
                    form.Remove(form.First(c => c.Key == "__RequestVerificationToken"));
                    modelJson = form.Aggregate("{", (current, item) => current + string.Format("'{0}':" + "'{1}',", item.Key, item.Value)) + "}";
                }

                var log = new Auditoria(
                    filterContext.HttpContext.User.Identity.IsAuthenticated
                        ? filterContext.HttpContext.User.Identity.GetUserName()
                        : "Anonimo",

                    "Sistema Modelo MVC",
                    GetIP(filterContext),
                    filterContext.HttpContext.Request.Url.AbsoluteUri,
                    modelJson);

                _context.Add(log);
            }
            catch (Exception ex)
            {

                var exception = new ExceptionAuditoria(
                       filterContext.HttpContext.User.Identity.IsAuthenticated
                        ? filterContext.HttpContext.User.Identity.GetUserName()
                        : "Anonimo",
                    "Sistema Modelo MVC",
                    GetIP(filterContext),
                    filterContext.HttpContext.Request.Url.AbsoluteUri,
                    ex.Message);

                _exception.Add(exception);

            }
        }

        private static List<Item> Form(HttpContextBase httpContext)
        {
            var result = httpContext.Request.Form.Keys.OfType<string>().Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
            return result;
        }

        public string GetIP(ActionExecutedContext filterContext)
        {
            return filterContext.HttpContext.Request.ServerVariables["SERVER_NAME"] == "localhost" ? "Acesso Local" : filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
        }

        public IEnumerable<Auditoria> ObterLogs()
        {
            throw new NotImplementedException();
        }
    }

    public class Item
    {
        public string Key { get; set; } 
        public string Value { get; set; }

        public Item(string key, string value)
        {
            Key = key;
            Value = value;
        }

    }
}
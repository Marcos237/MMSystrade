using Systrade.Cadastro.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Systrade.Cadastro.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("Systrade.Cadastro", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
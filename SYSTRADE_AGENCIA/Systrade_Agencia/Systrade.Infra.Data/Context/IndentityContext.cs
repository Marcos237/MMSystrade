using System.Data.Entity;
using Systrade.Dominio.Entidade;
using Systrade.Infra.Data.EntityConfiguration;

namespace Systrade.Infra.Data.Context
{
    public class IndentityContext : DbContext
    {
        public IndentityContext()
            : base("Systrade.Cadastro")
        {

        }

        public DbSet<UsuarioIdentity> UsuarioIdentity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioIdentityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

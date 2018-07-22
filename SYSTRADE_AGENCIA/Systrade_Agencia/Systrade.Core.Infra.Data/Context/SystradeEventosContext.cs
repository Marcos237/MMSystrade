using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Systrade.Auditoria.Entidades;

namespace Systrade.Auditoria.Infra.Data.Context
{
    public class SystradeAuditoriaContext : DbContext
    {
        public SystradeAuditoriaContext()
            : base("Systrade.Auditoria")
        {

        }

        public DbSet<CadastroAuditoria> Entity { get; set; }
        public DbSet<AuditoriaEvents> AuditoriaEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                 .Where(p => p.Name == p.ReflectedType.Name + "Id")
                 .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new CadastroAuditoriaConfiguration());
            modelBuilder.Configurations.Add(new AuditoriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ChangeDb
    {
        public static void ChangeConnection(this SystradeAuditoriaContext context, string con)
        {
            context.Database.Connection.ConnectionString = con;
        }
    }
}


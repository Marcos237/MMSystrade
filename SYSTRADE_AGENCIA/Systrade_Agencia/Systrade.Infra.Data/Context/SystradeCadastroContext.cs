using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;
using Systrade.Infra.Data.EntityConfiguration;

namespace Systrade.Infra.Data.Context
{
    public class SystradeCadastroContext : DbContext
    {
        public SystradeCadastroContext()
                  : base("Systrade.Cadastro")
        {
        }

        public DbSet<UsuarioIdentity> UsuarioIdentity { get; set; }
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<AgenciaUsuario> AgenciaUsuario { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<RegistroUsuario> RegistroUsuario { get; set; }

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

            modelBuilder.Configurations.Add(new UsuarioIdentityConfiguration());
            modelBuilder.Configurations.Add(new AgenciaConfiguration());
            modelBuilder.Configurations.Add(new AgenciaUsuarioConfiguration());
            modelBuilder.Configurations.Add(new EnderecosConfiguration());
            modelBuilder.Configurations.Add(new ClaimsConfigurtation());
            modelBuilder.Configurations.Add(new RegistroUsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
    public static class ChangeDb
    {
        public static void ChangeConnection(this SystradeCadastroContext context, string con)
        {
            context.Database.Connection.ConnectionString = con;
        }
    }
}


using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class UsuarioIdentityConfiguration: EntityTypeConfiguration<UsuarioIdentity>
    {
        public UsuarioIdentityConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired();

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}

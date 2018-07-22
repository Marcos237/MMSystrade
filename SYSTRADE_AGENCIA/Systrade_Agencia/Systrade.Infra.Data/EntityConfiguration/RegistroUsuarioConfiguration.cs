using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Entidades;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class RegistroUsuarioConfiguration : EntityTypeConfiguration<RegistroUsuario>
    {
        public RegistroUsuarioConfiguration()
        {
            HasKey(u => u.RegistroUsuarioId);

            Property(u => u.UsuarioId)
                 .IsRequired();

            Property(c => c.UserName)
                 .IsRequired()
                 .HasMaxLength(100);

            Property(c => c.IP)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Registro)
                .IsOptional();

            Property(f => f.DataCadastro)
                .HasColumnType("datetime2")
                .HasPrecision(0);


            ToTable("RegistroUsuario");
        }
    }
}

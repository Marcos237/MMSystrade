using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Entidade.Cadastro;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class ClaimsConfigurtation : EntityTypeConfiguration<Claims>
    {
        public ClaimsConfigurtation()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired();

            Property(u => u.ClaimValue)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetClaims");
        }
    }
}

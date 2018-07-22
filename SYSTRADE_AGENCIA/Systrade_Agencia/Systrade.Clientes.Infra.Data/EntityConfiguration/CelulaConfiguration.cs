using System.Data.Entity.ModelConfiguration;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Infra.Data.EntityConfiguration
{
    public class CelulaConfiguration : EntityTypeConfiguration<Celula>
    {
        public CelulaConfiguration()
        {
            HasKey(u => u.CelulaId);

            Property(u => u.CelulaId)
                    .IsRequired();

            Property(u => u.AgenciaId)
                    .IsRequired();

            Property(c => c.NomeCelula)
                 .IsRequired()
                 .HasMaxLength(150);

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.Status)
              .HasColumnName("Status")
              .IsRequired();

            Ignore(c => c.ValidationResult);


            ToTable("Celula");
        }
    }
}
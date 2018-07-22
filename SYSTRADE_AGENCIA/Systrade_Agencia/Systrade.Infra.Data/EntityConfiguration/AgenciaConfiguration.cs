using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Entidade;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class AgenciaConfiguration : EntityTypeConfiguration<Agencia>
    {
        public AgenciaConfiguration()
        {
            HasKey(u => u.AgenciaId);

            Property(u => u.AgenciaId)
                    .IsRequired();

            Property(c => c.NomeFantasia)
                 .IsRequired()
                 .HasMaxLength(100);

            Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CNPJ.Codigo)
                 .HasColumnName("CNPJ")
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength();
            //.HasColumnAnnotation("Index", new IndexAnnotation(
            //    new IndexAttribute("IX_CNPJ") { IsUnique = true }));

            Property(c => c.TelefoneFixo)
               .HasColumnName("TelefoneFixo")
               .HasMaxLength(10)
               .IsOptional();

            Property(c => c.DataCadastro)
                .IsRequired();

            Ignore(c => c.ValidationResult);


            ToTable("Agencia");
        }
    }
}

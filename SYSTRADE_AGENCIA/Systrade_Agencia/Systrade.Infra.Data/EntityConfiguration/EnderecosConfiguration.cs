using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class EnderecosConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecosConfiguration()
        {
            HasKey(u => u.EnderecoId);

            Property(c => c.Descricao)
                  .HasColumnName("Descricao")
                  .HasMaxLength(150);

            Property(c => c.Logradouro)
                 .HasColumnName("Logradouro")
                 .IsRequired()
                 .HasMaxLength(150);

            Property(c => c.Numero)
                .HasColumnName("Numero")
                .IsRequired()
                .HasMaxLength(6);

            Property(c => c.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(100);

            Property(e => e.Cep.CepCod)
                .HasColumnName("Cep")
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Cidade)
               .HasColumnName("Cidade")
               .IsRequired()
               .HasMaxLength(150);

            Property(e => e.Estado)
                .HasColumnName("Estado")
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();

            Property(u => u.AgenciaId)
                .HasColumnName("AgenciaId")
                 .IsRequired();

            ToTable("Enderecos");
        }
    }
}

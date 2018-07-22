using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Systrade.Dominio.Entidade.Usuarios;

namespace Systrade.Infra.Data.EntityConfiguration
{
    public class AgenciaUsuarioConfiguration : EntityTypeConfiguration<AgenciaUsuario>
    {
        public AgenciaUsuarioConfiguration()
        {
            HasKey(u => u.UsuarioId);

            Property(c => c.Nome)
                 .HasColumnName("Nome")
                 .IsRequired()
                 .HasMaxLength(100);

            Property(c => c.Sobrenome)
                 .IsRequired()
                 .HasMaxLength(100);

            Property(c => c.CPF.Codigo)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.Telefone.Celular)
                .HasColumnName("Celular")
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            Property(c => c.Telefone.Fixo)
              .HasColumnName("TelefoneFixo")
               .HasMaxLength(10)
               .IsOptional();

            Property(c => c.Email.Endereco)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Descricao)
              .HasColumnName("Descricao")
              .HasMaxLength(150);


            Property(c => c.DataCadastro)
                 .HasColumnName("DataCadastro")
                .IsRequired();

            Property(c => c.Status)
               .HasColumnName("Status")
               .IsRequired();

            Ignore(c => c.ValidationResult);

            Property(u => u.AgenciaId)
                .HasColumnName("AgenciaId")
                .IsRequired();

            Ignore(a => a.ClaimValue);
 
            ToTable("AgenciaUsuario");
        }
    }
}

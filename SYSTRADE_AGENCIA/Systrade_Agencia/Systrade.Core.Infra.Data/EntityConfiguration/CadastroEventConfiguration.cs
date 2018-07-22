using System.Data.Entity.ModelConfiguration;
using Systrade.Auditoria.Entidades;

namespace Systrade.Auditoria.Infra.Data
{
    public class CadastroAuditoriaConfiguration : EntityTypeConfiguration<CadastroAuditoria>
    {
        public CadastroAuditoriaConfiguration()
        {
            HasKey(u => u.CadastroAuditoriaId);

            Property(u => u.CadastroAuditoriaId)
                     .IsRequired();

            Property(u => u.UsuarioId)
                     .IsRequired();

            Property(u => u.Id)
                     .IsRequired();

            Property(u => u.UserName)
                    .HasMaxLength(150)
                    .HasColumnName("UserName");

            Property(u => u.Login)
                   .HasMaxLength(150)
                   .HasColumnName("Login");

            Property(u => u.Permissao)
                   .HasMaxLength(150)
                   .HasColumnName("Permissao");

            Property(c => c.Versao)
                    .HasColumnName("Versao")
                    .IsRequired();

            Property(c => c.DataOcorrencia)
                    .HasColumnName("DataOcorrencia")
                    .IsRequired();

            Property(c => c.Menssagem)
                   .HasMaxLength(150)
                   .IsRequired();

            ToTable("CadastroAuditoria");
        }
    }
}

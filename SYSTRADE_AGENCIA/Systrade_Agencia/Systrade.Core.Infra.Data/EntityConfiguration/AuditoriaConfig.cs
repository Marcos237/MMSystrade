using System.Data.Entity.ModelConfiguration;
using Systrade.Auditoria.Entidades;

namespace Systrade.Auditoria.Infra.Data
{
    public class AuditoriaConfiguration : EntityTypeConfiguration<AuditoriaEvents>
    {
        public AuditoriaConfiguration()
        {
            HasKey(a => a.LogId);

            Property(a => a.LogId)
                .IsRequired();

            Property(a => a.Sistema)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(a => a.Acao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            Property(a => a.IP)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(a => a.UserId)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            ToTable("LogAuditoria");
        }
    }
}
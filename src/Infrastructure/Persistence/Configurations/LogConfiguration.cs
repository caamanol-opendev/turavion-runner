using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> entity)
        {
            entity.HasKey(e => e.IdLog).HasName("PK__Logs__5CF3429876BF1EE2");

            entity.Property(e => e.IdLog).HasColumnName("Id_Log");
            entity.Property(e => e.Accion)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.EmailAgente)
                .HasMaxLength(250)
                .HasColumnName("Email_Agente");
            entity.Property(e => e.EmailCliente)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("Email_Cliente");
            entity.Property(e => e.Estado).HasMaxLength(64);
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaRegistroSolicitud)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro_Solicitud");
            entity.Property(e => e.IdSolicitudPago).HasColumnName("Id_Solicitud_Pago");
            entity.Property(e => e.NroOrden)
                .HasMaxLength(26)
                .HasColumnName("Nro_Orden");
            entity.Property(e => e.RolAgente)
                .HasMaxLength(100)
                .HasColumnName("Rol_Agente");
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SolicitudesPagoConfiguration : IEntityTypeConfiguration<SolicitudPagoEntity>
    {
        public void Configure(EntityTypeBuilder<SolicitudPagoEntity> entity)
        {
            entity.HasKey(e => e.IdSolicitudPago).HasName("PK__Solicitu__134518D9C44AA1F8");

            entity.ToTable("Solicitudes_Pago");

            entity.Property(e => e.IdSolicitudPago).HasColumnName("Id_Solicitud_Pago");
            entity.Property(e => e.CodCliente)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Cod_Cliente");
            entity.Property(e => e.EmailId).HasColumnName("Email_Id");
            entity.Property(e => e.Estado).HasMaxLength(64);
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Expiracion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.LinkPago)
                .HasMaxLength(255)
                .HasColumnName("Link_Pago");
            entity.Property(e => e.Moneda)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.NegocioCod)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Negocio_Cod");
            entity.Property(e => e.NombreAgente)
                .HasMaxLength(250)
                .HasColumnName("Nombre_Agente");
            entity.Property(e => e.NombreCliente)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("Nombre_Cliente");
            entity.Property(e => e.NroOrden)
                .HasMaxLength(26)
                .HasColumnName("Nro_Orden");
            entity.Property(e => e.RespuestaTransBank).HasColumnName("Respuesta_TransBank");
            entity.Property(e => e.RolAgente)
                .HasMaxLength(100)
                .HasColumnName("Rol_Agente");
            entity.Property(e => e.Sesion).HasMaxLength(61);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.Token).HasMaxLength(64);
            entity.Property(e => e.Valor).HasColumnType("decimal(17, 2)");

            entity.HasOne(d => d.Email).WithMany(p => p.SolicitudesPagos)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("FK_SolicitudesPago_Emails");
        }
    }
}

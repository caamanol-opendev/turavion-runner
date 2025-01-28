using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{

    public class MailConfiguration : IEntityTypeConfiguration<MailEntity>
    {
        public void Configure(EntityTypeBuilder<MailEntity> entity)
        {
            entity.HasKey(e => e.IdMail).HasName("PK__Mails__FFD3C1FBBE69490C");

            entity.Property(e => e.IdMail).HasColumnName("Id_Mail");
            entity.Property(e => e.AsuntoMsgExitoso).HasColumnName("Asunto_Msg_Exitoso");
            entity.Property(e => e.AsuntoMsgExpira).HasColumnName("Asunto_Msg_Expira");
            entity.Property(e => e.AsuntoMsgExpirado).HasColumnName("Asunto_Msg_Expirado");
            entity.Property(e => e.AsuntoMsgRechazado).HasColumnName("Asunto_Msg_Rechazado");
            entity.Property(e => e.AsuntoMsgSolicitud).HasColumnName("Asunto_Msg_Solicitud");
            entity.Property(e => e.MailMsgExitoso).HasColumnName("Mail_Msg_Exitoso");
            entity.Property(e => e.MailMsgExpira).HasColumnName("Mail_Msg_Expira");
            entity.Property(e => e.MailMsgExpirado).HasColumnName("Mail_Msg_Expirado");
            entity.Property(e => e.MailMsgRechazado).HasColumnName("Mail_Msg_Rechazado");
            entity.Property(e => e.MailMsgSolicitud).HasColumnName("Mail_Msg_Solicitud");
        }
    }
}

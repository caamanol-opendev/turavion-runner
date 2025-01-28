using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<EmailEntity>
    {
        public void Configure(EntityTypeBuilder<EmailEntity> entity)
        {
            entity.HasKey(e => e.IdEmail).HasName("PK__Emails__ADE1290CE42387E5");

            entity.Property(e => e.IdEmail).HasColumnName("Id_Email");
            entity.Property(e => e.EmailAdministrativo)
                .HasMaxLength(250)
                .HasColumnName("Email_Administrativo");
            entity.Property(e => e.EmailAgente)
                .HasMaxLength(250)
                .HasColumnName("Email_Agente");
            entity.Property(e => e.EmailCliente)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("Email_Cliente");
        }
    }
}

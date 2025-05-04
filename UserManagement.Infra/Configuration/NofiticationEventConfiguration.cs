using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Events;

namespace UserManagement.Infra.Configuration
{
    public class NotificationEventConfiguration : IEntityTypeConfiguration<NotificationEvent>
    {
        public void Configure(EntityTypeBuilder<NotificationEvent> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Type)
                .IsRequired();

            builder.Property(n => n.Timestamp)
                .IsRequired();

            // Configurando o Dictionary como JSON
            builder.Property(n => n.Data)
                .HasColumnType("json")
                .IsRequired();

            // Definindo o nome da tabela
            builder.ToTable("NotificationEvents");
        }
    }
}
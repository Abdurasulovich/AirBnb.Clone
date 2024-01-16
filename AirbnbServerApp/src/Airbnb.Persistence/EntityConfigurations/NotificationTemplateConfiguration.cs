using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;
///<summary>
/// Entity type configuration for the NotificationTemplate class.
///</summary>
public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    ///<summary>
    /// Configures the entity type properties and behavior for the NotificationTemplate class.
    ///</summary>
    ///<param name="builder">The entity type builder used to configure the NotificationTemplate entity.</param>
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(129_536);
        builder.HasIndex(
                template => new
                {
                    template.Type,
                    template.TemplateType
                })
            .IsUnique();

        builder.ToTable("NotificationTemplates")
            .HasDiscriminator(emailTemplate => emailTemplate.Type)
            .HasValue<EmailTemplate>(NotificationType.Email);
    }
}

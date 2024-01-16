using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;

///<summary>
/// Entity type configuration for the UserSettings class.
///</summary>
public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
{
    ///<summary>
    /// Configures the entity type properties and behavior for the UserSettings class.
    ///</summary>
    ///<param name="builder">The entity type builder used to configure the UserSettings entity.</param>
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasOne<User>().WithOne(user => user.UserSettings).HasForeignKey<UserSettings>(settings => settings.Id);
    }
}

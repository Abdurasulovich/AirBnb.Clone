using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;
///<summary>
/// Entity type configuration for the User class.
///</summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    ///<summary>
    /// Configures the entity type properties and behavior for the User class.
    ///</summary>
    ///<param name="builder">The entity type builder used to configure the User entity.</param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(64);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(64);
        builder.Property(user => user.EmailAddress).IsRequired().HasMaxLength(64);
        builder.Property(user => user.PasswordHash).IsRequired().HasMaxLength(256);

        builder.HasIndex(user => user.EmailAddress).IsUnique();
    }
}

using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;
///<summary>
/// Entity type configuration for the UserInfoVerificationCode class.
///</summary>
public class UserInfoVerificationCodeConfiguration : IEntityTypeConfiguration<UserInfoVerificationCode>
{
    ///<summary>
    /// Configures the entity type properties and behavior for the UserInfoVerificationCode class.
    ///</summary>
    ///<param name="builder">The entity type builder used to configure the UserInfoVerificationCode entity.</param>
    public void Configure(EntityTypeBuilder<UserInfoVerificationCode> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(code => code.UserId);
    }
}

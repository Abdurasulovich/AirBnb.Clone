using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;
///<summary>
/// Entity type configuration for the VerificationCode class.
///</summary>
public class VerificationCodeConfiguration : IEntityTypeConfiguration<VerificationCode>
{
    ///<summary>
    /// Configures the entity type properties and behavior for the VerificationCode class.
    ///</summary>
    ///<param name="builder">The entity type builder used to configure the VerificationCode entity.</param>
    public void Configure(EntityTypeBuilder<VerificationCode> builder)
    {
        builder.HasDiscriminator(verificationCode => verificationCode.Type)
            .HasValue<UserInfoVerificationCode>(VerificationType.UserActionVerificationCode);

        builder.Property(code => code.Code).IsRequired().HasMaxLength(64);
        builder.Property(code => code.VerificationLink).IsRequired().HasMaxLength(256);
    }
}

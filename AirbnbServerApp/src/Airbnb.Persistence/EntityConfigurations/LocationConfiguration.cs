using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(location=>location.Name).IsRequired().HasMaxLength(256);
        builder.Property(location=>location.ImageUrl).IsRequired().HasMaxLength(256);
        builder.Property(location=>location.BuiltYear).IsRequired().HasMaxLength(256);
        builder.Property(location=>location.FeedBack).IsRequired().HasMaxLength(256);
        builder.Property(location=>location.PricePerNight).IsRequired().HasMaxLength(256);

        builder.HasOne(location => location.Category)
            .WithMany(category => category.Locations)
            .HasForeignKey(location => location.CategoryId); 
    }
}
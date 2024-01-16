using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Persistence.DataContexts;

///<summary>
/// DbContext for managing notifications, including email templates and histories.
///</summary>
public class NotificationDbContext(DbContextOptions<NotificationDbContext> options) : DbContext(options)
{
    ///<summary>
    /// Gets or sets the DbSet for EmailTemplates.
    ///</summary>
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    ///<summary>
    /// Gets or sets the DbSet for EmailHistories.
    ///</summary>
    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    ///<summary>
    /// Configures the model and its relationships for the DbContext.
    ///</summary>
    ///<param name="modelBuilder">The model builder to use for configuration.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}
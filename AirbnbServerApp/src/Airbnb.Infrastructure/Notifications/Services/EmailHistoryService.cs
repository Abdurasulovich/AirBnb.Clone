using Airbnb.Application.Common.Notifications.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using AirBnB.Persistence.Extensions;
using Airbnb.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace Airbnb.Infrastructure.Notifications.Services;

public class EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IValidator<EmailHistory> emailHistoryValidator) : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository = emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator = emailHistoryValidator;
    
    
    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }

    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await _emailHistoryValidator.ValidateAsync(
            emailHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken
        );
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        return await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }
}
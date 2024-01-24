using System.Linq.Expressions;
using Airbnb.Application.Common.Notifications.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using AirBnB.Persistence.Extensions;
using Airbnb.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Notifications.Services;

public class EmailTemplateService(IEmailTemplateRepository emailTemplateRepository, IValidator<EmailTemplate> emailTemplateValidator) : IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository = emailTemplateRepository;
    private readonly IValidator<EmailTemplate> _emailTemplateValidator = emailTemplateValidator;
    
    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(FilterPagination filterPagination, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking: asNoTracking).ApplyPagination(filterPagination).ToListAsync(cancellationToken);
    }

    public async ValueTask<EmailTemplate?> GetByTypeAsync(NotificationTemplateType templateType, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _emailTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = _emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        
        return _emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

    private IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false)
    {
        return _emailTemplateRepository.Get(predicate, asNoTracking);
    }
}
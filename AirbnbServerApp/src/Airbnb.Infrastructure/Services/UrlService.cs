using Airbnb.Application.Common.Extensions;
using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Infrastructure.Common.Settings;
using Microsoft.Extensions.Options;

namespace Airbnb.Infrastructure.Services;

public class UrlService(IOptions<UrlSettings> options) : IUrlService
{
    public ValueTask<string> GetUrlFromRelativePath(string relativePath)
    {
        return new(Path.Combine(options.Value.BaseUrl, relativePath.ToUrl()));
    }
}
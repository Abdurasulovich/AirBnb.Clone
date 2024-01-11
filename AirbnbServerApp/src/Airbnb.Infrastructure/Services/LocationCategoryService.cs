using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using Microsoft.AspNetCore.Http;

namespace Airbnb.Infrastructure.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository, IUrlService urlService) : ILocationCategoryService
{
    private readonly string folderPath = "Assets/Images/";

    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = null,
        bool asNoTracking = false)
    {
        var list = new List<LocationCategory>();
        var result = locationCategoryRepository.Get(predicate, asNoTracking);
        foreach (var img in result)
        {
            img.ImagePath = "https://localhost:7043/" + img.ImagePath;
            list.Add(img);
        }
        return list.AsQueryable();
    }

    public async ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification,
        CancellationToken cancellationToken = default)
    {
        var list = new List<LocationCategory>();
        var result = await locationCategoryRepository.GetAsync(querySpecification, cancellationToken);
        foreach (var img in result)
        {
            img.ImagePath = "https://localhost:7043/" + img.ImagePath;
            list.Add(img);
        }
        return list;
    }

    public async ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationCategoryRepository.GetByIdAsync(locationCategoryId, asNoTracking, cancellationToken);

    public async ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationCategoryRepository.CreateAsync(locationCategory, saveChanges, cancellationToken);

    public async ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationCategoryRepository.UpdateAsync(locationCategory, saveChanges, cancellationToken);

    public async ValueTask<bool> DeleteAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationCategoryRepository.DeleteAsync(locationCategory, saveChanges, cancellationToken);

    public async ValueTask<bool> DeleteByIdAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationCategoryRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public async ValueTask<string> UploadImgAsync(Guid id, IFormFile imagePath, string webRootPath,
        CancellationToken cancellationToken = default)
    {
        var findFile = await GetByIdAsync(id, cancellationToken: cancellationToken) ??
                       throw new InvalidOperationException("LocationCategory with this id not found!");

        var relativePath = folderPath + id.ToString() + "." + imagePath.FileName.Split('.')[1];
        var filePath = Path.Combine(webRootPath, relativePath);
        if(File.Exists(filePath)) File.Delete(filePath);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imagePath.CopyToAsync(fileStream, cancellationToken);
        }

        findFile.ImagePath = relativePath;
        await UpdateAsync(findFile, cancellationToken: cancellationToken);
        return relativePath;
    }

    public async ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationCategoryRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    
}
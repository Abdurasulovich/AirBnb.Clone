using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using Microsoft.AspNetCore.Http;

namespace Airbnb.Infrastructure.Services;

public class LocationService(ILocationRepository locationRepository, IUrlService urlService) : ILocationService
{
    private readonly string folderPath = "Assets/Location/";
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null, bool asNoTracking = false)
        => locationRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<Location>> GetAsync(QuerySpecification querySpecification,
        CancellationToken cancellationToken = default)
    {
        var imgList = new List<Location>();
        var result = await locationRepository.GetAsync(querySpecification, cancellationToken);
        foreach (var imgs in result)
        {
            imgs.ImageUrl = "https://localhost:7043/" + imgs.ImageUrl;
            imgList.Add(imgs);
        }
        return imgList;
    }

    public async ValueTask<IList<Location>> GetByFilterAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetAsync(querySpecification, cancellationToken);

    public async ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    public async ValueTask<IList<Location>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<Location> CreateAsync(Location location, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationRepository.CreateAsync(location, saveChanges, cancellationToken);

    public async ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationRepository.UpdateAsync(location, saveChanges, cancellationToken);

    public async ValueTask<bool> DeleteAsync(Location location, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationRepository.DeleteAsync(location, saveChanges, cancellationToken);

    public async ValueTask<bool> DeleteByIdAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => await locationRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

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

        findFile.ImageUrl = relativePath;
        await UpdateAsync(findFile, cancellationToken: cancellationToken);
        return relativePath;
    }
}
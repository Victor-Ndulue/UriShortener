using Microsoft.EntityFrameworkCore;
using UriShortener.Data;
using UriShortener.Helpers;
using UriShortener.Helpers.Requests;
using UriShortener.Helpers.Responses.Dtos;
using UriShortener.Models;
using UriShortener.Services.Abstractions;

namespace UriShortener.Services.Implementations;
public class UriRepo : IUriRepo
{
    private readonly DbSet<UriDetail> _uris;
    private readonly DataContext _dataContext;
    public UriRepo(DataContext dataContext)
    {
        _uris = dataContext.UriDetails;
        _dataContext = dataContext;
    }
    public async Task<ResponseObject<UriDetailDto>> AddUri(AddUriDto addUriDto)
    {
        var baseUrl = "https://short.ly/";
        if (addUriDto.preferredPath is null) { addUriDto.preferredPath = GenerateRandomPath(); }
            var shortUrl = baseUrl + addUriDto.preferredPath;
        var alreadyShortened = await _uris.AnyAsync
            (x => x.ShortUrl == shortUrl
            || addUriDto.mainUrl.StartsWith(baseUrl));
        if (alreadyShortened) { return ReturnObject<UriDetailDto>.FailureResponse($"Short url {shortUrl} already exists or shortened"); }

        var uriDetail = new UriDetail
        {
            Id = Guid.NewGuid(),
            MainUrl = addUriDto.mainUrl,
            ShortUrl = baseUrl + addUriDto.preferredPath,
            DateCreated = DateTime.UtcNow.AddHours(1)
        };
        await _uris.AddAsync(uriDetail);
        await _dataContext.SaveChangesAsync();
        var uriDetailDto = new UriDetailDto
        {
            DateCreated = uriDetail.DateCreated,
            MainUrl = uriDetail.MainUrl,
            ShortUrl = uriDetail.ShortUrl,
        };
        return ReturnObject<UriDetailDto>.SuccessResponse(data: uriDetailDto);
    }

    public async Task<ResponseObject<UriDetailDto>> GetUriDetails(string shortUri)
    {
        var uriDetailData = _uris.Where(uri => uri.ShortUrl.Equals(shortUri))
            .AsNoTracking();
        var uriDetail = uriDetailData.FirstOrDefault();
        if (uriDetail is null)
        {
            return ReturnObject<UriDetailDto>.SuccessResponse();
        }
        else
        {
            UriDetailDto? uriDetailDto = new UriDetailDto()
            {
                DateCreated = uriDetail.DateCreated,
                MainUrl = uriDetail.MainUrl,
                ShortUrl = uriDetail.ShortUrl,
            };
            return ReturnObject<UriDetailDto>.SuccessResponse(data: uriDetailDto);
        }
    }
    private string GenerateRandomPath()
    {
        var randomPath = Guid.NewGuid()
            .ToString()
            .Substring(4, 8);
        return randomPath;
    }
}

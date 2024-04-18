using UriShortener.Helpers;
using UriShortener.Helpers.Requests;
using UriShortener.Helpers.Responses.Dtos;

namespace UriShortener.Services.Abstractions;

public interface IUriRepo
{
    Task<ReturnObject<UriDetailDto>> AddUri(AddUriDto addUriDto);
    Task<ReturnObject<UriDetailDto>> GetUriDetails(string shortUri);
}

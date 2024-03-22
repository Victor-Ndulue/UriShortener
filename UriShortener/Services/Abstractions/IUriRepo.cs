using UriShortener.Helpers;
using UriShortener.Helpers.Requests;
using UriShortener.Helpers.Responses.Dtos;

namespace UriShortener.Services.Abstractions;

public interface IUriRepo
{
    Task<ResponseObject<UriDetailDto>> AddUri(AddUriDto addUriDto);
    Task<ResponseObject<UriDetailDto>> GetUriDetails(string shortUri);
}

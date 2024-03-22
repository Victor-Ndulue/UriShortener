namespace UriShortener.Helpers.Responses.Dtos;
public record UriDetailDto
{
    public string? MainUrl { get; init; }
    public string? ShortUrl { get; init   ; }
    public DateTime? DateCreated { get; init; }
}

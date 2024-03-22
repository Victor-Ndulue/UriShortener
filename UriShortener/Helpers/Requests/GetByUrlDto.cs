namespace UriShortener.Helpers.Requests;

public record GetByUrlDto 
{
    public string url { get; set; }
}

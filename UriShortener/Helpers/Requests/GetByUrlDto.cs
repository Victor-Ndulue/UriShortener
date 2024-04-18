namespace UriShortener.Helpers.Requests;

public record GetByUrlDto 
{
    public string prefferedPath { get; set; }
}

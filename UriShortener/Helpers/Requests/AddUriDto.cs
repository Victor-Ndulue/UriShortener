using System.ComponentModel.DataAnnotations;

namespace UriShortener.Helpers.Requests;
public record AddUriDto 
{
    public string mainUrl { get; init; }
    public string preferredPath { get; set; }
}

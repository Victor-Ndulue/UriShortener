namespace UriShortener.Models;
public class UriDetail
{
    public Guid Id { get; set; }
    public string MainUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    //public string UniqueCode { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
}

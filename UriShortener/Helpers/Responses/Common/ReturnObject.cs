namespace UriShortener.Helpers;
public class ReturnObject<T>
{
    public T? Data { get; init; }
    public int StatusCode { get; init; }
    public bool IsSuccessStatusCode { get; init; }
    public string? Message { get; init; }
    public DateTime DateTimeCreated { get; init; }
    public static ReturnObject<T> SuccessResponse(string? message = "Successful.", T? data = default, int statusCode = 200)
    {
        return new ReturnObject<T>()
        {
            StatusCode = statusCode,
            Data = data,
            IsSuccessStatusCode = true,
            Message = message,
            DateTimeCreated = DateTime.UtcNow
        };
    }
    public static ReturnObject<T> FailureResponse(string message, T? data = default, int statusCode = 400)
    {
        return new ReturnObject<T>()
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccessStatusCode=false,
            DateTimeCreated = DateTime.UtcNow,
            Message = message
        };
    }
    public static ReturnObject<T> ServerFailure(string? message = "Server error. Please retry.", T? data = default, int statusCode = 500)
    {
        return new ReturnObject<T>()
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccessStatusCode=false,
            DateTimeCreated = DateTime.UtcNow,
            Message = message
        };
    }
}
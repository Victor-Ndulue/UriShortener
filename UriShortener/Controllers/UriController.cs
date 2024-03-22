using Microsoft.AspNetCore.Mvc;
using UriShortener.Helpers.Requests;
using UriShortener.Services.Abstractions;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Extensions;

namespace UriShortener.Controllers;

[ApiController]
[Route("[controller]")]
public class UriController : ControllerBase
{     
    private readonly ILogger<UriController> _logger;
    private readonly IUriRepo _uriRepo;
    public UriController(ILogger<UriController> logger, IUriRepo uriRepo)
    {
        _logger = logger;
        _uriRepo = uriRepo;
    }

    [HttpGet(Name = "get-uri-details")]
    public async Task<IActionResult> GetUriDetails([FromQuery] GetByUrlDto urlDto)
    {
        var shortUrl = urlDto.url;
        var result = await _uriRepo.GetUriDetails(shortUrl);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost, Route("create-url")]
    public async Task<IActionResult> Createuri(AddUriDto dto)
    {
        var result = await _uriRepo.AddUri(dto);
        return StatusCode(result.StatusCode, result);
    }
}



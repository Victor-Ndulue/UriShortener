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
//[Route("[controller]")]
public class UriController : ControllerBase
{     
    private readonly ILogger<UriController> _logger;
    private readonly IUriRepo _uriRepo;
    public UriController(ILogger<UriController> logger, IUriRepo uriRepo)
    {
        _logger = logger;
        _uriRepo = uriRepo;
    }
    [HttpGet, Route("{shortUrl}")]
    public async Task<IActionResult> RedirectToMainUrl(string shortUrl)
    {
        var urlResult = await _uriRepo.GetUriDetails(shortUrl);

        return urlResult.IsSuccessStatusCode switch
        {
            true when urlResult.Data is not null => Redirect(urlResult.Data.MainUrl),
            _ => NotFound()
        };
    }
    [HttpGet, Route("get-uri-details/{preferredPath}")]
    public async Task<IActionResult> GetUriDetails(string preferredPath)
    {
        var result = await _uriRepo.GetUriDetails(preferredPath);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost, Route("create-url")]
    public async Task<IActionResult> Createuri([FromBody] AddUriDto dto)
    {
        var result = await _uriRepo.AddUri(dto);
        return StatusCode(result.StatusCode, result);
    }
}



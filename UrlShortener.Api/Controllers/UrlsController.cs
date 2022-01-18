using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Contexts;
using UrlShortener.Data.Models;
using UrlShortener.Services.Interfaces;
using UrlShortener.Services.Services;

namespace UrlShortener.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public string Get()
        {
            return "Main page";
        }
        
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                return Redirect((await _urlService.Get(key)).OriginalUrl);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(string url)
        {
            if (!Uri.IsWellFormedUriString(url,UriKind.Absolute))
            {
                return BadRequest();
            }

            return Ok(await _urlService.Reduce(new Uri(url)));
        }
    }
}
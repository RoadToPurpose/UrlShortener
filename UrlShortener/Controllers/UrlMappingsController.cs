using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Route("")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UrlMappingsController : ControllerBase
    {
        private readonly UrlMappingsContext _db;

        public UrlMappingsController(UrlMappingsContext context)
        {
            _db = context;
        }

        [HttpGet]
        public string Get()
        {
            return "Main page";
        }
        
        [HttpGet("{shortenedUrlKey}")]
        public async Task<ActionResult<string>> Get(string shortenedUrlKey)
        {
            UrlMapping urlMapping = await _db.UrlMappings.FirstOrDefaultAsync(x => x.ShortenedUrlKey == shortenedUrlKey);
            if (urlMapping == null)
                return NotFound();
            return new ObjectResult(urlMapping.OriginalUrl);
        }
        
        [HttpPost]
        public async Task<ActionResult<UrlMapping>> Post(string url)
        {
            if (!Uri.IsWellFormedUriString(url,UriKind.Absolute))
            {
                return BadRequest();
            }

            UrlMapping newRecord = new UrlMapping()
            {
                OriginalUrl = url, ShortenedUrlKey = KeyGenerator.Generate()
            };
            _db.UrlMappings.Add(newRecord);
            await _db.SaveChangesAsync();
            
            return Ok(newRecord);
        }
    }
}
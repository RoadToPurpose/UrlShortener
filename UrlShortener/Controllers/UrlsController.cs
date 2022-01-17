using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Contexts;
using UrlShortener.Data.Models;

namespace UrlShortener.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly UrlsContext _context;

        public UrlsController(UrlsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            return "Main page";
        }
        
        [HttpGet("{key}")]
        public async Task<ActionResult<string>> Get(string key)
        {
            UrlModel urlModel = await _context.Urls.FirstOrDefaultAsync(x => x.Key == key);
            if (urlModel == null)
            {
                return NotFound();
            }
            
            return Redirect(urlModel.OriginalUrl);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(string url)
        {
            if (!Uri.IsWellFormedUriString(url,UriKind.Absolute))
            {
                return BadRequest();
            }

            UrlModel newRecord = new UrlModel()
            {
                OriginalUrl = url, Key = Guid.NewGuid().ToString()[..7]
            };
            _context.Urls.Add(newRecord);
            await _context.SaveChangesAsync();
            
            return Ok(newRecord);
        }
    }
}
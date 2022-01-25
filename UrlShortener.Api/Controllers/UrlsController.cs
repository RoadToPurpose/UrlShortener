using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services.Interfaces;

namespace UrlShortener.Controllers
{
    /// <summary>
    /// Main API controller with route ""
    /// </summary>
    [Route("")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        /// <summary>
        ///     The UrlService that is responsible for shortening the link and getting the original.
        /// </summary>
        private readonly IUrlService _urlService;

        /// <summary>
        ///     The constructor of the controller. It is responsible for constructing of the controller.
        /// </summary>
        /// <param name="urlService">
        ///     UrlService that is used for shortening the ling and getting the original.
        ///     The parameter is automatically set by the compiler.
        /// </param>
        public UrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        /// <summary>
        ///     The GET method of the controller for redirecting to original link by key (shorted link) 
        /// </summary>
        /// <param name="key">
        ///     The key of shorted link.
        /// </param>
        /// <returns>
        ///     returns an HTTP request that redirects to the original link or Not Found request if an invalid key is passed. 
        /// </returns>
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

        /// <summary>
        ///     The POST method of the controller for creating a key for shorted link.
        /// </summary>
        /// <param name="url">
        ///     The original link that should be shortened.
        /// </param>
        /// <returns>
        ///     Returns the Ok HTTP request with created UrlModel or BadRequest if the passed string is not a link.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return BadRequest();
            }

            return Ok(await _urlService.Reduce(new Uri(url)));
        }
    }
}
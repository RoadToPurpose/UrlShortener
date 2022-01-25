using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Contexts;
using UrlShortener.Data.Models;
using UrlShortener.Services.Interfaces;

namespace UrlShortener.Services.Services
{
    /// <summary>
    ///     Link Shortening Service.
    /// </summary>
    public class UrlService : IUrlService
    {
        /// <summary>
        ///     The database context.
        /// </summary>
        private readonly UrlContext _context;

        /// <summary>
        ///     The constructor of the service.
        /// </summary>
        /// <param name="context">
        ///     Database context.
        /// </param>
        public UrlService(UrlContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Creates a key for the original link and puts the created record in the database./
        /// </summary>
        /// <param name="uri">
        ///     The original link.
        /// </param>
        /// <returns>
        ///     Model with original link and its key.
        /// </returns>
        public async Task<UrlModel> Reduce(Uri uri)
        {
            UrlModel urlModel = new UrlModel()
            {
                OriginalUrl = uri.OriginalString, Key = Guid.NewGuid().ToString()[..7]
            };
            _context.Urls.Add(urlModel);
            await _context.SaveChangesAsync();

            return urlModel;
        }

        /// <summary>
        ///     Method for getting original link by key.
        /// </summary>
        /// <param name="key">
        ///     The key for original link.
        /// </param>
        /// <returns>
        ///     Model with original link and its key.
        /// </returns>
        /// <exception cref="Exception">
        ///     Throws an exception if a passed  key is not in the database.
        /// </exception>
        public async Task<UrlModel> Get(string key)
        {
            UrlModel urlModel = await _context.Urls.FirstOrDefaultAsync(x => x.Key == key);
            if (urlModel == null)
            {
                throw new Exception("Key was not found");
            }

            return urlModel;
        }
    }
}
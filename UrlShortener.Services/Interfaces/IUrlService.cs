using System;
using System.Threading.Tasks;
using UrlShortener.Data.Models;

namespace UrlShortener.Services.Interfaces
{
    /// <summary>
    ///     The interface that defines the service for shortening links.
    /// </summary>
    public interface IUrlService
    {
        /// <summary>
        ///     Method for shortening links.
        /// </summary>
        /// <param name="uri">
        ///     The original link.
        /// </param>
        /// <returns>
        ///     Model with original link and its key.
        /// </returns>
        public Task<UrlModel> Reduce(Uri uri);

        /// <summary>
        ///     Method for getting original link by key.
        /// </summary>
        /// <param name="key">
        ///     The key for original link.
        /// </param>
        /// <returns>
        ///     Model with original link and its key.
        /// </returns>
        public Task<UrlModel> Get(string key);
    }
}
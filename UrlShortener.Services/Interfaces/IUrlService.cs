using System;
using System.Threading.Tasks;
using UrlShortener.Data.Models;

namespace UrlShortener.Services.Interfaces
{
    public interface IUrlService
    {
        public Task<UrlModel> Reduce(Uri uri);
        
        public Task<UrlModel> Get(string key);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Contexts;
using UrlShortener.Data.Models;
using UrlShortener.Services.Interfaces;

namespace UrlShortener.Services.Services
{
    public class UrlService : IUrlService
    {
        private UrlContext _context;
        
        public UrlService(UrlContext context)
        {
            _context = context;
        }
        
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
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.Contexts
{
    public class UrlsContext : DbContext
    {
        public DbSet<UrlModel> Urls { get; set; }
        
        public UrlsContext(DbContextOptions<UrlsContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }
        
    }
}
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.Contexts
{
    public class UrlContext : DbContext
    {
        public DbSet<UrlModel> Urls { get; set; }
        
        public UrlContext(DbContextOptions<UrlContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }
        
    }
}
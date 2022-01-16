using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UrlShortener.Models
{
    public class UrlMappingsContext : DbContext
    {
        public DbSet<UrlMapping> UrlMappings { get; set; }
        
        public UrlMappingsContext(DbContextOptions<UrlMappingsContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Filename=UrlMappings.db");
        // }
    }
}
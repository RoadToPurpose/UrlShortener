using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.Contexts
{
    /// <summary>
    ///     The context for working with the link database.
    /// </summary>
    public class UrlContext : DbContext
    {
        /// <summary>
        ///     The dataset of original links with keys.
        /// </summary>
        public DbSet<UrlModel> Urls { get; set; }

        /// <summary>
        ///     The constructor that initializes the database.
        /// </summary>
        /// <param name="options">
        ///     Contexts parameters. Used for initializing DB in base class.
        /// </param>
        public UrlContext(DbContextOptions<UrlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
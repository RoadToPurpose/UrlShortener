using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models
{
    /// <summary>
    ///     A class that represents a model of records in a database.
    /// </summary>
    public class UrlModel
    {
        /// <summary>
        ///     Key for shorted link.
        /// </summary>
        [Key]
        public string Key { get; set; }

        /// <summary>
        ///     Original link string.
        /// </summary>
        public string OriginalUrl { get; set; }
    }
}
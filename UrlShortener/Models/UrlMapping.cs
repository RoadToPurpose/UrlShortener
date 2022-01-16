using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class UrlMapping
    {
        
        // Key for shortened url, uses first 8 characters of GUID.
        [Key]
        public string ShortenedUrlKey
        {
            get;
            set;
        }
        
        // Original URL. 
        public string OriginalUrl
        {
            get;
            set;
        }
    }
}
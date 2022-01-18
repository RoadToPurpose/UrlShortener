using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models
{
    public class UrlModel
    {
        
        // Key for shortened url, uses first 8 characters of GUID.
        [Key]
        public string Key
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
using System;

namespace UrlShortener
{
    public static class KeyGenerator
    {
        // generating a unique key uses a first 8 characters GUID
        public static string Generate()
        {
            return Guid.NewGuid().ToString()[..7];
        }
    }
}
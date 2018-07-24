using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class ShortCodeGenerator {
    public ShortenResponse GetShortUrl(ShortenRequest urlShortenRequest)
    {
      if (!CheckUrlIsValidorNot(urlShortenRequest.MainUrl))
      {
        return new ShortenResponse
        {
          StatusCode = 0,
          StatusMessage = $"{urlShortenRequest.MainUrl} is not a valid url"
        };
      }

      return new ShortenResponse
      {
        StatusMessage = "Success",
        StatusCode = 1,
        ShortUrl = new RandomStringGenerator().GetRandomString(),
        MainUrl = urlShortenRequest.MainUrl
      };

    }

    public bool CheckUrlIsValidorNot( string url )
    {
      return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
  }
 
}

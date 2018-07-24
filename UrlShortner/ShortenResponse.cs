using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class ShortenResponse {
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; }
    public string ShortUrl { get; set; }
    public string MainUrl { get; set; }
  }
}

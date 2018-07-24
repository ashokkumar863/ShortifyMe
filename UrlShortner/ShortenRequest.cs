using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class ShortenRequest {
    public string MainUrl { get; set; }
    public string Username { get; set; }
    public string HashKey { get; set; }
  }
}

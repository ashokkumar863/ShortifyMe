using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortner;

namespace UrlShortener.Tests {
  class Program {
    static void Main( string[] args )
    {
      
      TestCase();
    }

    public static void TestCase()
    {
     
        var urlShortner = new ShortCodeGenerator();
        var req = new ShortenRequest
        {
          MainUrl = "http://www.google.com"
        };
        var response = urlShortner.GetShortUrl(req);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" "+response.StatusMessage);
        Console.WriteLine(response.ShortUrl);
        Console.WriteLine(DateTime.Now);
      
    }
  }
}

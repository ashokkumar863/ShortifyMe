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
      
      Thread t1=new Thread(new ThreadStart(TestCase));
      Thread t2 = new Thread( new ThreadStart( TestCase ) );
      Thread t3 = new Thread( new ThreadStart( TestCase ) );
      Thread t4 = new Thread( new ThreadStart( TestCase ) );
      Console.WriteLine(DateTime.Now);
      t1.Start();t2.Start();t3.Start();t4.Start();
      Console.ReadKey();
    }

    public static void TestCase()
    {
      int i = 1000;
      while (i-- > 0)
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
}

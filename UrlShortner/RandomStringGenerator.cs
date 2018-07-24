using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class RandomStringGenerator {
    private readonly Random _random = new Random();
    public  string GetRandomString( int length=3 ) {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
     var code= new string( Enumerable.Repeat( chars, length )
        .Select( s => s[_random.Next( s.Length )] ).ToArray() );
      return CheckIfCodeExixsts(code) ? GetRandomString(length + 1) : code;
    }

    public bool CheckIfCodeExixsts(string code)
    {
      return false;
    }
  }
}

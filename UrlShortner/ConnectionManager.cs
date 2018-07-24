using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class ConnectionManager
  {
    private static SqlConnection connection;
    private static readonly object padlock = new object();

    private ConnectionManager()
    {        
      string connString = "Persist Security Info = False;Initial Catalog = SCR_Data; Server = ASHOK\\SQLEXPRESS;Integrated Security=true;MultipleActiveResultSets=true";
      connection = new SqlConnection( connString );
    }

    public static SqlConnection Connection {
      get {
        lock ( padlock ) {
          if ( connection == null )
          {
             new ConnectionManager();
          }
          return connection;
        }
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class DbOperations {
    public bool Insert(ShortenResponse data)
    {
      try
      {
        string sql = $"insert into dbo.Records(shorturl,longurl) values('{data.ShortUrl}','{data.MainUrl}')";
        ConnectionManager.Connection.Open();
        SqlCommand cmd = new SqlCommand(sql, ConnectionManager.Connection);
        cmd.ExecuteNonQuery();
        return true;
      }
      catch (Exception exp)
      {
        return false;
      }
    }

    public bool IsExist(string shortUrlCode)
    {
      try {
        string sql = $"select count(*) from dbo.Records where shorturl='{shortUrlCode}'";
        ConnectionManager.Connection.Open();
        SqlCommand cmd = new SqlCommand( sql, ConnectionManager.Connection );
        SqlDataReader dataReader = cmd.ExecuteReader();

        return dataReader.HasRows;
      }
      catch ( Exception exp ) {
        return false;
      }
    }

    public ShortenResponse Retrive(string  shortUrlCode)
    {     
        string sql = $"select * from dbo.Records where shorturl='{shortUrlCode}'";
        ConnectionManager.Connection.Open();
        SqlCommand cmd = new SqlCommand(sql, ConnectionManager.Connection);
        SqlDataReader dataReader = cmd.ExecuteReader();
        return dataReader.HasRows
          ? new ShortenResponse
          {
            ShortUrl = dataReader.GetValue(0).ToString(),
            MainUrl = dataReader.GetValue(1).ToString()
          }
          : null;
      }   
    } 
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner {
  public class DbOperations {
    public bool Insert( ShortenResponse data ) {
      try {
        string sql = $"insert into dbo.Records(shorturl,longurl) values('{data.ShortUrl}','{data.MainUrl}')";
        ConnectionManager.Connection.Open();
        SqlCommand cmd = new SqlCommand( sql, ConnectionManager.Connection );
        cmd.ExecuteNonQuery();
        ConnectionManager.Connection.Close();

        return true;
      }
      catch ( Exception exp ) {
        return false;
      }
    }

    public bool IsExist( string shortUrlCode ) {
      try {
        string sql = $"select * from dbo.Records where shorturl='{shortUrlCode}'";
        ConnectionManager.Connection.Open();
        SqlCommand cmd = new SqlCommand( sql, ConnectionManager.Connection );
        SqlDataReader dataReader = cmd.ExecuteReader();

        bool hasRows = dataReader.HasRows;
        dataReader.Close();
        ConnectionManager.Connection.Close();
        return hasRows;

      }
      catch ( Exception exp ) {
        return false;
      }
    }

    public ShortenResponse Retrive( string shortUrlCode ) {
      string sql = $"select * from dbo.Records where shorturl='{shortUrlCode}'";
      ConnectionManager.Connection.Open();
      SqlCommand cmd = new SqlCommand( sql, ConnectionManager.Connection );
      SqlDataReader dataReader = cmd.ExecuteReader();
      while (dataReader.Read())
      {
        var response= new ShortenResponse
        {
          ShortUrl = dataReader.GetValue(0).ToString(),
          MainUrl = dataReader.GetValue(1).ToString()
        };
        ConnectionManager.Connection.Close();
        return response;
      }
      dataReader.Close();
      ConnectionManager.Connection.Close();
      return null;
    }
  }
}

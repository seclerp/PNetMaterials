using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public class MyProcedure
{
  public static void UserGetProcedure(SqlString Name)
  {
    using (var connection = new SqlConnection("context connection = true"))
    {
      var cmd = connection.CreateCommand();
      cmd.CommandText = "SELECT * FROM students WHERE Name = @Name";
      cmd.Parameters.AddWithValue("@Name", Name);
      connection.Open();
      SqlContext.Pipe.ExecuteAndSend(cmd);
    }
  }
}
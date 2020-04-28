using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNetLab2.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DotNetLab2.Controllers
{
  public class HomeController : Controller
  {
    private const int MaxCount = 1000;

    private readonly string _connectionString;

    public HomeController(IOptions<Settings> settings) =>
      _connectionString = settings.Value.ConnectionString;

    public IActionResult Index() =>
      View(GetTableData("users"));

    public List<List<object>> GetTableData(string tableName)
    {
      var result = new List<List<object>>();

      using (var connection = new MySqlConnection (_connectionString))
      {
        connection.Open();

        var command = new MySqlCommand($"SELECT * FROM {tableName}", connection);
        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            result.Add(new List<object> {reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]});
            if (result.Count > MaxCount) return result;
          }
        }
      }

      return result;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
      View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
  }
}
using EduCare.DesignPatterns.Strategy.Models;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace EduCare.DesignPatterns.Strategy.GoodWay.Concrete
{
    public class SqlLogger : ILogger
    {
        private readonly string _connectionString;
        public SqlLogger()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LogDbConnectionString"].ConnectionString;
        }

        public void Save(string logText)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var log = new ActionLog(logText);
                log.Created = DateTime.Now;
                log.Id = Guid.NewGuid();
                var query = "INSERT INTO Logs VALUES(@id, @date, @text)";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", log.Id);
                cmd.Parameters.AddWithValue("@date", log.Created);
                cmd.Parameters.AddWithValue("@text", log.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

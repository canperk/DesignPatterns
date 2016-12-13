using EduCare.DesignPatterns.Strategy.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace EduCare.DesignPatterns.Strategy.BadWay.Concrete
{
    public class SqlLogger
    {
        private readonly string _connectionString;
        public SqlLogger()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LogDbConnectionString"].ConnectionString;
        }

        public void SaveLog(ActionLog log)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
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

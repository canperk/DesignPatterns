using System.Configuration;
using System.Data.SqlClient;

namespace EduCare.DesignPatterns.Singleton.GoodWay
{
    public class Connection
    {
        static Connection()
        {
            if (_connection == null)
            {
                lock (_lockObject)
                {
                    if (_connection == null)
                    {
                        var connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                        _connection = new SqlConnection(connectionString);
                        _connection.Open();
                    }
                }
            }
        }
        private static object _lockObject = new object();
        private static SqlConnection _connection;

        public static SqlConnection Instance { get { return _connection; } }
    }
}

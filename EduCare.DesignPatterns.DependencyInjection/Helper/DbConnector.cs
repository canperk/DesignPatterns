using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.DependencyInjection.Helper
{
    public abstract class DbConnector<T> : IDisposable
    {
        public DbConnector()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            Connection.Open();
        }
        protected SqlConnection Connection { get; set; }
        public abstract List<T> GetItems();
        ~DbConnector()
        {
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
            Connection = null;
        }
    }
}

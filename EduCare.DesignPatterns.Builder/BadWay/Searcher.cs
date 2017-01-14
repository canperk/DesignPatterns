using Dapper;
using EduCare.DesignPatterns.Builder.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace EduCare.DesignPatterns.Builder.BadWay
{
    public class Searcher
    {
        public Searcher()
        {
            Results = new List<SearchItem>();
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        }
        public List<SearchItem> Results { get; private set; }
        private SqlConnection _connection;
        public void Search(string searchText)
        {
            var words = searchText.Split(' ').ToList();
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = $" \"{words[i]}\" ";
            }
            var parameters = string.Join(" or ", words);
            var query = "SELECT * FROM News WHERE Detail LIKE @text OR Title LIKE @text OR CONTAINS((Title), @words) OR CONTAINS((Detail), @words)";
            Results = _connection.Query<SearchItem>(query, new { text = "%" + searchText + "%", words = parameters }).ToList();
        }
    }
}

using Dapper;
using EduCare.DesignPatterns.Builder.Helper;
using EduCare.DesignPatterns.Builder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Builder.GoodWay
{
    public class Searcher
    {
        public Searcher()
        {
            Results = new HashSet<SearchItem>(new HashSetComparer());
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        }
        public HashSet<SearchItem> Results { get; private set; }
        private SqlConnection _connection;

        public void SearchInTitle(string searchText)
        {
            var query = "SELECT * FROM News WHERE Title LIKE @text";
            var items = _connection.Query<SearchItem>(query, new { text = "%" + searchText + "%" }).ToList();
            items.ForEach(i => {
                i.Priority = Priority.High;
                Results.Add(i);
            });
        }

        public void SearchInDetail(string searchText)
        {
            var query = "SELECT * FROM News WHERE Detail LIKE @text";
            var items = _connection.Query<SearchItem>(query, new { text = "%" + searchText + "%" }).ToList();
            items.ForEach(i => {
                i.Priority = Priority.Normal;
                Results.Add(i);
            });
        }

        public void SearchWordsInTitle(string searchText)
        {
            var query = "SELECT * FROM News WHERE CONTAINS((Title), @words)";
            string parameters = SplitWords(searchText);
            var items = _connection.Query<SearchItem>(query, new { words = parameters }).ToList();
            items.ForEach(i => {
                i.Priority = Priority.Normal;
                Results.Add(i);
            });
        }

        public void SearchWordsInDetail(string searchText)
        {
            var query = "SELECT * FROM News WHERE CONTAINS((Detail), @words)";
            string parameters = SplitWords(searchText);
            var items = _connection.Query<SearchItem>(query, new { words = parameters }).ToList();
            items.ForEach(i => {
                i.Priority = Priority.Low;
                Results.Add(i);
            });
        }

        private static string SplitWords(string searchText)
        {
            var words = searchText.Split(' ').ToList();
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = $" \"{words[i]}\" ";
            }
            var parameters = string.Join(" or ", words);
            return parameters;
        }
    }
}

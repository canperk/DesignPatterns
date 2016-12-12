using EduCare.DesignPatterns.Facade.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduCare.DesignPatterns.Facade.GoodWay
{
    public class LuceneEngine
    {
        private Analyzer _Analyzer;
        private Directory _Directory;
        private string _IndexPath = @"C:\LuceneIndex";

        public LuceneEngine()
        {
            _Analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            _Directory = FSDirectory.Open(_IndexPath);
        }

        public void AddToIndex(IEnumerable<Employee> values)
        {
            using (var _IndexWriter = new IndexWriter(_Directory, _Analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {

                var _Document = new Document();
                _Document.Add(new Field("Id", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("FirstName", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("LastName", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("Gender", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("BirthDate", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("EMail", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("IpAddress", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("City", "", Field.Store.YES, Field.Index.ANALYZED));
                _Document.Add(new Field("Country", "", Field.Store.YES, Field.Index.ANALYZED));
                var i = 0;
                foreach (var loopEntity in values)
                {
                    _Document.GetField("Id").SetValue(loopEntity.Id.ToString());
                    _Document.GetField("FirstName").SetValue(loopEntity.FirstName);
                    _Document.GetField("LastName").SetValue(loopEntity.LastName);
                    _Document.GetField("Gender").SetValue(loopEntity.Gender);
                    _Document.GetField("BirthDate").SetValue(loopEntity.BirthDate.ToString());
                    _Document.GetField("EMail").SetValue(loopEntity.EMail);
                    _Document.GetField("IpAddress").SetValue(loopEntity.IpAddress);
                    _Document.GetField("City").SetValue(loopEntity.City);
                    _Document.GetField("Country").SetValue(loopEntity.Country);
                    i++;

                    _IndexWriter.AddDocument(_Document);


                    Console.Title = i.ToString();
                }
                _IndexWriter.Optimize();
                _IndexWriter.Commit();
            }
        }

        public List<Employee> Search(string field, string keyword)
        {
            var _QueryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, field, _Analyzer);
            var _Query = _QueryParser.Parse(keyword);

            using (var _IndexSearcher = new IndexSearcher(_Directory))
            {
                var employees = new List<Employee>();
                var result = _IndexSearcher.Search(_Query, 20);
                Document _Document = null;
                foreach (var loopDoc in result.ScoreDocs.OrderBy(s => s.Score))
                {
                    _Document = _IndexSearcher.Doc(loopDoc.Doc);

                    employees.Add(new Employee()
                    {
                        Id = Convert.ToInt32(_Document.Get("Id")),
                        FirstName = _Document.Get("FirstName"),
                        LastName = _Document.Get("LastName"),
                        EMail = _Document.Get("EMail")
                    });
                }

                return employees;
            }
        }
    }
}

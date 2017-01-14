using EduCare.DesignPatterns.Builder.GoodWay;
using EduCare.DesignPatterns.Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Builder
{
    public class SearchBuilder
    {
        private Searcher _searcher;
        public SearchBuilder()
        {
            _searcher = new Searcher();
        }
        public void DirectSearch(string text)
        {
            _searcher.SearchInTitle(text);
            _searcher.SearchInDetail(text);
        }

        public void CompleteSearch(string text)
        {
            _searcher.SearchInTitle(text);
            _searcher.SearchInDetail(text);
            _searcher.SearchWordsInTitle(text);
            _searcher.SearchWordsInDetail(text);
        }
        public HashSet<SearchItem> Results { get { return _searcher.Results; } }
    }
}

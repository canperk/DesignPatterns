using EduCare.DesignPatterns.Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Builder.Helper
{
    public class HashSetComparer : IEqualityComparer<SearchItem>
    {
        public bool Equals(SearchItem x, SearchItem y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(SearchItem obj)
        {
            return obj.Id;
        }
    }
}

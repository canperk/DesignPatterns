using Dapper;
using EduCare.DesignPatterns.DependencyInjection.Helper;
using EduCare.DesignPatterns.DependencyInjection.Models;
using System.Collections.Generic;
using System.Linq;

namespace EduCare.DesignPatterns.DependencyInjection.Concrete
{
    public class CategoryReader : DbConnector<Category>
    {
        public override List<Category> GetItems()
        {
            var list = Connection.Query<Category>("SELECT TOP 15 CategoryId, CategoryName FROM Categories").ToList();
            return list;
        }
    }
}

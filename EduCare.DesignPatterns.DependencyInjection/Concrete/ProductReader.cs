using Dapper;
using EduCare.DesignPatterns.DependencyInjection.Helper;
using EduCare.DesignPatterns.DependencyInjection.Models;
using System.Collections.Generic;
using System.Linq;

namespace EduCare.DesignPatterns.DependencyInjection.Concrete
{
    public class ProductReader : DbConnector<Product>
    {
        public override List<Product> GetItems()
        {
            var list = Connection.Query<Product>("SELECT TOP 15 ProductId, ProductName, UnitPrice, UnitsInStock FROM Products").ToList();
            return list;
        }
    }
}

using EduCare.DesignPatterns.DependencyInjection.Concrete;
using EduCare.DesignPatterns.DependencyInjection.Helper;
using System;

namespace EduCare.DesignPatterns.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData(new EmployeeReader());
            GetData(new ProductReader());
            GetData(new CategoryReader());
            Console.ReadKey();
        }

        #region Bad Way
        //static void GetData(EmployeeReader reader)
        //{
        //    var items = reader.GetItems();
        //    Console.WriteLine("Item Count {0}: ", items.Count);
        //}

        //static void GetData(ProductReader reader)
        //{
        //    var items = reader.GetItems();
        //    Console.WriteLine("Item Count {0}: ", items.Count);
        //}

        //static void GetData(CategoryReader reader)
        //{
        //    var items = reader.GetItems();
        //    Console.WriteLine("Item Count {0}: ", items.Count);
        //} 
        #endregion

        #region Good Way
        static void GetData<T>(DbConnector<T> reader)
        {
            var items = reader.GetItems();
            Console.WriteLine("Item Count {0}: ", items.Count);
        } 
        #endregion
    }
}

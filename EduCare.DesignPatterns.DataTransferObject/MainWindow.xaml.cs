using EduCare.DesignPatterns.DataTransferObject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using EduCare.DesignPatterns.DataTransferObject.Dtos;

namespace EduCare.DesignPatterns.DataTransferObject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public NorthwindEntities Context { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GoodWay();
        }

        private void BadWay()
        {
            Context = new NorthwindEntities();
            var list = Context.Order_Details.Include(i => i.Order).Include(i => i.Order.Customer).Include(i => i.Product).Where(i => i.Order.OrderDate.Value.Year == 1998).ToList();
            var content = JsonConvert.SerializeObject(list, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"C:\Test\oldData.txt", content);
            grid.ItemsSource = list;
            grid.AutoGenerateColumns = false;
        }

        private void GoodWay()
        {
            Context = new NorthwindEntities();
            var list = Context.Order_Details.Include(i => i.Order)
                              .Include(i => i.Order.Customer)
                              .Include(i => i.Product)
                              .Where(i => i.Order.OrderDate.Value.Year == 1998)
                              .Select(i => new OrderDto
                              {
                                  OrderId = i.OrderID,
                                  ProductName = i.Product.ProductName,
                                  CompanyName = i.Order.Customer.CompanyName,
                                  OrderDate = i.Order.OrderDate.Value,
                                  Summary = i.UnitPrice * i.Quantity
                              })
                              .ToList();
            var content = JsonConvert.SerializeObject(list, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"C:\Test\newData.txt", content);
            grid.ItemsSource = list;
            grid.AutoGenerateColumns = false;
        }
    }
}

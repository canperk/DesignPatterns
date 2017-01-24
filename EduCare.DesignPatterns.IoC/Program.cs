using EduCare.DesignPatterns.IoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Registerations
            var container = new Container();
            container.Register<ICommunication, Sms>();
            container.Register<IDatabase, MongoContext>();
            container.Register<IPayment, Transfer>();
            #endregion


            var cc1 = container.Resolve<IPayment>();
            Console.WriteLine(cc1.SendMoney(500));
            var cc2 = container.Resolve<IPayment>();
            Console.WriteLine(cc2.SendMoney(500));
            var cc3 = container.Resolve<IPayment>();
            Console.WriteLine(cc3.SendMoney(500));
            var cc4 = container.Resolve<IPayment>();
            Console.WriteLine(cc4.SendMoney(500));
            var cc5 = container.Resolve<IPayment>();
            Console.WriteLine(cc5.SendMoney(500));
            var cc6 = container.Resolve<IPayment>();
            Console.WriteLine(cc6.SendMoney(500));

            var mssql1 = container.Resolve<IDatabase>();
            Console.WriteLine(mssql1.Connect());
            var mssql2 = container.Resolve<IDatabase>();
            Console.WriteLine(mssql2.Connect());
            var mssql3 = container.Resolve<IDatabase>();
            Console.WriteLine(mssql3.Connect());

            var email1 = container.Resolve<ICommunication>();
            Console.WriteLine(email1.SendMessage("Hi", "Content"));
            var email2 = container.Resolve<ICommunication>();
            Console.WriteLine(email2.SendMessage("Hi", "Content"));
            var email3 = container.Resolve<ICommunication>();
            Console.WriteLine(email3.SendMessage("Hi", "Content"));

            Console.ReadKey();
        }
    }
}

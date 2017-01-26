using EduCare.DesignPatterns.IoC.Helper;
using EduCare.DesignPatterns.IoC.Models;
using EduCare.DesignPatterns.IoC.UnitySample;
using Microsoft.Practices.Unity;
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
            #region Custom Ioc
            //#region Registerations
            //var container = new Container();
            //container.Register<ICommunication, Sms>();
            //container.Register<IDatabase, MongoContext>();
            //container.Register<IPayment, Transfer>();
            //#endregion


            //var cc1 = container.Resolve<IPayment>();
            //Console.WriteLine(cc1.SendMoney(500));
            //var cc2 = container.Resolve<IPayment>();
            //Console.WriteLine(cc2.SendMoney(500));
            //var cc3 = container.Resolve<IPayment>();
            //Console.WriteLine(cc3.SendMoney(500));
            //var cc4 = container.Resolve<IPayment>();
            //Console.WriteLine(cc4.SendMoney(500));
            //var cc5 = container.Resolve<IPayment>();
            //Console.WriteLine(cc5.SendMoney(500));
            //var cc6 = container.Resolve<IPayment>();
            //Console.WriteLine(cc6.SendMoney(500));

            //var mssql1 = container.Resolve<IDatabase>();
            //Console.WriteLine(mssql1.Connect());
            //var mssql2 = container.Resolve<IDatabase>();
            //Console.WriteLine(mssql2.Connect());
            //var mssql3 = container.Resolve<IDatabase>();
            //Console.WriteLine(mssql3.Connect());

            //var email1 = container.Resolve<ICommunication>();
            //Console.WriteLine(email1.SendMessage("Hi", "Content"));
            //var email2 = container.Resolve<ICommunication>();
            //Console.WriteLine(email2.SendMessage("Hi", "Content"));
            //var email3 = container.Resolve<ICommunication>();
            //Console.WriteLine(email3.SendMessage("Hi", "Content")); 
            #endregion

            #region Microsoft Unity

            //var cc1 = Resolver.Resolve<IPayment>();
            //Console.WriteLine(cc1.SendMoney(300));
            //Console.WriteLine($"Limit is {cc1.Limit}");

            var shr = Resolver.Resolve<Shooper>(new ParameterOverride("payment", new CreditCard()));
            var s2 = Resolver.Resolve<Shooper>();
            var s3 = Resolver.Resolve<Shooper>();
            var s4 = Resolver.Resolve<Shooper>();
            s2.Charge(50);
            s3.Charge(50);
            s4.Charge(50);
            Console.WriteLine(shr.Charge(200));
            Console.WriteLine(s4.GetUsage());

            Console.ReadKey();
            #endregion
        }
    }
}

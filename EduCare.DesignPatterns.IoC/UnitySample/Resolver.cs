using EduCare.DesignPatterns.IoC.Helper;
using EduCare.DesignPatterns.IoC.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC.UnitySample
{
    public static class Resolver
    {
        private static UnityContainer _container;
        static Resolver()
        {
            _container = new UnityContainer();
            _container.RegisterType<IPayment, Transfer>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IPayment, CreditCard>(new InjectionProperty(PropertyHelper.GetPropertyName<CreditCard>(i => i.Limit), 1000.0));
        }

        public static T Resolve<T>(params ResolverOverride[] paramaters)
        {
            return _container.Resolve<T>(paramaters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC
{
    public class Container : IContainer
    {
        private static Dictionary<string, Type> _types = new Dictionary<string, Type>();
        public void Register<TSource, TResult>()
        {
            var typeName = typeof(TSource).FullName;
            if (_types.ContainsKey(typeName))
                throw new Exception("Type already registered");

            _types.Add(typeName, typeof(TResult));
        }

        public TSource Resolve<TSource>()
        {
            var typeName = typeof(TSource).FullName;
            if (!_types.ContainsKey(typeName))
                throw new Exception("Type has not registered");

            var type = _types[typeName];
            var instance = (TSource)Activator.CreateInstance(type);
            //TODO: Resolve constructors with parameters. Use reflection
            return instance;
        }
    }
}

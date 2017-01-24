using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC
{
    public interface IContainer
    {
        void Register<TSource, TResult>();
        TSource Resolve<TSource>();
    }
}

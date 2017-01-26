using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC.Helper
{
    public static class PropertyHelper
    {
        public static string GetPropertyName<TSource>(Expression<Func<TSource, object>> propertyExpression)
        {
            var operand = (propertyExpression.Body as UnaryExpression).Operand as MemberExpression;
            var name = operand.Member.Name;
            return name;
        }
    }
}

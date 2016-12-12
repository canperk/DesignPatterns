using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Facade.Helper
{
    public class UnitConverter
    {
        public double FahrenheitToCelcius(double temperature)
        {
            return Math.Round((temperature - 32) / 1.8, 1);
        }
    }
}

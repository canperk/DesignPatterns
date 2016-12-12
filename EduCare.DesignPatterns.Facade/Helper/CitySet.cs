using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Facade.Helper
{
    public class CitySet
    {
        private static Dictionary<string, string> _cities;
        static CitySet()
        {
            _cities = new Dictionary<string, string>();
            _cities.Add("06300", "Ankara");
            _cities.Add("83714", "Chicago");
            _cities.Add("56001", "Moscow");
        }


        public string GetCityFromZipCode(string code)
        {
            if (_cities.ContainsKey(code))
                return _cities[code];
            return string.Empty;
        }
    }
}

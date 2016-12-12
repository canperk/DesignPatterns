using EduCare.DesignPatterns.Facade.BadWay;
using EduCare.DesignPatterns.Facade.Helper;
using EduCare.DesignPatterns.Facade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Facade.GoodWay
{
    public class WeatherFacade
    {
        private readonly WeatherService _ws;
        private readonly UnitConverter _uc;
        private readonly CitySet _cs;
        public WeatherFacade() : this(new WeatherService(), new UnitConverter(), new CitySet())
        {

        }
        public WeatherFacade(WeatherService ws, UnitConverter uc, CitySet cs)
        {
            _ws = ws;
            _uc = uc;
            _cs = cs;
        }
        public City GetCityInformation(string zipcode)
        {
            var cityName = _cs.GetCityFromZipCode(zipcode);
            var city = _ws.GetDataFromName(cityName);
            var temperature = _uc.FahrenheitToCelcius(city.Temperature);
            city.Temperature = temperature;
            return city;
        }
    }
}

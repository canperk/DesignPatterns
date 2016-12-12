using EduCare.DesignPatterns.Facade.Helper;
using EduCare.DesignPatterns.Facade.Models;
using System.IO;
using System.Net;

namespace EduCare.DesignPatterns.Facade.BadWay
{
    public class WeatherService
    {
        public City GetDataFromName(string cityName)
        {
            var request = WebRequest.Create(string.Format(_apiAdress, cityName));
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var xml = new XmlCityHelper(reader.ReadToEnd());
            return xml.City;
        }
        private readonly string _apiAdress = "http://weather.service.msn.com/data.aspx?weasearchstr={0}&culture=en-US&weadegreetype=F&src=outlook";
    }
    
}

using EduCare.DesignPatterns.Facade.Models;
using System;
using System.Linq;
using System.Xml.Linq;

namespace EduCare.DesignPatterns.Facade.Helper
{
    public class XmlCityHelper
    {
        public XmlCityHelper(string xml)
        {
            City = new City();
            var doc = XDocument.Parse(xml);
            City.Name = doc.Root.Elements().Select(i => i.Attribute("weatherlocationname")).First().Value;
            City.Temperature = double.Parse(doc.Root.Elements().Select(i => i.Element("current").Attribute("temperature").Value).First());
            City.Date = DateTime.Parse(doc.Root.Elements().Select(i => i.Element("current").Attribute("date").Value).First());
            City.Latitude = double.Parse(doc.Root.Elements().Select(i => i.Attribute("lat")).First().Value.Replace(".",","));
            City.Longtitude = double.Parse(doc.Root.Elements().Select(i => i.Attribute("long")).First().Value.Replace(".", ","));
        }

        public City City { get; set; }
    }
}

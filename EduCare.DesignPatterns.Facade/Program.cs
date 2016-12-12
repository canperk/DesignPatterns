using EduCare.DesignPatterns.Facade.BadWay;
using EduCare.DesignPatterns.Facade.GoodWay;
using EduCare.DesignPatterns.Facade.Helper;
using EduCare.DesignPatterns.Facade.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EduCare.DesignPatterns.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bad Way
            //var ws = new WeatherService();
            //var uc = new UnitConverter();
            //var cs = new CitySet();

            //var cityName = cs.GetCityFromZipCode("06300");
            //var city = ws.GetDataFromName(cityName);
            //var temperature = uc.FahrenheitToCelcius(city.Temperature);

            //Console.WriteLine("Temperature is : {0} in [ {1} ], at {2}. Coordinates : {3}, {4}", temperature, city.Name, city.Date, city.Latitude, city.Longtitude);
            //Console.ReadKey(); 
            #endregion

            #region Good Way

            //var wf = new WeatherFacade();
            //var c = wf.GetCityInformation("06300");
            //Console.WriteLine("Temperature is : {0} in [ {1} ], at {2}. Coordinates : {3}, {4}", c.Temperature, c.Name, c.Date, c.Latitude, c.Longtitude);
            //Console.ReadKey(); 
            #endregion

            var le = new LuceneEngine();
            var sw = new Stopwatch();
            sw.Start();
            var result = le.Search("FirstName", "Maria");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static List<Employee> ConfigureLuceneData()
        {
            var employees = new List<Employee>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PeopleConnStr"].ConnectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Employees";
                var cmd = new SqlCommand(query, conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var emp = new Employee
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        EMail = dr["EMail"].ToString(),
                        IpAddress = dr["IpAddress"].ToString(),
                        City = dr["City"].ToString(),
                        Country = dr["Country"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"])
                    };
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}

using EduCare.DesignPatterns.Builder.BadWay;
using EduCare.DesignPatterns.Builder.Models;
using System;
using System.Collections.Generic;

namespace EduCare.DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bad Way
            //var searcher = new Searcher();
            //searcher.Search("turk role");
            //WriteResults(searcher.Results);
            //Console.ReadKey(); 
            #endregion

            var sb = new SearchBuilder();
            sb.CompleteSearch("Mark Zuckerberg");
            WriteResults(sb.Results);

            Console.ReadKey();
        }

        static void WriteResults(IEnumerable<SearchItem> results)
        {
            foreach (var item in results)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.Priority + " ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Title);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t{0}",item.Detail);

                Console.WriteLine("_____________________________________________");
            }
        }
    }
}

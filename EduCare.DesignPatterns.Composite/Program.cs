using EduCare.DesignPatterns.Composite.Models;
using System;

namespace EduCare.DesignPatterns.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = new Directory("Root");

            var dir1 = new Directory("Main 1");
            var dir2 = new Directory("Main 2");
            var dir3 = new Directory("Main 3");

            var dir11 = new Directory("Child 1_1");
            var dir12 = new Directory("Child 1_2");
            var dir21 = new Directory("Child 2_1");

            var dir211 = new Directory("Last 2_1_1");
            var dir212 = new Directory("Last 2_1_2");

            dir1.Add(dir11);
            dir1.Add(dir12);
            dir2.Add(dir21);
            dir21.Add(dir211);
            dir21.Add(dir212);
            dir.Add(dir1);
            dir.Add(dir2);
            dir.Add(dir3);
            var path = dir212.GetPath();
            Console.Write(path);
            Console.ReadKey();
        }
    }
}

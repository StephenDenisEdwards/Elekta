using System;
using System.Collections.Generic;
using System.IO;
using PetReport.Reflective.Domain;
using PetReport.Reflective.Lib;

namespace PetReport.Reflective
{
    class Program
    {
        static void Main(string[] args)
        {
            var pets = new List<IReportable>()
                {
                    new Dog(new Owner {Firstname = "Jim", Lastname = "Rogers", JoinedPractice = DateTime.Now})
                        {NumberOfVisits = 5},
                    new Dog(new Owner
                            {Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13)})
                        {NumberOfVisits = 10},
                    new Cat(new Owner
                            {Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6)})
                        {NumberOfVisits = 20, NumberOfLives = 9}
                };

            //using (StreamWriter writer = File.CreateText("PetsReport.csv"))
            using (TextWriter writer = Console.Out)
            {
                var report = new PetReportGenerator(Console.Out);
                report.GenerateReport(pets);
            }
        }
    }
}

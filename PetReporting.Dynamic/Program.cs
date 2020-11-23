using System;
using System.Collections.Generic;
using System.IO;
using PetReporting.Dynamic.Domain;
using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Report achieved using a polymorphic visitor pattern");
            Console.WriteLine("-----------------------------------------");
            var petsToVisit = new Pets();

            petsToVisit.Attach(new Dog(new Owner { Firstname = "Jim", Lastname = "Rogers", JoinedPractice = DateTime.Now })
                { NumberOfVisits = 5 });
            petsToVisit.Attach(new Dog(new Owner {Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13)})
                {NumberOfVisits = 10});
            petsToVisit.Attach(new Cat(new Owner {Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6)})
                {NumberOfVisits = 20, NumberOfLives = 9});

            var petReportVisitor = new PetReportVisitor(Console.Out);

            petsToVisit.Accept(petReportVisitor);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Report achieved using the DynamicObject");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" >> to file: PetsReport.csv");
            var pets = new List<IReportable>()
            {
                new Dog(new Owner {Firstname = "Jim", Lastname = "Rogers", JoinedPractice = DateTime.Now})
                    {NumberOfVisits = 5},
                new Dog(new Owner {Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13)})
                    {NumberOfVisits = 10},
                new Cat(new Owner {Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6)})
                    {NumberOfVisits = 20, NumberOfLives = 9}
            };

            using (StreamWriter writer = File.CreateText("PetsReport.csv"))
            {
                var report = new PetReportGeneratorDynamic(writer);
                report.GenerateReport(pets);
                writer.Flush();
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Report achieved using the DynamicObject");
            Console.WriteLine("-----------------------------------------");

            {
                var report = new PetReportGeneratorDynamic(Console.Out);
                report.GenerateReport(pets);
            }

            var iReportablePets = new List<IReportable>()
            {
                new Dog(new Owner {Firstname = "Jim", Lastname = "Rogers", JoinedPractice = DateTime.Now})
                    {NumberOfVisits = 5},
                new Dog(new Owner {Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13)})
                    {NumberOfVisits = 10},
                new Cat(new Owner {Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6)})
                    {NumberOfVisits = 20, NumberOfLives = 9}
            };

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Report achieved using a direct a direct Reflection implementation");
            Console.WriteLine("-----------------------------------------");

            {
                var report = new PetReportGeneratorReflective(Console.Out);
                report.GenerateReport(iReportablePets);
            }

            Console.ReadKey();
        }
    }
}

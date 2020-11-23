using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeExcercise
{
    // TODO: Tests should be in a seperated project
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void Test1()
        {
            var pets = new List<Pet>()
            {
                new Dog() { Firstname = "Jim", Lastname = "Rogers", numberofVisits = 5, joinedPractice = DateTime.Now},
                new Dog() { Firstname = "Tony", Lastname = "Smith", numberofVisits = 10, joinedPractice = new DateTime(1985, 7, 13)},
                new Cat() { Firstname = "Steve", Lastname = "Roberts", numberofVisits = 20, joinedPractice = new DateTime(2002, 5, 6), numberOfLives = 9 }
            };

            new Pet().printReport(pets, "PetsReport.csv");
            var outPets = File.ReadAllLines("PetsReport.csv");

            Assert.AreEqual(4, outPets.Count());
        }
    }

    // TODO: This is not a "Pet IS an Owner" relationship - We need to change this to either "Pet HAS an Owner" or "Owner HAS an Pet"
    public class Pet : Owner
    {
        // NOTE: These assumptions may be wrong
        // TODO: I am going to make the assumption that "numberofVisits" is a property of the Pet in question
        public int numberofVisits;
        // TODO: I am going to make the assumption that "joinedPractice" is a property of the Owner 
        public DateTime joinedPractice;

        // TODO: Printing a report is a responsibiliy that probably doesn't belong to a Pet -:)
        // NOTE: This method prints a pets reports in csv format.

        // TODO: It would be great if we could output our report to different streams in future, so we will abstract the "File" stream so we can use any stream.
        public void printReport(IEnumerable<Pet> pets, string filename)
        {
            List<string> entries = new List<string>();
            entries.Add("Owners name,Date Joined Practice,Number Of Visits,Number of Lives");
            
            foreach (var p in pets)
            {
                // TODO: We want to be able to vary what is reported without having to change this class (in fact this functionality will be external)
                var entry = string.Join(" ", p.Firstname, p.Lastname) + p.joinedPractice + "," + p.numberofVisits;
                
                // TODO: Having to check types is a bit of a smell
                if (p is Cat)
                {
                    var cat = p as Cat;
                    entry += "," + cat.numberOfLives;
                }

                entries.Add(entry);
            }

            File.WriteAllLines(filename, entries.ToArray());
        }
    }

    // My personal view is that almost no fields should ever be non-private. (Few exceptions)
    // https://csharpindepth.com/articles/PropertiesMatter
  
    // TODO: These public fields will be turned into properties 
    public class Dog : Pet
    {
        public double CostPerVisit;
    }

    public class Cat : Pet
    {
        public int? numberOfLives; 
        public double CostPerVisit;
    }
    

    public class Owner
    {
        public string Firstname;

        public string Lastname;
    }

}

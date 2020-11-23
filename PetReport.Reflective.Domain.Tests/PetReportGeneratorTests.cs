using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetReport.Reflective.Lib;

namespace PetReport.Reflective.Domain.Tests
{
    [TestClass]
    public class PetReportGeneratorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void PetReportGenerator_CTor_Failure_ArgumentNullException()
        {
            // Arrange

            // Act
            var uut = new PetReportGenerator(null);
        }

        [TestMethod]
        public void PetReportGenerator_GenerateReport_WritesToStream()
        {
            // Arrange
            var mockTextWriter = new Mock<TextWriter>();

            var uut = new PetReportGenerator(mockTextWriter.Object);

            var pets = new List<IReportable>()
            {
                new Dog(new Owner {Firstname = "Jim", Lastname = "Rogers", JoinedPractice = new DateTime(2020, 7, 20)})
                    {NumberOfVisits = 5},
                new Dog(new Owner
                        {Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13)})
                    {NumberOfVisits = 10},
                new Cat(new Owner
                        {Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6)})
                    {NumberOfVisits = 20, NumberOfLives = 9}
            };

            // Act
            uut.GenerateReport(pets);

            // Assert
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Owners name,Date Joined Practice,Number Of Visits,Number of Lives")), Times.Once());
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Jim Rogers, 20/07/2020 00:00:00, 5, ")), Times.Once());
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Tony Smith, 13/07/1985 00:00:00, 10, ")), Times.Once());
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Steve Roberts, 06/05/2002 00:00:00, 20, 9")), Times.Once());
        }

    }
}
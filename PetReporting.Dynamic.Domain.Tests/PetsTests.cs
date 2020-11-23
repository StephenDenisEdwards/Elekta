using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PetReporting.Dynamic.Domain.Tests
{
    [TestClass]
    public class PetsTests
    {
        [TestMethod]
        public void Pets_Accept_CallsVisitor_Success()
        {
            // Arrange
            var petsToVisit = new Pets();

            petsToVisit.Attach(new Dog(new Owner { Firstname = "Jim", Lastname = "Rogers", JoinedPractice = DateTime.Now })
                { NumberOfVisits = 5 });
            petsToVisit.Attach(new Dog(new Owner { Firstname = "Tony", Lastname = "Smith", JoinedPractice = new DateTime(1985, 7, 13) })
                { NumberOfVisits = 10 });
            petsToVisit.Attach(new Cat(new Owner { Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6) })
                { NumberOfVisits = 20, NumberOfLives = 9 });

            var mockVisitor = new Mock<IPetVisitor>();

            // Act
            petsToVisit.Accept(mockVisitor.Object);

            // Assert
            mockVisitor.Verify(u => u.Visit(It.IsAny<Dog>()), Times.Exactly(2));
            mockVisitor.Verify(u => u.Visit(It.IsAny<Cat>()), Times.Once());
        }
    }
}
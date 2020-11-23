using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic.Domain.Tests
{
    [TestClass]
    public class PetReportVisitorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert

        public void PetReportVisitor_CTor_Failure_ArgumentNullException()
        {
            // Arrange

            // Act
            var uut = new PetReportVisitor(null);
        }

        [TestMethod]
        public void PetReportVisitor_Visit_WritesOneDogLineToStream_Success()
        {
            // Arrange
            var mockTextWriter = new Mock<TextWriter>();
            var uut = new PetReportVisitor(mockTextWriter.Object);

            // Act
            uut.Visit(new Dog(new Owner { Firstname = "Jim", Lastname = "Rogers", JoinedPractice = new DateTime(2020, 7, 20) })
                { NumberOfVisits = 5 });

            // Assert
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Jim Rogers, 20/07/2020 00:00:00, 5, ")), Times.Once());
        }

        [TestMethod]
        public void PetReportVisitor_Visit_WritesDogAndCatLinesToStream_Success()
        {
            // Arrange
            var mockTextWriter = new Mock<TextWriter>();
            var uut = new PetReportVisitor(mockTextWriter.Object);

            // Act
            uut.Visit(new Dog(new Owner { Firstname = "Jim", Lastname = "Rogers", JoinedPractice = new DateTime(2020, 7, 20) })
                { NumberOfVisits = 5 });
            uut.Visit(new Cat(new Owner
                    { Firstname = "Steve", Lastname = "Roberts", JoinedPractice = new DateTime(2002, 5, 6) })
                { NumberOfVisits = 20, NumberOfLives = 9 });

            // Assert
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Jim Rogers, 20/07/2020 00:00:00, 5, ")), Times.Once());
            mockTextWriter.Verify(x => x.WriteLine(It.Is<string>(item => item == "Steve Roberts, 06/05/2002 00:00:00, 20, 9")), Times.Once());
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetReporting.Dynamic.Domain.Tests
{
    /*
        [UnitOfWork]_[Method]_[Behaviour]
    */
    
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert

        public void Pet_CTor_Failure_ArgumentNullException()
        {
            // Arrange

            // Act
            var uut = new TestPet(null);
        }
    }
}

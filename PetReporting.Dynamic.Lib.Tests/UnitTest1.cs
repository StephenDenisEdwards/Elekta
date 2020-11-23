using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetReporting.Dynamic.Lib.Tests
{
    class TestReportable : Reportable
    {
        public string MyProperty => "My Test Property Value";
    }

    [TestClass]
    public class ReportableTests
    {
        [TestMethod]
        public void Reportable_Indexer_Returns_PropertyValueByName()
        {
            // Arrange
            var uut = new TestReportable();

            // Act
            var value = uut["MyProperty"];

            // Assert
            Assert.AreEqual("My Test Property Value", value);
        }
    }
}

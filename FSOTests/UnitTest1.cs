using FieldServiceOrganizer.Client.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using Bunit.TestDoubles;

namespace FSOTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Assert
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }

        public void TestMethod2()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Act
            cut.Find("button").Click();

            // Assert
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");

        }
    }
}

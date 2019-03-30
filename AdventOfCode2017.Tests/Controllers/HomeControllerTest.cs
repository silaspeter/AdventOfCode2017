using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;
using AdventOfCode2017.Controllers;

namespace AdventOfCode2017.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;
using AdventOfCode2017.Controllers;
using LibAdventOfCode2017.Products;

namespace AdventOfCode2017.Tests.Controllers
{
    [TestClass]
    public class AdventOfCode2017ControllerTest
    {
        
        [TestMethod]
        public void PostDay9()
        {
            // Arrange
            Day9Product day9 = new Day9Product("{{<!!>},{<!!>},{<!!>},{<!!>}}");
            var result = day9.Process();
            Assert.AreEqual(result, 9);
        }

       
    }
}

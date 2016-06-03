using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PandoraWeb;
using PandoraWeb.Controllers;
using Xunit;

namespace PandoraWebTest.Controllers {
    public class HomeControllerTest {
        [Fact]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result.ViewBag.Message);
        }
    }
}

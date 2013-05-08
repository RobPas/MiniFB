using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniFB;
using MiniFB.Controllers;
using NUnit.Framework;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            ProfileController controller = new ProfileController();

            // Act
            ViewResult result = controller.Index("urban") as ViewResult;

            // Assert
            NUnit.Framework.Assert.AreNotEqual(result.View, null);
        }

    }
}

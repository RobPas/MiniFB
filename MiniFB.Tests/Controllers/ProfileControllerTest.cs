using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MiniFB;
using MiniFB.Controllers;
using NUnit.Framework;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var testGuid = Guid.NewGuid();
            var users = new List<User> { new User { UserName = "Test1", ID = testGuid, FirstName = "Test1"}};
            var fakeUserRepo = new FakeRepository<User>(users.ToArray());
            ProfileController controller = new ProfileController(fakeUserRepo);

            // Act
            ViewResult result = controller.Index("Test1") as ViewResult;

            // Assert
            Assert.That((result.Model as User).ID , Is.EqualTo(testGuid));
        }

    }
}

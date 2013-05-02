using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MiniFB.Controllers;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using NUnit.Framework;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    class GoatControllerTest
    {
        private Guid firstUserID;
        private IRepository<User> userRepo;

        [SetUp]
        public void setup()
        {
            firstUserID = Guid.NewGuid();
            List<User> userList = new List<User> { 
                                 new User { ID = firstUserID, 
                                            UserName = "TestUser1", 
                                             BirthDate = DateTime.Parse("1980-01-01") },                                new User { ID = Guid.NewGuid(), 
                                                 UserName = "TestUser", 
                                           BirthDate = DateTime.Parse("2000-01-01") } };
            userRepo = new FakeRepository<User>(userList.ToArray());
        }

        [Test]
        public void List_getWith2Users_ShouldReturnViewWith2Users()
        {
            // Arrange
            var goatController = new GoatController(userRepo);

            // Act
            var userModel = goatController.List().Model as List<User>;

            // Assert
            Assert.That(userModel.Count(), Is.EqualTo(2));
        }

        [Test]
        public void MyMethod()
        {
            // Arrange
            int a = 4;
            int b = 4;
            int expected = 8;

            // Act
            int actual = a + b;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

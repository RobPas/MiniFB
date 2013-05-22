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
using System.Web;
using System.IO;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        ProfileController controller;
        Guid testGuid;

        [SetUp]
        public void SetUp()
        {
            testGuid = Guid.NewGuid();
            var users = new List<User> { new User { UserName = "Test1", ID = testGuid, FirstName = "Test1" } };
            var fakeUserRepo = new FakeRepository<User>(users.ToArray());
            controller = new ProfileController(fakeUserRepo);
        }

        [Test]
        public void ProfileControllerTest_Index_returning_right_user_by_id()
        {
            // Arrange

            // Act
            ViewResult result = controller.Index("Test1") as ViewResult;

            // Assert
            Assert.That((result.Model as User).ID , Is.EqualTo(testGuid));
        }


        [Test]
        public void ProfileControllerTest_Edit_returning_right_user_by_id()
        {
            // Arrange
            

            // Act
            ViewResult result = controller.Index("Test1") as ViewResult;
           
            // Assert
            Assert.That((result.Model as User).UserName, Is.EqualTo("Test1"));
        }


        [Test]
        public void ProfileControllerTest_Edit_returning_ERROR_404_if_user_equals_to_null()
        {
            // Arrange
            

            // Act
            ViewResult result = controller.Index("ThisUsernameDosntExist") as ViewResult;

            // Assert
            Assert.Throws(HttpNotFoundResult);
            
        }
    }
}

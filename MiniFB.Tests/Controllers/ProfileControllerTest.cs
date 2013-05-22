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
using MiniFB.Models.Repositories.Abstract;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {

        
        private IRepository<User> fakeUserRepo;
        private Guid UserID;
        [SetUp]
        public void setup()
        {
            UserID = Guid.NewGuid();
            List<User> userList = new List<User> { 
                                new User { 
                                    ID = UserID, 
                                    UserName = "TestUser1", 
                                    BirthDate = DateTime.Parse("1980-01-01") 
                                },                                
                                new User { 
                                    ID = Guid.NewGuid(), 
                                    UserName = "TestUser", 
                                    BirthDate = DateTime.Parse("2000-01-01") } 
                                };
            fakeUserRepo = new FakeRepository<User>(userList.ToArray());
        }

        [Test]
        public void ProfileControllerIndexReturnEqualIDToUsername()
        {
            // Arrange
            
            ProfileController controller = new ProfileController(fakeUserRepo);

            // Act
            ViewResult result = controller.Index("TestUser1") as ViewResult;

            // Assert
            Assert.That((result.Model as User).ID , Is.EqualTo(UserID));
        }

        [Test]
        public void ProfileController_Edit_Model_is_not_null()
        {
            // Arrange
            ProfileController controller = new ProfileController(fakeUserRepo);

            // Act
            ViewResult result = controller.Edit(UserID) as ViewResult;

            // Assert
            Assert.That((result.Model as User), Is.Not.Null);
        }

        [Test]
        public void ProfileController_Edit_return_exeption_if_user_is_null()
        {
            // Arrange
            ProfileController controller = new ProfileController(fakeUserRepo);

            Guid fakeuserID = Guid.NewGuid();
            // Act
            ViewResult result = controller.Edit(UserID) as ViewResult;

            // Assert
            Assert.Throws<Exception>(
      delegate { throw new Exception(); });
        }
        

    }
}

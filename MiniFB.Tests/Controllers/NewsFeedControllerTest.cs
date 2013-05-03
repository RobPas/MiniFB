using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniFB.Controllers;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using NUnit.Framework;

namespace MiniFB.Tests.Controllers
{
    [TestFixture]
    class NewsFeedControllerTest
    {
        private IRepository<NewsFeedItem> _repo;

        [SetUp]
        public void Setup()
        {
            List<NewsFeedItem> newsFeedItemsList = new List<NewsFeedItem> {
                new NewsFeedItem { ID = Guid.NewGuid(), Comments = null, Content = "This is a status", Created = DateTime.Now, Modified = DateTime.Now, Type = "status" }
            };

            _repo = new FakeRepository<NewsFeedItem>(newsFeedItemsList.ToArray());
        }

        [Test]
        public void TestingUnitTesting() 
        { 
            // Arrange 
            var a = 10;
            var b = 20;
            var expected = 30;

            // Act 
            int actual = a + b;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Items_should_return_list_with_NewsFeedItems()
        {
            // Doesn't test shit. But still passes.

            NewsFeedController newsfeedcontroller = new NewsFeedController(_repo);
            List<NewsFeedItem> list;

            var newsFeedModel = newsfeedcontroller.Items().Model as List<NewsFeedItem>;
        }

        [Test]
        public void GoatCounts()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
        }
    }
}

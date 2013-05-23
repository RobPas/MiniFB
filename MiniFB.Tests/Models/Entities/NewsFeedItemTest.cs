using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniFB.Models.Entities;
using NUnit.Framework;

namespace MiniFB.Tests.Models.Entities
{
    [TestFixture]
    public class NewsFeedItemTest
    {
        private NewsFeedItem _newsFeedItem;

        [SetUp]
        public void Setup()
        {
            _newsFeedItem = new NewsFeedItem();
        }

        [Test]
        public void ItemType_negative_value_should_throw_exception()
        {
            int negativeValue = -1;

            Assert.Catch<Exception>(delegate 
            {
                var actual = _newsFeedItem.ItemType = negativeValue;
            });
        }

        [Test]
        public void ItemType_zero_value_should_throw_exception() 
        {
            int zeroValue = 0;

            Assert.Catch<Exception>(delegate
            {
                var actual = _newsFeedItem.ItemType = zeroValue;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniFB.Models.ProfileSettings;
using NUnit.Framework;

namespace MiniFB.Tests.Models.ProfileSettings
{
    [TestFixture]
    public class SettingsValidatorTest
    {
        private SettingsValidator _settingsValidator;

        [SetUp]
        public void Setup()
        {
            _settingsValidator = new SettingsValidator();
        }

        [Test]
        public void isValidSex_Kvinna_returns_true() 
        { 
            // arrange
            
            string sex = "Kvinna";
            bool expected = true;

            // act
            var actual = _settingsValidator.isValidSex(sex);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void isValidSex_empty_string_returns_false()
        {
            // arrange
            string empty = "";
            bool expected = false;

            // act
            var actual = _settingsValidator.isValidSex(empty);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void isValidSex_null_returns_false()
        {
            // arrange
            bool expected = false;

            // act
            var actual = _settingsValidator.isValidSex(null);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void isValidSex_nonvalidsex_returns_false()
        {
            // arrange
            var sex = "four";
            bool expected = false;

            // act
            var actual = _settingsValidator.isValidSex(sex);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
            //Assert.Throws(typeof(ArgumentException), delegate
            //{
            //    _settingsValidator.isValidSex(sex);
            //});
        }
    }
}

using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTest
{
    // Unit tests for Location class - Task 11.1
    [TestFixture]
    public class LocationTest
    {
        private Location _testLocation;
        private Item _testItem;

        [SetUp]
        public void Setup()
        {
            _testLocation = new Location(new string[] { "room", "test" }, "Test Room", "A room for testing");
            _testItem = new Item(new string[] { "sword", "weapon" }, "Steel Sword", "A sharp steel sword");
        }

        // Test Location can identify itself
        [Test]
        public void LocationCanIdentifyItself()
        {
            Assert.That(_testLocation.AreYou("room"), Is.True);
            Assert.That(_testLocation.AreYou("test"), Is.True);
            Assert.That(_testLocation.AreYou("invalid"), Is.False);
        }

        // Test Location can locate items it has
        [Test]
        public void LocationCanLocateItems()
        {
            _testLocation.Inventory.Put(_testItem);
            
            GameObject? result = _testLocation.Locate("sword");
            Assert.That(result, Is.EqualTo(_testItem));
            
            GameObject? nullResult = _testLocation.Locate("bow");
            Assert.That(nullResult, Is.Null);
        }

        // Test Location returns itself when located
        [Test]
        public void LocationLocatesItself()
        {
            GameObject? result = _testLocation.Locate("room");
            Assert.That(result, Is.EqualTo(_testLocation));
        }

        // Test Location full description
        [Test]
        public void LocationFullDescription()
        {
            _testLocation.Inventory.Put(_testItem);
            string description = _testLocation.FullDescription;
            
            Assert.That(description, Does.Contain("Test Room"));
            Assert.That(description, Does.Contain("Steel Sword"));
        }
    }
}
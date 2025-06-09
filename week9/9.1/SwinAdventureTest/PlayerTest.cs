using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTest
{
    [TestFixture]  // CHANGED: From [TestClass] to [TestFixture]
    public class PlayerTest
    {
        private Item _testItem1;
        private Item _testItem2; 
        private Player _testPlayer;

        [SetUp]  // CHANGED: From [TestInitialize] to [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("James", "an explorer");
            _testItem1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            _testItem2 = new Item(new string[] { "light", "torch" }, "A Torch", "A torch to light the path");
            _testPlayer.Inventory.Put(_testItem1);
            _testPlayer.Inventory.Put(_testItem2);
        }

        [Test]  // CHANGED: From [TestMethod] to [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.That(_testPlayer.AreYou("me"), Is.True);  // CHANGED: NUnit Assert syntax
            Assert.That(_testPlayer.AreYou("inventory"), Is.True);
        }

        [Test]  // CHANGED: From [TestMethod] to [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.That(_testPlayer.Locate("silver"), Is.EqualTo(_testItem1));  // CHANGED: NUnit Assert syntax
            Assert.That(_testPlayer.Locate("torch"), Is.EqualTo(_testItem2));
            // Verify items remain in inventory after locating
            Assert.That(_testPlayer.Inventory.HasItem("silver"), Is.True);
            Assert.That(_testPlayer.Inventory.HasItem("torch"), Is.True);
        }

        [Test]  // CHANGED: From [TestMethod] to [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));  // CHANGED: NUnit Assert syntax
            Assert.That(_testPlayer.Locate("inventory"), Is.EqualTo(_testPlayer));
        }

        [Test]  // CHANGED: From [TestMethod] to [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(_testPlayer.Locate("club"), Is.Null);  // CHANGED: NUnit Assert syntax
        }

        [Test]  // CHANGED: From [TestMethod] to [Test]
        public void TestPlayerFullDescription()
        {
            // Expected format based on your Inventory.ItemList property
            string expectedDescription = "You are James, an explorer\nYou are carrying:\n\ta A Silver Hat (silver)\n\ta A Torch (light)\n";
            Assert.That(_testPlayer.FullDescription, Is.EqualTo(expectedDescription));  // CHANGED: NUnit Assert syntax
        }
    }
}

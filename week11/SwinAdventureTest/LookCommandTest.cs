using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTest
{
    // Updated unit tests for LookCommand - Task 11.1
    [TestFixture]
    public class LookCommandTest
    {
        private Item _testItem;
        private Player _testPlayer;
        private Location _testLocation;
        private LookCommand _testLookCommand;

        [SetUp]
        public void Setup()
        {
            _testLookCommand = new LookCommand();
            _testPlayer = new Player("Harry Potter", "a student");
            _testLocation = new Location(new string[] { "room" }, "Test Room", "A room for testing");
            
            _testItem = new Item(new string[] { "gem", "ruby" }, "A Ruby", "A bright pink ruby");
            _testPlayer.Inventory.Put(_testItem);
            _testPlayer.Location = _testLocation;
        }

        // Test Look At Me
        [Test]
        public void LookAtPlayer()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "inventory" });
            Assert.That(result, Is.EqualTo(_testPlayer.FullDescription));
        }

        // Test Look At Item in Player
        [Test]
        public void LookAtItem()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem" });
            Assert.That(result, Is.EqualTo(_testItem.FullDescription));
        }

        // Task 11.1: Test single word "look" shows location
        [Test]
        public void LookAtLocation()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look" });
            Assert.That(result, Is.EqualTo(_testLocation.FullDescription));
        }

        // Task 11.1: Test player can locate items in location
        [Test]
        public void PlayerCanLocateItemsInLocation()
        {
            Item locationItem = new Item(new string[] { "sword", "weapon" }, "Steel Sword", "A sharp sword");
            _testLocation.Inventory.Put(locationItem);
            
            GameObject? result = _testPlayer.Locate("sword");
            Assert.That(result, Is.EqualTo(locationItem));
        }

        // Test player inventory takes priority over location
        [Test]
        public void InventoryTakesPriorityOverLocation()
        {
            Item playerGem = _testItem; // Already in player inventory
            Item locationGem = new Item(new string[] { "gem", "emerald" }, "Emerald", "A green emerald");
            _testLocation.Inventory.Put(locationGem);
            
            GameObject? result = _testPlayer.Locate("gem");
            Assert.That(result, Is.EqualTo(playerGem)); // Should find player's gem first
        }

        // Test Look At Unknown Item
        [Test]
        public void LookAtNothing()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "pen" });
            Assert.That(result, Is.EqualTo("I cannot find the pen in the Harry Potter"));
        }

        // Test Look At Item In Me
        [Test]
        public void LookAtItemInPlayer()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.That(result, Is.EqualTo(_testItem.FullDescription));
        }

        // Test invalid commands
        [Test]
        public void InvalidLook()
        {
            string result1 = _testLookCommand.Execute(_testPlayer, new string[] { "look", "around" });
            Assert.That(result1, Is.EqualTo("I don't know how to look like that"));
            
            string result2 = _testLookCommand.Execute(_testPlayer, new string[] { "hello", "at", "gem" });
            Assert.That(result2, Is.EqualTo("Error in look input"));
        }
    }
}
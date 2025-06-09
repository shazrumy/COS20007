using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    // Unit tests for LookCommand - Task 10.1
    [TestFixture]
    public class LookCommandTests
    {
        private Item _testItem;
        private Player _testPlayer;
        private Bag _testMoneyBag;
        private LookCommand _testLookCommand;

        [SetUp]
        public void Setup()
        {
            _testLookCommand = new LookCommand();
            _testPlayer = new Player("Harry Potter", "a student");
            
            // Use gem/ruby as specified in PDF requirements
            _testItem = new Item(new string[] { "gem", "ruby" }, "A Ruby", "A bright pink ruby");
            _testMoneyBag = new Bag(new string[] { "bag", "money" }, "Money Bag", "A bag that contains valuables");
            
            _testPlayer.Inventory.Put(_testItem);
        }

        // Test Look At Me
        [Test]
        public void LookAtPlayer()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "inventory" });
            Assert.That(result, Is.EqualTo(_testPlayer.FullDescription));
        }

        // Test Look At Gem - PDF requirement: look at gem in player's inventory
        [Test]
        public void LookAtItem()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem" });
            Assert.That(result, Is.EqualTo(_testItem.FullDescription));
        }

        // Test Look At Unknown Item
        [Test]
        public void LookAtNothing()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "pen" });
            Assert.That(result, Is.EqualTo("I cannot find the pen in the Harry Potter"));
        }

        // Test Look At Gem In Me - PDF requirement: "look at gem in inventory"
        [Test]
        public void LookAtItemInPlayer()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.That(result, Is.EqualTo(_testItem.FullDescription));
        }

        // Test Look At Gem In Bag - PDF requirement: look at gem in bag
        [Test]
        public void LookAtItemInBag()
        {
            // Create gem in bag as per PDF requirements
            Item bagGem = new Item(new string[] { "gem", "red" }, "Red Gem", "A bright red gem");
            _testMoneyBag.Inventory.Put(bagGem);
            _testPlayer.Inventory.Put(_testMoneyBag);
            
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo(bagGem.FullDescription));
        }

        // Test Look At Gem In No Bag - PDF requirement: look for bag that doesn't exist
        [Test]
        public void LookAtItemInNoBag()
        {
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo("I cannot find the bag"));
        }

        // Test Look At No Gem In Bag - PDF requirement: look for gem not in bag
        [Test]
        public void LookAtNothingInBag()
        {
            _testPlayer.Inventory.Put(_testMoneyBag);
            string result = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo("I cannot find the gem in the Money Bag"));
        }

        // Test Invalid Look Commands - PDF requirement: test error conditions
        [Test]
        public void InvalidLook()
        {
            // Test "look around" - wrong number of elements
            string result1 = _testLookCommand.Execute(_testPlayer, new string[] { "look", "around" });
            Assert.That(result1, Is.EqualTo("I don't know how to look like that"));
            
            // Test "hello your student ID" - wrong first word
            string result2 = _testLookCommand.Execute(_testPlayer, new string[] { "hello", "104100247", "gem" });
            Assert.That(result2, Is.EqualTo("Error in look input"));
            
            // Test "look for gem" - wrong second word
            string result3 = _testLookCommand.Execute(_testPlayer, new string[] { "look", "for", "gem" });
            Assert.That(result3, Is.EqualTo("What do you want to look at?"));
            
            // Test "look at gem inside bag" - wrong fourth word
            string result4 = _testLookCommand.Execute(_testPlayer, new string[] { "look", "at", "gem", "inside", "bag" });
            Assert.That(result4, Is.EqualTo("What do you want to look in?"));
        }
    }
}
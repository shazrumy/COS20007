using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class ItemTest
    {
        private Item _testItem;
        private Item _emptyItem;

        [SetUp]
        public void Setup()
        {
            // Create test item with multiple identifiers
            string[] swordIds = { "sword", "weapon", "blade" };
            _testItem = new Item(swordIds, "bronze sword", "A sturdy bronze sword with intricate engravings.");
            
            // Create item with empty identifiers for edge case testing
            string[] emptyIds = { };
            _emptyItem = new Item(emptyIds, "empty item", "An item with no identifiers.");
        }

        // Test 1: Test Item is Identifiable
        [Test]
        public void TestItemIsIdentifiable()
        {
            // Test with original identifiers
            Assert.That(_testItem.AreYou("sword"), Is.True);
            Assert.That(_testItem.AreYou("weapon"), Is.True);
            Assert.That(_testItem.AreYou("blade"), Is.True);
            
            // Test case insensitive matching
            Assert.That(_testItem.AreYou("SWORD"), Is.True);
            Assert.That(_testItem.AreYou("WeApOn"), Is.True);
            
            // Test with invalid identifiers
            Assert.That(_testItem.AreYou("axe"), Is.False);
            Assert.That(_testItem.AreYou("shield"), Is.False);
        }

        // Test 2: Test Short Description
        [Test]
        public void TestShortDescription()
        {
            // Test the format: "a {name} ({first_id})"
            string expectedShortDescription = "a bronze sword (sword)";
            Assert.That(_testItem.ShortDescription, Is.EqualTo(expectedShortDescription));
            
            // Test with another item to verify format consistency
            string[] bookIds = { "book", "tome", "manual" };
            var book = new Item(bookIds, "spell book", "A magical tome containing ancient spells.");
            string expectedBookDescription = "a spell book (book)";
            Assert.That(book.ShortDescription, Is.EqualTo(expectedBookDescription));
        }

        // Test 3: Test Full Description (LongDescription)
        [Test]
        public void TestFullDescription()
        {
            // Test that LongDescription returns the item's description
            string expectedDescription = "A sturdy bronze sword with intricate engravings.";
            Assert.That(_testItem.LongDescription, Is.EqualTo(expectedDescription));
            
            // Test with different item
            string[] potionIds = { "potion", "bottle", "elixir" };
            var potion = new Item(potionIds, "health potion", "A red potion that restores health when consumed.");
            Assert.That(potion.LongDescription, Is.EqualTo("A red potion that restores health when consumed."));
        }

        // Test 4: Test Privilege Escalation
        [Test]
        public void TestPrivilegeEscalation()
        {
            // Create item with student ID as first identifier
            string[] testIds = { "104100247", "test", "item" };
            var testItem = new Item(testIds, "test item", "A test item for privilege escalation.");
            
            // Verify initial FirstID
            Assert.That(testItem.FirstID, Is.EqualTo("104100247"));
            
            // Perform privilege escalation with correct PIN (last 4 digits: 0247)
            testItem.PrivilegeEscalation("0247");
            
            // Verify FirstID has been replaced with tutorial ID
            Assert.That(testItem.FirstID, Is.EqualTo("tutorial_id"));
            
            // Verify other identifiers still work
            Assert.That(testItem.AreYou("test"), Is.True);
            Assert.That(testItem.AreYou("item"), Is.True);
        }

        // Additional Test: Test Privilege Escalation with Wrong PIN
        [Test]
        public void TestPrivilegeEscalationWrongPin()
        {
            // Create item with identifiers
            string[] testIds = { "104100247", "secure", "item" };
            var testItem = new Item(testIds, "secure item", "A secure test item.");
            
            // Store original FirstID
            string originalFirstId = testItem.FirstID;
            
            // Try privilege escalation with wrong PIN
            testItem.PrivilegeEscalation("9999");
            
            // Verify FirstID hasn't changed
            Assert.That(testItem.FirstID, Is.EqualTo(originalFirstId));
        }

        // Additional Test: Test Name Property
        [Test]
        public void TestName()
        {
            // Test that Name property returns correct name
            Assert.That(_testItem.Name, Is.EqualTo("bronze sword"));
            
            // Test with empty item
            Assert.That(_emptyItem.Name, Is.EqualTo("empty item"));
        }

        // Additional Test: Test Add and Remove Identifiers
        [Test]
        public void TestAddRemoveIdentifiers()
        {
            // Add new identifier
            _testItem.AddIdentifier("excalibur");
            Assert.That(_testItem.AreYou("excalibur"), Is.True);
            
            // Remove identifier
            _testItem.RemoveIdentifier("excalibur");
            Assert.That(_testItem.AreYou("excalibur"), Is.False);
            
            // Verify original identifiers still work
            Assert.That(_testItem.AreYou("sword"), Is.True);
        }

        // Additional Test: Test FirstID with Empty Item
        [Test]
        public void TestFirstIdWithEmptyItem()
        {
            // Test that empty item returns empty string for FirstID
            Assert.That(_emptyItem.FirstID, Is.EqualTo(""));
        }
    }
}
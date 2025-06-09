using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure
{
    [TestFixture]
    public class ItemTest
    {
        private Item _testItem;

        [SetUp]
        public void Setup()
        {
            // Create test item with multiple identifiers
            string[] swordIds = { "sword", "weapon", "blade" };
            _testItem = new Item(swordIds, "bronze sword", "A sturdy bronze sword with intricate engravings.");
        }

        // Test that the item responds correctly to "Are You" requests based on the identifiers it is created with
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

        // Test that the game object's short description returns the string "a name (first id)" eg: a bronze sword (sword)
        [Test]
        public void TestShortDescription()
        {
            // Test the format: "a {name} ({first_id})"
            string expectedShortDescription = "a bronze sword (sword)";
            Assert.That(_testItem.ShortDescription, Is.EqualTo(expectedShortDescription));
        }

        // Test that returns the item's description
        [Test]
        public void TestFullDescription()
        {
            // FIXED: Changed LongDescription to FullDescription
            string expectedDescription = "A sturdy bronze sword with intricate engravings.";
            Assert.That(_testItem.FullDescription, Is.EqualTo(expectedDescription));
        }

        // Test that the item returns correctly the first ID as your tutorial ID if the inputed pin matches the last 4 digits of your student ID
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
            // Note: Replace "tutorial_id" with your actual tutorial ID
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
    }
}
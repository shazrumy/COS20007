using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    // Unit tests for IdentifiableObject class functionality
    [TestFixture]
    public class IdentifiableObjectTest
    {
        // Test objects for positive and edge case scenarios
        private IdentifiableObject _testObject;
        private IdentifiableObject _emptyObject;

        // Initialize test objects before each test
        [SetUp]
        public void Setup()
        {
            // Create object with student identifiers for testing
            string[] studentIdentifiers = { "104100247", "Shakila", "Hazrumy" };
            _testObject = new IdentifiableObject(studentIdentifiers);
            
            // Create empty object for edge case testing
            string[] emptyIdentifiers = { };
            _emptyObject = new IdentifiableObject(emptyIdentifiers);
        }

        // Test 1: Verify AreYou() returns true for valid identifiers
        [Test]
        public void TestAreYou()
        {
            // Test all identifiers passed to constructor
            Assert.That(_testObject.AreYou("104100247"), Is.True);
            Assert.That(_testObject.AreYou("Shakila"), Is.True);
            Assert.That(_testObject.AreYou("Hazrumy"), Is.True);
        }

        // Test 2: Verify AreYou() returns false for invalid identifiers
        [Test]
        public void TestNotAreYou()
        {
            // Test with modified student ID (0→O substitution)
            Assert.That(_testObject.AreYou("1O41OO247"), Is.False);
            
            // Test with unrelated identifiers
            Assert.That(_testObject.AreYou("Jagger"), Is.False);
            Assert.That(_testObject.AreYou("Swift"), Is.False);
            Assert.That(_testObject.AreYou("John"), Is.False);
        }

        // Test 3: Verify case-insensitive identifier matching
        [Test]
        public void TestCaseSensitive()
        {
            // Test uppercase variations
            Assert.That(_testObject.AreYou("SHAKILA"), Is.True);
            Assert.That(_testObject.AreYou("HAZRUMY"), Is.True);
            
            // Test mixed case variations
            Assert.That(_testObject.AreYou("ShAkIlA"), Is.True);
            Assert.That(_testObject.AreYou("HaZrUmY"), Is.True);
            
            // Test lowercase variations
            Assert.That(_testObject.AreYou("shakila"), Is.True);
            Assert.That(_testObject.AreYou("hazrumy"), Is.True);
        }

        // Test 4: Verify FirstID returns the first identifier
        [Test]
        public void TestFirstId()
        {
            // Should return first identifier from constructor array
            Assert.That(_testObject.FirstID, Is.EqualTo("104100247"));
            
            // Verify it's not a different identifier
            Assert.That(_testObject.FirstID, Is.Not.EqualTo("shakila"));
        }

        // Test 5: Verify FirstID returns empty string when no identifiers exist
        [Test]
        public void TestFirstIdWithNoIds()
        {
            // Empty object should return empty string
            Assert.That(_emptyObject.FirstID, Is.EqualTo(""));
        }

        // Test 6: Verify AddIdentifier() adds new identifiers successfully
        [Test]
        public void TestAddId()
        {
            // Create object with band member identifiers
            string[] initialIds = { "Seekers", "Athol", "Keith", "Bruce" };
            var testObj = new IdentifiableObject(initialIds);
            
            // Add new identifier and verify it works
            testObj.AddIdentifier("Mary");
            
            // Test all identifiers are recognized
            Assert.That(testObj.AreYou("Seekers"), Is.True);
            Assert.That(testObj.AreYou("Keith"), Is.True);
            Assert.That(testObj.AreYou("Mary"), Is.True);
        }

        // Test 7: Verify privilege escalation replaces FirstID with correct PIN
        [Test]
        public void TestPrivilegeEscalation()
        {
            // Create object with student ID as first identifier
            string[] ids = { "104100247", "Shakila" };
            var testObj = new IdentifiableObject(ids);
            
            // Verify initial state
            Assert.That(testObj.FirstID, Is.EqualTo("104100247"));
            
            // Perform privilege escalation with correct PIN (last 4 digits)
            testObj.PrivilegeEscalation("0247");
            
            // Verify FirstID changed to tutorial ID
            Assert.That(testObj.FirstID, Is.EqualTo("tutorial_id"));
            
            // Verify other identifiers still work
            Assert.That(testObj.AreYou("Shakila"), Is.True);
        }

        // Additional Test: Verify privilege escalation fails with wrong PIN
        [Test]
        public void TestPrivilegeEscalationWrongPin()
        {
            // Create test object
            string[] ids = { "104100247", "Shakila" };
            var testObj = new IdentifiableObject(ids);
            
            // Store original FirstID
            string originalFirstId = testObj.FirstID;
            
            // Try escalation with wrong PIN
            testObj.PrivilegeEscalation("9999");
            
            // Verify FirstID unchanged
            Assert.That(testObj.FirstID, Is.EqualTo(originalFirstId));
        }

        // Additional Test: Verify RemoveIdentifier() removes identifiers correctly
        [Test]
        public void TestRemoveIdentifier()
        {
            // Add temporary identifier
            _testObject.AddIdentifier("Temporary");
            Assert.That(_testObject.AreYou("Temporary"), Is.True);
            
            // Remove the identifier
            _testObject.RemoveIdentifier("Temporary");
            Assert.That(_testObject.AreYou("Temporary"), Is.False);
            
            // Verify original identifiers still work
            Assert.That(_testObject.AreYou("Shakila"), Is.True);
        }
    }
}

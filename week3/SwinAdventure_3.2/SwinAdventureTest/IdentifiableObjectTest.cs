using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using IdentifiableObject;

namespace SwinAdventure
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        // Test objects for various scenarios
        private IdentifiableObject.IdentifiableObject _testObject;
        private IdentifiableObject.IdentifiableObject _emptyObject;

        [SetUp]
        public void Setup()
        {
            // Initialize test object with student identifiers
            string[] studentIdentifiers = { "104100247", "Shakila", "Hazrumy" };
            _testObject = new IdentifiableObject.IdentifiableObject(studentIdentifiers);
            
            // Initialize empty object for testing edge cases
            string[] emptyIdentifiers = { };
            _emptyObject = new IdentifiableObject.IdentifiableObject(emptyIdentifiers);
        }

        // Test 1: Test Are You - Check positive identification
        [Test]
        public void TestAreYou()
        {
            // Test with student ID
            Assert.That(_testObject.AreYou("104100247"), Is.True);
            
            // Test with first name
            Assert.That(_testObject.AreYou("Shakila"), Is.True);
            
            // Test with family name
            Assert.That(_testObject.AreYou("Hazrumy"), Is.True);
        }

        // Test 2: Test Not Are You - Check negative identification
        [Test]
        public void TestNotAreYou()
        {
            // Test with modified student ID (change 0 to O as suggested)
            Assert.That(_testObject.AreYou("1O41OO247"), Is.False);
            
            // Test with completely different identifiers
            Assert.That(_testObject.AreYou("Jagger"), Is.False);
            Assert.That(_testObject.AreYou("Swift"), Is.False);
            Assert.That(_testObject.AreYou("John"), Is.False);
        }

        // Test 3: Test Case Sensitive - Check case insensitive matching
        [Test]
        public void TestCaseSensitive()
        {
            // Test uppercase versions of identifiers
            Assert.That(_testObject.AreYou("SHAKILA"), Is.True);
            Assert.That(_testObject.AreYou("HAZRUMY"), Is.True);
            
            // Test mixed case versions
            Assert.That(_testObject.AreYou("ShAkIlA"), Is.True);
            Assert.That(_testObject.AreYou("HaZrUmY"), Is.True);
            
            // Test lowercase versions
            Assert.That(_testObject.AreYou("shakila"), Is.True);
            Assert.That(_testObject.AreYou("hazrumy"), Is.True);
        }

        // Test 4: Test First ID - Check first identifier retrieval
        [Test]
        public void TestFirstId()
        {
            // First identifier should be the first one added (in lowercase)
            Assert.That(_testObject.FirstID, Is.EqualTo("104100247".ToLower()));
            
            // Verify it's not something else
            Assert.That(_testObject.FirstID, Is.Not.EqualTo("shakila"));
        }

        // Test 5: Test First ID With No IDs - Check empty object behavior
        [Test]
        public void TestFirstIdWithNoIds()
        {
            // Empty object should return empty string for FirstID
            Assert.That(_emptyObject.FirstID, Is.EqualTo(""));
        }

        // Test 6: Test Add ID - Check adding new identifiers
        [Test]
        public void TestAddId()
        {
            // Create object with initial identifiers
            string[] initialIds = { "Seekers", "Athol", "Keith", "Bruce" };
            var testObj = new IdentifiableObject.IdentifiableObject(initialIds);
            
            // Add new identifier
            testObj.AddIdentifier("Mary");
            
            // Verify all identifiers work
            Assert.That(testObj.AreYou("Seekers"), Is.True);
            Assert.That(testObj.AreYou("Keith"), Is.True);
            Assert.That(testObj.AreYou("Mary"), Is.True);
            
            // Verify the new identifier was added
            Assert.That(testObj.AreYou("Mary"), Is.True);
        }

        // Test 7: Test Privilege Escalation - Check ID replacement functionality
        [Test]
        public void TestPrivilegeEscalation()
        {
            // Create object with student ID and name
            string[] ids = { "104100247", "Shakila" };
            var testObj = new IdentifiableObject.IdentifiableObject(ids);
            
            // Verify initial FirstID
            Assert.That(testObj.FirstID, Is.EqualTo("104100247"));
            
            // Perform privilege escalation with correct PIN (last 4 digits)
            testObj.PrivilegeEscalation("0247");
            
            // Verify FirstID has been replaced with tutorial ID
            Assert.That(testObj.FirstID, Is.EqualTo("tutorial_id"));
            
            // Verify other identifiers still work
            Assert.That(testObj.AreYou("Shakila"), Is.True);
        }

        // Additional Test: Test Privilege Escalation with Wrong PIN
        [Test]
        public void TestPrivilegeEscalationWrongPin()
        {
            // Create object with student ID
            string[] ids = { "104100247", "Shakila" };
            var testObj = new IdentifiableObject.IdentifiableObject(ids);
            
            // Store original FirstID
            string originalFirstId = testObj.FirstID;
            
            // Try privilege escalation with wrong PIN
            testObj.PrivilegeEscalation("1ooo41oo247");
            
            // Verify FirstID hasn't changed
            Assert.That(testObj.FirstID, Is.EqualTo(originalFirstId));
        }

        // Additional Test: Test Remove Identifier functionality
        [Test]
        public void TestRemoveIdentifier()
        {
            // Add an identifier first
            _testObject.AddIdentifier("Temporary");
            
            // Verify it was added
            Assert.That(_testObject.AreYou("Temporary"), Is.True);
            
            // Remove the identifier
            _testObject.RemoveIdentifier("Temporary");
            
            // Verify it was removed
            Assert.That(_testObject.AreYou("Temporary"), Is.False);
            
            // Verify other identifiers still work
            Assert.That(_testObject.AreYou("Shakila"), Is.True);
        }
    }
}

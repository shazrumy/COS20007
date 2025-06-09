using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class BagTest
    {
        private Bag _testToolBag;
        private Bag _testFoodBag;
        private Item _testItem1;
        private Item _testItem2;

        [SetUp]
        public void Setup()
        {
            // Create test bags and items as shown in the PDF template
            _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            _testFoodBag = new Bag(new string[] { "bag", "food" }, "Food Bag", "A bag that contains food");
            _testItem1 = new Item(new string[] { "hammer", "tool" }, "Hammer", "A heavy hammer");
            _testItem2 = new Item(new string[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");
        }

        // Test that you can add items to the Bag, and locate the items in its inventory
        // This returns items the bag has and the item remains in the bag's inventory
        [Test]
        public void BagLocatesItems()
        {
            // Add item to bag
            _testToolBag.Inventory.Put(_testItem1);
            
            // Test that bag can locate the item
            Assert.That(_testToolBag.Locate("hammer"), Is.EqualTo(_testItem1));
            Assert.That(_testToolBag.Locate("tool"), Is.EqualTo(_testItem1));
            
            // Verify item remains in bag's inventory
            Assert.That(_testToolBag.Inventory.HasItem("hammer"), Is.True);
        }

        // Test that the bag returns itself if asked to locate one of its identifiers
        [Test]
        public void BagLocatesItself()
        {
            Assert.That(_testToolBag.Locate("bag"), Is.EqualTo(_testToolBag));
            Assert.That(_testToolBag.Locate("tool"), Is.EqualTo(_testToolBag));
        }

        // Test that the bag returns a null object if asked to locate something it does not have
        [Test]
        public void BagLocatesNothing()
        {
            Assert.That(_testToolBag.Locate("sword"), Is.Null);
            Assert.That(_testToolBag.Locate("nonexistent"), Is.Null);
        }

        // Test that the bag's full description contains the text "In the <n> you can see:"
        // and the short descriptions of the items the bag contains (from its inventory's item list)
        [Test]
        public void BagFullDescription()
        {
            // Add items to bag
            _testToolBag.Inventory.Put(_testItem1);
            _testToolBag.Inventory.Put(_testItem2);
            
            // Expected format: "In the <n> you can see:\n" + Inventory.ItemList (tab-indented with newlines)
            string expectedDescription = "In the Tools Bag you can see:\n\ta Hammer (hammer)\n\ta A Beef Stew (stew)\n";
            Assert.That(_testToolBag.FullDescription, Is.EqualTo(expectedDescription));
        }

        // Test bag in bag functionality
        // Create two Bag objects (b1, b2), put b2 in b1's inventory
        // Test that b1 can locate b2, can locate other items in b1, but cannot locate items in b2
        [Test]
        public void BaginBag()
        {
            // Create two bags
            Bag b1 = new Bag(new string[] { "b1", "bag1" }, "Bag 1", "First bag");
            Bag b2 = new Bag(new string[] { "b2", "bag2" }, "Bag 2", "Second bag");
            
            // Put some items in each bag
            Item itemInB1 = new Item(new string[] { "key", "metal" }, "Key", "A metal key");
            Item itemInB2 = new Item(new string[] { "coin", "gold" }, "Coin", "A gold coin");
            
            b1.Inventory.Put(itemInB1);  // Item directly in b1
            b2.Inventory.Put(itemInB2);  // Item in b2
            b1.Inventory.Put(b2);        // Put b2 inside b1
            
            // Test that b1 can locate b2
            Assert.That(b1.Locate("b2"), Is.EqualTo(b2));
            Assert.That(b1.Locate("bag2"), Is.EqualTo(b2));
            
            // Test that b1 can locate items directly in b1
            Assert.That(b1.Locate("key"), Is.EqualTo(itemInB1));
            
            // Test that b1 CANNOT locate items that are inside b2
            Assert.That(b1.Locate("coin"), Is.Null);
            Assert.That(b1.Locate("gold"), Is.Null);
        }

        // Test bag in bag with privileged item
        // Create two Bag objects (b1,b2), put b2 in b1's inventory
        // Put a privileged item into b2 using PrivilegeEscalation method
        // Test that b1 cannot locate the privileged item in b2
        [Test]
        public void BagPrivilegedItem()
        {
            // Create two bags
            Bag b1 = new Bag(new string[] { "b1", "outer" }, "Outer Bag", "The outer bag");
            Bag b2 = new Bag(new string[] { "b2", "inner" }, "Inner Bag", "The inner bag");
            
            // Create a privileged item with student ID as first identifier
            Item privilegedItem = new Item(new string[] { "104100247", "secret", "item" }, "Secret Item", "A secret privileged item");
            
            // Use PrivilegeEscalation to make it privileged (use last 4 digits of student ID)
            privilegedItem.PrivilegeEscalation("0247");
            
            // Put privileged item in b2, then put b2 in b1
            b2.Inventory.Put(privilegedItem);
            b1.Inventory.Put(b2);
            
            // Test that b1 can locate b2
            Assert.That(b1.Locate("b2"), Is.EqualTo(b2));
            
            // Test that b1 CANNOT locate the privileged item in b2
            // Since the item's FirstID was changed to "tutorial_id" by PrivilegeEscalation
            Assert.That(b1.Locate("tutorial_id"), Is.Null);
            Assert.That(b1.Locate("secret"), Is.Null);
            
            // However, b2 should still be able to locate its own privileged item
            Assert.That(b2.Locate("tutorial_id"), Is.EqualTo(privilegedItem));
        }
    }
}

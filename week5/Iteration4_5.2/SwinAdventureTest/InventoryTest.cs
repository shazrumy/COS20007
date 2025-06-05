using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwinAdventure;
 
namespace SwinAdventure
{
    // Test class for the Inventory functionality
    public class TestInventory
    {
        // Test items used across multiple tests
        Item shovel = new Item(new string[] {"shovel"},"shovel", "This is a shovel");
        Item sword = new Item(new string[] { "sword" }, "sword", "This is a sword");

        // Setup method called before each test (currently empty)
        [SetUp]
        public void Setup()
        {

        }

        // Test that the Inventory has items that are put in it
        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstID));
        }

        // Test that the Inventory does not have items it does not contain
        [Test]
        public void TestNoFindItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Assert.IsFalse(i.HasItem(sword.FirstID));
        }

        // Test that Fetch returns items it has, and the item remains in the inventory
        [Test]
        public void TestFetchItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Item? fetchItem = i.Fetch(shovel.FirstID);

            Assert.IsTrue(fetchItem == shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstID));
        }

        // Test that Take returns the item, and the item is no longer in the inventory
        [Test]
        public void TestTakeItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            i.Take(shovel.FirstID);
            Assert.IsFalse(i.HasItem(shovel.FirstID));
        }

        // Test that ItemList returns a string containing multiple lines with tab-indented short descriptions
        [Test]
        public void TestItemList()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            i.Put(sword);
            Assert.IsTrue(i.HasItem(shovel.FirstID));
            Assert.IsTrue(i.HasItem(sword.FirstID));

            // Expected output with tab indentation as required  
            string expctOutput = "\ta shovel (shovel)\n" + "\ta sword (sword)\n";
            Assert.That(i.ItemList, Is.EqualTo(expctOutput));
        }
    }
}

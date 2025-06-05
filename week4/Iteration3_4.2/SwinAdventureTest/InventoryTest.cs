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

        // Test that the Inventory can find items that were added to it
        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstID));
        }

        // Test that the Inventory correctly reports when items are NOT present
        [Test]
        public void TestNoFindItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Assert.IsFalse(i.HasItem(sword.FirstID));
        }

        // Test that Fetch returns the correct item and leaves it in the inventory
        [Test]
        public void TestFetchItems()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Item? fetchItem = i.Fetch(shovel.FirstID);

            Assert.IsTrue(fetchItem == shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstID));
        }

        // Test that Take removes the item from inventory and returns it
        [Test]
        public void TestTakenItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            i.Take(shovel.FirstID);
            Assert.IsFalse(i.HasItem(shovel.FirstID));
        }

        // Test that ItemList returns properly formatted string with tab-indented descriptions
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

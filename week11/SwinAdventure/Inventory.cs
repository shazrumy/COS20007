using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public string ItemList
        {
            get
            {
                string list = String.Empty;
                //option 1. separate list elements by a new line
                foreach (Item itm in _items)
                {
                    list = list + "\t" + itm.ShortDescription + "\n";
                }

                //option 2. separate list elements by commas
                //List<string> ItemDescriptionList = new List<string>();
                //foreach (Item itm in _items)
                //{
                //    ItemDescriptionList.Add(itm.ShortDescription);
                //}
                //list = string.Join(",", ItemDescriptionList);

                return list;
            }
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item? Take(string id)  // FIXED: Added nullable return type
        {
            Item? i = Fetch(id);  // FIXED: Added nullable type
            if (i != null)
            {
                _items.Remove(i);
            }
            return i;
        }

        public Item? Fetch(string id)  // FIXED: Added nullable return type
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }
    }
}
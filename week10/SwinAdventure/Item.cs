using System;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }

        // ADDED: Override ShortDescription to return "a name (id)" format for items
        public override string ShortDescription
        {
            get
            {
                return $"a {Name} ({FirstID})";
            }
        }
    }
}
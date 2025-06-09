using System;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }

        public override string ShortDescription
        {
            get
            {
                return $"a {Name} ({FirstID})";
            }
        }
    }
}

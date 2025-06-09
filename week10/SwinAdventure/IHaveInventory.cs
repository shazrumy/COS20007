using System;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        GameObject? Locate(string id);  // FIXED: Added nullable return type

        string Name { get; }
    }
}

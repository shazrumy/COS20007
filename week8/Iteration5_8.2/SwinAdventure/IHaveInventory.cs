using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        GameObject? Locate(string id);  // FIXED: Added ? to indicate nullable return
        string Name { get; }
    }
}

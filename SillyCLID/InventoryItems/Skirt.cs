using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class Skirt : IAmAnInventoryItem
    {
        public string Name => "Skirt";
        public Dictionary<string, Func<string>> Commands { get; }

        public Skirt()
        {
            Commands = new Dictionary<string, Func<string>>
            {
                {"Inspect",() => "It's a pleated skirt. It's blue. It's a little small..."},
                {"Remove", () => "Excuse me, what?!  That is NOT an appropriate way to behave!"},
                {"Tear", () =>
                {
                    Utilities.Program._character.Inventory.Remove(this.Name);
                    Utilities.Program._character.AddItemToInventory(new TornSkirt(), out var response);
                    return "You have torn the skirt...do you feel better about yourself now?";
                }}
            };
        }
    }
}

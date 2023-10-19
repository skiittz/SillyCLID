using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class MasterBedroomKey : IAmAnInventoryItem
    {
        public string Name => "Bedroom Key";
        public Dictionary<string, Func<string>> Commands { get; }
    }
}

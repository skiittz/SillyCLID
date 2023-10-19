using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class TornSkirt : IAmAnInventoryItem
    {
        public string Name => "Torn Skirt";

        public Dictionary<string, Func<string>> Commands => new()
        {
            { "Inspect", () => "It's a skirt.  Now it's torn.  You are embarrassed." },
            { "Remove", () => "It is already torn! Just leave it alone!"},
            { "Tear", () => "You already did that!"},
        };
    }
}

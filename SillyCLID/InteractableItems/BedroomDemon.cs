using SillyCLID.Definitions;
using SillyCLID.InventoryItems;

namespace SillyCLID.InteractableItems
{
    public class BedroomDemon : IAmAnInteractableObject
    {
        public string Name => "Demon";
        public Dictionary<string, Func<string>> Commands => new()
        {
            {"Tickle", () =>
                {
                    var key = new MasterBedroomKey();
                    Utilities.Program._character.Inventory.Add(key.Name, key);
                    return "The demon giggles.  He then gives you a key.";
                }
            },
            {"Attack", () =>
            {
                Utilities.Program._character.CurrentHealth -= 10;
                return "The demon dodges your attack and slashes in riposte! (hp -10)";
            }}
        };
        public string Describe() => "There is a pint size demon sitting on the bed.";
    }
}

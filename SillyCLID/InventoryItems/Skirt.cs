using SillyCLID.Commands;
using SillyCLID.Commands.Responses;
using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class Skirt : IInteractableObject
    {
        private static string _itemName = "Skirt";

        public string ItemName => _itemName;
        public CommandHandler CommandHandler { get; }

        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands =
            new()
            {
                {Command.Inspect, _ => new SimpleResponse("It's a pleated skirt. It's blue. It's a little small...")},
                {Command.Remove, _ => new SimpleResponse("Excuse me, what?!  That is NOT an appropriate way to behave!")},
                {Command.Tear, _ =>
                {
                    Utilities.Program._character.Inventory.Remove(_itemName);
                    Utilities.Program._character.AddItemToInventory(new TornSkirt(), out var response);
                    return new SimpleResponse("You have torn the skirt...do you feel better about yourself now?");
                }}
            };

        public Skirt()
        {
            CommandHandler = new CommandHandler(commands);
        }
    }
}

using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class TornSkirt : IInteractableObject
    {
        private static string _itemName = "Torn Skirt";
        public string ItemName => _itemName;
        public CommandHandler CommandHandler { get; }

        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands =
            new()
            {
                {
                    Command.Inspect,
                    _ => new SimpleResponse("It's a skirt.  Now it's torn.  You should be embarrassed.")
                },
                { Command.Remove, _ => new SimpleResponse("It is already torn! Just leave it alone!") },
                { Command.Tear, _ => new SimpleResponse("You already did that!") }

            };

        public TornSkirt()
        {
            CommandHandler = new CommandHandler(commands);
        }
    }
}

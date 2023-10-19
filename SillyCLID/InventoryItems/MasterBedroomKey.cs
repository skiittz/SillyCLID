using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class MasterBedroomKey : IInteractableObject
    {
        public string ItemName => "Bedroom Key";
        public  string Description => "It's a key.";

        public CommandHandler CommandHandler { get; }
        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands = new();

        public MasterBedroomKey()
        {
            CommandHandler = new CommandHandler(commands);
        }
    }
}

using SillyCLID.Commands;
using SillyCLID.Commands.Responses;
using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
    public class Key_WoodenDoor : IInteractableObject
    {
        public string ItemName => "Wooden Key";
        public CommandHandler CommandHandler { get; } = new(commands);

        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands = new()
        {
	        {
		        Command.Describe, _ =>
		        {
			        return new SimpleResponse("It's a key");
		        }
	        }
        };
    }
}

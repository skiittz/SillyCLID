using SillyCLID.Commands;
using SillyCLID.Commands.Responses;
using SillyCLID.Definitions;
using SillyCLID.InventoryItems;
using SillyCLID.Utilities;

namespace SillyCLID.WorldItems
{
    public class BedroomDemon : IInteractableObject
    {
        public  string ItemName => "Demon";
        public CommandHandler CommandHandler { get; } = new(commands);

        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands =
            new()
            {
                    {
                        Command.Tickle, _ =>
                        {
                            var key = new Key_WoodenDoor();
                            Program._character.AddItemToInventory(new Key_WoodenDoor(), out var _);
                            return new SimpleResponse("The demon giggles.  He then gives you a key.");
                        }
                    },
                    {
                        Command.Attack, _ =>
                        {
                            Utilities.Program._character.Damage(10);
                            return new SimpleResponse("The demon dodges your attack and slashes in riposte!");
                        }
                    },
                    {
                        Command.Describe, _ =>
                        {
                            return new SimpleResponse("There is a pint size demon sitting on the floor.");
                        }
                    }
                };
    }
}

using SillyCLID.Definitions;
using SillyCLID.InventoryItems;
using SillyCLID.Utilities;

namespace SillyCLID.WorldItems
{
    public class BedroomDemon : IInteractableObject
    {
        public  string ItemName => "Demon";
        public CommandHandler CommandHandler { get; }
        private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands =
            new()
            {
                    {
                        Command.Tickle, _ =>
                        {
                            var key = new MasterBedroomKey();
                            Program._character.AddItemToInventory(new MasterBedroomKey(), out var _);
                            return new SimpleResponse("The demon giggles.  He then gives you a key.");
                        }
                    },
                    {
                        Command.Attack, _ =>
                        {
                            Program._character.CurrentHealth -= 10;
                            return new SimpleResponse("The demon dodges your attack and slashes in riposte! (hp -10)");
                        }
                    },
                    {
                        Command.Describe, _ =>
                        {
                            return new SimpleResponse("There is a pint size demon sitting on the bed.");
                        }
                    }
                };

        public BedroomDemon()
        {
            CommandHandler = new CommandHandler(commands);
        }
    }
}

using SillyCLID.Definitions;
using SillyCLID.InventoryItems;

namespace SillyCLID.WorldItems
{
	public class MangledCorpse : IInteractableObject
	{
		public string ItemName => "Mangled Corpse";
		public CommandHandler CommandHandler { get; } = new(commands);

		private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands =
			new()
			{
				{
					Command.Describe, _ =>
					{
						return new SimpleResponse("It's mangled pretty badly and unidentifiable.  What could have done this?");
					}
                },
                {
					Command.Search, _ =>
					{
						Console.WriteLine("It's very gross...wet, sticky, and still warm...");
						Utilities.Program._character.AddItemToInventory(new Key_MagicGem(), out var response);
						return new SimpleResponse(response);
					}
				}
			};
	}
}

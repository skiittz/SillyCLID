using SillyCLID.Definitions;

namespace SillyCLID.InventoryItems
{
	internal class Key_MagicGem : IInteractableObject
	{
		public string ItemName => "Magic Gem";
		public CommandHandler CommandHandler { get; } = new(commands);

		private static readonly Dictionary<Command, Func<string[], ICommandResponse>> commands = new()
		{
			{
				Command.Describe, _ =>
				{
					return new SimpleResponse("It's a small gem, warm to the touch");
				}
			}
		};
	}
}

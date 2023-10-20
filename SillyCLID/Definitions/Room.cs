using System.Text;
using SillyCLID.Commands;

namespace SillyCLID.Definitions
{
    public class Room
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int MaxConnections = Enum.GetValues<Direction>().Length;

        public Dictionary<string, IInteractableObject> WorldItems { get; set; } = new();
        public Dictionary<Direction, IJoinRooms> Exits { get; set; } = new();

        public void Describe()
        {
            Console.WriteLine(Description);
            if (WorldItems.Any())
            {
                Console.WriteLine("The room contains:");
                foreach (var interactableObject in WorldItems)
                {
                    var output = new StringBuilder();
                    output.Append($"{interactableObject.Key} - ");
                    var response = interactableObject.Value.CommandHandler.TryHandle(Command.Describe, null);
                    if (response.IsSuccess)
                    {
                        output.Append(response.Output);
                        Console.WriteLine(output);
                    }
                }
            }

            foreach (var exit in Exits)
            {
                Console.WriteLine($"There is a {exit.Value.Name} to the {exit.Key} leading to a {exit.Value.NextRoom.Name}");
            }
            Console.WriteLine();
        }
    }
}

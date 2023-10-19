using System.Text;

namespace SillyCLID.Definitions
{
    public class Room
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
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
                    var response = interactableObject.Value.CommandHandler.TryHandle(Command.Describe, null);
                    if(response.IsSuccess)
                        response.Complete();
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

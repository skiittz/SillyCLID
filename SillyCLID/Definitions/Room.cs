using System.Text;

namespace SillyCLID.Definitions
{
    public class Room
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
        public Dictionary<string, IAmAnInteractableObject> InteractableObjects { get; set; } = new();
        public Dictionary<Direction, IJoinRooms> Exits { get; set; } = new();

        public void Describe()
        {
            var stringBuilder = new StringBuilder(Description);
            stringBuilder.AppendLine();

            if (InteractableObjects.Any())
            {
                stringBuilder.AppendLine("The room contains:");
                stringBuilder.AppendLine();

                foreach (var interactableObject in InteractableObjects)
                {
                    stringBuilder.AppendLine(interactableObject.Value.Describe());
                }

                stringBuilder.AppendLine();
            }

            foreach (var exit in Exits)
            {
                stringBuilder.AppendLine(
                    $"There is a {exit.Value.Name} to the {exit.Key} leading to a {exit.Value.NextRoom.Name}");
            }

            Console.Write(stringBuilder.ToString());
        }
    }
}

using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Doors
{
    public class WoodenDoor : IJoinRooms
    {
        public string Name => "Wooden Door";
        public string TraversalDescription => "You open the door, step through, and close it behind you.";
        public Room NextRoom { get; set; }
        public IBlockRoomJoints TraversalBlock { get; set; }
    }
}

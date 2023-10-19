using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Doors
{
    public class WoodenDoor : IJoinRooms
    {
        public string Name => "Wooden Door";
        public Room NextRoom { get; set; }
        public IBlockRoomJoints TraversalBlock { get; set; }
        public Room Traverse()
        {
            Console.WriteLine("You open the door, step through, and close it behind you.");

            NextRoom.Describe();
            return NextRoom;
        }
    }
}

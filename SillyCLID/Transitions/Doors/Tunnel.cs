using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Doors
{
    internal class Tunnel : IJoinRooms
    {
        public string Name => "Tunnel";
        public Room NextRoom { get; set; }
        public IBlockRoomJoints TraversalBlock { get; set; }

        public Room Traverse()
        {
            if(TraversalBlock == null || TraversalBlock.IsUnlocked)
            Console.WriteLine("You traverse the tunnel unimpeded.");

            NextRoom.Describe();
            return NextRoom;
        }
    }
}

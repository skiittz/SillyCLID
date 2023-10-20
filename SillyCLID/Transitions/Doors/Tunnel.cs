using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Doors
{
    internal class Tunnel : IJoinRooms
    {
        public string Name => "Tunnel";
        public string TraversalDescription => "You traverse the tunnel unimpeded.";
        public Room NextRoom { get; set; }
        public IBlockRoomJoints TraversalBlock { get; set; }
    }
}

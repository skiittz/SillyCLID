using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Doors
{
    internal class ShimmeringPortal : IJoinRooms
    {
        public string Name => "Shimmering Portal";

        public string TraversalDescription =>
            "You step through the portal, passing through cold liquid light, emerging on the other side";
        public Room NextRoom { get; set; }
        public IBlockRoomJoints TraversalBlock { get; set; }
        
    }
}

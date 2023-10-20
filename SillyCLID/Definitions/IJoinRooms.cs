namespace SillyCLID.Definitions
{
    public interface IJoinRooms
    {
        string Name { get; }
        string TraversalDescription { get; }
        Room NextRoom { get; set; }
        IBlockRoomJoints TraversalBlock { get; set; }
    }

    public static class RoomJoinExtensions
    {
        public static void RegisterJoin<T>(this Room sourceRoom, Direction direction, Room destinationRoom, IBlockRoomJoints joinBlock = null) where T : class, IJoinRooms
        {

            var joiner1 = Activator.CreateInstance(typeof(T)) as T;
            joiner1.NextRoom = destinationRoom;

            var joiner2 = Activator.CreateInstance(typeof(T))as T;
            joiner2.NextRoom = sourceRoom;

            if (joinBlock != null)
            {
                joiner1.TraversalBlock = joinBlock;
                joiner2.TraversalBlock = joinBlock;
            }

            sourceRoom.Exits.Add(direction,joiner1);
            destinationRoom.Exits.Add(direction.Opposite(),joiner2);
        }

        public static Room AttemptTraversal(this IJoinRooms joiner)
        {
            if(joiner.TraversalBlock != null)
                joiner.TraversalBlock.AttemptUnlock();

            if (joiner.TraversalBlock == null || joiner.TraversalBlock.IsUnlocked)
                return joiner.Traverse();
            
            joiner.TraversalBlock.FailAttempt();
            return null;
        }

        private static Room Traverse(this IJoinRooms joiner)
        {
            Console.WriteLine(joiner.TraversalDescription);
            joiner.NextRoom.Describe();
            return joiner.NextRoom;
        }
    }
}

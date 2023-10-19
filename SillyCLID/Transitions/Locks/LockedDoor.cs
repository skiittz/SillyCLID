using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Locks
{
    public class LockedDoor : IBlockRoomJoints
    {
        public bool IsUnlocked { get; set; }
        public void AttemptUnlock()
        {
            if (Utilities.Program._character.Inventory.ContainsKey("Bedroom Key")) 
                IsUnlocked = true;
        }

        public void FailAttempt()
        {
            Console.WriteLine("The door is locked.");
        }
    }
}

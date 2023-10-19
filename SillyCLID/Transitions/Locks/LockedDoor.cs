using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Locks
{
    public class LockedDoor : IBlockRoomJoints
    {
        public bool IsUnlocked { get; set; }
        private readonly IInteractableObject key;

        public LockedDoor(IInteractableObject key)
        {
            this.key = key;
        }

        public void AttemptUnlock()
        {
	        if (Utilities.Program._character.Inventory.ContainsKey(key.ItemName))
	        {
		        IsUnlocked = true;
		        Utilities.Program._character.Inventory.Remove(key.ItemName);
		        Console.WriteLine("You insert they key into the hole and turn it.  The door unlocks!");
	        }
        }
           
        public void FailAttempt()
        {
            Console.WriteLine("The door is locked.");
        }
    }
}

using SillyCLID.Definitions;
using SillyCLID.InventoryItems;

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
                IsUnlocked = true;
        }
           
        public void FailAttempt()
        {
            Console.WriteLine("The door is locked.");
        }
    }
}

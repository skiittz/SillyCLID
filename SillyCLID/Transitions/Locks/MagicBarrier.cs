using SillyCLID.Definitions;

namespace SillyCLID.Transitions.Locks
{
    public class MagicBarrier : IBlockRoomJoints
    {
        public bool IsUnlocked { get; set; }
        public IInteractableObject key { get; }

        public MagicBarrier(IInteractableObject key)
        {
            this.key = key;
        }

        public void AttemptUnlock()
        {
            if(Utilities.Program._character.Inventory.ContainsKey(key.ItemName))
                IsUnlocked = true;
        }

        public void FailAttempt()
        {
            Utilities.Program._character.Damage(1);
            Console.WriteLine("You attempt to step through the portal but are thrown backwards.  You stumble on fall on your butt - ow!");
        }

        
    }
}

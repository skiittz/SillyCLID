namespace SillyCLID.Definitions
{
    public interface IBlockRoomJoints
    {
        bool IsUnlocked { get; set; }
        void AttemptUnlock();
        void FailAttempt();
        
    }
}

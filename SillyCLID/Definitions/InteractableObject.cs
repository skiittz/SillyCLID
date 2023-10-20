using SillyCLID.Commands;

namespace SillyCLID.Definitions
{
    public interface IInteractableObject
    { 
        public string ItemName { get; }
        public CommandHandler CommandHandler { get; }
    }


}

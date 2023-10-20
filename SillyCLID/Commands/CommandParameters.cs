using SillyCLID.Definitions;

namespace SillyCLID.Commands;

public class CommandParameters
{
    public Command Command { get; set; }
    public IInteractableObject Target { get; set; }
}
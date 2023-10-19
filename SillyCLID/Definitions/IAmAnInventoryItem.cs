using Microsoft.VisualBasic.CompilerServices;

namespace SillyCLID.Definitions
{
    public interface IAmAnInventoryItem
    {
        string Name { get; }
        Dictionary<string, Func<string>> Commands { get; }
    }
}

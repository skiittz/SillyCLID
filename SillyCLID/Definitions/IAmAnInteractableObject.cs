namespace SillyCLID.Definitions
{
    public interface IAmAnInteractableObject
    {
        string Name { get; }
        Dictionary<string, Func<string>> Commands { get; }

        string Describe();
    }
}

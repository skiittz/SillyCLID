namespace SillyCLID.Commands.Responses;

public interface ICommandResponse
{
    public bool IsSuccess { get; }
    public string Output { get; }
}
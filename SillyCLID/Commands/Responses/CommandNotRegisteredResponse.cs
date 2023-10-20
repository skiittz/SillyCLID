namespace SillyCLID.Commands.Responses;

public class CommandNotRegisteredResponse : ICommandResponse
{
    public bool IsSuccess => false;
    public string Output { get; }
}
namespace SillyCLID.Commands.Responses;

public class SimpleResponse : ICommandResponse
{
    public bool IsSuccess => true;
    public string Output { get; }

    public SimpleResponse(string output)
    {
        Output = output;
    }
}
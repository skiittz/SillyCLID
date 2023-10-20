namespace SillyCLID.Definitions
{
    public class CommandHandler
    {
        private readonly Dictionary<Command, Func<string[], ICommandResponse>> commands;
        public CommandHandler(Dictionary<Command, Func<string[], ICommandResponse>> commands)
        {
            this.commands = commands;
        }

        public ICommandResponse TryHandle(Command command, string[] args)
        {
            if (!commands.ContainsKey(command))
                return new CommandNotRegisteredResponse();

            return commands[command](args);
        }
    }

    public interface ICommandResponse
    {
        public bool IsSuccess { get; }
        public string Output { get; }
    } 

    public class SimpleResponse : ICommandResponse
    {
        public bool IsSuccess => true;
        public string Output { get; }

        public SimpleResponse(string output)
        {
            this.Output = output;
        }
    }

    public class CommandNotRegisteredResponse : ICommandResponse
    {
        public bool IsSuccess => false;
        public string Output { get; }
    }

    public enum Command
    {
        Go,
        Walk,
        Tickle,
        Inspect,
        Remove,
        Tear,
        Attack,
        Describe,
        Search,
        Check
    }

    public class CommandParameters
    {
        public Command Command { get; set; }
        public IInteractableObject Target { get; set; }
    }
}

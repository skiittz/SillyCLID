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
        public void Complete();
    } 

    public class SimpleResponse : ICommandResponse
    {
        public bool IsSuccess => true;
        private readonly string output;

        public SimpleResponse(string output)
        {
            this.output = output;
        }

        public void Complete()
        {
            Console.WriteLine(output);
        }
    }

    public class CommandNotRegisteredResponse : ICommandResponse
    {
        public bool IsSuccess => false;

        public CommandNotRegisteredResponse()
        {

        }

        public void Complete()
        {
            //do nothing
        }
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
        Search
    }

    public class CommandParameters
    {
        public Command Command { get; set; }
        public IInteractableObject Target { get; set; }
    }
}

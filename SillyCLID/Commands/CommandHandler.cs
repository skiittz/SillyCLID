using SillyCLID.Commands.Responses;

namespace SillyCLID.Commands
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
}

namespace SillyCLID.Commands.KeywordHandling
{
    public static class KeywordHandler
    {
        private static Dictionary<Command, Dictionary<Keywords, Func<bool>>> CommandLibrary =
            new Dictionary<Command, Dictionary<Keywords, Func<bool>>>
            {
                {
                    Command.Check, new Dictionary<Keywords, Func<bool>>
                    {
                        {
                            Keywords.Inventory, () =>
                            {
                                {
                                    Utilities.Program._character.CheckInventory();
                                    return true;
                                }
                            }
                        },
                        {
                            Keywords.Room, () =>
                            {
                                {
                                    Utilities.Program._currentRoom.Describe();
                                    return true;
                                }
                            }
                        }
                    }
                }
            };

        public static bool Handle(Command verb, Keywords target)
        {
            return CommandLibrary[verb][target]();
        }
    }
}

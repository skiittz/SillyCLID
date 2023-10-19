using System.ComponentModel.DataAnnotations;
using SillyCLID.Definitions;
using SillyCLID.InteractableItems;
using SillyCLID.Rooms;
using SillyCLID.Transitions.Doors;
using SillyCLID.Transitions.Locks;

namespace SillyCLID.Utilities
{
    public static class Program
    {
        public static Character _character;
        private static Room _currentRoom;

        static void Main(string[] args)
        {
            Initialize();

            string input = String.Empty;
            while (true)
            {
                if (_character.CurrentHealth <= 0)
                {
                    Console.WriteLine("You are dead");
                    break;
                }
                input = Console.ReadLine().ToLower();
                if (input == "quit")
                    break;

                var spaceIndex = input.IndexOf(' ');
                var commandParts = new[]
                {
                    input.Substring(0,spaceIndex),
                    input.Substring(spaceIndex+1,input.Length -(spaceIndex+1))
                };
                
                if (commandParts.Length != 2 || commandParts.Any(x => x == null))
                {
                    Console.WriteLine("That's not a valid command.  Commands should be in the format 'Verb Target'");
                    continue;
                }

                if (input == "check inventory")
                {
                    _character.CheckInventory();
                    continue;
                }

                if (input == "check room")
                {
                    _currentRoom.Describe();
                    continue;
                }

                var verb = commandParts[0].FixCase();
                var targetName = commandParts[1].FixCase();

                if (verb == "Go" || verb == "Walk")
                {
                    Direction targetDirection;
                    if (Direction.TryParse(targetName, out targetDirection))
                    {
                        if (_currentRoom.Exits.ContainsKey(targetDirection))
                        {
                            var newRoom = _currentRoom.Exits[targetDirection].AttemptTraversal();
                            if(newRoom != null)
                                _currentRoom = newRoom;
                            continue;
                        }
                    }
                }

                if (_character.Inventory.ContainsKey(targetName))
                {
                    var target = _character.Inventory[targetName];
                    if (target.Commands.ContainsKey(verb))
                        Console.WriteLine(target.Commands[verb]());

                    continue;
                }

                if (_currentRoom.InteractableObjects.ContainsKey(targetName))
                {
                    var target = _currentRoom.InteractableObjects[targetName];
                    if (target.Commands.ContainsKey(verb))
                        Console.WriteLine(target.Commands[verb]());
                    continue;
                }

                Console.WriteLine("I dont know how to do that....");
            }
        }

        private static void Initialize()
        {
            _character = new Character();
            var spawnRoom = new Bedroom();
            _currentRoom = spawnRoom;

            var hallway = new BedroomHallway();
            var sisterDemon = new BedroomDemon();
            var sistersRoom = new SistersRoom
            {
                InteractableObjects =
                {
                    {sisterDemon.Name, sisterDemon}
                }
            };

            var masterBedroom = new MasterBedroom();
            spawnRoom.RegisterJoin<Tunnel>(Direction.East, hallway);
            hallway.RegisterJoin<WoodenDoor>(Direction.East, sistersRoom);
            hallway.RegisterJoin<WoodenDoor>(Direction.North, masterBedroom, new LockedDoor
            {

            });
            spawnRoom.Spawn();
        }
    }

    public static class Extensions
    {
        public static string FixCase(this string str)
        {
            if (str.Length == 0)
                return String.Empty;
            else if (str.Length == 1)
                return str.ToUpper();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}

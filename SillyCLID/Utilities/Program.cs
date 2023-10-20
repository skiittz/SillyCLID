using System.ComponentModel.DataAnnotations;
using SillyCLID.Definitions;
using SillyCLID.InventoryItems;
using SillyCLID.Rooms;
using SillyCLID.Transitions.Doors;
using SillyCLID.Transitions.Locks;
using SillyCLID.WorldItems;

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
                _character.PrintStatus();
                if (_character.CurrentHealth <= 0)
                {
                    Console.WriteLine("You are dead");
                    Initialize();
                    continue;
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

                if(!Enum.TryParse(commandParts[0], ignoreCase:true, out Command verb))
                {
                    Console.WriteLine("I dont know how to do that....");
                    continue;
                }
                var targetName = commandParts[1].FixCase();

                if (verb == Command.Go || verb == Command.Walk)
                {
                    Direction targetDirection;
                    if (Direction.TryParse(targetName, ignoreCase:true, out targetDirection))
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
                    var response = _character.Inventory[targetName].CommandHandler.TryHandle(verb, null);
                    if (response.IsSuccess)
                    {
                        Console.WriteLine(response.Output);
                        continue;
                    }

                }

                if (_currentRoom.WorldItems.ContainsKey(targetName))
                {
                    var response = _currentRoom.WorldItems[targetName].CommandHandler.TryHandle(verb, null);
                    if (response.IsSuccess)
                    {
                        Console.WriteLine(response.Output);
                        continue;
                    }
                }

                Console.WriteLine("I dont know how to do that....");
            }
        }

        private static void Initialize()
        {
            if (_character == null)
                _character = new Character();

            var spawnRoom = new Bedroom();
            _currentRoom = spawnRoom;

            var hallway = new BedroomHallway();
            var sisterDemon = new BedroomDemon();
            var sistersRoom = new SistersRoom
            {
                WorldItems =
                {
                    {sisterDemon.ItemName, sisterDemon}
                }
            };
            var corpse = new MangledCorpse();
            var masterBedroom = new MasterBedroom{WorldItems = {{corpse.ItemName, corpse}} };
            spawnRoom.RegisterJoin<Tunnel>(Direction.East, hallway);
            hallway.RegisterJoin<WoodenDoor>(Direction.East, sistersRoom);
            hallway.RegisterJoin<WoodenDoor>(Direction.North, masterBedroom, new LockedDoor(new Key_WoodenDoor()));
            var foyer = new MajesticFoyer();
            hallway.RegisterJoin<ShimmeringPortal>(Direction.South, foyer,new MagicBarrier(new Key_MagicGem()));
            spawnRoom.Spawn();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SillyCLID.Definitions;

namespace SillyCLID.Utilities
{
    public static class Generator
    {
        private const int maxRooms = 10;
        private static int RoomCount = 0;

        public static bool GenerateSpawnRoom(out Room room)
        {
            return GenerateRoom(out room, typeInclusions:new[] { typeof(IAmASpawnPoint) });
        }

        public static bool GenerateRoom(out Room result, Type[] typeInclusions = null, Type[] typeExclusions = null)
        {
            if (RoomCount >= maxRooms)
            {
                result = null;
                return false;
            }

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(Room).IsAssignableFrom(p) && p.IsClass && p.Name != "Room")
                .ToArray();

            if (typeInclusions != null && typeInclusions.Any())
                types = types.Where(p => typeInclusions.All(f => f.IsAssignableFrom(p))).ToArray();
            if (typeExclusions != null && typeExclusions.Any())
                types = types.Where(p => !typeExclusions.Any(f => f.IsAssignableFrom(p))).ToArray();

            var randomIndex = new Random().Next(0, types.Length);
            var chosenType = types[randomIndex];

            var room = (Room)chosenType.GetConstructor(Type.EmptyTypes)?.Invoke(null);

            RoomCount++;

            room.PopulateConnections();
            result = room;
            return true;
        }

        private static void PopulateConnections(this Room room)
        {
            var numberOfConnections = new Random().Next(1, room.MaxConnections);
            for (int i = 0; i < numberOfConnections; i++)
            {
                var test1 = Enum.GetValues(typeof(Direction)).Cast<Direction>();
                var test2 = room.Exits.Select(y => y.Key);
                var test3 = test1.Where(x => !room.Exits.Select(y => y.Key).Contains(x));

                var possibleDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>()
                    .Where(x => !room.Exits.Select(y => y.Key).Contains(x))
                    .ToArray();
                if (!possibleDirections.Any())
                    return;

                var randomDirection = possibleDirections[new Random().Next(0,possibleDirections.Length)];
                room.RegisterJoinWithRandomRoom(randomDirection);
            }
        }

        private static void RegisterJoinWithRandomRoom(this Room room, Direction direction)
        {
            if (room.Exits.Select(x => x.Key).Contains(direction))
                return;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IJoinRooms).IsAssignableFrom(p) && p.IsClass && !room.GetType().IsAssignableFrom(p))
                .ToArray();

            var randomIndex = new Random().Next(0, types.Length);
            var chosenType = (Activator.CreateInstance(types[randomIndex]))?.GetType();

            if (!GenerateRoom(out var nextRoom, typeExclusions: new[] { typeof(IAmASpawnPoint) }))
                return;
            
            room.GetType()
                .GetMethod("RegisterJoin")
                .MakeGenericMethod(chosenType)
                .Invoke(room, new object?[]{direction, nextRoom, null});
        }
    }
}

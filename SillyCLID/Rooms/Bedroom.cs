using SillyCLID.Definitions;
using SillyCLID.InventoryItems;

namespace SillyCLID.Rooms
{
    public class Bedroom : Room, IAmASpawnPoint
    {
        public Bedroom()
        {
            Name = "Bedroom";
            Description = "You are in your bedroom.  The sun is pouring though your window.";
        }
        public void Spawn()
        {
            Utilities.Program._character = new Character
            {
                CurrentHealth = 100
            };
            var skirt = new Skirt();
            //do nothing with response
            Utilities.Program._character.AddItemToInventory(skirt, out var response);
            this.Describe();
            Console.WriteLine(" For some reason you appear to be wearing your sister's skirt. " +
                          " You have no memory of putting this on.");
        }
    }
}

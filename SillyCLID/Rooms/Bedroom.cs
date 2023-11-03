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
            MaxConnections = 1;
        }
        public void Spawn()
        {
            if (Utilities.Program._character.CurrentHealth < Utilities.Program._character.MaxHealth)
                Utilities.Program._character.CurrentHealth = Utilities.Program._character.MaxHealth;
            
            Utilities.Program._currentRoom = this;

            var skirt = new Skirt();
            //do nothing with response
            Utilities.Program._character.AddItemToInventory(skirt, out var response);
            this.Describe();
            Console.WriteLine("For some reason you appear to be wearing your sister's skirt. " +
                          " You have no memory of putting this on.");
        }
    }
}

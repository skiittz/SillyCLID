using SillyCLID.Definitions;

namespace SillyCLID.Rooms
{
    public class MasterBedroom : Room
    {
        public MasterBedroom()
        {
            Name = "Master Bedroom";
            Description = "This is was your parent's bedroom.";
            MaxConnections = 1;
        }
    }
}

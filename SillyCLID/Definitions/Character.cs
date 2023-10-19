using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyCLID.Definitions
{
    public class Character
    {
        public int CurrentHealth;
        public Dictionary<string,IAmAnInventoryItem> Inventory = new();
        public Dictionary<string, Func<string>> Abilities = new();

        public void AddItemToInventory(IAmAnInventoryItem item, out string response)
        {
            if (Inventory.ContainsKey(item.Name))
            {
                response = $"What are you doing? You already have {item.Name}!";
                return;
            }

            Inventory.Add(item.Name, item);
            response = $"You have obtained {item.Name}";
        }

        public void CheckInventory()
        {
            var stringBuilder = new StringBuilder("You have:");
            foreach (var item in Inventory)
            {
                stringBuilder.AppendLine($"- {item.Key}");
            }
            Console.Write(stringBuilder);
        }
    }
}

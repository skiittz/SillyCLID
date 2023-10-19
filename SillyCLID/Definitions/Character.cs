using System.Text;

namespace SillyCLID.Definitions
{
    public class Character
    {
        public int CurrentHealth;
        public int MaxHealth => 100;
        public int HealthPercent => (int)(((float)CurrentHealth/(float)MaxHealth)*100);
        public Dictionary<string,IInteractableObject> Inventory = new();
        public Dictionary<string, Func<string>> Abilities = new();

        public void AddItemToInventory<T>(T item, out string response) where T : IInteractableObject
        {
            if (Inventory.ContainsKey(item.ItemName))
            {
                response = string.Empty;
                return;
            }

            Inventory.Add(item.ItemName, item);
            response = $"You have obtained {item.ItemName}";
        }

        public void CheckInventory()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("You have:");
            foreach (var item in Inventory)
            {
                stringBuilder.AppendLine($"- {item.Key}");
            }
            Console.Write(stringBuilder);
        }

        public void PrintStatus()
        {
            var healthBar = new StringBuilder();
            foreach (var i in Enumerable.Range(0,CurrentHealth/10))
            {
                healthBar.Append("|");
            }

            Console.WriteLine($"HP: [{healthBar,-10}] {HealthPercent}%");
        }
    }
}

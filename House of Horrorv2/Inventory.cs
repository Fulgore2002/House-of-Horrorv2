using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_of_Horrorv2
{
    public class Inventory
    {
        private List<string> items;

        public Inventory()
        {
            items = new List<string>();
        }

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"{item} has been added to your inventory.");
        }

        public void RemoveItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine($"{item} is not in your inventory.");
            }
        }

        public bool HasItem(string item)
        {
            return items.Contains(item);
        }

        public void ShowInventory()
        {
            if (items.Count > 0)
            {
                Console.WriteLine("You have the following items in your inventory:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.");
            }
        }
        public void Clear()
        {
            // Clear the player's inventory
            items.Clear();
            Console.WriteLine("Game Over! Your inventory has been cleared.");
        }
    }
}

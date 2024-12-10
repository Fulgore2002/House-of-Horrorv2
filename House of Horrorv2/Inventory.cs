using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace House_of_Horrorv2
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} has been added to your inventory.");
        }

        public void RemoveItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"{item.Name} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine($"{itemName} is not in your inventory.");
            }
        }

        public bool HasItem(string itemName)
        {
            return items.Any(i => i.Name == itemName);
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(i => i.Name == itemName);
        }

        public void Clear()
        {
            items.Clear();
            Console.WriteLine("Game Over! Your inventory has been cleared.");
        }

        public string GetInventoryString()
        {
            if (items.Count == 0)
            {
                return "Your inventory is empty.";
            }

            var inventoryList = "You are carrying:\n";
            foreach (var item in items)
            {
                inventoryList += $"{item.Quantity} x {item.Name}\n";
            }
            return inventoryList;
        }

        public void ShowInventory()
        {
            Console.WriteLine(GetInventoryString());
        }
    }
}

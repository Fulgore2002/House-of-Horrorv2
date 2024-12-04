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

        public void ShowInventory()
        {
            if (items.Count > 0)
            {
                Console.WriteLine("You have the following items in your inventory:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.");
            }
        }

        public void Clear()
        {
            items.Clear();
            Console.WriteLine("Game Over! Your inventory has been cleared.");
        }

        public void LoadItemsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string itemName = parts[0];
                    int quantity = int.Parse(parts[1]);
                    AddItem(new Item(itemName, quantity));
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}

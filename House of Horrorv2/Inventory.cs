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
            try
            {
                items.Add(item);
                Console.WriteLine($"{item.Name} has been added to your inventory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding item: {ex.Message}");
            }
        }

        public void RemoveItem(string itemName)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        public bool HasItem(string itemName)
        {
            try
            {
                return items.Any(i => i.Name == itemName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking item: {ex.Message}");
                return false;
            }
        }

        public Item GetItem(string itemName)
        {
            try
            {
                return items.FirstOrDefault(i => i.Name == itemName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting item: {ex.Message}");
                return null;
            }
        }

        public void Clear()
        {
            try
            {
                items.Clear();
                Console.WriteLine("Game Over! Your inventory has been cleared.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing inventory: {ex.Message}");
            }
        }

        public string GetInventoryString()
        {
            try
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
            catch (Exception ex)
            {
                return $"Error getting inventory: {ex.Message}";
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine(GetInventoryString());
        }
    }
}

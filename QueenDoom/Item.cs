using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Item
    {
        public string Name { get; }
        public bool IsHealing { get; }

        public Item(string name, bool isHealing = false)
        {
            Name = name;
            IsHealing = isHealing;
        }

        public static List<Item> GetPredefinedItems()
        {
            return new List<Item>
            {
                new Item("Silver Cross"),
                new Item("Silver Bullet"),
                new Item("The one ring"),
                new Item("Healing Potion", true)
            };
        }

        public static Item FindItem(Random random)
        {
            var items = GetPredefinedItems();
            return items[random.Next(items.Count)];
        }

        public static bool HasEffectiveItem(List<Item> inventory, Character enemy)
        {
            foreach (Item item in inventory)
                if (!item.IsHealing && item.Name.Contains(enemy.Name))
                    return true;

            return false;
        }

        public static void ShowInventory(List<Item> inventory)
        {
            Console.WriteLine("\nInventory:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }
    }
}

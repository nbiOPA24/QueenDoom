//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace QueenDoom
//{
//    public class Game
//    {
//        Player player;
//        Companion companion;
//        List<Item> inventory;
//        Random random = new Random();

//            public void Start()
//            {
//                player = new Player("Lilith", 100, 20);
//                companion = new Companion("Helper-Companion", 80, 15);
//                inventory = new List<Item>();
//                Console.WriteLine("Welcome to QueenDoom, A text adventure Game");
//                Console.WriteLine("You will have to fight monsters and solve clues and puzzles");
//                Console.WriteLine("Some enemies will see the light and turn to your side, as part of a companion");

//                while (player.IsAlive())
//                {
//                    Console.WriteLine("What would you like to do?");
//                    Console.WriteLine("1. Explore");
//                    Console.WriteLine("2. Check Inventory");
//                    Console.WriteLine("3. Quit");
//                    Console.Write("> ");
//                    string choice = Console.ReadLine();

//                    if (choice == "1") Explore();
//                    else if (choice == "2") ShowInventory();
//                    else if (choice == "3") break;
//                    else Console.WriteLine("Invalid choice. Try again.");
//                }
//            }
//        }
//    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Game
    {
        Player player;
        Companion companion;
        List<Item> inventory;
        Random random = new Random();

        public void Start()
        {
            player = new Player("Lilith", 120, 20);
            companion = new Companion("Friend-companion", 70, 15);
            inventory = new List<Item>();

            Console.WriteLine("Welcome to QueenDoom - A text based adventure");
            Console.WriteLine("You and your companion are on a journey to defeat monsters.");

            while (player.IsAlive())
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Quit");
                Console.Write("> ");
                string choice = Console.ReadLine();

                if (choice == "1") Explore();
                else if (choice == "2") ShowInventory();
                else if (choice == "3") break;
                else Console.WriteLine("Invalid choice. Try again.");
            }

            if (!player.IsAlive()) Console.WriteLine("You have been defeated. Game Over.");
        }

        private void Explore()
        {
            Console.WriteLine("\nTime to become an adventurer");

            if (random.Next(2) == 0)
            {
                Enemy enemy = GenerateEnemy();
                Console.WriteLine($"An Aggresive {enemy.Name} showed his face");

                if (HasEffectiveItem(enemy))
                {
                    Console.WriteLine($"You use an item effective against the {enemy.Name}, instantly defeating it!");
                    RecruitCompanion(enemy);
                }
                else
                {
                    Fight(enemy);
                }
            }
            else
            {
                FindItem();
            }
        }

        private void Fight(Enemy enemy)
        {
            while (enemy.IsAlive() && player.IsAlive())
            {
                Console.WriteLine($"\n{player.Name} HP: {player.Health} | {companion.Name} HP: {companion.Health} | {enemy.Name} HP: {enemy.Health}");
                Console.Write("Choose an action: (attack / flee) > ");
                string action = Console.ReadLine().ToLower();

                if (action == "attack")
                {
                    player.Attack(enemy);
                    if (enemy.IsAlive()) companion.Attack(enemy);
                    if (enemy.IsAlive())
                    {
                        enemy.Attack(player);
                        if (player.IsAlive()) enemy.Attack(companion);
                    }
                }
                else if (action == "Run away")
                {
                    Console.WriteLine("You ran to live another day");
                    return;
                }
            }

            if (!enemy.IsAlive()) RecruitCompanion(enemy);
        }

        private void RecruitCompanion(Enemy enemy)
        {
            Console.WriteLine($"Recruit {enemy.Name} as a companion? (yes/no)");
            if (Console.ReadLine().ToLower() == "yes")
            {
                companion = enemy.RecruitAsCompanion();
                Console.WriteLine($"{enemy.Name} has joined you as a companion!");
            }
        }

        private bool HasEffectiveItem(Character monster)
        {
            foreach (Item item in inventory)
                if (item.IsEffectiveAgainst(monster)) return true;

            return false;
        }

        private void FindItem()
        {
            Item newItem = GenerateItem();
            Console.WriteLine($"You found a {newItem.Name}!");
            inventory.Add(newItem);
        }

        private void ShowInventory()
        {
            Console.WriteLine("\nInventory:");
            if (inventory.Count == 0) Console.WriteLine("Your inventory is empty.");
            else inventory.ForEach(item => Console.WriteLine($"- {item.Name}"));
        }

        private Enemy GenerateEnemy()
        {
            string[] enemyNames = { "Ring Wrath", "Werewolf", "Bat(vampire)" };
            return new Enemy(enemyNames[random.Next(enemyNames.Length)], random.Next(30, 70), random.Next(10, 20));
        }

        private Item GenerateItem()
        {
            string[] itemNames = {"The one ring", "Silver Cross", "Silver Bullet", "Healing Potion" };
            return new Item(itemNames[random.Next(itemNames.Length)]);
        }
    }
}
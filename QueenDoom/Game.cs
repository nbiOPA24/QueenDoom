
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
        private Player player;
        private Companion companion;
        private List<Item> inventory;
        private List<House> map;
        private int currentLocation;
        private Random random = new Random();

        public Game()
        {
            player = new Player("Lilith", 100, 20, 50);
            companion = new Companion("Default Companion", 80, 15);
            inventory = new List<Item>();
            map = House.GetPredefinedMap();
            currentLocation = 0;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to QueenDoom - A text-based adventure");

            while (player.IsAlive())
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Explore the area");
                Console.WriteLine("2. Move to another location");
                Console.WriteLine("3. Check Inventory");
                Console.WriteLine("4. Rest");
                Console.WriteLine("5. Quit");
                Console.Write("> ");
                string choice = Console.ReadLine() ?? string.Empty;

                if (choice == "1") Explore();
                else if (choice == "2") Move();
                else if (choice == "3") Item.ShowInventory(inventory);
                else if (choice == "4") player.Rest();
                else if (choice == "5") break;
                else Console.WriteLine("Invalid choice. Try again.");
            }

            if (!player.IsAlive()) Console.WriteLine("You have been defeated. Game Over.");
        }

        private void Explore()
        {
            Console.WriteLine($"\nExploring {map[currentLocation].Name}: {map[currentLocation].Description}");

            int encounterChance = random.Next(3);
            if (encounterChance == 0)
            {
                var enemy = Enemy.GetPredefinedEnemies()[random.Next(Enemy.GetPredefinedEnemies().Count)];
                Console.WriteLine($"A wild {enemy.Name} appears!");

                if (Item.HasEffectiveItem(inventory, enemy))
                {
                    Console.WriteLine($"You use an effective item against {enemy.Name}, instantly defeating it!");
                    companion = Companion.RecruitCompanion(enemy);
                }
                else
                {
                    Fight(enemy);
                }
            }
            else if (encounterChance == 1)
            {
                var newItem = Item.FindItem(random);
                Console.WriteLine($"You found a {newItem.Name}!");
                inventory.Add(newItem);
            }
            else
            {
                Console.WriteLine("You found nothing of interest here.");
            }
        }

        private void Fight(Enemy enemy)
        {
            while (enemy.IsAlive() && player.IsAlive())
            {
                Console.WriteLine($"\n{player.Name} HP: {player.Health} | Mana: {player.Mana} | {companion.Name} HP: {companion.Health} | {enemy.Name} HP: {enemy.Health}");
                Console.WriteLine("Choose an action: (attack / spell / defend / flee) > ");
                string action = Console.ReadLine()?.ToLower() ?? string.Empty;

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
                else if (action == "spell")
                {
                    MagicSpell.DisplaySpells();
                    Console.Write("Choose a spell (1, 2, 3): ");
                    string spellChoice = Console.ReadLine() ?? string.Empty;

                    if (spellChoice == "1") player.CastSpell(MagicSpell.IceSpear, enemy);
                    else if (spellChoice == "2") player.CastSpell(MagicSpell.FireBreath, enemy);
                    else if (spellChoice == "3") player.CastSpell(MagicSpell.Heal);
                    else Console.WriteLine("Invalid spell choice!");

                    if (enemy.IsAlive())
                    {
                        enemy.Attack(player);
                        if (player.IsAlive()) enemy.Attack(companion);
                    }
                }
                else if (action == "defend")
                {
                    player.Defend();

                    if (enemy.IsAlive())
                    {
                        
                        enemy.Attack(player);
                        if (player.IsAlive()) enemy.Attack(companion);
                    }
                }
                else if (action == "flee")
                {
                    Console.WriteLine("You flee from the battle!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            if (!enemy.IsAlive())
            {
                companion = Companion.RecruitCompanion(enemy);
            }
        }

        private void Move()
        {
            Console.WriteLine("\nChoose a new location to explore:");
            for (int i = 0; i < map.Count; i++)
            {
                Console.WriteLine($"{i}. {map[i].Name} - {map[i].Description}");
            }
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int newLocation) && newLocation >= 0 && newLocation < map.Count)
            {
                currentLocation = newLocation;
                Console.WriteLine($"You move to {map[currentLocation].Name}.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
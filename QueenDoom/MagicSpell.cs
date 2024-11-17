using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class MagicSpell
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Mana { get; set; }

        public MagicSpell(string name, int power, int mana)
        {
            Name = name;
            Power = power;
            Mana = mana;
        }

        public void ChooseTarget(Player player, List<Enemy> enemies)
        {
            Console.WriteLine("Choose your target:");
            Console.WriteLine("1. Enemy");
            Console.WriteLine("2. Yourself");
            Console.Write("> ");
            string targetChoice = Console.ReadLine();

            if (targetChoice == "1")
            {
                if (enemies.Count > 0)
                {
                    Console.WriteLine("Select an enemy:");
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {enemies[i].Name} (HP: {enemies[i].Health})");
                    }
                    Console.Write("> ");
                    if (int.TryParse(Console.ReadLine(), out int enemyIndex) &&
                        enemyIndex > 0 && enemyIndex <= enemies.Count)
                    {
                        Enemy target = enemies[enemyIndex - 1];
                        CastOnTarget(player, target);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. No spell cast.");
                    }
                }
                else
                {
                    Console.WriteLine("There are no enemies to target.");
                }
            }
            else if (targetChoice == "2")
            {
                CastOnSelf(player);
            }
            else
            {
                Console.WriteLine("Invalid choice. No spell cast.");
            }
        }

        private void CastOnTarget(Player player, Enemy target)
        {
            if (player.Mana >= Mana)
            {
                Console.WriteLine($"{player.Name} casts {Name} on {target.Name}!");
                target.TakeDamage(Power);
                player.UseMana(Mana);

                if (!target.IsAlive())
                {
                    Console.WriteLine($"{target.Name} was defeated by the spell!");
                }
                else
                {
                    Console.WriteLine($"{target.Name} survived with {target.Health} HP remaining.");
                }
            }
            else
            {
                Console.WriteLine("Not enough mana to cast the spell!");
            }
        }

        private void CastOnSelf(Player player)
        {
            if (Power == 0)
            {
                Console.WriteLine("You cast a healing spell on yourself.");
                player.Heal(20);
                Console.WriteLine($"Health now {player.Health}.");
            }
            else
            {
                Console.WriteLine("This spell cannot target yourself.");
            }
        }

        public static List<MagicSpell> GetPredefinedSpells()
        {
            return new List<MagicSpell>
            {
                new MagicSpell("Ice Spear", 33, 12),
                new MagicSpell("Fire Breath", 42, 20),
                new MagicSpell("Heal", 0, 10)
            };
        }
    }
}

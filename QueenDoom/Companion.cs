using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Companion : Character
    {
        public Companion(string name, int health, int damage) : base(name, health, damage) { }

        public static Companion RecruitCompanion(Enemy enemy)
        {
            Console.WriteLine($"Recruit {enemy.Name} as a companion? (yes/no)");
            string choice = Console.ReadLine()?.ToLower() ?? string.Empty;
            if (choice == "yes")
            {
                Console.WriteLine($"{enemy.Name} has joined you as a companion!");
                return new Companion(enemy.Name, enemy.Health, enemy.Damage);
            }
            return null;
        }
    }
}

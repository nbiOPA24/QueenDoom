using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        private static Random random = new Random();

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public virtual void TakeDamage(int damage, bool isCrit = false)
        {
            if (isCrit)
            {
                damage *= 2;
                Console.WriteLine($"Crit HIT {Name} takes {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} damage: {damage}");
            }

            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {Damage} damage");
        }

        public void Attack(Character target)
        {
            target.Health -= Damage;
            System.Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage!");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public bool IsCriticalhit()
        {
            return random.Next(0, 100) < 20;
        }
    }
}

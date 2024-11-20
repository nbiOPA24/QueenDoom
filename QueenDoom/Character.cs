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

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {Damage} damage");
        }

        public void Attack(Character target)
        {
            target.Health -= Damage;
            System.Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage!");
        }

        public bool IsAlive() => Health > 0;
    }
}

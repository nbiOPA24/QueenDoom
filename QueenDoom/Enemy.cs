using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Enemy : Character
    {
        public Enemy(string name, int health, int damage) : base(name, health, damage) { }

        public Companion RecruitAsCompanion()
        {
            return new Companion(Name, Health, Damage);
        }

        public static List<Enemy> GetPredefinedEnemies()
        {
            return new List<Enemy>
            {
                new Enemy("Ring-Wrath", 100, 50),
                new Enemy("Werewolf", 70, 20),
                new Enemy("Vampire Bat", 40, 10),
                new Enemy("Cyclops", 60, 8),
                new Enemy("Orc", 60, 18)
            };
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) 
                Health = 0; //Hp kan inte bli negativt
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}


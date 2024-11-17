using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Player : Character
    {
        public int Mana { get; set; }


        public Player(string name, int health, int damage, int mana) : base(name, health, damage) 
        {
            Mana = mana;
        }

        public void UseMana(int manaCost)
        {
            if (Mana >= manaCost)
            {
                Mana -= manaCost;
            }
            else
            {
                Console.WriteLine("Not enough mana for this spell.");
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount} points!");
        }
    }
}

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
        private bool isDefending;

        public Player(string name, int health, int damage, int mana) : base(name, health, damage)
        {
            Mana = mana;
        }

        public bool UseMana(int manaCost)
        {
            if (Mana >= manaCost)
            {
                Mana -= manaCost;
                return true;
            }
            else
            {
                Console.WriteLine("Not enough mana!");
                return false;
            }
        }

        public void Rest()
        {
            int healthRestored = 20;
            int manaRestored = 10;

            Health += healthRestored;
            Mana += manaRestored; 


            if(Health > 100) Health = 100;
            if(Mana > 100) Mana = 100;
            Console.WriteLine($"{Name} You satt down to rest and have restored a portion of your Hp and Mana");
        }

        public void CastSpell(MagicSpell spell, Character target = null)
        {
            if (!UseMana(spell.ManaCost)) return;

            if (spell.IsHealing)
            {
                Health += spell.Damage;
                Console.WriteLine($"{Name} casts {spell.Name} and restores {spell.Damage} health!");
            }
            else if (target != null)
            {
                target.Health -= spell.Damage;
                Console.WriteLine($"{Name} casts {spell.Name}, dealing {spell.Damage} damage to {target.Name}!");
            }
        }

        public void Defend()
        {
            if (isDefending)
            {
                Damage /= 2;
                Console.WriteLine($"{Name} defends, damage reduced {Damage}!");
            }

            isDefending = false;
        }
    }
}

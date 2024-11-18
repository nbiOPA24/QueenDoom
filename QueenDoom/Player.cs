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
    }
}

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
        public string Name { get; }
        public int ManaCost { get; }
        public int Damage { get; }
        public bool IsHealing { get; }

        public MagicSpell(string name, int manaCost, int damage, bool isHealing = false)
        {
            Name = name;
            ManaCost = manaCost;
            Damage = damage; 
            IsHealing = isHealing;
        }

        public static MagicSpell IceSpear => new MagicSpell("Ice super Spear", 20, 50);
        public static MagicSpell FireBreath => new MagicSpell("Fire Breath", 15, 50);
        public static MagicSpell Heal => new MagicSpell("Heal", 20, 30, true);

        public static void DisplaySpells()
        {
            Console.WriteLine("\nAvailable Spells:");
            Console.WriteLine("1. Ice Spear (10 Mana, 30 Damage)");
            Console.WriteLine("2. Fire Breath (15 Mana, 50 Damage)");
            Console.WriteLine("3. Heal (20 Mana, Restores 30 Health)");
        }
    }
}

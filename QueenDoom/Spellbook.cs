using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Spellbook
    {
        private Player player;
        private List<MagicSpell> spells;
        private List<Enemy> enemyPool;
        private Random random = new Random();

        public Spellbook(Player player, List<MagicSpell> spells)
        {
            this.player = player;
            this.spells = spells;

            enemyPool = Enemy.GetPredefinedEnemies();
        }

        public void Show()
        {
            Console.WriteLine("?\nSpells of Choice");
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {spells[i].Name} (Damage: {spells[i].Damage}, Mana: {spells[i].ManaCost})");
            }

            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int spellIndex) && spellIndex > 0 && spellIndex <= spells.Count)
            {
                MagicSpell selectedSpell = spells[spellIndex - 1];
            }
            else
            {
                Console.WriteLine("Wrong spell selected");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Item
    {
        public string Name { get; private set; }

        public Item(string name)
        {
            Name = name;
        }

        public bool IsEffectiveAgainst(Character monster)
        {
            return (Name == "Wooden Stake" && monster.Name == "Bat(Vampire)") ||
                   (Name == "Silver Bullet" && monster.Name == "Werewolf");
        }
    }
}

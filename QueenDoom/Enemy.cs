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

        public Companion RecruitAsCompanion() => new Companion(Name, Health, Damage);
    }
}

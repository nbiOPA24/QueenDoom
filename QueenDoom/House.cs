using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class House
    {
        public string Name { get; }
        public string Description { get; }
        public int North { get; }
        public int South { get; }
        public int East { get; }
        public int West { get; }

        public House(string name, string description, int north, int south, int east, int west)
        {
            Name = name;
            Description = description;
            North = north;
            South = south;
            East = east;
            West = west;
        }
    }
}

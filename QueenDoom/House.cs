using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class House
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public House(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}

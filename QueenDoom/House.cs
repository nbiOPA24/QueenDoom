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

        public static List<House> GetPredefinedMap()
        {
            return new List<House>
            {
                new House("Road", "Start of your Adventure begins here"),
                new House("Main-House A", "Old barn house with broken windows."),
                new House("Side-HouseB", "A smaller house connected to house A."),
                new House("Side-HouseC", "A smaller house connected to house A."),
                new House("BackYard", "Backyard behind the 3 houses")
            };
        }
    }
}

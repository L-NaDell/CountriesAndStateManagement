using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries_State_Management.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string OfficialLanguages { get; set; }
        public string Greeting { get; set; }
        public string Description { get; set; }
        public List<string> Colors { get; set; }

        public Country(string name, string officialLanguages, string greeting, string description, List<string> colors)
        {
            Name = name;
            OfficialLanguages = officialLanguages;
            Greeting = greeting;
            Description = description;
            Colors = colors;
        }
    }
}

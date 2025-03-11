using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMAUI.Models
{
    public class Couleur
    {
        public string Name { get; set; }
        public string Hex { get; set; }

        public Couleur(string name, string hex)
        {
            Name = name;
            Hex = hex;
        }

        public override string ToString() => Name;
    }
}

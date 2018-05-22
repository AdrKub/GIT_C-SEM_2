using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_4_1
{
    public class Mitarbeiter
    {
        public int Personalnummer { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Abteilung { get; set; }
        public string Strasse { get; set; }
        public int Postleitzahl { get; set; }
        public string Wohnort { get; set; }
        public string Telefon { get; set; }
        public double Salaer { get; set; }

        public override string ToString()
        {
            return $"Pers.Nr:{Personalnummer}, Name:{Name}, Vorname:{Vorname}, Abteilung:{Abteilung},\nStrasse:{Strasse}, PLZ:{Postleitzahl}, Wohnort:{Wohnort},\nTelefon: {Telefon}, Salaer{Salaer}\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMitAttributen
{
    [CustomDebug("Die Klasse beschreibt ein Hund")]
    public class Hund
    {
        public string Name { get; set; }

        [CustomDebug("Die Eigenschaft ist Rasse")]
        public string Rasse { get; set; }
        public int Alter { get; set; }

        [CustomDebug("Die Methode für Bellen")]
        public void Bellen()
        {

        }
    }
}

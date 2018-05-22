using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_4_1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Mitarbeiter> MitarbeiterListe = new List<Mitarbeiter>
            {
                new Mitarbeiter{Personalnummer = 7500, Abteilung = 4000, Name = "Abderhalden", Vorname = "Andreas", Postleitzahl = 8001, Salaer = 70000, Strasse = "Teststrasse1", Telefon = "041 111 111 111", Wohnort = "Zürich" },
                new Mitarbeiter{Personalnummer = 7501, Abteilung = 9000, Name = "Tanner", Vorname = "Barbara", Postleitzahl = 4001, Salaer = 80000, Strasse = "Teststrasse2", Telefon = "041 111 111 222", Wohnort = "Basel" },
                new Mitarbeiter{Personalnummer = 8500, Abteilung = 3000, Name = "Meier", Vorname = "Celin", Postleitzahl = 5001, Salaer = 85000, Strasse = "Teststrasse3", Telefon = "041 111 111 333", Wohnort = "Bern" },
                new Mitarbeiter{Personalnummer = 8600, Abteilung = 8000, Name = "Siebert", Vorname = "Dorian", Postleitzahl = 7010, Salaer = 90000, Strasse = "Teststrasse4", Telefon = "041 111 111 444", Wohnort = "Luzern" },
                new Mitarbeiter{Personalnummer = 4500, Abteilung = 3000, Name = "Müller", Vorname = "Emil", Postleitzahl = 8002, Salaer = 100000, Strasse = "Teststrasse5", Telefon = "041 111 111 555", Wohnort = "Zürich" },
                new Mitarbeiter{Personalnummer = 4300, Abteilung = 3000, Name = "Rüdisüli", Vorname = "Florian", Postleitzahl = 4002, Salaer = 120000, Strasse = "Teststrasse6", Telefon = "041 111 111 666", Wohnort = "Basel" },
                new Mitarbeiter{Personalnummer = 5000, Abteilung = 2000, Name = "Kubli", Vorname = "Gunter", Postleitzahl = 5001, Salaer = 75000, Strasse = "Teststrasse7", Telefon = "041 111 111 777", Wohnort = "Bern" },
                new Mitarbeiter{Personalnummer = 5060, Abteilung = 3000, Name = "Volkomm", Vorname = "Hans", Postleitzahl = 7000, Salaer = 100001, Strasse = "Teststrasse8", Telefon = "041 111 111 888", Wohnort = "Luzern" },
                new Mitarbeiter{Personalnummer = 9000, Abteilung = 4000, Name = "Waser", Vorname = "Isabelle", Postleitzahl = 8003, Salaer = 110000, Strasse = "Teststrasse9", Telefon = "041 111 111 999", Wohnort = "Zürich" },
                new Mitarbeiter{Personalnummer = 9001, Abteilung = 3000, Name = "Zumkon", Vorname = "Kurt", Postleitzahl = 4003, Salaer = 100500, Strasse = "Teststrasse10", Telefon = "041 111 111 000", Wohnort = "Basel" }
            };

            Console.ReadLine();


            IEnumerable<Mitarbeiter> nachnamequery = from _mitarbeiter in MitarbeiterListe
                                                     orderby _mitarbeiter.Name descending
                                                     select _mitarbeiter;

            foreach(Mitarbeiter mit in nachnamequery)
                Console.WriteLine(mit);

            Console.ReadLine();
            Console.Clear();

            IEnumerable<IGrouping<int, Mitarbeiter>> abteilungquery = from _mitarbeiter in MitarbeiterListe
                                                      group _mitarbeiter by _mitarbeiter.Abteilung;


            foreach (var gruppe in abteilungquery) {
                Console.WriteLine($"Abteilung:{gruppe.Key}");
                foreach (Mitarbeiter mit in gruppe)
                {
                    Console.WriteLine(mit);
                }
             }

            Console.ReadLine();
            Console.Clear();

            IEnumerable<Mitarbeiter> salaerquery = from _mitarbeiter in MitarbeiterListe
                                                   where _mitarbeiter.Salaer > 100000
                                                   select _mitarbeiter;

            foreach (Mitarbeiter mit in salaerquery)
                Console.WriteLine(mit);

            Console.ReadLine();
            Console.Clear();


            var MitSalaerGroesser100000 = MitarbeiterListe
                                                .Where(salaer => salaer.Salaer > 100000)
                                                .Select( _mitarbeiter => new {_mitarbeiter});

            foreach (var mit in MitSalaerGroesser100000)
                Console.WriteLine(mit);

            Console.ReadLine();

            var WohnortKleiner6 = MitarbeiterListe
                                                .Where(city => city.Wohnort.Length < 6)
                                                .Select(_mitarbeiter => new { _mitarbeiter });

            foreach (var mit in WohnortKleiner6)
                Console.WriteLine(mit);

            Console.ReadLine();
        }
    }
}

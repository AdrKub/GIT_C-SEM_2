using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakultaetRek
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputval;

            Console.WriteLine("Bitte Zahl eingeben:");
            inputval = Int32.Parse(Console.ReadLine());

            Console.WriteLine(Fakultaet(inputval).ToString());
            Console.ReadLine();

            int Fakultaet(int nval)
            {
                if (nval > 1)
                    return nval * (Fakultaet(nval - 1));
                else
                    return 1;
            }
        }
    }
}

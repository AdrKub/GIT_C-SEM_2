using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultaet
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputval;

            while (true)
            {
                Console.WriteLine("Bitte Zahl eingeben:");
                inputval = Int32.Parse(Console.ReadLine());

                Console.WriteLine(Fakultaet(inputval).ToString());
                Console.ReadLine();
            }

            int Fakultaet(int nval)
            {
                int val = 1;
                for (int i = 1; i <= nval; i++)
                {
                    val = val * i;
                }
                return val;
            }
        }



        
    }
}

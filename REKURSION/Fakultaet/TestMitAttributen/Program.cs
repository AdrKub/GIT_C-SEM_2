using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMitAttributen
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCustomAttributes();
            Console.ReadLine();


            void ReadCustomAttributes()
            {
                CustomDebugAttribute cstmDebugAttr;
                string assName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe";
                Assembly assembly = Assembly.LoadFrom(assName);

                foreach(Attribute attr in assembly.GetCustomAttributes(true))
                {
                    cstmDebugAttr = attr as CustomDebugAttribute;
                    if(cstmDebugAttr != null)
                    {
                        Console.WriteLine("ASSEMBLY TEST {0} -> {1}", assName, cstmDebugAttr.Beschreibung);
                        Console.WriteLine();
                    }
                }

                //foreach(Attribute attr in assembly.Get)
            }
        }
    }
}

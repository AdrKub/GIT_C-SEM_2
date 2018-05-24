using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_1_GLUEFTUNG.Model
{
    public class Engine
    {
        public Engine()
        {
            Act_speed = 0.0;
            Act_current = 0.0;
            Act_voltage = 0.0;
            Act_power = 0.0;
            Eng_IsOn = "AUS";
        }

        public double Act_speed;
        public double Act_current;
        public double Act_voltage;
        public double Act_power;
        public string Eng_IsOn;
    }
}

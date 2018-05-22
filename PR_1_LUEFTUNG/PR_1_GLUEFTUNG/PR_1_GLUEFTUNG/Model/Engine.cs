using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_1_GLUEFTUNG.Model
{
    public class Engine
    {
        private double _actSpeed;
        private double _actCurrent;
        private double _actVoltage;
        private double _actPower;
        private string _isOn;

        public Engine()
        {
            _actSpeed = 0.0;
            _actCurrent = 0.0;
            _actPower = 0.0;
            _actVoltage = 0.0;
            _isOn = "AUS";
        }

        public double Act_speed
        {
            get { return _actSpeed; }

            set { _actSpeed = value; }
        }

        public double Act_current
        {
            get { return _actCurrent; }

            set { _actCurrent = value; }
        }

        public double Act_voltage
        {
            get { return _actVoltage; }

            set { _actVoltage = value; }
        }

        public double Act_power
        {
            get { return _actPower; }

            set { _actPower = value; }
        }

        public string Eng_IsOn
        {
            get { return _isOn; }

            set { _isOn = value; }
        }
    }
}

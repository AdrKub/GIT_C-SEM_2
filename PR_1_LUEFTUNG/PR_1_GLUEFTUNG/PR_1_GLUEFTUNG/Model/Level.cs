using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_1_GLUEFTUNG.Model
{
    public class Level
    {
        private double _levelStartUpTime;
        private int _lvlNumber;
        private double _shouldSpeed;
        private double _shouldPower;

        public Level()
        {
            _levelStartUpTime = 3000.0;
            _lvlNumber = 0;
            _shouldPower = 10.0;
            _shouldSpeed = 100.0;
        }

        public double LvlStartUpTime
        {
            get { return _levelStartUpTime; }
            set { _levelStartUpTime = value; }
        }

        public int LvlNumber
        {
            get { return _lvlNumber; }
            set { _lvlNumber = value; }
        }

        public double LvlShouldSpeed
        {
            get { return _shouldSpeed; }
            set { _shouldSpeed = value; }
        }

        public double LvlShouldPower
        {
            get { return _shouldPower; }
            set { _shouldPower = value; }
        }
    }
}

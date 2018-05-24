using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_1_GLUEFTUNG.Model
{
    public class Level
    {
        public Level()
        {
            LvlStartUpTime = 3000.0;
            LvlNumber = 0;
            LvlShouldSpeed = 10.0;
            LvlShouldPower = 100.0;
        }

        public double LvlStartUpTime;
        public int LvlNumber;
        public double LvlShouldSpeed;
        public double LvlShouldPower;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PR_1_GLUEFTUNG.Timer
{
    public class CycleTimer
    {
        private static System.Timers.Timer _timer;
        private bool _timerElapsed = false;
        private Action _elapsed;//ACTION = Funkion ohne Rückgabewerte

        public CycleTimer(Action elapsed)
        {
            _elapsed = elapsed ?? throw new ArgumentNullException("elapsed");
        }

        public void StartTimer(double duration)
        {
            _timer = new System.Timers.Timer(duration);
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void TimerElapsed(Object source, ElapsedEventArgs e)
        {
            _elapsed();
        }
    }
}

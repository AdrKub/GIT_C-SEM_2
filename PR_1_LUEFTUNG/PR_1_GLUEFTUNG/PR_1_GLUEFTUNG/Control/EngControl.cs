using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using PR_1_GLUEFTUNG.Model;
using PR_1_GLUEFTUNG.Timer;
using PR_1_GLUEFTUNG.DB_Model;


namespace PR_1_GLUEFTUNG.Control
{
    public class EngControl: INotifyPropertyChanged
    {
        private double _accdecelerateTimeStep;
        private double _loggerTimeStep;
        private double _elapsedAccDecTime;
        private bool _nextstep;
        private bool _loggerOnOff;
        private double _steps;
        private double _powerStepWidth;
        private double _speedStepWidth;
        private double _targetTime;
        private CycleTimer _timerAccDec;
        private CycleTimer _timerLogger;
        private Engine _engine;
        private WriteLog _logger;

        public bool AccDecIsActive;

        public EngControl()
        {
            _accdecelerateTimeStep = 50.0;
            _loggerTimeStep = 1000.0;
            _logger = new WriteLog();
            _engine = new Engine();
            InitAccDecTimer();
            InitLoggerTimer();
        }

        #region ENGINE PROPERTIES
        public double Eng_Voltage
        {
            get { return _engine.Act_voltage; }
            set
            {
                _engine.Act_voltage = value;
                RaisePropertyChanged("Eng_Voltage");
            }
        }

        public double Eng_Speed
        {
            get { return _engine.Act_speed; }
            set
            {
                _engine.Act_speed = value;
                RaisePropertyChanged("Eng_Speed");
            }
        }

        public double Eng_Power
        {
            get { return _engine.Act_power; }
            set
            {
                _engine.Act_power = value;
                RaisePropertyChanged("Eng_Power");
            }
        }

        public double Eng_Current
        {
            get { return _engine.Act_current; }
            set
            {
                _engine.Act_current = value;
                RaisePropertyChanged("Eng_Current");
            }
        }

        public string Eng_IsOnOff
        {
            get { return _engine.Eng_IsOn; }
            set
            {
                _engine.Eng_IsOn = value;
                RaisePropertyChanged("Eng_IsOnOff");
            }
        }
        #endregion

        #region ACC/DECELERATE ENGINE
        public void StartAccelerate(double trgSpeed, double trgPower, double trgTime)
        {
            if (trgPower > 0 && trgSpeed > 0 && trgTime > 0)
            {
                _elapsedAccDecTime = 0.0;
                _steps = trgTime / _accdecelerateTimeStep;
                _powerStepWidth = (trgPower - Eng_Power) / _steps;
                _speedStepWidth = (trgSpeed - Eng_Speed) / _steps;
                _targetTime = trgTime;
                _nextstep = true;

                _timerAccelerate.StartTimer(_accdecelerateTimeStep);
                AccDecIsActive = true;
            }
        }

        public void StartDecelerate(double trgTime)
        {
            if (trgTime > 0)
            {
                _elapsedAccDecTime = 0.0;
                _steps = trgTime / _accdecelerateTimeStep;
                _powerStepWidth = Eng_Power / _steps;
                _speedStepWidth = Eng_Speed / _steps;
                _targetTime = trgTime;
                _nextstep = false;

                _timerAccelerate.StartTimer(_accdecelerateTimeStep);
                AccDecIsActive = true;
            }
        }

        private void Accelerate()
        {
            if(_elapsedAccDecTime > _targetTime)
            {
                _timerAccelerate.StopTimer();
                AccDecIsActive = false;
            }
            else {
                Eng_IsOnOff = "EIN";
                Eng_Voltage = 230.0;
                Eng_Speed = Eng_Speed + _speedStepWidth;
                Eng_Power = Eng_Power + _powerStepWidth;
                Eng_Current = (Eng_Power / Eng_Voltage) * 1000.0;
            }
        }
        
        private void Decelerate()
        {
            if (_elapsedAccDecTime >= _targetTime)
            {
                _timerAccelerate.StopTimer();
                AccDecIsActive = false;
                Eng_IsOnOff = "AUS";
                Eng_Voltage = 0.0;
                Eng_Speed = 0.0;
                Eng_Power = 0.0;
                Eng_Current = 0.0;
            }
            else
            {
                Eng_Speed = Eng_Speed - _speedStepWidth;
                Eng_Power = Eng_Power - _powerStepWidth;
                Eng_Current = (Eng_Power / Eng_Voltage) * 1000.0;
            }
        }
        #endregion

        #region TIMER ACC/DEC

        private void InitAccDecTimer()
        {
            _timerAccDec = new CycleTimer(AccDecTimerElapsed);
        }

        private void AccDecTimerElapsed()
        {
            _elapsedAccDecTime = _elapsedAccDecTime + _accdecelerateTimeStep;
            if (_nextstep)
                Accelerate();
            else
                Decelerate();
        }
        #endregion

        #region TIMER LOGGER

        private void InitLoggerTimer()
        {
            _timerLogger = new CycleTimer(LoggerTimerElapsed);
        }

        private void LoggerTimerElapsed()
        {
            _logger.WriteLogEntry(_engine);
        }
        #endregion

        #region COMMANDS
        public ICommand OnOffLog
        {
            get
            {
                return new RelayCommand(SwitchOnOffLog, OnOffLogCanExecute);
            }
        }

        bool OnOffLogCanExecute()
        {
            return true;
        }

        void SwitchOnOffLog()
        {
            if (_loggerOnOff)
            {
                _loggerOnOff = false;
                _timerLogger.StopTimer();
            }
            else
            {
                _loggerOnOff = true;
                _timerLogger.StartTimer(_loggerTimeStep);
            }
        }
        #endregion

        #region CHANGE PROPERTY
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

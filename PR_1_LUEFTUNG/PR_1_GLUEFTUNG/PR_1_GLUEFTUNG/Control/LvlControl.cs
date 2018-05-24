using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using PR_1_GLUEFTUNG.Model;
using PR_1_GLUEFTUNG.Timer;


namespace PR_1_GLUEFTUNG.Control
{
    public class LvlControl : INotifyPropertyChanged
    {
        private EngControl _engineCtrl;
        private List<Level> _availableLvls;
        private int _actLevel;

        public LvlControl(EngControl engctrl)
        {
            _actLevel = 0;
            _availableLvls = new List<Level>();
            _engineCtrl = engctrl;
            InitLvls();
        }

        public int ActiveLevel
        {
            get { return _actLevel; }
            set {
                    _actLevel = value;
                RaisePropertyChanged("ActiveLevel");
                }
        }

        #region GENERAL FUNCTIONS
        private void LCtrl_SwitchOff()
        {
            double _trgTime;
            double _lvl = Convert.ToDouble(_actLevel);

            if (_actLevel > 0)
            {
                _trgTime = ((_lvl * _lvl) * 10) * 1000;
                _engineCtrl.StartDecelerate(_trgTime);
                ActiveLevel = 0;
            }
        }

        private void LCtrl_ChangeLevel(int lvlNumber)
        {
            foreach (Level lvl in _availableLvls)
            {
                if (lvl.LvlNumber == lvlNumber)
                {
                    _engineCtrl.StartAccelerate(lvl.LvlShouldSpeed, lvl.LvlShouldPower, lvl.LvlStartUpTime);
                    ActiveLevel = lvlNumber;
                }
            }
        }
        #endregion

        #region COMMANDS
        public ICommand RequestLevel1
        {
            get
            {
                return new RelayCommand(ChangeToLevel1, RequestLevel1CanExecute);
            }
        }
        public ICommand RequestLevel2
        {
            get
            {
                return new RelayCommand(ChangeToLevel2, RequestLevel2CanExecute);
            }
        }
        public ICommand RequestLevel3
        {
            get
            {
                return new RelayCommand(ChangeToLevel3, RequestLevel3CanExecute);
            }
        }
        public ICommand RequestLevelOff
        {
            get
            {
                return new RelayCommand(ChangeToOff, RequestLevelOffCanExecute);
            }
        }

        bool RequestLevel1CanExecute()
        {
            if ((ActiveLevel == 0 || ActiveLevel == 2) && ActiveLevel != 1)
                return true;
            else
                return false;
        }
        bool RequestLevel2CanExecute()
        {
            if ((ActiveLevel == 1 || ActiveLevel == 3) && ActiveLevel != 2)
                return true;
            else
                return false;
        }
        bool RequestLevel3CanExecute()
        {
            if (ActiveLevel == 2 && ActiveLevel != 3)
                return true;
            else
                return false;
        }
        bool RequestLevelOffCanExecute()
        {
            return true;
        }

        void ChangeToLevel1()
        {
            if(_engineCtrl.AccDecIsActive == false)
                LCtrl_ChangeLevel(1);
        }
        void ChangeToLevel2()
        {
            if (_engineCtrl.AccDecIsActive == false)
                LCtrl_ChangeLevel(2);
        }
        void ChangeToLevel3()
        {
            if (_engineCtrl.AccDecIsActive == false)
                LCtrl_ChangeLevel(3);
        }
        void ChangeToOff()
        {
            LCtrl_SwitchOff();
        }
        #endregion

        #region INIT FUNCTIONS
        private void InitLvls()
        {
            Level _lvl1 = new Level() { LvlNumber = 1, LvlShouldPower = 15.0, LvlShouldSpeed = 30.0, LvlStartUpTime = 5000.0 };
            Level _lvl2 = new Level() { LvlNumber = 2, LvlShouldPower = 45.0, LvlShouldSpeed = 60.0, LvlStartUpTime = 5000.0 };
            Level _lvl3 = new Level() { LvlNumber = 3, LvlShouldPower = 60.0, LvlShouldSpeed = 90.0, LvlStartUpTime = 5000.0 };
            _availableLvls.Add(_lvl1);
            _availableLvls.Add(_lvl2);
            _availableLvls.Add(_lvl3);
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

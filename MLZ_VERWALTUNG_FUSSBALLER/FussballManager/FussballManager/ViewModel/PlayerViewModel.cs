using FussballManager.Model;
using _20_MvvmFramework;

namespace FussballManager.ViewModel
{
    public class PlayerViewModel : ObservableObject
        {
        private Player _player;

        public PlayerViewModel(Player inplayer)
        {
            _player = inplayer;
        }

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
                RaisePropertyChanged();
            }
        }

        public Position Position
        {
            get { return _player.Position; }
        }

        public Team Team
        {
            get { return _player.Team; }
        }

        public string CompleteName
        {
            get { return _player.Name + " " + _player.FirstName; }
        }

        public string PositionName
        {
            get { return _player.Position.PosName; }
        }

        #endregion
    }
}

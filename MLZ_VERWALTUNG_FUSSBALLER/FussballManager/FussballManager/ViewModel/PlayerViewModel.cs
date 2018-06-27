using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.Model;
using _20_MvvmFramework;

namespace FussballManager.ViewModel
{
    public class PlayerViewModel : ObservableObject
        {
        private Player player;

        public PlayerViewModel(Player inplayer)
        {
            player = inplayer;
        }

        #region Properties
        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                RaisePropertyChanged();
            }
        }

        public Position Position
        {
            get { return player.Position; }
        }

        public Team Team
        {
            get { return player.Team; }
        }
        
        public string CompleteName
        {
            get { return player.Name + " " + player.FirstName; }
        }

        public string PositionName
        {
            get { return player.Position.PosName; }
        }

        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.DataAccess;
using FussballManager.Model;
using System.Windows.Input;

namespace FussballManager.ViewModel
{
    public class TestViewModel
    {
        //private ObservableCollection<PlayerViewModel> fPlayers;
        private TeamPlayerRepository footballRepository = new TeamPlayerRepository();

        public ObservableCollection<PlayerViewModel> SelPlayers { get; set; }
        public ObservableCollection<Position> AllPositions { get; set; }
        public PlayerViewModel SelPlayer { get; set; }


        public TestViewModel()
        {
            SelPlayers = new ObservableCollection<PlayerViewModel>();
            AllPositions = new ObservableCollection<Position>();
            Player tmp = new Player();
            SelPlayer = new PlayerViewModel(tmp);

            foreach(Player pl in footballRepository.TestLoadPlayers())
            {
                SelPlayers.Add(new PlayerViewModel(pl));
            }

            foreach (Position pos in footballRepository.LoadAllPositions())
            {
                AllPositions.Add(pos);
            }
        }

        

    }
}
